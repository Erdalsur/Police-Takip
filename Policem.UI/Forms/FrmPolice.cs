using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Policem.Core.Utility;
using Policem.Data;
using Policem.Data.Enums;
using Policem.UI.DependencyResolution;
using Policem.UI.Forms.Base;
using Policem.UI.Forms.Selection;

namespace Policem.UI.Forms
{
    public partial class FrmPolice : XPopupForm
    {
        bool YeniKayit = true;
        private bool Yenileme = false;
        public Police policem = new Police();
        Firma _policeMusteri = new Firma();
        Sigortaci _sigortaFirma = new Sigortaci(); 
        public FrmPolice()
        {
            InitializeComponent();
            ControlColoriezrSystem();
            YeniKayit = true;
            Yenileme = false;
        }
        public FrmPolice(Police police, bool yeniKayit = true, bool yenileme = false)
        {
            InitializeComponent();
            ControlColoriezrSystem();
            policem = police;
            _policeMusteri = police.Firma;
            _sigortaFirma = police.Sigortaci;
            YeniKayit = yeniKayit;
            Yenileme = yenileme;

        }

        public FrmPolice(Firma policeMusteri, bool yeniKayit = true, bool yenileme = false)
        {
            InitializeComponent();
            ControlColoriezrSystem();
            _policeMusteri = policeMusteri;
            policem.Firma = policeMusteri;
            txtPoliceSahibi.Text = _policeMusteri.Unvan.ToString();
            YeniKayit = yeniKayit;
            Yenileme = yenileme;
        }

        public FrmPolice(Sigortaci sigortaFirma,bool yeniKayit=true,bool yenileme=false)
        {
            InitializeComponent();
            ControlColoriezrSystem();
            _sigortaFirma = sigortaFirma;
            policem.Sigortaci = sigortaFirma;
            txtSigortaFirma.Text = sigortaFirma.Unvan.ToString();
            YeniKayit = yeniKayit;
            Yenileme = yenileme;
        }

        private void ControlColoriezrSystem()
        {
            ControlColorizer controlColorizer1 = new ControlColorizer
                            (Color.FromName(AppSession.PrgSettingsOrg.AktifAlanRengi), SystemColors.Window,
                            new Control[14]
                  {
        (Control) this.txtPoliceSahibi,
        (Control) this.txtCmbPoliceTuru,
        (Control) this.txtSigortaFirma,
        (Control) this.txtPoliceNo,
        (Control) this.txtDateBaslangicTarih,
        (Control) this.txtDateBitisTarih,
        (Control) this.txtPolicelenen,
        (Control) this.txtAciklama,
        (Control) this.txtCmbOdemeTuru,
        (Control) this.txtTutar,
        (Control) this.txtOncekiTutar,
        (Control) this.txtChkTaksit,
        (Control) this.txtTaksitSayisi,
        (Control) this.txtchkGeldimi
                  });
            ControlColorizer controlColorizer2 = new ControlColorizer
                           (Color.FromName(AppSession.PrgSettingsOrg.AktifAlanRengi), this.BackColor,
                           new Control[2]
                 {
        (Control) this.txtChkTaksit,
        (Control) this.txtchkGeldimi
                 });
        }

        private void FrmPolice_Load(object sender, EventArgs e)
        {
            EnumToLists();
            txtTutar.Properties.DisplayFormat.FormatType= DevExpress.Utils.FormatType.Custom;
            txtTutar.Properties.DisplayFormat.Format = new FormatPara("TL");            
            txtOncekiTutar.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtOncekiTutar.Properties.DisplayFormat.Format = new FormatPara("TL");
            txtChkTaksit.Checked = true;
            if (YeniKayit)
            {
                // Yeni Kayıt 2 Şekilde Gelir 
                // 1. Sıfır Kayıt
                // 2. Var olan Policeyi Yenileme
                if (Yenileme)
                {
                    // Yenileme Yapılacak
                    policem.PoliceBaslangicTarih = policem.PoliceBitisTarih;
                    policem.PoliceBitisTarih = policem.PoliceBitisTarih.AddYears(1);
                }
                else
                {
                    // Sıfır Kayıt Tarih düzenlemesi yapılacak
                    policem.PoliceBaslangicTarih = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 00, 00);
                    policem.PoliceBitisTarih = new DateTime(DateTime.Now.Year + 1, DateTime.Now.Month, DateTime.Now.Day, 12, 00, 00);
                }
                policem.TaksitSayisi = 1;
                BtnPoliceTara.Visible = false;
                BtnTaramaAc.Visible = false;
            }
            BilgileriEkranaAktar();
        }

