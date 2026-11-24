using DTOs;

namespace WindowsForms
{
    public partial class PasajeroDataItemControl : UserControl
    {
        public event EventHandler<PasajeroCreateDTO?>? PasajeroData;
        private PasajeroCreateDTO? _pasajeroCreateDTO;
        private bool _tieneFoco;

        public PasajeroDataItemControl(string nombrePlaceholder)
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
            ActualizarColorVisual();
        }

        public PasajeroCreateDTO? GetPasajero()
        {
            return _pasajeroCreateDTO;
        }

        public void Focus(bool isFocus)
        {
            _tieneFoco = isFocus;
            ActualizarColorVisual();
        }

        private void ActualizarColorVisual()
        {
            if (_pasajeroCreateDTO != null)
            {
                this.BackColor = _tieneFoco ? Color.MediumAquamarine : Color.LightGreen;
            }
            else
            {
                this.BackColor = _tieneFoco ? Color.Honeydew : SystemColors.Control;
            }
        }

        private void PasajeroDataItemControl_Load(object? sender, EventArgs e)
        {
            labelPasajero.Left = (this.ClientSize.Width - labelPasajero.Width) / 2;
            labelPasajero.Top = (this.ClientSize.Height - labelPasajero.Height) / 2;
        }

        private void PasajeroDataItemControl_Click(object? sender, EventArgs e)
        {
            PasajeroData?.Invoke(this, _pasajeroCreateDTO);
        }

        public void EjecutarClick()
        {
            PasajeroData?.Invoke(this, _pasajeroCreateDTO);
        }
    }
}
