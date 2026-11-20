using System;
using System.Collections.Generic;

namespace DTOs
{
    public class PaisDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public List<CiudadDTO>? Ciudades { get; set; }
    }

    public class PaisCreateDTO
    {
        public string Nombre { get; set; } = string.Empty;
    }

    public class PaisUpdateDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}