using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using Policem.Core.Business.ValidationRules.FluentValidation;
using Policem.Core.Core.CrossCuttingConcern.ExceptionHandling.Exceptions;
using Policem.Core.Utility;
using Policem.Data;
using Policem.UI.DependencyResolution;
using Policem.UI.Forms.Base;
using Policem.UI.Properties;

namespace Policem.UI.Forms
{
    public partial class FrmSigortaci : XForm
    {
        
        public Sigortaci _sigortaci = new Sigortaci();
        private List<SigortaciEkran> Liste;
        private bool YeniKayit = true;
        public FrmSigortaci()
        {
            //var sasd = new Session2(p,m,s);
            InitializeComponent();
            //Skin currentSkin = CommonSkins.GetSkin(AppSession.Settings.SkinName);
            //Color bc = currentSkin.Colors.GetColor(DevExpress.Skins.CommonColors.Window);
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            ControlColorizer controlColorizer1 = new ControlColorizer
                            (Color.FromName(AppSession.PrgSettingsOrg.AktifAlanRengi),SystemColors.Window,
                new Control[5]
                  {
                    (Control) this.txtFirmaKod,
                    (Control) this.txtUnvan,
                    (Control) this.txtHasarTel,
                    (Control) this.txtTemsilci,
                    (Control) this.txtTemsilciTel
                  });
        }

        private void FrmSigortaci_Load(object sender, EventArgs e)
        {
            
            txtFirmaKod.Focus();
            SigortaciListesi();
            
            GridManager manager = GridManager.GetManager(this.gvSigortacilar);
            manager.GridMenu.AddMenu("Poliçe Ekle", new EventHandler(BtnPoliceEkle_Click));
            manager.GridMenu.AddMenu("Alınan Poliçeler", new EventHandler(BtnPoliceleri_Click));
            manager.GridMenu.AddMenu("Sil", new EventHandler(this.BtnSil_Click), (Image)Resources.Delete_16x16);
            //GridControl(gridView1);
            ToplamKayitSayisi();
            dxErrorProvider1.DataSource = typeof(SigortaciValidator);
            dxErrorProvider1.ContainerControl = this;
            InitGridView(gvSigortacilar);
        }
        private void SigortaciListesi()
        {

            Liste = Session.FirmaPoliceService.GetAll(); //Session.SigortaciService.GetAll();
            //Liste.Join(Session2.PoliceService.GetAll(), emp => emp.Policeler, pol => pol.Sigortaci);
            //dataSetSigortacilar2 = dataSetSigortacilar = Liste.ConvertGenericList("Sigortacilar");
            //gridSigortacilar.DataSource = dataSetSigortacilar.Tables["Sigortacilar"];
            gcSigortacilar.DataSource = Liste;
            gridSigortacilar.DataSource = Liste;
            //List<SigortaFirma> Liste = Session2.SigortaFirmaService.GetAll();
            //dataSetSigortacilar2 = Liste.ConvertGenericList("Sigortacilar");
            //dataSetSigortacilar.Merge(dataSetSigortacilar2,true,MissingSchemaAction.Add);           
            GridDüzenle();
        }
        private void GridDüzenle()
        {
            //GridAlanGizle(this.gvKurum, "KurumId;YetkiliKisi;Adres1;Adres2;Tel1;Tel2;Tel3;Fax;EPosta;Bilgi;M;IsKoluKodu;YeniUniteKodu;EskiUniteKodu;IsyeriSiraNo;IlKodu;IlceKodu;KontrolNo;AraciKodu;TehlikeDerecesi;SSKSicilNo;SSKBolgeAdi;VergiDairesi;VergiNo;");
            UIGridUtility.GridAlanGizle(this.gvSigortacilar, "SigortaciId;SigortaciAdi;Policeler;HasarNumarasi;TemsilciTel;TemsilciAdi");
            //Önce Alan Gizleme
            gvSigortacilar.Columns["SigortaciId"].Visible = false;
            gvSigortacilar.Columns["SigortaciId"].Caption = "Referans No";
            gvSigortacilar.Columns["SigortaciAdi"].Visible = false;
            gvSigortacilar.Columns["SigortaciAdi"].Caption = "Sigortaci Adı";
            gvSigortacilar.Columns["FirmaNo"].Caption = "Kodu";
            gvSigortacilar.Columns["Unvan"].Caption = "Firma Ünvanı";
            gvSigortacilar.Columns["HasarNumarasi"].Caption = "Hasar Telefonu";
            gvSigortacilar.Columns["TemsilciAdi"].Caption = "Temsilci Adı";
            gvSigortacilar.Columns["TemsilciTel"].Caption = "Temsilci Telefonu";
            gvSigortacilar.Columns["PasifPoliceSayisi"].Visible = false;
            gvSigortacilar.Columns["ToplamPoliceSayisi"].Visible = false;
            gvSigortacilar.Columns["AktifPoliceSayisi"].Caption = "Aktif Poliçe Sayısı";
            gvSigortacilar.Columns["AktifPoliceSayisi"].DisplayFormat.Format =  new FormatAdet();
            //gvSigortacilar.Columns["AktifPoliceSayisi"].DisplayFormat.FormatString = "{0:#}";
            gvSigortacilar.BestFitColumns();
            
        }
        private void OrjinalBilgiDoldurma()
        {
            txtFirmaKod.Text = _sigortaci.FirmaNo?.ToString();
            txtUnvan.Text = _sigortaci.Unvan?.ToString();
            txtHasarTel.Text = _sigortaci.HasarNumarasi?.ToString();
            txtTemsilci.Text = _sigortaci.TemsilciAdi?.ToString();
            txtTemsilciTel.Text = _sigortaci.TemsilciTel?.ToString();
        }

