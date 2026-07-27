using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Model
{
    public class Pasajero:Persona
    {
        public char Tipo { get; set; }

        private Pasaje _pasaje;

        public Pasaje Pasaje { get; set; }
        
        public Pasajero(string nombre, string apellido, string tipoDocumento, string nroDocumento) : base(nombre, apellido, tipoDocumento, nroDocumento)
        {

        }

        public Pasajero(string nombre,string apellido,string tipoDocumento,string nroDocumento, char tipo) : base(nombre, apellido, tipoDocumento, nroDocumento)
        {
            this.Tipo = tipo;
        }
    }
}
