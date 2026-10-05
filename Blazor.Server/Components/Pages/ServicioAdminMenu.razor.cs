using DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace Blazor.Server.Components.Pages
{
    public partial class ServicioAdminMenu : ComponentBase
    {
        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;
        [Inject] public IJSRuntime JS { get; set; } = default!;

        public List<ServicioCargaDTO> servicios { get; set; } = new();
        public bool cargando { get; set; } = true;
        public string? mensajeError { get; set; }
        public ServicioCargaDTO? servicioAEliminar { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await CargarServicios();
        }

        private async Task CargarServicios()
        {
            try
            {
                cargando = true;
                mensajeError = null;

                // El HttpClient ya viaja con el token Bearer incrustado automáticamente por el CustomAuthorizationMessageHandler
                var listaServicios = await Http.GetFromJsonAsync<List<ServicioCargaDTO>>("servicios");

                if (listaServicios != null)
                {
                    servicios = listaServicios;
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al obtener los servicios: {ex.Message}";
            }
            finally
            {
                cargando = false;
            }
        }

        public void IrANuevoServicio()
        {
            Navigation.NavigateTo("/admin/servicios/nuevo");
        }

        public void VolverAlMenuAdmin()
        {
            Navigation.NavigateTo("/admin/menu");
        }

        public void EditarServicio(int id)
        {
            Navigation.NavigateTo($"/admin/servicios/editar/{id}");
        }

        public void SolicitarEliminacion(ServicioCargaDTO servicio)
        {
            servicioAEliminar = servicio;
        }

        public void CancelarEliminacion()
        {
            servicioAEliminar = null;
        }

        public async Task ConfirmarEliminacion()
        {
            if (servicioAEliminar == null) return;

            try
            {
                int id = servicioAEliminar.Id;
                servicioAEliminar = null;

                mensajeError = null;
                var response = await Http.DeleteAsync($"servicios/{id}");

                if (response.IsSuccessStatusCode)
                {
                    await CargarServicios();
                }
                else
                {
                    mensajeError = "No se pudo eliminar el servicio. Verifique que no esté asociado a reservas activas o vuelva a intentarlo.";
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error de conexión al eliminar: {ex.Message}";
            }
        }
    }
}