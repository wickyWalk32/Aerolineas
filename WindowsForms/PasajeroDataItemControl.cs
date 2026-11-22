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
    public partial class PasajeroDataItemControl : UserControl
    {
        public event EventHandler<PasajeroCreateDTO> PasajeroData;
        PasajeroCreateDTO _pasajeroCreateDTO;
        public PasajeroDataItemControl( string nombrePlaceholder)
        {
            InitializeComponent();
            labelPasajero.Text = nombrePlaceholder;
            labelPasajero.Click += PasajeroDataItemControl_Click;
            labelPasajero.Left = (this.ClientSize.Width - labelPasajero.Width) / 2;
            labelPasajero.Top = (this.ClientSize.Height - labelPasajero.Height) / 2;
            Cursor = Cursors.Hand;
        }

        public void SetPasajero(PasajeroCreateDTO pasajeroCreateDTO)
        {
            _pasajeroCreateDTO = pasajeroCreateDTO;
            this.BackColor = Color.LightGreen;
        }
        public PasajeroCreateDTO GetPasajero()
        {
            return _pasajeroCreateDTO;
        }

        public void Focus(bool isFocus)
        {
            if (isFocus)
            {
                this.BackColor = Color.Honeydew;
            }
            else
            {
                this.BackColor = SystemColors.Control;
            }
        }
        private void PasajeroDataItemControl_Load(object sender, EventArgs e)
        {
            labelPasajero.Left = (this.ClientSize.Width - labelPasajero.Width) / 2;
            labelPasajero.Top = (this.ClientSize.Height - labelPasajero.Height) / 2;
        }

        private void PasajeroDataItemControl_Click(object sender, EventArgs e)
        {
            PasajeroCreateDTO pasajeroData = _pasajeroCreateDTO;
            PasajeroData?.Invoke(this, pasajeroData);
        }
        public void EjecutarClick()
        {
            PasajeroData?.Invoke(this, _pasajeroCreateDTO);
        }
    }
}
