using System;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class PasajeroFormCreate : Form
    {
        public PasajeroFormCreate() => InitializeComponent();// CargarDesplegables() ya se llama desde el diseñador en el constructor parcial,// pero puedes descomentar si prefieres llamarlo aquí también:// CargarDesplegables();

        private void PasajeroFormCreate_Load(object? sender, EventArgs e)
        {
            // Inicializaciones adicionales al cargar el formulario (si las necesitas).             
        }
    }
}
