using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Win32;
using Policem.Core.Extensions;
using Policem.Core.Utility;
using Policem.Services.DependencyResolution;
using Policem.UI.Forms.Base;


namespace Policem.UI.Forms
{
    public partial class FrmDatabaseSettings : XPopupForm
    {
        Configuration config,config2;
        public List<string> DataBaseBilgi = null;
        public FrmDatabaseSettings()
        {
            InitializeComponent();
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            string configPath = Path.Combine(System.Environment.CurrentDirectory, "Policem.Services.exe");
            try
            {
                config2 = ConfigurationManager.OpenExeConfiguration(configPath);
            }
            catch { }
        }

        private void YukluSQL()
        {
            string[] yuklusqller = (string[])Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("Microsoft").OpenSubKey("Microsoft SQL Server").GetValue("InstalledInstances");
            var yukluozellikler = (from s in yuklusqller
                                   where s.Contains("SQLEXPRESS")
                                   select s).FirstOrDefault();
            if (yuklusqller == null)
            {
                MessageBox.Show("Programı kullanabilmek için SQL Server yüklenmelidir.", "UYARI");
                Application.Exit();
            }
            /*
            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                if (instanceKey != null)
                {
                    foreach (var instanceName in instanceKey.GetValueNames())
                    {
                        comboBoxEdit1.(Environment.MachineName + @"\" + instanceName);
                    }
                }
            }*/
        }

        private void FrmDatabaseSettings_Load(object sender, EventArgs e)
        {
            btnKaydet.Enabled = false;
            DatabaseBilgiOku();
        }

        private void DatabaseBilgiOku()
        {
            string databasestring = GetConnectionString("PoliceTakip");
            DataBaseBilgi = databasestring.ReverseStringFormat("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}");
            txtServer.EditValue = DataBaseBilgi[0];
            txtDatabaseName.EditValue = DataBaseBilgi[1];
            txtKullanici.EditValue = DataBaseBilgi[2];
            txtSifre.EditValue = DataBaseBilgi[3];
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            config.ConnectionStrings.ConnectionStrings["PoliceTakip"].ConnectionString = String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                txtServer.EditValue.ToString().Trim(),txtDatabaseName.EditValue.ToString().Trim(),txtKullanici.EditValue.ToString().Trim(),txtSifre.EditValue.ToString().Trim());
            config.ConnectionStrings.ConnectionStrings["PoliceTakipDosya"].ConnectionString = String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                txtServer.EditValue.ToString().Trim(), txtDatabaseName.EditValue.ToString().Trim()+"Dosya", txtKullanici.EditValue.ToString().Trim(), txtSifre.EditValue.ToString().Trim());
            config.Save(ConfigurationSaveMode.Modified);
            Properties.Settings.Default.Upgrade();
            IniIslemleri.VeriYaz("DataSetting", "Host", txtServer.EditValue.ToString().Trim());
            IniIslemleri.VeriYaz("DataSetting", "DataBase", txtDatabaseName.EditValue.ToString().Trim());
            IniIslemleri.VeriYaz("DataSetting", "User", txtKullanici.EditValue.ToString().Trim());
            var sifre = txtSifre.EditValue.ToString().Trim();
            IniIslemleri.VeriYaz("DataSetting", "Password", CryptoManager.Sifrele(sifre));
            XtraMessageBox.Show("Program Tekrar Başlatılacak...","Uyarı");
            try
            {
                config2.ConnectionStrings.ConnectionStrings["PoliceTakip"].ConnectionString = String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                    txtServer.EditValue.ToString().Trim(), txtDatabaseName.EditValue.ToString().Trim(), txtKullanici.EditValue.ToString().Trim(), txtSifre.EditValue.ToString().Trim());
                config2.ConnectionStrings.ConnectionStrings["PoliceTakipDosya"].ConnectionString = String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                    txtServer.EditValue.ToString().Trim(), txtDatabaseName.EditValue.ToString().Trim() + "Dosya", txtKullanici.EditValue.ToString().Trim(), txtSifre.EditValue.ToString().Trim());
                config2.Save();
            }
            catch { }
            Application.Restart();
        }

        //Get connection string from App.Config file
        public string GetConnectionString(string key)
        {
            return config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
        }

        private void txtServer_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string[] servers = SqlLocator.GetServers();
            this.Cursor = Cursors.Default;
            if (servers == null)
            {
                int num = (int)MessageBox.Show("Programı kullanabilmek için SQL Server yüklenmelidir.", "SQL Server");
            }
            else
            {
                string str = FrmSQLList.DoPickServer(servers);
                if (str != string.Empty)
                    this.txtServer.Text = str;
            }
            this.txtServer.Focus();
        }

        //Save connection string to App.config file
        public void SaveConnectionString(string key, string value)
        {
            config.ConnectionStrings.ConnectionStrings[key].ConnectionString = value;
            config.ConnectionStrings.ConnectionStrings[key].ProviderName = "System.Data.SqlClient";
            config.Save(ConfigurationSaveMode.Modified);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //YukluSQL();
            btnKaydet.Enabled = CheckDbConnection(txtServer.Text, txtDatabaseName.Text, txtKullanici.Text, txtSifre.Text);
        }

        private bool CheckDbConnection(string Server, string Database, string Kullanici, string Password)
        {
            try
            {
                using (var connection = new SqlConnection(string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", Server, Database, Kullanici, Password)))
                {
                    connection.Open();
                    connection.Close();
                    MessageBox.Show("Bağlantı Başarılı");
                    return true;
                }
            }
            catch (Exception ex)
            {
                //logger.Warn(LogTopicEnum.Agent, "Error in DB connection test on CheckDBConnection", ex);
                MessageBox.Show("Bağlantı Hatası " + ex.ToString());
                return false; // any error is considered as db connection error for now
            }
        }
    }
}
