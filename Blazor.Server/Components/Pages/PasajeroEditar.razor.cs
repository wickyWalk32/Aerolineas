using DTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Blazor.Server.Components.Pages
{
    public partial class PasajeroEditar : ComponentBase
    {
        [Parameter] public int Id { get; set; }

        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;

        public PasajeroUpdateDTO pasajeroDto { get; set; } = new();

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

                var pasajeroExistente = await Http.GetFromJsonAsync<PasajeroDTO>($"pasajeros/{Id}");
                if (pasajeroExistente != null)
                {
                    pasajeroDto = new PasajeroUpdateDTO
                    {
                        Id = pasajeroExistente.Id,
                        Nombre = pasajeroExistente.Nombre,
                        Apellido = pasajeroExistente.Apellido,
                        TipoDocumento = pasajeroExistente.TipoDocumento,
                        NroDocumento = pasajeroExistente.NroDocumento,
                        Tipo = pasajeroExistente.Tipo
                    };
                }
                else
                {
                    mensajeError = "No se encontró el pasajero solicitado.";
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al cargar los datos del pasajero: {ex.Message}";
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

                var response = await Http.PutAsJsonAsync($"pasajeros/{Id}", pasajeroDto);

                if (response.IsSuccessStatusCode)
                {
                    Navigation.NavigateTo("/admin/pasajeros");
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
            Navigation.NavigateTo("/admin/pasajeros");
        }
    }
}