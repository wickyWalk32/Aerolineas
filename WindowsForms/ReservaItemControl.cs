using DTOs;

namespace WindowsForms
{
    public partial class ReservaItemControl : UserControl
    {
        public event EventHandler<ReservaDTO>? OnDetalleReserva;
        private ReservaDTO _reserva = default!;

        public ReservaItemControl()
        {
            InitializeComponent();
        }

        public void CargarDatos(ReservaDTO reserva)
        {
            _reserva = reserva;

            string origen = reserva.Vuelo?.CiudadOrigen?.Nombre ?? "Origen";
            string destino = reserva.Vuelo?.CiudadDestino?.Nombre ?? "Destino";
            labelOrigenDestino.Text = $"{origen} - {destino}";

            if (reserva.Vuelo != null)
            {
                labelFechaHora.Text = $"{reserva.Vuelo.FechaHoraVuelo:dd/MM/yyyy}   {reserva.Vuelo.FechaHoraVuelo:HH:mm}";

                // Calculamos el costo total real: (precio vuelo * cant. pasajes) + servicios de cada pasaje
                decimal totalVuelos = reserva.Vuelo.Precio * (reserva.Pasajes?.Count ?? 0);
                decimal totalServicios = reserva.Pasajes?
                    .SelectMany(p => p.Servicios ?? new List<ServicioCargaDTO>())
                    .Sum(s => s.Precio) ?? 0m;

                labelCosto.Text = $"${totalVuelos + totalServicios:N2}";

                // Estado según si el vuelo todavía no salió o ya pasó (alineado con Blazor)
                labelEstado.Text = reserva.Vuelo.FechaHoraVuelo >= DateTime.Now
                    ? "Pendiente"
                    : "Finalizada";
            }
            else
            {
                labelFechaHora.Text = "-";
                labelCosto.Text = "$0,00";
                labelEstado.Text = "Pendiente";
            }
        }

        private void buttonVer_Click(object? sender, EventArgs e)
        {
            OnDetalleReserva?.Invoke(this, _reserva);
        }

        public void EsconderBotonDetalles()
        {
            buttonVer.Visible = false;
            this.BorderStyle = BorderStyle.None;
        }
    }
}

/*using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class ReservaItemControl : UserControl
    {
        public event EventHandler<ReservaDTO> OnDetalleReserva;
        ReservaDTO _reserva;
        public ReservaItemControl()
        {
            InitializeComponent();
        }

        public void CargarDatos(ReservaDTO reserva)
        {
            _reserva = reserva;
            labelOrigenDestino.Text = $"{reserva.Vuelo.CiudadOrigen.Nombre} - {reserva.Vuelo.CiudadDestino.Nombre}";
            labelFechaHora.Text = $"{reserva.Vuelo.FechaHoraVuelo:dd/MM/yyyy}   {reserva.Vuelo.FechaHoraVuelo:HH:mm}";
            labelCosto.Text = $"${reserva.Vuelo.Precio}";
            labelEstado.Text = "Pendiente";
        }
        private void buttonVer_Click(object sender, EventArgs e)
        {
            OnDetalleReserva?.Invoke(this, _reserva);
        }

        public void EsconderBotonDetalles()
        {
            buttonVer.Visible = false;
            this.BorderStyle = BorderStyle.None;
        }
    }
}*/
