using DTOs;
using Microsoft.AspNetCore.Components;
using System.Globalization;
using System.Net.Http.Json;

namespace Blazor.Server.Components.Pages
{
    public partial class VueloNuevo : ComponentBase
    {
        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;

        public VueloCreateDTO vueloDto { get; set; } = new();
        public List<CiudadDTO> ciudades { get; set; } = new();
        public List<AvionDTO> aviones { get; set; } = new();

        public DateTime fechaVuelo { get; set; } = DateTime.Today;
        public TimeOnly horaVuelo { get; set; } = TimeOnly.FromDateTime(DateTime.Now);

        public bool guardando { get; set; } = false;
        public string? mensajeError { get; set; }
        public string precioTexto { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await CargarDesplegables();
        }

        private async Task CargarDesplegables()
        {
            try
            {
                var resCiudades = await Http.GetFromJsonAsync<List<CiudadDTO>>("ciudades");
                if (resCiudades != null) ciudades = resCiudades;

                var resAviones = await Http.GetFromJsonAsync<List<AvionDTO>>("aviones");
                if (resAviones != null) aviones = resAviones;
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al cargar listas: {ex.Message}";
            }
        }

        public async Task GuardarVuelo()
        {
            try
            {
                guardando = true;
                mensajeError = null;

                // Reemplazamos coma por punto para estandarizar antes de parsear
                string textoLimpio = precioTexto.Trim().Replace(',', '.');

                // Validamos el formato numérico soportando formato invariante (punto)
                if (decimal.TryParse(textoLimpio, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precioParseado))
                {
                    vueloDto.Precio = precioParseado;
                }
                else
                {
                    mensajeError = "El precio ingresado no es válido. Por favor, ingrese un número correcto.";
                    guardando = false;
                    return; // Detenemos la ejecución sin llamar a la API
                }

                vueloDto.FechaHoraVuelo = new DateTime(
                    fechaVuelo.Year, fechaVuelo.Month, fechaVuelo.Day,
                    horaVuelo.Hour, horaVuelo.Minute, 0
                );

                var response = await Http.PostAsJsonAsync("vuelos", vueloDto);

                if (response.IsSuccessStatusCode)
                {
                    Navigation.NavigateTo("/admin/vuelos");
                }
                else
                {
                    mensajeError = "No se pudo registrar el vuelo. Revise los datos e intente nuevamente.";
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
            Navigation.NavigateTo("/admin/vuelos");
        }
    }
}