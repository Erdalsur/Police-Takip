namespace Policem.UI.Forms
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSigortacilar = new System.Windows.Forms.ToolStripButton();
            this.toolMusteriler = new System.Windows.Forms.ToolStripButton();
            this.toolPoliceler = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSigortacilar,
            this.toolMusteriler,
            this.toolPoliceler});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolSigortacilar
            // 
            this.toolSigortacilar.Image = global::Policem.UI.Properties.Resources.contact_32x32;
            this.toolSigortacilar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSigortacilar.Name = "toolSigortacilar";
            this.toolSigortacilar.Size = new System.Drawing.Size(113, 22);
            this.toolSigortacilar.Text = "Sigorta Firmaları";
            this.toolSigortacilar.Click += new System.EventHandler(this.ToolSigortacilar_Click);
            // 
            // toolMusteriler
            // 
            this.toolMusteriler.Image = global::Policem.UI.Properties.Resources.Assessors;
            this.toolMusteriler.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolMusteriler.Name = "toolMusteriler";
            this.toolMusteriler.Size = new System.Drawing.Size(80, 22);
            this.toolMusteriler.Text = "Müşteriler";
            this.toolMusteriler.Click += new System.EventHandler(this.ToolMusteriler_Click);
            // 
            // toolPoliceler
            // 
            this.toolPoliceler.Image = global::Policem.UI.Properties.Resources.Address_48x48;
            this.toolPoliceler.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPoliceler.Name = "toolPoliceler";
            this.toolPoliceler.Size = new System.Drawing.Size(72, 22);
            this.toolPoliceler.Text = "Poliçeler";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.toolStrip1);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "Poliçe Takip";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolSigortacilar;
        private System.Windows.Forms.ToolStripButton toolMusteriler;
        private System.Windows.Forms.ToolStripButton toolPoliceler;
    }
}