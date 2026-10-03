using DTOs;
using Microsoft.AspNetCore.Components;
using System.Globalization;
using System.Net.Http.Json;

namespace Blazor.Server.Components.Pages
{
    public partial class VueloEditar : ComponentBase
    {
        [Parameter] public int Id { get; set; }

        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;

        public VueloUpdateDTO vueloDto { get; set; } = new();
        public List<CiudadDTO> ciudades { get; set; } = new();
        public List<AvionDTO> aviones { get; set; } = new();

        public DateTime fechaVuelo { get; set; } = DateTime.Today;
        public TimeOnly horaVuelo { get; set; } = TimeOnly.FromDateTime(DateTime.Now);

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

                var resCiudades = await Http.GetFromJsonAsync<List<CiudadDTO>>("ciudades");
                if (resCiudades != null) ciudades = resCiudades;

                var resAviones = await Http.GetFromJsonAsync<List<AvionDTO>>("aviones");
                if (resAviones != null) aviones = resAviones;

                var vueloExistente = await Http.GetFromJsonAsync<VueloCargaDTO>($"vuelos/{Id}");
                if (vueloExistente != null)
                {
                    vueloDto = new VueloUpdateDTO
                    {
                        Id = vueloExistente.Id,
                        IdCiudadOrigen = vueloExistente.IdCiudadOrigen,
                        CiudadOrigenNombre = vueloExistente.CiudadOrigenNombre,
                        IdCiudadDestino = vueloExistente.IdCiudadDestino,
                        CiudadDestinoNombre = vueloExistente.CiudadDestinoNombre,
                        IdAvion = vueloExistente.IdAvion,
                        Precio = vueloExistente.Precio,
                        Aerolinea = vueloExistente.Aerolinea,
                        FechaHoraVuelo = vueloExistente.FechaHoraVuelo
                    };

                    // Formateamos el decimal inicial como string estándar usando punto decimal
                    precioTexto = vueloExistente.Precio.ToString("0.00", CultureInfo.InvariantCulture);

                    fechaVuelo = vueloExistente.FechaHoraVuelo.Date;
                    horaVuelo = TimeOnly.FromDateTime(vueloExistente.FechaHoraVuelo);
                }
                else
                {
                    mensajeError = "No se encontró el vuelo solicitado.";
                }
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al cargar los datos del vuelo: {ex.Message}";
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

                // Remplazamos comas por puntos para que admita ambos separadores decimales
                string textoLimpio = precioTexto.Trim().Replace(',', '.');

                // Validamos el formato numérico antes de llamar a la API
                if (decimal.TryParse(textoLimpio, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precioParseado))
                {
                    vueloDto.Precio = precioParseado;
                }
                else
                {
                    mensajeError = "El precio ingresado no es válido. Por favor, ingrese un número correcto.";
                    guardando = false;
                    return; // Interrumpe el guardado sin pegarle al backend
                }

                vueloDto.FechaHoraVuelo = new DateTime(
                    fechaVuelo.Year, fechaVuelo.Month, fechaVuelo.Day,
                    horaVuelo.Hour, horaVuelo.Minute, 0
                );

                var response = await Http.PutAsJsonAsync($"vuelos/{Id}", vueloDto);

                if (response.IsSuccessStatusCode)
                {
                    Navigation.NavigateTo("/admin/vuelos");
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
            Navigation.NavigateTo("/admin/vuelos");
        }
    }
}