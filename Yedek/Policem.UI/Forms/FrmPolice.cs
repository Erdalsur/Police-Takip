using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Policem.Data;
using Policem.Data.Enums;
using Policem.UI.DependencyResolution;
using Policem.UI.Forms.Selection;

namespace Policem.UI.Forms
{
    public partial class FrmPolice : Form
    {
        bool YeniKayit = true;
        bool Yenileme = false;
        public Police policem = new Police();
        Firma _policeMusteri = new Firma();
        Sigortaci _sigortaFirma = new Sigortaci(); 
        public FrmPolice()
        {
            InitializeComponent();
            
        }
        public FrmPolice(Police police)
        {
            InitializeComponent();
            policem = police;
            _policeMusteri = police.Firma;
            _sigortaFirma = police.Sigortaci;
            YeniKayit = false;
            
        }
        public FrmPolice(Police police, bool yeniKayit)
        {
            InitializeComponent();
            policem = police;
            _policeMusteri = police.Firma;
            _sigortaFirma = police.Sigortaci;
            Yenileme = true;
            YeniKayit = yeniKayit;

        }

        public FrmPolice(Firma policeMusteri)
        {
            InitializeComponent();
            _policeMusteri = policem.Firma = policeMusteri;
            txtPoliceSahibi.Text = policem.Firma.Unvan.ToString();
        }

        public FrmPolice(Sigortaci sigortaFirma)
        {
            InitializeComponent();
            _sigortaFirma = policem.Sigortaci = sigortaFirma;
            txtSigortaFirma.Text = policem.Sigortaci.Unvan.ToString();
        }

        private void FrmPolice_Load(object sender, EventArgs e)
        {
            LoadCombo<PoliceTuru>(txtCmbPoliceTuru);
            LoadCombo<OdemeTipi>(txtCmbOdemeTuru);
            if ((YeniKayit==true) && (Yenileme==false))
            {
                txtDateBaslangicTarih.Value = DateTime.Now;
                txtDateBitisTarih.Value = DateTime.Now.AddYears(1);
            }
            BilgileriEkranaAktar();
            PoliceKontrol();
        }

        private void PoliceKontrol()
        {
            if (policem.Yenilendimi==1)
            {
                //YENİLENMİŞ POLİÇE UYARISINI AÇ
                timer1.Enabled = true;
                //Kaydet butonunu kilitle
                btnKaydet.Enabled = false;
            }
        }

        private void LoadCombo<T>(ComboBox cmb) where T : struct, IConvertible, IComparable, IFormattable
        {
            cmb.DataSource = Enum.GetValues(typeof(T)).Cast<Enum>().
                Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()),
                    typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
            cmb.DisplayMember = "Description";
            cmb.ValueMember = "value";
        }

        private void BilgileriEkranaAktar()
        {
            policem.Firma =Session.FirmaService.GetById(policem.FirmaId);
            txtPoliceSahibi.Text = policem.Firma.Unvan;
            policem.Sigortaci = Session.SigortaciService.GetById(policem.SigortaciId);
            txtSigortaFirma.Text = policem.Sigortaci.Unvan;
            txtCmbPoliceTuru.SelectedValue = policem.PoliceTuru.ToString();
            txtPoliceNo.Text = policem.PoliceNo;
            txtDateBaslangicTarih.Value = policem.PoliceBaslangicTarih;
            txtDateBitisTarih.Value = policem.PoliceBitisTarih;
            txtPolicelenen.Text = policem.Policelenen;
            txtAciklama.Text = policem.Aciklama;
            txtTutar.Text = policem.Tutar.ToString();
            txtOncekiTutar.Text = policem.OncekiTutar.ToString();
            txtChkTaksit.Checked = (policem.Taksit == Taksit.Evet) ? true : false;
            txtCmbOdemeTuru.SelectedValue = policem.OdemeTuru;
            txtCmbPoliceTuru.SelectedValue = policem.PoliceTuru;
            txtTaksitSayisi.Text = policem.TaksitSayisi.ToString();
            txtchkGeldimi.Checked = (policem.PoliceGeldimi == EvetHayir.Evet) ? true : false;
            if (policem.Yenilendimi == Convert.ToInt32("1"))
            {
                lblYenilenmis.Visible = true;
                //Dikkat Herşeyi Kilitleyeceğiz
                btnKaydet.Enabled = false;
                btnPoliceBul.Enabled = false;
                btnFirmaBul.Enabled = false;
                txtChkTaksit.Enabled = false;
            }
            else
            {
                lblYenilenmis.Visible = false;
                btnKaydet.Enabled = true;
                btnPoliceBul.Enabled = true;
                btnFirmaBul.Enabled = true;
                txtChkTaksit.Enabled = true;
            }
        }

