using DTOs;

namespace Blazor.Server.Services
{
    public class PasajeroReservaItem
    {
        public AsientoDTO Asiento { get; set; } = new();
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string TipoDocumento { get; set; } = "DNI";
        public string NroDocumento { get; set; } = string.Empty;
        public string Tipo { get; set; } = "Mayor";
        public List<int> ServicioIdsSeleccionados { get; set; } = new();
    }

    public class DatosPagoSimulado
    {
        public string Titular { get; set; } = string.Empty;
        public string NumeroTarjeta { get; set; } = string.Empty;
        public string Vencimiento { get; set; } = string.Empty;
        public string CodigoSeguridad { get; set; } = string.Empty;
        public string TipoTarjeta { get; set; } = "Crédito";

        public string Ultimos4Digitos
        {
            get
            {
                var limpios = new string((NumeroTarjeta ?? string.Empty).Where(char.IsDigit).ToArray());
                return limpios.Length >= 4 ? limpios[^4..] : "0000";
            }
        }
    }

    public class ReservaStateService
    {
        public VueloDTO? VueloSeleccionado { get; set; }
        public int CantidadPasajeros { get; set; } = 1;
        public List<AsientoDTO> AsientosSeleccionados { get; set; } = new();
        public List<PasajeroReservaItem> Pasajeros { get; set; } = new();
        public DatosPagoSimulado Pago { get; set; } = new();

        // Snapshot de la reserva confirmada para mostrar en DetalleReserva y descargar comprobante
        public VueloDTO? VueloConfirmado { get; set; }
        public List<PasajeroReservaItem> PasajerosConfirmados { get; set; } = new();
        public List<ServicioCargaDTO> ServiciosCatalogo { get; set; } = new();
        public DatosPagoSimulado? PagoConfirmado { get; set; }
        public decimal TotalConfirmado { get; set; }
        public DateTime? FechaConfirmacion { get; set; }
        public int? ReservaIdCreada { get; set; }

        public void IniciarReserva(VueloDTO vuelo, int cantidadPasajeros)
        {
            VueloSeleccionado = vuelo;
            CantidadPasajeros = cantidadPasajeros;
            AsientosSeleccionados.Clear();
            Pasajeros.Clear();
            Pago = new DatosPagoSimulado();
        }

        public void PrepararPasajerosDesdeAsientos()
        {
            Pasajeros.Clear();
            foreach (var asiento in AsientosSeleccionados)
            {
                Pasajeros.Add(new PasajeroReservaItem
                {
                    Asiento = asiento,
                    TipoDocumento = "DNI",
                    Tipo = "Mayor"
                });
            }
        }

        public decimal CalcularTotalParcial(IEnumerable<ServicioCargaDTO> serviciosDisponibles)
        {
            decimal precioVuelo = VueloSeleccionado?.Precio ?? 0m;
            decimal total = precioVuelo * Pasajeros.Count;

            var diccionarioServicios = serviciosDisponibles.ToDictionary(s => s.Id, s => s.Precio);

            foreach (var pasajero in Pasajeros)
            {
                foreach (var servicioId in pasajero.ServicioIdsSeleccionados)
                {
                    if (diccionarioServicios.TryGetValue(servicioId, out decimal precioServicio))
                    {
                        total += precioServicio;
                    }
                }
            }

            return total;
        }

        public void RegistrarConfirmacion(int? reservaId, IEnumerable<ServicioCargaDTO> serviciosDisponibles)
        {
            var listaServicios = serviciosDisponibles.ToList();
            ServiciosCatalogo = listaServicios;
            VueloConfirmado = VueloSeleccionado;
            PasajerosConfirmados = Pasajeros.Select(p => new PasajeroReservaItem
            {
                Asiento = p.Asiento,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                TipoDocumento = p.TipoDocumento,
                NroDocumento = p.NroDocumento,
                Tipo = p.Tipo,
                ServicioIdsSeleccionados = p.ServicioIdsSeleccionados.ToList()
            }).ToList();

            PagoConfirmado = new DatosPagoSimulado
            {
                Titular = Pago.Titular,
                NumeroTarjeta = Pago.NumeroTarjeta,
                Vencimiento = Pago.Vencimiento,
                CodigoSeguridad = Pago.CodigoSeguridad,
                TipoTarjeta = Pago.TipoTarjeta
            };

            TotalConfirmado = CalcularTotalParcial(listaServicios);
            FechaConfirmacion = DateTime.Now;
            ReservaIdCreada = reservaId;
        }

        public void LimpiarBorrador()
        {
            VueloSeleccionado = null;
            CantidadPasajeros = 1;
            AsientosSeleccionados.Clear();
            Pasajeros.Clear();
            Pago = new DatosPagoSimulado();
        }
    }
}