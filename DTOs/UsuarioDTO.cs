namespace DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string ContraseniaHash { get; set; }
    }

    public class UsuarioCreateDTO
    {
        public string Email { get; set; }
        public string ContraseniaHash { get; set; }
    }
    public class UsuarioUpdateDTO
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? ContraseniaHash { get; set; } // Opcional para actualizar
    }
}
