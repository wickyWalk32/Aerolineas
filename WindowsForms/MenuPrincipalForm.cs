using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.Model;
using DTOs;

namespace WindowsForms
{
    public partial class MenuPrincipalForm : Form
    {

        // Para reabrir la ventana de Login salir del sistema.
        private readonly LoginForm _loginForm;

        // Tambien recibe el usuario autenticado / logueado
        private readonly LoginResultDTO _usuarioAutenticado;

        // Constructor: se ejecuta al cargar la ventana
        // Recibe la instancia original de LoginForm y carga la ventana de login al salir
        public MenuPrincipalForm(LoginForm loginForm, LoginResultDTO usuario)
        {
            InitializeComponent();
            _loginForm = loginForm;
            _usuarioAutenticado = usuario;

            // Cargamos el nombre completo en la etiqueta al iniciar el formulario
            // Observar que reconoce la etiqueta que pusimos en el diseñador. Accedemos a la propiedad Text.
            lblNombreApellido.Text = $"{_usuarioAutenticado.Nombre} {_usuarioAutenticado.Apellido}";

        }
        public MenuPrincipalForm()
        {
            InitializeComponent();

        }

        private void btnAdministrarUsuarios_Click(object sender, EventArgs e)
        {
            // Pasamos 'this' (MenuPrincipalForm) para poder regresar después
            AdminUsuariosForm ventanaAdminUsuarios = new AdminUsuariosForm(this);
            ventanaAdminUsuarios.Show();

            // Ocultamos el menú principal
            this.Hide();
        }

        /*
         * Botones para ir a ventanas de administración de ciudades y de paises: Windows Forms todavia no creados
         * 
        private void btnAdministrarPaises_Click(object sender, EventArgs e)
        {
            // Pasamos 'this' (MenuPrincipalForm) para poder regresar después
            AdminPaisesForm ventanaAdminPaises = new AdminPaisesForm(this);
            ventanaAdminPaises.Show();

            // Ocultamos el menú principal
            this.Hide();
        }

        private void btnAdministrarCiudades_Click(object sender, EventArgs e)
        {
            // Pasamos 'this' (MenuPrincipalForm) para poder regresar después
            AdminCiudadesForm ventanaAdminCiudades = new AdminCiudadesForm(this);
            ventanaAdminCiudades.Show();

            // Ocultamos el menú principal
            this.Hide();
        }
        */

        // Este boton cierra la sesión: vuelve a la ventana de Login
        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Volvemos a mostrar la pantalla de Login que ya existe
            _loginForm.Show();

            // Destruimos / Cerramos el menú actual
            this.Close();
        }

        private void btnAdministrarCiudades_Click(object sender, EventArgs e)
        {
            CiudadDetalle ventanaCiudad = new CiudadDetalle(this);
            ventanaCiudad.Show();
            this.Hide();
        }
    }
}
