using System;
using System.Windows.Forms;
using Data;
using Microsoft.EntityFrameworkCore;

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
                var options = new DbContextOptionsBuilder<AppDbContext>().Options;
                using var context = new AppDbContext(options);
                var repo = new PasajeroRepository(context);
                var service = new PasajeroService(repo);

                bool eliminado = await service.DeleteAsync(id);
                if (eliminado)
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