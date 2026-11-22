using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
namespace WindowsForms
{
    public partial class MenuUsuarioSeleccionarAsientoForm : Form
    {
        private VueloDTO _vueloActual;
        UsuarioLoginResultDTO _usuarioAutenticado;
        MenuUsuarioBuscarVueloForm _form1;

        private PasajeroDataItemControl _pasajeroControlActual;
        private PasajeroCreateDTO _pasajeroActual;
        private string _codigoAsiento;
        private List<PasajeroCreateDTO> pasajerosDTOs = [];
        private int _cantPasajeros;

        public MenuUsuarioSeleccionarAsientoForm(MenuUsuarioBuscarVueloForm form1,UsuarioLoginResultDTO usuarioAutenticado,VueloDTO vuelo, int cantPasajeros)
        {
            InitializeComponent();

            _vueloActual = vuelo;
            _cantPasajeros = cantPasajeros;
            _usuarioAutenticado = usuarioAutenticado;
            _form1 = form1;
            // Carga Asientos
            avionControl.AgregarAsientos(vuelo.Avion.Capacidad / 4);
            MarcarAsientosOcupados(vuelo);
            // Carga Pasajeros
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
                var pasajes = await Program.HttpClient.GetFromJsonAsync<List<PasajeDTO>>($"vuelos/{vuelo.Id}/reservas/pasajes");

                if (pasajes == null)
                {
                    MessageBox.Show("No se pudieron obtener los pasajes.");
                    return;
                }

                List<string> codAsientosOcupados = pasajes
                    .Where(p => int.TryParse(p.CodigoAsiento, out _))
                    .Select(p => ConvertirCodigoAsiento(int.Parse(p.CodigoAsiento)))
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
            if (nombre == "P1") pasajeroControl.EjecutarClick();
            flowLayoutPanelPasajeros.Controls.Add(pasajeroControl);
        }

        private void PasajeroControl_PasajeroData(object sender, PasajeroCreateDTO pasajero)
        {
            if (_pasajeroControlActual != null && _pasajeroControlActual != sender as PasajeroDataItemControl)
            {
                _pasajeroControlActual.Focus(false);
                if (_pasajeroActual != null)
                {
                    _pasajeroControlActual.SetPasajero(_pasajeroActual); // se pone foco al nuevo pasajero y lo guarda en el control
                }
            }

            _pasajeroControlActual = sender as PasajeroDataItemControl;
            _pasajeroActual = pasajero;
            _pasajeroControlActual.Focus(true);

            if (pasajero == null)
            {
                comboBoxEdad.SelectedIndex = -1;
                textBoxNombre.Clear();
                textBoxApellido.Clear();
                textBoxDocumento.Clear();
                comboBoxTipoDocumento.SelectedIndex = -1;
                _codigoAsiento = null;
                return;
            }

            comboBoxEdad.SelectedItem = pasajero.Tipo == "mayor" ? "Mayor (+16)" : "Menor";
            textBoxNombre.Text = pasajero.Nombre;
            textBoxApellido.Text = pasajero.Apellido;
            textBoxDocumento.Text = pasajero.NroDocumento;
            comboBoxTipoDocumento.SelectedItem = comboBoxTipoDocumento.Items
                    .Cast<string>()
                    .FirstOrDefault(x => x.EndsWith($"({pasajero.TipoDocumento})", StringComparison.OrdinalIgnoreCase));
            avionControl.AsientoSeleccionado(pasajero.CodigoAsiento); // se desbloquea el asiento del pasajero
        }
        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            string tipoEdad = comboBoxEdad.SelectedItem?.ToString();
            string nombre = textBoxNombre.Text;
            string apellido = textBoxApellido.Text;
            string nroDocumento = textBoxDocumento.Text;
            string tipoDoc = comboBoxTipoDocumento.SelectedItem?.ToString();
            _codigoAsiento = avionControl.GetCodigoAsiento();
            string codigoAsiento = _codigoAsiento;


