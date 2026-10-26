using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsForms
{
    public partial class MenuUsuarioBuscarVueloForm : Form
    {
        List<VueloDTO> _vuelos;
        List<VueloDTO> _vuelosFiltrados;

        public MenuUsuarioBuscarVueloForm(UsuarioLoginResultDTO usuarioAutenticado)
        {
            InitializeComponent();
            lblNombreApellido.Text = $"¡Hola, {usuarioAutenticado.Nombre} {usuarioAutenticado.Apellido}!";
            CargarVuelos();
            CargarCiudades();
            //CargarPaisesConCiudades();
        }
        private async Task CargarPaisesConCiudades()
        {
            try
            {
                var paises = await Program.HttpClient.GetFromJsonAsync<List<PaisDTO>>("paises");
            }
            catch (Exception ex)
            {

            }
        }
        private async Task CargarCiudades()
        {
            try
            {
                var ciudades = await Program.HttpClient.GetFromJsonAsync<List<CiudadDTO>>("ciudades");
                foreach (var ciudad in ciudades)
                {
                    comboBoxCiudadOrigen.Items.Add(ciudad.Nombre);
                    comboBoxCiudadDestino.Items.Add(ciudad.Nombre);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la Web API: {ex.Message}");
            }
        }

        private async Task CargarVuelos()
        {
            var vuelos = await Program.HttpClient.GetFromJsonAsync<List<VueloDTO>>("/vuelos");
            if (vuelos == null) { return; }
            _vuelos = vuelos;
            foreach (VueloDTO vuelo in vuelos)
            {
                VueloItemControl vueloItem = new VueloItemControl();
                vueloItem.CargarDatos(vuelo);
                vueloItem.Seleccionable();
                vueloItem.OnVueloSeleccionado += OnVueloSeleccionado =>
                {
                    VueloDTO vueloSeleccionado = OnVueloSeleccionado;
                };
                flowLayoutPanelVuelos.Controls.Add(vueloItem);
            }
        }

        private void btnBuscarVuelos_Click(object sender, EventArgs e)
        {
            // completar
        }

        private void btnSalirDelSistema_Click(object sender, EventArgs e)
        {
            Application.Restart(); // Reinicia la aplicación y vuelve al Login
        }


        private void FiltrarVuelos(object sender, EventArgs e)
        {
            var origen = comboBoxCiudadOrigen.SelectedItem as string;
            var destino = comboBoxCiudadDestino.SelectedItem as string;
            int? capacidad = int.TryParse(comboBoxCantidadPasajeros.SelectedItem?.ToString(), out int valor) ? valor : null;

            _vuelosFiltrados = _vuelos.Where(v =>
                (origen == null || v.CiudadOrigen.Nombre == origen) &&
                (destino == null || v.CiudadDestino.Nombre == destino) &&
                (capacidad == null || v.Capacidad >= capacidad)
            ).ToList();

            flowLayoutPanelVuelos.Controls.Clear();

            labelSinVuelos.Visible = _vuelosFiltrados.Count == 0;

            CargarVuelosEspecificos(_vuelosFiltrados);
        }

        private void CargarVuelosEspecificos(List<VueloDTO> vuelos)
        {
            foreach (VueloDTO vuelo in vuelos)
            {
                VueloItemControl vueloItem = new VueloItemControl();
                vueloItem.CargarDatos(vuelo);
                vueloItem.Seleccionable();
                flowLayoutPanelVuelos.Controls.Add(vueloItem);
            }
        }

    }
}
