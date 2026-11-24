using DTOs;
using System.Net.Http.Json;

namespace WindowsForms
{
    public partial class MenuUsuarioSeleccionarAsientoForm : Form
    {
        private readonly VueloDTO _vueloActual;
        private readonly UsuarioLoginResultDTO _usuarioAutenticado;
        private readonly MenuUsuarioBuscarVueloForm _form1;

        private PasajeroDataItemControl? _pasajeroControlActual;
        private PasajeroCreateDTO? _pasajeroActual;
        private string? _codigoAsiento;
        private readonly int _cantPasajeros;

        public MenuUsuarioSeleccionarAsientoForm(
            MenuUsuarioBuscarVueloForm form1,
            UsuarioLoginResultDTO usuarioAutenticado,
            VueloDTO vuelo,
            int cantPasajeros)
        {
            InitializeComponent();

            _vueloActual = vuelo;
            _cantPasajeros = cantPasajeros;
            _usuarioAutenticado = usuarioAutenticado;
            _form1 = form1;

            int capacidad = vuelo.Avion?.Capacidad ?? 52;
            int filas = Math.Max(1, (int)Math.Ceiling(capacidad / 4.0));

            // Dibujamos exactamente 'capacidad' asientos distribuidos en filas de 4 (1A, 1B, 1C, 1D, 2A...)
            avionControl.AgregarAsientos(filas, capacidad);
            _ = MarcarAsientosOcupados(vuelo);

            for (int i = 0; i < cantPasajeros; i++)
            {
                string nombre = $"P{i + 1}";
                AgregarPasajeros(nombre);
            }
        }

        private async Task MarcarAsientosOcupados(VueloDTO vuelo)
        {
            try
            {
                var pasajes = await Program.HttpClient
                    .GetFromJsonAsync<List<PasajeDTO>>($"vuelos/{vuelo.Id}/reservas/pasajes");

                if (pasajes == null)
                    return;

                List<string> codAsientosOcupados = pasajes
                    .Where(p => !string.IsNullOrWhiteSpace(p.CodigoAsiento))
                    .Select(p => int.TryParse(p.CodigoAsiento, out int nroAsiento)
                        ? ConvertirCodigoAsiento(nroAsiento)
                        : p.CodigoAsiento.Trim())
                    .ToList();

                avionControl.MarcarAsientosOcupados(codAsientosOcupados);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los asientos: {ex.Message}");
            }
        }

        private void AgregarPasajeros(string nombre)
        {
            var pasajeroControl = new PasajeroDataItemControl(nombre);
            pasajeroControl.PasajeroData += PasajeroControl_PasajeroData;
            flowLayoutPanelPasajeros.Controls.Add(pasajeroControl);

            if (nombre == "P1")
                pasajeroControl.EjecutarClick();
        }

        private void PasajeroControl_PasajeroData(object? sender, PasajeroCreateDTO? pasajero)
        {
            if (_pasajeroControlActual != null && _pasajeroControlActual != sender as PasajeroDataItemControl)
            {
                _pasajeroControlActual.Focus(false);
                if (_pasajeroActual != null)
                {
                    _pasajeroControlActual.SetPasajero(_pasajeroActual);
                }
            }

            _pasajeroControlActual = sender as PasajeroDataItemControl;
            _pasajeroActual = pasajero;
            _pasajeroControlActual?.Focus(true);

            if (pasajero == null)
            {
                comboBoxEdad.SelectedIndex = -1;
                textBoxNombre.Clear();
                textBoxApellido.Clear();
                textBoxDocumento.Clear();
                comboBoxTipoDocumento.SelectedIndex = -1;
                _codigoAsiento = null;
                avionControl.PrepararParaNuevoPasajero(null);
                return;
            }

            comboBoxEdad.SelectedItem = pasajero.Tipo == "mayor" ? "Mayor (+16)" : "Menor";
            textBoxNombre.Text = pasajero.Nombre;
            textBoxApellido.Text = pasajero.Apellido;
            textBoxDocumento.Text = pasajero.NroDocumento;
            comboBoxTipoDocumento.SelectedItem = comboBoxTipoDocumento.Items
                .Cast<string>()
                .FirstOrDefault(x => x.EndsWith($"({pasajero.TipoDocumento})", StringComparison.OrdinalIgnoreCase));

            _codigoAsiento = pasajero.CodigoAsiento;
            avionControl.PrepararParaNuevoPasajero(pasajero.CodigoAsiento);
        }

