using DTOs;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;

namespace WindowsForms
{
    public partial class DetalleReservaForm : Form
    {
        private readonly ReservaProcesoState _estado;
        private readonly List<ServicioCargaDTO> _serviciosDisponibles;
        private readonly decimal _totalAbonado;
        private string _textoReciboActual = string.Empty;

        public DetalleReservaForm(
            ReservaProcesoState estado,
            List<ServicioCargaDTO> serviciosDisponibles,
            decimal totalAbonado)
        {
            InitializeComponent();
            _estado = estado;
            _serviciosDisponibles = serviciosDisponibles ?? new List<ServicioCargaDTO>();
            _totalAbonado = totalAbonado;

            if (_estado.ReservaConfirmada != null && _estado.ReservaConfirmada.Id > 0)
            {
                lblSubtitulo.Text = $"Reserva N° {_estado.ReservaConfirmada.Id} registrada con éxito.";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"Titular de cuenta: {_estado.Usuario?.Nombre} {_estado.Usuario?.Apellido}");
            sb.AppendLine($"Vuelo: {_estado.Vuelo?.CiudadOrigen?.Nombre} → {_estado.Vuelo?.CiudadDestino?.Nombre}");
            sb.AppendLine($"Aerolínea: {_estado.Vuelo?.Aerolinea}");
            sb.AppendLine($"Fecha y hora del vuelo: {_estado.Vuelo?.FechaHoraVuelo:dd/MM/yyyy HH:mm}");
            sb.AppendLine($"Tarjeta utilizada: **** {_estado.UltimosCuatroDigitos}");
            sb.AppendLine(new string('-', 65));
            sb.AppendLine("PASAJEROS, ASIENTOS Y SERVICIOS:");
            sb.AppendLine();

            for (int i = 0; i < _estado.Pasajeros.Count; i++)
            {
                var p = _estado.Pasajeros[i];
                _estado.ServiciosPorPasajero.TryGetValue(i, out var idsSrv);
                idsSrv ??= new List<int>();

                var servs = _serviciosDisponibles.Where(s => idsSrv.Contains(s.Id)).ToList();
                string textoServs = servs.Count > 0
                    ? string.Join(", ", servs.Select(s => $"{s.Nombre} ($ {s.Precio:N2})"))
                    : "Sin servicios adicionales";

                string etiquetaAsiento = FormatearEtiquetaAsiento(p.CodigoAsiento);

                sb.AppendLine($"Pasajero #{i + 1}: {p.Nombre} {p.Apellido} | Tipo: {p.Tipo} | Doc: {p.TipoDocumento} {p.NroDocumento}");
                sb.AppendLine($"   Asiento: {etiquetaAsiento}");
                sb.AppendLine($"   Servicios: {textoServs}");
                sb.AppendLine();
            }

            richTextBoxResumenFinal.Text = sb.ToString();
            lblTotalFinal.Text = $"Total abonado: $ {_totalAbonado:N2}";
        }

        private void btnDescargarPdf_Click(object? sender, EventArgs e)
        {
            string nroReserva = (_estado.ReservaConfirmada != null && _estado.ReservaConfirmada.Id > 0)
                ? _estado.ReservaConfirmada.Id.ToString()
                : "Confirmada";

            using var saveDialog = new SaveFileDialog
            {
                Filter = "Archivo PDF (*.pdf)|*.pdf",
                FileName = $"Recibo_Reserva_{nroReserva}.pdf",
                Title = "Guardar recibo de reserva"
            };

            if (saveDialog.ShowDialog() != DialogResult.OK)
                return;

            _textoReciboActual = ArmarTextoRecibo(nroReserva);

            using var printDoc = new PrintDocument();
            printDoc.DocumentName = $"Recibo_Reserva_{nroReserva}";
            printDoc.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            printDoc.PrinterSettings.PrintToFile = true;
            printDoc.PrinterSettings.PrintFileName = saveDialog.FileName;
            printDoc.PrintPage += PrintDoc_PrintPage;

            try
            {
                if (!printDoc.PrinterSettings.IsValid)
                {
                    MessageBox.Show(
                        "No se encontró la impresora 'Microsoft Print to PDF' en el sistema.",
                        "Impresora no disponible",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                printDoc.Print();

                MessageBox.Show(
                    $"Recibo guardado en:\n{saveDialog.FileName}",
                    "Descarga completada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo generar el PDF: {ex.Message}",
                    "Error al exportar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void PrintDoc_PrintPage(object? sender, PrintPageEventArgs e)
        {
            using var fuente = new System.Drawing.Font("Consolas", 10F);
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;

            e.Graphics?.DrawString(
                _textoReciboActual,
                fuente,
                Brushes.Black,
                new RectangleF(x, y, e.MarginBounds.Width, e.MarginBounds.Height)
            );

            e.HasMorePages = false;
        }

        private string ArmarTextoRecibo(string nroReserva)
        {
            var sb = new StringBuilder();
            sb.AppendLine("AERORESERVAS.COM - RECIBO DE RESERVA");
            sb.AppendLine("------------------------------------------------------------");
            sb.AppendLine($"Nro. de Reserva: {nroReserva}");
            sb.AppendLine($"Fecha de emision: {DateTime.Now:dd/MM/yyyy HH:mm}");
            sb.AppendLine($"Titular: {_estado.Usuario?.Nombre} {_estado.Usuario?.Apellido}");
            sb.AppendLine($"Vuelo: {_estado.Vuelo?.CiudadOrigen?.Nombre} -> {_estado.Vuelo?.CiudadDestino?.Nombre}");
            sb.AppendLine($"Aerolinea: {_estado.Vuelo?.Aerolinea}");
            sb.AppendLine($"Fecha y hora vuelo: {_estado.Vuelo?.FechaHoraVuelo:dd/MM/yyyy HH:mm}");
            sb.AppendLine($"Tarjeta: **** {_estado.UltimosCuatroDigitos}");
            sb.AppendLine("------------------------------------------------------------");
            sb.AppendLine("PASAJEROS, ASIENTOS Y SERVICIOS:");
            sb.AppendLine();

            for (int i = 0; i < _estado.Pasajeros.Count; i++)
            {
                var p = _estado.Pasajeros[i];
                _estado.ServiciosPorPasajero.TryGetValue(i, out var idsSrv);
                idsSrv ??= new List<int>();

                var servs = _serviciosDisponibles.Where(s => idsSrv.Contains(s.Id)).ToList();
                string textoServs = servs.Count > 0
                    ? string.Join(", ", servs.Select(s => $"{s.Nombre} (${s.Precio:N2})"))
                    : "Sin servicios adicionales";

                string etiquetaAsiento = FormatearEtiquetaAsiento(p.CodigoAsiento);

                sb.AppendLine($"Pasajero #{i + 1}: {p.Nombre} {p.Apellido} ({p.Tipo})");
                sb.AppendLine($"  Doc: {p.TipoDocumento} {p.NroDocumento} | Asiento: {etiquetaAsiento}");
                sb.AppendLine($"  Servicios: {textoServs}");
            }

            sb.AppendLine("------------------------------------------------------------");
            sb.AppendLine($"TOTAL ABONADO: $ {_totalAbonado:N2}");
            return sb.ToString();
        }

        private static string FormatearEtiquetaAsiento(string? codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return "";

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

        private void btnVolverBuscador_Click(object? sender, EventArgs e)
        {
            var formBuscador = new MenuUsuarioBuscarVueloForm(_estado.Usuario);
            formBuscador.Show();
            this.Close();
        }
    }
}
