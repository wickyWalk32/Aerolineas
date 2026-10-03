using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class VueloDetalleForm : Form
    {

        public VueloUpdateDTO? VueloResultado { get; private set; }
        private bool _esEdicion = false;
        private readonly VueloAdminMenuForm _vueloAdminMenuForm;
        
        private VueloUpdateDTO? _vueloPendienteDeCarga;

        // Constructor para CREAR un nuevo vuelo
        public VueloDetalleForm(VueloAdminMenuForm vueloAdminMenuForm)
        {
            InitializeComponent();

            // --- CONFIGURACIÓN PARA EL DATETIMEPICKER DE HORA ---
            dateTimePickerHoraVuelo.Format = DateTimePickerFormat.Custom;
            dateTimePickerHoraVuelo.CustomFormat = "HH:mm";

            _vueloAdminMenuForm = vueloAdminMenuForm;
            lblTituloNuevoEditarVuelo.Text = "Nuevo Vuelo";
            lblTituloId.Text = "";
            lblIdVuelo.Text = "";

            _ = CargarComboBoxesRelacionados();
        }

        // Constructor para EDITAR un vuelo existente
        public VueloDetalleForm(VueloAdminMenuForm vueloAdminMenuForm, VueloUpdateDTO vueloAEditar)
        {
            InitializeComponent();
            
            // --- CONFIGURACIÓN PARA EL DATETIMEPICKER DE HORA ---
            dateTimePickerHoraVuelo.Format = DateTimePickerFormat.Custom;
            dateTimePickerHoraVuelo.CustomFormat = "HH:mm";

            _vueloAdminMenuForm = vueloAdminMenuForm;
            _esEdicion = true;
            lblTituloNuevoEditarVuelo.Text = "Editar Vuelo";
            VueloResultado = vueloAEditar;

            // Guardamos los datos del vuelo para usarlos una vez que los combos respondan
            _vueloPendienteDeCarga = vueloAEditar;

            // Disparamos la carga asíncrona
            _ = InicializarFormularioEdicionAsync(vueloAEditar);

        }

        private async void btnGuardarVuelo_Click(object sender, EventArgs e)
        {
            
            // Tomamos datos y los preparamos

            DateTime soloFecha = dateTimePickerFechaVuelo.Value.Date;           // 1. Capturamos la fecha del primer DateTimePicker (ej: dtpFecha)
            TimeSpan soloHora = dateTimePickerHoraVuelo.Value.TimeOfDay;        // 2. Capturamos la hora del segundo DateTimePicker (ej: dtpHora)
            DateTime fechaHoraVueloCompleta = soloFecha.Add(soloHora);          // 3. Unimos ambas en una sola variable DateTime

            // Validamos ingresos: que se haya seleccionado una opción real en los ComboBoxes (distinta de 0 / opción neutra) y decimal.

            if (comboBoxCiudadOrigen.SelectedValue == null || (int)comboBoxCiudadOrigen.SelectedValue == 0)
            {
                MessageBox.Show("Debe seleccionar una ciudad de origen válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxCiudadDestino.SelectedValue == null || (int)comboBoxCiudadDestino.SelectedValue == 0)
            {
                MessageBox.Show("Debe seleccionar una ciudad de destino válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((int)comboBoxCiudadOrigen.SelectedValue == (int)comboBoxCiudadDestino.SelectedValue)
            {
                MessageBox.Show("La ciudad de origen y la ciudad de destino no pueden ser la misma QWERTY.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal? precioValidado = ObtenerPrecioDecimalValidado();
            if (precioValidado == null) return;                                 // Frena la ejecución si dio error

            /*
            if (comboBoxAerolinea.SelectedItem == null || comboBoxAerolinea.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar una aerolínea válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            */
            
            if (comboBoxAvion.SelectedValue == null || (int)comboBoxAvion.SelectedValue == 0)
            {
                MessageBox.Show("Debe seleccionar un avión válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            

            if (!_esEdicion)
            {
                // Nuevo vuelo

                VueloCreateDTO vueloCreateDto = new VueloCreateDTO
                {
                    FechaHoraVuelo = fechaHoraVueloCompleta,
                    IdCiudadOrigen = (int)comboBoxCiudadOrigen.SelectedValue,
                    IdCiudadDestino = (int)comboBoxCiudadDestino.SelectedValue,
                    Precio = precioValidado.Value,
                    Aerolinea = textBoxAerolinea.Text,
                    //Aerolinea = comboBoxAerolinea.SelectedItem.ToString(),
                    IdAvion = (int)comboBoxAvion.SelectedValue
                };

                var response = await Program.HttpClient.PostAsJsonAsync("vuelos", vueloCreateDto);

                if (response.IsSuccessStatusCode)
                {
                    ClearForm();
                    MessageBox.Show("Nuevo vuelo creado y guardado!", "Éxito al guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Si hubo éxito al crear el vuelo, actualizamos la lista en el menú de admin de vuelos antes de mostrarlo, luego
                    // lo mostramos luego cerramos esta ventana. Este patrón hace que el admin vea impactados sus cambios en la base
                    // de datos.
                    _vueloAdminMenuForm.CargarListaVuelosEnItems();
                    _vueloAdminMenuForm.Show();
                    this.Close();
                }
                else
                {
                    string mensajeError = await response.Content.ReadAsStringAsync();
                    // Si la API devolvió un mensaje, lo mostramos; si viene vacío, usamos uno por defecto:
                    string textoAlerta = string.IsNullOrWhiteSpace(mensajeError) ? "Fallo al guardar el nuevo vuelo." : mensajeError.Trim('"');
                    MessageBox.Show(textoAlerta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else if (_esEdicion)
            {
                // Editar vuelo

                VueloUpdateDTO vueloUpdateDto = new VueloUpdateDTO
                {
                    Id = Convert.ToInt32(lblIdVuelo.Text),
                    FechaHoraVuelo = fechaHoraVueloCompleta,
                    IdCiudadOrigen = (int)comboBoxCiudadOrigen.SelectedValue,
                    IdCiudadDestino = (int)comboBoxCiudadDestino.SelectedValue,
                    Precio = precioValidado.Value,                                  // No usar Conver.ToDecimal() xq si ingresan letras se rompe
                    Aerolinea = textBoxAerolinea.Text,
                    //Aerolinea = comboBoxAerolinea.SelectedItem.ToString(),
                    IdAvion = (int)comboBoxAvion.SelectedValue
                };

                var response = await Program.HttpClient.PutAsJsonAsync($"vuelos/{vueloUpdateDto.Id}", vueloUpdateDto);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Vuelo editado y guardado!", "Éxito al guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Si hubo éxito al editar, actualizamos la lista en el menú de admin de vuelos antes de mostrarlo, luego lo mostramos
                    // luego cerramos esta ventana. Este patrón hace que el admin vea impactados sus cambios en la base de datos.
                    _vueloAdminMenuForm.CargarListaVuelosEnItems();
                    _vueloAdminMenuForm.Show();
                    this.Close();
                }
                else
                {
                    string mensajeError = await response.Content.ReadAsStringAsync();
                    // Si la API devolvió un mensaje, lo mostramos; si viene vacío, usamos uno por defecto:
                    string textoAlerta = string.IsNullOrWhiteSpace(mensajeError) ? "Fallo al editar el vuelo." : mensajeError.Trim('"');
                    MessageBox.Show(textoAlerta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private async Task InicializarFormularioEdicionAsync(VueloUpdateDTO vueloAEditar)
        {
            // 1. Esperamos obligatoriamente a que se descarguen y carguen los combos
            await CargarComboBoxesRelacionados();

            // 2. UNA VEZ QUE TERMINÓ DE LLENARSE TODO, asignamos los valores de manera segura:
            lblIdVuelo.Text = vueloAEditar.Id.ToString();
            textBoxPrecioVuelo.Text = vueloAEditar.Precio.ToString();
            textBoxAerolinea.Text = vueloAEditar.Aerolinea;
            //comboBoxAerolinea.SelectedItem = vueloAEditar.Aerolinea;

            dateTimePickerFechaVuelo.Value = vueloAEditar.FechaHoraVuelo.Date;
            dateTimePickerHoraVuelo.Value = vueloAEditar.FechaHoraVuelo;

            // Ahora los ComboBox ya tienen elementos, por lo que el SelectedValue va a encontrar el ID perfecto
            comboBoxCiudadOrigen.SelectedValue = vueloAEditar.IdCiudadOrigen;
            comboBoxCiudadDestino.SelectedValue = vueloAEditar.IdCiudadDestino;
            comboBoxAvion.SelectedValue = vueloAEditar.IdAvion;
        }

        private async Task CargarComboBoxesRelacionados()
        {
            try
            {
                // Cargar los ComboBox de Ciudad de origen, Ciudad de destino desde sus API:
                var ciudades = await Program.HttpClient.GetFromJsonAsync<List<CiudadDTO>>("ciudades");
                if (ciudades != null)
                {
                    /*
                     > IMPORTANTE:
                     En el siguiente código usé "new List<CiudadCargaDTO>(ciudades)" para el origen y cree una nueva instancia 
                     separada para el destino "new List<CiudadCargaDTO>(ciudades)".
                     En Windows Forms, si le asignas exactamente la misma instancia de una lista a dos ComboBoxes distintos, suelen trabarse 
                     o compartir la selección (si cambias el origen se cambia el destino solo). Al crear una copia independiente de la lista 
                     para cada ComboBox evitamos ese problema visual.
                    */

                    // Creamos lista para Origen con opción por defecto (Id = 0)
                    var listaOrigen = new List<CiudadDTO>(ciudades);
                    listaOrigen.Insert(0, new CiudadDTO { Id = 0, Nombre = "-- Seleccione origen --" });
                    comboBoxCiudadOrigen.DataSource = listaOrigen;
                    comboBoxCiudadOrigen.DisplayMember = "Nombre";      // Lo que ve el usuario
                    comboBoxCiudadOrigen.ValueMember = "Id";            // Lo que vale por detrás (el ID)

                    // Creamos lista para Destino con opción por defecto (Id = 0)
                    var listaDestino = new List<CiudadDTO>(ciudades);
                    listaDestino.Insert(0, new CiudadDTO { Id = 0, Nombre = "-- Seleccione destino --" });
                    comboBoxCiudadDestino.DataSource = listaDestino;
                    comboBoxCiudadDestino.DisplayMember = "Nombre";     // Lo que ve el usuario
                    comboBoxCiudadDestino.ValueMember = "Id";           // Lo que vale por detrás (el ID)

                }

                // COMENTADO PARA USAR textBoxAerolinea en vez de un ComboBox con opciones
                /*
                // Creamos la lista de aerolíneas sugeridas (puede escribir otra) con una opción por defecto en la posición 0
                var listaAerolineas = new List<string>
                    {
                        "-- Seleccione aerolínea --",
                        "Aerolíneas Argentinas",
                        "Emiratos Airlines",
                        "Flybondi",
                        "Global Wings Airlines",
                        "Qatar Airways"
                    };
                comboBoxAerolinea.DataSource = listaAerolineas;
                */

                // Cargar el ComboBox de Aviones desde su API, con opción por defecto (Id = 0):
                var aviones = await Program.HttpClient.GetFromJsonAsync<List<AvionDTO>>("aviones");
                if (aviones != null)
                {   
                    var listaAviones = new List<AvionDTO>(aviones);
                    listaAviones.Insert(0, new AvionDTO { Id = 0, Descripcion = "-- Seleccione avión --" });
                    comboBoxAvion.DataSource = listaAviones;
                    comboBoxAvion.DisplayMember = "Descripcion";
                    comboBoxAvion.ValueMember = "Id";
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos relacionados: {ex.Message}");
            }
        }

        // Valida que sea tipo decimal, y sirve ya sea que para la parte decimal se use coma o punto.
        private decimal? ObtenerPrecioDecimalValidado()
        {
            // 1. Tomamos el texto y reemplazamos la coma por un punto para unificar el criterio
            string textoPrecio = textBoxPrecioVuelo.Text.Trim().Replace(',', '.');

            // 2. Parseamos siempre con InvariantCulture (el punto es el separador decimal universal)
            if (decimal.TryParse(textoPrecio, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precioDecimal))
            {
                return precioDecimal;
            }

            // Si no es un número válido
            MessageBox.Show("Por favor, ingrese un precio válido (ej: 152.23 o 152,23).", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return null;
        }

        private void ClearForm()
        {
            //comboBoxAerolinea.SelectedIndex = 0;
            textBoxPrecioVuelo.Clear();
            comboBoxCiudadOrigen.SelectedIndex = 0;
            comboBoxCiudadDestino.SelectedIndex = 0;
            comboBoxAvion.SelectedIndex = 0;
            textBoxAerolinea.Clear();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            _vueloAdminMenuForm.CargarListaVuelosEnItems();
            _vueloAdminMenuForm.Show();
            this.Close();
        }

    }
}
