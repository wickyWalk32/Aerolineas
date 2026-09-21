using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Pasaje
    {

        // <<< ATRIBUTOS >>>

        public int Id { get; private set; }
        public string Estado { get; private set; } = string.Empty;


        // <<< ATRIBUTOS DE NAVEGACIÓN DEL MODELO >>>

        // 1 Pasaje > 1 Pasajero
        public int IdPasajero { get; private set; }
        public Pasajero Pasajero { get; private set; } = null!;

        // 1 Pasaje > 1 Asiento
        public int IdAvion { get; private set; }
        public string CodigoAsiento { get; private set; }
        public Asiento Asiento { get; private set; } = null!;

        // 1 Pasaje > Muchos Servicios

        private readonly List<Servicio> _servicios = new();
        public IReadOnlyCollection<Servicio> Servicios => _servicios.AsReadOnly();


        // <<< CONSTRUCTORES >>>

        public Pasaje()
        {
        }

        public Pasaje(string estado, int idPasajero, Pasajero pasajero, int idAvion, string codigoAsiento, Asiento asiento)
        {
            this.SetEstado(estado);
            this.SetIdPasajero(idPasajero);
            this.SetPasajero(pasajero);
            this.SetIdAvionCodigoAsiento(idAvion, codigoAsiento);
            this.SetAsiento(asiento);
        }

        public Pasaje(int id, string estado, int idPasajero, Pasajero pasajero, int idAvion, string codigoAsiento, Asiento asiento)
        {
            this.SetId(id);
            this.SetEstado(estado);
            this.SetIdPasajero(idPasajero);
            this.SetPasajero(pasajero);
            this.SetIdAvionCodigoAsiento(idAvion, codigoAsiento);
            this.SetAsiento(asiento);
        }

        // <<< MÉTODOS: SETTERS >>>

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("Id de pasaje inválido.");
            this.Id = id;
        }

        public void SetEstado(string estado)
        {
            if (string.IsNullOrWhiteSpace(estado))
                throw new ArgumentException("Estado del pasaje es inválido.");
            this.Estado = estado;
        }

        public void SetIdPasajero(int idPasajero)
        {
            if (idPasajero < 0)
                throw new ArgumentException("Id de pasajero del pasaje inválido.");
            this.IdPasajero = idPasajero;
        }

        public void SetPasajero(Pasajero pasajero)
        {
            if (pasajero == null)
                throw new ArgumentException("Pasajero del pasaje inválido.");
            this.Pasajero = pasajero;
        }

        public void SetIdAvionCodigoAsiento(int idAvion, string codigoAsiento)
        {
            if (idAvion < 0)
                throw new ArgumentException("Id de avion del pasaje inválido.");
            this.IdAvion = idAvion;
            
            if (string.IsNullOrWhiteSpace(codigoAsiento))
                throw new ArgumentException("Código de asiento del pasaje inválido.");
            this.CodigoAsiento = codigoAsiento;
        }

        public void SetAsiento(Asiento asiento)
        {
            if (asiento == null)
                throw new ArgumentException("Asiento de pasaje inválido.");
            this.Asiento = asiento;
        }

        public void AddServicio(Servicio servicio)
        {
            ArgumentNullException.ThrowIfNull(servicio);
            _servicios.Add(servicio);
        }

        public void RemoveServicio(Servicio servicio)
        {
            ArgumentNullException.ThrowIfNull(servicio);
            _servicios.Remove(servicio);
        }

        // <<< DEMÁS MÉTODOS >>>

    }
}
