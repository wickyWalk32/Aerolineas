using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Pasaje
    {
        public int Id { get; set; }
        public string Estado { get; private set; }

        private Reserva _reserva;
        private int _reservaId;

        public Reserva Reserva { get; set; }
        public int ReservaId { get; set; }

        // PASAJERO
        private Pasajero _pasajero;
        public Pasajero Pasajero { get; set; }
        private int _pasajeroId;      
        public int PasajeroId { get; set; }

        // VUELO
        private Vuelo _vuelo;
        public Vuelo Vuelo { get; set; }

        public int VueloId;

        // ASIENTO
        private Asiento _asiento;
        public Asiento Asiento { get; set; }

        public string AsientoCodigo;
        public int AvionId;

        public Pasaje(string estado)
        {
            setEstado(estado);
        }

        public void setEstado(string estado)
        {
            Estado = estado;
        }
    }
}
