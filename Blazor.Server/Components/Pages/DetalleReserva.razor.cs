using Blazor.Server.Auth;
using Blazor.Server.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.JSInterop;
using System.Text;

namespace Blazor.Server.Components.Pages
{
    public partial class DetalleReserva : ComponentBase
    {
        [Inject] public NavigationManager Navigation { get; set; } = default!;
        [Inject] public ProtectedLocalStorage LocalStorage { get; set; } = default!;
        [Inject] public CustomAuthenticationStateProvider AuthStateProvider { get; set; } = default!;
        [Inject] public ReservaStateService ReservaState { get; set; } = default!;
        [Inject] public IJSRuntime JS { get; set; } = default!;

        private async Task DescargarComprobante()
        {
            if (ReservaState.VueloConfirmado == null) return;

            var sb = new StringBuilder();
            sb.AppendLine("=== AERORESERVAS - DETALLE DE RESERVA ===");
            if (ReservaState.ReservaIdCreada.HasValue)
                sb.AppendLine($"Número de Reserva: #{ReservaState.ReservaIdCreada}");
            sb.AppendLine($"Fecha de emisión: {(ReservaState.FechaConfirmacion ?? DateTime.Now):dd/MM/yyyy HH:mm}");
            sb.AppendLine();
            sb.AppendLine("--- VUELO ---");
            sb.AppendLine($"Ruta: {ReservaState.VueloConfirmado.CiudadOrigen.Nombre} -> {ReservaState.VueloConfirmado.CiudadDestino.Nombre}");
            sb.AppendLine($"Fecha y Hora: {ReservaState.VueloConfirmado.FechaHoraVuelo:dd/MM/yyyy HH:mm}");
            sb.AppendLine($"Aerolínea: {ReservaState.VueloConfirmado.Aerolinea}");
            sb.AppendLine($"Precio unitario: $ {ReservaState.VueloConfirmado.Precio:N2}");
            sb.AppendLine();
            sb.AppendLine("--- PASAJEROS Y SERVICIOS ---");

            for (int i = 0; i < ReservaState.PasajerosConfirmados.Count; i++)
            {
                var p = ReservaState.PasajerosConfirmados[i];
                var servicios = ReservaState.ServiciosCatalogo
                    .Where(s => p.ServicioIdsSeleccionados.Contains(s.Id))
                    .Select(s => $"{s.Nombre} (${s.Precio:N2})")
                    .ToList();

                sb.AppendLine($"{i + 1}. {p.Nombre} {p.Apellido} ({p.Tipo}) - {p.TipoDocumento}: {p.NroDocumento}");
                sb.AppendLine($"   Asiento: {p.Asiento.Fila}{p.Asiento.Columna} (Código {p.Asiento.Codigo})");
                sb.AppendLine($"   Servicios: {(servicios.Count > 0 ? string.Join(", ", servicios) : "Ninguno")}");
            }

            sb.AppendLine();
            if (ReservaState.PagoConfirmado != null)
            {
                sb.AppendLine($"Medio de pago: Tarjeta {ReservaState.PagoConfirmado.TipoTarjeta} **** {ReservaState.PagoConfirmado.Ultimos4Digitos}");
            }
            sb.AppendLine($"TOTAL ABONADO: $ {ReservaState.TotalConfirmado:N2}");

            var bytes = Encoding.UTF8.GetBytes(sb.ToString());
            var base64 = Convert.ToBase64String(bytes);
            var nombreArchivo = $"Reserva_{(ReservaState.ReservaIdCreada?.ToString() ?? DateTime.Now.ToString("yyyyMMddHHmm"))}.txt";

            await JS.InvokeVoidAsync("eval", $@"
                const link = document.createElement('a');
                link.href = 'data:text/plain;charset=utf-8;base64,{base64}';
                link.download = '{nombreArchivo}';
                document.body.appendChild(link);
                link.click();
                document.body.removeChild(link);
            ");
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