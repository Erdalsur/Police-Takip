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
            this.txtchkGeldimi = new System.Windows.Forms.CheckBox();
            this.txtTaksitSayisi = new System.Windows.Forms.NumericUpDown();
            this.btnFirmaBul = new System.Windows.Forms.Button();
            this.btnPoliceBul = new System.Windows.Forms.Button();
            this.lblYenilenmis = new System.Windows.Forms.Label();
            this.btnIptal = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.txtChkTaksit = new System.Windows.Forms.CheckBox();
            this.txtCmbOdemeTuru = new System.Windows.Forms.ComboBox();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.txtPolicelenen = new System.Windows.Forms.TextBox();
            this.txtDateBitisTarih = new System.Windows.Forms.DateTimePicker();
            this.txtDateBaslangicTarih = new System.Windows.Forms.DateTimePicker();
            this.txtPoliceNo = new System.Windows.Forms.TextBox();
            this.txtSigortaFirma = new System.Windows.Forms.TextBox();
            this.txtCmbPoliceTuru = new System.Windows.Forms.ComboBox();
            this.txtPoliceSahibi = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTutar = new System.Windows.Forms.TextBox();
            this.txtOncekiTutar = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtTaksitSayisi)).BeginInit();
            this.SuspendLayout();
            // 
            // txtchkGeldimi
            // 
            this.txtchkGeldimi.AutoSize = true;
            this.txtchkGeldimi.Location = new System.Drawing.Point(111, 371);
            this.txtchkGeldimi.Name = "txtchkGeldimi";
            this.txtchkGeldimi.Size = new System.Drawing.Size(82, 17);
            this.txtchkGeldimi.TabIndex = 140;
            this.txtchkGeldimi.Text = "Poliçe Geldi";
            this.txtchkGeldimi.UseVisualStyleBackColor = true;
            // 
            // txtTaksitSayisi
            // 
            this.txtTaksitSayisi.Location = new System.Drawing.Point(214, 346);
            this.txtTaksitSayisi.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtTaksitSayisi.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtTaksitSayisi.Name = "txtTaksitSayisi";
            this.txtTaksitSayisi.Size = new System.Drawing.Size(52, 20);
            this.txtTaksitSayisi.TabIndex = 130;
            this.txtTaksitSayisi.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnFirmaBul
            // 
            this.btnFirmaBul.Location = new System.Drawing.Point(393, 61);
            this.btnFirmaBul.Name = "btnFirmaBul";
            this.btnFirmaBul.Size = new System.Drawing.Size(35, 31);
            this.btnFirmaBul.TabIndex = 31;
            this.btnFirmaBul.UseVisualStyleBackColor = true;
            this.btnFirmaBul.Click += new System.EventHandler(this.BtnFirmaBul_Click);
            // 
            // btnPoliceBul
            // 
            this.btnPoliceBul.Location = new System.Drawing.Point(335, 10);
            this.btnPoliceBul.Name = "btnPoliceBul";
            this.btnPoliceBul.Size = new System.Drawing.Size(36, 34);
            this.btnPoliceBul.TabIndex = 11;
            this.btnPoliceBul.UseVisualStyleBackColor = true;
            this.btnPoliceBul.Click += new System.EventHandler(this.BtnPoliceBul_Click);
            // 
            // lblYenilenmis
            // 
            this.lblYenilenmis.AutoSize = true;
            this.lblYenilenmis.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblYenilenmis.ForeColor = System.Drawing.Color.Red;
            this.lblYenilenmis.Location = new System.Drawing.Point(60, 390);
            this.lblYenilenmis.Name = "lblYenilenmis";
            this.lblYenilenmis.Size = new System.Drawing.Size(269, 25);
            this.lblYenilenmis.TabIndex = 46;
            this.lblYenilenmis.Text = "Dikkat Poliçe Yenilenmiş";
            this.lblYenilenmis.Visible = false;
            // 
            // btnIptal
            // 
            this.btnIptal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIptal.Location = new System.Drawing.Point(214, 418);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(85, 38);
            this.btnIptal.TabIndex = 160;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = true;
            this.btnIptal.Click += new System.EventHandler(this.BtnIptal_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKaydet.Location = new System.Drawing.Point(58, 418);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(116, 38);
            this.btnKaydet.TabIndex = 150;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // txtChkTaksit
            // 
            this.txtChkTaksit.AutoSize = true;
            this.txtChkTaksit.Checked = true;
            this.txtChkTaksit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.txtChkTaksit.Location = new System.Drawing.Point(111, 350);
            this.txtChkTaksit.Name = "txtChkTaksit";
            this.txtChkTaksit.Size = new System.Drawing.Size(15, 14);
            this.txtChkTaksit.TabIndex = 120;
            this.txtChkTaksit.UseVisualStyleBackColor = true;
            this.txtChkTaksit.CheckedChanged += new System.EventHandler(this.TxtChkTaksit_CheckedChanged);
            // 
            // txtCmbOdemeTuru
            // 
            this.txtCmbOdemeTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtCmbOdemeTuru.FormattingEnabled = true;
            this.txtCmbOdemeTuru.Location = new System.Drawing.Point(111, 265);
            this.txtCmbOdemeTuru.Name = "txtCmbOdemeTuru";
            this.txtCmbOdemeTuru.Size = new System.Drawing.Size(218, 21);
            this.txtCmbOdemeTuru.TabIndex = 90;
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(111, 200);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(333, 58);
            this.txtAciklama.TabIndex = 80;
            // 
            // txtPolicelenen
            // 
            this.txtPolicelenen.Location = new System.Drawing.Point(111, 173);
            this.txtPolicelenen.Name = "txtPolicelenen";
            this.txtPolicelenen.Size = new System.Drawing.Size(333, 20);
            this.txtPolicelenen.TabIndex = 70;
            // 
            // txtDateBitisTarih
            // 
            this.txtDateBitisTarih.Location = new System.Drawing.Point(111, 146);
            this.txtDateBitisTarih.Name = "txtDateBitisTarih";
            this.txtDateBitisTarih.Size = new System.Drawing.Size(218, 20);
            this.txtDateBitisTarih.TabIndex = 60;
            // 
            // txtDateBaslangicTarih
            // 
            this.txtDateBaslangicTarih.Location = new System.Drawing.Point(111, 120);
            this.txtDateBaslangicTarih.Name = "txtDateBaslangicTarih";
            this.txtDateBaslangicTarih.Size = new System.Drawing.Size(218, 20);
            this.txtDateBaslangicTarih.TabIndex = 50;
            this.txtDateBaslangicTarih.ValueChanged += new System.EventHandler(this.TxtDateBaslangicTarih_ValueChanged);
            // 
            // txtPoliceNo
            // 
            this.txtPoliceNo.Location = new System.Drawing.Point(111, 93);
            this.txtPoliceNo.Name = "txtPoliceNo";
            this.txtPoliceNo.Size = new System.Drawing.Size(218, 20);
            this.txtPoliceNo.TabIndex = 40;
            // 
            // txtSigortaFirma
            // 
            this.txtSigortaFirma.Location = new System.Drawing.Point(111, 67);
            this.txtSigortaFirma.Name = "txtSigortaFirma";
            this.txtSigortaFirma.ReadOnly = true;
            this.txtSigortaFirma.Size = new System.Drawing.Size(276, 20);
            this.txtSigortaFirma.TabIndex = 30;
            // 
            // txtCmbPoliceTuru
            // 
            this.txtCmbPoliceTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtCmbPoliceTuru.FormattingEnabled = true;
            this.txtCmbPoliceTuru.Location = new System.Drawing.Point(111, 43);
            this.txtCmbPoliceTuru.Name = "txtCmbPoliceTuru";
            this.txtCmbPoliceTuru.Size = new System.Drawing.Size(218, 21);
            this.txtCmbPoliceTuru.TabIndex = 20;
            // 
            // txtPoliceSahibi
            // 
            this.txtPoliceSahibi.Location = new System.Drawing.Point(111, 18);
            this.txtPoliceSahibi.Name = "txtPoliceSahibi";
            this.txtPoliceSahibi.ReadOnly = true;
            this.txtPoliceSahibi.Size = new System.Drawing.Size(218, 20);
            this.txtPoliceSahibi.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(142, 350);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "Taksit Sayısı";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(69, 350);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "Taksit";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2, 323);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Önceki Poliçe Tutarı";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(73, 296);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Tutar";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(44, 268);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Ödeme Tipi";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(55, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Açıklama";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
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
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Başlangıç Tarihi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
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
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Poliçe Türü";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Poliçe Sahibi";
            // 
            // txtTutar
            // 
            this.txtTutar.Location = new System.Drawing.Point(111, 293);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Size = new System.Drawing.Size(218, 20);
            this.txtTutar.TabIndex = 100;
            // 
            // txtOncekiTutar
            // 
            this.txtOncekiTutar.Location = new System.Drawing.Point(111, 320);
            this.txtOncekiTutar.Name = "txtOncekiTutar";
            this.txtOncekiTutar.Size = new System.Drawing.Size(218, 20);
            this.txtOncekiTutar.TabIndex = 110;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // FrmPolice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 468);
            this.Controls.Add(this.txtOncekiTutar);
            this.Controls.Add(this.txtTutar);
            this.Controls.Add(this.txtchkGeldimi);
            this.Controls.Add(this.txtTaksitSayisi);
            this.Controls.Add(this.btnFirmaBul);
            this.Controls.Add(this.btnPoliceBul);
            this.Controls.Add(this.lblYenilenmis);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtChkTaksit);
            this.Controls.Add(this.txtCmbOdemeTuru);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.txtPolicelenen);
            this.Controls.Add(this.txtDateBitisTarih);
            this.Controls.Add(this.txtDateBaslangicTarih);
            this.Controls.Add(this.txtPoliceNo);
            this.Controls.Add(this.txtSigortaFirma);
            this.Controls.Add(this.txtCmbPoliceTuru);
            this.Controls.Add(this.txtPoliceSahibi);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
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
            this.Controls.Add(this.label1);
            this.Name = "FrmPolice";
            this.Text = "Police Ekranı";
            this.Load += new System.EventHandler(this.FrmPolice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTaksitSayisi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox txtchkGeldimi;
        private System.Windows.Forms.NumericUpDown txtTaksitSayisi;
        private System.Windows.Forms.Button btnFirmaBul;
        private System.Windows.Forms.Button btnPoliceBul;
        private System.Windows.Forms.Label lblYenilenmis;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.CheckBox txtChkTaksit;
        private System.Windows.Forms.ComboBox txtCmbOdemeTuru;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.TextBox txtPolicelenen;
        private System.Windows.Forms.DateTimePicker txtDateBitisTarih;
        private System.Windows.Forms.DateTimePicker txtDateBaslangicTarih;
        private System.Windows.Forms.TextBox txtPoliceNo;
        private System.Windows.Forms.TextBox txtSigortaFirma;
        private System.Windows.Forms.ComboBox txtCmbPoliceTuru;
        private System.Windows.Forms.TextBox txtPoliceSahibi;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTutar;
        private System.Windows.Forms.TextBox txtOncekiTutar;
        private System.Windows.Forms.Timer timer1;
    }
}