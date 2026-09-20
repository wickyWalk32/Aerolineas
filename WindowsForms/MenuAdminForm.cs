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
using DTOs;

namespace WindowsForms
{
    public partial class MenuAdminForm : Form
    {

        // Constructor: se ejecuta al cargar la ventana
        public MenuAdminForm(UsuarioLoginResultDTO usuarioAutenticado)
        {
            InitializeComponent();
            lblNombreApellido.Text = $"{usuarioAutenticado.Nombre} {usuarioAutenticado.Apellido}";
        }

        private void btnAdministrarUsuarios_Click(object sender, EventArgs e)
        {
            UsuarioAdminMenuForm ventanaAdminUsuarios = new UsuarioAdminMenuForm(this);
            ventanaAdminUsuarios.Show();
            this.Hide();
        }

        private void btnAdministrarCiudades_Click(object sender, EventArgs e)
        {
            CiudadAdminMenuForm ventanaAdminCiudades = new CiudadAdminMenuForm(this);
            ventanaAdminCiudades.Show();
            this.Hide();
        }

        private void btnAdministrarPasajeros_Click(object sender, EventArgs e)
        {
            var ventana = new PasajeroAdminMenuForm(this);
            ventana.Show();
            this.Hide();
        }

        private void btnSalirDelSistema_Click(object sender, EventArgs e)
        {
            Application.Restart(); // Reinicia la aplicación y vuelve al Login
        }
    }
}

