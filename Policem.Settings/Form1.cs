using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Policem.Settings
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            foreach (DataRow serverRow in dt.Rows)
            {
                if (serverRow[dt.Columns["InstanceName"]].ToString() == "")
                {
                    txtcmbServer.Items.Add(serverRow[dt.Columns["ServerName"]].ToString());
                }
                else
                {
                    txtcmbServer.Items.Add(serverRow[dt.Columns["ServerName"]].ToString() + "\\" +
                                        (serverRow[dt.Columns["InstanceName"]].ToString()));
                }
            }

            DatabaseSettingsRead();
            MailSettingsRead();
        }

        private void DatabaseSettingsRead()
        {
            txtcmbServer.Text = IniIslemleri.VeriOku("DataSetting", "Host");
            txtKullaniciAdi.Text = IniIslemleri.VeriOku("DataSetting", "User");
            textBox3.Text = IniIslemleri.VeriOku("DataSetting", "DataBase");
            var SifreHash = IniIslemleri.VeriOku("DataSetting", "Password");
            var Sifre = CryptoManager.SifreCoz(SifreHash);
            txtSifre.Text = Sifre;
        }

        private void DatabaseSettingsWrite()
        {
            IniIslemleri.VeriYaz("DataSetting", "Host", txtcmbServer.Text.Trim());
            IniIslemleri.VeriYaz("DataSetting", "User",txtKullaniciAdi.Text.Trim());
            IniIslemleri.VeriYaz("DataSetting", "DataBase",textBox3.Text.Trim());
            var sifre = txtSifre.Text.Trim();
            IniIslemleri.VeriYaz("DataSetting", "Password", CryptoManager.Sifrele(sifre));
        }
        private void MailSettingsRead()
        {
            txtMailServer.Text = IniIslemleri.VeriOku("MailSetting", "Host");
            txtMailServerPort.Text = IniIslemleri.VeriOku("MailSetting", "Port");
            var ssl = IniIslemleri.VeriOku("MailSetting", "SSL");
            if (ssl == "True")
                txtchkSSL.Checked = true;
            else
                txtchkSSL.Checked = false;
            txtMailKullaniciAdi.Text = IniIslemleri.VeriOku("MailSetting", "Kullanici");
            var sifre = IniIslemleri.VeriOku("MailSetting", "Password");
            txtMailPassword.Text = CryptoManager.SifreCoz(sifre);

            txtMailRaporAdresler.Text = IniIslemleri.VeriOku("Guvercin", "Adres");
        }
        private void MailSettingsWrite()
        {
            IniIslemleri.VeriYaz("MailSetting", "Host", txtMailServer.Text.Trim());
            IniIslemleri.VeriYaz("MailSetting", "Port", txtMailServerPort.Text.Trim());
            //var ssl=
            IniIslemleri.VeriYaz("MailSetting", "SSL", txtchkSSL.Checked.ToString());
            IniIslemleri.VeriYaz("MailSetting", "Kullanici", txtMailKullaniciAdi.Text.Trim());
            var sifre = txtMailPassword.Text.Trim();
            IniIslemleri.VeriYaz("MailSetting", "Password", CryptoManager.Sifrele(sifre));

            IniIslemleri.VeriYaz("Guvercin", "Adres", txtMailRaporAdresler.Text.Trim());
        }

        private void btnDatabaseKaydet_Click(object sender, EventArgs e)
        {
            DatabaseSettingsWrite();
            MailSettingsWrite();
        }
    }
}
