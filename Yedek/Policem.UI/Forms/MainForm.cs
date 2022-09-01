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
using Policem.UI.DependencyResolution;

namespace Policem.UI.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ToolMusteriler_Click(object sender, EventArgs e)
        {
            //SplashScreenManager.ShowForm(typeof(WaitForm1));
            FormCollection fc = Application.OpenForms;
            bool FormFound = false;
            foreach (Form frm in fc)
            {
                if (frm.Name == "FrmMusteriler")
                {
                    frm.Focus();
                    FormFound = true;
                    //SplashScreenManager.CloseForm();
                }
            }
            if (FormFound == false)
            {
                FrmMusteriler m = new FrmMusteriler
                {
                    MdiParent = this
                };
                m.Show();
            }
        }

        private void ToolSigortacilar_Click(object sender, EventArgs e)
        {
            //SplashScreenManager.ShowForm(typeof(WaitForm1));
            FormCollection fc = Application.OpenForms;
            bool FormFound = false;
            foreach (Form frm in fc)
            {
                if (frm.Name == "FrmSigortaci")
                {
                    frm.Focus();
                    FormFound = true;
                    //SplashScreenManager.CloseForm();
                }
            }
            if (FormFound == false)
            {
                FrmSigortaci f = new FrmSigortaci
                {
                    MdiParent = this
                };
                f.Show();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Session session = new Session();
            var a = Session.FirmaService.GetAll();
            var a2 = Session.PoliceService.GetAll();
            var a3 = Session.SigortaciService.GetAll();
            SplashScreenManager.CloseForm();
        }
    }
}
