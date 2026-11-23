using DTOs;

namespace WindowsForms
{
    public partial class PaisItemControl : UserControl
    {
        public event EventHandler<PaisUpdateDTO>? OnEditarClicked;
        public event EventHandler<PaisDTO>? OnEliminarClicked;

        private PaisDTO? _paisActual;

        public PaisItemControl()
        {
            InitializeComponent();
        }

        public void CargarDatos(PaisDTO paisActual)
        {
            _paisActual = paisActual;
            lblId.Text = paisActual.Id.ToString();
            lblNombre.Text = paisActual.Nombre;
        }

        private void btnEditarPais_Click(object? sender, EventArgs e)
        {
            if (_paisActual == null) return;

            var paisUpdateDto = new PaisUpdateDTO
            {
                Id = _paisActual.Id,
                Nombre = _paisActual.Nombre
            };

            OnEditarClicked?.Invoke(this, paisUpdateDto);
        }

        private void btnEliminarPais_Click(object? sender, EventArgs e)
        {
            if (_paisActual == null) return;
            OnEliminarClicked?.Invoke(this, _paisActual);
        }
    }
}
/*using System;
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
    public partial class PaisItemControl : UserControl
    {
        public PaisItemControl()
        {
            InitializeComponent();
        }
    }
}*/
