using System;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class MenuAvionesForm : Form
    {
        private readonly MenuAdminForm _menuAdminForm;

        // Constructor por defecto para compatibilidad con el Diseñador Visual
        public MenuAvionesForm()
        {
            InitializeComponent();
            AsignarEventos();
        }

        // Constructor principal que recibe la referencia de MenuAdminForm
        public MenuAvionesForm(MenuAdminForm menuAdminForm) : this()
        {
            _menuAdminForm = menuAdminForm;
        }

        private void AsignarEventos()
        {
            // Vinculación de eventos Click a todos los botones del menú
            btnCrearPasajero.Click += btnCrearAvion_Click;
            btnMostrarPasajeros.Click += btnMostrarAviones_Click;
            btnModificarPasajero.Click += btnModificarPasajero_Click;
            btnEliminarPasajero.Click += btnEliminarAvion_Click;
            btnVolver.Click += btnVolver_Click;
        }

        private void MenuAvionesForm_Load(object sender, EventArgs e)
        {
            // Código de inicialización si fuera necesario
        }

        // 1. Botón "Crear Aviones" (btnCrearPasajero)
        private void btnCrearAvion_Click(object sender, EventArgs e)
        {
            AvionCreateForm formCrear = new AvionCreateForm();
            formCrear.ShowDialog();
        }

        // 2. Botón "Mostrar Aviones" (btnMostrarPasajeros)
        private void btnMostrarAviones_Click(object sender, EventArgs e)
        {
            AvionListForm formListado = new AvionListForm();
            formListado.ShowDialog();
        }

        // 3. Botón "Modificar Aviones" (btnModificarPasajero)
        private void btnModificarPasajero_Click(object sender, EventArgs e)
        {
            AvionUpdateForm formModificar = new AvionUpdateForm();
            formModificar.ShowDialog();
        }

        // 4. Botón "Eliminar Aviones" (btnEliminarPasajero)
        private void btnEliminarAvion_Click(object sender, EventArgs e)
        {
            AvionDeleteForm formEliminar = new AvionDeleteForm();
            formEliminar.ShowDialog();
        }

        // 5. Botón "Volver" (btnVolver)
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close(); // Regresa al formulario padre (MenuAdminForm)
        }
    }
}