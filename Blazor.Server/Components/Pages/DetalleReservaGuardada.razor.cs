using Blazor.Server.Auth;
using DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using System.Text;

namespace Blazor.Server.Components.Pages
{
    public partial class DetalleReservaGuardada : ComponentBase
    {
        [Parameter] public int ReservaId { get; set; }

        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;
        [Inject] public ProtectedLocalStorage LocalStorage { get; set; } = default!;
        [Inject] public CustomAuthenticationStateProvider AuthStateProvider { get; set; } = default!;
        [Inject] public IJSRuntime JS { get; set; } = default!;

        private bool cargando = true;
        private string? mensajeError;
        private ReservaDTO? reserva;
        private VueloDTO? vuelo;
        private string estadoCalculado = "Pendiente";

        protected override async Task OnInitializedAsync()
        {
            await CargarDetalleAsync();
        }

        private async Task CargarDetalleAsync()
        {
            try
            {
                cargando = true;
                mensajeError = null;

                var todasReservas = await Http.GetFromJsonAsync<List<ReservaDTO>>("reservas") ?? new();
                reserva = todasReservas.FirstOrDefault(r => r.Id == ReservaId);

                if (reserva == null)
                {
                    mensajeError = $"No se encontró la reserva #{ReservaId}.";
                    return;
                }

                var todosVuelos = await Http.GetFromJsonAsync<List<VueloDTO>>("vuelos") ?? new();
                vuelo = todosVuelos.FirstOrDefault(v => v.Id == reserva.VueloId);

                if (vuelo != null)
                {
                    estadoCalculado = vuelo.FechaHoraVuelo >= DateTime.Now ? "Pendiente" : "Finalizada";
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al obtener el detalle de la reserva: {ex.Message}";
            }
            finally
            {
                cargando = false;
            }
        }

        private decimal CalcularTotal()
        {
            if (reserva == null) return 0m;

            decimal precioVuelo = vuelo?.Precio ?? 0m;
            decimal totalVuelos = precioVuelo * reserva.Pasajes.Count;
            decimal totalServicios = reserva.Pasajes
                .SelectMany(p => p.Servicios ?? new())
                .Sum(s => s.Precio);

            return totalVuelos + totalServicios;
        }

        private async Task DescargarComprobante()
        {
            if (reserva == null) return;

            var sb = new StringBuilder();
            sb.AppendLine("=== AERORESERVAS - DETALLE DE RESERVA ===");
            sb.AppendLine($"Número de Reserva: #{reserva.Id}");
            sb.AppendLine($"Estado: {estadoCalculado}");
            sb.AppendLine($"Fecha de reserva: {reserva.FechaHoraReserva:dd/MM/yyyy HH:mm}");
            sb.AppendLine();

            if (vuelo != null)
            {
                sb.AppendLine("--- VUELO ---");
                sb.AppendLine($"Ruta: {vuelo.CiudadOrigen.Nombre} -> {vuelo.CiudadDestino.Nombre}");
                sb.AppendLine($"Fecha y Hora: {vuelo.FechaHoraVuelo:dd/MM/yyyy HH:mm}");
                sb.AppendLine($"Aerolínea: {vuelo.Aerolinea}");
                sb.AppendLine($"Precio unitario: $ {vuelo.Precio:N2}");
                sb.AppendLine();
            }

            sb.AppendLine("--- PASAJEROS Y SERVICIOS ---");
            for (int i = 0; i < reserva.Pasajes.Count; i++)
            {
                var p = reserva.Pasajes[i];
                var serviciosTexto = (p.Servicios != null && p.Servicios.Count > 0)
                    ? string.Join(", ", p.Servicios.Select(s => $"{s.Nombre} (${s.Precio:N2})"))
                    : "Ninguno";

                sb.AppendLine($"{i + 1}. {p.Pasajero?.Nombre} {p.Pasajero?.Apellido} ({p.Pasajero?.Tipo}) - {p.Pasajero?.TipoDocumento}: {p.Pasajero?.NroDocumento}");
                sb.AppendLine($"   Avión #{p.IdAvion} · Asiento {p.CodigoAsiento}");
                sb.AppendLine($"   Servicios: {serviciosTexto}");
            }

            sb.AppendLine();
            sb.AppendLine($"TOTAL: $ {CalcularTotal():N2}");

            var bytes = Encoding.UTF8.GetBytes(sb.ToString());
            var base64 = Convert.ToBase64String(bytes);
            var nombreArchivo = $"Reserva_{reserva.Id}.txt";

            await JS.InvokeVoidAsync("eval", $@"
                const link = document.createElement('a');
                link.href = 'data:text/plain;charset=utf-8;base64,{base64}';
                link.download = '{nombreArchivo}';
                document.body.appendChild(link);
                link.click();
                document.body.removeChild(link);
            ");
        }

        private void VolverAMisReservas()
        {
            Navigation.NavigateTo("/mis-reservas");
        }

        private void VolverAlMenuInicial()
        {
            Navigation.NavigateTo("/menu");
        }

        protected async Task CerrarSesion()
        {
            await LocalStorage.DeleteAsync("authToken");
            AuthStateProvider.NotificarUsuarioCierreSesion();
            Navigation.NavigateTo("/login");
        }
    }
}