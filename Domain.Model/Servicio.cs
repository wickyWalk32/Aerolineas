using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Servicio
    {

        // <<< ATRIBUTOS >>>

        public int Id { get; private set; }
        public string Nombre { get; private set; } = string.Empty;
        public string Descripción { get; private set; } = string.Empty;
        public decimal Precio { get; private set; }

        // <<< ATRIBUTOS DE NAVEGACIÓN DEL MODELO >>>

        // 1 Servicio > Muchos Pasajes

        private readonly List<Pasaje> _pasajes = new();
        public IReadOnlyCollection<Pasaje> Pasajes => _pasajes.AsReadOnly();

        // <<< CONSTRUCTORES >>>

        public Servicio()
        {
        }

        public Servicio(string nombre, string descripcion, decimal precio)
        {
            this.SetNombre(nombre);
            this.SetDescripcion(descripcion);
            this.SetPrecio(precio);
        }

        public Servicio(int id, string nombre, string descripcion, decimal precio)
        {
            this.SetId(id);
            this.SetNombre(nombre);
            this.SetDescripcion(descripcion);
            this.SetPrecio(precio);
        }

        // <<< MÉTODOS: SETTERS >>>

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("Id de servicio inválido.");
            this.Id = id;
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("Nombre de servicio inválido.");
            this.Nombre = nombre;
        }

        public void SetDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("Descripción de servicio inválida.");
            this.Descripción = descripcion;
        }

        public void SetPrecio(decimal precio)
        {
            if (precio < 0)
                throw new ArgumentException("Precio de servicio inválido.");
            this.Precio = precio;
        }

        public void AddPasaje(Pasaje pasaje)
        {
            ArgumentNullException.ThrowIfNull(pasaje);
            _pasajes.Add(pasaje);
        }

        public void RemovePasaje(Pasaje pasaje)
        {
            ArgumentNullException.ThrowIfNull(pasaje);
            _pasajes.Remove(pasaje);
        }

        // <<< DEMÁS MÉTODOS >>>

    }
}
