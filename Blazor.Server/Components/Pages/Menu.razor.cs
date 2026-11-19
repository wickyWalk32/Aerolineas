using Blazor.Server.Auth;
using DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Net.Http.Json;

namespace Blazor.Server.Components.Pages
{
    public partial class Menu : ComponentBase
    {
        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;
        [Inject] public ProtectedLocalStorage LocalStorage { get; set; } = default!;
        [Inject] public CustomAuthenticationStateProvider AuthStateProvider { get; set; } = default!;
        [Inject] public Blazor.Server.Services.ReservaStateService ReservaState { get; set; } = default!;

        private List<VueloDTO> todosLosVuelos = new();
        private List<VueloDTO> vuelosFiltrados = new();
        private List<VueloDTO> vuelosPaginados = new();

        private List<PaisDTO> paises = new();
        private List<CiudadDTO> todasLasCiudades = new();

        private List<CiudadDTO> ciudadesOrigenDisponibles = new();
        private List<CiudadDTO> ciudadesDestinoDisponibles = new();

        private bool cargando = true;

        // Variables de Texto para los inputs con autocompletado
        private string? textoPaisOrigen;
        private string? textoCiudadOrigen;
        private string? textoPaisDestino;
        private string? textoCiudadDestino;

        // IDs internos para el filtrado de vuelos
        private int? filtroCiudadOrigenId;
        private int? filtroCiudadDestinoId;
        private int filtroCantidadPasajeros = 1;

        // Variables de Paginación (10 elementos por página)
        private int paginaActual = 0;
        private int tamanoPagina = 10;
        private int totalPaginas => (int)Math.Ceiling((double)vuelosFiltrados.Count / tamanoPagina);

        protected override async Task OnInitializedAsync()
        {
            await CargarDatosIniciales();
        }

        private async Task CargarDatosIniciales()
        {
            try
            {
                cargando = true;

                var tareaPaises = Http.GetFromJsonAsync<List<PaisDTO>>("paises");
                var tareaCiudades = Http.GetFromJsonAsync<List<CiudadDTO>>("ciudades");
                var tareaVuelos = Http.GetFromJsonAsync<List<VueloDTO>>("vuelos");

                await Task.WhenAll(tareaPaises, tareaCiudades, tareaVuelos);

                paises = await tareaPaises ?? new();
                todasLasCiudades = await tareaCiudades ?? new();
                todosLosVuelos = await tareaVuelos ?? new();

                ciudadesOrigenDisponibles = todasLasCiudades;
                ciudadesDestinoDisponibles = todasLasCiudades;

                AplicarFiltros();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al inicializar datos del menú de usuario: {ex.Message}");
            }
            finally
            {
                cargando = false;
            }
        }

        private void OnPaisOrigenInputChanged()
        {
            var paisEncontrado = paises.FirstOrDefault(p => p.Nombre.Equals(textoPaisOrigen, StringComparison.OrdinalIgnoreCase));

            if (paisEncontrado != null)
            {
                ciudadesOrigenDisponibles = todasLasCiudades.Where(c => c.PaisId == paisEncontrado.Id).ToList();
            }
            else
            {
                ciudadesOrigenDisponibles = todasLasCiudades;
                filtroCiudadOrigenId = null;
                textoCiudadOrigen = null;
            }

            AplicarFiltros();
        }

        private void OnCiudadOrigenInputChanged()
        {
            var ciudadEncontrada = ciudadesOrigenDisponibles.FirstOrDefault(c => c.Nombre.Equals(textoCiudadOrigen, StringComparison.OrdinalIgnoreCase));
            filtroCiudadOrigenId = ciudadEncontrada?.Id;
            AplicarFiltros();
        }

        private void OnPaisDestinoInputChanged()
        {
            var paisEncontrado = paises.FirstOrDefault(p => p.Nombre.Equals(textoPaisDestino, StringComparison.OrdinalIgnoreCase));

            if (paisEncontrado != null)
            {
                ciudadesDestinoDisponibles = todasLasCiudades.Where(c => c.PaisId == paisEncontrado.Id).ToList();
            }
            else
            {
                ciudadesDestinoDisponibles = todasLasCiudades;
                filtroCiudadDestinoId = null;
                textoCiudadDestino = null;
            }

            AplicarFiltros();
        }

