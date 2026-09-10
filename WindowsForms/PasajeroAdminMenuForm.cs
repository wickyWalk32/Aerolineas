using System;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class PasajeroAdminMenuForm : Form
    {
        private readonly MenuPrincipalForm _menuPrincipalForm;

        public PasajeroAdminMenuForm(MenuPrincipalForm menuPrincipalForm)
        {
            _menuPrincipalForm = menuPrincipalForm;
            InitializeComponent();
        }

        private void BtnCrearPasajero_Click(object sender, EventArgs e)
        {
            try
            {
                // Especifica el constructor correcto si hay sobrecarga ambigua
                var ventana = new PasajeroFormCreate();
                ventana.ShowDialog(this);
            }
            catch
            {
                MessageBox.Show("Formulario de creación de pasajero no disponible.", "No implementado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnModificarPasajero_Click(object sender, EventArgs e)
        {
            try
            {
                // Abrimos listado (desde ahí se puede implementar edición)
                var ventana = new PasajeroListForm();
                ventana.ShowDialog(this);
            }
            catch
            {
                MessageBox.Show("Formulario para modificar pasajero no disponible.", "No implementado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnMostrarPasajeros_Click(object sender, EventArgs e)
        {
            try
            {
                var ventana = new PasajeroListForm();
                ventana.ShowDialog(this);
            }
            catch
            {
                MessageBox.Show("Listado de pasajeros no disponible.", "No implementado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnEliminarPasajero_Click(object sender, EventArgs e)
        {
            try
            {
                // Abrir listado; implementar eliminación dentro de `PasajeroListForm` si se desea.
                var ventana = new PasajeroListForm();
                ventana.ShowDialog(this);
            }
            catch
            {
                MessageBox.Show("Funcionalidad de eliminar pasajero no disponible.", "No implementado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            _menuPrincipalForm.Show();
            this.Close();
        }
    }
}