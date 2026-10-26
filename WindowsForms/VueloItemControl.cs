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

        public event Action<VueloDTO>? OnVueloSeleccionado;

        private VueloDTO? _vueloActual;

        public VueloItemControl()
        {
            InitializeComponent();
        }

        // Método para cargar la información en este ítem visual
        public void CargarDatos(VueloDTO vueloActual)
        {
            _vueloActual = vueloActual;

            lblId.Text = vueloActual.Id.ToString();
            lblFecha.Text = vueloActual.FechaHoraVuelo.ToString("dd/MM/yyyy");
            lblHora.Text = vueloActual.FechaHoraVuelo.ToString("HH:mm");
            lblAerolinea.Text = "Aerolínea: " + vueloActual.Aerolinea;
            lblPrecio.Text = "$ " + Convert.ToString(vueloActual.Precio);
            lblCiudadOrigen.Text = "Origen: " + vueloActual.CiudadOrigen.Nombre;
            lblCiudadDestino.Text = "Destino: " + vueloActual.CiudadDestino.Nombre;
            lblAvionDescripcion.Text = "Avión: " + vueloActual.Avion.Descripcion;
            lblAvionCapacidad.Text = "Capacidad: " + vueloActual.Avion.Capacidad.ToString();

        }

        public void Seleccionable()
        {
            this.Controls.Remove(btnEditarVuelo);
            btnEditarVuelo.Dispose();
            this.Controls.Remove(btnEliminarVuelo);
            btnEliminarVuelo.Dispose();
            SetHandCursor(this);
            AttachClickEvents(this);
            SeleccionarVueloComportamiento(this);
        }

        private void SetHandCursor(Control control)
        {
            control.Cursor = Cursors.Hand;

            foreach (Control child in control.Controls)
            {
                SetHandCursor(child);
            }
        }
        private void Item_Click(object sender, EventArgs e)
        {
            if (_vueloActual == null) return;

            OnVueloSeleccionado?.Invoke(_vueloActual);
        }
        private void AttachClickEvents(Control parent)
        {
            parent.Click += Item_Click;

            foreach (Control child in parent.Controls)
            {
                AttachClickEvents(child);
            }
        }

        private void SeleccionarVueloComportamiento(VueloItemControl item)
        {
            Color colorOriginal = item.BackColor;
            Color colorHover = Color.Honeydew;

            void MouseEnterItem(object sender, EventArgs e)
            {
                item.BackColor = colorHover;
                item.Cursor = Cursors.Hand;
            }

            void MouseLeaveItem(object sender, EventArgs e)
            {
                // Keep hover while the mouse is still inside the item.
                Point mousePosition = item.PointToClient(Cursor.Position);

                if (!item.ClientRectangle.Contains(mousePosition))
                {
                    item.BackColor = colorOriginal;
                    item.Cursor = Cursors.Default;
                }
            }

            void AttachEvents(Control control)
            {
                control.MouseEnter += MouseEnterItem;
                control.MouseLeave += MouseLeaveItem;

                foreach (Control child in control.Controls)
                {
                    AttachEvents(child);
                }
            }

            AttachEvents(item);
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
                    IdCiudadOrigen = _vueloActual.CiudadOrigen.Id,
                    IdCiudadDestino = _vueloActual.CiudadDestino.Id,
                    IdAvion = _vueloActual.Avion.Id
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
                    CiudadOrigenNombre = _vueloActual.CiudadOrigen.Nombre,
                    CiudadDestinoNombre = _vueloActual.CiudadDestino.Nombre
                };

                OnEliminarClicked?.Invoke(this, vueloDeleteDto);
            }
        }

    }
}
