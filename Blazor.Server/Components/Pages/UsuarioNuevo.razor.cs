using DTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Blazor.Server.Components.Pages
{
    public partial class UsuarioNuevo : ComponentBase
    {
        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;

        public UsuarioCreateDTO usuarioDto { get; set; } = new()
        {
            Email = string.Empty,
            Contrasenia = string.Empty,
            Rol = string.Empty
        };

        public bool guardando { get; set; } = false;
        public string? mensajeError { get; set; }

        public async Task GuardarUsuario()
        {
            try
            {
                guardando = true;
                mensajeError = null;

                var response = await Http.PostAsJsonAsync("usuarios", usuarioDto);

                if (response.IsSuccessStatusCode)
                {
                    Navigation.NavigateTo("/admin/usuarios");
                }
                else
                {
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

        public void VolverAlMenu()
        {
            Navigation.NavigateTo("/admin/usuarios");
        }
    }
}