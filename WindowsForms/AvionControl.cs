using DTOs;
using System.Drawing.Drawing2D;

namespace WindowsForms
{
    public partial class AvionControl : UserControl
    {
        private static readonly char[] LetrasColumnas = { 'A', 'B', 'C', 'D' };
        private readonly List<AsientoCreateDTO> asientosCreateDTO = new();
        private readonly Dictionary<string, AvionAsientoItemControl> _controlesPorCodigo = new(StringComparer.OrdinalIgnoreCase);

        private AvionAsientoItemControl? _asientoSeleccionadoActual;
        private string? _codigoAsientoActual;

        public event EventHandler<string?>? AsientoCambiado;

        public AvionControl()
        {
            InitializeComponent();
        }

        private void panelAvion_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            float x = panelAvion.Width * 0.05f;
            float y = 10;
            float w = panelAvion.Width * 0.90f;
            float h = Math.Max(panelAvion.Height - 15, 200);

            using var path = new GraphicsPath();

            path.AddBezier(x, y + 70, x, y + 25, x + w * 0.25f, y, x + w / 2, y);
            path.AddBezier(x + w / 2, y, x + w * 0.75f, y, x + w, y + 25, x + w, y + 70);
            path.AddLine(x + w, y + 70, x + w, y + h - 70);
            path.AddBezier(x + w, y + h - 70, x + w, y + h - 25, x + w * 0.75f, y + h, x + w / 2, y + h);
            path.AddBezier(x + w / 2, y + h, x + w * 0.25f, y + h, x, y + h - 25, x, y + h - 70);
            path.AddLine(x, y + h - 70, x, y + 70);
            path.CloseFigure();

            using var fill = new SolidBrush(Color.LightGray);
            using var border = new Pen(Color.DimGray, 2);

            g.FillPath(fill, path);
            g.DrawPath(border, path);
        }

        public List<AsientoCreateDTO> AgregarAsientos(int filas)
        {
            return AgregarAsientos(filas, capacidadMaxima: null);
        }

        public List<AsientoCreateDTO> AgregarAsientos(int filas, int? capacidadMaxima)
        {
            LimpiarAsientos();

            int columnas = LetrasColumnas.Length;
            int seatSize = 30;
            int spacingX = 10;
            int spacingY = 8;

            int gridWidth = columnas * seatSize + (columnas - 1) * spacingX;

            int areaLeft = (int)(panelAvion.Width * 0.20f);
            int areaRight = (int)(panelAvion.Width * 0.80f);
            int areaTop = 75;
            int areaWidth = areaRight - areaLeft;

            int startX = areaLeft + (areaWidth - gridWidth) / 2;
            int startY = areaTop;

            int totalCapacidad = capacidadMaxima ?? (filas * columnas);
            int numeroAsiento = 0;

            for (int filaIdx = 0; filaIdx < filas; filaIdx++)
            {
                char letraFila = (char)('A' + filaIdx);

                for (int colIdx = 0; colIdx < columnas; colIdx++)
                {
                    if (numeroAsiento >= totalCapacidad)
                        return asientosCreateDTO;

                    numeroAsiento++;
                    int nroColumna = colIdx + 1; // 1, 2, 3, 4
                    string codigoBackend = numeroAsiento.ToString(); // "1", "2", "3"...
                    string etiquetaVisible = $"{letraFila}{nroColumna}"; // "A1", "A2", "B1"...

                    int x = startX + colIdx * (seatSize + spacingX);
                    int y = startY + filaIdx * (seatSize + spacingY);

                    asientosCreateDTO.Add(new AsientoCreateDTO
                    {
                        Codigo = codigoBackend,
                        Fila = letraFila,
                        Columna = nroColumna,
                        Estado = "Habilitado"
                    });

                    AgregarAsiento(x, y, codigoBackend, etiquetaVisible);
                }
            }

            return asientosCreateDTO;
        }

        private void AgregarAsiento(int x, int y, string codigoBackend, string etiquetaVisible)
        {
            var asiento = new AvionAsientoItemControl(codigoBackend, etiquetaVisible);
            asiento.Location = new Point(x, y);
            asiento.Size = new Size(30, 30);
            asiento.OnClickGetCodigoAsiento += OnClickSelectAsiento;
            panelAvion.Controls.Add(asiento);
            _controlesPorCodigo[codigoBackend] = asiento;
        }

        private void OnClickSelectAsiento(object? sender, string codigoAsiento)
        {
            if (sender is not AvionAsientoItemControl asientoControl || asientoControl.IsBlocked)
                return;

            if (_asientoSeleccionadoActual != null &&
                _asientoSeleccionadoActual != asientoControl &&
                !_asientoSeleccionadoActual.IsBlocked)
            {
                _asientoSeleccionadoActual.AsientoDisponible();
            }

            _asientoSeleccionadoActual = asientoControl;
            _codigoAsientoActual = asientoControl.AsientoSeleccionado();
            AsientoCambiado?.Invoke(this, _codigoAsientoActual);
        }

        public void SincronizarCroquis(
            IEnumerable<string> ocupadosEnVuelo,
            IEnumerable<string> guardadosPorOtrosPasajeros,
            string? asientoGuardadoPasajeroActual,
            string? asientoTemporalPasajeroActual)
        {
            var setOcupados = new HashSet<string>(ocupadosEnVuelo, StringComparer.OrdinalIgnoreCase);
            var setOtrosGuardados = new HashSet<string>(guardadosPorOtrosPasajeros, StringComparer.OrdinalIgnoreCase);

            _asientoSeleccionadoActual = null;
            _codigoAsientoActual = null;

            foreach (var (codigo, ctrl) in _controlesPorCodigo)
            {
                ctrl.IsBlocked = false;
                ctrl.AsientoDisponible();

                if (setOcupados.Contains(codigo))
                {
                    ctrl.AsientoOcupado();
                    ctrl.IsBlocked = true;
                }
                else if (setOtrosGuardados.Contains(codigo))
                {
                    ctrl.AsientoSeleccionado();
                    ctrl.IsBlocked = true;
                }
            }

            string? codigoActivo = !string.IsNullOrWhiteSpace(asientoTemporalPasajeroActual)
                ? asientoTemporalPasajeroActual.Trim()
                : asientoGuardadoPasajeroActual?.Trim();

            if (!string.IsNullOrWhiteSpace(codigoActivo) &&
                _controlesPorCodigo.TryGetValue(codigoActivo, out var ctrlActivo) &&
                !setOcupados.Contains(codigoActivo))
            {
                ctrlActivo.IsBlocked = false;
                ctrlActivo.AsientoSeleccionado();
                _asientoSeleccionadoActual = ctrlActivo;
                _codigoAsientoActual = codigoActivo;
            }
        }

        public string? GetCodigoAsiento() => _codigoAsientoActual;

        public string? GetEtiquetaPorCodigo(string? codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo)) return null;
            return _controlesPorCodigo.TryGetValue(codigo.Trim(), out var ctrl)
                ? ctrl.GetEtiqueta()
                : codigo;
        }

        public void LimpiarAsientos()
        {
            asientosCreateDTO.Clear();
            _controlesPorCodigo.Clear();
            _codigoAsientoActual = null;
            _asientoSeleccionadoActual = null;

            foreach (var asiento in panelAvion.Controls
                .OfType<AvionAsientoItemControl>()
                .ToList())
            {
                panelAvion.Controls.Remove(asiento);
                asiento.Dispose();
            }
        }
    }
}