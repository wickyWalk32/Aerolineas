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
    public partial class ServicioItemControl : UserControl
    {
        
        // Eventos que escuchará el formulario padre (ServicioDetalleF.cs)
        public event EventHandler<ServicioUpdateDTO>? OnEditarClicked;
        public event EventHandler<ServicioDeleteDTO>? OnEliminarClicked;

        private ServicioCargaDTO? _servicioActual;

        public ServicioItemControl()
        {
            InitializeComponent();
        }

        // Método para cargar la información en este ítem visual
        public void CargarDatos(ServicioCargaDTO servicioActual)
        {
            _servicioActual = servicioActual;

            lblId.Text = servicioActual.Id.ToString();
            lblNombre.Text = servicioActual.Nombre;
            lblDescripcion.Text = servicioActual.Descripcion;
            lblPrecio.Text = Convert.ToString(servicioActual.Precio);
        }

        private void btnEditarServicio_Click(object sender, EventArgs e)
        {
            if (_servicioActual != null)
            {

                ServicioUpdateDTO servicioUpdateDto = new ServicioUpdateDTO
                {
                    Id = _servicioActual.Id,
                    Nombre = _servicioActual.Nombre,
                    Descripcion = _servicioActual.Descripcion,
                    Precio = _servicioActual.Precio
                }; 

                OnEditarClicked?.Invoke(this, servicioUpdateDto);
            }
        }

        private void btnEliminarServicio_Click(object sender, EventArgs e)
        {
            if (_servicioActual != null)
            {
                ServicioDeleteDTO servicioDeleteDto = new ServicioDeleteDTO
                {
                    Id = _servicioActual.Id,
                    //Nombre = _servicioActual.Nombre,
                    //Descripcion = _servicioActual.Descripcion,
                    //Precio = _servicioActual.Precio
                }; 
                
                OnEliminarClicked?.Invoke(this, servicioDeleteDto);
            }
        }

    }
}
