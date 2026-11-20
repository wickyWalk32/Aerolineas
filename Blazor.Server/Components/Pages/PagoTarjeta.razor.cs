using Blazor.Server.Auth;
using Blazor.Server.Services;
using DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Net.Http.Json;
using System.Security.Claims;

namespace Blazor.Server.Components.Pages
{
    public partial class PagoTarjeta : ComponentBase
    {
        [Parameter] public int VueloId { get; set; }

        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;
        [Inject] public ProtectedLocalStorage LocalStorage { get; set; } = default!;
        [Inject] public CustomAuthenticationStateProvider AuthStateProvider { get; set; } = default!;
        [Inject] public ReservaStateService ReservaState { get; set; } = default!;

        private List<ServicioCargaDTO> serviciosDisponibles = new();
        private decimal totalCalculado;
        private bool cargando = true;
        private bool procesandoPago = false;
        private string? mensajeError;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                cargando = true;
                mensajeError = null;

                if (ReservaState.VueloSeleccionado == null ||
                    ReservaState.VueloSeleccionado.Id != VueloId ||
                    ReservaState.Pasajeros.Count == 0)
                {
                    mensajeError = "No hay datos completos de la reserva para procesar el pago.";
                    return;
                }

                var servicios = await Http.GetFromJsonAsync<List<ServicioCargaDTO>>("servicios");
                serviciosDisponibles = servicios ?? new List<ServicioCargaDTO>();
                totalCalculado = ReservaState.CalcularTotalParcial(serviciosDisponibles);
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al cargar los datos de pago: {ex.Message}";
            }
            finally
            {
                cargando = false;
            }
        }

        private async Task ConfirmarPagoYReserva()
        {
            mensajeError = null;

            if (string.IsNullOrWhiteSpace(ReservaState.Pago.Titular) ||
                string.IsNullOrWhiteSpace(ReservaState.Pago.NumeroTarjeta) ||
                string.IsNullOrWhiteSpace(ReservaState.Pago.Vencimiento) ||
                string.IsNullOrWhiteSpace(ReservaState.Pago.CodigoSeguridad))
            {
                mensajeError = "Completá todos los datos de la tarjeta para confirmar la reserva.";
                return;
            }

            var digitosTarjeta = new string(ReservaState.Pago.NumeroTarjeta.Where(char.IsDigit).ToArray());
            if (digitosTarjeta.Length < 4)
            {
                mensajeError = "Ingresá un número de tarjeta válido (al menos 4 dígitos).";
                return;
            }

            try
            {
                procesandoPago = true;

                var authState = await AuthStateProvider.GetAuthenticationStateAsync();
                var userIdClaim = authState.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                int.TryParse(userIdClaim, out int usuarioId);

                DateTime fechaVenc = DateTime.UtcNow.AddYears(1);
                var partesVenc = ReservaState.Pago.Vencimiento.Split('/', StringSplitOptions.TrimEntries);
                if (partesVenc.Length == 2 &&
                    int.TryParse(partesVenc[0], out int mes) && mes is >= 1 and <= 12 &&
                    int.TryParse(partesVenc[1], out int anioCorto))
                {
                    int anioCompleto = anioCorto < 100 ? 2000 + anioCorto : anioCorto;
                    fechaVenc = new DateTime(anioCompleto, mes, 1, 0, 0, 0, DateTimeKind.Utc);
                }

                var payload = new ReservaCreateDTO
                {
                    UsuarioId = usuarioId,
                    VueloId = VueloId,
                    FechaHoraReserva = DateTime.UtcNow,
                    UltimosCuatroDigitos = ReservaState.Pago.Ultimos4Digitos,
                    FechaVencimientoTarjeta = fechaVenc,
                    Pasajes = ReservaState.Pasajeros.Select(p => new PasajeCreateDTO
                    {
                        Estado = "Confirmado",
                        IdAvion = p.Asiento.AvionId,
                        CodigoAsiento = p.Asiento.Codigo,
                        Pasajero = new PasajeroCreateDTO
                        {
                            Nombre = p.Nombre.Trim(),
                            Apellido = p.Apellido.Trim(),
                            TipoDocumento = p.TipoDocumento,
                            NroDocumento = p.NroDocumento.Trim(),
                            Tipo = p.Tipo
                        },
                        ServicioIds = p.ServicioIdsSeleccionados.ToList()
                    }).ToList()
                };

                var response = await Http.PostAsJsonAsync("reservas", payload);
                if (!response.IsSuccessStatusCode)
                {
                    var detalleError = await response.Content.ReadAsStringAsync();
                    mensajeError = $"No se pudo registrar la reserva en la base de datos. {detalleError}";
                    return;
                }

                int? reservaIdCreada = null;
                try
                {
                    var creada = await response.Content.ReadFromJsonAsync<ReservaDTO>();
                    reservaIdCreada = creada?.Id;
                }
                catch
                {
                    // Si la respuesta no tiene cuerpo JSON estándar, continuamos igual
                }

                ReservaState.RegistrarConfirmacion(reservaIdCreada, serviciosDisponibles);
                ReservaState.LimpiarBorrador();

                Navigation.NavigateTo("/reserva/detalle");
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al confirmar la reserva: {ex.Message}";
            }
            finally
            {
                procesandoPago = false;
            }
        }

        private void VolverAPasajeros() => Navigation.NavigateTo($"/reserva/pasajeros/{VueloId}");
        private void VolverAlBuscador() => Navigation.NavigateTo("/menu");

        protected async Task CerrarSesion()
        {
            await LocalStorage.DeleteAsync("authToken");
            AuthStateProvider.NotificarUsuarioCierreSesion();
            Navigation.NavigateTo("/login");
        }
    }
}