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
                string url = "https://localhost:7099/paises";
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CargarPaisesAsync();
        }
    }
}
