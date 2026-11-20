using System;
using System.Collections.Generic;

namespace DTOs
{
    public class ReservaDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int VueloId { get; set; }
        public int IdTarjetaCliente { get; set; }
        public DateTime FechaHoraReserva { get; set; }
        public List<PasajeDTO> Pasajes { get; set; } = new();
    }

    public class ReservaCreateDTO
    {
        public int UsuarioId { get; set; }
        public int VueloId { get; set; }
        public DateTime FechaHoraReserva { get; set; } = DateTime.UtcNow;

        // Datos para registrar TarjetaCliente
        public string UltimosCuatroDigitos { get; set; } = string.Empty;
        public DateTime FechaVencimientoTarjeta { get; set; }

        public List<PasajeCreateDTO> Pasajes { get; set; } = new();
    }

    public class ReservaUpdateDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaHoraReserva { get; set; }
    }
}