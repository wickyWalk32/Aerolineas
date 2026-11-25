using DTOs;
using System.Net.Http.Json;

namespace WindowsForms
{
    public partial class MenuUsuarioBuscarVueloForm : Form
    {
        private const string TextoOrigenDefault = "Seleccione ciudad origen";
        private const string TextoDestinoDefault = "Seleccione ciudad destino";
        private const string TextoPasajerosDefault = "Ingrese cantidad de pasajeros";

        private List<VueloDTO> _vuelos = new();
        private readonly Dictionary<int, int> _asientosOcupadosPorVuelo = new();
        private readonly UsuarioLoginResultDTO _usuarioAutenticado;
        private bool _cargandoCombos = false;

        public MenuUsuarioBuscarVueloForm(UsuarioLoginResultDTO usuarioAutenticado)
        {
            InitializeComponent();
            _usuarioAutenticado = usuarioAutenticado;
            lblNombreApellido.Text = $"¡Hola, {usuarioAutenticado.Nombre} {usuarioAutenticado.Apellido}!";

            InicializarCombos();
            _ = CargarDatosAsync();
        }

        private void InicializarCombos()
        {
            _cargandoCombos = true;

            comboBoxCiudadOrigen.Items.Clear();
            comboBoxCiudadOrigen.Items.Add(TextoOrigenDefault);
            comboBoxCiudadOrigen.SelectedIndex = 0;

            comboBoxCiudadDestino.Items.Clear();
            comboBoxCiudadDestino.Items.Add(TextoDestinoDefault);
            comboBoxCiudadDestino.SelectedIndex = 0;

            comboBoxCantidadPasajeros.Items.Clear();
            comboBoxCantidadPasajeros.Items.Add(TextoPasajerosDefault);
            for (int i = 1; i <= 10; i++)
            {
                comboBoxCantidadPasajeros.Items.Add(i.ToString());
            }
            comboBoxCantidadPasajeros.SelectedIndex = 0;

            _cargandoCombos = false;
        }

        private async Task CargarDatosAsync()
        {
            await CargarCiudadesAsync();
            await CargarVuelosAsync();
        }

        private async Task CargarCiudadesAsync()
        {
            try
            {
                var ciudades = await Program.HttpClient.GetFromJsonAsync<List<CiudadDTO>>("ciudades");
                if (ciudades == null) return;

                _cargandoCombos = true;
                foreach (var ciudad in ciudades.OrderBy(c => c.Nombre))
                {
                    comboBoxCiudadOrigen.Items.Add(ciudad.Nombre);
                    comboBoxCiudadDestino.Items.Add(ciudad.Nombre);
                }
                _cargandoCombos = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ciudades: {ex.Message}");
            }
        }

        private async Task CargarVuelosAsync()
        {
            try
            {
                var vuelos = await Program.HttpClient.GetFromJsonAsync<List<VueloDTO>>("/vuelos");
                _vuelos = vuelos ?? new List<VueloDTO>();

                _asientosOcupadosPorVuelo.Clear();

                // Consultamos en paralelo los pasajes/ocupados de cada vuelo para calcular asientos libres reales
                var tareasOcupados = _vuelos.Select(async v =>
                {
                    try
                    {
                        var pasajes = await Program.HttpClient
                            .GetFromJsonAsync<List<PasajeDTO>>($"vuelos/{v.Id}/reservas/pasajes");

                        int ocupados = pasajes?
                            .Where(p => !string.IsNullOrWhiteSpace(p.CodigoAsiento))
                            .Select(p => p.CodigoAsiento.Trim())
                            .Distinct(StringComparer.OrdinalIgnoreCase)
                            .Count() ?? 0;

                        return (VueloId: v.Id, Ocupados: ocupados);
                    }
                    catch
                    {
                        return (VueloId: v.Id, Ocupados: 0);
                    }
                });

                var resultados = await Task.WhenAll(tareasOcupados);
                foreach (var res in resultados)
                {
                    _asientosOcupadosPorVuelo[res.VueloId] = res.Ocupados;
                }

                MostrarVuelos(_vuelos);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar vuelos: {ex.Message}");
            }
        }