        private void buttonGuardar_Click(object? sender, EventArgs e)
        {
            string? tipoEdad = comboBoxEdad.SelectedItem?.ToString();
            string nombre = textBoxNombre.Text.Trim();
            string apellido = textBoxApellido.Text.Trim();
            string nroDocumento = textBoxDocumento.Text.Trim();
            string? tipoDoc = comboBoxTipoDocumento.SelectedItem?.ToString();
            string? codigoAsiento = avionControl.GetCodigoAsiento() ?? _codigoAsiento;

            if (string.IsNullOrWhiteSpace(tipoEdad) ||
                string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(nroDocumento) ||
                string.IsNullOrWhiteSpace(tipoDoc))
            {
                MessageBox.Show(
                    "Debe completar todos los datos del pasajero.",
                    "Campos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (string.IsNullOrWhiteSpace(codigoAsiento))
            {
                MessageBox.Show(
                    "Debe seleccionar un asiento en el croquis.",
                    "Falta asiento",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (_pasajeroControlActual == null)
            {
                MessageBox.Show("Debe seleccionar un pasajero (P1, P2, etc.).");
                return;
            }

            string tipoNormalizado = tipoEdad.StartsWith("Mayor", StringComparison.OrdinalIgnoreCase)
                ? "mayor"
                : "menor";

            string tipoDocNormalizado = tipoDoc.Contains('(') && tipoDoc.EndsWith(')')
                ? tipoDoc.Substring(tipoDoc.LastIndexOf('(') + 1).TrimEnd(')')
                : tipoDoc;

            PasajeroCreateDTO nuevoPasajero = new PasajeroCreateDTO
            {
                Nombre = nombre,
                Apellido = apellido,
                Tipo = tipoNormalizado,
                NroDocumento = nroDocumento,
                TipoDocumento = tipoDocNormalizado,
                CodigoAsiento = codigoAsiento.Trim()
            };

            avionControl.SeleccionAsientoGuardado(nuevoPasajero.CodigoAsiento);
            _pasajeroControlActual.SetPasajero(nuevoPasajero);
            _pasajeroActual = nuevoPasajero;
            _codigoAsiento = null;
        }

        private string ConvertirCodigoAsiento(int codigo)
        {
            int nroFila = (codigo - 1) / 4 + 1;
            int columna = (codigo - 1) % 4;
            char letra = (char)('A' + columna);
            return $"{nroFila}{letra}"; // Patrón: 1A, 1B, 1C, 1D, 2A...
        }

        private void avionControl_Click(object? sender, EventArgs e)
        {
            _codigoAsiento = avionControl.GetCodigoAsiento();
        }

        private void buttonSiguiente_Click(object? sender, EventArgs e)
        {
            var controlesPasajeros = flowLayoutPanelPasajeros.Controls
                .OfType<PasajeroDataItemControl>()
                .ToList();

            var pasajerosCompletos = new List<PasajeroCreateDTO>();

            foreach (var control in controlesPasajeros)
            {
                var pasajero = control.GetPasajero();
                if (pasajero == null || string.IsNullOrWhiteSpace(pasajero.CodigoAsiento))
                {
                    MessageBox.Show(
                        "Complete los datos y el asiento de todos los pasajeros antes de continuar.",
                        "Pasajeros incompletos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
                pasajerosCompletos.Add(pasajero);
            }

            if (pasajerosCompletos.Count != _cantPasajeros)
            {
                MessageBox.Show("Faltan pasajeros por completar.");
                return;
            }

            var estado = new ReservaProcesoState
            {
                Usuario = _usuarioAutenticado,
                Vuelo = _vueloActual,
                CantidadPasajeros = _cantPasajeros,
                Pasajeros = pasajerosCompletos
            };

            // Pasamos al Paso 2: cargar servicios por pasajero
            var formServicios = new SeleccionarServiciosPorPasajeroForm(this, estado);
            formServicios.Show();
            this.Hide();
        }

        private void buttonVolver_Click(object? sender, EventArgs e)
        {
            _form1.Show();
            this.Close();
        }
    }
}