using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Model
{
    public class Ciudad
    {
        
        // <<< ATRIBUTOS >>>

        public int Id { get; private set;}
        public string Nombre { get; private set; } = string.Empty;
        public string CodigoPostal { get; private set; } = string.Empty;
        public string CodigoAeropuerto { get; private set; } = string.Empty;

        // <<< ATRIBUTOS DE NAVEGACIÓN DEL MODELO >>>

        // 1 Ciudad > 1 Pais

        public int PaisId { get; private set; }         // Clave foránea
        public Pais Pais { get; private set; }          // Propiedad de navegación

        // 1 Ciudad > Muchos vuelos (siendo ciudad de origen)  >>>  * ciudado con el tema CiudadOrigen y CiudadDestino de un vuelo:

        private readonly List<Vuelo> _vuelosOrigen = new();
        public IReadOnlyCollection<Vuelo> VuelosOrigen => _vuelosOrigen.AsReadOnly();

        // 1 Ciudad > Muchos vuelos (siendo ciudad de destino)

        private readonly List<Vuelo> _vuelosDestino = new();
        public IReadOnlyCollection<Vuelo> VuelosDestino => _vuelosDestino.AsReadOnly();

        // <<< CONSTRUCTORES >>>

        public Ciudad()
        {
        }

        public Ciudad(string nombre, string codigoPostal, string codigoAeropuerto, int paisId)
        {
            this.SetNombre(nombre);
            this.SetCodigoPostal(codigoPostal);
            this.SetCodigoAeropuerto(codigoAeropuerto);
            this.SetPaisId(paisId);
        }

        public Ciudad(int id, string nombre, string codigoPostal, string codigoAeropuerto, int paisId)
        {
            this.SetId(id);
            this.SetNombre(nombre);
            this.SetCodigoPostal(codigoPostal);
            this.SetCodigoAeropuerto(codigoAeropuerto);
            this.SetPaisId(paisId);
        }

        // <<< MÉTODOS: SETTERS >>>

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("Id de ciudad inválido.");
            this.Id = id;
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("Nombre de ciudad inválido.");
            this.Nombre = nombre;
        }

        public void SetCodigoPostal(string codigoPostal)
        {
            if (string.IsNullOrWhiteSpace(codigoPostal))
                throw new ArgumentException("Código postal es inválido.");
            this.CodigoPostal = codigoPostal;
        }

        public void SetCodigoAeropuerto(string codigoAeropuerto)
        {
            if (string.IsNullOrWhiteSpace(codigoAeropuerto))
                throw new ArgumentException("Código de aeropuerto inválido.");
            this.CodigoAeropuerto = codigoAeropuerto;
        }

        public void SetPaisId(int paisId)
        {
            if (paisId < 0)
                throw new ArgumentException("Id de pais de la ciudad es inválido.");
            this.PaisId = paisId;
        }

        public void SetPais(Pais pais)
        {
            if (pais == null)
                throw new ArgumentException("Pais de la ciudad es inválido.");
            this.Pais = pais;
        }

        public void AddVueloOrigen(Vuelo vueloOrigen)
        {
            ArgumentNullException.ThrowIfNull(vueloOrigen);
            _vuelosOrigen.Add(vueloOrigen);
        }

        public void RemoveVueloOrigen(Vuelo vueloOrigen)
        {
            ArgumentNullException.ThrowIfNull(vueloOrigen);
            _vuelosOrigen.Remove(vueloOrigen);
        }

        // <<< DEMÁS MÉTODOS >>>

    }
}
