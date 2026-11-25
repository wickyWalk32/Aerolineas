using DTOs;
using System.Net.Http.Json;
using System.Text;

namespace WindowsForms
{
    /*
     Acá validamos los campos de la tarjeta, extraemos los últimos 4 dígitos (UltimosCuatroDigitos), parseamos MM/AA a 
    DateTime UTC, armamos ReservaCreateDTO con Pasajes y ServicioIds de cada pasajero, enviamos el POST /reservas, 
    guardamos ReservaConfirmada en _estado y abrimos la cuarta y última ventana (DetalleReservaForm).
     */
    public partial class PagoTarjetaForm : Form
    {
        private readonly Form _formAnterior;
        private readonly ReservaProcesoState _estado;
        private List<ServicioCargaDTO> _serviciosDisponibles = new();
        private decimal _totalCalculado;

        public PagoTarjetaForm(Form formAnterior, ReservaProcesoState estado)
        {
            InitializeComponent();
            _formAnterior = formAnterior;
            _estado = estado;

            comboBoxTipoTarjeta.SelectedIndex = 0;
            _ = CargarResumenYServiciosAsync();
        }

        private async Task CargarResumenYServiciosAsync()
        {
            try
            {
                var servicios = await Program.HttpClient
                    .GetFromJsonAsync<List<ServicioCargaDTO>>("servicios");
                _serviciosDisponibles = servicios ?? new List<ServicioCargaDTO>();
            }
            catch
            {
                _serviciosDisponibles = new List<ServicioCargaDTO>();
            }

            string origen = _estado.Vuelo?.CiudadOrigen?.Nombre ?? "";
            string destino = _estado.Vuelo?.CiudadDestino?.Nombre ?? "";
            lblResumenVuelo.Text = $"Vuelo: {origen} - {destino} ({_estado.Vuelo?.Aerolinea})";

            var sb = new StringBuilder();
            decimal totalServicios = 0m;

            for (int i = 0; i < _estado.Pasajeros.Count; i++)
            {
                var p = _estado.Pasajeros[i];
                _estado.ServiciosPorPasajero.TryGetValue(i, out var idsSrv);
                idsSrv ??= new List<int>();

                var servsElegidos = _serviciosDisponibles
                    .Where(s => idsSrv.Contains(s.Id))
                    .ToList();

                foreach (var s in servsElegidos)
                    totalServicios += s.Precio;

                string textoServicios = servsElegidos.Count > 0
                    ? string.Join(", ", servsElegidos.Select(s => $"{s.Nombre} (${s.Precio:N2})"))
                    : "Ninguno";

                string etiquetaAsiento = FormatearEtiquetaAsiento(p.CodigoAsiento);

                sb.AppendLine($"• {p.Nombre} {p.Apellido} ({p.Tipo}) - Asiento {etiquetaAsiento}");
                sb.AppendLine($"  Servicios: {textoServicios}");
                sb.AppendLine();
            }

            richTextBoxDetallePasajeros.Text = sb.ToString();

            decimal totalVuelos = (_estado.Vuelo?.Precio ?? 0m) * _estado.Pasajeros.Count;
            _totalCalculado = totalVuelos + totalServicios;

            lblTotalPagar.Text = $"Total a pagar: $ {_totalCalculado:N2}";
            btnConfirmarPago.Text = $"Confirmar Pago ($ {_totalCalculado:N2})";
        }

