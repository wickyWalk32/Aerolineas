using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class MenuUsuarioBuscarVueloForm : Form
    {
        public MenuUsuarioBuscarVueloForm(UsuarioLoginResultDTO usuarioAutenticado)
        {
            InitializeComponent();
            lblNombreApellido.Text = $"¡Hola, {usuarioAutenticado.Nombre} {usuarioAutenticado.Apellido}!";
        }

        private void btnBuscarVuelos_Click(object sender, EventArgs e)
        {
            // completar
        }

        private void btnSalirDelSistema_Click(object sender, EventArgs e)
        {
            Application.Restart(); // Reinicia la aplicación y vuelve al Login
        }

    }
}
