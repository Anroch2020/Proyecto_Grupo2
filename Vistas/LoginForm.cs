using System;
using System.Windows.Forms;
using Krypton.Toolkit;
using Proyecto_Grupo2.Clases;
using Proyecto_Grupo2.Modelos;
using Enrollment;
using System.IO;
namespace Proyecto_Grupo2.Vistas
{
    public partial class LoginForm : KryptonForm
    {
        public LoginForm()
        {
            InitializeComponent();
            huellaButton.PaletteMode = PaletteMode.Custom;
            huellaButton.Palette = AppTheme.PrimaryButtonStylePalette;
            registrarButton.PaletteMode = PaletteMode.Custom;
            registrarButton.Palette = AppTheme.PrimaryButtonStylePalette;
            ingresarButton.PaletteMode = PaletteMode.Custom;
            ingresarButton.Palette = AppTheme.PrimaryButtonStylePalette;
        }

        private void ingresarButton_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = AuthService.Login(usuarioTextBox.Text.Trim(), passwordTextBox.Text);

                if (usuario == null)
                {
                    MessageBox.Show("Usuario o contraseña inválidos.");
                    return;
                }

                OpenRole(usuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void huellaButton_Click(object sender, EventArgs e)
        {
            try
            {
                var usuarios = AuthService.FingerprintUsers();
                if (usuarios.Count == 0)
                {
                    MessageBox.Show("No hay usuarios activos con una huella registrada.");
                    return;
                }

                var verificationForm = new VerificationForm();

                verificationForm.IdentificationCompleted += (usuario, ok) =>
                {
                    AuthService.RegistrarResultadoHuella(usuario, ok);
                    if (ok)
                    {
                        BeginInvoke(new Action(() => OpenRole(usuario)));
                    }
                };

                verificationForm.Identify(usuarios);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
        }
        private void OpenRole(AuthUser usuario)
        {
            Form form;

            switch (usuario.Role)
            {
                case "Administrador":
                    form = new AdministradorForm();
                    break;

                case "Doctor":
                    form = new MedicoForm();
                    break;

                case "Farmacia":
                    form = new FarmaciaForm();
                    break;

                default:
                    form = new RecepcionForm();
                    break;
            }

            Hide();

            form.FormClosed += (sender, e) => Close();
            form.Show();
        }

        private void registrarButton_Click(object sender, EventArgs e)
        {
            using (var form = new RegisterForm())
            {
                form.ShowDialog();
            }
        }
    }
}
