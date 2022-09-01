using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid;
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
    public partial class FrmPoliceler : XForm
    {
        private Police SeciliPolice = null;
        public FrmPoliceler()
        {
            InitializeComponent();
        }

        private void FrmPoliceler_Load(object sender, EventArgs e)
        {
            EnumToLists();
            //PoliceListesiGetir((AktifPoliceRapor)CmbRaporTipi.EditValue);
            //this.vgc.LayoutStyle = LayoutViewStyle.SingleRecordView;
            //this.vgc.OptionsBehavior.UseEnterAsTab = true;
            //this.CreateVerticalGrid();
            //this.vgc.FocusedRow = this.vgc.Rows["BaslangicTarihi"];
            //this.vgc.BestFit();
            gridViewPoliceler.ViewCaption = "Aktif Poliçeler";
            gridViewPoliceler.OptionsView.ShowViewCaption = false;
            GridManager manager2 = GridManager.GetManager(this.gridViewPoliceler);
            manager2.GridMenu.AddMenu("Aç", new EventHandler(BtnPoliceAc_Click));
            manager2.GridMenu.AddMenu("Yeni Poliçe Ekle", new EventHandler(BtnYeniPolice_Click));
            manager2.GridMenu.AddMenu("Police Sil", new EventHandler(BtnPoliceSil_Click), (Image)Resources.Delete_16x16);
            manager2.GridMenu.AddMenu("Seçili Poliçeyi Yenile", new EventHandler(BtnPoliceYenileme_Click), (Image)Resources.refresh);
            manager2.GridMenu.AddMenu("Outlook Takvimini Oluştur", new EventHandler(BtnTakvimOlustur_Click), (Image)Resources.Calendar);
        }

        private void BtnPoliceAc_Click(object sender, EventArgs e)
        {
            var handle = this.gridViewPoliceler.GetSelectedRows()[0];
            // handle 0 küçük ise group seçili
            if (handle >= 0)
                PoliceBilgileriAc();
        }

        private void BtnYeniPolice_Click(object sender, EventArgs e)
        {
            var handle = this.gridViewPoliceler.GetSelectedRows()[0];
            // handle 0 küçük ise group seçili
            PoliceBilgileriAc(false);
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
                PoliceListesiGetir((AktifPoliceRapor)CmbRaporSure.EditValue, (PoliceRaporTipi)CmbRaporTip.EditValue);
        }

        private void BtnPoliceSil_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hazırlanıyor.");
        }

        private void BtnPoliceYenileme_Click(object sender, EventArgs e)
        {
            var handle = this.gridViewPoliceler.GetSelectedRows()[0];
            // handle 0 küçük ise group seçili
            if (handle >= 0)
            {
                Police eskiPolice = Session.PoliceService.GetById(Convert.ToInt32(gridViewPoliceler.GetRowCellValue(handle, "PoliceId"))); ;
                eskiPolice.Firma = Session.FirmaService.GetById(eskiPolice.FirmaId);
                eskiPolice.Sigortaci = Session.SigortaciService.GetById(eskiPolice.SigortaciId);
                Police yeniPolice = new Police
                {
                    Firma = eskiPolice.Firma,
                    FirmaId = eskiPolice.FirmaId,
                    Sigortaci = eskiPolice.Sigortaci,
                    SigortaciId = eskiPolice.SigortaciId,
                    PoliceBaslangicTarih = eskiPolice.PoliceBitisTarih,
                    PoliceBitisTarih = eskiPolice.PoliceBitisTarih.AddYears(1),
                    OncekiTutar = eskiPolice.Tutar,
                    Policelenen = eskiPolice.Policelenen,
                    PoliceNo = eskiPolice.PoliceNo,
                    PoliceTuru = eskiPolice.PoliceTuru
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
                    PoliceListesiGetir((AktifPoliceRapor)CmbRaporSure.EditValue, (PoliceRaporTipi)CmbRaporTip.EditValue);
                }
            }
        }

        private void BtnTakvimOlustur_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        //private void CreateVerticalGrid()
        //{
        //    this.vgc.Rows.AddRange(new BaseRow[1]
        //    {

        //        this.AddItem("BaslangicTarihi", typeof (DateTime), (RepositoryItem) new RepositoryItemDateEdit()),
        //    });
        //}
        private void EnumToLists()
        {
            //Controls.Add(CmbRaporTipi);
            CmbRaporSure.Properties.DataSource = typeof(AktifPoliceRapor).ToList();
            CmbRaporSure.Properties.DisplayMember = "Value";
            CmbRaporSure.Properties.ValueMember = "Key";
            CmbRaporSure.Properties.ShowHeader = false;
            CmbRaporSure.Properties.PopulateColumns();
            CmbRaporSure.Properties.Columns["Key"].Visible = false;
            CmbRaporSure.EditValue = AktifPoliceRapor.Hepsi;
 
            CmbRaporTip.Properties.DataSource = typeof(PoliceRaporTipi).ToList();
            CmbRaporTip.Properties.DisplayMember = "Value";
            CmbRaporTip.Properties.ValueMember = "Key";
            CmbRaporTip.Properties.ShowHeader = false;
            CmbRaporTip.Properties.PopulateColumns();
            CmbRaporTip.Properties.Columns["Key"].Visible = false;
            CmbRaporTip.EditValue = PoliceRaporTipi.Hepsi;
        }

        //public BaseRow AddItem(string name, Type t, params RepositoryItem[] ri)
        //{
        //    return this.AddItem(vgc, name, t, ri);
        //}

        //public BaseRow AddItem(VGridControl vgc, string name, Type t, params RepositoryItem[] ri)
        //{
        //    BaseRow baseRow = (BaseRow)new EditorRow();
        //    baseRow.Name = baseRow.Properties.FieldName = baseRow.Properties.Caption = name;
        //    baseRow.Height = 20;
        //    if (ri.Length > 0)
        //    {
        //        ri[0].Name = name;
        //        baseRow.Properties.RowEdit = ri[0];
        //    }
        //    else
        //    {
        //        switch (t.ToString().ToLower())
        //        {
        //            case "system.boolean":
        //                baseRow.Properties.RowEdit = (RepositoryItem)new RepositoryItemCheckEdit();
        //                baseRow.Properties.UnboundType = UnboundColumnType.Boolean;
        //                break;
        //            case "system.ınt32":
        //            case "system.int32":
        //                baseRow.Properties.RowEdit = (RepositoryItem)new RepositoryItemTextEdit();
        //                baseRow.Properties.UnboundType = UnboundColumnType.Integer;
        //                break;
        //            case "system.string":
        //                baseRow.Properties.RowEdit = (RepositoryItem)new RepositoryItemTextEdit();
        //                baseRow.Properties.UnboundType = UnboundColumnType.String;
        //                break;
        //            case "system.datetime":
        //                baseRow.Properties.RowEdit = (RepositoryItem)new RepositoryItemDateEdit();
        //                baseRow.Properties.UnboundType = UnboundColumnType.DateTime;
        //                break;
        //        }
        //    }
        //    return baseRow;
        //}


        private void PoliceListesiGetir(AktifPoliceRapor raporSure, PoliceRaporTipi raporTipi)
        {
            var policelerim = Session.PoliceService.GetAll();
            var RaporPoliceleri=policelerim;
            switch (raporSure)
            {
                case AktifPoliceRapor.Son15:
                    RaporPoliceleri = policelerim.Where(t => t.PoliceBitisTarih >= DateTime.Now).
                        Where(t => t.PoliceBitisTarih <= DateTime.Now.AddDays(15)).ToList();
                    break;
                case AktifPoliceRapor.Son7:
                    RaporPoliceleri = policelerim.Where(t => t.PoliceBitisTarih >= DateTime.Now).
                        Where(t => t.PoliceBitisTarih <= DateTime.Now.AddDays(7)).ToList();
                    break;
                case AktifPoliceRapor.GelecekAy:
                    RaporPoliceleri = policelerim.Where(t => t.PoliceBitisTarih >= Policem.Core.Extensions.ExtensionMethods.AyinBaslangici(DateTime.Now.AddMonths(1))).
                        Where(t => t.PoliceBitisTarih <= Policem.Core.Extensions.ExtensionMethods.AyinBitisi(DateTime.Now.AddMonths(1))).ToList();
                    break;
                case AktifPoliceRapor.SonAy:
                    RaporPoliceleri = policelerim.Where(t => t.PoliceBitisTarih >= Policem.Core.Extensions.ExtensionMethods.AyinBaslangici(DateTime.Now)).
                        Where(t => t.PoliceBitisTarih <= Policem.Core.Extensions.ExtensionMethods.AyinBitisi(DateTime.Now)).ToList();
                    break;
                default:
                    RaporPoliceleri = policelerim.Where(t => t.PoliceBitisTarih >DateTime.Now ).ToList();
                    break;

            }
            switch(raporTipi)
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
                    RaporPoliceleri = RaporPoliceleri.Where(t => t.PoliceTuru == PoliceTuru.Muayene||t.PoliceTuru==PoliceTuru.Egsoz).ToList();
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
            gridControlPoliceler.DataSource = a.OrderBy(t => t.PoliceBitisTarih).ToList();
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
            //NumberFormatInfo nf = new NumberFormatInfo() { CurrencySymbol = "TL" };
            gridViewPoliceler.Columns["Tutar"].DisplayFormat.Format = new FormatPara("TL");
            gridViewPoliceler.Columns["Tutar"].DisplayFormat.FormatString = "{0:#,###.##}";
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
            //gridViewPoliceler.GroupedColumns();
        }

        private void FrmPoliceler_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F5)
            //{
            //    ShowDockPanel("PoliceArama");
            //}
        }
        //public void ShowDockPanel(string caption)
        //{
        //    DockPanel dpFound = null;
        //    foreach (DockPanel dp in dockManager.Panels)
        //    {
        //        if (dp.Name == caption)
        //        {
        //            dpFound = dp;
        //            break;
        //        }
        //    }
        //    dpFound.Visibility = DockVisibility.Visible;
        //    dpFound.Show();
        //}

        private void CmbRaporSure_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                PoliceListesiGetir((AktifPoliceRapor)CmbRaporSure.EditValue, (PoliceRaporTipi)CmbRaporTip.EditValue);
                
            }
            catch { }
        }
        public void ToplamHesapla()
        {
            NumberFormatInfo nf = new NumberFormatInfo() { CurrencySymbol = "TL" };
            gridViewPoliceler.OptionsView.ShowFooter = true;
            //gridViewPoliceler.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
            GridGroupSummaryItem item = new GridGroupSummaryItem
            {
                FieldName = "Tutar",
                ShowInGroupColumnFooter = gridViewPoliceler.Columns["Tutar"],
                SummaryType = DevExpress.Data.SummaryItemType.Sum,
                Format =new FormatPara("TL"),
                DisplayFormat = "{0:#,###.##}"
            };
            //item.DisplayFormat = "{ 0:#,##0} TL";
            gridViewPoliceler.GroupSummary.Add(item);
                       
            gridViewPoliceler.Columns["Tutar"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridViewPoliceler.Columns["Tutar"].SummaryItem.Format = new FormatPara("TL");
            gridViewPoliceler.Columns["Tutar"].SummaryItem.DisplayFormat = "{0:#,###.##}";

        }

        private void BtnExcell_Click(object sender, EventArgs e)
        {
            gridViewPoliceler.BestFitColumns();
            gridViewPoliceler.OptionsPrint.ShowPrintExportProgress = false;
            PrintingSystem printingSystem1 = new PrintingSystem();
            PrintableComponentLink printableComponentLink1 = new PrintableComponentLink();

            printingSystem1.Links.AddRange(new object[] { printableComponentLink1 });
            ((GridView)gridControlPoliceler.MainView).ClearDocument();
            printableComponentLink1.Component = gridControlPoliceler;
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
            //gridControlPoliceler.ExportToXlsx(path+"\\Aktif Policeler.xlsx");
            //if (MessageBox.Show("Aktarılan dosyayı şimdi görmek ister misiniz?", "Excel dosyası", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    //Kaydedilen Excel Dosyasını açar.

            //    System.Diagnostics.Process.Start(path + "\\Aktif Policeler.xlsx");
            //}
        }

        private void FrmPoliceler_Shown(object sender, EventArgs e)
        {
            gridViewPoliceler.Columns["Name"].GroupIndex = 0;
            ToplamHesapla();
            gridViewPoliceler.BestFitColumns();
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
        public int seciliSatir = 999999999; // 999999999 olmasının sebebi herhangi bir çakışmayı engelleme amaçlıdır.

        private void GridViewPoliceler_RowClick(object sender, RowClickEventArgs e)
        {
            gridViewPoliceler.SelectRow(gridViewPoliceler.FocusedRowHandle); // gridview'de tıklanan satırı seçmek için
            gridViewPoliceler.ShowEditor(); // seçimi göstermek için
            gridViewPoliceler.Appearance.FocusedCell.BackColor = Color.Transparent; // Tıklanan hücrenin arkaplanını transparan yapmak için
            if (seciliSatir == gridViewPoliceler.FocusedRowHandle) // bir önceki tıklanan satır ile şimdi tıklanan satır aynı mı diye kontrol ediyor
            {
                seciliSatir = 999999999; // Tıklamayı sıfırlamak için tekrar başlangıç değerine dönüyoruz.
                // Çift tıklandığında yapılacak işlemler yazılacak..
                BtnPoliceAc_Click(sender,e);
            }
            else { seciliSatir = gridViewPoliceler.FocusedRowHandle; }  // aynı değlse son tıklananı alıyor. 
        }
    }
}
