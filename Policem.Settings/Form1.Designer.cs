namespace Policem.Settings
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtcmbServer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMailServer = new System.Windows.Forms.TextBox();
            this.txtMailServerPort = new System.Windows.Forms.TextBox();
            this.txtchkSSL = new System.Windows.Forms.CheckBox();
            this.txtMailKullaniciAdi = new System.Windows.Forms.TextBox();
            this.txtMailPassword = new System.Windows.Forms.TextBox();
            this.txtMailRaporAdresler = new System.Windows.Forms.TextBox();
            this.txtMailOutlookTakvimAdres = new System.Windows.Forms.TextBox();
            this.btnDatabaseKaydet = new System.Windows.Forms.Button();
            this.btnMailKaydet = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(347, 236);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnDatabaseKaydet);
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.txtSifre);
            this.tabPage1.Controls.Add(this.txtKullaniciAdi);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtcmbServer);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(339, 210);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DataBase";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnMailKaydet);
            this.tabPage2.Controls.Add(this.txtMailOutlookTakvimAdres);
            this.tabPage2.Controls.Add(this.txtMailRaporAdresler);
            this.tabPage2.Controls.Add(this.txtMailPassword);
            this.tabPage2.Controls.Add(this.txtMailKullaniciAdi);
            this.tabPage2.Controls.Add(this.txtchkSSL);
            this.tabPage2.Controls.Add(this.txtMailServerPort);
            this.tabPage2.Controls.Add(this.txtMailServer);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(339, 210);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mail";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtcmbServer
            // 
            this.txtcmbServer.FormattingEnabled = true;
            this.txtcmbServer.Location = new System.Drawing.Point(79, 6);
            this.txtcmbServer.Name = "txtcmbServer";
            this.txtcmbServer.Size = new System.Drawing.Size(238, 21);
            this.txtcmbServer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "SQL Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kullanıcı Adı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Şifre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "DataBase Adı";
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new System.Drawing.Point(79, 33);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(235, 20);
            this.txtKullaniciAdi.TabIndex = 3;
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(79, 59);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(235, 20);
            this.txtSifre.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(79, 85);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(235, 20);
            this.textBox3.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mail Server";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mail Server Port";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(115, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "SSL";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(78, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Kullanici Adi";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(65, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Kullanici Şifresi";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Rapor Atilacak Mailler";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 189);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Outlook Takvim Mail Adresi";
            this.label11.Visible = false;
            // 
            // txtMailServer
            // 
            this.txtMailServer.Location = new System.Drawing.Point(148, 13);
            this.txtMailServer.Name = "txtMailServer";
            this.txtMailServer.Size = new System.Drawing.Size(183, 20);
            this.txtMailServer.TabIndex = 1;
            // 
            // txtMailServerPort
            // 
            this.txtMailServerPort.Location = new System.Drawing.Point(148, 37);
            this.txtMailServerPort.Name = "txtMailServerPort";
            this.txtMailServerPort.Size = new System.Drawing.Size(183, 20);
            this.txtMailServerPort.TabIndex = 1;
            // 
            // txtchkSSL
            // 
            this.txtchkSSL.AutoSize = true;
            this.txtchkSSL.Location = new System.Drawing.Point(148, 63);
            this.txtchkSSL.Name = "txtchkSSL";
            this.txtchkSSL.Size = new System.Drawing.Size(15, 14);
            this.txtchkSSL.TabIndex = 2;
            this.txtchkSSL.UseVisualStyleBackColor = true;
            // 
            // txtMailKullaniciAdi
            // 
            this.txtMailKullaniciAdi.Location = new System.Drawing.Point(148, 81);
            this.txtMailKullaniciAdi.Name = "txtMailKullaniciAdi";
            this.txtMailKullaniciAdi.Size = new System.Drawing.Size(183, 20);
            this.txtMailKullaniciAdi.TabIndex = 3;
            // 
            // txtMailPassword
            // 
            this.txtMailPassword.Location = new System.Drawing.Point(148, 106);
            this.txtMailPassword.Name = "txtMailPassword";
            this.txtMailPassword.Size = new System.Drawing.Size(183, 20);
            this.txtMailPassword.TabIndex = 3;
            // 
            // txtMailRaporAdresler
            // 
            this.txtMailRaporAdresler.Location = new System.Drawing.Point(148, 129);
            this.txtMailRaporAdresler.Name = "txtMailRaporAdresler";
            this.txtMailRaporAdresler.Size = new System.Drawing.Size(183, 20);
            this.txtMailRaporAdresler.TabIndex = 3;
            // 
            // txtMailOutlookTakvimAdres
            // 
            this.txtMailOutlookTakvimAdres.Location = new System.Drawing.Point(148, 186);
            this.txtMailOutlookTakvimAdres.Name = "txtMailOutlookTakvimAdres";
            this.txtMailOutlookTakvimAdres.Size = new System.Drawing.Size(183, 20);
            this.txtMailOutlookTakvimAdres.TabIndex = 3;
            this.txtMailOutlookTakvimAdres.Visible = false;
            // 
            // btnDatabaseKaydet
            // 
            this.btnDatabaseKaydet.Location = new System.Drawing.Point(79, 112);
            this.btnDatabaseKaydet.Name = "btnDatabaseKaydet";
            this.btnDatabaseKaydet.Size = new System.Drawing.Size(123, 41);
            this.btnDatabaseKaydet.TabIndex = 4;
            this.btnDatabaseKaydet.Text = "Kaydet";
            this.btnDatabaseKaydet.UseVisualStyleBackColor = true;
            this.btnDatabaseKaydet.Click += new System.EventHandler(this.btnDatabaseKaydet_Click);
            // 
            // btnMailKaydet
            // 
            this.btnMailKaydet.Location = new System.Drawing.Point(118, 161);
            this.btnMailKaydet.Name = "btnMailKaydet";
            this.btnMailKaydet.Size = new System.Drawing.Size(123, 41);
            this.btnMailKaydet.TabIndex = 5;
            this.btnMailKaydet.Text = "Kaydet";
            this.btnMailKaydet.UseVisualStyleBackColor = true;
            this.btnMailKaydet.Click += new System.EventHandler(this.btnDatabaseKaydet_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 236);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Ayarlar";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox txtcmbServer;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMailOutlookTakvimAdres;
        private System.Windows.Forms.TextBox txtMailRaporAdresler;
        private System.Windows.Forms.TextBox txtMailPassword;
        private System.Windows.Forms.TextBox txtMailKullaniciAdi;
        private System.Windows.Forms.CheckBox txtchkSSL;
        private System.Windows.Forms.TextBox txtMailServerPort;
        private System.Windows.Forms.TextBox txtMailServer;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnDatabaseKaydet;
        private System.Windows.Forms.Button btnMailKaydet;
    }
}

