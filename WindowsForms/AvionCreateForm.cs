using Domain.Model;
using DTOs;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;
using System.Windows.Forms;
using static WindowsForms.AvionCreateForm;

namespace WindowsForms
{
    public partial class AvionCreateForm : Form
    {
        string[] abc = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        List<AsientoCreateDTO> asientosCreateDTO = new();

        public AvionCreateForm()
        {
            InitializeComponent();
            // Vinculación de eventos Click a los botones
            btnGuardar.Click += btnGuardar_Click;
            btnVolver.Click += btnVolver_Click;

        }

        private void AvionCreateForm_Load(object sender, EventArgs e)
        {
            CargarEstadosDisponibilidad();
        }

        private void CargarEstadosDisponibilidad()
        {
            comboBoxDisponibilidad.Items.Clear();
            comboBoxDisponibilidad.Items.Add("Disponible");
            comboBoxDisponibilidad.Items.Add("En Mantenimiento");
            comboBoxDisponibilidad.Items.Add("Inactivo");
            comboBoxDisponibilidad.SelectedIndex = 0;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validar campo Descripción
            if (string.IsNullOrWhiteSpace(textBoxDescripcion.Text))
            {
                MessageBox.Show("Por favor, ingrese una descripción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validar campo Capacidad
            if (!int.TryParse(textBoxCapacidad.Text, out int capacidad) || capacidad <= 0)
            {
                MessageBox.Show("Ingrese un número válido mayor a 0 en Capacidad.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(asientosCreateDTO.Count == 0)
            {
                MessageBox.Show("Debe ingresar los asientos del avion.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Crear el DTO para el POST
            var nuevoAvion = new AvionCreateDTO
            {
                Descripcion = textBoxDescripcion.Text.Trim(),
                Capacidad = capacidad,
                EstadoDisponibilidad = comboBoxDisponibilidad.SelectedItem?.ToString() ?? "Disponible",
                AsientosCreateDTO = asientosCreateDTO
            };

            // 4. Enviar datos a la API (.NET 8)
            try
            {
                btnGuardar.Enabled = false;

                HttpResponseMessage response = await Program.HttpClient.PostAsJsonAsync("aviones", nuevoAvion);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("¡Avión creado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    string errorMsg = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error en la API ({response.StatusCode}): {errorMsg}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo conectar con el servidor API: {ex.Message}", "Error de red", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardar.Enabled = true;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelAvion_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            float x = panelAvion.Width * 0.05f;
            float y = 10;
            float w = panelAvion.Width * 0.75f;
            float h = panelAvion.Height - 10;

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
        private void AgregarAsientos(float x, float y)
        {
            y = y + 50;
            x = x - 35;
            var positionX = x;
            var positionY = y;

            var filas = int.TryParse(comboBoxFilas.Text.Trim(), out int value) ? value : 0;
            var capacidad = int.TryParse(textBoxCapacidad.Text, out int cap) ? cap : 0;
            string codigo;
            char fila;
            for (var i = 0; i < filas; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    positionX = positionX + 10 + 35;
                    fila = abc[j][0];
                    codigo = fila+(i+1).ToString();
                    //asientosCreateDTO.Add(new AsientoCreateDTO(codigo, fila, i+1, "Habilitado"));
                    asientosCreateDTO.Add(new AsientoCreateDTO { Codigo = codigo, Fila = fila, Columna = i + 1, Estado = "Habilitado" });
                    AgregarAsiento((int)positionX, (int)y, i, j, codigo);
                }
                y = y + 5 + 35;
                positionX = x;
            }
        }

        private void textBoxCapacidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void AgregarAsiento(int x, int y, int fila, int columna, string codAsiento)
        {
            var asiento = new AvionItemControl(codAsiento);
            asiento.Location = new Point(x, y);
            asiento.Size = new Size(30, 30);
            panelAvion.Controls.Add(asiento);
        }

        private void comboBoxFilas_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarAsientos();
            float x = panelAvion.Width * 0.1f;
            float y = 10;
            AgregarAsientos(x, y);
        }

        private void LimpiarAsientos()
        {
            asientosCreateDTO.Clear();

            foreach (var asiento in panelAvion.Controls
            .OfType<AvionItemControl>()
            .ToList())
            {
                panelAvion.Controls.Remove(asiento);
                asiento.Dispose();
            }
        }
    }
}