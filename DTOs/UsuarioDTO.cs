namespace DTOs
{

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

    public class UsuarioDeleteDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
    }
}
