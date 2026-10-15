using DTOs;
using Microsoft.AspNetCore.Components;
using System.Globalization;
using System.Net.Http.Json;

namespace Blazor.Server.Components.Pages
{
    public partial class ServicioEditar : ComponentBase
    {
        [Parameter] public int Id { get; set; }

        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;

        public ServicioUpdateDTO servicioDto { get; set; } = new();

        public bool cargando { get; set; } = true;
        public bool guardando { get; set; } = false;
        public string? mensajeError { get; set; }
        public string precioTexto { get; set; } = string.Empty;

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

                // Asumiendo que el endpoint GET por ID en la API de servicios es "servicios/{Id}"
                var servicioExistente = await Http.GetFromJsonAsync<ServicioCargaDTO>($"servicios/{Id}");
                if (servicioExistente != null)
                {
                    servicioDto = new ServicioUpdateDTO
                    {
                        Id = servicioExistente.Id,
                        Nombre = servicioExistente.Nombre,
                        Descripcion = servicioExistente.Descripcion,
                        Precio = servicioExistente.Precio
                    };

                    // Formateamos el decimal inicial con punto invariant
                    precioTexto = servicioExistente.Precio.ToString("0.00", CultureInfo.InvariantCulture);
                }
                else
                {
                    mensajeError = "No se encontró el servicio solicitado.";
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al cargar los datos del servicio: {ex.Message}";
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

                // Reemplazamos comas por puntos para admitir ambos separadores en el precio
                string textoLimpio = precioTexto.Trim().Replace(',', '.');

                if (decimal.TryParse(textoLimpio, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precioParseado))
                {
                    servicioDto.Precio = precioParseado;
                }
                else
                {
                    mensajeError = "El precio ingresado no es válido. Por favor, ingrese un número correcto.";
                    guardando = false;
                    return;
                }

                var response = await Http.PutAsJsonAsync($"servicios/{Id}", servicioDto);

                if (response.IsSuccessStatusCode)
                {
                    Navigation.NavigateTo("/admin/servicios");
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
            Navigation.NavigateTo("/admin/servicios");
        }
    }
}