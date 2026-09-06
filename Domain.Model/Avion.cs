using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Avion
    {
        public int Id { get; private set; }
        public string Descripcion { get; private set; }
        public int Capacidad { get; private set; }
        public string EstadoDisponibilidad { get; private set; }

        private List<Asiento> _asientos = new();

        public IReadOnlyCollection<Asiento> Asientos;

        public Avion()
        {

        }

        public Avion(string descripcion, int capacidad, string estado)
        {
            SetDescripcion(descripcion);
            SetCapacidad(capacidad);
            SetEstado(estado);
        }

        private void SetDescripcion(string descripcion) { 
            Descripcion = descripcion;
        }
        private void SetCapacidad(int capacidad)
        {
            Capacidad = capacidad;
        }
        private void SetEstado(string estado)
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
