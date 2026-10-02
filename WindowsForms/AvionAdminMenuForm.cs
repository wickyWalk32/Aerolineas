using System;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class AvionAdminMenuForm : Form
    {
        private readonly MenuAdminForm _menuAdminForm;

        // Constructor principal que recibe la referencia de MenuAdminForm
        public AvionAdminMenuForm(MenuAdminForm menuAdminForm)
        {
            InitializeComponent();
            _menuAdminForm = menuAdminForm;
        }

        private void btnNuevoAvion_Click(object sender, EventArgs e)
        {
            AvionCreateForm formCrear = new AvionCreateForm();
            formCrear.ShowDialog();
        }

        private void btnMostrarAviones_Click(object sender, EventArgs e)
        {
            AvionListForm formListado = new AvionListForm();
            formListado.ShowDialog();
        }

        private void btnEditarAvion_Click(object sender, EventArgs e)
        {
            AvionUpdateForm formModificar = new AvionUpdateForm();
            formModificar.ShowDialog();
        }

        private void btnEliminarAvion_Click(object sender, EventArgs e)
        {
            AvionDeleteForm formEliminar = new AvionDeleteForm();
            formEliminar.ShowDialog();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            _menuAdminForm.Show();  // Regresa al formulario padre que llegó en el constructor (MenuAdminForm)
            this.Close(); 
        }

    }
}