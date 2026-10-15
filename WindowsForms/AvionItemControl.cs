using DTOs;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class AvionItemControl : UserControl
    {
        private AvionDTO? _avionDTO;
        public event EventHandler<AvionDTO>? EditarAvionClicked;
        public event EventHandler<AvionDTO>? EliminarAvionClicked;
        public AvionItemControl()
        {
            InitializeComponent();


        }

        public void CargarDatos(AvionDTO avion)
        {
            _avionDTO = avion;
            toolTipAvion.SetToolTip(this, avion.Descripcion);
            labelId.Text = avion.Id.ToString();
            labelCapacidad.Text = avion.Capacidad.ToString();
            //labelModelo.Text = _avionDTO.Modelo;
            labelEstado.Text = avion.EstadoDisponibilidad;
            //buttonEliminar.FlatAppearance.MouseOverBackColor = Color.Red;
        }

        public void buttonEliminar_Click(object sender, EventArgs e)
        {
            EliminarAvionClicked?.Invoke(this, _avionDTO);
        }
        public void buttonEditar_Click(object sender, EventArgs e)
        {
            EditarAvionClicked?.Invoke(this, _avionDTO);
        }

        private void buttonEditar_MouseEnter(object sender, EventArgs e)
        {
            buttonEditar.ForeColor = Color.LimeGreen;
        }

        private void buttonEliminar_MouseEnter(object sender, EventArgs e)
        {
            buttonEliminar.ForeColor = Color.Red;

        }
        private void button_MouseLeave(object sender, EventArgs e)
        {
            if(sender is Button button)
            {
                button.ForeColor = Color.Black;
            }

        }
    }
}
