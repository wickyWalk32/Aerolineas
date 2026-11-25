using DTOs;

namespace WindowsForms
{
    public partial class PasajeItemControl : UserControl
    {
        public PasajeItemControl()
        {
            InitializeComponent();
        }

        public void CargarDatos(PasajeDTO pasaje)
        {
            if (pasaje == null) return;

            var pasajero = pasaje.Pasajero;
            string nombre = pasajero?.Nombre?.Trim() ?? "Pasajero";
            string apellido = pasajero?.Apellido?.Trim() ?? string.Empty;
            string tipo = pasajero?.Tipo ?? string.Empty;

            labelNombreYTipo.Text = string.IsNullOrWhiteSpace(tipo)
                ? $"{nombre} {apellido}".Trim()
                : $"{nombre} {apellido} ({tipo})".Trim();

            string tipoDoc = pasajero?.TipoDocumento ?? string.Empty;
            string nroDoc = pasajero?.NroDocumento ?? string.Empty;
            labelDNI.Text = $"{tipoDoc}  {nroDoc}".Trim();

            var servicios = pasaje.Servicios;
            if (servicios == null || servicios.Count == 0)
            {
                labelServicios.Text = "Servicios: Sin servicios adicionales";
            }
            else
            {
                string detalleServicios = string.Join(
                    ", ",
                    servicios.Select(s => $"{s.Nombre} (+$ {s.Precio:N2})")
                );
                labelServicios.Text = $"Servicios: {detalleServicios}";
            }

            labelAsiento.Text = $"Asiento: {FormatearEtiquetaAsiento(pasaje.CodigoAsiento)}";
        }

        private static string FormatearEtiquetaAsiento(string? codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return string.Empty;

            string limpio = codigo.Trim();
            if (int.TryParse(limpio, out int nro) && nro > 0)
            {
                int filaIdx = (nro - 1) / 4;
                int colNum = ((nro - 1) % 4) + 1;
                char filaLetra = (char)('A' + filaIdx);
                return $"{filaLetra}{colNum}";
            }

            return limpio;
        }
    }
}
