using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Model
{
    public class Usuario
    {
        // Atributos de la clase Usuario


        private static readonly PasswordHasher<Usuario> PasswordHasher = new();
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ContraseniaHash { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;

        private readonly List<Reserva> _reservas = new();
        public IReadOnlyCollection<Reserva> Reservas => _reservas.AsReadOnly();

        // Constructores de la clase Usuario

        public Usuario()
        {
        }

        public Usuario(string nombre, string apellido, string email, string contrasenia, string rol) 
        {
            SetNombre(nombre);
            SetApellido(apellido);
            SetEmail(email);
            SetContraseniaHash(contrasenia);
            SetRol(rol);
        }

        // Métodos de la clase Usuario

        public void SetId(int id) 
        {
            Id = id;
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("Nombre inválido.");
            Nombre = nombre;
        }

        public void SetApellido(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("Apellido inválido.");
            Apellido = apellido;
        }
        
        public void SetEmail(string email) 
        {
            if (!EsEmailValido(email))
                throw new ArgumentException("El email no tiene un formato válido.", nameof(email));
            Email = email;
        }

        private static bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public void SetContraseniaHash(string contrasenia)
        {
            ContraseniaHash = PasswordHasher.HashPassword(this, contrasenia);
        }

        public void SetRol(string rol)
        {
            if (string.IsNullOrWhiteSpace(rol))
                throw new ArgumentException("Rol inválido.");
            Rol = rol;
        }

        public void AddReserva(Reserva reserva)
        {
            ArgumentNullException.ThrowIfNull(reserva);
            _reservas.Add(reserva);
        }

    }
}
