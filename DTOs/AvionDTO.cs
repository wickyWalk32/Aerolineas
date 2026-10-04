using System;
using System.Collections.Generic;

namespace DTOs
{
    // DTO para respuestas (GET)
    public class AvionDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Capacidad { get; set; }
        public string EstadoDisponibilidad { get; set; }
    }

    // DTO para creación (POST)
    public class AvionCreateDTO
    {
        public string Descripcion { get; set; }
        public int Capacidad { get; set; }
        public string EstadoDisponibilidad { get; set; } // Cambiado de 'private set' a 'set'
        public List<AsientoCreateDTO>? AsientosCreateDTO { get; set; }

    }

    // DTO para actualización (PUT)
    public class AvionUpdateDTO
    {
        public int Id { get; set; } // Cambiado de 'private set' a 'set'
        public string Descripcion { get; set; }
        public int Capacidad { get; set; }
        public string EstadoDisponibilidad { get; set; }
    }

}