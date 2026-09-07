using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Reserva
    {
        public int Id { get; private set; }
        public DateTime FechaHoraReserva { get; private set; }

        private Usuario _usuario;
        private int _usuarioId;

        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

        public Asiento Asiento { get; set; }



        private readonly List<Pasaje> _pasajes = new();
        public IReadOnlyCollection<Pasaje> Pasajes => _pasajes.AsReadOnly();

        public Reserva(DateTime fechaHoraReserva, int usuarioId)
        {
            setFechaHoraReserva(fechaHoraReserva);
            setUsuarioId(usuarioId);
        }

        public void setFechaHoraReserva(DateTime fechaHoraReserva)
        {
            FechaHoraReserva = fechaHoraReserva;
        }

        public void setUsuarioId(int usuarioId)
        {
            UsuarioId = usuarioId;
        }

        public void AddPasaje(Pasaje pasaje)
        {
            ArgumentNullException.ThrowIfNull(pasaje);
            _pasajes.Add(pasaje);
        }

        public void RemovePasaje(Pasaje pasaje)
        {
            ArgumentNullException.ThrowIfNull(pasaje);
            _pasajes.Remove(pasaje);
        }

    }
}
