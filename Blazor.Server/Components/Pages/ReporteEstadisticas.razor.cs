using DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Blazor.Server.Components.Pages
{
    public partial class ReporteEstadisticas : ComponentBase
    {
        [Inject] public HttpClient Http { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;
        [Inject] public IJSRuntime JS { get; set; } = default!;

        public ReporteEstadisticasDTO? reporte { get; set; }
        public bool cargando { get; set; } = true;
        public string? mensajeError { get; set; }
        public string tipoTorta { get; set; } = "ingresosBaseServicios";

        private static readonly string[] coloresTorta =
        {
            "#0d6efd",
            "#198754",
            "#fd7e14",
            "#6f42c1",
            "#0dcaf0",
            "#dc3545",
            "#6c757d",
            "#20c997"
        };

        protected override async Task OnInitializedAsync()
        {
            await CargarReporte();
        }

        private async Task CargarReporte()
        {
            try
            {
                cargando = true;
                mensajeError = null;

                reporte = await Http.GetFromJsonAsync<ReporteEstadisticasDTO>("reportes/estadisticas");
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al obtener las estadísticas del reporte: {ex.Message}";
            }
            finally
            {
                cargando = false;
            }
        }

        public void SeleccionarTorta(string tipo)
        {
            tipoTorta = tipo;
        }

        public async Task DescargarPdfAsync()
        {
            await JS.InvokeVoidAsync("window.print");
        }

        public void VolverAlMenuAdmin()
        {
            Navigation.NavigateTo("/admin/menu");
        }

        private List<SegmentoTorta> ObtenerSegmentosTorta()
        {
            if (reporte == null) return new();

            return tipoTorta switch
            {
                "pasajesReserva" => reporte.PasajesPorReserva
                    .Select(x => new SegmentoTorta(x.Etiqueta, x.Cantidad, $"{x.Cantidad} reservas"))
                    .ToList(),

                "ingresosDestino" => reporte.IngresosPorDestino
                    .Select(x => new SegmentoTorta(x.Etiqueta, x.Monto, $"$ {x.Monto:N2}"))
                    .ToList(),

                _ => reporte.IngresosBaseVsServicios
                    .Select(x => new SegmentoTorta(x.Etiqueta, x.Monto, $"$ {x.Monto:N2}"))
                    .ToList()
            };
        }

        private static string DescribirSectorTorta(double cx, double cy, double r, double anguloInicio, double anguloFin)
        {
            var inicio = PolarACartesiano(cx, cy, r, anguloFin);
            var fin = PolarACartesiano(cx, cy, r, anguloInicio);
            string arcoLargo = (anguloFin - anguloInicio) > 180.0 ? "1" : "0";

            return string.Create(
                CultureInfo.InvariantCulture,
                $"M {cx} {cy} L {inicio.X:0.###} {inicio.Y:0.###} A {r} {r} 0 {arcoLargo} 0 {fin.X:0.###} {fin.Y:0.###} Z");
        }

        private static (double X, double Y) PolarACartesiano(double cx, double cy, double r, double anguloGrados)
        {
            double radianes = (anguloGrados - 90.0) * Math.PI / 180.0;
            return (cx + r * Math.Cos(radianes), cy + r * Math.Sin(radianes));
        }

        private sealed record SegmentoTorta(string Etiqueta, decimal Valor, string ValorFormateado);
    }
}