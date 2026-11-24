using DTOs;
using System.Drawing.Drawing2D;

namespace WindowsForms
{
    public partial class AvionControl : UserControl
    {
        private static readonly char[] LetrasColumnas = { 'A', 'B', 'C', 'D' };
        private readonly List<AsientoCreateDTO> asientosCreateDTO = new();
        private AvionAsientoItemControl? _asientoSeleccionadoActual;
        private string? _codigoAsientoActual;

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

            int creados = 0;

            for (int filaIdx = 0; filaIdx < filas; filaIdx++)
            {
                int nroFila = filaIdx + 1;

                for (int colIdx = 0; colIdx < columnas; colIdx++)
                {
                    if (capacidadMaxima.HasValue && creados >= capacidadMaxima.Value)
                    {
                        return asientosCreateDTO;
                    }

                    char letra = LetrasColumnas[colIdx];
                    string codigo = $"{nroFila}{letra}";

                    int x = startX + colIdx * (seatSize + spacingX);
                    int y = startY + filaIdx * (seatSize + spacingY);

                    asientosCreateDTO.Add(new AsientoCreateDTO
                    {
                        Codigo = codigo,
                        Fila = letra,
                        Columna = nroFila,
                        Estado = "Habilitado"
                    });

                    AgregarAsiento(x, y, codigo);
                    creados++;
                }
            }

            return asientosCreateDTO;
        }

        private void AgregarAsiento(int x, int y, string codAsiento)
        {
            var asiento = new AvionAsientoItemControl(codAsiento);
            asiento.Location = new Point(x, y);
            asiento.Size = new Size(30, 30);
            asiento.OnClickGetCodigoAsiento += OnClickSelectAsiento;
            panelAvion.Controls.Add(asiento);
        }

        private void OnClickSelectAsiento(object? sender, string codigoAsiento)
        {
            if (sender is not AvionAsientoItemControl asientoControl || asientoControl.IsBlocked)
                return;

            // Si había otro asiento temporalmente seleccionado (no guardado), lo devolvemos a disponible
            if (_asientoSeleccionadoActual != null &&
                _asientoSeleccionadoActual != asientoControl &&
                !_asientoSeleccionadoActual.IsBlocked)
            {
                _asientoSeleccionadoActual.AsientoDisponible();
            }

            _asientoSeleccionadoActual = asientoControl;
            _codigoAsientoActual = asientoControl.AsientoSeleccionado();
        }

        public void PrepararParaNuevoPasajero(string? codigoAsientoPrevio)
        {
            // Limpiamos selección temporal no guardada
            if (_asientoSeleccionadoActual != null && !_asientoSeleccionadoActual.IsBlocked)
            {
                _asientoSeleccionadoActual.AsientoDisponible();
            }

            _asientoSeleccionadoActual = null;
            _codigoAsientoActual = null;

            if (!string.IsNullOrWhiteSpace(codigoAsientoPrevio))
            {
                AsientoSeleccionado(codigoAsientoPrevio);
            }
        }

        public void AsientoSeleccionado(string codigoAsiento)
        {
            foreach (AvionAsientoItemControl asiento in panelAvion.Controls
                         .OfType<AvionAsientoItemControl>())
            {
                if (string.Equals(codigoAsiento, asiento.GetCodigoAsiento(), StringComparison.OrdinalIgnoreCase))
                {
                    asiento.IsBlocked = false;
                    asiento.AsientoSeleccionado();
                    asiento.OnClickGetCodigoAsiento -= OnClickSelectAsiento;
                    asiento.OnClickGetCodigoAsiento += OnClickSelectAsiento;
                    _asientoSeleccionadoActual = asiento;
                    _codigoAsientoActual = asiento.GetCodigoAsiento();
                }
            }
        }

        public void SeleccionAsientoGuardado(string codigoAsiento)
        {
            foreach (AvionAsientoItemControl asiento in panelAvion.Controls
                         .OfType<AvionAsientoItemControl>())
            {
                if (string.Equals(codigoAsiento, asiento.GetCodigoAsiento(), StringComparison.OrdinalIgnoreCase))
                {
                    asiento.AsientoSeleccionado();
                    asiento.IsBlocked = true;
                    asiento.Cursor = Cursors.Default;
                    asiento.OnClickGetCodigoAsiento -= OnClickSelectAsiento;
                }
            }

            // Reseteamos la selección temporal para el siguiente pasajero
            _asientoSeleccionadoActual = null;
            _codigoAsientoActual = null;
        }

        public string? GetCodigoAsiento()
        {
            return _codigoAsientoActual;
        }

        public void MarcarAsientosOcupados(List<string> asientosOcupados)
        {
            HashSet<string> ocupados = new HashSet<string>(
                asientosOcupados,
                StringComparer.OrdinalIgnoreCase
            );

            foreach (AvionAsientoItemControl asiento in panelAvion.Controls
                         .OfType<AvionAsientoItemControl>())
            {
                if (ocupados.Contains(asiento.GetCodigoAsiento()))
                {
                    asiento.AsientoOcupado();
                    asiento.IsBlocked = true;
                    asiento.OnClickGetCodigoAsiento -= OnClickSelectAsiento;
                }
            }
        }

        public void LimpiarAsientos()
        {
            asientosCreateDTO.Clear();
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
