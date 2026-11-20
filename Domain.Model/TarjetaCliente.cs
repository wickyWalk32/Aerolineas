using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Model
{
    public class TarjetaCliente
    {

        // <<< ATRIBUTOS >>>

        public int Id { get; private set; }
        public string UltimosCuatroDigitos { get; private set; } = string.Empty;
        // Mes y año de expiración (se puede guardar como DateTime fijando el primer día del mes o como un string "MM/yy").
        public DateTime FechaVencimiento { get; private set; }

        // <<< ATRIBUTOS DE NAVEGACIÓN DEL MODELO >>>

        // 1 TarjetaCliente > Muchas Reservas

        private readonly List<Reserva> _reservas = new();
        public IReadOnlyCollection<Reserva> Reservas => _reservas.AsReadOnly();

        // <<< CONSTRUCTORES >>>

        public TarjetaCliente()
        {
        }

        public TarjetaCliente(string ultimosCuatroDigitos, DateTime fechaVencimiento)
        {
            this.SetUltimosCuatroDigitos(ultimosCuatroDigitos);
            this.SetFechaVencimiento(fechaVencimiento);
        }

        public TarjetaCliente(int id, string ultimosCuatroDigitos, DateTime fechaVencimiento)
        {
            this.SetId(id);
            this.SetUltimosCuatroDigitos(ultimosCuatroDigitos);
            this.SetFechaVencimiento(fechaVencimiento);
        }

        // <<< MÉTODOS: SETTERS >>>

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("Id de tarjeta de cliente inválido.");
            this.Id = id;
        }

        public void SetUltimosCuatroDigitos(string ultimosCuatroDigitos)
        {
            if (string.IsNullOrWhiteSpace(ultimosCuatroDigitos))
                throw new ArgumentException("Últimos cuatro dígitos inválidos.");
            
            if (ultimosCuatroDigitos.Length > 4)
                throw new ArgumentException("Cantidad de dígitos debe ser 4.");

            this.UltimosCuatroDigitos = ultimosCuatroDigitos;
        }

        public void SetFechaVencimiento(DateTime fechaVencimiento)
        {
            this.FechaVencimiento = fechaVencimiento;
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
