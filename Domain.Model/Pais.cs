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

        private List<Ciudad> _ciudades = new();

        public IReadOnlyCollection<Ciudad> Ciudades => _ciudades.AsReadOnly();
        
        // Constructores de la clase Pais

        public Pais()
        {
        }

        public Pais(string nombre)
        {
            SetNombre(nombre);
        }

        // Métodos de la clase Pais

        public void SetNombre(string nombre)
        {
            Nombre = nombre;
        }

    }
}
