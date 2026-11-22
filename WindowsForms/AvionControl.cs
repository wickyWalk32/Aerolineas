using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace WindowsForms
{
    public partial class AvionControl : UserControl
    {
        string[] abc = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        List<AsientoCreateDTO> asientosCreateDTO = new();
        AvionAsientoItemControl _asientoControl;
        string _codigoAsientoActual;
        public AvionControl()
        {
            InitializeComponent();
        }
        private void panelAvion_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            float x = panelAvion.Width * 0.05f;
            float y = 10;
            float w = panelAvion.Width * 0.90f;
            float h = panelAvion.Height - 15;

            using var path = new GraphicsPath();

            // Nose
            path.AddBezier(
                x, y + 70,
                x, y + 25,
                x + w * 0.25f, y,
                x + w / 2, y
            );

            path.AddBezier(
                x + w / 2, y,
                x + w * 0.75f, y,
                x + w, y + 25,
                x + w, y + 70
            );

            // Right side
            path.AddLine(x + w, y + 70, x + w, y + h - 70);

            // Tail
            path.AddBezier(
                x + w, y + h - 70,
                x + w, y + h - 25,
                x + w * 0.75f, y + h,
                x + w / 2, y + h
            );

            path.AddBezier(
                x + w / 2, y + h,
                x + w * 0.25f, y + h,
                x, y + h - 25,
                x, y + h - 70
            );

            // Left side
            path.AddLine(x, y + h - 70, x, y + 70);

            path.CloseFigure();

            using var fill = new SolidBrush(Color.LightGray);
            using var border = new Pen(Color.DimGray, 2);

            g.FillPath(fill, path);
            g.DrawPath(border, path);


        }
        public List<AsientoCreateDTO> AgregarAsientos(int filas)
        {
            LimpiarAsientos();

            int columnas = 4;

            int seatSize = 30;
            int spacingX = 10;
            int spacingY = 10;

            int gridWidth = columnas * seatSize + (columnas - 1) * spacingX;
            int gridHeight = filas * seatSize + (filas - 1) * spacingY;

            // Area available inside the plane
            int areaLeft = (int)(panelAvion.Width * 0.20f);
            int areaRight = (int)(panelAvion.Width * 0.80f);

            int areaTop = 70;
            int areaBottom = panelAvion.Height - 70;

            int areaWidth = areaRight - areaLeft;
            int areaHeight = areaBottom - areaTop;

            // Center the grid
            int startX = areaLeft + (areaWidth - gridWidth) / 2;
            int startY = areaTop + (areaHeight - gridHeight) / 2;

            for (int fila = 0; fila < filas; fila++)
            {
                for (int columna = 0; columna < columnas; columna++)
                {
                    int x = startX + columna * (seatSize + spacingX);
                    int y = startY + fila * (seatSize + spacingY);

                    string codigo = $"{abc[columna]}{fila + 1}";

                    asientosCreateDTO.Add(new AsientoCreateDTO
                    {
                        Codigo = codigo,
                        Fila = abc[columna][0],
                        Columna = fila + 1,
                        Estado = "Habilitado"
                    });

                    AgregarAsiento(x, y, fila, columna, codigo);
                }
            }
            return asientosCreateDTO;
        }

        private void textBoxCapacidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void AgregarAsiento(int x, int y, int fila, int columna, string codAsiento)
        {
            var asiento = new AvionAsientoItemControl(codAsiento);
            asiento.Location = new Point(x, y);
            asiento.Size = new Size(30, 30);
            asiento.OnClickGetCodigoAsiento += OnClickSelectAsiento;
            panelAvion.Controls.Add(asiento);
        }

        private void OnClickSelectAsiento(object sender, string codigoAsiento)
        {
            AvionAsientoItemControl asientoControl = sender as AvionAsientoItemControl;
            if (_codigoAsientoActual!=null && _codigoAsientoActual != codigoAsiento &&
                _asientoControl.IsBlocked == false)
            {
                _asientoControl.AsientoDisponible();
            }
            _asientoControl = asientoControl;
           _codigoAsientoActual = _asientoControl.AsientoSeleccionado();
        }
        public void AsientoSeleccionado(string codigoAsiento)
        {
            foreach (AvionAsientoItemControl asiento in panelAvion.Controls
                         .OfType<AvionAsientoItemControl>())
            {
                if (codigoAsiento == asiento.GetCodigoAsiento())
                {
                    asiento.AsientoDisponible(); 
                    asiento.AsientoSeleccionado();
                    asiento.OnClickGetCodigoAsiento += OnClickSelectAsiento;
                    _asientoControl.IsBlocked = false;
                    asiento.Cursor = Cursors.Hand;
                }
            }
        }
        public void SeleccionAsientoGuardado(string codigoAsiento)
        {
            foreach (AvionAsientoItemControl asiento in panelAvion.Controls
                         .OfType<AvionAsientoItemControl>())
            {
                if (codigoAsiento == asiento.GetCodigoAsiento())
                {
                    asiento.AsientoSeleccionado();
                    asiento.OnClickGetCodigoAsiento -= OnClickSelectAsiento;
                    _asientoControl.IsBlocked = true;
                    asiento.Cursor = Cursors.Default;
                    //if (_pasajero!=null && _pasajero == pasajero) _asientoControl.IsBlocked = false ;
                    //_pasajero = pasajero;
                }
            }
        }
        public string GetCodigoAsiento()
        {
            return _codigoAsientoActual;
        }

        private void comboBoxFilas_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarAsientos();
            float x = panelAvion.Width * 0.1f;
            float y = 10;
            if (sender is ComboBox comboBox &&
                int.TryParse(comboBox.Text, out int filas))
            {
                AgregarAsientos(filas);
            }
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
                if (ocupados.Contains(asiento.GetCodigoAsiento() ) )
                {
                    asiento.AsientoOcupado();
                    asiento.OnClickGetCodigoAsiento -= OnClickSelectAsiento;
                }
            }
        }

        public void LimpiarAsientos()
        {
            asientosCreateDTO.Clear();

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

