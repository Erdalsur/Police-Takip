using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using Policem.Core.Utility;
using Policem.Data;
using Policem.Data.Enums;
using Policem.UI.DependencyResolution;
using Policem.UI.Forms.Base;

namespace Policem.UI.Forms
{
    public partial class FrmGelmeyenPoliceler : XForm
    {
        private Police SeciliPolice = null;
        public FrmGelmeyenPoliceler()
        {
            InitializeComponent();
        }

        private void FrmGelmeyenPoliceler_Load(object sender, EventArgs e)
        {
            PolicesiGelmeyenListesi();
            InitGridView(gvGelmeyenPoliceler);
        }

        private void PolicesiGelmeyenListesi()
        {
            var policelerim = Session.PoliceService.GetAll();
            var RaporPoliceleri = policelerim;
            RaporPoliceleri = policelerim.Where(t => t.PoliceGeldimi==EvetHayir.Hayır).ToList();
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
            gcGelmeyenPoliceler.DataSource = null;
            var son30gün = DateTime.Now.AddDays(-30);
            gcGelmeyenPoliceler.DataSource = a.Where(ay => ay.PoliceBitisTarih > son30gün).OrderBy(t => t.PoliceBaslangicTarih).ToList();
            GridDüzenle();
        }
        private void GridDüzenle()
        {
            UIGridUtility.GridAlanGizle(gvGelmeyenPoliceler, "PoliceId;FirmaId;SigortaciId");
            gvGelmeyenPoliceler.Columns["PoliceId"].Caption = "Referans No";
            gvGelmeyenPoliceler.Columns["FirmaId"].Caption = "Müşteri Referans No";
            gvGelmeyenPoliceler.Columns["SigortaciId"].Caption = "Sigortaci Referans No";
            gvGelmeyenPoliceler.Columns["PoliceTuru"].Caption = "Poliçe Tipi";
            gvGelmeyenPoliceler.Columns["PoliceTuru"].ColumnEdit = GetCustomPoliceTipi();
            gvGelmeyenPoliceler.Columns["PoliceTuru"].AppearanceCell.TextOptions.RightToLeft = true;
            gvGelmeyenPoliceler.Columns["PoliceNo"].Caption = "Poliçenin Numarası";
            gvGelmeyenPoliceler.Columns["PoliceBaslangicTarih"].Caption = "Başlangıç Tarihi";
            gvGelmeyenPoliceler.Columns["PoliceBitisTarih"].Caption = "Bitiş Tarihi";
            gvGelmeyenPoliceler.Columns["Policelenen"].Caption = "Neyin Poliçelendiği";
            gvGelmeyenPoliceler.Columns["Aciklama"].Caption = "Açıklama";
            gvGelmeyenPoliceler.Columns["Tutar"].Caption = "Tutar";
            gvGelmeyenPoliceler.Columns["Tutar"].AppearanceCell.TextOptions.RightToLeft = true;
            gvGelmeyenPoliceler.Columns["Tutar"].DisplayFormat.FormatType = FormatType.Custom;
            gvGelmeyenPoliceler.Columns["Tutar"].DisplayFormat.Format = new FormatPara("TL");
            gvGelmeyenPoliceler.Columns["Tutar"].DisplayFormat.FormatString = "#.###,## TL";
            gvGelmeyenPoliceler.Columns["ArtisYuzdesi"].Caption = "Artış Oranı";
            gvGelmeyenPoliceler.Columns["ArtisYuzdesi"].AppearanceCell.TextOptions.RightToLeft = true;
            gvGelmeyenPoliceler.Columns["ArtisYuzdesi"].DisplayFormat.FormatType = FormatType.Custom;
            gvGelmeyenPoliceler.Columns["ArtisYuzdesi"].DisplayFormat.Format = new FormatYuzde();
            gvGelmeyenPoliceler.Columns["PoliceGeldimi"].Caption = "Poliçe Basıldı";
            gvGelmeyenPoliceler.Columns["PoliceGeldimi"].AppearanceCell.TextOptions.RightToLeft = true;
            gvGelmeyenPoliceler.Columns["Unvan"].Caption = "Sigorta Firması";
            gvGelmeyenPoliceler.Columns["Name"].Caption = "Poliçe Sahibi";
            gvGelmeyenPoliceler.ViewCaption = "Gelmeyen Poliçeler";
            gvGelmeyenPoliceler.ExpandAllGroups();
            gvGelmeyenPoliceler.BestFitColumns();
            //gridViewPoliceler.GroupedColumns();
            
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

        private void FrmGelmeyenPoliceler_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                PolicesiGelmeyenListesi();
            }
        }
        public void ToplamHesapla()
        {
            gvGelmeyenPoliceler.OptionsView.ShowFooter = true;
            GridGroupSummaryItem item = new GridGroupSummaryItem
            {
                FieldName = "Tutar",
                ShowInGroupColumnFooter = gvGelmeyenPoliceler.Columns["Tutar"],
                SummaryType = DevExpress.Data.SummaryItemType.Sum,
                Format = new FormatPara("TL")
            };
            gvGelmeyenPoliceler.GroupSummary.Add(item);
            gvGelmeyenPoliceler.Columns["Tutar"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gvGelmeyenPoliceler.Columns["Tutar"].DisplayFormat.Format = new FormatPara("TL");
            gvGelmeyenPoliceler.Columns["Tutar"].SummaryItem.DisplayFormat = "{0:#,###.##} TL";

        }

        private void FrmGelmeyenPoliceler_Shown(object sender, EventArgs e)
        {
            gvGelmeyenPoliceler.Columns["Unvan"].GroupIndex = 0;
            ToplamHesapla();
            gvGelmeyenPoliceler.BestFitColumns();
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

        private void barBtnExcell_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gvGelmeyenPoliceler.BestFitColumns();
            gvGelmeyenPoliceler.OptionsPrint.ShowPrintExportProgress = false;
            PrintingSystem printingSystem1 = new PrintingSystem();
            PrintableComponentLink printableComponentLink1 = new PrintableComponentLink();

            printingSystem1.Links.AddRange(new object[] { printableComponentLink1 });
            ((GridView)gcGelmeyenPoliceler.MainView).ClearDocument();
            printableComponentLink1.Component = gcGelmeyenPoliceler;
            printableComponentLink1.Landscape = true;
            printableComponentLink1.Margins = new Margins(1, 1, 10, 10);
            var filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            printableComponentLink1.ExportToXlsx(filePath + "\\Gelmeyen Policeler.xlsx");


            using (Process pr = new Process())
            {
                pr.StartInfo = new ProcessStartInfo(filePath + "\\Gelmeyen Policeler.xlsx");
                pr.Start();
            }
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //gridControlPoliceler.ExportToXlsx(path + "\\Gelmeyen Policeler.xlsx");
            //if (MessageBox.Show("Aktarılan dosyayı şimdi görmek ister misiniz?", "Excel dosyası", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    System.Diagnostics.Process.Start(path + "\\Gelmeyen Policeler.xlsx");
            //}
        }

        private void gridViewPoliceler_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                var handle = this.gvGelmeyenPoliceler.GetSelectedRows()[0];
                SeciliPolice = Session.PoliceService.GetById(Convert.ToInt32(gvGelmeyenPoliceler.GetRowCellValue(handle, "PoliceId")));

            }
            catch
            {
                SeciliPolice = null;
            }
        }

        public int seciliSatir = 999999999; // 999999999 olmasının sebebi herhangi bir çakışmayı engelleme amaçlıdır.

        private void gridViewPoliceler_RowClick(object sender, RowClickEventArgs e)
        {
            gvGelmeyenPoliceler.SelectRow(gvGelmeyenPoliceler.FocusedRowHandle); // gridview'de tıklanan satırı seçmek için
            gvGelmeyenPoliceler.ShowEditor(); // seçimi göstermek için
            gvGelmeyenPoliceler.Appearance.FocusedCell.BackColor = Color.Transparent; // Tıklanan hücrenin arkaplanını transparan yapmak için
            if (seciliSatir == gvGelmeyenPoliceler.FocusedRowHandle) // bir önceki tıklanan satır ile şimdi tıklanan satır aynı mı diye kontrol ediyor
            {
                seciliSatir = 999999999; // Tıklamayı sıfırlamak için tekrar başlangıç değerine dönüyoruz.
                // Çift tıklandığında yapılacak işlemler yazılacak..
                BtnPoliceAc_Click(sender, e);
            }
            else { seciliSatir = gvGelmeyenPoliceler.FocusedRowHandle; }  // aynı değlse son tıklananı alıyor. 
        }

        private void BtnPoliceAc_Click(object sender, EventArgs e)
        {
            var handle = this.gvGelmeyenPoliceler.GetSelectedRows()[0];
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
                PolicesiGelmeyenListesi();
        }

        private void barBtnGuncel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PolicesiGelmeyenListesi();
        }

        private void barBtnPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gvGelmeyenPoliceler.BestFitColumns();
            gvGelmeyenPoliceler.OptionsPrint.ShowPrintExportProgress = false;
            PrintingSystem printingSystem1 = new PrintingSystem();
            PrintableComponentLink printableComponentLink1 = new PrintableComponentLink();

            printingSystem1.Links.AddRange(new object[] { printableComponentLink1 });
            ((GridView)gcGelmeyenPoliceler.MainView).ClearDocument();
            printableComponentLink1.Component = gcGelmeyenPoliceler;
            printableComponentLink1.Landscape = true;
            printableComponentLink1.Margins = new Margins(1, 1, 10, 10);
            var filePath= Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            printableComponentLink1.ExportToPdf(filePath+"\\Gelmeyen Policeler.pdf");
            
            //printableComponentLink1.ExportToHtml(filePath + "\\Gelmeyen Policeler.html");

            using (Process pr = new Process())
            {
                pr.StartInfo = new ProcessStartInfo(filePath+ "\\Gelmeyen Policeler.pdf");
                pr.Start();
            }

            //    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //gridControlPoliceler.ExportToPdf(path + "\\Gelmeyen Policeler.pdf");
            //if (MessageBox.Show("Aktarılan dosyayı şimdi görmek ister misiniz?", "Excel dosyası", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    System.Diagnostics.Process.Start(path + "\\Gelmeyen Policeler.pdf");
            //}
        }
    }
}
