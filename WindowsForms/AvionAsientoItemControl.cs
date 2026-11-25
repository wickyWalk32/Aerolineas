using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class AvionAsientoItemControl : UserControl
    {
        public event EventHandler<string>? OnClickGetCodigoAsiento;

        private readonly string _codigoBackend; // Ej: "1", "2", "5", "7"
        public bool IsBlocked { get; set; } = false;

        public AvionAsientoItemControl(string codigoBackend, string etiquetaVisible)
        {
            InitializeComponent();
            _codigoBackend = codigoBackend;
            labelCodigoAsiento.Text = etiquetaVisible;
            CentrarLabel();

            Cursor = Cursors.Hand;
            this.Click += AvionAsientoItemControl_Click;
            labelCodigoAsiento.Click += AvionAsientoItemControl_Click;
            AsientoDisponible();
        }

        private void CentrarLabel()
        {
            labelCodigoAsiento.Left = Math.Max(0, (this.ClientSize.Width - labelCodigoAsiento.Width) / 2);
            labelCodigoAsiento.Top = Math.Max(0, (this.ClientSize.Height - labelCodigoAsiento.Height) / 2);
        }

        private void AvionItemControl_Load(object? sender, EventArgs e)
        {
            CentrarLabel();
        }

        private void AvionAsientoItemControl_Click(object? sender, EventArgs e)
        {
            if (!IsBlocked)
            {
                OnClickGetCodigoAsiento?.Invoke(this, _codigoBackend);
            }
        }

        public string GetCodigoAsiento() => _codigoBackend;

        public string GetEtiqueta() => labelCodigoAsiento.Text;

        private void AplicarColor(Color color, Cursor cursor)
        {
            this.BackColor = color;
            labelCodigoAsiento.BackColor = color;
            this.Cursor = cursor;
        }

        public void AsientoOcupado()
        {
            AplicarColor(Color.LightCoral, Cursors.Default);
        }

        public string AsientoSeleccionado()
        {
            AplicarColor(Color.LightGreen, Cursors.Hand);
            return _codigoBackend;
        }

        public void AsientoDisponible()
        {
            AplicarColor(SystemColors.Control, Cursors.Hand);
        }
    }
}
