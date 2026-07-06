using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;

namespace Domain.Model
{
    public class Usuario
    {
        private static readonly PasswordHasher<Usuario> PasswordHasher = new();
        public int Id { get; set; }
        public string Email { get; set; }
        public string ContraseniaHash { get; set; }


        private readonly List<Reserva> _reservas = new();
        public IReadOnlyCollection<Reserva> Reservas => _reservas.AsReadOnly();
        public Usuario()
        {
        }
        public Usuario( string email, string contrasenia) {
            SetEmail(email);
            SetContraseniaHash(contrasenia);
        }

        public void SetId(int id) {  Id = id; }
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
        public void AddReserva(Reserva reserva)
        {
            ArgumentNullException.ThrowIfNull(reserva);
            _reservas.Add(reserva);
        }

    }
}
