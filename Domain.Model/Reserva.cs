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

        // <<< ATRIBUTOS >>>

        public int Id { get; private set; }
        public DateTime FechaHoraReserva { get; private set; }


        // <<< ATRIBUTOS DE NAVEGACIÓN DEL MODELO >>>

        // 1 Reserva > 1 Usuario
        public int UsuarioId { get; private set; }
        public Usuario? Usuario { get; private set; }

        // 1 Reserva > 1 TarjetaCliente
        public int IdTarjetaCliente { get; private set; }
        public TarjetaCliente? TarjetaCliente { get; private set; }
        
        // 1 Reserva > Muchos Pasajes

        private readonly List<Pasaje> _pasajes = new(); // new List<Pasaje>() ?
        public IReadOnlyCollection<Pasaje> Pasajes => _pasajes.AsReadOnly();


        // <<< CONSTRUCTORES >>>

        public Reserva()
        {
        }

        public Reserva(DateTime fechaHoraReserva, int idUsuario)
        {
            this.SetFechaHoraReserva(fechaHoraReserva);
            this.SetIdUsuario(idUsuario);
        }

        public Reserva(DateTime fechaHoraReserva, Usuario usuario, int idUsuario, TarjetaCliente tarjetaCliente, int idTarjetaCliente)
        {
            this.SetFechaHoraReserva(fechaHoraReserva);
            this.SetUsuario(usuario);
            this.SetIdUsuario(idUsuario);
            this.SetTarjetaCliente(tarjetaCliente);
            this.SetIdTarjetaCliente(idTarjetaCliente);
        }
        public Reserva(int id, DateTime fechaHoraReserva, Usuario usuario, int idUsuario, TarjetaCliente tarjetaCliente, int idTarjetaCliente)
        {
            this.SetId(id);
            this.SetFechaHoraReserva(fechaHoraReserva);
            this.SetUsuario(usuario);
            this.SetIdUsuario(idUsuario);
            this.SetTarjetaCliente(tarjetaCliente);
            this.SetIdTarjetaCliente(idTarjetaCliente);
        }


        // <<< MÉTODOS: SETTERS >>>

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("Id de reserva inválido.");
            this.Id = id;
        }

        public void SetFechaHoraReserva(DateTime fechaHoraReserva)
        {
            this.FechaHoraReserva = fechaHoraReserva;
        }

        public void SetUsuario(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentException("Usuario de la reserva es inválido.");
            this.Usuario = usuario;
        }

        public void SetIdUsuario(int usuarioId)
        {
            if (usuarioId < 0)
                throw new ArgumentException("Id de usuario de la reserva es inválido.");
            this.UsuarioId = usuarioId;
        }

        public void SetTarjetaCliente(TarjetaCliente tarjetaCliente)
        {
            if (tarjetaCliente == null)
                throw new ArgumentException("Tarjeta de cliente para la reserva es inválida.");
            this.TarjetaCliente = tarjetaCliente;
        }

        public void SetIdTarjetaCliente(int idTarjetaCliente)
        {
            if (idTarjetaCliente < 0)
                throw new ArgumentException("Id de tarjeta cliente para la reserva es inválido.");
            this.IdTarjetaCliente = idTarjetaCliente;
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

        // <<< DEMÁS MÉTODOS >>>

    }
}
