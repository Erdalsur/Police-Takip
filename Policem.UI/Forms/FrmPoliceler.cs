using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using Policem.Core.Extensions;
using Policem.Core.Utility;
using Policem.Data;
using Policem.Data.Enums;
using Policem.UI.Core;
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
            gvPoliceler.ViewCaption = "Aktif Poliçeler";
            gvPoliceler.OptionsView.ShowViewCaption = false;
            GridManager manager2 = GridManager.GetManager(this.gvPoliceler);
            manager2.GridMenu.AddMenu("Aç", new EventHandler(BtnPoliceAc_Click));
            manager2.GridMenu.AddMenu("Yeni Poliçe Ekle", new EventHandler(BtnYeniPolice_Click));
            manager2.GridMenu.AddMenu("Police Sil", new EventHandler(BtnPoliceSil_Click), (Image)Resources.Delete_16x16);
            manager2.GridMenu.AddMenu("Seçili Poliçeyi Yenile", new EventHandler(BtnPoliceYenileme_Click), (Image)Resources.refresh);
            manager2.GridMenu.AddMenu("Outlook Takvimini Oluştur", new EventHandler(BtnTakvimOlustur_Click), (Image)Resources.Calendar);
            InitGridView(gvPoliceler);
        }

        private void BtnPoliceAc_Click(object sender, EventArgs e)
        {
            var handle = this.gvPoliceler.GetSelectedRows()[0];
            // handle 0 küçük ise group seçili
            if (handle >= 0)
                PoliceBilgileriAc();
        }

        private void BtnYeniPolice_Click(object sender, EventArgs e)
        {
            var handle = this.gvPoliceler.GetSelectedRows()[0];
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
            var handle = this.gvPoliceler.GetSelectedRows()[0];
            // handle 0 küçük ise group seçili
            if (handle >= 0)
            {
                Police eskiPolice = Session.PoliceService.GetById(Convert.ToInt32(gvPoliceler.GetRowCellValue(handle, "PoliceId"))); ;
                eskiPolice.Firma = Session.FirmaService.GetById(eskiPolice.FirmaId);
                eskiPolice.Sigortaci = Session.SigortaciService.GetById(eskiPolice.SigortaciId);
                if (eskiPolice.Yenilendimi == 1)
                {
                    XtraMessageBox.Show("Bu Poliçe Daha önceden yenilenmiş işlem yapamazsınız.", "Uyarı");
                    return;
                }
                Police yeniPolice = new Police
                {
                    Firma = eskiPolice.Firma,
                    FirmaId = eskiPolice.FirmaId,
                    Sigortaci = eskiPolice.Sigortaci,
                    SigortaciId = eskiPolice.SigortaciId,
                    PoliceBaslangicTarih = eskiPolice.PoliceBaslangicTarih,
                    PoliceBitisTarih = eskiPolice.PoliceBitisTarih,//.AddYears(1),
                    OncekiTutar = eskiPolice.Tutar,
                    Policelenen = eskiPolice.Policelenen,
                    PoliceNo = eskiPolice.PoliceNo,
                    PoliceTuru = eskiPolice.PoliceTuru,
                    Aciklama=eskiPolice.Aciklama
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
            string MailAdresi = AppSession.Settings.OutlookMailAdresi;
            int KacGunOncesi = AppSession.Settings.MuayeneTakvimHatirlatici * (-1);
            var gönderilecekPolice = SeciliPolice;
            OutlookTakvim.CreateMeetingRequest(MailAdresi, gönderilecekPolice.Policelenen + " - " + gönderilecekPolice.PoliceBitisTarih.ToLongDateString(),
                "Hatırlacı Takvim Sistemi Üzerinden \n" +
                "Bir önceki Tutarı = " + gönderilecekPolice.Tutar +
                "\n" + gönderilecekPolice.Aciklama,
                Convert.ToDateTime(gönderilecekPolice.PoliceBitisTarih.AddDays(KacGunOncesi)), Convert.ToDateTime(gönderilecekPolice.PoliceBitisTarih));
            AppSession.MainForm.NotifyMain(gönderilecekPolice.Policelenen + " için Outlook Takvim Bilgisi Gönderildi.");
        }
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
                        Where(t => t.PoliceBitisTarih <= DateTime.Now.AddDays(15)).Where(ay => ay.Yenilendimi == 0).ToList();
                    break;
                case AktifPoliceRapor.Son7:
                    RaporPoliceleri = policelerim.Where(t => t.PoliceBitisTarih >= DateTime.Now).
                        Where(t => t.PoliceBitisTarih <= DateTime.Now.AddDays(7)).Where(ay => ay.Yenilendimi == 0).ToList();
                    break;
                case AktifPoliceRapor.GelecekAy:
                    RaporPoliceleri = policelerim.Where(t => t.PoliceBitisTarih >= ExtensionMethods.AyinBaslangici(DateTime.Now.AddMonths(1))).
                        Where(t => t.PoliceBitisTarih <= ExtensionMethods.AyinBitisi(DateTime.Now.AddMonths(1))).Where(ay => ay.Yenilendimi == 0).ToList();
                    break;
                case AktifPoliceRapor.SonAy:
                    RaporPoliceleri = policelerim.Where(t => t.PoliceBitisTarih >= ExtensionMethods.AyinBaslangici(DateTime.Now)).
                        Where(t => t.PoliceBitisTarih <= ExtensionMethods.AyinBitisi(DateTime.Now)).Where(ay => ay.Yenilendimi == 0).ToList();
                    break;
                default:
                    RaporPoliceleri = policelerim.Where(t => t.PoliceBitisTarih >DateTime.Now ).Where(ay => ay.Yenilendimi == 0).ToList();
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
            gcPoliceler.DataSource = null;
            gcPoliceler.DataSource = a.OrderBy(t => t.PoliceBitisTarih).ToList();
            if (gvPoliceler.RowCount > 0)
                gcPoliceler.ContextMenuStrip = null;
            else
                gcPoliceler.ContextMenuStrip = contextMenuStrip2;
            GridDüzenle();
        }

        private void GridDüzenle()
        {            
            UIGridUtility.GridAlanGizle(gvPoliceler, "PoliceId;FirmaId;SigortaciId");
            gvPoliceler.Columns["PoliceId"].Caption = "Referans No";
            gvPoliceler.Columns["FirmaId"].Caption = "Müşteri Referans No";
            gvPoliceler.Columns["SigortaciId"].Caption = "Sigortaci Referans No";
            gvPoliceler.Columns["PoliceTuru"].Caption = "Poliçe Tipi";
            gvPoliceler.Columns["PoliceTuru"].ColumnEdit = GetCustomPoliceTipi();
            gvPoliceler.Columns["PoliceTuru"].AppearanceCell.TextOptions.RightToLeft = true;
            gvPoliceler.Columns["PoliceNo"].Caption = "Poliçenin Numarası";
            gvPoliceler.Columns["PoliceBaslangicTarih"].Caption = "Başlangıç Tarihi";
            gvPoliceler.Columns["PoliceBitisTarih"].Caption = "Bitiş Tarihi";
            gvPoliceler.Columns["Policelenen"].Caption = "Neyin Poliçelendiği";
            gvPoliceler.Columns["Aciklama"].Caption = "Açıklama";
            gvPoliceler.Columns["Tutar"].Caption = "Tutar";
            gvPoliceler.Columns["Tutar"].AppearanceCell.TextOptions.RightToLeft = true;
            gvPoliceler.Columns["Tutar"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            //NumberFormatInfo nf = new NumberFormatInfo() { CurrencySymbol = "TL" };
            gvPoliceler.Columns["Tutar"].DisplayFormat.Format = new FormatPara("TL");
            gvPoliceler.Columns["Tutar"].DisplayFormat.FormatString = "{0:#,###.##}";
            gvPoliceler.Columns["ArtisYuzdesi"].Caption = "Artış Oranı";
            gvPoliceler.Columns["ArtisYuzdesi"].AppearanceCell.TextOptions.RightToLeft = true;
            gvPoliceler.Columns["ArtisYuzdesi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gvPoliceler.Columns["ArtisYuzdesi"].DisplayFormat.Format = new FormatYuzde();
            gvPoliceler.Columns["PoliceGeldimi"].Caption = "Poliçe Basıldı";
            gvPoliceler.Columns["PoliceGeldimi"].AppearanceCell.TextOptions.RightToLeft = true;
            gvPoliceler.Columns["Unvan"].Caption = "Sigorta Firması";
            gvPoliceler.Columns["Name"].Caption = "Poliçe Sahibi";
            
            gvPoliceler.ExpandAllGroups();
            gvPoliceler.BestFitColumns();
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
            gvPoliceler.OptionsView.ShowFooter = true;
            //gridViewPoliceler.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
            GridGroupSummaryItem item = new GridGroupSummaryItem
            {
                FieldName = "Tutar",
                ShowInGroupColumnFooter = gvPoliceler.Columns["Tutar"],
                SummaryType = DevExpress.Data.SummaryItemType.Sum,
                Format =new FormatPara("TL"),
                DisplayFormat = "{0:#,###.##}"
            };
            //item.DisplayFormat = "{ 0:#,##0} TL";
            gvPoliceler.GroupSummary.Add(item);
                       
            gvPoliceler.Columns["Tutar"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gvPoliceler.Columns["Tutar"].SummaryItem.Format = new FormatPara("TL");
            gvPoliceler.Columns["Tutar"].SummaryItem.DisplayFormat = "{0:#,###.##}";

        }

        private void BtnExcell_Click(object sender, EventArgs e)
        {
            gvPoliceler.BestFitColumns();
            gvPoliceler.OptionsPrint.ShowPrintExportProgress = false;
            PrintingSystem printingSystem1 = new PrintingSystem();
            PrintableComponentLink printableComponentLink1 = new PrintableComponentLink();

            printingSystem1.Links.AddRange(new object[] { printableComponentLink1 });
            ((GridView)gcPoliceler.MainView).ClearDocument();
            printableComponentLink1.Component = gcPoliceler;
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
            gvPoliceler.Columns["Name"].GroupIndex = 0;
            ToplamHesapla();
            gvPoliceler.BestFitColumns();
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
                var handle = this.gvPoliceler.GetSelectedRows()[0];
                SeciliPolice = Session.PoliceService.GetById(Convert.ToInt32(gvPoliceler.GetRowCellValue(handle, "PoliceId")));
                SeciliPoliceDosyaBul();
            }
            catch
            {
                SeciliPolice = null;
            }
        }
        public int seciliSatir = 999999999; // 999999999 olmasının sebebi herhangi bir çakışmayı engelleme amaçlıdır.

        private void GridViewPoliceler_RowClick(object sender, RowClickEventArgs e)
        {
            gvPoliceler.SelectRow(gvPoliceler.FocusedRowHandle); // gridview'de tıklanan satırı seçmek için
            gvPoliceler.ShowEditor(); // seçimi göstermek için
            gvPoliceler.Appearance.FocusedCell.BackColor = Color.Transparent; // Tıklanan hücrenin arkaplanını transparan yapmak için
            if (seciliSatir == gvPoliceler.FocusedRowHandle) // bir önceki tıklanan satır ile şimdi tıklanan satır aynı mı diye kontrol ediyor
            {
                seciliSatir = 999999999; // Tıklamayı sıfırlamak için tekrar başlangıç değerine dönüyoruz.
                // Çift tıklandığında yapılacak işlemler yazılacak..
                BtnPoliceAc_Click(sender,e);
            }
            else { seciliSatir = gvPoliceler.FocusedRowHandle; }  // aynı değlse son tıklananı alıyor. 
        }

        private void SeciliPoliceDosyaBul()
        {
            var policedosyalar = Session.PoliceDosyaService.GetPoliceById(SeciliPolice.PoliceId);
            if (policedosyalar.Count > 0)
            {
                pdfViewer1.DetachStreamAfterLoadComplete = true;
                using (MemoryStream ms = new MemoryStream(policedosyalar.FirstOrDefault().Dosya))
                    pdfViewer1.LoadDocument(ms);
            }
            else
            {
                pdfViewer1.CloseDocument();
            }
        }
    }
}
