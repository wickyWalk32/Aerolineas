using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{

    // DTO para lectura de la base de datos (trae el nombre del país incluido gracias a Include())
    public class CiudadDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string CodigoPostal { get; set; } = string.Empty;
        public string CodigoAeropuerto { get; set; } = string.Empty;
        public int PaisId { get; set; }
        public string PaisNombre { get; set; } = string.Empty;

    }
    
    // DTO para creación (lo que envía Windows Forms para guardar en la DB)
    public class CiudadCreateDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string CodigoPostal { get; set; } = string.Empty;
        public string CodigoAeropuerto { get; set; } = string.Empty;
        public int PaisId { get; set; }

    }

    // DTO para actualización (lo que envía Windows Forms para guardar en la DB)
    public class CiudadUpdateDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string CodigoPostal { get; set; } = string.Empty;
        public string CodigoAeropuerto { get; set; } = string.Empty;
        public int PaisId { get; set; }
    
    }
    
}