        private void BilgileriEkranaAktar()
        {
            if (policem.Firma == null)
                txtPoliceSahibi.Text = string.Empty;
            else
                txtPoliceSahibi.Text = policem.Firma.Unvan;
            txtCmbPoliceTuru.EditValue= (PoliceTuru)policem.PoliceTuru;
            if (policem.Sigortaci == null)
                txtSigortaFirma.Text = string.Empty;
            else
                txtSigortaFirma.Text = policem.Sigortaci.Unvan;
            txtPoliceNo.Text = policem.PoliceNo;
            txtDateBaslangicTarih.DateTime =policem.PoliceBaslangicTarih;
            txtDateBitisTarih.DateTime = policem.PoliceBitisTarih;
            txtPolicelenen.Text = policem.Policelenen;
            txtAciklama.Text = policem.Aciklama;
            txtCmbOdemeTuru.EditValue = (OdemeTipi)policem.OdemeTuru;
            txtTutar.EditValue = policem.Tutar;
            txtOncekiTutar.EditValue = policem.OncekiTutar;
            txtChkTaksit.Checked = (policem.Taksit == Taksit.Evet) ? true : false;
            txtTaksitSayisi.EditValue = policem.TaksitSayisi;
            txtchkGeldimi.Checked = (policem.PoliceGeldimi == EvetHayir.Evet) ? true : false;
            if (policem.Yenilendimi==1)
            {
                // Police yenilenmiş DİKKAT
                lblYenilenmis.Visible = true;
                timer1.Enabled = true;
                btnKaydet.Enabled = false;
                BtnPoliceTara.Enabled = false;
            }
            else
            {
                lblYenilenmis.Visible = false;
                timer1.Enabled = false;
                btnKaydet.Enabled = true;
            }
        }

        private void EnumToLists()
        {
            Controls.Add(txtCmbPoliceTuru);
            txtCmbPoliceTuru.Properties.DataSource = typeof(PoliceTuru).ToList();
            txtCmbPoliceTuru.Properties.DisplayMember = "Value";
            txtCmbPoliceTuru.Properties.ValueMember = "Key";
            txtCmbPoliceTuru.Properties.ShowHeader = false;
            txtCmbPoliceTuru.Properties.PopulateColumns();
            txtCmbPoliceTuru.Properties.Columns["Key"].Visible = false;
            txtCmbPoliceTuru.EditValue = PoliceTuru.Seciniz;
            Controls.Add(txtCmbOdemeTuru);
            txtCmbOdemeTuru.Properties.DataSource = typeof(OdemeTipi).ToList();
            txtCmbOdemeTuru.Properties.DisplayMember = "Value";
            txtCmbOdemeTuru.Properties.ValueMember = "Key";
            txtCmbOdemeTuru.Properties.ShowHeader = false;
            txtCmbOdemeTuru.Properties.PopulateColumns();
            txtCmbOdemeTuru.Properties.Columns["Key"].Visible = false;
            txtCmbOdemeTuru.EditValue = OdemeTipi.Seciniz;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblYenilenmis.Visible = !lblYenilenmis.Visible;
        }

