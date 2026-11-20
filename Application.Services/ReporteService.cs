using Data;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ReporteService
    {
        private readonly IReservaRepository _reservaRepository;

        public ReporteService(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public async Task<ReporteEstadisticasDTO> ObtenerEstadisticasAsync()
        {
            var reservas = await _reservaRepository.GetAllWithDetallesAsync();

            var reporte = new ReporteEstadisticasDTO
            {
                FechaGeneracion = DateTime.Now,
                TotalReservas = reservas.Count
            };

            decimal ingresosBase = 0m;
            decimal ingresosServicios = 0m;
            int totalPasajes = 0;

            var conteoOrigenes = new Dictionary<string, int>();
            var conteoDestinos = new Dictionary<string, int>();

            int reservasUnPasaje = 0;
            int reservasMultiplesPasajes = 0;

            var montosPorDestino = new Dictionary<string, decimal>();

            foreach (var reserva in reservas)
            {
                var vuelo = reserva.Vuelo;
                decimal precioVuelo = vuelo?.Precio ?? 0m;
                string origenNombre = vuelo?.CiudadOrigen?.Nombre ?? $"Ciudad #{vuelo?.IdCiudadOrigen ?? 0}";
                string destinoNombre = vuelo?.CiudadDestino?.Nombre ?? $"Ciudad #{vuelo?.IdCiudadDestino ?? 0}";

                int cantPasajesReserva = reserva.Pasajes.Count;
                totalPasajes += cantPasajesReserva;

                if (cantPasajesReserva <= 1)
                    reservasUnPasaje++;
                else
                    reservasMultiplesPasajes++;

                int pesoRuta = cantPasajesReserva > 0 ? cantPasajesReserva : 1;
                conteoOrigenes[origenNombre] = conteoOrigenes.GetValueOrDefault(origenNombre) + pesoRuta;
                conteoDestinos[destinoNombre] = conteoDestinos.GetValueOrDefault(destinoNombre) + pesoRuta;

                decimal baseReserva = precioVuelo * cantPasajesReserva;
                decimal serviciosReserva = reserva.Pasajes
                    .SelectMany(p => p.Servicios)
                    .Sum(s => s.Precio);

                ingresosBase += baseReserva;
                ingresosServicios += serviciosReserva;

                decimal totalReserva = baseReserva + serviciosReserva;
                montosPorDestino[destinoNombre] = montosPorDestino.GetValueOrDefault(destinoNombre) + totalReserva;
            }

            reporte.TotalPasajes = totalPasajes;
            reporte.IngresosPasajesBase = ingresosBase;
            reporte.IngresosServiciosAdicionales = ingresosServicios;
            reporte.RecaudacionTotal = ingresosBase + ingresosServicios;

            reporte.OrigenesMasElegidos = conteoOrigenes
                .OrderByDescending(x => x.Value)
                .Take(8)
                .Select(x => new ItemConteoDTO { Etiqueta = x.Key, Cantidad = x.Value })
                .ToList();

            reporte.DestinosMasElegidos = conteoDestinos
                .OrderByDescending(x => x.Value)
                .Take(8)
                .Select(x => new ItemConteoDTO { Etiqueta = x.Key, Cantidad = x.Value })
                .ToList();

            reporte.IngresosBaseVsServicios = new List<ItemMontoDTO>
            {
                new() { Etiqueta = "Pasajes base", Monto = ingresosBase },
                new() { Etiqueta = "Servicios adicionales", Monto = ingresosServicios }
            };

            reporte.PasajesPorReserva = new List<ItemConteoDTO>
            {
                new() { Etiqueta = "1 pasaje", Cantidad = reservasUnPasaje },
                new() { Etiqueta = "2 o más pasajes", Cantidad = reservasMultiplesPasajes }
            };

            reporte.IngresosPorDestino = montosPorDestino
                .OrderByDescending(x => x.Value)
                .Take(8)
                .Select(x => new ItemMontoDTO { Etiqueta = x.Key, Monto = x.Value })
                .ToList();

            return reporte;
        }
    }
}