using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using Policem.Core.Utility;
using Policem.Data.Enums;
using Policem.Services.DependencyResolution;
using Quartz;

namespace Policem.Services
{
    public class Son15GunBitecekPoliceler : IJob
    {
        public FormGelmeyenPoliceler form;
        public Task Execute(IJobExecutionContext context)
        {
            // Yapılacak İşler Buraya 
            form = new FormGelmeyenPoliceler();
            form.gridViewPoliceler.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(GridViewPoliceler_RowCellStyle);
            form.Show();
            form.WindowState = FormWindowState.Minimized;
            form.ShowInTaskbar = false;
            RaporOlustur();
            return Task.CompletedTask;
        }

        private void RaporOlustur()
        {
            var policelerim = Session.PoliceService.GetAll().Where(t => t.Yenilendimi == 0).ToList(); 
            var RaporPoliceleri = policelerim;//.Where(t => t.Yenilendimi == 0).ToList(); ;
            RaporPoliceleri = policelerim.Where(t => t.PoliceBitisTarih > DateTime.Now).
                Where(t=>t.PoliceBitisTarih<DateTime.Now.AddDays(15)).ToList();
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
            form.gridControlPoliceler.DataSource = null;
            form.gridControlPoliceler.DataSource = a.OrderBy(t => t.PoliceBitisTarih).ToList();
            GridDüzenle();
            form.gridViewPoliceler.Columns["Unvan"].GroupIndex = 0;
            ToplamHesapla();
            DosyayaKaydet();
            //Mail Gönderme yap
            if (a.Count() > 0)
                MailGonder(Session.MailGonderilecekAdresler);
            //form Kapatılıyor...
            form.Close();
        }
        private void ToplamHesapla()
        {
            form.gridViewPoliceler.OptionsView.ShowFooter = true;
            GridGroupSummaryItem item = new GridGroupSummaryItem
            {
                FieldName = "Tutar",
                ShowInGroupColumnFooter = form.gridViewPoliceler.Columns["Tutar"],
                SummaryType = DevExpress.Data.SummaryItemType.Sum,
                Format = new FormatPara("TL")
            };
            form.gridViewPoliceler.GroupSummary.Add(item);
            form.gridViewPoliceler.Columns["Tutar"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            form.gridViewPoliceler.Columns["Tutar"].DisplayFormat.Format = new FormatPara("TL");
            form.gridViewPoliceler.Columns["Tutar"].SummaryItem.DisplayFormat = "{0:#,###.##} TL";
            form.gridViewPoliceler.BestFitColumns();
        }
        private void GridDüzenle()
        {
            form.gridViewPoliceler.Columns["PoliceTuru"].Caption = "Poliçe Tipi";
            form.gridViewPoliceler.Columns["PoliceTuru"].AppearanceCell.TextOptions.RightToLeft = true;
            form.gridViewPoliceler.Columns["PoliceNo"].Caption = "Poliçenin Numarası";
            form.gridViewPoliceler.Columns["PoliceBaslangicTarih"].Caption = "Başlangıç Tarihi";
            form.gridViewPoliceler.Columns["PoliceBitisTarih"].Caption = "Bitiş Tarihi";
            form.gridViewPoliceler.Columns["Policelenen"].Caption = "Neyin Poliçelendiği";
            form.gridViewPoliceler.Columns["Tutar"].Caption = "Tutar";
            form.gridViewPoliceler.Columns["Tutar"].AppearanceCell.TextOptions.RightToLeft = true;
            form.gridViewPoliceler.Columns["Tutar"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            form.gridViewPoliceler.Columns["Tutar"].DisplayFormat.Format = new FormatPara("TL");
            form.gridViewPoliceler.Columns["Tutar"].DisplayFormat.FormatString = "#.###,## TL";
            form.gridViewPoliceler.Columns["PoliceGeldimi"].Caption = "Poliçe Basıldı";
            form.gridViewPoliceler.Columns["PoliceGeldimi"].AppearanceCell.TextOptions.RightToLeft = true;
            form.gridViewPoliceler.Columns["Unvan"].Caption = "Sigorta Firması";
            form.gridViewPoliceler.Columns["Name"].Caption = "Poliçe Sahibi";
            form.gridViewPoliceler.ViewCaption = "Gelmeyen Poliçeler";
            form.gridViewPoliceler.ExpandAllGroups();
            form.gridViewPoliceler.BestFitColumns();
        }
        private void DosyayaKaydet()
        {
            form.gridViewPoliceler.OptionsPrint.ShowPrintExportProgress = false;
            PrintingSystem printingSystem1 = new PrintingSystem();
            PrintableComponentLink printableComponentLink1 = new PrintableComponentLink();
            printingSystem1.Links.AddRange(new object[] { printableComponentLink1 });
            ((GridView)form.gridControlPoliceler.MainView).ClearDocument();
            printableComponentLink1.Component = form.gridControlPoliceler;
            printableComponentLink1.Landscape = true;
            printableComponentLink1.Margins = new Margins(1, 1, 10, 10);
            printableComponentLink1.ExportToXlsx(Session.TempDosyaYolu + "\\15 Gun içinde Bitecek Policeler.xlsx");
            printableComponentLink1.ExportToHtml(Session.TempDosyaYolu + "\\15 Gun içinde Bitecek Policeler.html");
        }
        private void GridViewPoliceler_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView currentView = sender as GridView;
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
        private static void MailGonder(string mailAdresleri)
        {
            MailMessage ePosta = new MailMessage();
            if (Session.SmptService.Kullanici)
                ePosta.From = new MailAddress(Session.SmptService.KullaniciAdi);
            else
                ePosta.From = new MailAddress("PoliceTakip@PoliceSistem.com");
            string str = mailAdresleri;
            char[] chArray = new char[1] { ';' };
            foreach (string index in str.Split(chArray))
            {
                try
                {
                    ePosta.To.Add(index);
                }
                catch
                {
                }
            }
            ePosta.Subject = "15 Gün içinde Bitecek Poliçeler";
            ePosta.IsBodyHtml = true;
            var icerik = File.ReadAllText(Session.TempDosyaYolu + "\\15 Gun içinde Bitecek Policeler.html"); ;
            ePosta.Body = icerik;
            ePosta.Attachments.Add(new Attachment(Session.TempDosyaYolu + "\\15 Gun içinde Bitecek Policeler.xlsx"));
            SmtpClient smtp = new SmtpClient();
            if (Session.SmptService.Kullanici)
                smtp.Credentials = new System.Net.NetworkCredential(Session.SmptService.KullaniciAdi, Session.SmptService.Sifre);
            smtp.Port = Session.SmptService.Port;
            smtp.Host = Session.SmptService.Host;
            smtp.EnableSsl = Session.SmptService.SSL;
            smtp.Send(ePosta);
        }

    }
}
//saniye dakika saat ayın günü ay haftanın günü yıl

//Yıl girilmesi Zorunlu değildir
//ifade anlam
//0 0 12 **? Her gün saat 12'de (öğlen) ateş edin
//0 15 10?* Her gün saat 10: 15'te ateş edin
//0 15 10 **? Her gün saat 10: 15'te ateş edin
//0 15 10 **?* Her gün saat 10: 15'te ateş edin
//0 15 10 **?	2005 2005’te her gün saat 10: 15’de ateş
//0 * 14 **? Her gün saat 14: 00'ten başlayıp her gün saat 14: 59'da sona erer.
//0 0/5 14 **? Her 5 dakikada bir 2 de başlayıp her gün 14:55 de biter.
//0 0/5 14,18 * *?	Her 5 dakikada bir 2 de başlayıp 2: 55'te biter ve her 5 dakikada bir, 6'dan başlayıp her gün 6: 55'te biter.
//0 0-5 14 * *?	Her dakika saat 14: 00'ten başlayıp her gün saat 14: 00'te biter.
//0 10,44 14? 3 WED Mart ayında her çarşamba saat 14:10 ve 14:44 saatlerinde ateş edin.
//0 15 10? * MON-FRI Her pazartesi, salı, çarşamba, perşembe ve cuma günü saat 10: 15'te ateş
//0 15 10 15 *?	Her ayın 15'inde saat 10: 15'te ateş edin
//0 15 10 L*?	Her ayın son günü saat 10: 15'te ateş edin
//0 15 10 L-2 *?	Her ayın ikinci sonuncu günü saat 10: 15'te ateş edin
//0 15 10? * 6L	Her ayın son cuma günü saat 10: 15'te ateş edin
//0 15 10? * 6L	Her ayın son cuma günü saat 10: 15'te ateş edin
//0 15 10? * 6L 2002-2005	2002, 2003, 2004 ve 2005 yıllarında her ayın son cuma günü saat 10: 15'te ateş
//0 15 10? * 6 # 3	Her ayın üçüncü cuma günü saat 10: 15'te ateş
//0 0 12 1/5 *?	Her ayın 5 günü (öğlen) saatte, ayın ilk günü başlayarak.
//0 11 11 11 11?	11 Kasım saat 11: 11'de ateş ediyorum.