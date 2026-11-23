using DTOs;
using System.Net.Http.Json;
using System.Text.Json;

namespace WindowsForms
{
    public partial class PaisAdminMenuForm : Form
    {
        private readonly MenuAdminForm _menuAdminForm;

        public PaisAdminMenuForm(MenuAdminForm menuAdminForm)
        {
            InitializeComponent();
            _menuAdminForm = menuAdminForm;
            CargarListaPaisesEnItems();
        }

        public async void CargarListaPaisesEnItems()
        {
            panelListaPaises.Controls.Clear();

            try
            {
                var listaPaises = await Program.HttpClient.GetFromJsonAsync<List<PaisDTO>>("paises");

                if (listaPaises == null) return;

                foreach (var pais in listaPaises)
                {
                    var item = new PaisItemControl();
                    item.CargarDatos(pais);
                    item.OnEditarClicked += Item_OnEditarClicked;
                    item.OnEliminarClicked += Item_OnEliminarClicked;
                    panelListaPaises.Controls.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Fallo al conectar con la API al cargar los países.",
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnNuevoPais_Click(object? sender, EventArgs e)
        {
            var formDetalle = new PaisDetalleForm(this);
            this.Hide();
            formDetalle.ShowDialog();
        }

        private void Item_OnEditarClicked(object? sender, PaisUpdateDTO paisUpdateDto)
        {
            var formDetalle = new PaisDetalleForm(this, paisUpdateDto);
            this.Hide();
            formDetalle.ShowDialog();
        }

        private async void Item_OnEliminarClicked(object? sender, PaisDTO pais)
        {
            var confirmacion = MessageBox.Show(
                $"¿Está seguro de que desea eliminar el país '{pais.Nombre}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion != DialogResult.Yes) return;

            try
            {
                var response = await Program.HttpClient.DeleteAsync($"paises/{pais.Id}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("País eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListaPaisesEnItems();
                }
                else
                {
                    // Si el backend devuelve BadRequest por ciudades asociadas, intentamos leer el mensaje de error
                    string mensajeError = $"No se pudo eliminar el país ({response.ReasonPhrase}).";
                    try
                    {
                        var errObj = await response.Content.ReadFromJsonAsync<JsonElement>();
                        if (errObj.TryGetProperty("error", out var errorProp) && !string.IsNullOrWhiteSpace(errorProp.GetString()))
                        {
                            mensajeError = errorProp.GetString()!;
                        }
                    }
                    catch
                    {
                        // Si el cuerpo no es JSON con "error", mantenemos el mensaje genérico
                    }

                    MessageBox.Show(mensajeError, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Fallo al conectar con la API al intentar eliminar.",
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnVolver_Click(object? sender, EventArgs e)
        {
            _menuAdminForm.Show();
            this.Close();
        }
    }
}