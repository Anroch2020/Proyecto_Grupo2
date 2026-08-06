using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Enrollment;
using Proyecto_Grupo2.Clases;
using Krypton.Toolkit;

namespace Proyecto_Grupo2.Vistas
{
    public partial class RegisterForm : KryptonForm
{
    private byte[] plantillaHuella;

    public RegisterForm()
    {
        InitializeComponent();
        LoadRoles();
    }

    private void LoadRoles()
    {
        rolComboBox.DisplayMember = "NombreRol";
        rolComboBox.ValueMember = "RolID";
        rolComboBox.DataSource = AuthService.Roles();
    }

    private void registrarHuellaButton_Click(object sender, EventArgs e)
    {
        var enrollmentForm = new EnrollmentForm();

        enrollmentForm.OnTemplate += template =>
        {
            if (template == null)
            {
                return;
            }

            using (var memoryStream = new MemoryStream())
            {
                template.Serialize(memoryStream);
                plantillaHuella = memoryStream.ToArray();
            }
        };

        enrollmentForm.ShowDialog();
    }

    private void guardarButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(usuarioTextBox.Text) ||
                string.IsNullOrWhiteSpace(nombreTextBox.Text) ||
                passwordTextBox.Text.Length < 6 ||
                passwordTextBox.Text != confirmarPasswordTextBox.Text ||
                rolComboBox.SelectedValue == null)
            {
                MessageBox.Show("Complete los campos y use una contraseña de al menos 6 caracteres.");
                return;
            }

            if (AuthService.UserExists(usuarioTextBox.Text.Trim()))
            {
                MessageBox.Show("Ese usuario ya existe.");
                return;
            }

            AuthService.Register(
                usuarioTextBox.Text.Trim(),
                passwordTextBox.Text,
                nombreTextBox.Text.Trim(),
                correoTextBox.Text.Trim(),
                (int)rolComboBox.SelectedValue,
                plantillaHuella
            );

            MessageBox.Show("Usuario registrado.");
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error");
        }
    }

    private void RegisterForm_Load(object sender, EventArgs e)
    {
        guardarButton.PaletteMode = PaletteMode.Custom;
        guardarButton.Palette = AppTheme.PrimaryButtonStylePalette;
        registrarHuellaButton.PaletteMode = PaletteMode.Custom;
        registrarHuellaButton.Palette = AppTheme.PrimaryButtonStylePalette;
    }
}
}