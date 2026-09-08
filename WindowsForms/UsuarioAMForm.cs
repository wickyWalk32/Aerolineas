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
    // Ventana para el alta y modificación de usuarios (reutilizable entre ambos)
    public partial class UsuarioAMForm : Form
    {
        public Usuario? UsuarioResultado { get; private set; }
        private bool _esEdicion = false;

        // Recibo y guardo la ventana de Administrar usuarios para abrirla al cerrar el alta / modif de usu
        private readonly AdminUsuariosForm _ventanaAdminUsuarios;

        /* Dos constructores: depende cual se llama, es la ventana que se carga: nuevo / editar. */
        
        // Constructor para nuevo usuario
        public UsuarioAMForm(AdminUsuariosForm ventanaAdminUsuarios)
        {
            InitializeComponent();
            CargarComboRoles();
            lblTituloNuevoEditarUsuario.Text = "Nuevo Usuario";
            lblIdUsuario.Text = "";
            _ventanaAdminUsuarios = ventanaAdminUsuarios;
        }

        // Constructor con parámetro (para EDITAR usuario)
        public UsuarioAMForm(AdminUsuariosForm ventanaAdminUsuarios, Usuario usuarioAEditar) : this(ventanaAdminUsuarios)
        {
            _esEdicion = true;
            lblTituloNuevoEditarUsuario.Text = "Editar Usuario";
            UsuarioResultado = usuarioAEditar;

            // Cargamos los datos actuales del usuario elegido en la pantalla anterior en las cajas de texto
            lblIdUsuario.Text = usuarioAEditar.Id.ToString();
            textBoxNombre.Text = usuarioAEditar.Nombre;
            textBoxApellido.Text = usuarioAEditar.Apellido;
            textBoxEmail.Text = usuarioAEditar.Email;
            comboBoxRol.SelectedItem = usuarioAEditar.Rol;
        }

        private void CargarComboRoles()
        {
            comboBoxRol.Items.Clear();
            comboBoxRol.Items.Add("admin");
            comboBoxRol.Items.Add("usuario");
            comboBoxRol.SelectedIndex = 0;
        }

        // Guardar nuevo usuario
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validaciones básicas
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text) ||
                string.IsNullOrWhiteSpace(textBoxApellido.Text) ||
                string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show("Por favor complete los campos obligatorios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_esEdicion)
            {
                UsuarioResultado = new Usuario();
            }

            // 2. Asignamos las propiedades desde los campos del formulario
            UsuarioResultado!.Nombre = textBoxNombre.Text;
            UsuarioResultado.Apellido = textBoxApellido.Text;
            UsuarioResultado.Email = textBoxEmail.Text;
            UsuarioResultado.Rol = comboBoxRol.SelectedItem?.ToString() ?? "usuario";

            // 3. Establecemos el resultado y cerramos el diálogo
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // ?
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // por error
        private void lblRol_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            _ventanaAdminUsuarios.Show();
            this.Close();
        }

        // por error
        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
