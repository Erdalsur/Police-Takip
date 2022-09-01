using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using Policem.Core.Extensions;
using Policem.Core.Utility;
using Policem.Data;
using Policem.Data.Enums;
using Policem.UI.DependencyResolution;
using Policem.UI.Forms.Base;

namespace Policem.UI.Forms
{
    public partial class FrmPolicelerYeni : XForm
    {
        private Police SeciliPolice = null;

        public FrmPolicelerYeni()
        {
            InitializeComponent();
        }

        private void FrmPolicelerYeni_Load(object sender, EventArgs e)
        {
            var policelerim = Session.PoliceService.GetAll().Where(t => t.Yenilendimi == 0).ToList();
            var RaporPoliceleri = policelerim;//.Where(t => t.Yenilendimi == 0).ToList(); 
            RaporPoliceleri = policelerim.Where(t => t.PoliceBitisTarih > DateTime.Now).
                Where(t => t.PoliceBitisTarih < DateTime.Now.AddDays(15)).ToList();
            var a = from Policem in RaporPoliceleri.ToList()
                    orderby Policem.PoliceBitisTarih descending
                    join Sigortaci in Session.SigortaciService.GetAll() on Policem.SigortaciId equals Sigortaci.SigortaciId
                    join Musteri in Session.FirmaService.GetAll() on Policem.FirmaId equals Musteri.FirmaId

                    select new
                    {
                        Musteri.Name,
                        Policem.PoliceTuru,
                        Policem.PoliceNo,
                        Policem.Policelenen,
                        Policem.Tutar,
                        Policem.PoliceBaslangicTarih,
                        Policem.PoliceBitisTarih,
                        Policem.PoliceGeldimi,
                        Sigortaci.Unvan
                    };
            gcPoliceler.DataSource = null;
            gcPoliceler.DataSource = a;
            //var son30gün = DateTime.Now.AddDays(-30);
            //gcPoliceler.DataSource = a.Where(ay => ay.PoliceBitisTarih > son30gün).OrderBy(t => t.PoliceBaslangicTarih).ToList();
            //EnumToLists();
            //gvPoliceler.ViewCaption = "Aktif Poliçeler";
            //gvPoliceler.OptionsView.ShowViewCaption = false;
            //GridManager manager2 = GridManager.GetManager(this.gvPoliceler);
            //manager2.GridMenu.AddMenu("Aç", new EventHandler(BtnPoliceAc_Click));
            ////manager2.GridMenu.AddMenu("Yeni Poliçe Ekle", new EventHandler(BtnYeniPolice_Click));
            ////manager2.GridMenu.AddMenu("Police Sil", new EventHandler(BtnPoliceSil_Click), (Image)Resources.Delete_16x16);
            ////manager2.GridMenu.AddMenu("Seçili Poliçeyi Yenile", new EventHandler(BtnPoliceYenileme_Click), (Image)Resources.refresh);
            ////manager2.GridMenu.AddMenu("Outlook Takvimini Oluştur", new EventHandler(BtnTakvimOlustur_Click), (Image)Resources.Calendar);
            //InitGridView(gvPoliceler);
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

        private void BtnPoliceAc_Click(object sender, EventArgs e)
        {
            var handle = this.gvPoliceler.GetSelectedRows()[0];
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
                PoliceListesiGetir((AktifPoliceRapor)CmbRaporSure.EditValue, (PoliceRaporTipi)CmbRaporTip.EditValue);
        }

        private void PoliceListesiGetir(AktifPoliceRapor raporSure, PoliceRaporTipi raporTipi)
        {
            var policelerim = Session.PoliceService.GetAll();
            var RaporPoliceleri = policelerim;
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
                    RaporPoliceleri = policelerim.Where(t => t.PoliceBitisTarih > DateTime.Now).Where(ay => ay.Yenilendimi == 0).ToList();
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

        private void CmbRaporSure_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                PoliceListesiGetir((AktifPoliceRapor)CmbRaporSure.EditValue, (PoliceRaporTipi)CmbRaporTip.EditValue);

            }
            catch { }
        }

        private void btnExcell_Click(object sender, EventArgs e)
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
            printableComponentLink1.ExportToXlsx(filePath + "\\Aktif Policeler.xlsx");


            using (Process pr = new Process())
            {
                pr.StartInfo = new ProcessStartInfo(filePath + "\\Aktif Policeler.xlsx");
                pr.Start();
            }
        }
    }
}