        private void TxtPoliceSahibi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmMusteriSec f = new FrmMusteriSec();
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                _policeMusteri = f.policeMusteri;
                policem.Firma = f.policeMusteri;
                policem.FirmaId = f.policeMusteri.FirmaId;
                txtPoliceSahibi.Text = policem.Firma.Unvan;
            }
        }

        private void TxtSigortaFirma_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmSigortaciSec f = new FrmSigortaciSec();
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                _sigortaFirma = policem.Sigortaci = f.sigortaFirma;
                policem.SigortaciId = f.sigortaFirma.SigortaciId;
                txtSigortaFirma.Text = f.sigortaFirma.Unvan;
            }
        }

        private void TxtDateBaslangicTarih_EditValueChanged(object sender, EventArgs e)
        {
            txtDateBitisTarih.EditValue = new DateTime(txtDateBaslangicTarih.DateTime.Year+1,txtDateBaslangicTarih.DateTime.Month,txtDateBaslangicTarih.DateTime.Day, 12, 00, 00); 
        }

        private void TxtChkTaksit_CheckedChanged(object sender, EventArgs e)
        {
            switch (txtChkTaksit.Checked)
            {
                case true:
                    txtTaksitSayisi.Enabled = true;
                    break;
                default:
                    txtTaksitSayisi.Enabled = false;
                    break;
                    //txtTaksitSayisi.Text = "1";
            }
        }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            BilgileriNesneyeAktar();
            if (YeniKayit)
            {                
                policem = Session.PoliceService.Add(policem);
                AppSession.MainForm.NotifyMain(policem.PoliceNo + " numaralı Poliçe Yeni Kayıt Edildi.");
            }
            else
            {
                policem = Session.PoliceService.Update(policem);
                AppSession.MainForm.NotifyMain(policem.PoliceNo + " numaralı Poliçe Bilgileri Güncellendi.");
            }
            this.DialogResult = DialogResult.OK;
            
        }

        private void BilgileriNesneyeAktar()
        {
            policem.Firma = _policeMusteri;
            policem.FirmaId = _policeMusteri.FirmaId;
            policem.PoliceTuru = (PoliceTuru)txtCmbPoliceTuru.EditValue;
            policem.Sigortaci = _sigortaFirma;
            policem.SigortaciId = _sigortaFirma.SigortaciId;
            //if (YeniKayit)
            {
                //Firma ve Sigortaciyı yeni kayıt olarak eklememesi için
                policem.Firma = null;
                policem.Sigortaci = null;
            }
            policem.PoliceNo = txtPoliceNo.EditValue==null?string.Empty:((string)txtPoliceNo.EditValue).Trim();
            policem.PoliceBaslangicTarih= new DateTime(txtDateBaslangicTarih.DateTime.Year, txtDateBaslangicTarih.DateTime.Month, 
                txtDateBaslangicTarih.DateTime.Day, 12, 00, 00);
            policem.PoliceBitisTarih = new DateTime(txtDateBitisTarih.DateTime.Year, txtDateBitisTarih.DateTime.Month,
                txtDateBitisTarih.DateTime.Day, 12, 00, 00);
            policem.Policelenen = txtPolicelenen.EditValue == null ? string.Empty : ((string)txtPolicelenen.EditValue).Trim();
            policem.Aciklama = txtAciklama.EditValue == null ? string.Empty : (string)txtAciklama.EditValue;
            policem.OdemeTuru = (OdemeTipi)txtCmbOdemeTuru.EditValue;
#pragma warning disable CS0252 // Possible unintended reference comparison; left hand side needs cast
            policem.Tutar = txtTutar.EditValue == "" ? 0 : Convert.ToDecimal(txtTutar.EditValue);
            policem.OncekiTutar = txtOncekiTutar.EditValue == "" ? 0 : Convert.ToDecimal(txtOncekiTutar.EditValue);
#pragma warning restore CS0252 // Possible unintended reference comparison; left hand side needs cast
            if ((bool)txtChkTaksit.EditValue)
                policem.Taksit = Taksit.Evet;
            else
                policem.Taksit = Taksit.Hayır;
            policem.TaksitSayisi = Convert.ToInt32(txtTaksitSayisi.EditValue);
            if ((bool)txtchkGeldimi.EditValue)
                policem.PoliceGeldimi = EvetHayir.Evet;
            else
                policem.PoliceGeldimi = EvetHayir.Hayır;

            if (policem.OncekiTutar == 0)
                policem.ArtisYuzdesi = 100;
            else
                policem.ArtisYuzdesi = policem.Tutar * 100 / policem.OncekiTutar - 100;
        }

        private void BtnPoliceTara_Click(object sender, EventArgs e)
        {
            if (policem.Yenilendimi == 0)

                if (YeniKayit == false)
                {
                    DialogResult result = XtraMessageBox.Show("Poliçe Tarayacak mısnız?", "Onay", MessageBoxButtons.YesNo);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        FrmPoliceTara form = new FrmPoliceTara(policem.PoliceId);
                        form.ShowDialog();
                        if (form.DialogResult == DialogResult.OK)
                        {
                            policem.PoliceGeldimi = EvetHayir.Evet;
                            txtchkGeldimi.Checked = true;
                            var police = Session.PoliceService.GetById(policem.PoliceId);
                            police.PoliceGeldimi = EvetHayir.Evet;
                            police = Session.PoliceService.Update(police);
                            policem = police;
                            policem.Firma = Session.FirmaService.GetById(police.FirmaId);
                            policem.Sigortaci = Session.SigortaciService.GetById(police.SigortaciId);
                            BilgileriEkranaAktar();
                        }
                        else
                        {
                            policem.PoliceGeldimi = EvetHayir.Hayır;
                            txtchkGeldimi.Checked = false;
                            var police = Session.PoliceService.GetById(policem.PoliceId);
                            police.PoliceGeldimi = EvetHayir.Evet;
                            police = Session.PoliceService.Update(police);
                            policem = police;
                            policem.Firma = Session.FirmaService.GetById(police.FirmaId);
                            policem.Sigortaci = Session.SigortaciService.GetById(police.SigortaciId);
                            BilgileriEkranaAktar();
                        }
                    }
                    else
                    {
                        //Dosya Seçme Yapılacak
                        OpenFileDialog dialog = new OpenFileDialog();
                        dialog.Filter = "PDF Dosyaları | *.pdf"; // file types, that will be allowed to upload
                        dialog.Multiselect = false; // allow/deny user to upload more than one file at a time
                        if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
                        {
                            String path = dialog.FileName; // get name of file
                                                           //MessageBox.Show(path);
                                                           //using (StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open), new UTF8Encoding())) // do anything you want, e.g. read it
                                                           //{
                                                           //    // ...
                            bool Yeni = true;
                            PoliceDosyaDetay policeDosyaDetay = new PoliceDosyaDetay();
                            policeDosyaDetay.PoliceId = policem.PoliceId;
                            policeDosyaDetay.DosyaType = "PDF";
                            policeDosyaDetay.Aciklama = Session.PoliceService.GetById(policeDosyaDetay.PoliceId).Policelenen;
                            policeDosyaDetay.Dosyalandimi = EvetHayir.Hayır;
                            var durum = Session.PoliceDosyaService.GetPoliceById(policeDosyaDetay.PoliceId);
                            if (durum.Count > 0)
                            {
                                Yeni = false;
                                policeDosyaDetay.Id = durum.FirstOrDefault().Id;
                            }
                            else
                                Yeni = true;
                            policeDosyaDetay.Dosya = File.ReadAllBytes(path);
                            if (Yeni)
                            {
                                policeDosyaDetay = Session.PoliceDosyaService.Add(policeDosyaDetay);
                                txtchkGeldimi.Checked = true;
                                var police = Session.PoliceService.GetById(policeDosyaDetay.PoliceId);
                                police.PoliceGeldimi = EvetHayir.Evet;
                                police = Session.PoliceService.Update(police);
                                policem = police;
                                policem.Firma = Session.FirmaService.GetById(police.FirmaId);
                                policem.Sigortaci = Session.SigortaciService.GetById(police.SigortaciId);
                                BilgileriEkranaAktar();
                            }
                            else
                            {
                                policeDosyaDetay = Session.PoliceDosyaService.Update(policeDosyaDetay);
                                txtchkGeldimi.Checked = false;
                                var police = Session.PoliceService.GetById(policeDosyaDetay.PoliceId);
                                police.PoliceGeldimi = EvetHayir.Evet;
                                police = Session.PoliceService.Update(police);
                                policem = police;
                                policem.Firma = Session.FirmaService.GetById(police.FirmaId);
                                policem.Sigortaci = Session.SigortaciService.GetById(police.SigortaciId);
                                BilgileriEkranaAktar();
                            }

                            //}
                        }
                    }
                }
                else
                    XtraMessageBox.Show("Poliçe Yenilenmiş Tarama Yapamazsınız","Uyarı");
        }

        private void BtnTaranmisPoliceAc_Click(object sender, EventArgs e)
        {
            var policedosyalar = Session.PoliceDosyaService.GetPoliceById(policem.PoliceId);
            if (policedosyalar.Count > 0)
            {
                FrmPoliceOnizleme form = new FrmPoliceOnizleme(policedosyalar.FirstOrDefault().Id);
                form.Show();
            }
            else
                XtraMessageBox.Show("Kayıtlı Poliçe Yok","Uyarı");

        }
    }
}
//LoadCombo<PoliceTuru>(txtCmbPoliceTuru);
            //LoadCombo<OdemeTipi>(txtCmbOdemeTuru);
            
            //if ((YeniKayit==true) && (Yenileme==false))
            //{
            //    txtDateBaslangicTarih.Value = DateTime.Now;
            //    txtDateBitisTarih.Value = DateTime.Now.AddYears(1);
            //}
            //if (YeniKayit != true)
            //{
            //    BilgileriEkranaAktar();
            //    PoliceKontrol();
            //}
