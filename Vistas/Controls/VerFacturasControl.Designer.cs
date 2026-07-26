namespace Proyecto_Grupo2.Vistas.Controls
{
    partial class VerFacturasControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerFacturasControl));
            this.kryptonTableLayoutPanel1 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.kryptonTableLayoutPanel2 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonTableLayoutPanel1.SuspendLayout();
            this.kryptonTableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonTableLayoutPanel1
            // 
            this.kryptonTableLayoutPanel1.AutoSize = true;
            this.kryptonTableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kryptonTableLayoutPanel1.ColumnCount = 1;
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.kryptonTableLayoutPanel1.Controls.Add(this.kryptonTableLayoutPanel2, 0, 0);
            this.kryptonTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonTableLayoutPanel1.Name = "kryptonTableLayoutPanel1";
            this.kryptonTableLayoutPanel1.RowCount = 2;
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.kryptonTableLayoutPanel1.Size = new System.Drawing.Size(800, 587);
            this.kryptonTableLayoutPanel1.TabIndex = 0;
            // 
            // kryptonTableLayoutPanel2
            // 
            this.kryptonTableLayoutPanel2.AutoSize = true;
            this.kryptonTableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kryptonTableLayoutPanel2.ColumnCount = 3;
            this.kryptonTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.kryptonTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.kryptonTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.kryptonTableLayoutPanel2.Controls.Add(this.kryptonLabel1, 1, 0);
            this.kryptonTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.kryptonTableLayoutPanel2.Name = "kryptonTableLayoutPanel2";
            this.kryptonTableLayoutPanel2.RowCount = 1;
            this.kryptonTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel2.Size = new System.Drawing.Size(794, 82);
            this.kryptonTableLayoutPanel2.TabIndex = 0;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.TitlePanel;
            this.kryptonLabel1.Location = new System.Drawing.Point(267, 3);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(258, 76);
            this.kryptonLabel1.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel1.StateCommon.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Facturas";
            // 
            // VerFacturasControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonTableLayoutPanel1);
            this.Name = "VerFacturasControl";
            this.Size = new System.Drawing.Size(800, 587);
            this.kryptonTableLayoutPanel1.ResumeLayout(false);
            this.kryptonTableLayoutPanel1.PerformLayout();
            this.kryptonTableLayoutPanel2.ResumeLayout(false);
            this.kryptonTableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonTableLayoutPanel kryptonTableLayoutPanel1;
        private Krypton.Toolkit.KryptonTableLayoutPanel kryptonTableLayoutPanel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}
