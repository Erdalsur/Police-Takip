namespace Policem.UI.Forms
{
    partial class FrmPolice
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPolice));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BtnTaramaAc = new DevExpress.XtraEditors.SimpleButton();
            this.BtnPoliceTara = new DevExpress.XtraEditors.SimpleButton();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.lblYenilenmis = new DevExpress.XtraEditors.LabelControl();
            this.txtchkGeldimi = new DevExpress.XtraEditors.CheckEdit();
            this.txtTaksitSayisi = new DevExpress.XtraEditors.SpinEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.txtChkTaksit = new DevExpress.XtraEditors.CheckEdit();
            this.txtOncekiTutar = new DevExpress.XtraEditors.TextEdit();
            this.txtTutar = new DevExpress.XtraEditors.TextEdit();
            this.txtAciklama = new DevExpress.XtraEditors.MemoEdit();
            this.txtPolicelenen = new DevExpress.XtraEditors.TextEdit();
            this.txtDateBitisTarih = new DevExpress.XtraEditors.DateEdit();
            this.txtDateBaslangicTarih = new DevExpress.XtraEditors.DateEdit();
            this.txtPoliceNo = new DevExpress.XtraEditors.TextEdit();
            this.txtSigortaFirma = new DevExpress.XtraEditors.ButtonEdit();
            this.txtCmbOdemeTuru = new DevExpress.XtraEditors.LookUpEdit();
            this.txtCmbPoliceTuru = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPoliceSahibi = new DevExpress.XtraEditors.ButtonEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtchkGeldimi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaksitSayisi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChkTaksit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOncekiTutar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTutar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPolicelenen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateBitisTarih.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateBitisTarih.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateBaslangicTarih.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateBaslangicTarih.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPoliceNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSigortaFirma.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCmbOdemeTuru.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCmbPoliceTuru.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPoliceSahibi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // BtnTaramaAc
            // 
            this.BtnTaramaAc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.BtnTaramaAc.Location = new System.Drawing.Point(346, 62);
            this.BtnTaramaAc.Name = "BtnTaramaAc";
            this.BtnTaramaAc.Size = new System.Drawing.Size(101, 47);
            this.BtnTaramaAc.TabIndex = 180;
            this.BtnTaramaAc.Text = "Taramayı Aç";
            this.BtnTaramaAc.Click += new System.EventHandler(this.BtnTaranmisPoliceAc_Click);
            // 
            // BtnPoliceTara
            // 
            this.BtnPoliceTara.ImageOptions.Image = global::Policem.UI.Properties.Resources.scanner;
            this.BtnPoliceTara.Location = new System.Drawing.Point(346, 12);
            this.BtnPoliceTara.Name = "BtnPoliceTara";
            this.BtnPoliceTara.Size = new System.Drawing.Size(101, 47);
            this.BtnPoliceTara.TabIndex = 179;
            this.BtnPoliceTara.Text = "Poliçe Tara";
            this.BtnPoliceTara.Click += new System.EventHandler(this.BtnPoliceTara_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIptal.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnIptal.ImageOptions.Image")));
            this.btnIptal.Location = new System.Drawing.Point(213, 418);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(121, 42);
            this.btnIptal.TabIndex = 15;
            this.btnIptal.Text = "İptal";
            this.btnIptal.Click += new System.EventHandler(this.BtnIptal_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.ImageOptions.Image")));
            this.btnKaydet.Location = new System.Drawing.Point(54, 418);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(121, 42);
            this.btnKaydet.TabIndex = 14;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // lblYenilenmis
            // 
            this.lblYenilenmis.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblYenilenmis.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblYenilenmis.Appearance.Options.UseFont = true;
            this.lblYenilenmis.Appearance.Options.UseForeColor = true;
            this.lblYenilenmis.Location = new System.Drawing.Point(58, 387);
            this.lblYenilenmis.Name = "lblYenilenmis";
            this.lblYenilenmis.Size = new System.Drawing.Size(257, 25);
            this.lblYenilenmis.TabIndex = 178;
            this.lblYenilenmis.Text = "Dikkat Poliçe Yenilenmiş";
            // 
            // txtchkGeldimi
            // 
            this.txtchkGeldimi.Location = new System.Drawing.Point(111, 371);
            this.txtchkGeldimi.Name = "txtchkGeldimi";
            this.txtchkGeldimi.Properties.Caption = "Poliçe Geldi mi?";
            this.txtchkGeldimi.Size = new System.Drawing.Size(121, 19);
            this.txtchkGeldimi.TabIndex = 13;
            // 
            // txtTaksitSayisi
            // 
            this.txtTaksitSayisi.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtTaksitSayisi.Location = new System.Drawing.Point(253, 346);
            this.txtTaksitSayisi.Name = "txtTaksitSayisi";
            this.txtTaksitSayisi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTaksitSayisi.Properties.IsFloatValue = false;
            this.txtTaksitSayisi.Properties.Mask.EditMask = "N00";
            this.txtTaksitSayisi.Properties.MaxValue = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.txtTaksitSayisi.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtTaksitSayisi.Size = new System.Drawing.Size(58, 20);
            this.txtTaksitSayisi.TabIndex = 12;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(182, 349);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "Taksit Sayısı";
            // 
            // txtChkTaksit
            // 
            this.txtChkTaksit.Location = new System.Drawing.Point(111, 346);
            this.txtChkTaksit.Name = "txtChkTaksit";
            this.txtChkTaksit.Properties.Caption = "Taksit";
            this.txtChkTaksit.Size = new System.Drawing.Size(75, 19);
            this.txtChkTaksit.TabIndex = 11;
            this.txtChkTaksit.CheckedChanged += new System.EventHandler(this.TxtChkTaksit_CheckedChanged);
            // 
            // txtOncekiTutar
            // 
            this.txtOncekiTutar.EditValue = "";
            this.txtOncekiTutar.Location = new System.Drawing.Point(112, 320);
            this.txtOncekiTutar.Name = "txtOncekiTutar";
            this.txtOncekiTutar.Properties.Appearance.Options.UseTextOptions = true;
            this.txtOncekiTutar.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtOncekiTutar.Properties.DisplayFormat.FormatString = "\"#,###.## \'TL\'";
            this.txtOncekiTutar.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtOncekiTutar.Size = new System.Drawing.Size(217, 20);
            this.txtOncekiTutar.TabIndex = 10;
            // 
            // txtTutar
            // 
            this.txtTutar.EditValue = "";
            this.txtTutar.Location = new System.Drawing.Point(112, 293);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTutar.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTutar.Properties.DisplayFormat.FormatString = "\"#,###.## \'TL\'";
            this.txtTutar.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtTutar.Size = new System.Drawing.Size(217, 20);
            this.txtTutar.TabIndex = 9;
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(112, 201);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(331, 58);
            this.txtAciklama.TabIndex = 7;
            // 
            // txtPolicelenen
            // 
            this.txtPolicelenen.Location = new System.Drawing.Point(111, 173);
            this.txtPolicelenen.Name = "txtPolicelenen";
            this.txtPolicelenen.Size = new System.Drawing.Size(332, 20);
            this.txtPolicelenen.TabIndex = 6;
            // 
            // txtDateBitisTarih
            // 
            this.txtDateBitisTarih.EditValue = null;
            this.txtDateBitisTarih.Location = new System.Drawing.Point(111, 149);
            this.txtDateBitisTarih.Name = "txtDateBitisTarih";
            this.txtDateBitisTarih.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDateBitisTarih.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDateBitisTarih.Properties.DisplayFormat.FormatString = "D";
            this.txtDateBitisTarih.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDateBitisTarih.Size = new System.Drawing.Size(218, 20);
            this.txtDateBitisTarih.TabIndex = 5;
            // 
            // txtDateBaslangicTarih
            // 
            this.txtDateBaslangicTarih.EditValue = null;
            this.txtDateBaslangicTarih.Location = new System.Drawing.Point(111, 123);
            this.txtDateBaslangicTarih.Name = "txtDateBaslangicTarih";
            this.txtDateBaslangicTarih.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDateBaslangicTarih.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDateBaslangicTarih.Properties.DisplayFormat.FormatString = "D";
            this.txtDateBaslangicTarih.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDateBaslangicTarih.Size = new System.Drawing.Size(218, 20);
            this.txtDateBaslangicTarih.TabIndex = 4;
            this.txtDateBaslangicTarih.EditValueChanged += new System.EventHandler(this.TxtDateBaslangicTarih_EditValueChanged);
            // 
            // txtPoliceNo
            // 
            this.txtPoliceNo.Location = new System.Drawing.Point(111, 93);
            this.txtPoliceNo.Name = "txtPoliceNo";
            this.txtPoliceNo.Size = new System.Drawing.Size(218, 20);
            this.txtPoliceNo.TabIndex = 3;
            // 
            // txtSigortaFirma
            // 
            this.txtSigortaFirma.Location = new System.Drawing.Point(111, 67);
            this.txtSigortaFirma.Name = "txtSigortaFirma";
            this.txtSigortaFirma.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtSigortaFirma.Properties.ReadOnly = true;
            this.txtSigortaFirma.Size = new System.Drawing.Size(218, 20);
            this.txtSigortaFirma.TabIndex = 2;
            this.txtSigortaFirma.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.TxtSigortaFirma_ButtonClick);
            // 
            // txtCmbOdemeTuru
            // 
            this.txtCmbOdemeTuru.Location = new System.Drawing.Point(111, 265);
            this.txtCmbOdemeTuru.Name = "txtCmbOdemeTuru";
            this.txtCmbOdemeTuru.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtCmbOdemeTuru.Size = new System.Drawing.Size(218, 20);
            this.txtCmbOdemeTuru.TabIndex = 8;
            // 
            // txtCmbPoliceTuru
            // 
            this.txtCmbPoliceTuru.Location = new System.Drawing.Point(111, 43);
            this.txtCmbPoliceTuru.Name = "txtCmbPoliceTuru";
            this.txtCmbPoliceTuru.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtCmbPoliceTuru.Size = new System.Drawing.Size(218, 20);
            this.txtCmbPoliceTuru.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(44, 20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 162;
            this.labelControl1.Text = "Poliçe Sahibi";
            // 
            // txtPoliceSahibi
            // 
            this.txtPoliceSahibi.Location = new System.Drawing.Point(111, 17);
            this.txtPoliceSahibi.Name = "txtPoliceSahibi";
            this.txtPoliceSahibi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtPoliceSahibi.Properties.ReadOnly = true;
            this.txtPoliceSahibi.Size = new System.Drawing.Size(218, 20);
            this.txtPoliceSahibi.TabIndex = 0;
            this.txtPoliceSahibi.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.TxtPoliceSahibi_ButtonClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2, 323);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Önceki Poliçe Tutarı";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(73, 296);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Tutar";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(44, 268);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Ödeme Tipi";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(55, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Açıklama";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Poliçelenen";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Bitiş Tarihi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Başlangıç Tarihi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Poliçe Numarası";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Poliçeleyen Firma";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Poliçe Türü";
            // 
            // FrmPolice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 472);
            this.Controls.Add(this.BtnTaramaAc);
            this.Controls.Add(this.BtnPoliceTara);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.lblYenilenmis);
            this.Controls.Add(this.txtchkGeldimi);
            this.Controls.Add(this.txtTaksitSayisi);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtChkTaksit);
            this.Controls.Add(this.txtOncekiTutar);
            this.Controls.Add(this.txtTutar);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.txtPolicelenen);
            this.Controls.Add(this.txtDateBitisTarih);
            this.Controls.Add(this.txtDateBaslangicTarih);
            this.Controls.Add(this.txtPoliceNo);
            this.Controls.Add(this.txtSigortaFirma);
            this.Controls.Add(this.txtCmbOdemeTuru);
            this.Controls.Add(this.txtCmbPoliceTuru);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtPoliceSahibi);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(475, 510);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(475, 510);
            this.Name = "FrmPolice";
            this.Text = "Police Ekranı";
            this.Load += new System.EventHandler(this.FrmPolice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtchkGeldimi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaksitSayisi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChkTaksit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOncekiTutar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTutar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPolicelenen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateBitisTarih.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateBitisTarih.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateBaslangicTarih.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateBaslangicTarih.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPoliceNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSigortaFirma.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCmbOdemeTuru.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCmbPoliceTuru.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPoliceSahibi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.ButtonEdit txtPoliceSahibi;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit txtCmbPoliceTuru;
        private DevExpress.XtraEditors.LookUpEdit txtCmbOdemeTuru;
        private DevExpress.XtraEditors.ButtonEdit txtSigortaFirma;
        private DevExpress.XtraEditors.TextEdit txtPoliceNo;
        private DevExpress.XtraEditors.DateEdit txtDateBaslangicTarih;
        private DevExpress.XtraEditors.DateEdit txtDateBitisTarih;
        private DevExpress.XtraEditors.TextEdit txtPolicelenen;
        private DevExpress.XtraEditors.MemoEdit txtAciklama;
        private DevExpress.XtraEditors.TextEdit txtTutar;
        private DevExpress.XtraEditors.TextEdit txtOncekiTutar;
        private DevExpress.XtraEditors.CheckEdit txtChkTaksit;
        private DevExpress.XtraEditors.SpinEdit txtTaksitSayisi;
        private DevExpress.XtraEditors.CheckEdit txtchkGeldimi;
        private DevExpress.XtraEditors.LabelControl lblYenilenmis;
        private DevExpress.XtraEditors.SimpleButton btnIptal;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton BtnPoliceTara;
        private DevExpress.XtraEditors.SimpleButton BtnTaramaAc;
    }
}