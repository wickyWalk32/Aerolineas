using DTOs;
using System.Net.Http.Json;

namespace WindowsForms
{
    // Ventana reutilizable para crear y editar países
    public partial class PaisDetalleForm : Form
    {
        private readonly bool _esEdicion;
        private readonly PaisAdminMenuForm _paisAdminMenuForm;

        // Constructor para CREAR un nuevo país
        public PaisDetalleForm(PaisAdminMenuForm paisAdminMenuForm)
        {
            InitializeComponent();
            _paisAdminMenuForm = paisAdminMenuForm;
            _esEdicion = false;
            lblTituloNuevoEditarPais.Text = "Nuevo País";
            lblId.Text = string.Empty;
            lblIdPais.Text = string.Empty;
        }

        // Constructor para EDITAR un país existente
        public PaisDetalleForm(PaisAdminMenuForm paisAdminMenuForm, PaisUpdateDTO paisAEditar)
        {
            InitializeComponent();
            _paisAdminMenuForm = paisAdminMenuForm;
            _esEdicion = true;
            lblTituloNuevoEditarPais.Text = "Editar País";
            lblIdPais.Text = paisAEditar.Id.ToString();
            textBoxNombre.Text = paisAEditar.Nombre;
        }

        private async void btnGuardar_Click(object? sender, EventArgs e)
        {
            string nombre = textBoxNombre.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show(
                    "Por favor, ingrese el nombre del país.",
                    "Campo obligatorio",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                textBoxNombre.Focus();
                return;
            }

            try
            {
                if (!_esEdicion)
                {
                    var nuevoPais = new PaisCreateDTO { Nombre = nombre };
                    var response = await Program.HttpClient.PostAsJsonAsync("paises", nuevoPais);

                    if (response.IsSuccessStatusCode)
                    {
                        textBoxNombre.Clear();
                        MessageBox.Show("¡País guardado!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar el país.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    int id = int.Parse(lblIdPais.Text);
                    var paisActualizado = new PaisUpdateDTO
                    {
                        Id = id,
                        Nombre = nombre
                    };

                    var response = await Program.HttpClient.PutAsJsonAsync($"paises/{id}", paisActualizado);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("¡Cambios guardados!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el país.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error de conexión con la API: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnVolver_Click(object? sender, EventArgs e)
        {
            _paisAdminMenuForm.Show();
            this.Close();
            _paisAdminMenuForm.CargarListaPaisesEnItems();
        }
    }
}