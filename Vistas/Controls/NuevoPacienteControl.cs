using Krypton.Toolkit;
using Proyecto_Grupo2.Clases;
using Proyecto_Grupo2.Modelos;
using System;
using System.Windows.Forms;

namespace Proyecto_Grupo2.Vistas.Controls
{
    public partial class NuevoPacienteControl : UserControl
    {
        public NuevoPacienteControl()
        {
            InitializeComponent();
            InicializarCombos();
        }

        private void registrarButton_Click(object sender, EventArgs e)
        {
            try
            {
                PacienteService.Registrar(new Paciente
                {
                    Nombres = kryptonTextBox1.Text.Trim(),
                    Apellidos = kryptonTextBox2.Text.Trim(),
                    DPI = dpiTextBox.Text.Trim(),
                    FechaNacimiento = kryptonDateTimePicker1.Value,
                    Genero = generoComboBox.SelectedIndex > 0 ? generoComboBox.SelectedItem.ToString() : null,
                    Direccion = direccionTextBox.Text.Trim(),
                    Telefono = kryptonTextBox4.Text.Trim(),
                    Correo = correoTextBox.Text.Trim(),
                    TipoSangre = tsangreComboBox.SelectedIndex > 0 ? tsangreComboBox.SelectedItem.ToString() : null
                });

                MessageBox.Show("Paciente registrado correctamente.", "Registro exitoso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (PacienteRegistrationException exception)
            {
                MessageBox.Show(exception.Message, "Error al registrar", MessageBoxButtons.OK,
                    exception.IsDuplicateDpi ? MessageBoxIcon.Warning : MessageBoxIcon.Error);
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message, "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void limpiarFormButton_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void InicializarCombos()
        {
            generoComboBox.Items.Clear();
            generoComboBox.Items.Add("Seleccione...");
            generoComboBox.Items.Add("M");
            generoComboBox.Items.Add("F");
            generoComboBox.SelectedIndex = 0;

            tsangreComboBox.Items.Clear();
            tsangreComboBox.Items.Add("Seleccione...");
            tsangreComboBox.Items.AddRange(new object[] { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" });
            tsangreComboBox.SelectedIndex = 0;
        }

        private void LimpiarFormulario()
        {
            kryptonTextBox1.Clear();
            kryptonTextBox2.Clear();
            kryptonTextBox4.Clear();
            dpiTextBox.Clear();
            correoTextBox.Clear();
            direccionTextBox.Clear();
            kryptonDateTimePicker1.Value = DateTime.Today;
            generoComboBox.SelectedIndex = 0;
            tsangreComboBox.SelectedIndex = 0;
            kryptonTextBox1.Focus();
        }
    }
}
