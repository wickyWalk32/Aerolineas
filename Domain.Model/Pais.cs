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

        public Pais(int id, string nombre)
        {
            this.SetId(id);
            this.SetNombre(nombre);
        }

        // <<< MÉTODOS: SETTERS >>>

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("Id de país inválido.");
            this.Id = id;
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("Nombre de país inválido.");
            this.Nombre = nombre;
        }

    }
}
