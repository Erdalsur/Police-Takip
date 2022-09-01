using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using Policem.Core.Extensions;
using Policem.Core.Utility;
using Policem.Data;
using Policem.Data.Enums;
using Policem.UI.DependencyResolution;
using Policem.UI.Forms.Base;
using Policem.UI.Properties;

namespace Policem.UI.Forms
{
    public partial class FrmPasifPoliceler : XForm
    {
        private Police SeciliPolice = null;
        private int seciliSatir;

        public FrmPasifPoliceler()
        {
            InitializeComponent();
        }

        private void FrmPasifPoliceler_Load(object sender, EventArgs e)
        {
            EnumToLists();
            gvPasifPoliceler.ViewCaption = "Süresi Biten Poliçeler";
            GridManager manager2 = GridManager.GetManager(this.gvPasifPoliceler);
            manager2.GridMenu.AddMenu("Aç", new EventHandler(BtnPoliceAc_Click));
            manager2.GridMenu.AddMenu("Seçili Poliçeyi Yenile", new EventHandler(BtnPoliceYenileme_Click), (Image)Resources.refresh);
            InitGridView(gvPasifPoliceler);
        }
        private void BtnPoliceYenileme_Click(object sender, EventArgs e)
        {
            var handle = this.gvPasifPoliceler.GetSelectedRows()[0];
            // handle 0 küçük ise group seçili
            if (handle >= 0)
            {
                Police eskiPolice = Session.PoliceService.GetById(Convert.ToInt32(gvPasifPoliceler.GetRowCellValue(handle, "PoliceId"))); ;
                eskiPolice.Firma = Session.FirmaService.GetById(eskiPolice.FirmaId);
                eskiPolice.Sigortaci = Session.SigortaciService.GetById(eskiPolice.SigortaciId);
                if (eskiPolice.Yenilendimi==1)
                {
                    XtraMessageBox.Show("Bu Poliçe Daha önceden yenilenmiş işlem yapamazsınız.","Uyarı");
                    return;
                }
                Police yeniPolice = new Police
                {
                    Firma = eskiPolice.Firma,
                    FirmaId = eskiPolice.FirmaId,
                    Sigortaci = eskiPolice.Sigortaci,
                    SigortaciId = eskiPolice.SigortaciId,
                    PoliceBaslangicTarih = eskiPolice.PoliceBaslangicTarih,
                    PoliceBitisTarih = eskiPolice.PoliceBitisTarih,
                    OncekiTutar = eskiPolice.Tutar,
                    Policelenen = eskiPolice.Policelenen,
                    PoliceNo = eskiPolice.PoliceNo,
                    PoliceTuru = eskiPolice.PoliceTuru,
                    Aciklama = eskiPolice.Aciklama
                };
                //Yeni Poliçeyi Sayfaya gönder ama dikkat poliçeyi açmaya çalışmasın
                FrmPolice f = new FrmPolice(yeniPolice, true, true);
                f.ShowDialog();
                if (f.DialogResult == DialogResult.OK)
                {
                    //eski policeye yeni police bilgilerini vereğiz.
                    eskiPolice.Yenilendimi = 1;
                    eskiPolice.YeniPoliceId = f.policem.PoliceId;
                    Session.PoliceService.Update(eskiPolice);
                    PoliceListesiGetir((PasifPoliceRapor)CmbRaporSure.EditValue, (PoliceRaporTipi)CmbRaporTip.EditValue,(YenilemeTipi)CmbYenilendimi.EditValue);
                }
            }
        }
        private void EnumToLists()
        {
            //Süre Durumu
            CmbRaporSure.Properties.DataSource = typeof(PasifPoliceRapor).ToList();
            CmbRaporSure.Properties.DisplayMember = "Value";
            CmbRaporSure.Properties.ValueMember = "Key";
            CmbRaporSure.Properties.ShowHeader = false;
            CmbRaporSure.Properties.PopulateColumns();
            CmbRaporSure.Properties.Columns["Key"].Visible = false;
            CmbRaporSure.EditValue = PasifPoliceRapor.Hepsi;
            //Poliçe Tipleri
            CmbRaporTip.Properties.DataSource = typeof(PoliceRaporTipi).ToList();
            CmbRaporTip.Properties.DisplayMember = "Value";
            CmbRaporTip.Properties.ValueMember = "Key";
            CmbRaporTip.Properties.ShowHeader = false;
            CmbRaporTip.Properties.PopulateColumns();
            CmbRaporTip.Properties.Columns["Key"].Visible = false;
            CmbRaporTip.EditValue = PoliceRaporTipi.Hepsi;
            //Yenilendi
            CmbYenilendimi.Properties.DataSource = typeof(YenilemeTipi).ToList();
            CmbYenilendimi.Properties.DisplayMember = "Value";
            CmbYenilendimi.Properties.ValueMember = "Key";
            CmbYenilendimi.Properties.ShowHeader = false;
            CmbYenilendimi.Properties.PopulateColumns();
            CmbYenilendimi.Properties.Columns["Key"].Visible = false;
            CmbYenilendimi.EditValue = YenilemeTipi.Hepsi;

        }
        public RepositoryItemGridLookUpEdit PoliceYenilendi()
        {
            try
            {
                return this.GetCustomGLE();
            }
            catch
            {
                
                return (RepositoryItemGridLookUpEdit)null;
            }
        }

