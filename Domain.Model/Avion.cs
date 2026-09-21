using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Avion
    {

        // <<< ATRIBUTOS >>>

        public int Id { get; private set; }
        public string Descripcion { get; private set; } = string.Empty;
        public int Capacidad { get; private set; }
        public string EstadoDisponibilidad { get; private set; }

        // <<< ATRIBUTOS DE NAVEGACION >>>

        // 1 Avion > Muchos Vuelos

        private readonly List<Vuelo> _vuelos = new();
        public IReadOnlyCollection<Vuelo> Vuelos => _vuelos.AsReadOnly();

        // 1 Avion > Muchos Asientos

        private readonly List<Asiento> _asientos = new();
        public IReadOnlyCollection<Asiento> Asientos => _asientos.AsReadOnly();

        // <<< CONSTRUCTORES >>>

        public Avion()
        {
        }

        public Avion(string descripcion, int capacidad, string estadoDisponibilidad)
        {
            this.SetDescripcion(descripcion);
            this.SetCapacidad(capacidad);
            this.SetEstadoDisponibilidad(estadoDisponibilidad);
        }

        public Avion(int id, string descripcion, int capacidad, string estadoDisponibilidad)
        {
            this.SetId(id);
            this.SetDescripcion(descripcion);
            this.SetCapacidad(capacidad);
            this.SetEstadoDisponibilidad(estadoDisponibilidad);
        }

        // <<< MÉTODOS: SETTERS >>>

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("Id de avión inválido.");
            this.Id = id;
        }

        public void SetDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("Descripción del avión inválida.");
            this.Descripcion = descripcion;
        }

        public void SetCapacidad(int capacidad)
        {
            if (capacidad < 0)
                throw new ArgumentException("Capacidad del avión debe ser mayor a cero.");
            if (capacidad > 1000)
                throw new ArgumentException("Capacidad del avión debe ser menor a 1000.");
            this.Capacidad = capacidad;
        }

        public void SetEstadoDisponibilidad(string estadoDisponibilidad) 
        {
            if (string.IsNullOrWhiteSpace(estadoDisponibilidad))
                throw new ArgumentException("Estado de disponibilidad del avión inválido.");
            this.EstadoDisponibilidad = estadoDisponibilidad;
        }

        public void AddVuelo(Vuelo vuelo)
        {
            ArgumentNullException.ThrowIfNull(vuelo);
            _vuelos.Add(vuelo);
        }

        public void RemoveVuelo(Vuelo vuelo)
        {
            ArgumentNullException.ThrowIfNull(vuelo);
            _vuelos.Remove(vuelo);
        }

        public void AddAsiento(Asiento asiento)
        {
            ArgumentNullException.ThrowIfNull(asiento);
            _asientos.Add(asiento);
        }

        public void RemoveAsiento(Asiento asiento)
        {
            ArgumentNullException.ThrowIfNull(asiento);
            _asientos.Remove(asiento);
        }

        // <<< DÉMÁS MÉTODOS >>>

    }
}
