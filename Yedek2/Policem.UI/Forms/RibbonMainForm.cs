using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraSplashScreen;
using Policem.UI.DependencyResolution;
using Policem.UI.Forms.Base;
using DevExpress.XtraEditors;
using Policem.UI.Forms.Selection;

namespace Policem.UI.Forms
{
    public partial class RibbonMainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public AppSession appSession;
        public Dictionary<string, XForm> forms = new Dictionary<string, XForm>();
        public XForm ActiveXForm = (XForm)null;
        public RibbonMainForm()
        {
            InitializeComponent();
        }
        public void Viewchild(Form _form)
        {
            //Check Before Open
            if (!IsFormActive(_form))
            {
                _form.MdiParent = this;
                _form.Show();
            }
        }
        private bool IsFormActive(Form form)
        {
            bool IsOpened = false;
            //If There Is More Than One Form Opened
            if (MdiChildren.Count() > 0)
            {
                foreach (var item in MdiChildren)
                {
                    if (form.Name == item.Name)
                    {
                        // Active This Form
                        xtraTabbedMdiManager1.Pages[item].MdiChild.Activate();
                        IsOpened = true;
                        SplashScreenManager.CloseForm();
                    }
                }
            }
            return IsOpened;
        }
        private string GetHash(Type type, object[] prm)
        {
            string str = "";
            foreach (object obj in prm)
                str += (string)(object)obj.GetHashCode();
            return type.GetHashCode().ToString() + "." + str;
        }
        public XForm GetActiveForm(Type type, params object[] prm)
        {
            string hash = this.GetHash(type, prm);
            forms.TryGetValue(hash, out XForm xform);
            if (xform != null)
            {
                if (!xform.IsDisposed)
                {
                    xform.Activate();
                    return xform;
                }
                forms.Remove(hash);
            }
            return (XForm)null;
        }
        public XForm ShowMdiChildForm(Type type, params object[] prm)
        {
            XForm xform = this.GetActiveForm(type, prm);
            if (xform != null)
            {
                this.ActiveXForm = xform;
                return xform;
            }
            try
            {
                if (type.BaseType == typeof(XPopupForm))
                {
                    using (XPopupForm instance = (XPopupForm)Activator.CreateInstance(type, prm))
                    {
                        this.ActiveXForm = (XForm)instance;
                        xform = (XForm)instance;
                        int num = (int)instance.ShowDialog();
                    }
                }
                else
                {
                    xform = (XForm)Activator.CreateInstance(type, prm);
                    xform.MdiParent = (Form)this;
                    xform.WindowState = FormWindowState.Maximized;
                    this.forms.Add(this.GetHash(type, prm), xform);
                    this.ActiveXForm = xform;
                    xform.Show();
                }
            }
            catch (Exception ex)
            {
                int num = (int)XtraMessageBox.Show(ex.InnerException.ToString());
            }
            return xform;
        }

        public void NotifyMain(string message)
        {
            BsiInfo.Caption = DateTime.Now.ToLongTimeString() + " | " + message;
        }

        private void BtnSigortacilar_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMdiChildForm(typeof(FrmSigortaci));
            //Viewchild(new FrmSigortaci());
        }

        private void RibbonMainForm_Load(object sender, EventArgs e)
        {
            
            
            if (AppSession.Settings.SkinName != string.Empty)
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(AppSession.Settings.SkinName);
            else
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2013");
            Text = "Poliçe Takip Sistemi";
            var a2 = Session.PoliceService.GetAll();
            this.WindowState = FormWindowState.Maximized;
            SplashScreenManager.CloseForm();
        }

        private void BtnMusteriler_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMdiChildForm(typeof(FrmMusteriler));
            //Viewchild(new FrmMusteriler());
        }

        private void RibbonMainForm_Shown(object sender, EventArgs e)
        {
            RibbonMainForm mainForm = this;
            mainForm.Text = mainForm.Text + " - v" + Application.ProductVersion;
            AppSession.MainForm.NotifyMain("Sistem Başladı...");
        }

        private void BtnGenelAyarlar_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMdiChildForm(typeof(FrmAyarlar));
        }

        private void BtnAktifPoliceler_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMdiChildForm(typeof(FrmPoliceler));
            //FrmMusteriSec f = new FrmMusteriSec();
            //f.ShowDialog();
        }

        private void btnGelmeyenPoliceler_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMdiChildForm(typeof(FrmGelmeyenPoliceler));
        }

        private void btnPasifPoliceler_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMdiChildForm(typeof(FrmPasifPoliceler));
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMdiChildForm(typeof(FrmPoliceTara));
        }
    }
}