using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace DTOs
{
    public class VueloCargaDTO
    {
        public int Id { get; set; }
        public DateTime FechaHoraVuelo { get; set; }
        public string Aerolinea { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int IdCiudadOrigen { get; set; }
        public string CiudadOrigenNombre { get; set; } = string.Empty;
        public int IdCiudadDestino { get; set; }
        public string CiudadDestinoNombre { get; set; } = string.Empty;
        public int IdAvion { get; set; }
        public string AvionDescripcion { get; private set; } = string.Empty;
        public int AvionCapacidad { get; private set; }

        private readonly List<Reserva> _reservas = new();
    }

    public class VueloCreateDTO
    {
        public DateTime FechaHoraVuelo { get; set; }
        public string Aerolinea { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int IdCiudadOrigen { get; set; }
        public int IdCiudadDestino { get; set; }
        public int IdAvion { get; set; }

        private readonly List<Reserva> _reservas = new();
    }

    public class VueloUpdateDTO
    {
        public int Id { get; set; }
        public DateTime FechaHoraVuelo { get; set; }
        public string Aerolinea { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int IdCiudadOrigen { get; set; }
        public string CiudadOrigenNombre { get; set; } = string.Empty;
        public int IdCiudadDestino { get; set; }
        public string CiudadDestinoNombre { get; set; } = string.Empty;
        public int IdAvion { get; set; }

        private readonly List<Reserva> _reservas = new();
    }

    public class VueloDeleteDTO
    {
        // Si se borra un vuelo, se necesita el avión para navegar hasta sus asientos y también borrarlos.
        // Si se borra un vuelo se necesita su listado de reservas para también borrarlas.

        public int Id { get; set; }
        public DateTime FechaHoraVuelo { get; set; }
        public string Aerolinea { get; set; } = string.Empty;
        public string CiudadOrigenNombre { get; set; } = string.Empty;
        public string CiudadDestinoNombre { get; set; } = string.Empty;
        public int IdAvion { get; set; }

        private readonly List<Reserva> _reservas = new();
    }

}