using DTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Blazor.Server.Components.Pages
{
    public partial class PaisNuevo : ComponentBase
    {
        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;

        public PaisCreateDTO paisDto { get; set; } = new();

        public bool guardando { get; set; } = false;
        public string? mensajeError { get; set; }

        public async Task GuardarPais()
        {
            if (string.IsNullOrWhiteSpace(paisDto.Nombre))
            {
                mensajeError = "El nombre del país es obligatorio.";
                return;
            }

            try
            {
                guardando = true;
                mensajeError = null;

                paisDto.Nombre = paisDto.Nombre.Trim();
                var response = await Http.PostAsJsonAsync("paises", paisDto);

                if (response.IsSuccessStatusCode)
                {
                    Navigation.NavigateTo("/admin/paises");
                }
                else
                {
                    mensajeError = "No se pudo registrar el país. Revise los datos e intente nuevamente.";
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
            Navigation.NavigateTo("/admin/paises");
        }
    }
}