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

                sb.AppendLine($"Pasajero #{i + 1}: {p.Nombre} {p.Apellido} | Tipo: {p.Tipo} | Doc: {p.TipoDocumento} {p.NroDocumento}");
                sb.AppendLine($"   Asiento: {p.CodigoAsiento}");
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

        /*private void btnDescargarPdf_Click(object? sender, EventArgs e)
        {
            string nroReserva = (_estado.ReservaConfirmada != null && _estado.ReservaConfirmada.Id > 0)
                ? _estado.ReservaConfirmada.Id.ToString()
                : "Confirmada";

            _textoReciboActual = ArmarTextoRecibo(nroReserva);

            using var printDoc = new PrintDocument();
            printDoc.DocumentName = $"Recibo_Reserva_{nroReserva}";
            printDoc.PrintPage += PrintDoc_PrintPage;

            using var printDialog = new PrintDialog
            {
                Document = printDoc,
                UseEXDialog = true
            };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    printDoc.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"No se pudo imprimir o exportar el recibo: {ex.Message}",
                        "Error al exportar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }*/

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

                sb.AppendLine($"Pasajero #{i + 1}: {p.Nombre} {p.Apellido} ({p.Tipo})");
                sb.AppendLine($"  Doc: {p.TipoDocumento} {p.NroDocumento} | Asiento: {p.CodigoAsiento}");
                sb.AppendLine($"  Servicios: {textoServs}");
            }

            sb.AppendLine("------------------------------------------------------------");
            sb.AppendLine($"TOTAL ABONADO: $ {_totalAbonado:N2}");
            return sb.ToString();
        }

        private void btnVolverBuscador_Click(object? sender, EventArgs e)
        {
            var formBuscador = new MenuUsuarioBuscarVueloForm(_estado.Usuario);
            formBuscador.Show();
            this.Close();
        }
    }
}

/*using DTOs;
using System.IO;
using System.Text;

namespace WindowsForms
{
    public partial class DetalleReservaForm : Form
    {
        private readonly ReservaProcesoState _estado;
        private readonly List<ServicioCargaDTO> _serviciosDisponibles;
        private readonly decimal _totalAbonado;

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

                sb.AppendLine($"Pasajero #{i + 1}: {p.Nombre} {p.Apellido} | Tipo: {p.Tipo} | Doc: {p.TipoDocumento} {p.NroDocumento}");
                sb.AppendLine($"   Asiento: {p.CodigoAsiento}");
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

            using var dialog = new SaveFileDialog
            {
                Filter = "Archivo PDF (*.pdf)|*.pdf",
                FileName = $"Recibo_Reserva_{nroReserva}.pdf",
                Title = "Guardar recibo de reserva"
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                string textoRecibo = ArmarTextoRecibo(nroReserva);
                byte[] pdfBytes = CrearPdfSimpleDesdeTexto(textoRecibo);
                File.WriteAllBytes(dialog.FileName, pdfBytes);

                MessageBox.Show(
                    "Recibo en PDF guardado correctamente.",
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

                sb.AppendLine($"Pasajero #{i + 1}: {p.Nombre} {p.Apellido} ({p.Tipo})");
                sb.AppendLine($"  Doc: {p.TipoDocumento} {p.NroDocumento} | Asiento: {p.CodigoAsiento}");
                sb.AppendLine($"  Servicios: {textoServs}");
            }

            sb.AppendLine("------------------------------------------------------------");
            sb.AppendLine($"TOTAL ABONADO: $ {_totalAbonado:N2}");
            return sb.ToString();
        }

        private static byte[] CrearPdfSimpleDesdeTexto(string texto)
        {
            string limpiarAscii(string s)
            {
                if (string.IsNullOrEmpty(s)) return string.Empty;
                string normalizado = s.Normalize(NormalizationForm.FormD);
                var sb = new StringBuilder(normalizado.Length);
                foreach (char c in normalizado)
                {
                    var cat = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);
                    if (cat != System.Globalization.UnicodeCategory.NonSpacingMark && c <= 127)
                    {
                        sb.Append(c);
                    }
                }
                return sb.ToString();
            }

            string escaparPdf(string s) =>
                limpiarAscii(s)
                    .Replace("\\", "\\\\")
                    .Replace("(", "\\(")
                    .Replace(")", "\\)");

            var lineas = texto.Replace("\r\n", "\n").Split('\n');
            var stream = new StringBuilder();
            stream.Append("BT\n/F1 11 Tf\n45 780 Td\n15 TL\n");

            foreach (var linea in lineas)
            {
                stream.Append($"({escaparPdf(linea)}) Tj\nT*\n");
            }

            stream.Append("ET\n");
            byte[] streamBytes = Encoding.ASCII.GetBytes(stream.ToString());

            string obj1 = "1 0 obj\n<< /Type /Catalog /Pages 2 0 R >>\nendobj\n";
            string obj2 = "2 0 obj\n<< /Type /Kids [3 0 R] /Count 1 >>\nendobj\n";
            string obj3 = "3 0 obj\n<< /Type /Page /Parent 2 0 R /MediaBox [0 0 595 842] /Resources << /Font << /F1 4 0 R >> >> /Contents 5 0 R >>\nendobj\n";
            string obj4 = "4 0 obj\n<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica >>\nendobj\n";
            string obj5Head = $"5 0 obj\n<< /Length {streamBytes.Length} >>\nstream\n";
            string obj5Tail = "endstream\nendobj\n";

            using var ms = new MemoryStream();
            void EscribirAscii(string s)
            {
                byte[] b = Encoding.ASCII.GetBytes(s);
                ms.Write(b, 0, b.Length);
            }

            EscribirAscii("%PDF-1.4\n");

            long off1 = ms.Position; EscribirAscii(obj1);
            long off2 = ms.Position; EscribirAscii(obj2);
            long off3 = ms.Position; EscribirAscii(obj3);
            long off4 = ms.Position; EscribirAscii(obj4);
            long off5 = ms.Position;
            EscribirAscii(obj5Head);
            ms.Write(streamBytes, 0, streamBytes.Length);
            EscribirAscii(obj5Tail);

            long xrefPos = ms.Position;
            var xref = new StringBuilder();
            xref.Append("xref\n0 6\n");
            xref.Append("0000000000 65535 f\n");
            xref.Append($"{off1:D10} 00000 n\n");
            xref.Append($"{off2:D10} 00000 n\n");
            xref.Append($"{off3:D10} 00000 n\n");
            xref.Append($"{off4:D10} 00000 n\n");
            xref.Append($"{off5:D10} 00000 n\n");
            xref.Append($"trailer\n<< /Size 6 /Root 1 0 R >>\nstartxref\n{xrefPos}\n%%EOF\n");

            EscribirAscii(xref.ToString());
            return ms.ToArray();
        }

        private void btnVolverBuscador_Click(object? sender, EventArgs e)
        {
            var formBuscador = new MenuUsuarioBuscarVueloForm(_estado.Usuario);
            formBuscador.Show();
            this.Close();
        }
    }
}
*/