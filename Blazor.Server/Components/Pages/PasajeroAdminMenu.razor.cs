using DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace Blazor.Server.Components.Pages
{
    public partial class PasajeroAdminMenu : ComponentBase
    {
        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;
        [Inject] public IJSRuntime JS { get; set; } = default!;

        public List<PasajeroDTO> pasajeros { get; set; } = new();
        public bool cargando { get; set; } = true;
        public string? mensajeError { get; set; }
        public PasajeroDTO? pasajeroAEliminar { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await CargarPasajeros();
        }

        private async Task CargarPasajeros()
        {
            try
            {
                cargando = true;
                mensajeError = null;

                // Consumo del endpoint configurado en PasajeroEndpoints ("pasajeros/")
                var listaPasajeros = await Http.GetFromJsonAsync<List<PasajeroDTO>>("pasajeros");

                if (listaPasajeros != null)
                {
                    pasajeros = listaPasajeros;
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al obtener los pasajeros: {ex.Message}";
            }
            finally
            {
                cargando = false;
            }
        }

        public void IrANuevoPasajero()
        {
            Navigation.NavigateTo("/admin/pasajeros/nuevo");
        }

        public void VolverAlMenuAdmin()
        {
            Navigation.NavigateTo("/admin/menu");
        }

        public void EditarPasajero(int id)
        {
            Navigation.NavigateTo($"/admin/pasajeros/editar/{id}");
        }

        public void SolicitarEliminacion(PasajeroDTO pasajero)
        {
            pasajeroAEliminar = pasajero;
        }

        public void CancelarEliminacion()
        {
            pasajeroAEliminar = null;
        }

        public async Task ConfirmarEliminacion()
        {
            if (pasajeroAEliminar == null) return;

            try
            {
                int id = pasajeroAEliminar.Id;
                pasajeroAEliminar = null;

                mensajeError = null;
                var response = await Http.DeleteAsync($"pasajeros/{id}");

                if (response.IsSuccessStatusCode)
                {
                    await CargarPasajeros();
                }
                else
                {
                    mensajeError = "No se pudo eliminar el pasajero. Verifique que no posea reservas asociadas o vuelva a intentarlo.";
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error de conexión al eliminar: {ex.Message}";
            }
        }
    }
}