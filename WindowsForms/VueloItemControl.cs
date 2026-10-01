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
    public partial class VueloItemControl : UserControl
    {

        // Eventos que escuchará el formulario padre (ServicioDetalleF.cs)
        public event EventHandler<VueloUpdateDTO>? OnEditarClicked;
        public event EventHandler<VueloDeleteDTO>? OnEliminarClicked;

        private VueloCargaDTO? _vueloActual;

        public VueloItemControl()
        {
            InitializeComponent();
        }

        // Método para cargar la información en este ítem visual
        public void CargarDatos(VueloCargaDTO vueloActual)
        {
            _vueloActual = vueloActual;

            lblId.Text = vueloActual.Id.ToString();
            lblFecha.Text = vueloActual.FechaHoraVuelo.ToString("dd/MM/yyyy");
            lblHora.Text = vueloActual.FechaHoraVuelo.ToString("HH:mm");
            lblAerolinea.Text = "Aerolínea: " + vueloActual.Aerolinea;
            lblPrecio.Text = "$ " + Convert.ToString(vueloActual.Precio);
            lblCiudadOrigen.Text = "Origen: " + vueloActual.CiudadOrigenNombre;
            lblCiudadDestino.Text = "Destino: " + vueloActual.CiudadDestinoNombre;
            lblAvionDescripcion.Text = "Avión: " + vueloActual.AvionDescripcion;
            lblAvionCapacidad.Text = "Capacidad: " + vueloActual.AvionCapacidad.ToString();

        }

        private void btnEditarVuelo_Click(object sender, EventArgs e)
        {
            if (_vueloActual != null)
            {

                VueloUpdateDTO vueloUpdateDto = new VueloUpdateDTO
                {
                    Id = _vueloActual.Id,
                    FechaHoraVuelo = _vueloActual.FechaHoraVuelo,
                    Aerolinea = _vueloActual.Aerolinea,
                    Precio = _vueloActual.Precio,
                    IdCiudadOrigen = _vueloActual.IdCiudadOrigen,
                    IdCiudadDestino = _vueloActual.IdCiudadDestino,
                    IdAvion = _vueloActual.IdAvion
                };

                OnEditarClicked?.Invoke(this, vueloUpdateDto);
            }
        }

        private void btnEliminarVuelo_Click(object sender, EventArgs e)
        {
            if (_vueloActual != null)
            {
                VueloDeleteDTO vueloDeleteDto = new VueloDeleteDTO
                {
                    Id = _vueloActual.Id,
                    FechaHoraVuelo = _vueloActual.FechaHoraVuelo,
                    Aerolinea = _vueloActual.Aerolinea,
                    CiudadOrigenNombre = _vueloActual.CiudadOrigenNombre,
                    CiudadDestinoNombre = _vueloActual.CiudadDestinoNombre
                };

                OnEliminarClicked?.Invoke(this, vueloDeleteDto);
            }
        }

    }
}
