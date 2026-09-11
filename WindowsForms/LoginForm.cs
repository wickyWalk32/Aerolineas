using Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs;
using System.Net.Http.Json;

namespace WindowsForms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text.Trim();
            string contrasenia = textBoxPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contrasenia))
            {
                MessageBox.Show("Por favor, ingrese email y contraseña.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7099/") })
                {
                    LoginRequestDTO loginRequestDto = new LoginRequestDTO
                    {
                        Email = email,
                        Contrasenia = contrasenia
                    };

                    HttpResponseMessage response = await httpClient.PostAsJsonAsync("/usuarios/login", loginRequestDto);

                    // Leemos la respuesta como LoginResultDTO (a resultado llega un DTO de Usuario)
                    var resultado = await response.Content.ReadFromJsonAsync<LoginResultDTO>();

                    if (response.IsSuccessStatusCode && resultado != null && resultado.Exitoso)
                    {
                        //MessageBox.Show("¡Bienvenido al sistema!", "Acceso Concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MenuPrincipalForm ventanaMenuPrincipal = new MenuPrincipalForm(this, resultado);
                        ventanaMenuPrincipal.Show();

                        // Ocultamos el formulario de Login actual, sin cerrarlo
                        this.Hide();
                    }
                    else
                    {
                        string mensajeError = resultado?.Mensaje ?? "Acceso denegado.";
                        MessageBox.Show(mensajeError, "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión con la Web API: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        // Cierra la aplicación por completo y libera todos los procesos
        private void btnSalirSistema_Click(object sender, EventArgs e)
        {

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de que desea salir del sistema?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                //Application.Exit();
            }
        }

    }
}
