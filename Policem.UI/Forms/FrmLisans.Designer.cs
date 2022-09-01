namespace Policem.UI.Forms
{
    partial class FrmLisans
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnAktivasyon = new DevExpress.XtraEditors.SimpleButton();
            this.txtSerial = new DevExpress.XtraEditors.TextEdit();
            this.txtAktivasyonKodu = new DevExpress.XtraEditors.TextEdit();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.txtFirma = new DevExpress.XtraEditors.TextEdit();
            this.txtAd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAktivasyonKodu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirma.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.ContentImage = global::Policem.UI.Properties.Resources.tokalasma;
            this.panelControl1.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.panelControl1.Controls.Add(this.btnAktivasyon);
            this.panelControl1.Controls.Add(this.txtSerial);
            this.panelControl1.Controls.Add(this.txtAktivasyonKodu);
            this.panelControl1.Controls.Add(this.txtEmail);
            this.panelControl1.Controls.Add(this.txtFirma);
            this.panelControl1.Controls.Add(this.txtAd);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(633, 230);
            this.panelControl1.TabIndex = 11;
            // 
            // btnAktivasyon
            // 
            this.btnAktivasyon.Location = new System.Drawing.Point(221, 143);
            this.btnAktivasyon.Name = "btnAktivasyon";
            this.btnAktivasyon.Size = new System.Drawing.Size(163, 59);
            this.btnAktivasyon.TabIndex = 40;
            this.btnAktivasyon.Text = "Aktivasyon";
            this.btnAktivasyon.Click += new System.EventHandler(this.btnAktivasyon_Click);
            // 
            // txtSerial
            // 
            this.txtSerial.Location = new System.Drawing.Point(115, 117);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(269, 20);
            this.txtSerial.TabIndex = 30;
            // 
            // txtAktivasyonKodu
            // 
            this.txtAktivasyonKodu.Location = new System.Drawing.Point(115, 91);
            this.txtAktivasyonKodu.Name = "txtAktivasyonKodu";
            this.txtAktivasyonKodu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtAktivasyonKodu.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txtAktivasyonKodu.Properties.Appearance.Options.UseFont = true;
            this.txtAktivasyonKodu.Properties.Appearance.Options.UseForeColor = true;
            this.txtAktivasyonKodu.Properties.ReadOnly = true;
            this.txtAktivasyonKodu.Size = new System.Drawing.Size(269, 20);
            this.txtAktivasyonKodu.TabIndex = 3;
            this.txtAktivasyonKodu.TabStop = false;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(115, 64);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.ValidateOnEnterKey = true;
            this.txtEmail.Size = new System.Drawing.Size(269, 20);
            this.txtEmail.TabIndex = 20;
            // 
            // txtFirma
            // 
            this.txtFirma.Location = new System.Drawing.Point(115, 38);
            this.txtFirma.Name = "txtFirma";
            this.txtFirma.Size = new System.Drawing.Size(269, 20);
            this.txtFirma.TabIndex = 10;
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(115, 12);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(269, 20);
            this.txtAd.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(36, 120);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(73, 13);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Lisans Anahtarı";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 94);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(97, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Aktivasyon Anahtarı";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(81, 67);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(28, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "E-Mail";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(82, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(27, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Şirket";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(63, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Ad Soyad";
            // 
            // FrmLisans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 230);
            this.Controls.Add(this.panelControl1);
            this.Name = "FrmLisans";
            this.Text = "Lisans";
            this.Load += new System.EventHandler(this.FrmLisans_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAktivasyonKodu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirma.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAd.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnAktivasyon;
        private DevExpress.XtraEditors.TextEdit txtSerial;
        private DevExpress.XtraEditors.TextEdit txtAktivasyonKodu;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.TextEdit txtFirma;
        private DevExpress.XtraEditors.TextEdit txtAd;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}