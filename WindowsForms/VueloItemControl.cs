using DTOs;

namespace WindowsForms
{
    public partial class VueloItemControl : UserControl
    {
        public event EventHandler<VueloUpdateDTO>? OnEditarClicked;
        public event EventHandler<VueloDeleteDTO>? OnEliminarClicked;
        public event EventHandler<VueloDTO>? OnVueloSeleccionado;

        private VueloDTO? _vueloActual;

        public VueloItemControl()
        {
            InitializeComponent();
        }

        public void CargarDatos(VueloDTO vueloActual)
        {
            _vueloActual = vueloActual;

            lblId.Text = vueloActual.Id.ToString();
            lblFecha.Text = vueloActual.FechaHoraVuelo.ToString("dd/MM/yyyy");
            lblHora.Text = vueloActual.FechaHoraVuelo.ToString("HH:mm");
            lblAerolinea.Text = vueloActual.Aerolinea;
            lblPrecio.Text = $"$ {vueloActual.Precio:N2}";
            lblCiudadOrigen.Text = "Desde " + (vueloActual.CiudadOrigen?.Nombre ?? "");
            lblCiudadDestino.Text = "a " + (vueloActual.CiudadDestino?.Nombre ?? "");
            lblAvionDescripcion.Text = "Avión: " + (vueloActual.Avion?.Descripcion ?? "");
            lblAvionCapacidad.Text = "Capacidad: " + (vueloActual.Avion != null ? vueloActual.Avion.Capacidad.ToString() : "");
        }

        public void Seleccionable()
        {
            btnEditarVuelo.Visible = false;
            btnEliminarVuelo.Visible = false;
            btnSeleccionarVuelo.Visible = true;
            btnSeleccionarVuelo.Cursor = Cursors.Hand;
        }

        private void btnSeleccionarVuelo_Click(object? sender, EventArgs e)
        {
            if (_vueloActual == null) return;
            OnVueloSeleccionado?.Invoke(this, _vueloActual);
        }

        private void btnEditarVuelo_Click(object? sender, EventArgs e)
        {
            if (_vueloActual != null)
            {
                VueloUpdateDTO vueloUpdateDto = new VueloUpdateDTO
                {
                    Id = _vueloActual.Id,
                    FechaHoraVuelo = _vueloActual.FechaHoraVuelo,
                    Aerolinea = _vueloActual.Aerolinea,
                    Precio = _vueloActual.Precio,
                    IdCiudadOrigen = _vueloActual.CiudadOrigen?.Id ?? 0,
                    IdCiudadDestino = _vueloActual.CiudadDestino?.Id ?? 0,
                    IdAvion = _vueloActual.Avion?.Id ?? 0
                };

                OnEditarClicked?.Invoke(this, vueloUpdateDto);
            }
        }

        private void btnEliminarVuelo_Click(object? sender, EventArgs e)
        {
            if (_vueloActual != null)
            {
                VueloDeleteDTO vueloDeleteDto = new VueloDeleteDTO
                {
                    Id = _vueloActual.Id,
                    FechaHoraVuelo = _vueloActual.FechaHoraVuelo,
                    Aerolinea = _vueloActual.Aerolinea,
                    CiudadOrigenNombre = _vueloActual.CiudadOrigen?.Nombre ?? "",
                    CiudadDestinoNombre = _vueloActual.CiudadDestino?.Nombre ?? ""
                };

                OnEliminarClicked?.Invoke(this, vueloDeleteDto);
            }
        }
    }
}