//private void BtnKaydet_Click(object sender, EventArgs e)
//{
//    BilgileriNesneyeAktar();
//    try
//    {
//        policem = YeniKayit ? Session2.PoliceService.Add(policem) : Session2.PoliceService.Update(policem);
//        this.DialogResult = DialogResult.OK;
//    }
//    catch
//    {
//        this.DialogResult = DialogResult.Cancel;
//        MessageBox.Show("Hata Oluştu");
//    }
//}

//private void PoliceKontrol()
//{
//    if (policem.Yenilendimi == 1)
//    {
//        //YENİLENMİŞ POLİÇE UYARISINI AÇ
//        timer1.Enabled = true;
//        //Kaydet butonunu kilitle
//        btnKaydet.Enabled = false;
//    }
//}

//private void LoadCombo<T>(System.Windows.Forms.ComboBox cmb) where T : struct, IConvertible, IComparable, IFormattable
//{
//    cmb.DataSource = Enum.GetValues(typeof(T)).Cast<Enum>().
//        Select(value => new
//        {
//            (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()),
//            typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
//            value
//        })
//        .OrderBy(item => item.value)
//        .ToList();
//    cmb.DisplayMember = "Description";
//    cmb.ValueMember = "value";
//}

//private void BilgileriEkranaAktar()
//{
//    policem.Firma = Session2.FirmaService.GetById(policem.FirmaId);
//    if (policem.Firma == null)
//        txtPoliceSahibi.Text = string.Empty;
//    else
//        txtPoliceSahibi.Text = policem.Firma.Unvan;
//    policem.Sigortaci = Session2.SigortaciService.GetById(policem.SigortaciId);
//    if (policem.Sigortaci == null)
//        txtSigortaFirma.Text = string.Empty;
//    else
//        txtSigortaFirma.Text = policem.Sigortaci.Unvan;
//    txtCmbPoliceTuru.EditValue = (PoliceTuru)policem.PoliceTuru;
//    txtPoliceNo.Text = policem.PoliceNo;
//    txtDateBaslangicTarih.EditValue = policem.PoliceBaslangicTarih;
//    txtDateBitisTarih.EditValue = policem.PoliceBitisTarih;
//    txtPolicelenen.Text = policem.Policelenen;
//    txtAciklama.Text = policem.Aciklama;
//    txtTutar.Text = policem.Tutar.ToString();
//    txtOncekiTutar.Text = policem.OncekiTutar.ToString();
//    txtChkTaksit.Checked = (policem.Taksit == Taksit.Evet) ? true : false;
//    txtCmbOdemeTuru.EditValue = policem.OdemeTuru;
//    txtCmbPoliceTuru.EditValue = policem.PoliceTuru;
//    txtTaksitSayisi.Text = policem.TaksitSayisi.ToString();
//    txtchkGeldimi.Checked = (policem.PoliceGeldimi == EvetHayir.Evet) ? true : false;
//    if (policem.Yenilendimi == Convert.ToInt32("1"))
//    {
//        lblYenilenmis.Visible = true;
//        //Dikkat Herşeyi Kilitleyeceğiz
//        btnKaydet.Enabled = false;
//        txtSigortaFirma.Enabled = false;
//        txtChkTaksit.Enabled = false;
//    }
//    else
//    {
//        lblYenilenmis.Visible = false;
//        btnKaydet.Enabled = true;

