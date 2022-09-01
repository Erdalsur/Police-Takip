namespace Policem.UI.Forms
{
    partial class FrmMusteri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMusteri));
            this.txtKod = new DevExpress.XtraEditors.TextEdit();
            this.txtUnvan = new DevExpress.XtraEditors.TextEdit();
            this.txtYetkili = new DevExpress.XtraEditors.TextEdit();
            this.txtVergiNo = new DevExpress.XtraEditors.TextEdit();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.lblMusteriKod = new DevExpress.XtraEditors.LabelControl();
            this.lblUnvan = new DevExpress.XtraEditors.LabelControl();
            this.lblYetkili = new DevExpress.XtraEditors.LabelControl();
            this.lblVergiNo = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtKod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnvan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYetkili.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVergiNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtKod
            // 
            this.txtKod.Location = new System.Drawing.Point(90, 6);
            this.txtKod.Name = "txtKod";
            this.txtKod.Size = new System.Drawing.Size(144, 20);
            this.txtKod.TabIndex = 71;
            // 
            // txtUnvan
            // 
            this.txtUnvan.Location = new System.Drawing.Point(90, 32);
            this.txtUnvan.Name = "txtUnvan";
            this.txtUnvan.Size = new System.Drawing.Size(268, 20);
            this.txtUnvan.TabIndex = 72;
            // 
            // txtYetkili
            // 
            this.txtYetkili.Location = new System.Drawing.Point(90, 57);
            this.txtYetkili.Name = "txtYetkili";
            this.txtYetkili.Size = new System.Drawing.Size(268, 20);
            this.txtYetkili.TabIndex = 73;
            // 
            // txtVergiNo
            // 
            this.txtVergiNo.Location = new System.Drawing.Point(90, 83);
            this.txtVergiNo.Name = "txtVergiNo";
            this.txtVergiNo.Size = new System.Drawing.Size(268, 20);
            this.txtVergiNo.TabIndex = 74;
            // 
            // btnKaydet
            // 
            this.btnKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.ImageOptions.Image")));
            this.btnKaydet.Location = new System.Drawing.Point(48, 109);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(121, 42);
            this.btnKaydet.TabIndex = 75;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIptal.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnIptal.ImageOptions.Image")));
            this.btnIptal.Location = new System.Drawing.Point(207, 109);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(121, 42);
            this.btnIptal.TabIndex = 76;
            this.btnIptal.Text = "İptal";
            this.btnIptal.Click += new System.EventHandler(this.BtnIptal_Click);
            // 
            // lblMusteriKod
            // 
            this.lblMusteriKod.Location = new System.Drawing.Point(21, 9);
            this.lblMusteriKod.Name = "lblMusteriKod";
            this.lblMusteriKod.Size = new System.Drawing.Size(62, 13);
            this.lblMusteriKod.TabIndex = 77;
            this.lblMusteriKod.Text = "Müşteri Kodu";
            // 
            // lblUnvan
            // 
            this.lblUnvan.Location = new System.Drawing.Point(52, 35);
            this.lblUnvan.Name = "lblUnvan";
            this.lblUnvan.Size = new System.Drawing.Size(31, 13);
            this.lblUnvan.TabIndex = 78;
            this.lblUnvan.Text = "Ünvan";
            // 
            // lblYetkili
            // 
            this.lblYetkili.Location = new System.Drawing.Point(56, 60);
            this.lblYetkili.Name = "lblYetkili";
            this.lblYetkili.Size = new System.Drawing.Size(27, 13);
            this.lblYetkili.TabIndex = 79;
            this.lblYetkili.Text = "Yetkili";
            // 
            // lblVergiNo
            // 
            this.lblVergiNo.Location = new System.Drawing.Point(28, 86);
            this.lblVergiNo.Name = "lblVergiNo";
            this.lblVergiNo.Size = new System.Drawing.Size(55, 13);
            this.lblVergiNo.TabIndex = 80;
            this.lblVergiNo.Text = "VKN / TCKN";
            // 
            // FrmMusteri
            // 
            this.AcceptButton = this.btnKaydet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnIptal;
            this.ClientSize = new System.Drawing.Size(384, 162);
            this.Controls.Add(this.lblVergiNo);
            this.Controls.Add(this.lblYetkili);
            this.Controls.Add(this.lblUnvan);
            this.Controls.Add(this.lblMusteriKod);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtVergiNo);
            this.Controls.Add(this.txtYetkili);
            this.Controls.Add(this.txtUnvan);
            this.Controls.Add(this.txtKod);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "FrmMusteri";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmMusteri";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmMusteri_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMusteri_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txtKod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnvan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYetkili.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVergiNo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txtKod;
        private DevExpress.XtraEditors.TextEdit txtUnvan;
        private DevExpress.XtraEditors.TextEdit txtYetkili;
        private DevExpress.XtraEditors.TextEdit txtVergiNo;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnIptal;
        private DevExpress.XtraEditors.LabelControl lblMusteriKod;
        private DevExpress.XtraEditors.LabelControl lblUnvan;
        private DevExpress.XtraEditors.LabelControl lblYetkili;
        private DevExpress.XtraEditors.LabelControl lblVergiNo;
    }
}