using DTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Blazor.Server.Components.Pages
{
    public partial class RegistroUsuario : ComponentBase
    {
        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;

        public UsuarioRegistroDTO usuarioDto { get; set; } = new()
        {
            Nombre = string.Empty,
            Apellido = string.Empty,
            Email = string.Empty,
            Contrasenia = string.Empty
        };

        public bool guardando { get; set; } = false;
        public string? mensajeError { get; set; }

        public async Task RegistrarUsuario()
        {
            try
            {
                guardando = true;
                mensajeError = null;

                var response = await Http.PostAsJsonAsync("registro", usuarioDto);

                if (response.IsSuccessStatusCode)
                {
                    // Una vez registrado con éxito, lo redirigimos al login
                    Navigation.NavigateTo("/login");
                }
                else
                {
                    // Si el backend devuelve un error (ej: BadRequest con mensaje de excepción)
                    var errorContent = await response.Content.ReadAsStringAsync();
                    mensajeError = "No se pudo registrar el usuario. Revise los datos e intente nuevamente.";
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

        public void VolverAlLogin()
        {
            Navigation.NavigateTo("/login");
        }
    }
}