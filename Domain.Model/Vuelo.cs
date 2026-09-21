using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Vuelo
    {

        // <<< ATRIBUTOS >>>

        public int Id { get; private set; }
        public DateTime FechaHoraVuelo { get; private set; }
        public string Aerolinea { get; private set; } = string.Empty;
        public decimal Precio { get; private set; }


        // <<< ATRIBUTOS DE NAVEGACIÓN >>>

        // 1 Vuelo > 1 Ciudad de origen

        public int IdCiudadOrigen { get; private set; }
        public Ciudad? CiudadOrigen { get; private set; }

        // 1 Vuelo > 1 Ciudad de destino

        public int IdCiudadDestino { get; private set; }
        public Ciudad? CiudadDestino { get; private set; }

        // 1 Vuelo > 1 Avion

        public int IdAvion { get; private set; }
        public Avion? Avion { get; private set; }
        
        // 1 Vuelo > Muchas Reservas

        private readonly List<Reserva> _reservas = new(); // new List<Reserva>() ?
        public IReadOnlyCollection<Reserva> Reservas => _reservas.AsReadOnly();


        // <<< CONSTRUCTORES >>>

        public Vuelo()
        {
        }

        public Vuelo(DateTime fechaHoraVuelo, string aerolinea, decimal precio, Ciudad ciudadOrigen, int idCiudadOrigen,
            Ciudad ciudadDestino, int idCiudadDestino, Avion avion, int idAvion)
        {
            this.SetFechaHoraVuelo(fechaHoraVuelo);
            this.SetAerolinea(aerolinea);
            this.SetPrecio(precio);
            this.SetIdCiudadOrigen(idCiudadOrigen);
            this.SetCiudadOrigen(ciudadOrigen);
            this.SetIdCiudadDestino(idCiudadDestino);
            this.SetCiudadDestino(ciudadDestino);
            this.SetIdAvion(idAvion);
            this.SetAvion(avion);
        }

        public Vuelo(int id, DateTime fechaHoraVuelo, string aerolinea, decimal precio, Ciudad ciudadOrigen, int idCiudadOrigen,
            Ciudad ciudadDestino, int idCiudadDestino, Avion avion, int idAvion)
        {
            this.SetId(id);
            this.SetFechaHoraVuelo(fechaHoraVuelo);
            this.SetAerolinea(aerolinea);
            this.SetPrecio(precio);
            this.SetIdCiudadOrigen(idCiudadOrigen);
            this.SetCiudadOrigen(ciudadOrigen);
            this.SetIdCiudadDestino(idCiudadDestino);
            this.SetCiudadDestino(ciudadDestino);
            this.SetIdAvion(idAvion);
            this.SetAvion(avion);
        }

        // <<< MÉTODOS: SETTERS >>>

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("Id de vuelo inválido.");
            this.Id = id;
        }

        public void SetFechaHoraVuelo(DateTime fechaHoraVuelo)
        {
            // 1. Validar que no sea en el pasado o el momento exacto actual
            if (fechaHoraVuelo <= DateTime.Now)
            {
                throw new ArgumentException("La fecha y hora del vuelo debe ser posterior al momento actual.");
            }

            // 2. Validar que no supere el año de anticipación
            if (fechaHoraVuelo > DateTime.Now.AddYears(1))
            {
                throw new ArgumentException("La fecha y hora del vuelo no puede programarse a más de un año de distancia.");
            }

            this.FechaHoraVuelo = fechaHoraVuelo;
        }

        public void SetAerolinea(string aerolinea)
        {
            if (string.IsNullOrWhiteSpace(aerolinea))
                throw new ArgumentException("Aerolínea para vuelo es inválida.");
            this.Aerolinea = aerolinea;
        }

        public void SetPrecio(decimal precio)
        {
            if (precio < 0)
                throw new ArgumentException("Precio de vuelo inválido.");
            this.Precio = precio;
        }

        public void SetIdCiudadOrigen(int idCiudadOrigen)
        {
            if (idCiudadOrigen < 0)
                throw new ArgumentException("Id de ciudad de origen del vuelo inválido.");
            this.IdCiudadOrigen = idCiudadOrigen;
        }
        
        public void SetCiudadOrigen(Ciudad ciudadOrigen)
        {
            if (ciudadOrigen == null)
                throw new ArgumentException("Ciudad de origen del vuelo inválida.");
            this.CiudadOrigen = ciudadOrigen;
        }

        public void SetIdCiudadDestino(int idCiudadDestino)
        {
            if (idCiudadDestino < 0)
                throw new ArgumentException("Id de ciudad de destino del vuelo inválido.");
            this.IdCiudadDestino = idCiudadDestino;
        }

        public void SetCiudadDestino(Ciudad ciudadDestino)
        {
            if (ciudadDestino == null)
                throw new ArgumentException("Ciudad de destino del vuelo inválida.");
            this.CiudadDestino = ciudadDestino;
        }

        public void SetIdAvion(int idAvion)
        {
            if (idAvion < 0)
                throw new ArgumentException("Id del avion del vuelo es inválido.");
            this.IdAvion = idAvion;
        }

        public void SetAvion(Avion avion)
        {
            if (avion == null)
                throw new ArgumentException("Avion del vuelo es inválido.");
            this.Avion = avion;
        }

        public void AddReserva(Reserva reserva)
        {
            ArgumentNullException.ThrowIfNull(reserva);
            _reservas.Add(reserva);
        }

        public void RemoveReserva(Reserva reserva)
        {
            ArgumentNullException.ThrowIfNull(reserva);
            _reservas.Remove(reserva);
        }

        // <<< DEMÁS MÉTODOS >>>

    }
}
