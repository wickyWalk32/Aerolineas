using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Pais
    {
        // Atributos de la clase Pais

        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        // Propiedad de navegación para EF Core
        public ICollection<Ciudad> Ciudades { get; set; } = new List<Ciudad>();

        // Constructores de la clase Pais

        public Pais()
        { 
        }

        // Métodos de la clase Pais

    }
}
