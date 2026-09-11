using System;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class PasajeroDeleteForm : Form
    {
        public PasajeroDeleteForm()
        {
            InitializeComponent();
        }

        private async void BtnEliminar_Click(object? sender, EventArgs e)
        {
            int id = (int)nudId.Value;
            if (id <= 0)
            {
                MessageBox.Show("Ingrese un Id válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmar = MessageBox.Show($"¿Confirma eliminar el pasajero con Id {id}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar != DialogResult.Yes) return;

            try
            {
                var response = await Program.HttpClient.DeleteAsync($"pasajeros/{id}");
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Pasajero eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("No se encontró un pasajero con ese Id.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}