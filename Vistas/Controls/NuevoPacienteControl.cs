using Krypton.Toolkit;
using Proyecto_Grupo2.Clases;
using System.Windows.Forms;

namespace Proyecto_Grupo2.Vistas.Controls
{
    public partial class NuevoPacienteControl : UserControl
    {
        public NuevoPacienteControl()
        {
            InitializeComponent();
            kryptonButton1.PaletteMode = PaletteMode.Custom;
            kryptonButton1.Palette = AppTheme.PrimaryButtonStylePalette;
            kryptonButton2.PaletteMode = PaletteMode.Custom;
            kryptonButton2.Palette = AppTheme.SecondaryButtonStylePalette;
        }
    }
}
