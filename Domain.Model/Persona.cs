using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public abstract class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }

        public Persona(string nombre, string apellido, string tipoDocumento, string nroDocumento)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.TipoDocumento = tipoDocumento;
            this.NroDocumento = nroDocumento;
        }
}
}
