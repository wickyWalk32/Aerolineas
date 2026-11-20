using Blazor.Server.Auth;
using Blazor.Server.Services;
using DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.IO.Pipelines;
using System.Net.Http.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        private HashSet<string> codigosAsientosOcupadosEnVuelo = new(StringComparer.OrdinalIgnoreCase);

        private bool cargando = true;
        private string? mensajeError;

        private int CantidadRestante => Math.Max(0, CantidadPasajeros - ReservaState.AsientosSeleccionados.Count);

        protected override async Task OnInitializedAsync()
        {
            try
            {
                cargando = true;
                codigosAsientosOcupadosEnVuelo.Clear();

                // Recupera el vuelo desde el servicio (sevicio creado en el back especificamente en Blazor.Server > Services para
                // guardar datos de un vuelo (a modo de memoria del sitio web)) o desde la API si se recargó la página. Es decir:
                // > Si venimos desde Menu.razor y ya tenemos el vuelo en ReservaState, lo reusamos;
                // > si el usuario entró directo por URL o recargó (F5), lo pedimos a la API por VueloId.
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

                // Guarda en el servicio de estado de sesión cuántos pasajeros se van a reservar y cuál es el vuelo
                ReservaState.CantidadPasajeros = CantidadPasajeros;
                ReservaState.VueloSeleccionado = vueloActual;
                ReservaState.AsientosSeleccionados.Clear();

                // Obtiene el ID del avión asignado a este vuelo (ej. AvionId = 6)
                int? avionId = vueloActual.Avion?.Id;
                if (avionId == null || avionId <= 0)
                {
                    mensajeError = "El vuelo no tiene un avión válido asignado.";
                    return;
                }

                // Ahora se piden en paralelo los datos del avión(con su lista de AsientoDTO) y los asientos ocupados de este vuelo:

                // 1.Dispara ambas peticiones HTTP sin esperar una a que termine la otra:
                var tareaAvion = Http.GetFromJsonAsync<AvionDTO>($"aviones/{avionId.Value}");
                var tareaOcupados = Http.GetFromJsonAsync<List<string>>($"vuelos/{VueloId}/asientos-ocupados");

                // 2.Espera a que ambas terminen
                await Task.WhenAll(tareaAvion, tareaOcupados);

                // 3.Extrae los resultados resueltos
                var avionDto = await tareaAvion;
                var ocupadosLista = await tareaOcupados ?? new List<string>();

                // Asientos ocupados SOLO para este VueloId (filtrados en el backend)
                codigosAsientosOcupadosEnVuelo = ocupadosLista
                    .Where(c => !string.IsNullOrWhiteSpace(c))
                    .Select(c => c.Trim())
                    .ToHashSet(StringComparer.OrdinalIgnoreCase);

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
            return !string.IsNullOrWhiteSpace(asiento.Codigo)
                   && codigosAsientosOcupadosEnVuelo.Contains(asiento.Codigo.Trim());
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