using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CiudadDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CodigoPostal { get; set; }
        public string CodigoAeropuerto { get; set; }
        public int PaisId { get; set; }

    }

    public class CiudadCreateDTO
    {
        public string Nombre { get; set; }
        public string CodigoPostal { get; set; }
        public string CodigoAeropuerto { get; set; }
        public int PaisId { get; set; }

    }

    public class CiudadUpdateDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CodigoPostal { get; set; }
        public string CodigoAeropuerto { get; set; }
        public int PaisId { get; set; }

    }
}
