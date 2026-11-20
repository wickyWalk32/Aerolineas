using DTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Blazor.Server.Components.Pages
{
    public partial class PaisEditar : ComponentBase
    {
        [Parameter] public int Id { get; set; }

        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;

        public PaisUpdateDTO paisDto { get; set; } = new();

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

                var paisExistente = await Http.GetFromJsonAsync<PaisDTO>($"paises/{Id}");
                if (paisExistente != null)
                {
                    paisDto = new PaisUpdateDTO
                    {
                        Id = paisExistente.Id,
                        Nombre = paisExistente.Nombre
                    };
                }
                else
                {
                    mensajeError = "No se encontró el país solicitado.";
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al cargar los datos del país: {ex.Message}";
            }
            finally
            {
                cargando = false;
            }
        }

        public async Task GuardarCambios()
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

                paisDto.Id = Id;
                paisDto.Nombre = paisDto.Nombre.Trim();

                var response = await Http.PutAsJsonAsync($"paises/{Id}", paisDto);

                if (response.IsSuccessStatusCode)
                {
                    Navigation.NavigateTo("/admin/paises");
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
            Navigation.NavigateTo("/admin/paises");
        }
    }
}