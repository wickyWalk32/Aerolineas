using DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using System.Text.Json;

namespace Blazor.Server.Components.Pages
{
    public partial class PaisAdminMenu : ComponentBase
    {
        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;
        [Inject] public IJSRuntime JS { get; set; } = default!;

        public List<PaisDTO> paises { get; set; } = new();
        public bool cargando { get; set; } = true;
        public string? mensajeError { get; set; }
        public PaisDTO? paisAEliminar { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await CargarPaises();
        }

        private async Task CargarPaises()
        {
            try
            {
                cargando = true;
                mensajeError = null;

                var listaPaises = await Http.GetFromJsonAsync<List<PaisDTO>>("paises");

                if (listaPaises != null)
                {
                    paises = listaPaises;
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al obtener los países: {ex.Message}";
            }
            finally
            {
                cargando = false;
            }
        }

        public void IrANuevoPais()
        {
            Navigation.NavigateTo("/admin/paises/nuevo");
        }

        public void VolverAlMenuAdmin()
        {
            Navigation.NavigateTo("/admin/menu");
        }

        public void EditarPais(int id)
        {
            Navigation.NavigateTo($"/admin/paises/editar/{id}");
        }

        public void SolicitarEliminacion(PaisDTO pais)
        {
            paisAEliminar = pais;
        }

        public void CancelarEliminacion()
        {
            paisAEliminar = null;
        }

        public async Task ConfirmarEliminacion()
        {
            if (paisAEliminar == null) return;

            try
            {
                int id = paisAEliminar.Id;
                paisAEliminar = null;

                mensajeError = null;
                var response = await Http.DeleteAsync($"paises/{id}");

                if (response.IsSuccessStatusCode)
                {
                    await CargarPaises();
                }
                else
                {
                    var raw = await response.Content.ReadAsStringAsync();
                    mensajeError = ExtraerMensajeError(
                        raw,
                        "No se pudo eliminar el país. Verifique que no tenga ciudades asociadas o vuelva a intentarlo."
                    );
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error de conexión al eliminar: {ex.Message}";
            }
        }

        private static string ExtraerMensajeError(string raw, string mensajePorDefecto)
        {
            if (string.IsNullOrWhiteSpace(raw))
                return mensajePorDefecto;

            try
            {
                using var doc = JsonDocument.Parse(raw);
                if (doc.RootElement.TryGetProperty("error", out var errorProp))
                {
                    var msg = errorProp.GetString();
                    if (!string.IsNullOrWhiteSpace(msg))
                        return msg;
                }
            }
            catch
            {
                // Si no viene en JSON, usamos el mensaje por defecto.
            }

            return mensajePorDefecto;
        }
    }
}