using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    // Ventana para el alta y modificación de servicios (reutilizable entre ambos)
    public partial class ServicioDetalleForm : Form
    {
        public ServicioUpdateDTO? ServicioResultado { get; private set; }
        private bool _esEdicion = false;
        private readonly ServicioAdminMenuForm _servicioAdminMenuForm;

        // Constructor para CREAR un nuevo servicio
        public ServicioDetalleForm(ServicioAdminMenuForm servicioAdminMenuForm)
        {
            InitializeComponent();
            _servicioAdminMenuForm = servicioAdminMenuForm;
            lblTituloNuevoEditarServicio.Text = "Nuevo Servicio";
            lblId.Text = "";
            lblIdServicio.Text = "";
        }

        // Constructor para EDITAR una ciudad existente
        public ServicioDetalleForm(ServicioAdminMenuForm servicioAdminMenuForm, ServicioUpdateDTO servicioAEditar)
        {
            InitializeComponent();
            _servicioAdminMenuForm = servicioAdminMenuForm;
            _esEdicion = true;
            lblTituloNuevoEditarServicio.Text = "Editar Servicio";
            ServicioResultado = servicioAEditar;

            // Cargamos los datos actuales del usuario elegido en la pantalla anterior en las cajas de texto
            lblIdServicio.Text = servicioAEditar.Id.ToString();
            textBoxNombre.Text = servicioAEditar.Nombre;
            textBoxDescripcion.Text = servicioAEditar.Descripcion;
            textBoxPrecio.Text = Convert.ToString(servicioAEditar.Precio);
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {

            decimal? precioValidado = ObtenerPrecioDecimalValidado();
            if (precioValidado == null) return; // Frena la ejecución si dio error

            if (!_esEdicion)
            {
                ServicioCreateDTO servicioCreateDto = new ServicioCreateDTO
                {
                    Nombre = textBoxNombre.Text,
                    Descripcion = textBoxDescripcion.Text,
                    Precio = precioValidado.Value
                };

                var response = await Program.HttpClient.PostAsJsonAsync("servicios", servicioCreateDto);

                if (response.IsSuccessStatusCode)
                {
                    ClearForm();
                    MessageBox.Show("Servicio Guardado!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Fallo al guardar el nuevo servicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (_esEdicion)
            {
                ServicioUpdateDTO servicioUpdateDto = new ServicioUpdateDTO
                {
                    Id = Convert.ToInt32(lblIdServicio.Text),
                    Nombre = textBoxNombre.Text,
                    Descripcion = textBoxDescripcion.Text,
                    Precio = precioValidado.Value               // No usar Conver.ToDecimal() xq si ingresan letras se rompe
                };

                var response = await Program.HttpClient.PutAsJsonAsync($"servicios/{servicioUpdateDto.Id}", servicioUpdateDto);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cambios Guardados!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Fallo al editar el servicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Valida que sea tipo decimal, y sirve ya sea que para la parte decimal se use coma o punto.
        private decimal ObtenerPrecioDecimalValidado()
        {
            // 1. Tomamos el texto y reemplazamos la coma por un punto para unificar el criterio
            string textoPrecio = textBoxPrecio.Text.Trim().Replace(',', '.');

            // 2. Parseamos siempre con InvariantCulture (el punto es el separador decimal universal)
            if (decimal.TryParse(textoPrecio, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precioDecimal))
            {
                return precioDecimal;
            }

            // Si no es un número válido
            MessageBox.Show("Por favor, ingrese un precio válido (ej: 152.23 o 152,23).", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            throw new FormatException("Precio inválido.");
        }

        private void ClearForm()
        {
            textBoxNombre.Clear();
            textBoxDescripcion.Clear();
            textBoxPrecio.Clear();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            _servicioAdminMenuForm.Show();
            this.Close();
            _servicioAdminMenuForm.CargarListaServiciosEnItems();
        }

    }
}
