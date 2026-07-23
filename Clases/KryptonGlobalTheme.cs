using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Grupo2.Clases
{
    public static class AppTheme
    {
        public static KryptonCustomPaletteBase GlobalPalette { get; }
        public static KryptonCustomPaletteBase AccentButtonPalette { get; }

        private static readonly KryptonManager _manager;

        static AppTheme()
        {
            GlobalPalette = new KryptonCustomPaletteBase
            {
                BaseFont = new Font("Segoe UI", 9F),
                BaseFontSize = 9F,
                BasePaletteMode = PaletteMode.Microsoft365White,
                BasePaletteType = BasePaletteType.Custom,
                ThemeName = "",
                UseKryptonFileDialogs = true
            };
            GlobalPalette.InputControlStyles.InputControlCommon.StateCommon.Border.DrawBorders =
                ((PaletteDrawBorders)((((PaletteDrawBorders.Top | PaletteDrawBorders.Bottom)
                | PaletteDrawBorders.Left)
                | PaletteDrawBorders.Right)));
            GlobalPalette.InputControlStyles.InputControlCommon.StateCommon.Border.Rounding = 20F;
            GlobalPalette.InputControlStyles.InputControlCommon.StateCommon.Border.Width = 1;
            GlobalPalette.InputControlStyles.InputControlCommon.StateCommon.Content.LongText.TextH = PaletteRelativeAlign.Center;
            GlobalPalette.InputControlStyles.InputControlCommon.StateCommon.Content.LongText.TextV = PaletteRelativeAlign.Center;
            GlobalPalette.InputControlStyles.InputControlCommon.StateCommon.Content.ShortText.TextH = PaletteRelativeAlign.Center;
            GlobalPalette.InputControlStyles.InputControlCommon.StateCommon.Content.ShortText.TextV = PaletteRelativeAlign.Center;
            GlobalPalette.LabelStyles.LabelCommon.StateCommon.ShortText.TextH = PaletteRelativeAlign.Center;
            GlobalPalette.LabelStyles.LabelCommon.StateCommon.ShortText.TextV = PaletteRelativeAlign.Center;

            AccentButtonPalette = new KryptonCustomPaletteBase
            {
                BaseFont = new Font("Segoe UI", 9F),
                BaseFontSize = 9F,
                BasePaletteMode = PaletteMode.ProfessionalSystem,
                BasePaletteType = BasePaletteType.Custom,
                ThemeName = "",
                UseKryptonFileDialogs = true
            };

            AccentButtonPalette.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color1 = Color.FromArgb(14, 116, 144);
            AccentButtonPalette.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color2 = Color.FromArgb(20, 90, 130);
            AccentButtonPalette.ButtonStyles.ButtonCommon.OverrideDefault.Back.ColorAngle = 45F;
            AccentButtonPalette.ButtonStyles.ButtonCommon.OverrideDefault.Border.Color1 = Color.FromArgb(14, 116, 144);
            AccentButtonPalette.ButtonStyles.ButtonCommon.OverrideDefault.Border.Color2 = Color.FromArgb(20, 90, 130);
            AccentButtonPalette.ButtonStyles.ButtonCommon.OverrideDefault.Border.ColorAngle = 45F;
            AccentButtonPalette.ButtonStyles.ButtonCommon.OverrideDefault.Border.DrawBorders =
                ((PaletteDrawBorders)((((PaletteDrawBorders.Top | PaletteDrawBorders.Bottom)
                | PaletteDrawBorders.Left)
                | PaletteDrawBorders.Right)));
            AccentButtonPalette.ButtonStyles.ButtonCommon.OverrideDefault.Border.GraphicsHint = PaletteGraphicsHint.AntiAlias;
            AccentButtonPalette.ButtonStyles.ButtonCommon.OverrideDefault.Border.Rounding = 20F;
            AccentButtonPalette.ButtonStyles.ButtonCommon.OverrideDefault.Border.Width = 1;

            AccentButtonPalette.ButtonStyles.ButtonCommon.StateCommon.Back.Color1 = Color.FromArgb(14, 116, 144);
            AccentButtonPalette.ButtonStyles.ButtonCommon.StateCommon.Back.Color2 = Color.FromArgb(20, 90, 130);
            AccentButtonPalette.ButtonStyles.ButtonCommon.StateCommon.Back.ColorAngle = 45F;
            AccentButtonPalette.ButtonStyles.ButtonCommon.StateCommon.Back.GraphicsHint = PaletteGraphicsHint.AntiAlias;
            AccentButtonPalette.ButtonStyles.ButtonCommon.StateCommon.Border.Color1 = Color.FromArgb(14, 116, 144);
            AccentButtonPalette.ButtonStyles.ButtonCommon.StateCommon.Border.Color2 = Color.FromArgb(20, 90, 130);
            AccentButtonPalette.ButtonStyles.ButtonCommon.StateCommon.Border.DrawBorders =
                ((PaletteDrawBorders)((((PaletteDrawBorders.Top | PaletteDrawBorders.Bottom)
                | PaletteDrawBorders.Left)
                | PaletteDrawBorders.Right)));
            AccentButtonPalette.ButtonStyles.ButtonCommon.StateCommon.Border.GraphicsHint = PaletteGraphicsHint.AntiAlias;
            AccentButtonPalette.ButtonStyles.ButtonCommon.StateCommon.Border.Rounding = 20F;
            AccentButtonPalette.ButtonStyles.ButtonCommon.StateCommon.Border.Width = 1;
            AccentButtonPalette.ButtonStyles.ButtonCommon.StateCommon.Content.ShortText.Color1 = Color.White;
            AccentButtonPalette.ButtonStyles.ButtonCommon.StateCommon.Content.ShortText.Color2 = Color.White;

            AccentButtonPalette.ButtonStyles.ButtonCommon.StatePressed.Back.Color1 = Color.FromArgb(10, 90, 112);
            AccentButtonPalette.ButtonStyles.ButtonCommon.StatePressed.Back.Color2 = Color.FromArgb(8, 75, 95);
            AccentButtonPalette.ButtonStyles.ButtonCommon.StatePressed.Back.ColorAngle = 135F;
            AccentButtonPalette.ButtonStyles.ButtonCommon.StatePressed.Back.GraphicsHint = PaletteGraphicsHint.AntiAlias;
            AccentButtonPalette.ButtonStyles.ButtonCommon.StatePressed.Border.Color1 = Color.FromArgb(20, 145, 198);
            AccentButtonPalette.ButtonStyles.ButtonCommon.StatePressed.Border.Color2 = Color.FromArgb(22, 121, 206);
            AccentButtonPalette.ButtonStyles.ButtonCommon.StatePressed.Border.ColorAngle = 135F;
            AccentButtonPalette.ButtonStyles.ButtonCommon.StatePressed.Border.DrawBorders =
                ((PaletteDrawBorders)((((PaletteDrawBorders.Top | PaletteDrawBorders.Bottom)
                | PaletteDrawBorders.Left)
                | PaletteDrawBorders.Right)));
            AccentButtonPalette.ButtonStyles.ButtonCommon.StatePressed.Border.Rounding = 20F;
            AccentButtonPalette.ButtonStyles.ButtonCommon.StatePressed.Border.Width = 1;

            AccentButtonPalette.ButtonStyles.ButtonCommon.StateTracking.Back.Color1 = Color.FromArgb(20, 140, 170);
            AccentButtonPalette.ButtonStyles.ButtonCommon.StateTracking.Back.Color2 = Color.FromArgb(14, 116, 144);
            AccentButtonPalette.ButtonStyles.ButtonCommon.StateTracking.Back.ColorAngle = 45F;
            AccentButtonPalette.ButtonStyles.ButtonCommon.StateTracking.Border.Color1 = Color.FromArgb(6, 174, 244);
            AccentButtonPalette.ButtonStyles.ButtonCommon.StateTracking.Border.Color2 = Color.FromArgb(8, 142, 254);
            AccentButtonPalette.ButtonStyles.ButtonCommon.StateTracking.Border.ColorAngle = 45F;
            AccentButtonPalette.ButtonStyles.ButtonCommon.StateTracking.Border.DrawBorders =
                ((PaletteDrawBorders)((((PaletteDrawBorders.Top | PaletteDrawBorders.Bottom)
                | PaletteDrawBorders.Left)
                | PaletteDrawBorders.Right)));
            AccentButtonPalette.ButtonStyles.ButtonCommon.StateTracking.Border.GraphicsHint = PaletteGraphicsHint.AntiAlias;
            AccentButtonPalette.ButtonStyles.ButtonCommon.StateTracking.Border.Rounding = 20F;
            AccentButtonPalette.ButtonStyles.ButtonCommon.StateTracking.Border.Width = 1;

            // ---- was: this.kryptonManagerControl ----
            _manager = new KryptonManager
            {
                GlobalPalette = GlobalPalette,
                GlobalPaletteMode = PaletteMode.Custom
            };
        }

        /// <summary>Call once at startup to trigger the static constructor above.</summary>
        public static void EnsureInitialized() { }
    }
}

