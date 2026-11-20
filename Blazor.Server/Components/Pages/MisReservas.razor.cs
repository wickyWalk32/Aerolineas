using Blazor.Server.Auth;
using DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Net.Http.Json;
using System.Security.Claims;

namespace Blazor.Server.Components.Pages
{
    public partial class MisReservas : ComponentBase
    {
        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;
        [Inject] public ProtectedLocalStorage LocalStorage { get; set; } = default!;
        [Inject] public CustomAuthenticationStateProvider AuthStateProvider { get; set; } = default!;
        [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;

        private bool cargando = true;
        private string? mensajeError;

        private List<ReservaListItem> todasMisReservas = new();
        private List<ReservaListItem> reservasFiltradas = new();
        private List<ReservaListItem> reservasPaginadas = new();

        // Filtros
        private string filtroDestino = string.Empty;
        private string filtroEstado = "Todos";

        // Paginación (10 reservas por página)
        private int paginaActual = 0;
        private const int TamanoPagina = 10;
        private int totalPaginas => (int)Math.Ceiling((double)reservasFiltradas.Count / TamanoPagina);

        protected override async Task OnInitializedAsync()
        {
            await CargarMisReservasAsync();
        }

        private async Task CargarMisReservasAsync()
        {
            try
            {
                cargando = true;
                mensajeError = null;

                var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
                var user = authState.User;

                var idClaim = user.FindFirst("nameid")?.Value
                              ?? user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (!int.TryParse(idClaim, out int usuarioId) || usuarioId <= 0)
                {
                    mensajeError = "No se pudo identificar al usuario actual.";
                    return;
                }

                var tareaReservas = Http.GetFromJsonAsync<List<ReservaDTO>>("reservas");
                var tareaVuelos = Http.GetFromJsonAsync<List<VueloDTO>>("vuelos");

                await Task.WhenAll(tareaReservas, tareaVuelos);

                var todasReservas = await tareaReservas ?? new();
                var todosVuelos = await tareaVuelos ?? new();
                var vuelosPorId = todosVuelos.ToDictionary(v => v.Id);

                var ahora = DateTime.Now;

                todasMisReservas = todasReservas
                    .Where(r => r.UsuarioId == usuarioId)
                    .OrderByDescending(r => r.FechaHoraReserva)
                    .Select(r =>
                    {
                        vuelosPorId.TryGetValue(r.VueloId, out var vuelo);

                        string origen = vuelo?.CiudadOrigen?.Nombre ?? "Origen no disponible";
                        string destino = vuelo?.CiudadDestino?.Nombre ?? "Destino no disponible";
                        string aerolinea = vuelo?.Aerolinea ?? string.Empty;
                        DateTime? fechaVuelo = vuelo?.FechaHoraVuelo;

                        string estadoCalculado = fechaVuelo.HasValue
                            ? (fechaVuelo.Value >= ahora ? "Pendiente" : "Finalizada")
                            : "Pendiente";

                        return new ReservaListItem
                        {
                            ReservaId = r.Id,
                            Origen = origen,
                            Destino = destino,
                            Aerolinea = aerolinea,
                            FechaVuelo = fechaVuelo,
                            EstadoCalculado = estadoCalculado
                        };
                    })
                    .ToList();

                AplicarFiltros();
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al cargar las reservas: {ex.Message}";
            }
            finally
            {
                cargando = false;
            }
        }

        private void AplicarFiltros()
        {
            paginaActual = 0;

            IEnumerable<ReservaListItem> query = todasMisReservas;

            if (!string.IsNullOrWhiteSpace(filtroDestino))
            {
                var termino = filtroDestino.Trim();
                query = query.Where(r =>
                    r.Destino.Contains(termino, StringComparison.OrdinalIgnoreCase) ||
                    r.Origen.Contains(termino, StringComparison.OrdinalIgnoreCase) ||
                    r.Aerolinea.Contains(termino, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.Equals(filtroEstado, "Todos", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(r =>
                    string.Equals(r.EstadoCalculado, filtroEstado, StringComparison.OrdinalIgnoreCase));
            }

            reservasFiltradas = query.ToList();
            ActualizarPaginacion();
        }

        private void LimpiarFiltros()
        {
            filtroDestino = string.Empty;
            filtroEstado = "Todos";
            AplicarFiltros();
        }

        private void ActualizarPaginacion()
        {
            reservasPaginadas = reservasFiltradas
                .Skip(paginaActual * TamanoPagina)
                .Take(TamanoPagina)
                .ToList();
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

        private void VerReserva(int reservaId)
        {
            Navigation.NavigateTo($"/mis-reservas/{reservaId}");
        }

        private void IrABuscador()
        {
            Navigation.NavigateTo("/menu");
        }

        protected async Task CerrarSesion()
        {
            await LocalStorage.DeleteAsync("authToken");
            AuthStateProvider.NotificarUsuarioCierreSesion();
            Navigation.NavigateTo("/login");
        }

        private sealed class ReservaListItem
        {
            public int ReservaId { get; set; }
            public string Origen { get; set; } = string.Empty;
            public string Destino { get; set; } = string.Empty;
            public string Aerolinea { get; set; } = string.Empty;
            public DateTime? FechaVuelo { get; set; }
            public string EstadoCalculado { get; set; } = "Pendiente";
        }
    }
}