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
    public partial class AvionItemControl : UserControl
    {
        public AvionItemControl(string codigoAsiento)
        {
            InitializeComponent();
            labelCodigoAsiento.Text = codigoAsiento;
            labelCodigoAsiento.Left = (this.ClientSize.Width - labelCodigoAsiento.Width) / 2;
            labelCodigoAsiento.Top = (this.ClientSize.Height - labelCodigoAsiento.Height) / 2;

        }

        private void AvionItemControl_Load(object sender, EventArgs e)
        {
            labelCodigoAsiento.Left = (this.ClientSize.Width - labelCodigoAsiento.Width) / 2;
            labelCodigoAsiento.Top = (this.ClientSize.Height - labelCodigoAsiento.Height) / 2;
        }
    }
}
