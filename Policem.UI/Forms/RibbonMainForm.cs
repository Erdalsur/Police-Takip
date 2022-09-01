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
using Policem.UI.Properties;
using Policem.Core.Extensions;
using Policem.Core;
using System.Windows.Threading;
using Policem.Core.Utility;
using Policem.UI.Rapor;
using DevExpress.XtraReports.UI;
using Policem.Data;
using Policem.Data.Enums;

namespace Policem.UI.Forms
{
    public partial class RibbonMainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly DispatcherTimer _timer;
        public AppSession appSession;
        public string Saat;
        public Dictionary<string, XForm> forms = new Dictionary<string, XForm>();
        public XForm ActiveXForm = (XForm)null;
        public RibbonMainForm()
        {
            InitializeComponent();
            _timer = new DispatcherTimer();
            _timer.Tick += TimerTick;
            Saat = "...";
        }
        private void TimerTick(object sender, EventArgs e)
        {
            string format = "{0} {1}";
            DateTime now = SystemTime.Now;
            string longDateString = now.ToLongDateString();
            now = SystemTime.Now;
            string shortTimeString = now.ToShortTimeString();
            string str = string.Format(format, longDateString, shortTimeString);
            Saat = Saat.Contains(":") ? str.Replace(":", ".") : str;
            barTextSaat.Caption= Saat;
            //süreli işlemleri tetiklemekte de kullanılabilir.
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
            MessageSession.Mesaj=DateTime.Now.ToLongTimeString() + " | " + message;
            //MessageSession.SetOtomatikSil(true, 5000);
            BsiInfo.Caption = MessageSession.Mesaj;
        }

