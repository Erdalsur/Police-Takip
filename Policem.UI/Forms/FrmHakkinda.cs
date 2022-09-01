using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Policem.UI.Forms.Base;

namespace Policem.UI.Forms
{
    public partial class FrmHakkinda : XPopupForm
    {
        public FrmHakkinda()
        {
            InitializeComponent();
        }

        private void FrmHakkinda_Load(object sender, EventArgs e)
        {
            //Assembly assembly = Assembly.GetExecutingAssembly();
            //FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            var Ad = AppSession.Lisansim.Adi??string.Empty;//Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\ErSu\" + fvi.ProductName, "RegisterUser", null);
            var Firma = AppSession.Lisansim.Firma ?? string.Empty;//Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\ErSu\" + fvi.ProductName, "RegisterCompany", null);
            var Key = AppSession.Lisansim.SerialNumber ?? string.Empty;//Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\ErSu\" + fvi.ProductName, "ProductKey", null);
            lblKullanici.Text = "Kullanıcı  : " + Ad ?? String.Empty;
            lblFirma.Text = "Firma      : " + Firma ?? String.Empty;
            lblKey.Text = "Seri No    : " + Key ?? String.Empty;
            lblSurum.Text = "v." + AssemblyVersion;
        }
        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        private void lblEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:erdalsur@hotmail.com");
        }
    }
}
