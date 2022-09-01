using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using Policem.Core.Extensions;
using Policem.Core.Utility;
using Policem.Data;
using Policem.Data.Enums;
using Policem.UI.DependencyResolution;
using Policem.UI.Forms.Base;

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
            gridViewPoliceler.ViewCaption = "Süresi Biten Poliçeler";
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
        }

        private void CmbRaporSure_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                PoliceListesiGetir((PasifPoliceRapor)CmbRaporSure.EditValue, (PoliceRaporTipi)CmbRaporTip.EditValue);

            }
            catch { }
        }

        private void PoliceListesiGetir(PasifPoliceRapor raporSure, PoliceRaporTipi raporTipi)
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
            gridControlPoliceler.DataSource = null;
            gridControlPoliceler.DataSource = a.OrderByDescending(t => t.PoliceBitisTarih).ToList();
            GridDüzenle();
        }
        private void GridDüzenle()
        {
            UIGridUtility.GridAlanGizle(gridViewPoliceler, "PoliceId;FirmaId;SigortaciId");
            gridViewPoliceler.Columns["PoliceId"].Caption = "Referans No";
            gridViewPoliceler.Columns["FirmaId"].Caption = "Müşteri Referans No";
            gridViewPoliceler.Columns["SigortaciId"].Caption = "Sigortaci Referans No";
            gridViewPoliceler.Columns["PoliceTuru"].Caption = "Poliçe Tipi";
            gridViewPoliceler.Columns["PoliceTuru"].AppearanceCell.TextOptions.RightToLeft = true;
            gridViewPoliceler.Columns["PoliceNo"].Caption = "Poliçenin Numarası";
            gridViewPoliceler.Columns["PoliceBaslangicTarih"].Caption = "Başlangıç Tarihi";
            gridViewPoliceler.Columns["PoliceBitisTarih"].Caption = "Bitiş Tarihi";
            gridViewPoliceler.Columns["Policelenen"].Caption = "Neyin Poliçelendiği";
            gridViewPoliceler.Columns["Aciklama"].Caption = "Açıklama";
            gridViewPoliceler.Columns["Tutar"].Caption = "Tutar";
            gridViewPoliceler.Columns["Tutar"].AppearanceCell.TextOptions.RightToLeft = true;
            gridViewPoliceler.Columns["Tutar"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;            
            gridViewPoliceler.Columns["Tutar"].DisplayFormat.Format = new FormatPara("TL");
            gridViewPoliceler.Columns["Tutar"].DisplayFormat.FormatString = "#.###,## TL";
            gridViewPoliceler.Columns["ArtisYuzdesi"].Caption = "Artış Oranı";
            gridViewPoliceler.Columns["ArtisYuzdesi"].AppearanceCell.TextOptions.RightToLeft = true;
            gridViewPoliceler.Columns["ArtisYuzdesi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridViewPoliceler.Columns["ArtisYuzdesi"].DisplayFormat.Format = new FormatYuzde();
            gridViewPoliceler.Columns["PoliceGeldimi"].Caption = "Poliçe Basıldı";
            gridViewPoliceler.Columns["PoliceGeldimi"].AppearanceCell.TextOptions.RightToLeft = true;
            gridViewPoliceler.Columns["Unvan"].Caption = "Sigorta Firması";
            gridViewPoliceler.Columns["Name"].Caption = "Poliçe Sahibi";
            gridViewPoliceler.ExpandAllGroups();
            gridViewPoliceler.BestFitColumns();
        }

        private void GridViewPoliceler_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                var handle = this.gridViewPoliceler.GetSelectedRows()[0];
                SeciliPolice = Session.PoliceService.GetById(Convert.ToInt32(gridViewPoliceler.GetRowCellValue(handle, "PoliceId")));

            }
            catch
            {
                SeciliPolice = null;
            }
        }

        private void GridViewPoliceler_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
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
            gridViewPoliceler.SelectRow(gridViewPoliceler.FocusedRowHandle); // gridview'de tıklanan satırı seçmek için
            gridViewPoliceler.ShowEditor(); // seçimi göstermek için
            gridViewPoliceler.Appearance.FocusedCell.BackColor = Color.Transparent; // Tıklanan hücrenin arkaplanını transparan yapmak için
            if (seciliSatir == gridViewPoliceler.FocusedRowHandle) // bir önceki tıklanan satır ile şimdi tıklanan satır aynı mı diye kontrol ediyor
            {
                seciliSatir = 999999999; // Tıklamayı sıfırlamak için tekrar başlangıç değerine dönüyoruz.
                // Çift tıklandığında yapılacak işlemler yazılacak..
                BtnPoliceAc_Click(sender, e);
            }
            else { seciliSatir = gridViewPoliceler.FocusedRowHandle; }  // aynı değlse son tıklananı alıyor. 
        }
        private void BtnPoliceAc_Click(object sender, EventArgs e)
        {
            var handle = this.gridViewPoliceler.GetSelectedRows()[0];
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
                PoliceListesiGetir((PasifPoliceRapor)CmbRaporSure.EditValue, (PoliceRaporTipi)CmbRaporTip.EditValue);
            }
        }
    }
}