        private void BtnSigortacilar_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMdiChildForm(typeof(FrmSigortaci));
            //Viewchild(new FrmSigortaci());
        }

        private void RibbonMainForm_Load(object sender, EventArgs e)
        {
            if (AppSession.Lisansim.LisansDurum)
                btnLisans.Visibility = BarItemVisibility.Never;
            else
                btnLisans.Visibility = BarItemVisibility.Always;
            _timer.Interval = TimeSpan.FromSeconds(1.0);
            _timer.Start();
            if (AppSession.Settings.SkinName != string.Empty)
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(AppSession.Settings.SkinName);
            else
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2013");
            Text = "Poliçe Takip Sistemi";
            var a2 = Session.PoliceService.GetAll();
            this.WindowState = FormWindowState.Maximized;
            SplashScreenManager.CloseForm();
            //Control.DefaultFont.FontWeight = FontWeights.Bold;
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
            //ShowMdiChildForm(typeof(FrmPolicelerYeni));
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMdiChildForm(typeof(FrmPoliceTara));
        }

        private void btnDatabaseAyar_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMdiChildForm(typeof(FrmDatabaseSettings));
        }

        private void RibbonMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timer.Stop();
        }

        private void btnHakkinda_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMdiChildForm(typeof(FrmHakkinda));
            
        }

        private void btnLisans_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMdiChildForm(typeof(FrmLisans));
        }

        private void RaporGelmeyenPolicelerim_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportGelmeyen report =new ReportGelmeyen();
            report.DataSource = CreateGelmeyenPoliceler();
            ReportPrintTool tool = new ReportPrintTool(report);
            tool.ShowPreview();
        }

        private List<GelmeyenPolice> CreateGelmeyenPoliceler()
        {
            var policelerim = Session.PoliceService.GetAll();
            var RaporPoliceleri = policelerim;
            RaporPoliceleri = policelerim.Where(t => t.PoliceGeldimi == EvetHayir.Hayır).ToList();
            var a = from Policem in RaporPoliceleri.ToList()
                    //orderby Policem.PoliceBitisTarih descending
                    orderby Policem.FirmaId descending
                    join Sigortaci in Session.SigortaciService.GetAll() on Policem.SigortaciId equals Sigortaci.SigortaciId
                    join Musteri in Session.FirmaService.GetAll() on Policem.FirmaId equals Musteri.FirmaId
                    select new GelmeyenPolice()
                    {
                        PoliceId = Policem.PoliceId,
                        Unvan = Sigortaci.Unvan,
                        Name = Musteri.Name,
                        PoliceTuru = Policem.PoliceTuru,
                        PoliceNo = Policem.PoliceNo,
                        PoliceBaslangicTarih = Policem.PoliceBaslangicTarih,
                        PoliceBitisTarih = Policem.PoliceBitisTarih,
                        Aciklama = Policem.Aciklama,
                        Policelenen = Policem.Policelenen,
                        Tutar = Policem.Tutar,
                        ArtisYuzdesi = Policem.ArtisYuzdesi
                    };
            //select new
            //{
            //    Musteri.Name,
            //    Policem.PoliceId,
            //    Policem.PoliceTuru,
            //    Policem.PoliceNo,
            //    Policem.Policelenen,
            //    Policem.Tutar,
            //    Policem.ArtisYuzdesi,
            //    Policem.PoliceBaslangicTarih,
            //    Policem.PoliceBitisTarih,
            //    Policem.PoliceGeldimi,
            //    Sigortaci.Unvan,
            //    Policem.FirmaId,
            //    Policem.SigortaciId,
            //    Policem.Aciklama
            //};
            var son30gün = DateTime.Now.AddDays(-30);
            return a.Where(ay => ay.PoliceBitisTarih > son30gün).OrderBy(t => t.PoliceBaslangicTarih).OrderBy(t=>t.Name).ToList();
        }

        private void RaporAktifPolicelerim_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportAktiffPolicelerim report = new ReportAktiffPolicelerim();
            report.DataSource = CreatePolicelerim();
            ReportPrintTool tool = new ReportPrintTool(report);
            tool.ShowPreview();
        }

        private List<AktifPolicerim> CreatePolicelerim()
        {
            var policelerim = Session.PoliceService.GetAll();
            var RaporPoliceleri = policelerim;
            RaporPoliceleri = policelerim.Where(t => t.PoliceBitisTarih > DateTime.Now).Where(ay => ay.Yenilendimi == 0).ToList();
            var a = from Policem in RaporPoliceleri.ToList()
                    orderby Policem.PoliceBitisTarih descending
                    join Sigortaci in Session.SigortaciService.GetAll() on Policem.SigortaciId equals Sigortaci.SigortaciId
                    join Musteri in Session.FirmaService.GetAll() on Policem.FirmaId equals Musteri.FirmaId
                    select new AktifPolicerim()
                    {
                        PoliceId = Policem.PoliceId,
                        Unvan = Sigortaci.Unvan,
                        Name = Musteri.Name,
                        PoliceTuru = Policem.PoliceTuru,
                        PoliceNo = Policem.PoliceNo,
                        Policelenen = Policem.Policelenen,
                        Tutar = Policem.Tutar,
                        ArtisYuzdesi = Policem.ArtisYuzdesi,
                        PoliceBaslangicTarih = Policem.PoliceBaslangicTarih,
                        PoliceBitisTarih = Policem.PoliceBitisTarih,
                        Basildimi = Policem.PoliceGeldimi,
                        Aciklama = Policem.Aciklama
                    };
            return a.OrderBy(t => t.Name).ToList();
        }

        private List<PasifPolicerim> CreatePasifPolicelerim(DateTime BaslangicTarihi)
        {
            var policelerim = Session.PoliceService.GetAll();
            var RaporPoliceleri = policelerim;
            RaporPoliceleri = policelerim.Where(tar=> tar.PoliceBitisTarih> BaslangicTarihi).Where(t => t.PoliceBitisTarih < DateTime.Now).Where(ay => ay.Yenilendimi == 0).ToList();
            var a = from Policem in RaporPoliceleri.ToList()
                    orderby Policem.PoliceBitisTarih descending
                    join Sigortaci in Session.SigortaciService.GetAll() on Policem.SigortaciId equals Sigortaci.SigortaciId
                    join Musteri in Session.FirmaService.GetAll() on Policem.FirmaId equals Musteri.FirmaId
                    select new PasifPolicerim()
                    {
                        PoliceId = Policem.PoliceId,
                        Unvan = Sigortaci.Unvan,
                        Name = Musteri.Name,
                        PoliceTuru = Policem.PoliceTuru,
                        PoliceNo = Policem.PoliceNo,
                        Policelenen = Policem.Policelenen,
                        Tutar = Policem.Tutar,
                        ArtisYuzdesi = Policem.ArtisYuzdesi,
                        PoliceBaslangicTarih = Policem.PoliceBaslangicTarih,
                        PoliceBitisTarih = Policem.PoliceBitisTarih,
                        Basildimi = Policem.PoliceGeldimi,
                        Aciklama = Policem.Aciklama
                    };
            return a.OrderBy(t => t.Name).ToList();
        }

        private void RaporSüresindeYenilenmemis_ItemClick(object sender, ItemClickEventArgs e)
        {
            DateTime baslamatarihi =Convert.ToDateTime("01/01/"+DateTime.Now.Year.ToString());
            ReportPasifPoliceler report = new ReportPasifPoliceler();
            report.LblBaslik.Text = baslamatarihi.ToShortDateString() + " " + report.LblBaslik.Text;
            report.DataSource = CreatePasifPolicelerim(baslamatarihi);
            ReportPrintTool tool = new ReportPrintTool(report);
            tool.ShowPreview();
        }
    }
}