            if (string.IsNullOrWhiteSpace(tipoEdad) || string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(nroDocumento) || string.IsNullOrWhiteSpace(tipoDoc))
            {
                MessageBox.Show("Error, debe completar todos los campos.", "Hay Campos Vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(_codigoAsiento))
            {
                MessageBox.Show("Error, Falta seleccionar el Asiento.", "Hay Campos Vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            tipoEdad = tipoEdad.StartsWith("Mayor", StringComparison.OrdinalIgnoreCase) ? "mayor" : "menor";
            tipoDoc = tipoDoc.Substring(tipoDoc.LastIndexOf('(') + 1).TrimEnd(')');

            PasajeroCreateDTO nuevoPasajero = new PasajeroCreateDTO
            {
                Nombre = nombre,
                Apellido = apellido,
                Tipo = tipoEdad,
                NroDocumento = nroDocumento,
                TipoDocumento = tipoDoc,
                CodigoAsiento = codigoAsiento
            };
            if (_pasajeroControlActual == null)
            {
                MessageBox.Show("El pasajero actual esta vacio. Debe seleccionar uno");
                return;
            }
            avionControl.SeleccionAsientoGuardado(codigoAsiento); // guardado absoluto
            _pasajeroControlActual.SetPasajero(nuevoPasajero);
            _pasajeroActual = nuevoPasajero;
            _codigoAsiento = null;
        }

        private string ConvertirCodigoAsiento(int codigo)
        {
            int fila = (codigo - 1) / 4 + 1;
            int columna = (codigo - 1) % 4;

            char letra = (char)('A' + columna);

            return $"{letra}{fila}";
        }
        private int ConvertirCodigoAsiento(string codigo)
        {
            char letra = codigo[0];
            int fila = int.Parse(codigo.Substring(1));

            int columna = letra - 'A';

            return (fila - 1) * 4 + columna + 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _codigoAsiento = avionControl.GetCodigoAsiento();
            MessageBox.Show("Codigo del ultimo asiento Seleccionado: ", _codigoAsiento);
        }

        private void avionControl_Click(object sender, EventArgs e)
        {
            // setear valor del pasajero actual?
            _codigoAsiento = avionControl.GetCodigoAsiento();
        }

        private void buttonContinuar_Click(object sender, EventArgs e)
        {   // Generar Reserva

            List<PasajeCreateDTO> pasajesDTOs = new List<PasajeCreateDTO>();
            pasajerosDTOs = [];
            // pasajes
            foreach (PasajeroDataItemControl pasajeroItemControl in flowLayoutPanelPasajeros.Controls
                         .OfType<PasajeroDataItemControl>())
            {
                PasajeroCreateDTO pasajero = pasajeroItemControl.GetPasajero();
                if (pasajero == null)
                {
                    MessageBox.Show("Hay Pasajeros Sin Completar");
                    return;
                }
                pasajerosDTOs.Add(pasajero);
            }

            // Pasajes
            if (pasajerosDTOs.Count == _cantPasajeros)
            {
                pasajesDTOs = pasajerosDTOs.Select(pasajeroCreate => new PasajeCreateDTO
                {
                    Estado = "Emitido",
                    IdAvion = _vueloActual.Avion.Id,
                    CodigoAsiento = ConvertirCodigoAsiento(pasajeroCreate.CodigoAsiento).ToString(),
                    Pasajero = pasajeroCreate
                }).ToList();
            }
            else
            {
                MessageBox.Show("Error. No Todos los datos de los pasajeros fueron completados");
                return;
            }

            // Reserva
            ReservaCreateDTO reservaDTO = new ReservaCreateDTO
            {
                UsuarioId = _usuarioAutenticado.Id,
                VueloId = _vueloActual.Id,
                FechaHoraReserva = DateTime.UtcNow,
                UltimosCuatroDigitos = "0000",
                FechaVencimientoTarjeta = DateTime.UtcNow.AddYears(1),
                Pasajes = pasajesDTOs
            };

            GenerarReserva(reservaDTO);
        }

        private async Task GenerarReserva(ReservaCreateDTO reserva)
        {
            var response = await Program.HttpClient.PostAsJsonAsync<ReservaCreateDTO>("/reservas", reserva);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Reserva Guardada Con Exito");
            }
            else
            {
                MessageBox.Show("Error en la Reserva");
            }
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Status: {(int)response.StatusCode} - {response.StatusCode}");
            Console.WriteLine($"Response: {content}");
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            _form1.Show();
            this.Close();
        }
    }
}
