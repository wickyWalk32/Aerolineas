using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsForms
{
    // Ventana para el alta y modificación de ciudades (reutilizable entre ambos)
    public partial class CiudadDetalleForm : Form
    {
        public CiudadDTO? CiudadResultado { get; private set; }
        private bool _esEdicion = false;
        private readonly CiudadAdminMenuForm _ciudadAdminMenuForm;

        // Constructor para CREAR una nueva ciudad
        public CiudadDetalleForm(CiudadAdminMenuForm ciudadAdminMenuForm)
        {
            InitializeComponent();
            _ciudadAdminMenuForm = ciudadAdminMenuForm;
            lblTituloNuevoEditarCiudad.Text = "Nueva Ciudad";
            lblId.Text = "";
            lblIdCiudad.Text = "";
            
            // Carga los países normalmente sin selección previa
            _ = CargarPaisesAsync();
        }

        // Constructor para EDITAR una ciudad existente
        public CiudadDetalleForm(CiudadAdminMenuForm ciudadAdminMenu, CiudadDTO ciudadAEditar)// : this(ciudadAdminMenu)
        {
            InitializeComponent();
            _ciudadAdminMenuForm = ciudadAdminMenu;
            _esEdicion = true;
            lblTituloNuevoEditarCiudad.Text = "Editar Ciudad";
            CiudadResultado = ciudadAEditar;

            // Cargamos los datos actuales del usuario elegido en la pantalla anterior en las cajas de texto
            lblIdCiudad.Text = ciudadAEditar.Id.ToString();
            textBoxNombre.Text = ciudadAEditar.Nombre;
            textBoxCodigoPostal.Text = ciudadAEditar.CodigoPostal;
            textBoxCodigoAeropuerto.Text = ciudadAEditar.CodigoAeropuerto;
            
            // Cargamos los países y seleccionamos automáticamente el correspondiente
            _ = CargarPaisesAsync(ciudadAEditar.PaisId);

        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {

            // --- VALIDACIÓN DEL COMBOBOX DE PAÍS ---
            if (comboBoxPais.SelectedValue == null || Convert.ToInt32(comboBoxPais.SelectedValue) == 0)
            {
                MessageBox.Show("Por favor seleccione un país válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_esEdicion)
            {
               CiudadCreateDTO ciudad = new CiudadCreateDTO
                {
                    Nombre = textBoxNombre.Text,
                    CodigoPostal = textBoxCodigoPostal.Text,
                    CodigoAeropuerto = textBoxCodigoAeropuerto.Text,
                    PaisId = Convert.ToInt32(comboBoxPais.SelectedValue)
                };

                var response = await Program.HttpClient.PostAsJsonAsync("ciudades", ciudad);

                if (response.IsSuccessStatusCode)
                {
                    ClearForm();
                    MessageBox.Show("Ciudad guardada!","Éxito",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error. La ciudad no fue guardada.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            }
            else if (_esEdicion)
            {
                CiudadUpdateDTO ciudad = new CiudadUpdateDTO
                {
                    Id = Convert.ToInt32(lblIdCiudad.Text),
                    Nombre = textBoxNombre.Text,
                    CodigoPostal = textBoxCodigoPostal.Text,
                    CodigoAeropuerto = textBoxCodigoAeropuerto.Text,
                    PaisId = Convert.ToInt32(comboBoxPais.SelectedValue)
                };

                var response = await Program.HttpClient.PutAsJsonAsync($"ciudades/{ciudad.Id}", ciudad);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cambios Guardada!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error. Cambios no guardados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task CargarPaisesAsync(int? paisIdASeleccionar = null)
        {
            try
            {
                var paises = await Program.HttpClient.GetFromJsonAsync<List<PaisDTO>>("https://localhost:7099/paises");

                if (paises == null)
                    paises = new List<PaisDTO>();

                // Creamos la opción por defecto con Id = 0 (o -1) para que actúe como guía
                var opcionDefault = new PaisDTO
                {
                    Id = 0,
                    Nombre = "-- Seleccione País --"
                };

                // Insertamos la opción por defecto en la primera posición (índice 0)
                paises.Insert(0, opcionDefault);

                comboBoxPais.DataSource = paises;
                comboBoxPais.DisplayMember = "Nombre";
                comboBoxPais.ValueMember = "Id";
                comboBoxPais.DropDownStyle = ComboBoxStyle.DropDownList; // Para que no escriban texto libre

                // Si viene un ID de país (modo edición), lo seleccionamos; sino dejamos la opción 0 por defecto
                if (paisIdASeleccionar.HasValue)
                {
                    comboBoxPais.SelectedValue = paisIdASeleccionar.Value;
                }
                else
                {
                    comboBoxPais.SelectedIndex = 0; // Selecciona "--Seleccione País--"
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar países: {ex.Message}");
            }

        }

        private void ClearForm()
        {
            textBoxNombre.Clear();
            textBoxCodigoPostal.Clear();
            textBoxCodigoAeropuerto.Clear();
            //comboBoxPais.SelectedIndex = -1;

            if (comboBoxPais.Items.Count > 0)
            {
                comboBoxPais.SelectedIndex = 0; // Vuelve a "-- Seleccione País --"
            }

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            _ciudadAdminMenuForm.Show();
            this.Close();
            _ciudadAdminMenuForm.CargarListaCiudadesEnItems();
        }

    }    
}
