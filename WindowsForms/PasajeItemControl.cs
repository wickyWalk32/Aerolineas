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
    public partial class PasajeItemControl : UserControl
    {
        public PasajeItemControl()
        {
            InitializeComponent();
        }

        public void CargarDatos(PasajeDTO pasaje)
        {
            labelNombreYTipo.Text = $"{pasaje.Pasajero.Nombre}  {pasaje.Pasajero.Apellido}  ({pasaje.Pasajero.Tipo})";
            labelDNI.Text = $"{pasaje.Pasajero.TipoDocumento}  {pasaje.Pasajero.NroDocumento}";
            labelServicios.Text = string.Join(", ", pasaje.Servicios.Select(s => $"{s.Nombre} (+${s.Precio})"));
            labelAsiento.Text = $"Asiento: #{pasaje.CodigoAsiento.ToString()}";
        }
    }
}