        private RepositoryItemGridLookUpEdit GetCustomGLE()
        {
            RepositoryItemGridLookUpEdit itemGridLookUpEdit = new RepositoryItemGridLookUpEdit();
            itemGridLookUpEdit.DataSource= typeof(YenilemeTipi).ToList();
            itemGridLookUpEdit.DisplayMember = "Value";
            itemGridLookUpEdit.ValueMember ="Key";
            itemGridLookUpEdit.PopulateViewColumns();
            itemGridLookUpEdit.View.Columns["Key"].Visible = false;
            return itemGridLookUpEdit;
        }

        private RepositoryItemGridLookUpEdit GetCustomPoliceTipi()
        {
            RepositoryItemGridLookUpEdit itemGridLookUpEdit = new RepositoryItemGridLookUpEdit();
            itemGridLookUpEdit.DataSource = typeof(PoliceTuru).ToList();
            itemGridLookUpEdit.DisplayMember = "Value";
            itemGridLookUpEdit.ValueMember = "Key";
            itemGridLookUpEdit.PopulateViewColumns();
            itemGridLookUpEdit.View.Columns["Key"].Visible = false;
            return itemGridLookUpEdit;
        }

        private void CmbRaporSure_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                PoliceListesiGetir((PasifPoliceRapor)CmbRaporSure.EditValue, (PoliceRaporTipi)CmbRaporTip.EditValue,(YenilemeTipi)CmbYenilendimi.EditValue);

            }
            catch { }
        }

        private void PoliceListesiGetir(PasifPoliceRapor raporSure, PoliceRaporTipi raporTipi, YenilemeTipi yenileme)
        {
            var policelerim = Session.PoliceService.GetAll();
            var RaporPoliceleri = policelerim;
            
            switch (raporSure)
            {
                case PasifPoliceRapor.Son15:
                    RaporPoliceleri = policelerim.Where(t => t.PoliceBitisTarih >= DateTime.Now).
                        Where(t => t.PoliceBitisTarih <= DateTime.Now.AddDays(-15)).ToList();
                    break;
                case PasifPoliceRapor.Son7:
                    RaporPoliceleri = policelerim.Where(t => t.PoliceBitisTarih >= DateTime.Now).
                        Where(t => t.PoliceBitisTarih <= DateTime.Now.AddDays(-7)).ToList();
                    break;
                case PasifPoliceRapor.GecenAy:
                    RaporPoliceleri = policelerim.Where(t => t.PoliceBitisTarih >= ExtensionMethods.AyinBaslangici(DateTime.Now.AddMonths(-1))).
                        Where(t => t.PoliceBitisTarih <= ExtensionMethods.AyinBitisi(DateTime.Now.AddMonths(-1))).ToList();
                    break;
                case PasifPoliceRapor.SonAy:
                    RaporPoliceleri = policelerim.Where(t => t.PoliceBitisTarih >= ExtensionMethods.AyinBaslangici(DateTime.Now)).
                        Where(t => t.PoliceBitisTarih <= (DateTime.Now)).ToList();
                    break;
                default:
                    RaporPoliceleri = policelerim.Where(t => t.PoliceBitisTarih < DateTime.Now).ToList();
                    break;

            }
            switch (yenileme)
            {
                case YenilemeTipi.Hepsi:
                    RaporPoliceleri = RaporPoliceleri.ToList();
                    break;
                case YenilemeTipi.Hayır:
                    RaporPoliceleri = RaporPoliceleri.Where(t=>t.Yenilendimi==0).ToList();
                    break;
                case YenilemeTipi.Evet:
                    RaporPoliceleri = RaporPoliceleri.Where(t => t.Yenilendimi == 1).ToList();
                    break;
                default:
                    RaporPoliceleri = RaporPoliceleri.ToList();
                    break;
            }
            switch (raporTipi)
            {
                case PoliceRaporTipi.Belgeler:
                    RaporPoliceleri = RaporPoliceleri.Where(t => t.PoliceTuru == PoliceTuru.K2
                    || t.PoliceTuru == PoliceTuru.Piskoteknik).ToList();
                    break;
                case PoliceRaporTipi.Sigortalar:
                    RaporPoliceleri = RaporPoliceleri.Where(t => t.PoliceTuru == PoliceTuru.Dask
                    || t.PoliceTuru == PoliceTuru.Elektronik
                    || t.PoliceTuru == PoliceTuru.Hayat
                    || t.PoliceTuru == PoliceTuru.IsverenMaliMesuliyet
                    || t.PoliceTuru == PoliceTuru.Kasko
                    || t.PoliceTuru == PoliceTuru.Konut
                    || t.PoliceTuru == PoliceTuru.MakinaKirilmasi
                    || t.PoliceTuru == PoliceTuru.Saglık
                    || t.PoliceTuru == PoliceTuru.SahisMaliMesuliyet
                    || t.PoliceTuru == PoliceTuru.TicariRisk
                    || t.PoliceTuru == PoliceTuru.Trafik).ToList();
                    break;
                case PoliceRaporTipi.Muayeneler:
                    RaporPoliceleri = RaporPoliceleri.Where(t => t.PoliceTuru == PoliceTuru.Muayene || t.PoliceTuru == PoliceTuru.Egsoz).ToList();
                    break;
                default:
                    //Hiçbir İşlem Yapmaya Gerek Yok
                    break;
            }
            var a = from Policem in RaporPoliceleri.ToList()
                    orderby Policem.PoliceBitisTarih descending
                    join Sigortaci in Session.SigortaciService.GetAll() on Policem.SigortaciId equals Sigortaci.SigortaciId
                    join Musteri in Session.FirmaService.GetAll() on Policem.FirmaId equals Musteri.FirmaId

                    select new
                    {
                        Policem.Yenilendimi,
                        Musteri.Name,
                        Policem.PoliceId,
                        Policem.PoliceTuru,
                        Policem.PoliceNo,
                        Policem.Policelenen,
                        Policem.Tutar,
                        Policem.ArtisYuzdesi,
                        Policem.PoliceBaslangicTarih,
                        Policem.PoliceBitisTarih,
                        Policem.PoliceGeldimi,
                        Sigortaci.Unvan,
                        Policem.FirmaId,
                        Policem.SigortaciId,
                        Policem.Aciklama
                    };
            gcPasifPoliceler.DataSource = null;
            gcPasifPoliceler.DataSource = a.OrderByDescending(t => t.PoliceBitisTarih).ToList();
            GridDüzenle();
        }
        private void GridDüzenle()
        {
            UIGridUtility.GridAlanGizle(gvPasifPoliceler, "PoliceId;FirmaId;SigortaciId");
            gvPasifPoliceler.Columns["PoliceId"].Caption = "Referans No";
            gvPasifPoliceler.Columns["FirmaId"].Caption = "Müşteri Referans No";
            gvPasifPoliceler.Columns["SigortaciId"].Caption = "Sigortaci Referans No";
            gvPasifPoliceler.Columns["PoliceTuru"].Caption = "Poliçe Tipi";
            gvPasifPoliceler.Columns["PoliceTuru"].ColumnEdit = GetCustomPoliceTipi();
            gvPasifPoliceler.Columns["PoliceTuru"].AppearanceCell.TextOptions.RightToLeft = true;
            gvPasifPoliceler.Columns["PoliceNo"].Caption = "Poliçenin Numarası";
            gvPasifPoliceler.Columns["PoliceBaslangicTarih"].Caption = "Başlangıç Tarihi";
            gvPasifPoliceler.Columns["PoliceBitisTarih"].Caption = "Bitiş Tarihi";
            gvPasifPoliceler.Columns["Policelenen"].Caption = "Neyin Poliçelendiği";
            gvPasifPoliceler.Columns["Aciklama"].Caption = "Açıklama";
            gvPasifPoliceler.Columns["Tutar"].Caption = "Tutar";
            gvPasifPoliceler.Columns["Tutar"].AppearanceCell.TextOptions.RightToLeft = true;
            gvPasifPoliceler.Columns["Tutar"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;            
            gvPasifPoliceler.Columns["Tutar"].DisplayFormat.Format = new FormatPara("TL");
            gvPasifPoliceler.Columns["Tutar"].DisplayFormat.FormatString = "#.###,## TL";
            gvPasifPoliceler.Columns["ArtisYuzdesi"].Caption = "Artış Oranı";
            gvPasifPoliceler.Columns["ArtisYuzdesi"].AppearanceCell.TextOptions.RightToLeft = true;
            gvPasifPoliceler.Columns["ArtisYuzdesi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gvPasifPoliceler.Columns["ArtisYuzdesi"].DisplayFormat.Format = new FormatYuzde();
            gvPasifPoliceler.Columns["PoliceGeldimi"].Caption = "Poliçe Basıldı";
            gvPasifPoliceler.Columns["PoliceGeldimi"].AppearanceCell.TextOptions.RightToLeft = true;
            gvPasifPoliceler.Columns["Unvan"].Caption = "Sigorta Firması";
            gvPasifPoliceler.Columns["Name"].Caption = "Poliçe Sahibi";
            gvPasifPoliceler.Columns["Yenilendimi"].Caption = "Durum";
            gvPasifPoliceler.Columns["Yenilendimi"].ColumnEdit = repositoryYenilendi;
            //gridViewPoliceler.Columns["Yenilendimi"].so
            gvPasifPoliceler.ExpandAllGroups();
            gvPasifPoliceler.BestFitColumns();
        }

        private void GridViewPoliceler_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                var handle = this.gvPasifPoliceler.GetSelectedRows()[0];
                SeciliPolice = Session.PoliceService.GetById(Convert.ToInt32(gvPasifPoliceler.GetRowCellValue(handle, "PoliceId")));

            }
            catch
            {
                SeciliPolice = null;
            }
        }

        private void GridViewPoliceler_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView currentView = sender as GridView;
            if (e.Column.FieldName == "ArtisYuzdesi")
            {
                decimal value = Convert.ToDecimal(currentView.GetRowCellValue(e.RowHandle, "ArtisYuzdesi"));
                if (value > 20)
                    e.Appearance.BackColor = Color.Red;
                if (value < 0)
                    e.Appearance.BackColor = Color.GreenYellow;
            }
            if (e.Column.FieldName == "PoliceBaslangicTarih" || e.Column.FieldName == "PoliceBitisTarih" || e.Column.FieldName == "PoliceTuru")
            {
                e.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            }
            if (e.Column.FieldName == "PoliceGeldimi")
            {
                e.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                bool value = Convert.ToBoolean(currentView.GetRowCellValue(e.RowHandle, "PoliceGeldimi"));
                if (value == false)
                    e.Appearance.BackColor = Color.Red;
            }
        }

        private void GridViewPoliceler_RowClick(object sender, RowClickEventArgs e)
        {
            gvPasifPoliceler.SelectRow(gvPasifPoliceler.FocusedRowHandle); // gridview'de tıklanan satırı seçmek için
            gvPasifPoliceler.ShowEditor(); // seçimi göstermek için
            gvPasifPoliceler.Appearance.FocusedCell.BackColor = Color.Transparent; // Tıklanan hücrenin arkaplanını transparan yapmak için
            if (seciliSatir == gvPasifPoliceler.FocusedRowHandle) // bir önceki tıklanan satır ile şimdi tıklanan satır aynı mı diye kontrol ediyor
            {
                seciliSatir = 999999999; // Tıklamayı sıfırlamak için tekrar başlangıç değerine dönüyoruz.
                // Çift tıklandığında yapılacak işlemler yazılacak..
                BtnPoliceAc_Click(sender, e);
            }
            else { seciliSatir = gvPasifPoliceler.FocusedRowHandle; }  // aynı değlse son tıklananı alıyor. 
        }
        private void BtnPoliceAc_Click(object sender, EventArgs e)
        {
            var handle = this.gvPasifPoliceler.GetSelectedRows()[0];
            // handle 0 küçük ise group seçili
            if (handle >= 0)
                PoliceBilgileriAc();
        }
        private void PoliceBilgileriAc(bool EskiPolice = true)
        {
            FrmPolice f;
            if (EskiPolice)
            {
                SeciliPolice.Firma = Session.FirmaService.GetById(SeciliPolice.FirmaId);
                SeciliPolice.Sigortaci = Session.SigortaciService.GetById(SeciliPolice.SigortaciId);
                f = new FrmPolice(SeciliPolice, false);
            }
            else
            {
                f = new FrmPolice();
            }
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                PoliceListesiGetir((PasifPoliceRapor)CmbRaporSure.EditValue, (PoliceRaporTipi)CmbRaporTip.EditValue, (YenilemeTipi)CmbYenilendimi.EditValue);
            }
        }

        private void btnExcell_Click(object sender, EventArgs e)
        {
            gvPasifPoliceler.BestFitColumns();
            gvPasifPoliceler.OptionsPrint.ShowPrintExportProgress = false;
            PrintingSystem printingSystem1 = new PrintingSystem();
            PrintableComponentLink printableComponentLink1 = new PrintableComponentLink();

            printingSystem1.Links.AddRange(new object[] { printableComponentLink1 });
            ((GridView)gcPasifPoliceler.MainView).ClearDocument();
            printableComponentLink1.Component = gcPasifPoliceler;
            printableComponentLink1.Landscape = true;
            printableComponentLink1.Margins = new Margins(1, 1, 10, 10);
            var filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            printableComponentLink1.ExportToXlsx(filePath + "\\Yenilenmeyen Policeler.xlsx");


            using (Process pr = new Process())
            {
                pr.StartInfo = new ProcessStartInfo(filePath + "\\Yenilenmeyen Policeler.xlsx");
                pr.Start();
            }
        }
    }
}
