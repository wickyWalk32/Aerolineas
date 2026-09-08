namespace DTOs
{

    // LOGIN: DTO para enviar las credenciales desde WinForms a la Web API
    public class LoginRequestDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Contrasenia { get; set; } = string.Empty;
    }

    // LOGIN: DTO para responder el resultado de la autenticación
    public class LoginResultDTO
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Rol { get; set; }
    }

    public class UsuarioCreateDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ContraseniaHash { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
    }
    public class UsuarioUpdateDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? ContraseniaHash { get; set; } // Opcional para actualizar
        public string Rol { get; set; } = string.Empty;
    }

    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? ContraseniaHash { get; set; } // Opcional para actualizar
        public string Rol { get; set; } = string.Empty;
    }

}
