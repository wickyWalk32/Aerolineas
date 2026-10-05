using DTOs;
using Microsoft.AspNetCore.Components;
using System.Globalization;
using System.Net.Http.Json;

namespace Blazor.Server.Components.Pages
{
    public partial class AvionEditar : ComponentBase
    {
        [Parameter] public int Id { get; set; }

        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;

        public AvionUpdateDTO avionDto { get; set; } = new();

        public bool cargando { get; set; } = true;
        public bool guardando { get; set; } = false;
        public string? mensajeError { get; set; }

        // Campo auxiliar de texto para parseo seguro de la capacidad entera
        public string capacidadTexto { get; set; } = string.Empty;

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

                // Endpoint GET por ID en la API de aviones ("aviones/{Id}")
                var avionExistente = await Http.GetFromJsonAsync<AvionDTO>($"aviones/{Id}");
                if (avionExistente != null)
                {
                    avionDto = new AvionUpdateDTO
                    {
                        Id = avionExistente.Id,
                        Descripcion = avionExistente.Descripcion,
                        Capacidad = avionExistente.Capacidad,
                        EstadoDisponibilidad = avionExistente.EstadoDisponibilidad
                    };

                    // Cargamos el valor inicial de capacidad en formato texto con CultureInfo Invariant
                    capacidadTexto = avionExistente.Capacidad.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    mensajeError = "No se encontró el avión solicitado.";
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al cargar los datos del avión: {ex.Message}";
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

                // Validación y parseo de Capacidad (entero)
                string capLimpia = capacidadTexto.Trim();
                if (int.TryParse(capLimpia, NumberStyles.Integer, CultureInfo.InvariantCulture, out int capParseada))
                {
                    avionDto.Capacidad = capParseada;
                }
                else
                {
                    mensajeError = "La capacidad ingresada no es válida. Debe ser un número entero.";
                    guardando = false;
                    return;
                }

                var response = await Http.PutAsJsonAsync($"aviones/{Id}", avionDto);

                if (response.IsSuccessStatusCode)
                {
                    Navigation.NavigateTo("/admin/aviones");
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
            Navigation.NavigateTo("/admin/aviones");
        }
    }
}