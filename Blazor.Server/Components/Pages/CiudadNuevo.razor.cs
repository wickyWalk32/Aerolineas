using DTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Blazor.Server.Components.Pages
{
    public partial class CiudadNuevo : ComponentBase
    {
        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;

        public CiudadCreateDTO ciudadDto { get; set; } = new();
        public List<PaisDTO> paises { get; set; } = new();

        public bool guardando { get; set; } = false;
        public string? mensajeError { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await CargarPaises();
        }

        private async Task CargarPaises()
        {
            try
            {
                var resPaises = await Http.GetFromJsonAsync<List<PaisDTO>>("paises");
                if (resPaises != null) paises = resPaises;
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al cargar los países: {ex.Message}";
            }
        }

        public async Task GuardarCiudad()
        {
            try
            {
                guardando = true;
                mensajeError = null;

                var response = await Http.PostAsJsonAsync("ciudades", ciudadDto);

                if (response.IsSuccessStatusCode)
                {
                    Navigation.NavigateTo("/admin/ciudades");
                }
                else
                {
                    mensajeError = "No se pudo registrar la ciudad. Revise los datos e intente nuevamente.";
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error de conexión: {ex.Message}";
            }
            finally
            {
                guardando = false;
            }
        }

        public void VolverAlMenu()
        {
            Navigation.NavigateTo("/admin/ciudades");
        }
    }
}
