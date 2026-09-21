namespace DTOs
{

    // LOGIN: DTO para enviar las credenciales desde WinForms a la Web API
    public class UsuarioLoginRequestDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Contrasenia { get; set; } = string.Empty;
    }

    // LOGIN: DTO para responder el resultado de la autenticación
    public class UsuarioLoginResultDTO
    {   
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; } = string.Empty;

        // Propiedad agregada para recibir el Token JWT generado por la WebApi
        public string? Token { get; set; }
    }

    // DTO para lectura de la base de datos
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Contrasenia { get; set; } // Opcional para actualizar
        public string Rol { get; set; } = string.Empty;
    }

    public class UsuarioCreateDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public required string Email { get; set; }
        public required string Contrasenia { get; set; }
        public required string Rol { get; set; }
    }
    public class UsuarioUpdateDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Contrasenia { get; set; } // Opcional para actualizar
        public string Rol { get; set; } = string.Empty;
    }

}
