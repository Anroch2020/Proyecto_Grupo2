using Krypton.Toolkit;
using Proyecto_Grupo2.Clases;
using Proyecto_Grupo2.Vistas.Controls;
using System;
using System.Windows.Forms;

namespace Proyecto_Grupo2.Vistas
{
    public partial class MedicosForm : KryptonForm
    {
        private UserControl _currentControl;
        public MedicosForm()
        {
            InitializeComponent();
            btnCrearPaciente.PaletteMode = PaletteMode.Custom;
            btnCrearPaciente.Palette = AppTheme.PrimaryButtonStylePalette;
            btnListaPacientes.PaletteMode = PaletteMode.Custom;
            btnListaPacientes.Palette = AppTheme.PrimaryButtonStylePalette;
            btnBuscarPaciente.PaletteMode = PaletteMode.Custom;
            btnBuscarPaciente.Palette = AppTheme.PrimaryButtonStylePalette;
            kryptonButton1.PaletteMode = PaletteMode.Custom;
            kryptonButton1.Palette = AppTheme.PrimaryButtonStylePalette;
            kryptonButton2.PaletteMode = PaletteMode.Custom;
            kryptonButton2.Palette = AppTheme.PrimaryButtonStylePalette;
            kryptonButton3.PaletteMode = PaletteMode.Custom;
            kryptonButton3.Palette = AppTheme.PrimaryButtonStylePalette;
            kryptonButton6.PaletteMode = PaletteMode.Custom;
            kryptonButton6.Palette = AppTheme.PrimaryButtonStylePalette;
            kryptonButton5.PaletteMode = PaletteMode.Custom;
            kryptonButton5.Palette = AppTheme.PrimaryButtonStylePalette;
            kryptonButton4.PaletteMode = PaletteMode.Custom;
            kryptonButton4.Palette = AppTheme.PrimaryButtonStylePalette;
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            foreach (Control c in PacientesflowLayoutPanel.Controls)
            {
                c.Width = PacientesflowLayoutPanel.ClientSize.Width - c.Margin.Left - c.Margin.Right;
            }
        }

        private void btnListaPacientes_Click(object sender, EventArgs e)
        {
            loadControl(new ListarPacientesControl());
        }

        private void flowLayoutPanel2_Resize(object sender, EventArgs e)
        {
            foreach (Control c in CitasflowLayoutPanel.Controls)
            {
                c.Width = CitasflowLayoutPanel.ClientSize.Width - c.Margin.Left - c.Margin.Right;
            }
        }

        private void flowLayoutPanel3_Resize(object sender, EventArgs e)
        {
            foreach (Control c in FacturasflowLayoutPanel.Controls)
            {
                c.Width = FacturasflowLayoutPanel.ClientSize.Width - c.Margin.Left - c.Margin.Right;
            }
        }

        private void btnCrearPaciente_Click(object sender, EventArgs e)
        {
            loadControl(new NuevoPacienteControl());
        }
        private void loadControl(UserControl newControl)
        {
            mainPanel.Controls.Clear();
            _currentControl?.Dispose();
            newControl.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(newControl);
            _currentControl = newControl;
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            loadControl(new BuscarPacienteControl());
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            loadControl(new NuevaCitaControl());
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            loadControl(new BuscarCitaControl());
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            loadControl(new VerCitasControl());
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            loadControl(new CrearFacturaControl());
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            loadControl(new VerFacturasControl());
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            loadControl(new VerHistorialControl());
        }
    }
}
