using System.ComponentModel;

namespace Proyecto_Grupo2.Vistas
{
    partial class RegisterForm
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
            this.mainFormLayoutPanel = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.bodyContainerLayoutPanel = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.bodySecondaryTableLayoutPanel = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.passwordGroupBox = new Krypton.Toolkit.KryptonGroupBox();
            this.passwordContainerTableLayout = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.passwordLabel = new Krypton.Toolkit.KryptonLabel();
            this.passwordTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.confirmarPasswordLabel = new Krypton.Toolkit.KryptonLabel();
            this.confirmarPasswordTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.rolGroupBox = new Krypton.Toolkit.KryptonGroupBox();
            this.rolTableLayoutPanel = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.rolLabel = new Krypton.Toolkit.KryptonLabel();
            this.rolComboBox = new Krypton.Toolkit.KryptonComboBox();
            this.userDataGroupBox = new Krypton.Toolkit.KryptonGroupBox();
            this.userDataContainerLayoutPanel = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.usuarioLabel = new Krypton.Toolkit.KryptonLabel();
            this.usuarioTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.nombreLabel = new Krypton.Toolkit.KryptonLabel();
            this.nombreTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.correoLabel = new Krypton.Toolkit.KryptonLabel();
            this.correoTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.guardarButton = new Krypton.Toolkit.KryptonButton();
            this.registrarHuellaButton = new Krypton.Toolkit.KryptonButton();
            this.titleLabel = new Krypton.Toolkit.KryptonLabel();
            this.kryptonFormsStyle = new Krypton.Toolkit.KryptonCustomPaletteBase(this.components);
            this.mainFormLayoutPanel.SuspendLayout();
            this.bodyContainerLayoutPanel.SuspendLayout();
            this.bodySecondaryTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passwordGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordGroupBox.Panel)).BeginInit();
            this.passwordGroupBox.Panel.SuspendLayout();
            this.passwordGroupBox.SuspendLayout();
            this.passwordContainerTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rolGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolGroupBox.Panel)).BeginInit();
            this.rolGroupBox.Panel.SuspendLayout();
            this.rolGroupBox.SuspendLayout();
            this.rolTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rolComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userDataGroupBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userDataGroupBox.Panel)).BeginInit();
            this.userDataGroupBox.Panel.SuspendLayout();
            this.userDataGroupBox.SuspendLayout();
            this.userDataContainerLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainFormLayoutPanel
            // 
            this.mainFormLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mainFormLayoutPanel.ColumnCount = 1;
            this.mainFormLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainFormLayoutPanel.Controls.Add(this.bodyContainerLayoutPanel, 0, 1);
            this.mainFormLayoutPanel.Controls.Add(this.titleLabel, 0, 0);
            this.mainFormLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainFormLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainFormLayoutPanel.Name = "mainFormLayoutPanel";
            this.mainFormLayoutPanel.RowCount = 2;
            this.mainFormLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.mainFormLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.mainFormLayoutPanel.Size = new System.Drawing.Size(800, 450);
            this.mainFormLayoutPanel.TabIndex = 0;
            // 
            // bodyContainerLayoutPanel
            // 
            this.bodyContainerLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bodyContainerLayoutPanel.ColumnCount = 2;
            this.bodyContainerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.bodyContainerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.bodyContainerLayoutPanel.Controls.Add(this.bodySecondaryTableLayoutPanel, 1, 0);
            this.bodyContainerLayoutPanel.Controls.Add(this.userDataGroupBox, 0, 0);
            this.bodyContainerLayoutPanel.Controls.Add(this.guardarButton, 0, 1);
            this.bodyContainerLayoutPanel.Controls.Add(this.registrarHuellaButton, 1, 1);
            this.bodyContainerLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyContainerLayoutPanel.Location = new System.Drawing.Point(3, 70);
            this.bodyContainerLayoutPanel.Name = "bodyContainerLayoutPanel";
            this.bodyContainerLayoutPanel.RowCount = 2;
            this.bodyContainerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.bodyContainerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.bodyContainerLayoutPanel.Size = new System.Drawing.Size(794, 377);
            this.bodyContainerLayoutPanel.TabIndex = 0;
            // 
            // bodySecondaryTableLayoutPanel
            // 
            this.bodySecondaryTableLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bodySecondaryTableLayoutPanel.ColumnCount = 1;
            this.bodySecondaryTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.bodySecondaryTableLayoutPanel.Controls.Add(this.passwordGroupBox, 0, 0);
            this.bodySecondaryTableLayoutPanel.Controls.Add(this.rolGroupBox, 0, 1);
            this.bodySecondaryTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodySecondaryTableLayoutPanel.Location = new System.Drawing.Point(400, 3);
            this.bodySecondaryTableLayoutPanel.Name = "bodySecondaryTableLayoutPanel";
            this.bodySecondaryTableLayoutPanel.RowCount = 2;
            this.bodySecondaryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.bodySecondaryTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.bodySecondaryTableLayoutPanel.Size = new System.Drawing.Size(391, 314);
            this.bodySecondaryTableLayoutPanel.TabIndex = 0;
            // 
            // passwordGroupBox
            // 
            this.passwordGroupBox.CaptionVisible = false;
            this.passwordGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passwordGroupBox.Location = new System.Drawing.Point(3, 3);
            this.passwordGroupBox.Name = "passwordGroupBox";
            // 
            // passwordGroupBox.Panel
            // 
            this.passwordGroupBox.Panel.Controls.Add(this.passwordContainerTableLayout);
            this.passwordGroupBox.Size = new System.Drawing.Size(385, 151);
            this.passwordGroupBox.TabIndex = 0;
            // 
            // passwordContainerTableLayout
            // 
            this.passwordContainerTableLayout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.passwordContainerTableLayout.ColumnCount = 2;
            this.passwordContainerTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.passwordContainerTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.passwordContainerTableLayout.Controls.Add(this.passwordLabel, 0, 0);
            this.passwordContainerTableLayout.Controls.Add(this.passwordTextBox, 1, 0);
            this.passwordContainerTableLayout.Controls.Add(this.confirmarPasswordLabel, 0, 1);
            this.passwordContainerTableLayout.Controls.Add(this.confirmarPasswordTextBox, 1, 1);
            this.passwordContainerTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passwordContainerTableLayout.Location = new System.Drawing.Point(0, 0);
            this.passwordContainerTableLayout.Name = "passwordContainerTableLayout";
            this.passwordContainerTableLayout.RowCount = 2;
            this.passwordContainerTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.passwordContainerTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.passwordContainerTableLayout.Size = new System.Drawing.Size(381, 147);
            this.passwordContainerTableLayout.TabIndex = 0;
            // 
            // passwordLabel
            // 
            this.passwordLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passwordLabel.Location = new System.Drawing.Point(3, 3);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(184, 67);
            this.passwordLabel.TabIndex = 0;
            this.passwordLabel.Values.Text = "Ingresa tu contrasena";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordTextBox.Location = new System.Drawing.Point(193, 23);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '●';
            this.passwordTextBox.Size = new System.Drawing.Size(185, 27);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // confirmarPasswordLabel
            // 
            this.confirmarPasswordLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.confirmarPasswordLabel.Location = new System.Drawing.Point(3, 76);
            this.confirmarPasswordLabel.Name = "confirmarPasswordLabel";
            this.confirmarPasswordLabel.Size = new System.Drawing.Size(184, 68);
            this.confirmarPasswordLabel.TabIndex = 2;
            this.confirmarPasswordLabel.Values.Text = "Confirma Tu Contrasena";
            // 
            // confirmarPasswordTextBox
            // 
            this.confirmarPasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmarPasswordTextBox.Location = new System.Drawing.Point(193, 96);
            this.confirmarPasswordTextBox.Name = "confirmarPasswordTextBox";
            this.confirmarPasswordTextBox.PasswordChar = '●';
            this.confirmarPasswordTextBox.Size = new System.Drawing.Size(185, 27);
            this.confirmarPasswordTextBox.TabIndex = 3;
            this.confirmarPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // rolGroupBox
            // 
            this.rolGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rolGroupBox.Location = new System.Drawing.Point(3, 160);
            this.rolGroupBox.Name = "rolGroupBox";
            // 
            // rolGroupBox.Panel
            // 
            this.rolGroupBox.Panel.Controls.Add(this.rolTableLayoutPanel);
            this.rolGroupBox.Size = new System.Drawing.Size(385, 151);
            this.rolGroupBox.TabIndex = 1;
            this.rolGroupBox.Values.Heading = "Seleciona un rol";
            // 
            // rolTableLayoutPanel
            // 
            this.rolTableLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rolTableLayoutPanel.ColumnCount = 2;
            this.rolTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.rolTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.rolTableLayoutPanel.Controls.Add(this.rolLabel, 0, 0);
            this.rolTableLayoutPanel.Controls.Add(this.rolComboBox, 1, 0);
            this.rolTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rolTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.rolTableLayoutPanel.Name = "rolTableLayoutPanel";
            this.rolTableLayoutPanel.RowCount = 1;
            this.rolTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.rolTableLayoutPanel.Size = new System.Drawing.Size(381, 123);
            this.rolTableLayoutPanel.TabIndex = 0;
            // 
            // rolLabel
            // 
            this.rolLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rolLabel.Location = new System.Drawing.Point(3, 3);
            this.rolLabel.Name = "rolLabel";
            this.rolLabel.Size = new System.Drawing.Size(184, 117);
            this.rolLabel.TabIndex = 0;
            this.rolLabel.Values.Text = "Rol Asignado";
            // 
            // rolComboBox
            // 
            this.rolComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rolComboBox.Location = new System.Drawing.Point(193, 3);
            this.rolComboBox.Name = "rolComboBox";
            this.rolComboBox.Size = new System.Drawing.Size(185, 117);
            this.rolComboBox.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.rolComboBox.TabIndex = 1;
            // 
            // userDataGroupBox
            // 
            this.userDataGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userDataGroupBox.Location = new System.Drawing.Point(3, 3);
            this.userDataGroupBox.Name = "userDataGroupBox";
            // 
            // userDataGroupBox.Panel
            // 
            this.userDataGroupBox.Panel.Controls.Add(this.userDataContainerLayoutPanel);
            this.userDataGroupBox.Size = new System.Drawing.Size(391, 314);
            this.userDataGroupBox.TabIndex = 1;
            this.userDataGroupBox.Values.Heading = "Datos De Usuario";
            // 
            // userDataContainerLayoutPanel
            // 
            this.userDataContainerLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.userDataContainerLayoutPanel.ColumnCount = 2;
            this.userDataContainerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.userDataContainerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.userDataContainerLayoutPanel.Controls.Add(this.usuarioLabel, 0, 0);
            this.userDataContainerLayoutPanel.Controls.Add(this.usuarioTextBox, 1, 0);
            this.userDataContainerLayoutPanel.Controls.Add(this.nombreLabel, 0, 1);
            this.userDataContainerLayoutPanel.Controls.Add(this.nombreTextBox, 1, 1);
            this.userDataContainerLayoutPanel.Controls.Add(this.correoLabel, 0, 2);
            this.userDataContainerLayoutPanel.Controls.Add(this.correoTextBox, 1, 2);
            this.userDataContainerLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userDataContainerLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.userDataContainerLayoutPanel.Name = "userDataContainerLayoutPanel";
            this.userDataContainerLayoutPanel.RowCount = 3;
            this.userDataContainerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.userDataContainerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.userDataContainerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.userDataContainerLayoutPanel.Size = new System.Drawing.Size(387, 286);
            this.userDataContainerLayoutPanel.TabIndex = 0;
            // 
            // usuarioLabel
            // 
            this.usuarioLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usuarioLabel.Location = new System.Drawing.Point(3, 3);
            this.usuarioLabel.Name = "usuarioLabel";
            this.usuarioLabel.Size = new System.Drawing.Size(187, 89);
            this.usuarioLabel.TabIndex = 0;
            this.usuarioLabel.Values.Text = "Nombre De Usuario";
            // 
            // usuarioTextBox
            // 
            this.usuarioTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.usuarioTextBox.Location = new System.Drawing.Point(196, 34);
            this.usuarioTextBox.Name = "usuarioTextBox";
            this.usuarioTextBox.Size = new System.Drawing.Size(188, 27);
            this.usuarioTextBox.TabIndex = 1;
            // 
            // nombreLabel
            // 
            this.nombreLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nombreLabel.Location = new System.Drawing.Point(3, 98);
            this.nombreLabel.Name = "nombreLabel";
            this.nombreLabel.Size = new System.Drawing.Size(187, 89);
            this.nombreLabel.TabIndex = 2;
            this.nombreLabel.Values.Text = "Nombre";
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nombreTextBox.Location = new System.Drawing.Point(196, 129);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(188, 27);
            this.nombreTextBox.TabIndex = 3;
            // 
            // correoLabel
            // 
            this.correoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.correoLabel.Location = new System.Drawing.Point(3, 193);
            this.correoLabel.Name = "correoLabel";
            this.correoLabel.Size = new System.Drawing.Size(187, 90);
            this.correoLabel.TabIndex = 4;
            this.correoLabel.Values.Text = "Correo";
            // 
            // correoTextBox
            // 
            this.correoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.correoTextBox.Location = new System.Drawing.Point(196, 224);
            this.correoTextBox.Name = "correoTextBox";
            this.correoTextBox.Size = new System.Drawing.Size(188, 27);
            this.correoTextBox.TabIndex = 5;
            // 
            // guardarButton
            // 
            this.guardarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.guardarButton.Location = new System.Drawing.Point(133, 323);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(131, 51);
            this.guardarButton.TabIndex = 2;
            this.guardarButton.Values.Text = "Registrar";
            this.guardarButton.Click += new System.EventHandler(this.guardarButton_Click);
            // 
            // registrarHuellaButton
            // 
            this.registrarHuellaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.registrarHuellaButton.Location = new System.Drawing.Point(505, 323);
            this.registrarHuellaButton.Name = "registrarHuellaButton";
            this.registrarHuellaButton.Size = new System.Drawing.Size(181, 51);
            this.registrarHuellaButton.TabIndex = 3;
            this.registrarHuellaButton.Values.Text = "Registrar Huella";
            this.registrarHuellaButton.Click += new System.EventHandler(this.registrarHuellaButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.LabelStyle = Krypton.Toolkit.LabelStyle.TitlePanel;
            this.titleLabel.Location = new System.Drawing.Point(3, 3);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(794, 61);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Values.Text = "Registrar Usuario";
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
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainFormLayoutPanel);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "RegisterForm";
            this.Palette = this.kryptonFormsStyle;
            this.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.Text = "RegisterForm";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.mainFormLayoutPanel.ResumeLayout(false);
            this.mainFormLayoutPanel.PerformLayout();
            this.bodyContainerLayoutPanel.ResumeLayout(false);
            this.bodySecondaryTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.passwordGroupBox.Panel)).EndInit();
            this.passwordGroupBox.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.passwordGroupBox)).EndInit();
            this.passwordGroupBox.ResumeLayout(false);
            this.passwordContainerTableLayout.ResumeLayout(false);
            this.passwordContainerTableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rolGroupBox.Panel)).EndInit();
            this.rolGroupBox.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rolGroupBox)).EndInit();
            this.rolGroupBox.ResumeLayout(false);
            this.rolTableLayoutPanel.ResumeLayout(false);
            this.rolTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rolComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userDataGroupBox.Panel)).EndInit();
            this.userDataGroupBox.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userDataGroupBox)).EndInit();
            this.userDataGroupBox.ResumeLayout(false);
            this.userDataContainerLayoutPanel.ResumeLayout(false);
            this.userDataContainerLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        private Krypton.Toolkit.KryptonLabel titleLabel;

        private Krypton.Toolkit.KryptonCustomPaletteBase kryptonFormsStyle;

        private Krypton.Toolkit.KryptonButton guardarButton;

        private Krypton.Toolkit.KryptonButton registrarHuellaButton;

        private Krypton.Toolkit.KryptonComboBox rolComboBox;

        private Krypton.Toolkit.KryptonLabel rolLabel;

        private Krypton.Toolkit.KryptonTableLayoutPanel rolTableLayoutPanel;

        private Krypton.Toolkit.KryptonTextBox confirmarPasswordTextBox;

        private Krypton.Toolkit.KryptonLabel confirmarPasswordLabel;

        private Krypton.Toolkit.KryptonTextBox passwordTextBox;

        private Krypton.Toolkit.KryptonLabel passwordLabel;

        private Krypton.Toolkit.KryptonTableLayoutPanel passwordContainerTableLayout;

        private Krypton.Toolkit.KryptonTextBox correoTextBox;

        private Krypton.Toolkit.KryptonLabel correoLabel;

        private Krypton.Toolkit.KryptonTextBox nombreTextBox;

        private Krypton.Toolkit.KryptonLabel nombreLabel;

        private Krypton.Toolkit.KryptonTextBox usuarioTextBox;

        private Krypton.Toolkit.KryptonLabel usuarioLabel;

        private Krypton.Toolkit.KryptonTableLayoutPanel userDataContainerLayoutPanel;

        private Krypton.Toolkit.KryptonGroupBox userDataGroupBox;

        private Krypton.Toolkit.KryptonGroupBox rolGroupBox;

        private Krypton.Toolkit.KryptonTableLayoutPanel bodyContainerLayoutPanel;

        private Krypton.Toolkit.KryptonTableLayoutPanel bodySecondaryTableLayoutPanel;

        private Krypton.Toolkit.KryptonTableLayoutPanel mainFormLayoutPanel;
        
        private Krypton.Toolkit.KryptonGroupBox passwordGroupBox;

        #endregion
    }
}