//        txtSigortaFirma.Enabled = true;
//        txtChkTaksit.Enabled = true;
//    }
//}

//private void BilgileriNesneyeAktar()
//{

//    policem.Firma = _policeMusteri;
//    policem.FirmaId = policem.Firma.FirmaId;
//    policem.Sigortaci = _sigortaFirma;

//    policem.SigortaciId = policem.Sigortaci.SigortaciId;
//    if (YeniKayit)
//    {
//        policem.Firma = null;
//        policem.Sigortaci = null;
//    }
//    policem.PoliceTuru = (PoliceTuru)txtCmbPoliceTuru.EditValue;
//    policem.OdemeTuru = (OdemeTipi)(txtCmbOdemeTuru.EditValue);
//    policem.PoliceNo = txtPoliceNo.Text;

//    policem.PoliceBaslangicTarih = (DateTime)txtDateBaslangicTarih.EditValue;
//    policem.PoliceBitisTarih = (DateTime)txtDateBitisTarih.EditValue;
//    policem.Policelenen = txtPolicelenen.Text;
//    policem.Aciklama = txtAciklama.Text;
//    policem.Tutar = Convert.ToDecimal(txtTutar.Text);

//    if (txtOncekiTutar.Text == string.Empty)
//        policem.OncekiTutar = 0;
//    else
//        policem.OncekiTutar = Convert.ToDecimal(txtOncekiTutar.Text);