        private void AlanTemizle()
        {
            txtFirmaKod.Text =
                txtUnvan.Text =
                txtHasarTel.Text =
                txtTemsilci.Text =
                txtTemsilciTel.Text = string.Empty;
        }

        private void GridSigortacilar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            YeniKayit = false;
            _sigortaci = Session.SigortaciService.GetById(Convert.ToInt32(gridSigortacilar.CurrentRow.Cells[0].Value.ToString()));
            OrjinalBilgiDoldurma();
        }
        private void BtnIptal_Click(object sender, EventArgs e)
        {
            OrjinalBilgiDoldurma();
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            _sigortaci.FirmaNo = txtFirmaKod.Text;
            _sigortaci.SigortaciAdi = _sigortaci.Unvan = txtUnvan.Text;
            _sigortaci.HasarNumarasi = txtHasarTel.Text;
            _sigortaci.TemsilciAdi = txtTemsilci.Text;
            _sigortaci.TemsilciTel = txtTemsilciTel.Text;
            //var validator = new SigortaciValidator();
            //ValidationResult results = validator.Validate(_sigortaci);
            //bool success = results.IsValid;
            //if (success)
            try
            {
                _sigortaci = (YeniKayit == true) ? Session.SigortaciService.Add(_sigortaci) : Session.SigortaciService.Update(_sigortaci);
                SigortaciListesi();
                OrjinalBilgiDoldurma();
                AppSession.MainForm.NotifyMain(_sigortaci.Unvan + " Unvanlı Sigorta Firması Kayıt Edildi.");

            }
            catch (ValidationCoreException mesaj)
            {
                
                MessageBox.Show(mesaj.Message.ToString());
            }
            //else
            //    MessageBox.Show(results.ToString());
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {            
            if (YeniKayit == false)
            {
                Sigortaci _sigortacim = Session.SigortaciService.GetById(Convert.ToInt32(gridSigortacilar.CurrentRow.Cells[0].Value.ToString()));
                var durum = Session.PoliceService.GetAll().Where(t => t.SigortaciId == _sigortacim.SigortaciId).Count();
                if (durum == 0)
                {
                    //MessageBox.Show("testc");
                    KayıtSil(_sigortacim);
                }
                else
                    MessageBox.Show("Poliçe kesilmiş durumda");
                
            }
            else MessageBox.Show("Önce Kayıt Secin...");
        }

        private void KayıtSil(Sigortaci silinecekFirma)
        {
            DialogResult durum = new DialogResult();
            // firma poliçeleri var ise silme engellenecek
            durum = MessageBox.Show(silinecekFirma.Unvan + " firmasını silmek istiyor musunuz", "Emin Misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (durum == DialogResult.Yes)
            {
                Session.SigortaciService.Delete(silinecekFirma);
                YeniKayit = true;
                _sigortaci = new Sigortaci();
                gridSigortacilar.ClearSelection();
                AlanTemizle();
            }
            else
            {
                YeniKayit = true;
                _sigortaci = new Sigortaci();
                AlanTemizle();
            }

        }
        private void BtnPoliceleri_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hazırlanıyor...");
        }

        private void BtnPoliceEkle_Click(object sender, EventArgs e)
        {
            var sigortaci = Session.SigortaciService.GetById(Convert.ToInt32(gridSigortacilar.CurrentRow.Cells[0].Value.ToString()));
            FrmPolice f = new FrmPolice(sigortaci);
            f.ShowDialog();
        }

        private void FrmSigortaci_Shown(object sender, EventArgs e)
        {
            SplashScreenManager.CloseForm();
        }

        private void TxtFirmaKod_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            YeniKayitBaslatma();
        }

        private void YeniKayitBaslatma()
        {
            YeniKayit = true;
            _sigortaci = new Sigortaci();
            gridSigortacilar.ClearSelection();
            AlanTemizle();
        }

        private void GridView1_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                YeniKayit = false;
                var handle = this.gvSigortacilar.GetSelectedRows()[0];
                var id = Convert.ToInt32(this.gvSigortacilar.GetRowCellValue(handle, "SigortaciId"));
                _sigortaci = Session.SigortaciService.GetById(id);
                OrjinalBilgiDoldurma();
                txtFirmaKod.Focus();
            }
            catch { YeniKayitBaslatma(); }
        }

        private void BtnEklePolice_ItemClick(object sender, ItemClickEventArgs e)
        {
            var handle = this.gvSigortacilar.GetSelectedRows()[0];
            var sigortaci = Session.SigortaciService.GetById(Convert.ToInt32(this.gvSigortacilar.GetRowCellValue(handle, "SigortaciId")));
            FrmPolice f = new FrmPolice(sigortaci);
            f.ShowDialog();
        }

        public void ToplamKayitSayisi()
        {
            gvSigortacilar.OptionsView.ShowFooter = true;
            gvSigortacilar.Columns["FirmaNo"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gvSigortacilar.Columns["FirmaNo"].SummaryItem.DisplayFormat = "{0:#,##0} Kayıt";
            
        }
    }
}
