using DTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Blazor.Server.Components.Pages
{
    public partial class UsuarioEditar : ComponentBase
    {
        [Parameter] public int Id { get; set; }

        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;

        public UsuarioUpdateDTO usuarioDto { get; set; } = new();

        public bool cargando { get; set; } = true;
        public bool guardando { get; set; } = false;
        public string? mensajeError { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await CargarDatos();
        }

        private async Task CargarDatos()
        {
            try
            {
                cargando = true;
                mensajeError = null;

                // Se asume que el endpoint para obtener un usuario por ID es "usuarios/{Id}"
                var usuarioExistente = await Http.GetFromJsonAsync<UsuarioDTO>($"usuarios/{Id}");
                if (usuarioExistente != null)
                {
                    usuarioDto = new UsuarioUpdateDTO
                    {
                        Id = usuarioExistente.Id,
                        Email = usuarioExistente.Email,
                        Nombre = usuarioExistente.Nombre,
                        Apellido = usuarioExistente.Apellido,
                        Rol = usuarioExistente.Rol
                    };
                }
                else
                {
                    mensajeError = "No se encontró el usuario solicitado.";
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al cargar los datos del usuario: {ex.Message}";
            }
            finally
            {
                cargando = false;
            }
        }

        public async Task GuardarCambios()
        {
            try
            {
                guardando = true;
                mensajeError = null;

                var response = await Http.PutAsJsonAsync($"usuarios/{Id}", usuarioDto);

                if (response.IsSuccessStatusCode)
                {
                    Navigation.NavigateTo("/admin/usuarios");
                }
                else
                {
                    mensajeError = "No se pudieron guardar los cambios. Revise los datos e intente nuevamente.";
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