        private async void btnConfirmarPago_Click(object? sender, EventArgs e)
        {
            string titular = textBoxTitular.Text.Trim();
            string numeroTarjeta = textBoxNumeroTarjeta.Text.Trim();
            string vencimiento = textBoxVencimiento.Text.Trim();
            string cvv = textBoxCvv.Text.Trim();

            if (string.IsNullOrWhiteSpace(titular) ||
                string.IsNullOrWhiteSpace(numeroTarjeta) ||
                string.IsNullOrWhiteSpace(vencimiento) ||
                string.IsNullOrWhiteSpace(cvv))
            {
                MessageBox.Show(
                    "Complete todos los datos de la tarjeta para confirmar la reserva.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string digitos = new string(numeroTarjeta.Where(char.IsDigit).ToArray());
            if (digitos.Length < 4)
            {
                MessageBox.Show(
                    "Ingrese un número de tarjeta válido (al menos 4 dígitos).",
                    "Tarjeta inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string ultimos4 = digitos.Substring(digitos.Length - 4);
            DateTime fechaVenc = ParsearVencimientoUtc(vencimiento);

            _estado.UltimosCuatroDigitos = ultimos4;
            _estado.FechaVencimientoTarjeta = fechaVenc;

            var pasajesDto = new List<PasajeCreateDTO>();
            int idAvion = _estado.Vuelo?.Avion?.Id ?? 0;

            for (int i = 0; i < _estado.Pasajeros.Count; i++)
            {
                var pasajero = _estado.Pasajeros[i];
                _estado.ServiciosPorPasajero.TryGetValue(i, out var idsSrv);
                string codigoAsientoLimpio = (pasajero.CodigoAsiento ?? string.Empty).Trim();

                pasajesDto.Add(new PasajeCreateDTO
                {
                    Estado = "Emitido",
                    IdAvion = idAvion,
                    CodigoAsiento = codigoAsientoLimpio,
                    Pasajero = new PasajeroCreateDTO
                    {
                        Nombre = pasajero.Nombre.Trim(),
                        Apellido = pasajero.Apellido.Trim(),
                        Tipo = pasajero.Tipo,
                        NroDocumento = pasajero.NroDocumento.Trim(),
                        TipoDocumento = pasajero.TipoDocumento,
                        CodigoAsiento = codigoAsientoLimpio
                    },
                    ServicioIds = idsSrv?.ToList() ?? new List<int>()
                });
            }

            var reservaPayload = new ReservaCreateDTO
            {
                UsuarioId = _estado.Usuario.Id,
                VueloId = _estado.Vuelo.Id,
                FechaHoraReserva = DateTime.UtcNow,
                UltimosCuatroDigitos = ultimos4,
                FechaVencimientoTarjeta = fechaVenc,
                Pasajes = pasajesDto
            };

            try
            {
                btnConfirmarPago.Enabled = false;
                btnAtras.Enabled = false;

                var response = await Program.HttpClient.PostAsJsonAsync("reservas", reservaPayload);
                if (!response.IsSuccessStatusCode)
                {
                    string detalleError = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(
                        $"No se pudo registrar la reserva: {detalleError}",
                        "Error al reservar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                try
                {
                    _estado.ReservaConfirmada = await response.Content.ReadFromJsonAsync<ReservaDTO>();
                }
                catch
                {
                    _estado.ReservaConfirmada = null;
                }

                var formDetalle = new DetalleReservaForm(_estado, _serviciosDisponibles, _totalCalculado);
                formDetalle.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al confirmar la reserva: {ex.Message}");
            }
            finally
            {
                if (!IsDisposed)
                {
                    btnConfirmarPago.Enabled = true;
                    btnAtras.Enabled = true;
                }
            }
        }

        private static string FormatearEtiquetaAsiento(string? codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return "";

            string limpio = codigo.Trim();
            if (int.TryParse(limpio, out int nro) && nro > 0)
            {
                int filaIdx = (nro - 1) / 4;
                int colNum = ((nro - 1) % 4) + 1;
                char filaLetra = (char)('A' + filaIdx);
                return $"{filaLetra}{colNum}";
            }

            return limpio;
        }

        private static DateTime ParsearVencimientoUtc(string vencimiento)
        {
            var partes = vencimiento.Split('/', StringSplitOptions.TrimEntries);
            if (partes.Length == 2 &&
                int.TryParse(partes[0], out int mes) && mes is >= 1 and <= 12 &&
                int.TryParse(partes[1], out int anioCorto))
            {
                int anioCompleto = anioCorto < 100 ? 2000 + anioCorto : anioCorto;
                return new DateTime(anioCompleto, mes, 1, 0, 0, 0, DateTimeKind.Utc);
            }
            return DateTime.UtcNow.AddYears(1);
        }

        private void btnAtras_Click(object? sender, EventArgs e)
        {
            _formAnterior.Show();
            this.Close();
        }
    }
}