using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ReservaDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaHoraReserva { get; set; }
    }

    public class ReservaCreateDTO
    {
        public int UsuarioId { get; set; }
        public DateTime FechaHoraReserva { get; set; }
    }
    public class ReservaUpdateDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaHoraReserva { get; set; }
    }
}
