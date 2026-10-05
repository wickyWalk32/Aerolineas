using Domain.Model;
using DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace Blazor.Server.Components.Pages
{
    public partial class VueloAdminMenu : ComponentBase
    {
        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;
        [Inject] public IJSRuntime JS { get; set; } = default!;

        public List<VueloCargaDTO> vuelos { get; set; } = new();
        public bool cargando { get; set; } = true;
        public string? mensajeError { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await CargarVuelos();
        }

        private async Task CargarVuelos()
        {
            try
            {
                cargando = true;
                mensajeError = null;

                var listaVuelos = await Http.GetFromJsonAsync<List<VueloCargaDTO>>("vuelos");

                if (listaVuelos != null)
                {
                    vuelos = listaVuelos;
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al obtener los vuelos: {ex.Message}";
            }
            finally
            {
                cargando = false;
            }
        }

        public void IrANuevoVuelo()
        {
            Navigation.NavigateTo("/admin/vuelos/nuevo");
        }

        public void VolverAlMenuAdmin()
        {
            Navigation.NavigateTo("/admin/menu");
        }

        public void EditarVuelo(int id)
        {
            Navigation.NavigateTo($"/admin/vuelos/editar/{id}");
        }

        public async Task EliminarVuelo(VueloCargaDTO vuelo)
        {
            try
            {
                string mensaje = $"¿Está seguro de que desea eliminar el vuelo desde " +
                                 $"{vuelo.CiudadOrigenNombre} a {vuelo.CiudadDestinoNombre} " +
                                 $"del día: {vuelo.FechaHoraVuelo.ToString("dd/MM/yyyy")}, " +
                                 $"hora: {vuelo.FechaHoraVuelo.ToString("HH:mm")}, " +
                                 $"aerolínea: {vuelo.Aerolinea}?";

                bool confirmado = await JS.InvokeAsync<bool>("confirm", mensaje);

                if (!confirmado)
                {
                    return;
                }

                mensajeError = null;
                var response = await Http.DeleteAsync($"vuelos/{vuelo.Id}");

                if (response.IsSuccessStatusCode)
                {
                    await CargarVuelos();
                }
                else
                {
                    mensajeError = "No se pudo eliminar el vuelo. Verifique que no tenga pasajes asociados o vuelva a intentarlo.";
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error de conexión al eliminar: {ex.Message}";
            }
        }

    }
}