//    if (txtChkTaksit.Checked == true)
//        policem.Taksit = Taksit.Evet;
//    else
//        policem.Taksit = Taksit.Hayır;
//    if (txtchkGeldimi.Checked == true)
//        policem.PoliceGeldimi = EvetHayir.Evet;
//    else
//        policem.PoliceGeldimi = EvetHayir.Hayır;

//    if (policem.OncekiTutar == 0)
//        policem.ArtisYuzdesi = 100;
//    else
//        policem.ArtisYuzdesi = policem.Tutar * 100 / policem.OncekiTutar - 100;
//    policem.TaksitSayisi = Convert.ToInt32(txtTaksitSayisi.Text);

//}

//private PoliceTuru EnumPoliceTuruAktar(object selectedValue)
//{
//    switch (selectedValue.ToString())
//    {
//        case "Seciniz":
//            return PoliceTuru.Seciniz;
//        case "Kasko":
//            return PoliceTuru.Kasko;
//        case "Trafik":
//            return PoliceTuru.Trafik;
//        case "Saglık":
//            return PoliceTuru.Saglık;
//        case "Konut":
//            return PoliceTuru.Konut;
//        case "Dask":
//            return PoliceTuru.Dask;
//        default:
//            return PoliceTuru.Seciniz;
//    }
//}

//private OdemeTipi EnumOdemeTuruAktar(object selectedValue)
//{
//    switch (selectedValue.ToString())
//    {
//        case "Seciniz":
//            return OdemeTipi.Seciniz;
//        case "Nakit":
//            return OdemeTipi.Nakit;
//        case "KrediKartı":
//            return OdemeTipi.KrediKartı;
//        case "Banka":
//            return OdemeTipi.Banka;
//        default:
//            return OdemeTipi.Seciniz;
//    }
//}




