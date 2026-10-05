using DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace Blazor.Server.Components.Pages
{
    public partial class AvionAdminMenu : ComponentBase
    {
        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;
        [Inject] public IJSRuntime JS { get; set; } = default!;

        public List<AvionDTO> aviones { get; set; } = new();
        public bool cargando { get; set; } = true;
        public string? mensajeError { get; set; }
        public AvionDTO? avionAEliminar { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await CargarAviones();
        }

        private async Task CargarAviones()
        {
            try
            {
                cargando = true;
                mensajeError = null;

                var listaAviones = await Http.GetFromJsonAsync<List<AvionDTO>>("aviones");

                if (listaAviones != null)
                {
                    aviones = listaAviones;
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al obtener los aviones: {ex.Message}";
            }
            finally
            {
                cargando = false;
            }
        }

        public void IrANuevoAvion()
        {
            Navigation.NavigateTo("/admin/aviones/nuevo");
        }

        public void VolverAlMenuAdmin()
        {
            Navigation.NavigateTo("/admin/menu");
        }

        public void EditarAvion(int id)
        {
            Navigation.NavigateTo($"/admin/aviones/editar/{id}");
        }

        public void SolicitarEliminacion(AvionDTO avion)
        {
            avionAEliminar = avion;
        }

        public void CancelarEliminacion()
        {
            avionAEliminar = null;
        }

        public async Task ConfirmarEliminacion()
        {
            if (avionAEliminar == null) return;

            try
            {
                int id = avionAEliminar.Id;
                avionAEliminar = null;

                mensajeError = null;
                var response = await Http.DeleteAsync($"aviones/{id}");

                if (response.IsSuccessStatusCode)
                {
                    await CargarAviones();
                }
                else
                {
                    mensajeError = "No se pudo eliminar el avión. Verifique que no esté asignado a un vuelo activo o vuelva a intentarlo.";
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error de conexión al eliminar: {ex.Message}";
            }
        }
    }
}