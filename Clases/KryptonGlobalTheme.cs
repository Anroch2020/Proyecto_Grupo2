using Krypton.Toolkit;
using System.Drawing;

namespace Proyecto_Grupo2.Clases
{
    public static class AppTheme
    {
        ///<summary>
        /// Main palette for the application.
        ///</summary>
        public static KryptonCustomPaletteBase GlobalPalette { get; }
        ///<summary>
        /// For usage with primary action buttons, medic blue.
        ///</summary>
        public static KryptonCustomPaletteBase PrimaryButtonStylePalette { get; }
        ///<summary>
        /// For usage with secondary action buttons, ligther blue.
        ///</summary>
        public static KryptonCustomPaletteBase SecondaryButtonStylePalette { get; }

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
            // Sets the Input Control Border Radius
            GlobalPalette.InputControlStyles.InputControlCommon.StateCommon.Border.Rounding = 20F;
            GlobalPalette.InputControlStyles.InputControlCommon.StateCommon.Border.Width = 1;
            GlobalPalette.InputControlStyles.InputControlCommon.StateCommon.Content.LongText.TextH = PaletteRelativeAlign.Center;
            GlobalPalette.InputControlStyles.InputControlCommon.StateCommon.Content.LongText.TextV = PaletteRelativeAlign.Center;
            GlobalPalette.InputControlStyles.InputControlCommon.StateCommon.Content.ShortText.TextH = PaletteRelativeAlign.Center;
            GlobalPalette.InputControlStyles.InputControlCommon.StateCommon.Content.ShortText.TextV = PaletteRelativeAlign.Center;
            // Alignment of the Labels Text
            GlobalPalette.LabelStyles.LabelCommon.StateCommon.ShortText.TextH = PaletteRelativeAlign.Center;
            GlobalPalette.LabelStyles.LabelCommon.StateCommon.ShortText.TextV = PaletteRelativeAlign.Center;
            // Set Input Border color
            GlobalPalette.InputControlStyles.InputControlCommon.StateCommon.Border.Color1 = Color.FromArgb(148, 163, 184);
            GlobalPalette.InputControlStyles.InputControlCommon.StateCommon.Border.Color2 = Color.FromArgb(148, 163, 184);
            // Set GroupBox Border color
            GlobalPalette.ControlStyles.ControlGroupBox.StateCommon.Border.Color1 = Color.FromArgb(203, 213, 225);
            GlobalPalette.ControlStyles.ControlGroupBox.StateCommon.Border.Color2 = Color.FromArgb(203, 213, 225);
            // Set Input Controls Background Color
            GlobalPalette.InputControlStyles.InputControlCommon.StateNormal.Back.Color1 = Color.FromArgb(248, 250, 252);
            GlobalPalette.InputControlStyles.InputControlCommon.StateNormal.Back.Color2 = Color.FromArgb(248, 250, 252);
            GlobalPalette.InputControlStyles.InputControlCommon.StateCommon.Back.Color1 = Color.FromArgb(248, 250, 252);
            GlobalPalette.InputControlStyles.InputControlCommon.StateCommon.Back.Color2 = Color.FromArgb(248, 250, 252);
            PrimaryButtonStylePalette = new KryptonCustomPaletteBase
            {
                BaseFont = new Font("Segoe UI", 9F),
                BaseFontSize = 9F,
                BasePaletteMode = PaletteMode.ProfessionalSystem,
                BasePaletteType = BasePaletteType.Custom,
                ThemeName = "",
                UseKryptonFileDialogs = true
            };

            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color1 = Color.FromArgb(14, 116, 144);
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color2 = Color.FromArgb(20, 90, 130);
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.OverrideDefault.Back.ColorAngle = 45F;
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.OverrideDefault.Border.Color1 = Color.FromArgb(14, 116, 144);
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.OverrideDefault.Border.Color2 = Color.FromArgb(20, 90, 130);
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.OverrideDefault.Border.ColorAngle = 45F;
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.OverrideDefault.Border.DrawBorders =
                ((PaletteDrawBorders)((((PaletteDrawBorders.Top | PaletteDrawBorders.Bottom)
                | PaletteDrawBorders.Left)
                | PaletteDrawBorders.Right)));
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.OverrideDefault.Border.GraphicsHint = PaletteGraphicsHint.AntiAlias;
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.OverrideDefault.Border.Rounding = 20F;
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.OverrideDefault.Border.Width = 1;

            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StateCommon.Back.Color1 = Color.FromArgb(14, 116, 144);
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StateCommon.Back.Color2 = Color.FromArgb(20, 90, 130);
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StateCommon.Back.ColorAngle = 45F;
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StateCommon.Back.GraphicsHint = PaletteGraphicsHint.AntiAlias;
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StateCommon.Border.Color1 = Color.FromArgb(14, 116, 144);
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StateCommon.Border.Color2 = Color.FromArgb(20, 90, 130);
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StateCommon.Border.DrawBorders =
                ((PaletteDrawBorders)((((PaletteDrawBorders.Top | PaletteDrawBorders.Bottom)
                | PaletteDrawBorders.Left)
                | PaletteDrawBorders.Right)));
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StateCommon.Border.GraphicsHint = PaletteGraphicsHint.AntiAlias;
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StateCommon.Border.Rounding = 20F;
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StateCommon.Border.Width = 1;
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StateCommon.Content.ShortText.Color1 = Color.White;
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StateCommon.Content.ShortText.Color2 = Color.White;

            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StatePressed.Back.Color1 = Color.FromArgb(10, 90, 112);
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StatePressed.Back.Color2 = Color.FromArgb(8, 75, 95);
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StatePressed.Back.ColorAngle = 135F;
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StatePressed.Back.GraphicsHint = PaletteGraphicsHint.AntiAlias;
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StatePressed.Border.Color1 = Color.FromArgb(20, 145, 198);
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StatePressed.Border.Color2 = Color.FromArgb(22, 121, 206);
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StatePressed.Border.ColorAngle = 135F;
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StatePressed.Border.DrawBorders =
                ((PaletteDrawBorders)((((PaletteDrawBorders.Top | PaletteDrawBorders.Bottom)
                | PaletteDrawBorders.Left)
                | PaletteDrawBorders.Right)));
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StatePressed.Border.Rounding = 20F;
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StatePressed.Border.Width = 1;

            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StateTracking.Back.Color1 = Color.FromArgb(20, 140, 170);
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StateTracking.Back.Color2 = Color.FromArgb(14, 116, 144);
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StateTracking.Back.ColorAngle = 45F;
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StateTracking.Border.Color1 = Color.FromArgb(6, 174, 244);
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StateTracking.Border.Color2 = Color.FromArgb(8, 142, 254);
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StateTracking.Border.ColorAngle = 45F;
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StateTracking.Border.DrawBorders =
                ((PaletteDrawBorders)((((PaletteDrawBorders.Top | PaletteDrawBorders.Bottom)
                | PaletteDrawBorders.Left)
                | PaletteDrawBorders.Right)));
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StateTracking.Border.GraphicsHint = PaletteGraphicsHint.AntiAlias;
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StateTracking.Border.Rounding = 20F;
            PrimaryButtonStylePalette.ButtonStyles.ButtonCommon.StateTracking.Border.Width = 1;
            
            
            SecondaryButtonStylePalette = new KryptonCustomPaletteBase
            {
                BaseFont = new Font("Segoe UI", 9F),
                BaseFontSize = 9F,
                BasePaletteMode = PaletteMode.ProfessionalSystem,
                BasePaletteType = BasePaletteType.Custom,
                ThemeName = "",
                UseKryptonFileDialogs = true
            };

            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color1 = Color.FromArgb(203, 213, 225);
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color2 = Color.FromArgb(148, 163, 184);
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.OverrideDefault.Back.ColorAngle = 45F;
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.OverrideDefault.Border.Color1 = Color.FromArgb(203, 213, 225);
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.OverrideDefault.Border.Color2 = Color.FromArgb(148, 163, 184);
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.OverrideDefault.Border.ColorAngle = 45F;
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.OverrideDefault.Border.DrawBorders =
                ((PaletteDrawBorders)((((PaletteDrawBorders.Top | PaletteDrawBorders.Bottom)
                | PaletteDrawBorders.Left)
                | PaletteDrawBorders.Right)));
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.OverrideDefault.Border.GraphicsHint = PaletteGraphicsHint.AntiAlias;
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.OverrideDefault.Border.Rounding = 20F;
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.OverrideDefault.Border.Width = 1;

            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StateCommon.Back.Color1 = Color.FromArgb(203, 213, 225);
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StateCommon.Back.Color2 = Color.FromArgb(148, 163, 184);
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StateCommon.Back.ColorAngle = 45F;
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StateCommon.Back.GraphicsHint = PaletteGraphicsHint.AntiAlias;
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StateCommon.Border.Color1 = Color.FromArgb(203, 213, 225);
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StateCommon.Border.Color2 = Color.FromArgb(148, 163, 184);
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StateCommon.Border.DrawBorders =
                ((PaletteDrawBorders)((((PaletteDrawBorders.Top | PaletteDrawBorders.Bottom)
                | PaletteDrawBorders.Left)
                | PaletteDrawBorders.Right)));
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StateCommon.Border.GraphicsHint = PaletteGraphicsHint.AntiAlias;
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StateCommon.Border.Rounding = 20F;
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StateCommon.Border.Width = 1;
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StateCommon.Content.ShortText.Color1 = Color.White;
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StateCommon.Content.ShortText.Color2 = Color.White;

            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StatePressed.Back.Color1 = Color.FromArgb(203, 213, 225);
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StatePressed.Back.Color2 = Color.FromArgb(148, 163, 184);
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StatePressed.Back.ColorAngle = 135F;
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StatePressed.Back.GraphicsHint = PaletteGraphicsHint.AntiAlias;
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StatePressed.Border.Color1 = Color.FromArgb(20, 145, 198);
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StatePressed.Border.Color2 = Color.FromArgb(22, 121, 206);
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StatePressed.Border.ColorAngle = 135F;
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StatePressed.Border.DrawBorders =
                ((PaletteDrawBorders)((((PaletteDrawBorders.Top | PaletteDrawBorders.Bottom)
                | PaletteDrawBorders.Left)
                | PaletteDrawBorders.Right)));
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StatePressed.Border.Rounding = 20F;
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StatePressed.Border.Width = 1;

            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StateTracking.Back.Color1 = Color.FromArgb(20, 140, 170);
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StateTracking.Back.Color2 = Color.FromArgb(14, 116, 144);
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StateTracking.Back.ColorAngle = 45F;
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StateTracking.Border.Color1 = Color.FromArgb(6, 174, 244);
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StateTracking.Border.Color2 = Color.FromArgb(8, 142, 254);
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StateTracking.Border.ColorAngle = 45F;
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StateTracking.Border.DrawBorders =
                ((PaletteDrawBorders)((((PaletteDrawBorders.Top | PaletteDrawBorders.Bottom)
                | PaletteDrawBorders.Left)
                | PaletteDrawBorders.Right)));
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StateTracking.Border.GraphicsHint = PaletteGraphicsHint.AntiAlias;
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StateTracking.Border.Rounding = 20F;
            SecondaryButtonStylePalette.ButtonStyles.ButtonCommon.StateTracking.Border.Width = 1;
            
            _manager = new KryptonManager
            {
                GlobalPalette = GlobalPalette,
                GlobalPaletteMode = PaletteMode.Custom
            };
        }

        /// <summary>Call once at startup to trigger the static constructor above.</summary>
        public static void ensureInitialized() { }
    }
}

