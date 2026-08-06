using System.ComponentModel;

namespace Proyecto_Grupo2.Vistas
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MainPanelLayout = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.BodyPanel = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.LoginTableLayoutPanel = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.usuarioLabel = new Krypton.Toolkit.KryptonLabel();
            this.usuarioTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.passwordLabel = new Krypton.Toolkit.KryptonLabel();
            this.passwordTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.ingresarButton = new Krypton.Toolkit.KryptonButton();
            this.huellaButton = new Krypton.Toolkit.KryptonButton();
            this.registrarButton = new Krypton.Toolkit.KryptonButton();
            this.titleLabel = new Krypton.Toolkit.KryptonLabel();
            this.kryptonFormsStyle = new Krypton.Toolkit.KryptonCustomPaletteBase(this.components);
            this.MainPanelLayout.SuspendLayout();
            this.BodyPanel.SuspendLayout();
            this.LoginTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanelLayout
            // 
            this.MainPanelLayout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MainPanelLayout.ColumnCount = 1;
            this.MainPanelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainPanelLayout.Controls.Add(this.BodyPanel, 0, 1);
            this.MainPanelLayout.Controls.Add(this.titleLabel, 0, 0);
            this.MainPanelLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanelLayout.Location = new System.Drawing.Point(0, 0);
            this.MainPanelLayout.Name = "MainPanelLayout";
            this.MainPanelLayout.RowCount = 2;
            this.MainPanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.MainPanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.MainPanelLayout.Size = new System.Drawing.Size(800, 450);
            this.MainPanelLayout.TabIndex = 0;
            // 
            // BodyPanel
            // 
            this.BodyPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BodyPanel.ColumnCount = 3;
            this.BodyPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.BodyPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.BodyPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.BodyPanel.Controls.Add(this.LoginTableLayoutPanel, 1, 0);
            this.BodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BodyPanel.Location = new System.Drawing.Point(3, 70);
            this.BodyPanel.Name = "BodyPanel";
            this.BodyPanel.RowCount = 1;
            this.BodyPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BodyPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 377F));
            this.BodyPanel.Size = new System.Drawing.Size(794, 377);
            this.BodyPanel.TabIndex = 0;
            // 
            // LoginTableLayoutPanel
            // 
            this.LoginTableLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.LoginTableLayoutPanel.ColumnCount = 1;
            this.LoginTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LoginTableLayoutPanel.Controls.Add(this.usuarioLabel, 0, 0);
            this.LoginTableLayoutPanel.Controls.Add(this.usuarioTextBox, 0, 1);
            this.LoginTableLayoutPanel.Controls.Add(this.passwordLabel, 0, 2);
            this.LoginTableLayoutPanel.Controls.Add(this.passwordTextBox, 0, 3);
            this.LoginTableLayoutPanel.Controls.Add(this.ingresarButton, 0, 4);
            this.LoginTableLayoutPanel.Controls.Add(this.huellaButton, 0, 5);
            this.LoginTableLayoutPanel.Controls.Add(this.registrarButton, 0, 6);
            this.LoginTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoginTableLayoutPanel.Location = new System.Drawing.Point(267, 3);
            this.LoginTableLayoutPanel.Name = "LoginTableLayoutPanel";
            this.LoginTableLayoutPanel.RowCount = 7;
            this.LoginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.LoginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.LoginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.LoginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.LoginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.LoginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.LoginTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.LoginTableLayoutPanel.Size = new System.Drawing.Size(258, 371);
            this.LoginTableLayoutPanel.TabIndex = 0;
            // 
            // usuarioLabel
            // 
            this.usuarioLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usuarioLabel.Location = new System.Drawing.Point(3, 3);
            this.usuarioLabel.Name = "usuarioLabel";
            this.usuarioLabel.Size = new System.Drawing.Size(252, 46);
            this.usuarioLabel.TabIndex = 0;
            this.usuarioLabel.Values.Text = "Usuario";
            // 
            // usuarioTextBox
            // 
            this.usuarioTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.usuarioTextBox.Location = new System.Drawing.Point(3, 64);
            this.usuarioTextBox.Name = "usuarioTextBox";
            this.usuarioTextBox.Size = new System.Drawing.Size(252, 27);
            this.usuarioTextBox.TabIndex = 1;
            // 
            // passwordLabel
            // 
            this.passwordLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passwordLabel.Location = new System.Drawing.Point(3, 107);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(252, 46);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Values.Text = "Contrasena";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordTextBox.Location = new System.Drawing.Point(3, 168);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '●';
            this.passwordTextBox.Size = new System.Drawing.Size(252, 27);
            this.passwordTextBox.TabIndex = 3;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // ingresarButton
            // 
            this.ingresarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ingresarButton.Location = new System.Drawing.Point(3, 221);
            this.ingresarButton.Name = "ingresarButton";
            this.ingresarButton.Size = new System.Drawing.Size(252, 25);
            this.ingresarButton.TabIndex = 4;
            this.ingresarButton.Values.Text = "Ingresar";
            this.ingresarButton.Click += new System.EventHandler(this.ingresarButton_Click);
            // 
            // huellaButton
            // 
            this.huellaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.huellaButton.Location = new System.Drawing.Point(3, 273);
            this.huellaButton.Name = "huellaButton";
            this.huellaButton.Size = new System.Drawing.Size(252, 25);
            this.huellaButton.TabIndex = 5;
            this.huellaButton.Values.Text = "Ingresar Con Huella";
            this.huellaButton.Click += new System.EventHandler(this.huellaButton_Click);
            // 
            // registrarButton
            // 
            this.registrarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.registrarButton.Location = new System.Drawing.Point(3, 329);
            this.registrarButton.Name = "registrarButton";
            this.registrarButton.Size = new System.Drawing.Size(252, 25);
            this.registrarButton.TabIndex = 6;
            this.registrarButton.Values.Text = "Registrarse";
            this.registrarButton.Click += new System.EventHandler(this.registrarButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.LabelStyle = Krypton.Toolkit.LabelStyle.TitlePanel;
            this.titleLabel.Location = new System.Drawing.Point(3, 3);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(794, 61);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Values.Text = "Iniciar Sesion";
            // 
            // kryptonFormsStyle
            // 
            this.kryptonFormsStyle.BaseFont = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonFormsStyle.BaseFontSize = 9F;
            this.kryptonFormsStyle.BasePaletteMode = Krypton.Toolkit.PaletteMode.Microsoft365White;
            this.kryptonFormsStyle.BasePaletteType = Krypton.Toolkit.BasePaletteType.Custom;
            this.kryptonFormsStyle.FormStyles.FormMain.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.kryptonFormsStyle.FormStyles.FormMain.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.kryptonFormsStyle.FormStyles.FormMain.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) | Krypton.Toolkit.PaletteDrawBorders.Left) | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonFormsStyle.FormStyles.FormMain.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.None;
            this.kryptonFormsStyle.FormStyles.FormMain.StateCommon.Border.Rounding = 22F;
            this.kryptonFormsStyle.ThemeName = "";
            this.kryptonFormsStyle.UseKryptonFileDialogs = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainPanelLayout);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "LoginForm";
            this.Palette = this.kryptonFormsStyle;
            this.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.MainPanelLayout.ResumeLayout(false);
            this.MainPanelLayout.PerformLayout();
            this.BodyPanel.ResumeLayout(false);
            this.LoginTableLayoutPanel.ResumeLayout(false);
            this.LoginTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        private Krypton.Toolkit.KryptonCustomPaletteBase kryptonFormsStyle;

        private Krypton.Toolkit.KryptonLabel titleLabel;

        private Krypton.Toolkit.KryptonButton registrarButton;

        private Krypton.Toolkit.KryptonButton huellaButton;
        
        private Krypton.Toolkit.KryptonButton ingresarButton;

        private Krypton.Toolkit.KryptonTextBox usuarioTextBox;

        private Krypton.Toolkit.KryptonLabel passwordLabel;

        private Krypton.Toolkit.KryptonTextBox passwordTextBox;

        private Krypton.Toolkit.KryptonLabel usuarioLabel;

        private Krypton.Toolkit.KryptonTableLayoutPanel LoginTableLayoutPanel;

        private Krypton.Toolkit.KryptonTableLayoutPanel MainPanelLayout;

        private Krypton.Toolkit.KryptonTableLayoutPanel BodyPanel;

        #endregion
    }
}