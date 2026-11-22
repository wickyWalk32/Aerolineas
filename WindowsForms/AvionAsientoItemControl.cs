using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class AvionAsientoItemControl : UserControl
    {
        public event EventHandler<string> OnClickGetCodigoAsiento;
        AsientoDTO _asiento;
        public bool IsBlocked = false;
        public AvionAsientoItemControl(string codigoAsiento)
        {
            InitializeComponent();
            labelCodigoAsiento.Text = codigoAsiento;
            labelCodigoAsiento.Left = (this.ClientSize.Width - labelCodigoAsiento.Width) / 2;
            labelCodigoAsiento.Top = (this.ClientSize.Height - labelCodigoAsiento.Height) / 2;
            Cursor = Cursors.Hand;
            this.Click += AvionAsientoItemControl_Click;
            labelCodigoAsiento.Click += AvionAsientoItemControl_Click;
        }

        private void AvionItemControl_Load(object sender, EventArgs e)
        {
            labelCodigoAsiento.Left = (this.ClientSize.Width - labelCodigoAsiento.Width) / 2;
            labelCodigoAsiento.Top = (this.ClientSize.Height - labelCodigoAsiento.Height) / 2;
        }

        private void AvionAsientoItemControl_Click(object sender, EventArgs e)
        {
            OnClickGetCodigoAsiento?.Invoke(this, labelCodigoAsiento.Text);
        }
        public string GetCodigoAsiento()
        {
            return labelCodigoAsiento.Text;
        }

        public void AsientoOcupado()
        {
            this.BackColor = Color.LightCoral;
            labelCodigoAsiento.BackColor = Color.LightCoral;
            this.Cursor = Cursors.Default;
        }

        public string AsientoSeleccionado()
        {
            this.BackColor = Color.LightGreen;
            this.Cursor = Cursors.Hand;
            return labelCodigoAsiento.Text;
        }
        public void AsientoDisponible()
        {
            this.BackColor = SystemColors.Control;
            this.Cursor = Cursors.Hand;
        }
    }
}
