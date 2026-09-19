using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Model
{
    public class Usuario
    {

        // <<< ATRIBUTOS >>>
        
        public int Id { get; private set; }
        public string Nombre { get; private set; } = string.Empty;
        public string Apellido { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string ContraseniaHash { get; private set; } = string.Empty;
        public string Rol { get; private set; } = string.Empty;

        private static readonly PasswordHasher<Usuario> PasswordHasher = new();

        // <<< ATRIBUTOS DE NAVEGACIÓN DEL MODELO >>>

        // 1 Usuario > Muchas Reservas

        private readonly List<Reserva> _reservas = new();
        public IReadOnlyCollection<Reserva> Reservas => _reservas.AsReadOnly();

        // <<< CONSTRUCTORES >>>

        public Usuario()
        {
        }

        public Usuario(string nombre, string apellido, string email, string contrasenia, string rol) 
        {
            this.SetNombre(nombre);
            this.SetApellido(apellido);
            this.SetEmail(email);
            this.SetContraseniaHash(contrasenia);
            this.SetRol(rol);
        }

        public Usuario(int id, string nombre, string apellido, string email, string contrasenia, string rol)
        {
            this.SetId(id);
            this.SetNombre(nombre);
            this.SetApellido(apellido);
            this.SetEmail(email);
            this.SetContraseniaHash(contrasenia);
            this.SetRol(rol);
        }

        // <<< MÉTODOS: SETTERS >>>

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("Id de usuario inválido.");
            this.Id = id;
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("Nombre de usuario inválido.");
            this.Nombre = nombre;
        }

        public void SetApellido(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("Apellido de usuario inválido.");
            this.Apellido = apellido;
        }

        public void SetEmail(string email)
        {
            if (!EsEmailValido(email))
                throw new ArgumentException("El email del usuario no tiene un formato válido.", nameof(email));
            this.Email = email;
        }

        public void SetContraseniaHash(string contrasenia)
        {
            this.ContraseniaHash = PasswordHasher.HashPassword(this, contrasenia);
        }

        public void SetRol(string rol)
        {
            if (string.IsNullOrWhiteSpace(rol))
                throw new ArgumentException("Rol del usuario inválido.");
            this.Rol = rol;
        }

        public void AddReserva(Reserva reserva)
        {
            ArgumentNullException.ThrowIfNull(reserva);
            _reservas.Add(reserva);
        }

        public void RemoveReserva(Reserva reserva)
        {
            ArgumentNullException.ThrowIfNull(reserva);
            _reservas.Remove(reserva);
        }

        // <<< DEMÁS MÉTODOS >>>

        private static bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

    }
}
