using Domain.Model;
using DTOs;
using System;
using System.Net.Http.Json;
using System.Windows.Forms;
namespace WindowsForms
{
    public partial class AvionAdminMenuForm : Form
    {
        private readonly MenuAdminForm _menuAdminForm;

        // Constructor principal que recibe la referencia de MenuAdminForm

        public AvionAdminMenuForm(MenuAdminForm menuAdminForm)
        {
            InitializeComponent();
            _menuAdminForm = menuAdminForm;
            CargarAviones();
        }

        private async Task CargarAviones()
        {
            flowLayoutPanelAviones.Controls.Clear();
            try
            {
                var aviones = await Program.HttpClient.GetFromJsonAsync<List<AvionDTO>>("/aviones");
                if (aviones != null)
                {
                    foreach (var avion in aviones)
                    {
                        var avionItem = new AvionItemControl();
                        avionItem.CargarDatos(avion);
                        avionItem.EditarAvionClicked += Item_OnEditarAvionClicked;
                        avionItem.EliminarAvionClicked += Item_OnEliminarAvionClicked;
                        this.Controls.Add(avionItem);
                        flowLayoutPanelAviones.Controls.Add(avionItem);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la Web API: {ex.Message}");
            }
        }



        private void Item_OnEditarAvionClicked(object? sender, AvionDTO avion)
        {
            AvionUpdateForm avionForm = new AvionUpdateForm(avion);
            avionForm.FormClosed += async (s, args) =>
            {
                await CargarAviones();
            };
            avionForm.Show();
        }
        private async void Item_OnEliminarAvionClicked(object? sender, AvionDTO avion)
        {
            var confirmacion = MessageBox.Show(
                $"¿Está seguro de que desea eliminar el avion codigo: {avion.Id}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.No)
            {
                return;
            }
                try
            {
                HttpResponseMessage response = await Program.HttpClient.DeleteAsync($"/aviones/{avion.Id}/");
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Avion Eliminado junto con futuros vuelos");
                    await CargarAviones();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la Web API: {ex.Message}");
            }
        }

        private void btnNuevoAvion_Click(object sender, EventArgs e)
        {
            AvionCreateForm formCrear = new AvionCreateForm();
            formCrear.FormClosed += async (s, args) =>
            {
                await CargarAviones();
            };
            formCrear.ShowDialog();
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            _menuAdminForm.Show();  // Regresa al formulario padre que llegó en el constructor (MenuAdminForm)
            this.Close();
        }
    }
}