using DTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Blazor.Server.Components.Pages
{
    public partial class PasajeroNuevo : ComponentBase
    {
        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;

        public PasajeroCreateDTO pasajeroDto { get; set; } = new();

        public bool guardando { get; set; } = false;
        public string? mensajeError { get; set; }

        public async Task GuardarPasajero()
        {
            try
            {
                guardando = true;
                mensajeError = null;

                var response = await Http.PostAsJsonAsync("pasajeros", pasajeroDto);

                if (response.IsSuccessStatusCode)
                {
                    Navigation.NavigateTo("/admin/pasajeros");
                }
                else
                {
                    mensajeError = "No se pudo registrar el pasajero. Revise los datos e intente nuevamente.";
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
            Navigation.NavigateTo("/admin/pasajeros");
        }
    }
}