        private void OnCiudadDestinoInputChanged()
        {
            var ciudadEncontrada = ciudadesDestinoDisponibles.FirstOrDefault(c => c.Nombre.Equals(textoCiudadDestino, StringComparison.OrdinalIgnoreCase));
            filtroCiudadDestinoId = ciudadEncontrada?.Id;
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            paginaActual = 0; // Volver a la primera página ante cualquier cambio en los filtros

            vuelosFiltrados = todosLosVuelos.Where(v =>
            {
                // Si escribió o seleccionó país origen pero no ciudad específica, filtramos por las ciudades de ese país
                if (!string.IsNullOrWhiteSpace(textoPaisOrigen) && filtroCiudadOrigenId == null)
                {
                    var paisObj = paises.FirstOrDefault(p => p.Nombre.Equals(textoPaisOrigen, StringComparison.OrdinalIgnoreCase));
                    if (paisObj != null)
                    {
                        var idsCiudadesPais = todasLasCiudades.Where(c => c.PaisId == paisObj.Id).Select(c => c.Id).ToList();
                        if (!idsCiudadesPais.Contains(v.CiudadOrigen.Id)) return false;
                    }
                }

                // Filtrar por Ciudad de Origen exacta
                if (filtroCiudadOrigenId.HasValue && v.CiudadOrigen.Id != filtroCiudadOrigenId.Value)
                    return false;

                // Si escribió o seleccionó país destino pero no ciudad específica
                if (!string.IsNullOrWhiteSpace(textoPaisDestino) && filtroCiudadDestinoId == null)
                {
                    var paisObj = paises.FirstOrDefault(p => p.Nombre.Equals(textoPaisDestino, StringComparison.OrdinalIgnoreCase));
                    if (paisObj != null)
                    {
                        var idsCiudadesPais = todasLasCiudades.Where(c => c.PaisId == paisObj.Id).Select(c => c.Id).ToList();
                        if (!idsCiudadesPais.Contains(v.CiudadDestino.Id)) return false;
                    }
                }

                // Filtrar por Ciudad de Destino exacta
                if (filtroCiudadDestinoId.HasValue && v.CiudadDestino.Id != filtroCiudadDestinoId.Value)
                    return false;

                // Filtrar por Capacidad de Pasajeros de forma segura y óptima
                int capacidadDisponible = v.Avion?.Capacidad ?? v.Capacidad ?? 0;
                if (capacidadDisponible < filtroCantidadPasajeros)
                    return false;

                return true;
            }).ToList();

            ActualizarPaginacion();
        }

        private void ActualizarPaginacion()
        {
            vuelosPaginados = vuelosFiltrados
                .Skip(paginaActual * tamanoPagina)
                .Take(tamanoPagina)
                .ToList();

            StateHasChanged();
        }

        private void PaginaAnterior()
        {
            if (paginaActual > 0)
            {
                paginaActual--;
                ActualizarPaginacion();
            }
        }

        private void PaginaSiguiente()
        {
            if (paginaActual < totalPaginas - 1)
            {
                paginaActual++;
                ActualizarPaginacion();
            }
        }

        private void SeleccionarVuelo(int vueloId)
        {
            var vueloElegido = todosLosVuelos.FirstOrDefault(v => v.Id == vueloId);
            if (vueloElegido != null)
            {
                ReservaState.IniciarReserva(vueloElegido, filtroCantidadPasajeros);
            }

            Navigation.NavigateTo($"/reserva/asientos/{vueloId}/{filtroCantidadPasajeros}");
        }

        private void IrAMisReservas()
        {
            Navigation.NavigateTo("/mis-reservas");
        }

        protected async Task CerrarSesion()
        {
            await LocalStorage.DeleteAsync("authToken");
            AuthStateProvider.NotificarUsuarioCierreSesion();
            Navigation.NavigateTo("/login");
        }
    }
}