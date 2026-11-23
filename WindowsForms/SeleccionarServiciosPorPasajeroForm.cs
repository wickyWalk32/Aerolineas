using DTOs;
using System.Net.Http.Json;

namespace WindowsForms
{
    public partial class SeleccionarServiciosPorPasajeroForm : Form
    {
        private sealed class ServicioItemOption
        {
            public ServicioCargaDTO Servicio { get; set; } = default!;
            public override string ToString() => $"{Servicio.Nombre} (+$ {Servicio.Precio:N2})";
        }

        private readonly Form _formAnterior;
        private readonly ReservaProcesoState _estado;
        private List<ServicioCargaDTO> _serviciosDisponibles = new();
        private bool _cargandoChecks = false;

        public SeleccionarServiciosPorPasajeroForm(Form formAnterior, ReservaProcesoState estado)
        {
            InitializeComponent();
            _formAnterior = formAnterior;
            _estado = estado;

            InicializarDiccionarioServicios();
            CargarResumenVuelo();
            CargarComboPasajeros();
            _ = CargarServiciosAsync();
        }

        private void InicializarDiccionarioServicios()
        {
            for (int i = 0; i < _estado.Pasajeros.Count; i++)
            {
                if (!_estado.ServiciosPorPasajero.ContainsKey(i))
                {
                    _estado.ServiciosPorPasajero[i] = new List<int>();
                }
            }
        }

        private void CargarResumenVuelo()
        {
            string origen = _estado.Vuelo?.CiudadOrigen?.Nombre ?? "";
            string destino = _estado.Vuelo?.CiudadDestino?.Nombre ?? "";
            lblResumenRuta.Text = $"Ruta: {origen} → {destino}";
            lblResumenFecha.Text = $"Fecha y hora: {_estado.Vuelo?.FechaHoraVuelo:dd/MM/yyyy HH:mm}";

            var asientos = _estado.Pasajeros
                .Select(p => p.CodigoAsiento)
                .Where(c => !string.IsNullOrWhiteSpace(c));
            lblResumenAsientos.Text = $"Asientos: {string.Join(", ", asientos)}";

            ActualizarTotalEstimado();
        }

        private void CargarComboPasajeros()
        {
            comboBoxPasajeros.Items.Clear();
            for (int i = 0; i < _estado.Pasajeros.Count; i++)
            {
                var p = _estado.Pasajeros[i];
                comboBoxPasajeros.Items.Add($"Pasajero #{i + 1}: {p.Nombre} {p.Apellido} (Asiento {p.CodigoAsiento})");
            }

            if (comboBoxPasajeros.Items.Count > 0)
            {
                comboBoxPasajeros.SelectedIndex = 0;
            }
        }

        private async Task CargarServiciosAsync()
        {
            try
            {
                var servicios = await Program.HttpClient
                    .GetFromJsonAsync<List<ServicioCargaDTO>>("servicios");

                _serviciosDisponibles = servicios ?? new List<ServicioCargaDTO>();

                checkedListBoxServicios.Items.Clear();
                foreach (var srv in _serviciosDisponibles)
                {
                    checkedListBoxServicios.Items.Add(new ServicioItemOption { Servicio = srv });
                }

                SincronizarChecksConPasajeroActual();
                ActualizarTotalEstimado();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar servicios adicionales: {ex.Message}");
            }
        }

        private void comboBoxPasajeros_SelectedIndexChanged(object? sender, EventArgs e)
        {
            SincronizarChecksConPasajeroActual();
        }

        private void SincronizarChecksConPasajeroActual()
        {
            int idxPasajero = comboBoxPasajeros.SelectedIndex;
            if (idxPasajero < 0 || !_estado.ServiciosPorPasajero.TryGetValue(idxPasajero, out var idsSeleccionados))
                return;

            _cargandoChecks = true;
            for (int i = 0; i < checkedListBoxServicios.Items.Count; i++)
            {
                if (checkedListBoxServicios.Items[i] is ServicioItemOption opcion)
                {
                    bool marcado = idsSeleccionados.Contains(opcion.Servicio.Id);
                    checkedListBoxServicios.SetItemChecked(i, marcado);
                }
            }
            _cargandoChecks = false;
        }

        private void checkedListBoxServicios_ItemCheck(object? sender, ItemCheckEventArgs e)
        {
            if (_cargandoChecks) return;

            int idxPasajero = comboBoxPasajeros.SelectedIndex;
            if (idxPasajero < 0) return;

            if (checkedListBoxServicios.Items[e.Index] is not ServicioItemOption opcion)
                return;

            if (!_estado.ServiciosPorPasajero.ContainsKey(idxPasajero))
            {
                _estado.ServiciosPorPasajero[idxPasajero] = new List<int>();
            }

            var lista = _estado.ServiciosPorPasajero[idxPasajero];
            bool vaAQuedarMarcado = e.NewValue == CheckState.Checked;

            if (vaAQuedarMarcado && !lista.Contains(opcion.Servicio.Id))
            {
                lista.Add(opcion.Servicio.Id);
            }
            else if (!vaAQuedarMarcado)
            {
                lista.Remove(opcion.Servicio.Id);
            }

            // Recalcular total usando el estado actualizado
            this.BeginInvoke(new Action(ActualizarTotalEstimado));
        }

        private void ActualizarTotalEstimado()
        {
            decimal precioVuelo = _estado.Vuelo?.Precio ?? 0m;
            decimal totalVuelos = precioVuelo * _estado.Pasajeros.Count;

            decimal totalServicios = 0m;
            var diccionarioPrecios = _serviciosDisponibles.ToDictionary(s => s.Id, s => s.Precio);

            foreach (var par in _estado.ServiciosPorPasajero)
            {
                foreach (var srvId in par.Value)
                {
                    if (diccionarioPrecios.TryGetValue(srvId, out var precioSrv))
                    {
                        totalServicios += precioSrv;
                    }
                }
            }

            lblTotalEstimado.Text = $"Total estimado: $ {(totalVuelos + totalServicios):N2}";
        }

        private void btnAtras_Click(object? sender, EventArgs e)
        {
            _formAnterior.Show();
            this.Close();
        }

        private void btnSiguiente_Click(object? sender, EventArgs e)
        {
            /*
            // Siguiente paso: ventana de datos de pago (la armamos en el próximo mensaje)
            MessageBox.Show(
                "Servicios guardados por pasajero. Pasemos ahora a la ventana de datos de pago.",
                "Listo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            */
            var formPago = new PagoTarjetaForm(this, _estado);
            formPago.Show();
            this.Hide();
        }
    }
}

/*using System;
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
    public partial class SeleccionarServiciosPorPasajeroForm : Form
    {
        public SeleccionarServiciosPorPasajeroForm()
        {
            InitializeComponent();
        }
    }
}*/
