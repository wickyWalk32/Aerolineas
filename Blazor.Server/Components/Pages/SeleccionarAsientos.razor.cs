using Blazor.Server.Auth;
using Blazor.Server.Services;
using DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Net.Http.Json;

namespace Blazor.Server.Components.Pages
{
    public partial class SeleccionarAsientos : ComponentBase
    {
        [Parameter] public int VueloId { get; set; }
        [Parameter] public int CantidadPasajeros { get; set; }

        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;
        [Inject] public ProtectedLocalStorage LocalStorage { get; set; } = default!;
        [Inject] public CustomAuthenticationStateProvider AuthStateProvider { get; set; } = default!;
        [Inject] public ReservaStateService ReservaState { get; set; } = default!;

        private VueloDTO? vueloActual;
        private List<AsientoDTO> asientos = new();
        private List<IGrouping<char, AsientoDTO>> filasOrdenadas = new();

        private bool cargando = true;
        private string? mensajeError;

        private int CantidadRestante => Math.Max(0, CantidadPasajeros - ReservaState.AsientosSeleccionados.Count);

        protected override async Task OnInitializedAsync()
        {
            try
            {
                cargando = true;

                // Recupera el vuelo desde el servicio o desde la API si se recargó la página
                if (ReservaState.VueloSeleccionado != null && ReservaState.VueloSeleccionado.Id == VueloId)
                {
                    vueloActual = ReservaState.VueloSeleccionado;
                }
                else
                {
                    vueloActual = await Http.GetFromJsonAsync<VueloDTO>($"vuelos/{VueloId}");
                }

                if (vueloActual == null)
                {
                    mensajeError = "No se encontró el vuelo seleccionado.";
                    return;
                }

                ReservaState.CantidadPasajeros = CantidadPasajeros;
                ReservaState.VueloSeleccionado = vueloActual;
                ReservaState.AsientosSeleccionados.Clear();

                int? avionId = vueloActual.Avion?.Id;
                if (avionId == null || avionId <= 0)
                {
                    mensajeError = "El vuelo no tiene un avión válido asignado.";
                    return;
                }

                var avionDto = await Http.GetFromJsonAsync<AvionDTO>($"aviones/{avionId.Value}");
                asientos = avionDto?.Asientos ?? new List<AsientoDTO>();

                filasOrdenadas = asientos
                    .OrderBy(a => a.Fila)
                    .ThenBy(a => a.Columna)
                    .GroupBy(a => a.Fila)
                    .ToList();
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al cargar los asientos del avión: {ex.Message}";
            }
            finally
            {
                cargando = false;
            }
        }

        private bool EsOcupado(AsientoDTO asiento)
        {
            return string.Equals(asiento.Estado?.Trim(), "ocupado", StringComparison.OrdinalIgnoreCase);
        }

        private bool EstaSeleccionado(AsientoDTO asiento)
        {
            return ReservaState.AsientosSeleccionados.Any(a =>
                a.AvionId == asiento.AvionId &&
                string.Equals(a.Codigo, asiento.Codigo, StringComparison.OrdinalIgnoreCase));
        }

        private void ToggleAsiento(AsientoDTO asiento)
        {
            if (EsOcupado(asiento))
                return;

            var existente = ReservaState.AsientosSeleccionados.FirstOrDefault(a =>
                a.AvionId == asiento.AvionId &&
                string.Equals(a.Codigo, asiento.Codigo, StringComparison.OrdinalIgnoreCase));

            if (existente != null)
            {
                ReservaState.AsientosSeleccionados.Remove(existente);
            }
            else if (ReservaState.AsientosSeleccionados.Count < CantidadPasajeros)
            {
                ReservaState.AsientosSeleccionados.Add(asiento);
            }
        }

        private void IrASiguiente()
        {
            if (CantidadRestante != 0)
                return;

            Navigation.NavigateTo($"/reserva/pasajeros/{VueloId}");
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