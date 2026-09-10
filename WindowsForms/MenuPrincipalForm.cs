using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
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

            lblNombreApellido.Text = $"{_usuarioAutenticado.Nombre} {_usuarioAutenticado.Apellido}";
        }
        public MenuPrincipalForm()
        {
            InitializeComponent();

        }

        private void btnAdministrarUsuarios_Click(object sender, EventArgs e)
        {
            AdminUsuariosForm ventanaAdminUsuarios = new AdminUsuariosForm(this);
            ventanaAdminUsuarios.Show();
            this.Hide();
        }

        private void btnAdministrarPaises_Click(object sender, EventArgs e)
        {
            try
            {
                Type tipo = Type.GetType("WindowsForms.AdminPaisesForm, WindowsForms");
                if (tipo != null)
                {
                    Form ventana = (Form)Activator.CreateInstance(tipo, this)!;
                    ventana.Show();
                    this.Hide();
                    return;
                }
            }
            catch { }
            MessageBox.Show("Administración de países no implementada aún.", "No implementado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdministrarCiudades_Click(object sender, EventArgs e)
        {
            try
            {
                Type tipo = Type.GetType("WindowsForms.AdminCiudadesForm, WindowsForms");
                if (tipo != null)
                {
                    Form ventana = (Form)Activator.CreateInstance(tipo, this)!;
                    ventana.Show();
                    this.Hide();
                    return;
                }
            }
            catch { }
            MessageBox.Show("Administración de ciudades no implementada aún.", "No implementado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            _loginForm.Show();
                    this.Close();
        }

        // Nuevo: abre el formulario independiente de administración de pasajeros
        private void btnAdministrarPasajeros_Click(object sender, EventArgs e)
        {
            var ventana = new PasajeroAdminMenuForm(this);
            ventana.Show();
            this.Hide();
        }

        private void btnAdministrarCiudades_Click(object sender, EventArgs e)
        {
            CiudadDetalle ventanaCiudad = new CiudadDetalle(this);
            ventanaCiudad.Show();
            this.Hide();
        }
    }
}
        private void MenuPrincipalForm_Load(object sender, EventArgs e)
        {

        }
    }
}
