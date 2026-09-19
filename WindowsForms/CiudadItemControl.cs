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
    public partial class CiudadItemControl : UserControl
    {

        // Eventos que escuchará el formulario padre (UsuarioAMForm.cs)
        public event EventHandler<CiudadDTO>? OnEditarClicked;
        public event EventHandler<CiudadDTO>? OnEliminarClicked;

        private CiudadDTO? _ciudadActual;

        public CiudadItemControl()
        {
            InitializeComponent();
        }

        // Método para cargar la información en este ítem visual
        public void CargarDatos(CiudadDTO ciudad)
        {
            _ciudadActual = ciudad;

            lblIdCiudad.Text = ciudad.Id.ToString();
            lblNombreCiudad.Text = ciudad.Nombre;
            lblCodigoPostal.Text = ciudad.CodigoPostal;
            lblCodigoAeropuerto.Text = ciudad.CodigoAeropuerto;
            lblPais.Text = ciudad.PaisNombre;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (_ciudadActual != null)
            {
                OnEditarClicked?.Invoke(this, _ciudadActual);
            }
        }

        private void btnEliminarCiudad_Click(object sender, EventArgs e)
        {
            if (_ciudadActual != null)
            {
                OnEliminarClicked?.Invoke(this, _ciudadActual);
            }
        }

        /*private void CiudadItemControl_Load(object sender, EventArgs e)
        {

        }*/

    }
}
