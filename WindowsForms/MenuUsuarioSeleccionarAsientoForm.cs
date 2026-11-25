using DTOs;
using System.Net.Http.Json;

namespace WindowsForms
{
    public partial class MenuUsuarioSeleccionarAsientoForm : Form
    {
        private readonly VueloDTO _vueloActual;
        private readonly UsuarioLoginResultDTO _usuarioAutenticado;
        private readonly MenuUsuarioBuscarVueloForm _form1;
        private readonly int _cantPasajeros;

        private readonly HashSet<string> _codigosOcupadosEnVuelo = new(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<PasajeroDataItemControl, string> _asientoGuardadoPorControl = new();

        private PasajeroDataItemControl? _pasajeroControlActual;
        private PasajeroCreateDTO? _pasajeroActual;
        private string? _codigoAsientoBorrador;

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

            avionControl.AgregarAsientos(filas, capacidad);
            avionControl.AsientoCambiado += AvionControl_AsientoCambiado;

            for (int i = 0; i < cantPasajeros; i++)
            {
                string nombre = $"P{i + 1}";
                AgregarPasajeros(nombre);
            }

            _ = CargarAsientosOcupadosAsync(vuelo);
        }

        private async Task CargarAsientosOcupadosAsync(VueloDTO vuelo)
        {
            try
            {
                var pasajes = await Program.HttpClient
                    .GetFromJsonAsync<List<PasajeDTO>>($"vuelos/{vuelo.Id}/reservas/pasajes");

                _codigosOcupadosEnVuelo.Clear();

                if (pasajes != null)
                {
                    foreach (var p in pasajes)
                    {
                        if (string.IsNullOrWhiteSpace(p.CodigoAsiento)) continue;
                        string cod = NormalizarCodigoAsiento(p.CodigoAsiento.Trim());
                        _codigosOcupadosEnVuelo.Add(cod);
                    }
                }

                RefrescarCroquisSegunEstadoActual();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los asientos: {ex.Message}");
            }
        }

        // Si en BD el código viene como "7" queda "7"; si alguna vez viniera como "B3", lo convierte a "7"
        private static string NormalizarCodigoAsiento(string valor)
        {
            if (int.TryParse(valor, out int nro) && nro > 0)
                return nro.ToString();

            if (valor.Length >= 2)
            {
                char letra = char.ToUpperInvariant(valor[0]);
                if (letra is >= 'A' and <= 'Z' && int.TryParse(valor[1..], out int col) && col is >= 1 and <= 4)
                {
                    int filaIdx = letra - 'A';
                    int codigoCalculado = filaIdx * 4 + col;
                    return codigoCalculado.ToString();
                }
            }

            return valor;
        }

        private void AvionControl_AsientoCambiado(object? sender, string? nuevoCodigo)
        {
            _codigoAsientoBorrador = nuevoCodigo;
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
            if (sender is not PasajeroDataItemControl nuevoControl)
                return;

            if (_pasajeroControlActual != null && _pasajeroControlActual != nuevoControl)
            {
                _pasajeroControlActual.Focus(false);
                if (_pasajeroActual != null)
                {
                    _pasajeroControlActual.SetPasajero(_pasajeroActual);
                }
            }

            _pasajeroControlActual = nuevoControl;
            _pasajeroActual = pasajero;
            _pasajeroControlActual.Focus(true);

            _asientoGuardadoPorControl.TryGetValue(nuevoControl, out string? asientoGuardado);
            _codigoAsientoBorrador = asientoGuardado ?? pasajero?.CodigoAsiento;

            if (pasajero == null)
            {
                comboBoxEdad.SelectedIndex = -1;
                textBoxNombre.Clear();
                textBoxApellido.Clear();
                textBoxDocumento.Clear();
                comboBoxTipoDocumento.SelectedIndex = -1;
            }
            else
            {
                comboBoxEdad.SelectedItem = pasajero.Tipo == "mayor" ? "Mayor (+16)" : "Menor";
                textBoxNombre.Text = pasajero.Nombre;
                textBoxApellido.Text = pasajero.Apellido;
                textBoxDocumento.Text = pasajero.NroDocumento;
                comboBoxTipoDocumento.SelectedItem = comboBoxTipoDocumento.Items
                    .Cast<string>()
                    .FirstOrDefault(x => x.EndsWith($"({pasajero.TipoDocumento})", StringComparison.OrdinalIgnoreCase));
            }

            RefrescarCroquisSegunEstadoActual();
        }

        private void RefrescarCroquisSegunEstadoActual()
        {
            string? asientoActualGuardado = null;
            if (_pasajeroControlActual != null)
            {
                _asientoGuardadoPorControl.TryGetValue(_pasajeroControlActual, out asientoActualGuardado);
            }

            var asientosDeOtros = _asientoGuardadoPorControl
                .Where(kvp => kvp.Key != _pasajeroControlActual && !string.IsNullOrWhiteSpace(kvp.Value))
                .Select(kvp => kvp.Value);

            avionControl.SincronizarCroquis(
                _codigosOcupadosEnVuelo,
                asientosDeOtros,
                asientoActualGuardado,
                _codigoAsientoBorrador
            );
        }

        private void buttonGuardar_Click(object? sender, EventArgs e)
        {
            if (_pasajeroControlActual == null)
            {
                MessageBox.Show("Debe seleccionar un pasajero (P1, P2, etc.).");
                return;
            }

            string? tipoEdad = comboBoxEdad.SelectedItem?.ToString();
            string nombre = textBoxNombre.Text.Trim();
            string apellido = textBoxApellido.Text.Trim();
            string nroDocumento = textBoxDocumento.Text.Trim();
            string? tipoDoc = comboBoxTipoDocumento.SelectedItem?.ToString();
            string? codigoAsiento = (avionControl.GetCodigoAsiento() ?? _codigoAsientoBorrador)?.Trim();

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

            if (_codigosOcupadosEnVuelo.Contains(codigoAsiento))
            {
                MessageBox.Show("Ese asiento ya se encuentra ocupado en este vuelo.");
                return;
            }

            bool tomadoPorOtro = _asientoGuardadoPorControl
                .Any(kvp => kvp.Key != _pasajeroControlActual &&
                             string.Equals(kvp.Value, codigoAsiento, StringComparison.OrdinalIgnoreCase));

            if (tomadoPorOtro)
            {
                MessageBox.Show("Ese asiento ya fue asignado a otro pasajero de esta reserva.");
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
                CodigoAsiento = codigoAsiento
            };

            _asientoGuardadoPorControl[_pasajeroControlActual] = codigoAsiento;
            _pasajeroControlActual.SetPasajero(nuevoPasajero);
            _pasajeroActual = nuevoPasajero;
            _codigoAsientoBorrador = null;

            RefrescarCroquisSegunEstadoActual();
        }

        private void avionControl_Click(object? sender, EventArgs e)
        {
            _codigoAsientoBorrador = avionControl.GetCodigoAsiento();
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