using Krypton.Toolkit;
using Proyecto_Grupo2.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Grupo2.Vistas.UserControls
{
    public partial class nuevoPacienteControl : UserControl
    {
        public nuevoPacienteControl()
        {
            InitializeComponent();
            kryptonButton1.PaletteMode = PaletteMode.Custom;
            kryptonButton1.Palette = AppTheme.AccentButtonPalette;
            kryptonButton2.PaletteMode = PaletteMode.Custom;
            kryptonButton2.Palette = AppTheme.AccentButtonPalette;
        }

        private void kryptonControllersStyleLight_PalettePaint(object sender, Krypton.Toolkit.PaletteLayoutEventArgs e)
        {
               
        }
    }
}
