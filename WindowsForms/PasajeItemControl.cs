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

            // Evitamos NullReferenceException si el objeto Pasajero viene nulo
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

            // Si no tiene servicios adicionales, lo indicamos explícitamente
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

            labelAsiento.Text = $"Asiento: {pasaje.CodigoAsiento}";
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
}*/
