using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Pais
    {

        // <<< ATRIBUTOS >>>

        public int Id { get; private set; }
        public string Nombre { get; private set; } = string.Empty;

        // <<< ATRIBUTOS DE NAVEGACIÓN DEL MODELO >>>

        // 1 Pais > Muchas Ciudades

        private readonly List<Ciudad> _ciudades = new(); // new List<Ciudad>() ?
        public IReadOnlyCollection<Ciudad> Ciudades => _ciudades.AsReadOnly();

        // <<< CONSTRUCTORES >>>

        public Pais()
        {
        }

        public Pais(string nombre)
        {
            this.SetNombre(nombre);
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

        public void AddCiudad(Ciudad ciudad)
        {
            ArgumentNullException.ThrowIfNull(ciudad);
            _ciudades.Add(ciudad);
        }

        public void RemoveCiudad(Ciudad ciudad)
        {
            ArgumentNullException.ThrowIfNull(ciudad);
            _ciudades.Remove(ciudad);
        }

        // <<< DEMÁS MÉTODOS >>>

    }
}
