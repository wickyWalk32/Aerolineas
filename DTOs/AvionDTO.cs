using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class AvionDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Capacidad { get; set; }
        public string EstadoDisponibilidad { get; set; }

        //private List<Asiento> Asientos = new();
    }

    public class AvionUpdateDTO
    {
        public int Id { get; private set; }
        public string Descripcion { get; private set; }
        public int Capacidad { get; private set; }
        public string EstadoDisponibilidad { get; private set; }


    }
    public class AvionCreateDTO
    {
        public required string Descripcion { get; set; }
        public required int Capacidad { get; set; }
        public string EstadoDisponibilidad { get; private set; }

    }
}
