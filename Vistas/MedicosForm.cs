using Krypton.Toolkit;
using Proyecto_Grupo2.Clases;
using Proyecto_Grupo2.Vistas.Controls;
using Proyecto_Grupo2.Vistas.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Grupo2
{
    public partial class MedicosForm : KryptonForm
    {
        private UserControl currentControl;
        public MedicosForm()
        {
            InitializeComponent();
            btnCrearPaciente.PaletteMode = PaletteMode.Custom;
            btnCrearPaciente.Palette = AppTheme.AccentButtonPalette;
            btnListaPacientes.PaletteMode = PaletteMode.Custom;
            btnListaPacientes.Palette = AppTheme.AccentButtonPalette;
            btnBuscarPaciente.PaletteMode = PaletteMode.Custom;
            btnBuscarPaciente.Palette = AppTheme.AccentButtonPalette;
            kryptonButton1.PaletteMode = PaletteMode.Custom;
            kryptonButton1.Palette = AppTheme.AccentButtonPalette;
            kryptonButton2.PaletteMode = PaletteMode.Custom;
            kryptonButton2.Palette = AppTheme.AccentButtonPalette;
            kryptonButton3.PaletteMode = PaletteMode.Custom;
            kryptonButton3.Palette = AppTheme.AccentButtonPalette;
            kryptonButton6.PaletteMode = PaletteMode.Custom;
            kryptonButton6.Palette = AppTheme.AccentButtonPalette;
            kryptonButton5.PaletteMode = PaletteMode.Custom;
            kryptonButton5.Palette = AppTheme.AccentButtonPalette;
            kryptonButton4.PaletteMode = PaletteMode.Custom;
            kryptonButton4.Palette = AppTheme.AccentButtonPalette;
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
            LoadControl(new listarPacientesControl());
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
            LoadControl(new nuevoPacienteControl());
        }
        private void LoadControl(UserControl newControl)
        {
            mainPanel.Controls.Clear();
            currentControl?.Dispose();
            newControl.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(newControl);
            currentControl = newControl;
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            LoadControl(new buscarPacienteControl());
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            LoadControl(new nuevaCitaControl());
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            LoadControl(new buscarCitaControl());
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            LoadControl(new verCitasControl());
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            LoadControl(new crearFacturaControl());
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            LoadControl(new verFacturasControl());
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            LoadControl(new verHistorialControl());
        }
    }
}
