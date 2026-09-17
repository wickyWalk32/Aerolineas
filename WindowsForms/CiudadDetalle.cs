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
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsForms
{
    public partial class CiudadDetalle : Form
    {
        private readonly MenuPrincipalForm _menuPrincipalForm;
        //private readonly HttpClient _httpClient;

        public CiudadDetalle(MenuPrincipalForm menuPrincipalForm)
        {
            InitializeComponent();
            _ = CargarPaisesAsync();
            _menuPrincipalForm = menuPrincipalForm;
        }
        private readonly HttpClient _httpClient = new HttpClient();

        private async Task CargarPaisesAsync()
        {
            try
            {
                var paises = await _httpClient.GetFromJsonAsync<List<PaisDTO>>("https://localhost:7099/paises");
                if (paises == null)
                    return;

                comboBoxPais.DataSource = paises;
                comboBoxPais.DisplayMember = "Nombre";
                comboBoxPais.ValueMember = "Id";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar países: {ex.Message}");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            _menuPrincipalForm.Show();
            this.Hide();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Convert.ToInt32(comboBoxPais.SelectedValue).ToString());
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

                MessageBox.Show(
                    "Ciudad Guardada!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                MessageBox.Show(
                    "Failed to save.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
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
