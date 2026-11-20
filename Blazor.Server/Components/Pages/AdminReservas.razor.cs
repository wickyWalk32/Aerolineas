using Blazor.Server.Auth;
using DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Net.Http.Json;

namespace Blazor.Server.Components.Pages
{
    public partial class AdminReservas : ComponentBase
    {
        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;
        [Inject] public ProtectedLocalStorage LocalStorage { get; set; } = default!;
        [Inject] public CustomAuthenticationStateProvider AuthStateProvider { get; set; } = default!;

        private bool cargando = true;
        private string? mensajeError;

        private List<AdminReservaListItem> todasLasReservasItems = new();
        private List<AdminReservaListItem> reservasFiltradas = new();
        private List<AdminReservaListItem> reservasPaginadas = new();

        // Filtros
        private string filtroUsuario = string.Empty;
        private string filtroVuelo = string.Empty;
        private string filtroEstado = "Todos";

        // Paginación de a 20 reservas
        private int paginaActual = 0;
        private const int TamanoPagina = 20;
        private int totalPaginas => (int)Math.Ceiling((double)reservasFiltradas.Count / TamanoPagina);

        protected override async Task OnInitializedAsync()
        {
            await CargarTodasLasReservasAsync();
        }

        private async Task CargarTodasLasReservasAsync()
        {
            try
            {
                cargando = true;
                mensajeError = null;

                var tareaReservas = Http.GetFromJsonAsync<List<ReservaDTO>>("reservas");
                var tareaVuelos = Http.GetFromJsonAsync<List<VueloDTO>>("vuelos");
                var tareaUsuarios = ObtenerUsuariosSeguroAsync();

                await Task.WhenAll(tareaReservas, tareaVuelos, tareaUsuarios);

                var todasReservas = await tareaReservas ?? new();
                var todosVuelos = await tareaVuelos ?? new();
                var todosUsuarios = await tareaUsuarios;

                var vuelosPorId = todosVuelos.ToDictionary(v => v.Id);
                var usuariosPorId = todosUsuarios.ToDictionary(u => u.Id);
                var ahora = DateTime.Now;

                todasLasReservasItems = todasReservas
                    .OrderByDescending(r => r.Id)
                    .Select(r =>
                    {
                        vuelosPorId.TryGetValue(r.VueloId, out var vuelo);
                        usuariosPorId.TryGetValue(r.UsuarioId, out var usuario);

                        string origen = vuelo?.CiudadOrigen?.Nombre ?? "Origen no disponible";
                        string destino = vuelo?.CiudadDestino?.Nombre ?? "Destino no disponible";
                        string aerolinea = vuelo?.Aerolinea ?? string.Empty;
                        DateTime? fechaVuelo = vuelo?.FechaHoraVuelo;

                        string estadoCalculado = fechaVuelo.HasValue
                            ? (fechaVuelo.Value >= ahora ? "Pendiente" : "Finalizada")
                            : "Pendiente";

                        string usuarioInfo = usuario != null
                            ? $"{usuario.Nombre} {usuario.Apellido}"
                            : $"Usuario #{r.UsuarioId}";

                        string usuarioBusqueda = usuario != null
                            ? $"{usuario.Nombre} {usuario.Apellido} {usuario.Email} #{r.UsuarioId}"
                            : $"Usuario #{r.UsuarioId}";

                        return new AdminReservaListItem
                        {
                            ReservaId = r.Id,
                            VueloId = r.VueloId,
                            UsuarioInfo = usuarioInfo,
                            UsuarioBusqueda = usuarioBusqueda,
                            Origen = origen,
                            Destino = destino,
                            Aerolinea = aerolinea,
                            FechaVuelo = fechaVuelo,
                            CantidadPasajes = r.Pasajes?.Count ?? 0,
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

            IEnumerable<AdminReservaListItem> query = todasLasReservasItems;

            if (!string.IsNullOrWhiteSpace(filtroUsuario))
            {
                var terminoUsuario = filtroUsuario.Trim();
                query = query.Where(r =>
                    r.UsuarioBusqueda.Contains(terminoUsuario, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(filtroVuelo))
            {
                var terminoVuelo = filtroVuelo.Trim();
                query = query.Where(r =>
                    r.Origen.Contains(terminoVuelo, StringComparison.OrdinalIgnoreCase) ||
                    r.Destino.Contains(terminoVuelo, StringComparison.OrdinalIgnoreCase) ||
                    r.Aerolinea.Contains(terminoVuelo, StringComparison.OrdinalIgnoreCase) ||
                    $"#{r.VueloId}".Contains(terminoVuelo, StringComparison.OrdinalIgnoreCase));
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
            filtroUsuario = string.Empty;
            filtroVuelo = string.Empty;
            filtroEstado = "Todos";
            AplicarFiltros();
        }

        private async Task<List<UsuarioDTO>> ObtenerUsuariosSeguroAsync()
        {
            try
            {
                return await Http.GetFromJsonAsync<List<UsuarioDTO>>("usuarios") ?? new();
            }
            catch
            {
                return new();
            }
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
            Navigation.NavigateTo($"/admin/reservas/{reservaId}");
        }

        private void VolverAlMenuAdmin()
        {
            Navigation.NavigateTo("/admin/menu");
        }

        protected async Task CerrarSesion()
        {
            await LocalStorage.DeleteAsync("authToken");
            AuthStateProvider.NotificarUsuarioCierreSesion();
            Navigation.NavigateTo("/login");
        }

        private sealed class AdminReservaListItem
        {
            public int ReservaId { get; set; }
            public int VueloId { get; set; }
            public string UsuarioInfo { get; set; } = string.Empty;
            public string UsuarioBusqueda { get; set; } = string.Empty;
            public string Origen { get; set; } = string.Empty;
            public string Destino { get; set; } = string.Empty;
            public string Aerolinea { get; set; } = string.Empty;
            public DateTime? FechaVuelo { get; set; }
            public int CantidadPasajes { get; set; }
            public string EstadoCalculado { get; set; } = "Pendiente";
        }
    }
}
