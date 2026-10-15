using DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace Blazor.Server.Components.Pages
{
    public partial class UsuarioAdminMenu : ComponentBase
    {
        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;
        [Inject] public IJSRuntime JS { get; set; } = default!;

        public List<UsuarioDTO> usuarios { get; set; } = new();
        public bool cargando { get; set; } = true;
        public string? mensajeError { get; set; }
        public UsuarioDTO? usuarioAEliminar { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await CargarUsuarios();
        }

        private async Task CargarUsuarios()
        {
            try
            {
                cargando = true;
                mensajeError = null;

                var listaUsuarios = await Http.GetFromJsonAsync<List<UsuarioDTO>>("usuarios");

                if (listaUsuarios != null)
                {
                    usuarios = listaUsuarios;
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al obtener los usuarios: {ex.Message}";
            }
            finally
            {
                cargando = false;
            }
        }

        public void IrANuevoUsuario()
        {
            Navigation.NavigateTo("/admin/usuarios/nuevo");
        }

        public void VolverAlMenuAdmin()
        {
            Navigation.NavigateTo("/admin/menu");
        }

        public void EditarUsuario(int id)
        {
            Navigation.NavigateTo($"/admin/usuarios/editar/{id}");
        }

        public void SolicitarEliminacion(UsuarioDTO usuario)
        {
            usuarioAEliminar = usuario;
        }

        public void CancelarEliminacion()
        {
            usuarioAEliminar = null;
        }

        public async Task ConfirmarEliminacion()
        {
            if (usuarioAEliminar == null) return;

            try
            {
                int id = usuarioAEliminar.Id;
                usuarioAEliminar = null;

                mensajeError = null;
                var response = await Http.DeleteAsync($"usuarios/{id}");

                if (response.IsSuccessStatusCode)
                {
                    await CargarUsuarios();
                }
                else
                {
                    mensajeError = "No se pudo eliminar el usuario. Verifique que no tenga dependencias activas o vuelva a intentarlo.";
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error de conexión al eliminar: {ex.Message}";
            }
        }
    }
}