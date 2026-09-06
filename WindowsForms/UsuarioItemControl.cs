using Domain.Model;
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
    public partial class UsuarioItemControl : UserControl
    {
        // Eventos que escuchará el formulario padre (UsuarioAMForm.cs)
        public event EventHandler<Usuario>? OnEditarClicked;
        public event EventHandler<Usuario>? OnEliminarClicked;

        private Usuario? _usuarioActual;

        public UsuarioItemControl()
        {
            InitializeComponent();
        }

        // Método para cargar la información en este ítem visual
        public void CargarDatos(Usuario usuario)
        {
            _usuarioActual = usuario;

            lblIdUsuario.Text = usuario.Id.ToString();
            lblNombreApellido.Text = $"{usuario.Nombre} {usuario.Apellido}";
            lblEmail.Text = usuario.Email;
            lblRol.Text = usuario.Rol;
        }

        // Evento del botón Editar del UserControl (hacerle doble clic en el diseñador)
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (_usuarioActual != null)
            {
                OnEditarClicked?.Invoke(this, _usuarioActual);
            }
        }

        // Evento del botón Eliminar del UserControl (hacerle doble clic en el diseñador)
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_usuarioActual != null)
            {
                OnEliminarClicked?.Invoke(this, _usuarioActual);
            }
        }

        // por error
        private void lblIdUsuario_Click(object sender, EventArgs e)
        {

        }

    }
}
