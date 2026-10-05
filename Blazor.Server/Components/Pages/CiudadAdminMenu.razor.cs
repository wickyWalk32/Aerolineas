using DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace Blazor.Server.Components.Pages
{
    public partial class CiudadAdminMenu : ComponentBase
    {
        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;
        [Inject] public IJSRuntime JS { get; set; } = default!;

        public List<CiudadDTO> ciudades { get; set; } = new();
        public bool cargando { get; set; } = true;
        public string? mensajeError { get; set; }
        public CiudadDTO? ciudadAEliminar { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await CargarCiudades();
        }

        private async Task CargarCiudades()
        {
            try
            {
                cargando = true;
                mensajeError = null;

                var listaCiudades = await Http.GetFromJsonAsync<List<CiudadDTO>>("ciudades");

                if (listaCiudades != null)
                {
                    ciudades = listaCiudades;
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al obtener las ciudades: {ex.Message}";
            }
            finally
            {
                cargando = false;
            }
        }

        public void IrANuevaCiudad()
        {
            Navigation.NavigateTo("/admin/ciudades/nuevo");
        }

        public void VolverAlMenuAdmin()
        {
            Navigation.NavigateTo("/admin/menu");
        }

        public void EditarCiudad(int id)
        {
            Navigation.NavigateTo($"/admin/ciudades/editar/{id}");
        }

        public void SolicitarEliminacion(CiudadDTO ciudad)
        {
            ciudadAEliminar = ciudad;
        }

        public void CancelarEliminacion()
        {
            ciudadAEliminar = null;
        }

        public async Task ConfirmarEliminacion()
        {
            if (ciudadAEliminar == null) return;

            try
            {
                int id = ciudadAEliminar.Id;
                ciudadAEliminar = null;

                mensajeError = null;
                var response = await Http.DeleteAsync($"ciudades/{id}");

                if (response.IsSuccessStatusCode)
                {
                    await CargarCiudades();
                }
                else
                {
                    mensajeError = "No se pudo eliminar la ciudad. Verifique que no esté asociada a vuelos activos o vuelva a intentarlo.";
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error de conexión al eliminar: {ex.Message}";
            }
        }
    }
}