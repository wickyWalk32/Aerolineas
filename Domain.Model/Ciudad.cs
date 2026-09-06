using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Ciudad
    {
        // Atributos de la clase Ciudad
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string CodigoAeropuerto { get; set; } = string.Empty;
        
        // Relacion / Clave foranea
        public int IdPais { get; set; }
        public Pais? Pais { get; set; }

        // Constructores de la clase Cuidad

        public Ciudad()
        { 
        }

        // Métodos de la clase Ciudad

    }
}
