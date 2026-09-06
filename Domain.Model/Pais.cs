using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Pais
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        private List<Ciudad> _ciudades = new();
        public IReadOnlyCollection<Ciudad> Ciudades => _ciudades.AsReadOnly();
        public Pais()
        {

        }

        public Pais(string nombre)
        {
            SetNombre(nombre);
        }

        public void SetNombre(string nombre)
        {
            Nombre = Nombre;
        }
    }
}
