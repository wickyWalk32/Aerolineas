using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    // Autoregistro
    public class UsuarioRegistroDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Contrasenia { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
    }

    // LOGIN: DTO para enviar las credenciales desde WinForms a la Web API
    public class UsuarioLoginRequestDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Contrasenia { get; set; } = string.Empty;

    }

    // LOGIN: DTO para responder el resultado de la autenticación
    public class UsuarioLoginResultDTO  // AuthResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public bool Exitoso { get; set; }

        // Propiedad agregada para recibir el Token JWT generado por la WebApi
        public string? Token { get; set; }
        public string Mensaje { get; set; } = string.Empty;

    }

    // Se usa en LoginEndpoints. DTO para que el JwtTokenService pueda generar los claims.
    public class UsuarioLoginDTO
    {
        public string Id { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;

    }

}
