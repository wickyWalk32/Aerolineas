using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class PasajeroDTO
    {
        public int Id { get; set; }
        public char Tipo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }

    }

    public class PasajeroCreateDTO
    {
        public char Tipo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }

    }

    public class PasajeroUpdateDTO
    {
        public int Id { set; get; }
        public char Tipo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
    }
}
