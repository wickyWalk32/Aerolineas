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
    public partial class CiudadDetalle : Form
    {
        public CiudadDTO? CiudadResultado { get; private set; }
        private bool _esEdicion = false;
        private readonly CiudadAdminMenu _ciudadAdminMenu;

        // Constructor para CREAR una nueva ciudad
        public CiudadDetalle(CiudadAdminMenu ciudadAdminMenu)
        {
            InitializeComponent();
            _ciudadAdminMenu = ciudadAdminMenu;
            lblTituloNuevoEditarCiudad.Text = "Nueva Ciudad";
            lblIdCiudad.Text = "";
            
            // Carga los países normalmente sin selección previa
            _ = CargarPaisesAsync();
        }

        // Constructor para EDITAR una ciudad existente
        public CiudadDetalle(CiudadAdminMenu ciudadAdminMenu, CiudadDTO ciudadAEditar)// : this(ciudadAdminMenu)
        {
            InitializeComponent();
            _ciudadAdminMenu = ciudadAdminMenu;
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

        private void btnVolver_Click(object sender, EventArgs e)
        {
            _ciudadAdminMenu.Show();
            this.Close();
            _ciudadAdminMenu.CargarListaCiudadesEnItems();

        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
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
                    MessageBox.Show("Ciudad Guardada!","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to save.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            }
            else
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
                    MessageBox.Show("Failed to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task CargarPaisesAsync(int? paisIdASeleccionar = null)
        {
            try
            {

                var paises = await Program.HttpClient.GetFromJsonAsync<List<PaisDTO>>("https://localhost:7099/paises");

                if (paises == null)
                    return;

                comboBoxPais.DataSource = paises;
                comboBoxPais.DisplayMember = "Nombre";
                comboBoxPais.ValueMember = "Id";

                // Si viene un ID de país, lo posicionamos inmediatamente después de enlazar los datos
                if (paisIdASeleccionar.HasValue)
                {
                    comboBoxPais.SelectedValue = paisIdASeleccionar.Value;
                }
                else
                {
                    comboBoxPais.SelectedIndex = -1;
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
            comboBoxPais.SelectedIndex = -1;
        }

    }    
}
