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
                var ventana = new PasajeroDetalle();
                ventana.ShowDialog(this);
        }

        private void BtnModificarPasajero_Click(object sender, EventArgs e)
        {
                var ventana = new PasajeroListForm();
                ventana.ShowDialog(this);
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
                var ventana = new PasajeroDeleteForm();
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