using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Avion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Capacidad { get; set; }
        public string EstadoDisponibilidad { get; set; }

        private readonly List<Asiento> _asientos = new();

        public IReadOnlyCollection<Asiento> Asientos => _asientos.AsReadOnly();

        public Avion()
        {

        }

        public Avion(string descripcion, int capacidad, string estado)
        {
            SetDescripcion(descripcion);
            SetCapacidad(capacidad);
            SetEstado(estado);
        }

        public void SetDescripcion(string descripcion) { 
            Descripcion = descripcion;
        }
        public void SetCapacidad(int capacidad)
        {
            Capacidad = capacidad;
        }
        public void SetEstado(string estado)
        {
            EstadoDisponibilidad = estado;
        }

        public void AgregarAsiento(Asiento asiento)
        {
            _asientos.Add(asiento);
        }

        public void RemoverAsiento(Asiento asiento)
        {
            _asientos.Remove(asiento);
        }

    }
}
