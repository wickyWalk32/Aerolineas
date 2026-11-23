using DTOs;
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
}
