using Blazor.Server.Auth;
using Blazor.Server.Services;
using DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Net.Http.Json;

namespace Blazor.Server.Components.Pages
{
    public partial class PasajerosYServicios : ComponentBase
    {
        [Parameter] public int VueloId { get; set; }

        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;
        [Inject] public ProtectedLocalStorage LocalStorage { get; set; } = default!;
        [Inject] public CustomAuthenticationStateProvider AuthStateProvider { get; set; } = default!;
        [Inject] public ReservaStateService ReservaState { get; set; } = default!;

        private List<ServicioCargaDTO> serviciosDisponibles = new();
        private readonly List<string> tiposDocumento = new()
        {
            "DNI",
            "DNI (Extranjero)",
            "Libreta Cívica (LC)",
            "Libreta de Enrolamiento (LE)"
        };

        private bool cargando = true;
        private string? mensajeError;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                cargando = true;
                mensajeError = null;

                if (ReservaState.VueloSeleccionado == null ||
                    ReservaState.VueloSeleccionado.Id != VueloId ||
                    ReservaState.AsientosSeleccionados.Count == 0)
                {
                    mensajeError = "No hay asientos seleccionados para este vuelo. Volvé a la selección de asientos.";
                    return;
                }

                if (ReservaState.Pasajeros.Count != ReservaState.AsientosSeleccionados.Count)
                {
                    ReservaState.PrepararPasajerosDesdeAsientos();
                }

                var servicios = await Http.GetFromJsonAsync<List<ServicioCargaDTO>>("servicios");
                serviciosDisponibles = servicios ?? new List<ServicioCargaDTO>();
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al cargar los servicios adicionales: {ex.Message}";
            }
            finally
            {
                cargando = false;
            }
        }

        private void ToggleServicioPasajero(PasajeroReservaItem pasajero, int servicioId, bool seleccionado)
        {
            if (seleccionado)
            {
                if (!pasajero.ServicioIdsSeleccionados.Contains(servicioId))
                {
                    pasajero.ServicioIdsSeleccionados.Add(servicioId);
                }
            }
            else
            {
                pasajero.ServicioIdsSeleccionados.Remove(servicioId);
            }
        }

        private void ContinuarAPago()
        {
            mensajeError = null;

            for (int i = 0; i < ReservaState.Pasajeros.Count; i++)
            {
                var p = ReservaState.Pasajeros[i];
                if (string.IsNullOrWhiteSpace(p.Nombre))
                {
                    mensajeError = $"Completá el nombre del Pasajero #{i + 1}.";
                    return;
                }
                if (string.IsNullOrWhiteSpace(p.Apellido))
                {
                    mensajeError = $"Completá el apellido del Pasajero #{i + 1}.";
                    return;
                }
                if (string.IsNullOrWhiteSpace(p.TipoDocumento))
                {
                    mensajeError = $"Seleccioná el tipo de documento del Pasajero #{i + 1}.";
                    return;
                }
                if (string.IsNullOrWhiteSpace(p.NroDocumento))
                {
                    mensajeError = $"Completá el número de documento del Pasajero #{i + 1}.";
                    return;
                }
                if (string.IsNullOrWhiteSpace(p.Tipo))
                {
                    mensajeError = $"Seleccioná el tipo (Mayor/Menor) del Pasajero #{i + 1}.";
                    return;
                }
            }

            Navigation.NavigateTo($"/reserva/pago/{VueloId}");
        }

        private void VolverAAsientos()
        {
            int cant = ReservaState.CantidadPasajeros > 0
                ? ReservaState.CantidadPasajeros
                : Math.Max(1, ReservaState.AsientosSeleccionados.Count);

            Navigation.NavigateTo($"/reserva/asientos/{VueloId}/{cant}");
        }

        private void VolverAlBuscador() => Navigation.NavigateTo("/menu");
        private void IrAMisReservas() => Navigation.NavigateTo("/mis-reservas");

        protected async Task CerrarSesion()
        {
            await LocalStorage.DeleteAsync("authToken");
            AuthStateProvider.NotificarUsuarioCierreSesion();
            Navigation.NavigateTo("/login");
        }
    }
}