        private void BilgileriNesneyeAktar()
        {
            
            policem.Firma =_policeMusteri;
            policem.FirmaId = policem.Firma.FirmaId;
            policem.Sigortaci =_sigortaFirma;
            
            policem.SigortaciId = policem.Sigortaci.SigortaciId;
            if (YeniKayit)
            {
                policem.Firma = null;
                policem.Sigortaci = null;
            }
            policem.PoliceTuru = EnumPoliceTuruAktar(txtCmbPoliceTuru.SelectedValue);
            policem.OdemeTuru = EnumOdemeTuruAktar(txtCmbOdemeTuru.SelectedValue);
            policem.PoliceNo = txtPoliceNo.Text;
            txtDateBaslangicTarih.Value = new DateTime(txtDateBaslangicTarih.Value.Date.Year
                ,txtDateBaslangicTarih.Value.Month,txtDateBaslangicTarih.Value.Day,12,00,00);
            policem.PoliceBaslangicTarih = txtDateBaslangicTarih.Value;
            txtDateBitisTarih.Value = new DateTime(txtDateBitisTarih.Value.Date.Year
                , txtDateBitisTarih.Value.Month, txtDateBitisTarih.Value.Day, 12, 00, 00);
            policem.PoliceBitisTarih = txtDateBitisTarih.Value;
            policem.Policelenen = txtPolicelenen.Text;
            policem.Aciklama = txtAciklama.Text;
            policem.Tutar = Convert.ToDecimal(txtTutar.Text);

            if (txtOncekiTutar.Text == string.Empty)
                policem.OncekiTutar = 0;
            else
                policem.OncekiTutar=Convert.ToDecimal(txtOncekiTutar.Text);


            if (txtChkTaksit.Checked == true)
                policem.Taksit = Taksit.Evet;
            else
                policem.Taksit = Taksit.Hayır;
            if (txtchkGeldimi.Checked == true)
                policem.PoliceGeldimi = EvetHayir.Evet;
            else
                policem.PoliceGeldimi = EvetHayir.Hayır;

            if (policem.OncekiTutar == 0)
                policem.ArtisYuzdesi = 100;
            else
                policem.ArtisYuzdesi = policem.Tutar * 100 / policem.OncekiTutar-100;
            policem.TaksitSayisi = Convert.ToInt32(txtTaksitSayisi.Text);

        }

        private PoliceTuru EnumPoliceTuruAktar(object selectedValue)
        {
            switch (selectedValue.ToString())
            {
                case "Seciniz":
                    return PoliceTuru.Seciniz;                    
                case "Kasko":
                    return PoliceTuru.Kasko;                    
                case "Trafik":
                    return PoliceTuru.Trafik;                    
                case "Saglık":
                    return PoliceTuru.Saglık;                    
                case "Konut":
                    return PoliceTuru.Konut;                    
                case "Dask":
                    return PoliceTuru.Dask;                  
                default:
                    return PoliceTuru.Seciniz;                  
            }
        }

        private OdemeTipi EnumOdemeTuruAktar(object selectedValue)
        {
            switch (selectedValue.ToString())
            {
                case "Seciniz":
                    return OdemeTipi.Seciniz;                    
                case "Nakit":
                    return OdemeTipi.Nakit;                    
                case "KrediKartı":
                    return OdemeTipi.KrediKartı;                    
                case "Banka":
                    return OdemeTipi.Banka;                    
                default:
                    return OdemeTipi.Seciniz;               
            }
        }

        private void TxtChkTaksit_CheckedChanged(object sender, EventArgs e)
        {
            if (txtChkTaksit.Checked == true)
            {
                txtTaksitSayisi.Enabled = true;
                txtTaksitSayisi.Text = "1";
            }
            else
            {
                txtTaksitSayisi.Enabled = false;
                txtTaksitSayisi.Text = "1";
            }
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            BilgileriNesneyeAktar();
            try
            {
                policem = YeniKayit ? Session.PoliceService.Add(policem) : Session.PoliceService.Update(policem);
                this.DialogResult = DialogResult.OK;
            }
            catch
            {
                this.DialogResult = DialogResult.Cancel;
                MessageBox.Show("Hata Oluştu");
            }
        }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BtnFirmaBul_Click(object sender, EventArgs e)
        {
            FrmSigortaciSec f = new FrmSigortaciSec();
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                _sigortaFirma=policem.Sigortaci = f.sigortaFirma;
                txtSigortaFirma.Text = f.sigortaFirma.Unvan;
            }
        }

        private void BtnPoliceBul_Click(object sender, EventArgs e)
        {
            FrmMusteriSec f = new FrmMusteriSec();
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                _policeMusteri=policem.Firma = f.policeMusteri;
                txtPoliceSahibi.Text = f.policeMusteri.Unvan;
            }

        }

        private void TxtDateBaslangicTarih_ValueChanged(object sender, EventArgs e)
        {
            txtDateBitisTarih.Value = txtDateBaslangicTarih.Value.AddYears(1);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblYenilenmis.Visible = !lblYenilenmis.Visible;
        }
    }
}
