using DTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Blazor.Server.Components.Pages
{
    public partial class CiudadEditar : ComponentBase
    {
        [Parameter] public int Id { get; set; }

        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;

        public CiudadUpdateDTO ciudadDto { get; set; } = new();

        // Lista auxiliar para cargar el desplegable de países
        public List<PaisDTO>? paises { get; set; }

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

                var tareaPaises = Http.GetFromJsonAsync<List<PaisDTO>>("paises");
                var tareaCiudad = Http.GetFromJsonAsync<CiudadDTO>($"ciudades/{Id}");
                
                await Task.WhenAll(tareaCiudad, tareaPaises);

                var ciudadExistente = tareaCiudad.Result;
                paises = tareaPaises.Result;

                if (ciudadExistente != null)
                {
                    ciudadDto = new CiudadUpdateDTO
                    {
                        Id = ciudadExistente.Id,
                        Nombre = ciudadExistente.Nombre,
                        CodigoPostal = ciudadExistente.CodigoPostal,
                        CodigoAeropuerto = ciudadExistente.CodigoAeropuerto,
                        PaisId = ciudadExistente.PaisId
                    };
                }
                else
                {
                    mensajeError = "No se encontró la ciudad solicitada.";
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al cargar los datos: {ex.Message}";
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

                // Validación simple de país seleccionado
                if (ciudadDto.PaisId <= 0)
                {
                    mensajeError = "Por favor, seleccione un país válido.";
                    guardando = false;
                    return;
                }

                var response = await Http.PutAsJsonAsync($"ciudades/{Id}", ciudadDto);

                if (response.IsSuccessStatusCode)
                {
                    Navigation.NavigateTo("/admin/ciudades");
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
            Navigation.NavigateTo("/admin/ciudades");
        }
    }

}