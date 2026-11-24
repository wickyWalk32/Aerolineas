using DTOs;

namespace WindowsForms
{
    public class ReservaProcesoState
    {
        public UsuarioLoginResultDTO Usuario { get; set; } = default!;
        public VueloDTO Vuelo { get; set; } = default!;
        public int CantidadPasajeros { get; set; }

        // Cada pasajero tiene Nombre, Apellido, Tipo, NroDocumento, TipoDocumento y CodigoAsiento (ej: "1A")
        public List<PasajeroCreateDTO> Pasajeros { get; set; } = new();

        // Guarda para cada pasajero (por su índice 0, 1, 2...) la lista de IDs de servicios elegidos
        public Dictionary<int, List<int>> ServiciosPorPasajero { get; set; } = new();

        // Datos de tarjeta cargados en el paso de pago
        public string UltimosCuatroDigitos { get; set; } = string.Empty;
        public DateTime FechaVencimientoTarjeta { get; set; } = DateTime.UtcNow.AddYears(1);

        // Resultado final devuelto por la API al confirmar la reserva
        public ReservaDTO? ReservaConfirmada { get; set; }

        public void Resetear()
        {
            CantidadPasajeros = 0;
            Pasajeros.Clear();
            ServiciosPorPasajero.Clear();
            UltimosCuatroDigitos = string.Empty;
            FechaVencimientoTarjeta = DateTime.UtcNow.AddYears(1);
            ReservaConfirmada = null;
        }
    }
}