        private int ObtenerAsientosLibres(VueloDTO vuelo)
        {
            int capacidadTotal = vuelo.Avion?.Capacidad ?? vuelo.Capacidad ?? 0;
            int ocupados = _asientosOcupadosPorVuelo.TryGetValue(vuelo.Id, out int cantOcupados)
                ? cantOcupados
                : 0;

            return Math.Max(0, capacidadTotal - ocupados);
        }

        private void FiltrarVuelos(object? sender, EventArgs e)
        {
            if (_cargandoCombos || _vuelos.Count == 0) return;

            string? origen = comboBoxCiudadOrigen.SelectedItem?.ToString();
            string? destino = comboBoxCiudadDestino.SelectedItem?.ToString();
            string? cantTexto = comboBoxCantidadPasajeros.SelectedItem?.ToString();

            bool filtrarOrigen = !string.IsNullOrWhiteSpace(origen) && origen != TextoOrigenDefault;
            bool filtrarDestino = !string.IsNullOrWhiteSpace(destino) && destino != TextoDestinoDefault;
            int? cantidadPasajeros = int.TryParse(cantTexto, out int cant) ? cant : null;

            var filtrados = _vuelos.Where(v =>
                (!filtrarOrigen || v.CiudadOrigen?.Nombre == origen) &&
                (!filtrarDestino || v.CiudadDestino?.Nombre == destino) &&
                (!cantidadPasajeros.HasValue || ObtenerAsientosLibres(v) >= cantidadPasajeros.Value)
            ).ToList();

            labelSinVuelos.Visible = filtrados.Count == 0;
            MostrarVuelos(filtrados);
        }

        private void MostrarVuelos(List<VueloDTO> vuelos)
        {
            flowLayoutPanelVuelos.SuspendLayout();
            flowLayoutPanelVuelos.Controls.Clear();

            foreach (var vuelo in vuelos)
            {
                var vueloItem = new VueloItemControl();
                vueloItem.CargarDatos(vuelo);
                vueloItem.Seleccionable();
                vueloItem.OnVueloSeleccionado += OnVueloSeleccionado;
                flowLayoutPanelVuelos.Controls.Add(vueloItem);
            }

            flowLayoutPanelVuelos.ResumeLayout();
        }

        private void OnVueloSeleccionado(object? sender, VueloDTO vuelo)
        {
            SeleccionarVuelo(vuelo);
        }

        private void SeleccionarVuelo(VueloDTO vuelo)
        {
            string? cantTexto = comboBoxCantidadPasajeros.SelectedItem?.ToString();
            if (!int.TryParse(cantTexto, out int cantidadPasajeros) || cantidadPasajeros <= 0)
            {
                MessageBox.Show(
                    "Por favor, ingrese la cantidad de pasajeros antes de continuar.",
                    "Falta cantidad de pasajeros",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                comboBoxCantidadPasajeros.Focus();
                return;
            }

            if (ObtenerAsientosLibres(vuelo) < cantidadPasajeros)
            {
                MessageBox.Show(
                    "El vuelo seleccionado no tiene suficientes asientos libres para esa cantidad de pasajeros.",
                    "Sin disponibilidad suficiente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var formAsientos = new MenuUsuarioSeleccionarAsientoForm(
                this,
                _usuarioAutenticado,
                vuelo,
                cantidadPasajeros
            );
            formAsientos.Show();
            this.Hide();
        }

        private void btnSalirDelSistema_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void buttonMisReservas_Click(object sender, EventArgs e)
        {
            var form = new MenuUsuarioReservaForm(this, _usuarioAutenticado);
            form.Show();
            this.Hide();
        }
    }
}