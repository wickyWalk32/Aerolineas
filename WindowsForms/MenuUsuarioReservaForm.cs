using DTOs;
using System.Drawing.Printing;
using System.Net.Http.Json;

namespace WindowsForms
{
    public partial class MenuUsuarioReservaForm : Form
    {
        private readonly UsuarioLoginResultDTO _usuario;
        private ReservaDTO _reserva = default!;
        private readonly MenuUsuarioBuscarVueloForm _formAnterior;

        public MenuUsuarioReservaForm(MenuUsuarioBuscarVueloForm form, UsuarioLoginResultDTO usuario)
        {
            InitializeComponent();
            _formAnterior = form;
            _usuario = usuario;

            // Cargamos las reservas del usuario al abrir el formulario
            this.Load += async (_, _) => await CargarReservas(_usuario.Id);
        }

        private async Task CargarReservas(int usuarioId)
        {
            try
            {
                flowLayoutPanelReservas.Controls.Clear();

                var reservas = await Program.HttpClient
                    .GetFromJsonAsync<List<ReservaDTO>>($"/reservas/usuarios/{usuarioId}");

                if (reservas == null) return;

                foreach (ReservaDTO reserva in reservas)
                {
                    var reservaItemControl = new ReservaItemControl();
                    reservaItemControl.CargarDatos(reserva);
                    reservaItemControl.OnDetalleReserva += OnClickVerReserva;
                    flowLayoutPanelReservas.Controls.Add(reservaItemControl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al consultar reservas: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void OnClickVerReserva(object? sender, ReservaDTO reserva)
        {
            _reserva = reserva;
            panelReserva.Visible = true;
            flowLayoutPanelReservas.Visible = false;

            reservaItemControlEnPanel.CargarDatos(reserva);
            reservaItemControlEnPanel.EsconderBotonDetalles();
            labelFechaReserva.Text = reserva.FechaHoraReserva.ToString("dd/MM/yyyy HH:mm");

            // Sumamos el costo base del vuelo por pasajero más los servicios adicionales elegidos
            decimal precioVuelo = reserva.Vuelo?.Precio ?? 0m;
            int cantPasajes = reserva.Pasajes?.Count ?? 0;
            decimal totalPasajes = precioVuelo * cantPasajes;
            decimal totalServicios = reserva.Pasajes?
                .SelectMany(p => p.Servicios ?? new List<ServicioCargaDTO>())
                .Sum(s => s.Precio) ?? 0m;

            labelCostoTotal.Text = $"Total Estimado: $ {totalPasajes + totalServicios:N2}";

            // Limpiamos antes de cargar para evitar duplicados al cambiar de reserva
            flowLayoutPanelPasajes.Controls.Clear();

            if (reserva.Pasajes != null)
            {
                foreach (PasajeDTO pasaje in reserva.Pasajes)
                {
                    var pasajeControl = new PasajeItemControl();
                    pasajeControl.CargarDatos(pasaje);
                    flowLayoutPanelPasajes.Controls.Add(pasajeControl);
                }
            }
        }

        private void buttonVolver_Click(object? sender, EventArgs e)
        {
            panelReserva.Visible = false;
            flowLayoutPanelReservas.Visible = true;
        }

        private void buttonImprimirReserva_Click(object? sender, EventArgs e)
        {
            if (_reserva == null) return;

            string nombreBase = $"Comprobante_Reserva_{_reserva.Id}";
            printDocumentReserva.DocumentName = nombreBase;

            // Sugerimos el nombre del archivo si el usuario elige guardar como PDF
            using var saveDialog = new SaveFileDialog
            {
                Filter = "Archivo PDF (*.pdf)|*.pdf",
                FileName = $"{nombreBase}.pdf",
                Title = "Guardar comprobante de reserva"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                printDocumentReserva.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                printDocumentReserva.PrinterSettings.PrintToFile = true;
                printDocumentReserva.PrinterSettings.PrintFileName = saveDialog.FileName;

                try
                {
                    if (!printDocumentReserva.PrinterSettings.IsValid)
                    {
                        MessageBox.Show(
                            "No se encontró la impresora 'Microsoft Print to PDF' en el sistema.",
                            "Impresora no disponible",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    printDocumentReserva.Print();
                    MessageBox.Show(
                        $"Comprobante guardado en:\n{saveDialog.FileName}",
                        "Exportación completada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"No se pudo generar el comprobante: {ex.Message}",
                        "Error al exportar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void printDocumentReserva_PrintPage(object? sender, PrintPageEventArgs e)
        {
            if (e.Graphics == null || _reserva == null) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            float left = 50;
            float right = e.MarginBounds.Right;
            float width = e.MarginBounds.Width;
            float y = 50;

            using var titulo = new Font("Arial", 20, FontStyle.Bold);
            using var subtitulo = new Font("Arial", 12, FontStyle.Bold);
            using var negrita = new Font("Arial", 10, FontStyle.Bold);
            using var texto = new Font("Arial", 10);
            using var pequeno = new Font("Arial", 8);

            using var negro = new SolidBrush(Color.FromArgb(35, 45, 60));
            using var gris = new SolidBrush(Color.FromArgb(100, 110, 125));
            using var azul = new SolidBrush(Color.FromArgb(35, 85, 140));
            using var fondo = new SolidBrush(Color.FromArgb(240, 244, 248));
            using var linea = new Pen(Color.FromArgb(210, 218, 228), 1);

            void DibujarLinea()
            {
                g.DrawLine(linea, left, y, right, y);
                y += 15;
            }

            void DibujarTexto(string label, string valor, Font? fuenteValor = null)
            {
                g.DrawString(label, texto, gris, left, y);
                g.DrawString(valor, fuenteValor ?? texto, negro, left + 130, y);
                y += 25;
            }

            // HEADER
            g.DrawString("RESERVAS AÉREAS", titulo, azul, left, y);
            y += 35;

            g.DrawString("COMPROBANTE DE RESERVA", subtitulo, negro, left, y);
            y += 30;

            DibujarLinea();

            // INFORMACION DE RESERVA
            g.DrawString("INFORMACIÓN DE RESERVA", subtitulo, azul, left, y);
            y += 30;

            DibujarTexto("Reserva N°:", _reserva.Id.ToString(), negrita);
            DibujarTexto("Fecha:", _reserva.FechaHoraReserva.ToString("dd/MM/yyyy HH:mm"));
            DibujarTexto("Pasajeros:", (_reserva.Pasajes?.Count ?? 0).ToString());

            y += 10;
            DibujarLinea();

            // INFORMACION DEL VUELO
            g.DrawString("INFORMACIÓN DEL VUELO", subtitulo, azul, left, y);
            y += 30;

            if (_reserva.Vuelo != null)
            {
                DibujarTexto("Aerolínea:", _reserva.Vuelo.Aerolinea);
                DibujarTexto("Vuelo N°:", _reserva.Vuelo.Id.ToString());
                DibujarTexto("Origen:", _reserva.Vuelo.CiudadOrigen?.Nombre ?? "No disponible", negrita);
                DibujarTexto("Destino:", _reserva.Vuelo.CiudadDestino?.Nombre ?? "No disponible", negrita);
                DibujarTexto("Salida:", _reserva.Vuelo.FechaHoraVuelo.ToString("dd/MM/yyyy HH:mm"));
                DibujarTexto("Precio por pasaje:", _reserva.Vuelo.Precio.ToString("C"));
            }

            y += 10;
            DibujarLinea();

            // PASAJEROS Y SERVICIOS
            g.DrawString("PASAJEROS Y SERVICIOS", subtitulo, azul, left, y);
            y += 30;

            decimal totalPasajes = 0m;
            decimal totalServicios = 0m;

            foreach (var pasaje in _reserva.Pasajes ?? new List<PasajeDTO>())
            {
                string nombreCompleto = pasaje.Pasajero != null
                    ? $"{pasaje.Pasajero.Nombre} {pasaje.Pasajero.Apellido}".Trim()
                    : "Pasajero";

                g.DrawString(nombreCompleto, negrita, negro, left, y);
                y += 22;

                g.DrawString($"Pasaje: {_reserva.Vuelo?.Precio.ToString("C") ?? "No disponible"}", texto, negro, left + 15, y);
                y += 22;

                totalPasajes += _reserva.Vuelo?.Precio ?? 0m;

                foreach (var servicio in pasaje.Servicios ?? new List<ServicioCargaDTO>())
                {
                    g.DrawString($"- {servicio.Nombre}", texto, gris, left + 15, y);
                    g.DrawString(servicio.Precio.ToString("C"), texto, negro, right - 100, y);
                    y += 20;
                    totalServicios += servicio.Precio;
                }

                y += 10;
            }

            DibujarLinea();

            // TOTAL
            decimal total = totalPasajes + totalServicios;

            g.FillRectangle(fondo, left, y, width, 55);
            g.DrawString("TOTAL PAGADO", subtitulo, negro, left + 15, y + 15);

            string totalTexto = total.ToString("C");
            SizeF totalSize = g.MeasureString(totalTexto, titulo);
            g.DrawString(totalTexto, titulo, azul, right - totalSize.Width - 15, y + 10);

            y += 75;

            // FOOTER
            g.DrawLine(linea, left, y, right, y);
            y += 15;

            g.DrawString("Gracias por elegirnos. ¡Buen viaje!", texto, gris, left, y);
            g.DrawString($"Comprobante de reserva N° {_reserva.Id}", pequeno, gris, left, y + 25);

            e.HasMorePages = false;
        }

        private void buttonVolverMenuPrincipal_Click(object? sender, EventArgs e)
        {
            this.Close();
            _formAnterior.Show();
        }

        private void reservaItemControlEnPanel_Load(object sender, EventArgs e)
        {

        }
    }
}

/*using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class MenuUsuarioReservaForm : Form
    {
        UsuarioLoginResultDTO _usuario;
        ReservaDTO _reserva;
        MenuUsuarioBuscarVueloForm _formAnterior;
        public MenuUsuarioReservaForm(MenuUsuarioBuscarVueloForm form, UsuarioLoginResultDTO usuario)
        {
            InitializeComponent();
            _formAnterior = form;
            _usuario = usuario;
            this.Load += async (sender, e) => await CargarReservas(_usuario.Id);
        }

        private async Task CargarReservas(int usuarioId)
        {
            try
            {
                var reservas = await Program.HttpClient.GetFromJsonAsync<List<ReservaDTO>>($"/reservas/usuarios/{_usuario.Id}");
                if (reservas != null)
                {
                    foreach (ReservaDTO reserva in reservas)
                    {
                        ReservaItemControl reservaItemControl = new ReservaItemControl();
                        reservaItemControl.CargarDatos(reserva);
                        reservaItemControl.OnDetalleReserva += OnClickVerReserva;
                        flowLayoutPanelReservas.Controls.Add(reservaItemControl);
                    }
                }
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show($"Error al consultar reservas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OnClickVerReserva(object sender, ReservaDTO reserva)
        {
            _reserva = reserva;
            panelReserva.Visible = true;
            flowLayoutPanelReservas.Visible = false;
            reservaItemControlEnPanel.CargarDatos(reserva);
            reservaItemControlEnPanel.EsconderBotonDetalles();
            labelFechaReserva.Text = reserva.FechaHoraReserva.ToString();

            decimal totalPasajes = reserva.Vuelo.Precio * reserva.Pasajes.Count();
            decimal totalServicios = reserva.Pasajes.SelectMany(p => p.Servicios).Sum(s => s.Precio);
            labelCostoTotal.Text = $"Total Estimado: $ {totalPasajes + totalServicios}";

            foreach (PasajeDTO pasaje in reserva.Pasajes)
            {
                PasajeItemControl pasajeControl = new PasajeItemControl();
                pasajeControl.CargarDatos(pasaje);
                flowLayoutPanelPasajes.Controls.Add(pasajeControl);
            }
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            panelReserva.Visible = false;
            flowLayoutPanelReservas.Visible = true;
        }


        private void printDocumentReserva_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            float left = 50;
            float right = e.MarginBounds.Right;
            float width = e.MarginBounds.Width;
            float y = 50;

            using Font titulo = new Font("Arial", 20, FontStyle.Bold);
            using Font subtitulo = new Font("Arial", 12, FontStyle.Bold);
            using Font negrita = new Font("Arial", 10, FontStyle.Bold);
            using Font texto = new Font("Arial", 10);
            using Font pequeno = new Font("Arial", 8);

            using Brush negro = new SolidBrush(Color.FromArgb(35, 45, 60));
            using Brush gris = new SolidBrush(Color.FromArgb(100, 110, 125));
            using Brush azul = new SolidBrush(Color.FromArgb(35, 85, 140));
            using Brush fondo = new SolidBrush(Color.FromArgb(240, 244, 248));
            using Pen linea = new Pen(Color.FromArgb(210, 218, 228), 1);

            void DibujarLinea()
            {
                g.DrawLine(linea, left, y, right, y);
                y += 15;
            }

            void DibujarTexto(string label, string valor, Font font = null)
            {
                g.DrawString(label, texto, gris, left, y);
                g.DrawString(valor, font ?? texto, negro, left + 130, y);
                y += 25;
            }

            // HEADER
            g.DrawString("RESERVAS AÉREAS", titulo, azul, left, y);
            y += 35;

            g.DrawString("COMPROBANTE DE RESERVA", subtitulo, negro, left, y);
            y += 30;

            DibujarLinea();

            // INFORMACION DE RESERVA
            g.DrawString("INFORMACIÓN DE RESERVA", subtitulo, azul, left, y);
            y += 30;

            DibujarTexto("Reserva N°:", _reserva.Id.ToString(), negrita);
            DibujarTexto("Fecha:", _reserva.FechaHoraReserva.ToString("dd/MM/yyyy HH:mm"));
            DibujarTexto("Pasajeros:", _reserva.Pasajes.Count.ToString());

            y += 10;
            DibujarLinea();

            // INFORMACION DE VUELO
            g.DrawString("INFORMACIÓN DEL VUELO", subtitulo, azul, left, y);
            y += 30;

            if (_reserva.Vuelo != null)
            {
                DibujarTexto("Aerolínea:", _reserva.Vuelo.Aerolinea);
                DibujarTexto("Vuelo N°:", _reserva.Vuelo.Id.ToString());

                DibujarTexto("Origen:",
                    _reserva.Vuelo.CiudadOrigen?.Nombre ?? "No disponible",
                    negrita);

                DibujarTexto("Destino:",
                    _reserva.Vuelo.CiudadDestino?.Nombre ?? "No disponible",
                    negrita);

                DibujarTexto("Salida:",
                    _reserva.Vuelo.FechaHoraVuelo.ToString("dd/MM/yyyy HH:mm"));

                DibujarTexto("Precio por pasaje:",
                    _reserva.Vuelo.Precio.ToString("C"));
            }

            y += 10;
            DibujarLinea();

            // PASAJEROS Y SERVICIOS
            g.DrawString("PASAJEROS Y SERVICIOS", subtitulo, azul, left, y);
            y += 30;

            decimal totalPasajes = 0;
            decimal totalServicios = 0;

            foreach (var pasaje in _reserva.Pasajes)
            {
                g.DrawString(pasaje.Pasajero?.Nombre ?? "Pasajero", negrita, negro, left, y);

                y += 22;

                g.DrawString($"Pasaje: {_reserva.Vuelo?.Precio.ToString("C") ?? "No disponible"}", texto, negro, left + 15, y);

                y += 22;

                totalPasajes += _reserva.Vuelo?.Precio ?? 0;

                foreach (var servicio in pasaje.Servicios)
                {
                    g.DrawString($"- {servicio.Nombre}", texto, gris, left + 15, y);
                    g.DrawString(servicio.Precio.ToString("C"), texto, negro, right - 100, y);
                    y += 20;
                    totalServicios += servicio.Precio;
                }

                y += 10;
            }

            DibujarLinea();

            // TOTAL
            decimal total = totalPasajes + totalServicios;

            g.FillRectangle(fondo, left, y, width, 55);

            g.DrawString("TOTAL PAGADO", subtitulo, negro, left + 15, y + 15);

            string totalTexto = total.ToString("C");
            SizeF totalSize = g.MeasureString(totalTexto, titulo);

            g.DrawString(totalTexto, titulo, azul, right - totalSize.Width - 15, y + 10);

            y += 75;

            // FOOTER
            g.DrawLine(linea, left, y, right, y);
            y += 15;

            g.DrawString("Gracias por elegirnos. ¡Buen viaje!", texto, gris, left, y);

            g.DrawString($"Comprobante de reserva N° {_reserva.Id}", pequeno, gris, left, y + 25);
        }


        private void buttonImprimirReserva_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDocumentReserva;
            preview.ShowDialog();
        }

        private void buttonVolverMenuPrincipal_Click(object sender, EventArgs e)
        {
            this.Close();
            _formAnterior.Show();
        }
    }
}*/
