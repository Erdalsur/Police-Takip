using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using Policem.UI.Forms.Base;

namespace Policem.UI.Forms
{
    public partial class FrmSQLList : XPopupForm
    {
        private string _chosenServer = string.Empty;

        public FrmSQLList()
        {
            InitializeComponent();
        }
        public static string DoPickServer(string[] servers)
        {
            string str1 = string.Empty;
            FrmSQLList pickServer = new FrmSQLList();
            pickServer.lbServers.DataSource = (object)servers;
            int num = (int)pickServer.ShowDialog();
            string str2 = pickServer._chosenServer;
            pickServer.Dispose();
            return str2;
        }

        private void FrmSQLList_Load(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            try
            {
                this.ResumeLayout(false);
            }
            finally
            {
                //Close Wait Form
                SplashScreenManager.CloseForm(false);
            }
        }
        private void SQLSec_Click(object sender, EventArgs e)
        {
            if (this.lbServers.SelectedItem == null)
                return;
            this._chosenServer = this.lbServers.SelectedItem.ToString();
            this.Close();
        }

        private void lbServers_DoubleClick(object sender, EventArgs e)
        {
            this.SQLSec_Click(sender, e);
        }


        public void SetPickButton()
        {
            if (this.lbServers.SelectedItem != null)
            {
                this.SQLSec.Enabled = true;
                this.AcceptButton = (IButtonControl)this.SQLSec;
            }
            else
                this.SQLSec.Enabled = false;
        }

        private void lbServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPickButton();
        }

        private void FrmSQLList_Activated(object sender, EventArgs e)
        {
            SetPickButton();
        }
    }
}
