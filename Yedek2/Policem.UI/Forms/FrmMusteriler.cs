using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using Policem.Core.Utility;
using Policem.Data;
using Policem.Data.Enums;
using Policem.UI.DependencyResolution;
using Policem.UI.Forms.Base;
using Policem.UI.Properties;

namespace Policem.UI.Forms
{
    public partial class FrmMusteriler : XForm
    {
        private Firma SeciliMusteri = null;
        private Police SeciliPolice = null;
        public FrmMusteriler()
        {
            InitializeComponent();
            SplashScreenManager.ShowForm(typeof(WaitForm1));
        }

        private void FrmMusteriler_Load(object sender, EventArgs e)
        {            
            lblUnvan.Text = string.Empty;
            MusteriListesi();
            gridViewMusteriler.Focus();
            GridManager manager = GridManager.GetManager(this.gridViewMusteriler);
            manager.GridMenu.AddMenu("Aç", new EventHandler(BtnAc_Click));
            manager.GridMenu.AddMenu("Yeni Poliçe Ekle", new EventHandler(BtnYeniPolice_Click));
            manager.GridMenu.AddMenu("Yeni Müşteri Ekle", new EventHandler(BtnYeniMusteri_Click));
            //manager.GridMenu.AddMenu("Alınan Poliçeler", new EventHandler(BtnPoliceleri_Click));
            manager.GridMenu.AddMenu("Sil", new EventHandler(BtnMusteriSil_Click), (Image)Resources.Delete_16x16);
            GridManager manager2 = GridManager.GetManager(this.gridViewPoliceler);
            manager2.GridMenu.AddMenu("Aç", new EventHandler(BtnPoliceAc_Click));
            manager2.GridMenu.AddMenu("Yeni Poliçe Ekle", new EventHandler(BtnYeniPolice_Click));
            manager2.GridMenu.AddMenu("Police Sil", new EventHandler(BtnPoliceSil_Click), (Image)Resources.Delete_16x16);
            manager2.GridMenu.AddMenu("Seçili Poliçeyi Yenile", new EventHandler(BtnPoliceYenileme_Click), (Image)Resources.refresh);
            manager2.GridMenu.AddMenu("Outlook Takvimini Oluştur", new EventHandler(BtnTakvimOlustur_Click), (Image)Resources.Calendar);
        }

        private void BtnTakvimOlustur_Click(object sender, EventArgs e)
        {
            string MailAdresi = AppSession.Settings.OutlookMailAdresi;
            int KacGunOncesi = AppSession.Settings.MuayeneTakvimHatirlatici*(-1);
            CreateMeetingRequest(MailAdresi, SeciliPolice.Policelenen+" - "+SeciliPolice.PoliceBitisTarih.ToLongDateString(),
                "Hatırlacı Takvim Sistemi Üzerinden \n" +
                "Bir önceki Tutarı = "+ SeciliPolice.Tutar+
                "\n"+SeciliPolice.Aciklama, 
                Convert.ToDateTime(SeciliPolice.PoliceBitisTarih.AddDays(KacGunOncesi)), Convert.ToDateTime(SeciliPolice.PoliceBitisTarih));
            AppSession.MainForm.NotifyMain(SeciliPolice.Policelenen+" için Outlook Takvim Bilgisi Gönderildi.");
        }

        public static void CreateMeetingRequest(string toEmail, string subject, string body, DateTime startDate, DateTime endDate)
        {
            try
            {
                Microsoft.Office.Interop.Outlook.Application objOL = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook.AppointmentItem objAppt = (Microsoft.Office.Interop.Outlook.AppointmentItem)objOL.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olAppointmentItem);
                objAppt.Start = startDate;
                objAppt.End = endDate;
                objAppt.AllDayEvent = true;
                objAppt.Subject = subject;
                objAppt.Body = body;
                objAppt.MeetingStatus = Microsoft.Office.Interop.Outlook.OlMeetingStatus.olMeeting;
                objAppt.RequiredAttendees = toEmail;
                objAppt.Send();
                objAppt = null;
                objOL = null;
            }
            catch { AppSession.MainForm.NotifyMain("Outlook Takvimi Oluşturulurken Hata Oluştu."); }
        }
        private void MusteriListesi()
        {
            List<Firma> Musteriler = Session.FirmaService.GetAll();

            //dataSetSigortacilar2 = dataSetSigortacilar = Liste.ConvertGenericList("Sigortacilar");
            //gridSigortacilar.DataSource = dataSetSigortacilar.Tables["Sigortacilar"];
            gridControlMusteriler.DataSource = Musteriler;
            var handle = this.gridViewMusteriler.GetSelectedRows()[0];
            Firma policeMusteri = Session.FirmaService.GetById(Convert.ToInt32(gridViewMusteriler.GetRowCellValue(handle, "FirmaId")));
            //List<Police> Police = Session2.PoliceService.GetMusteriPoliceleri(policeMusteri);
            policeMusteri.Policeler = Session.PoliceService.GetMusteriPoliceleri(policeMusteri);

            var policeleri = policeMusteri.Policeler.Where(t => t.PoliceBitisTarih > DateTime.Now).ToList();
            var a = from pol in policeleri orderby pol.PoliceBitisTarih descending
                    join sig in Session.SigortaciService.GetAll() on pol.SigortaciId equals sig.SigortaciId
                    select new
                    {
                        pol.PoliceId,
                        pol.PoliceTuru,
                        pol.PoliceNo,
                        pol.Policelenen,
                        pol.Tutar,
                        pol.ArtisYuzdesi,
                        pol.PoliceBaslangicTarih,
                        pol.PoliceBitisTarih,
                        pol.PoliceGeldimi,
                        sig.Unvan,
                        pol.Aciklama

                    };
            gridControlPoliceler.DataSource= a.OrderBy(t => t.PoliceBitisTarih).ToList();
            //List<SigortaFirma> Liste = Session2.SigortaFirmaService.GetAll();
            //dataSetSigortacilar2 = Liste.ConvertGenericList("Sigortacilar");
            //dataSetSigortacilar.Merge(dataSetSigortacilar2,true,MissingSchemaAction.Add); 
            GridDüzenle();

        }
        private void GridDüzenle()
        {
            UIGridUtility.GridAlanGizle(this.gridViewMusteriler, "FirmaId;Name;Policeler");
            //Önce Alan Gizleme
            gridViewMusteriler.Columns["FirmaId"].Caption = "Referans No";
            gridViewMusteriler.Columns["Name"].Caption = "Adı";
            gridViewMusteriler.Columns["Kod"].Caption = "Kodu";
            gridViewMusteriler.Columns["Unvan"].Caption = "Müşteri Ünvanı";
            gridViewMusteriler.Columns["Yetkili"].Caption = "Yetkilisi";
            gridViewMusteriler.Columns["VKNO"].Caption = "Kimlik No";
            gridViewMusteriler.Columns["Policeler"].Caption = "Policeleri";
            gridViewMusteriler.BestFitColumns();
            //Poliçe grid düzeni
            GridDüzenlePolice();
        }
        private void GridDüzenlePolice()
        {
            UIGridUtility.GridAlanGizle(gridViewPoliceler, "PoliceId");
            gridViewPoliceler.Columns["PoliceId"].Caption = "Referans No";
            //gridPoliceler.Columns["Firma"].Visible = false;
            //gridPoliceler.Columns["Firma"].HeaderText = "Kime Ait";
            gridViewPoliceler.Columns["PoliceTuru"].Caption = "Poliçe Tipi";
            gridViewPoliceler.Columns["PoliceTuru"].AppearanceCell.TextOptions.RightToLeft = true;
            //gridPoliceler.Columns["Sigortaci"].HeaderText = "Sigorta Firması";
            gridViewPoliceler.Columns["PoliceNo"].Caption = "Poliçenin Numarası";
            gridViewPoliceler.Columns["PoliceBaslangicTarih"].Caption = "Başlangıç Tarihi";
            gridViewPoliceler.Columns["PoliceBitisTarih"].Caption = "Bitiş Tarihi";
            gridViewPoliceler.Columns["Policelenen"].Caption = "Neyin Poliçelendiği";
            gridViewPoliceler.Columns["Aciklama"].Caption = "Açıklama";
            //gridPoliceler.Columns["OdemeTuru"].HeaderText = "Ödeme Tipi";
            gridViewPoliceler.Columns["Tutar"].Caption = "Tutar";
            gridViewPoliceler.Columns["Tutar"].AppearanceCell.TextOptions.RightToLeft = true;
            gridViewPoliceler.Columns["Tutar"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            NumberFormatInfo nf = new NumberFormatInfo() { CurrencySymbol = "TL" };
            gridViewPoliceler.Columns["Tutar"].DisplayFormat.Format =nf;
            gridViewPoliceler.Columns["Tutar"].DisplayFormat.FormatString = "#.###,## TL";
            //gridPoliceler.Columns["OncekiTutar"].Visible = false;
            //gridPoliceler.Columns["OncekiTutar"].HeaderText = "Önceki Poliçe Tutarı";
            gridViewPoliceler.Columns["ArtisYuzdesi"].Caption = "Artış Oranı";
            gridViewPoliceler.Columns["ArtisYuzdesi"].AppearanceCell.TextOptions.RightToLeft = true;
            gridViewPoliceler.Columns["ArtisYuzdesi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridViewPoliceler.Columns["ArtisYuzdesi"].DisplayFormat.Format = new FormatYuzde();
            //gridPoliceler.Columns["Taksit"].Visible = false;
            //gridPoliceler.Columns["Taksit"].HeaderText = "Taksit Varmı";
            //gridPoliceler.Columns["TaksitSayisi"].Visible = false;
            //gridPoliceler.Columns["TaksitSayisi"].HeaderText = "Taksit Sayısı";
            //gridPoliceler.Columns["Yenilendimi"].Visible = false;
            //gridPoliceler.Columns["Yenilendimi"].HeaderText = "Yenilendimi";
            //gridPoliceler.Columns["YeniPoliceId"].Visible = false;
            //gridPoliceler.Columns["YeniPoliceId"].HeaderText = "Yeni Referans No";

            gridViewPoliceler.Columns["PoliceGeldimi"].Caption = "Poliçe Basıldı";
            gridViewPoliceler.Columns["PoliceGeldimi"].AppearanceCell.TextOptions.RightToLeft = true;
            gridViewPoliceler.Columns["Unvan"].Caption = "Sigorta Firması";
            gridViewPoliceler.BestFitColumns();
        }        
        private void BtnYeniMusteri_Click(object sender, EventArgs e)
        {
            MusteriBilgileriAc(false);
        }
        private void BtnYeniPolice_Click(object sender, EventArgs e)
        {
            PoliceBilgileriAc(false);
        }
        private void BtnAc_Click(object sender, EventArgs e)
        {
            MusteriBilgileriAc();
        }
        private void BtnPoliceAc_Click(object sender, EventArgs e)
        {
            PoliceBilgileriAc();
        }
        private void BtnMusteriSil_Click(object sender, EventArgs e)
        {
            //Hazırlanacak
            MessageBox.Show("Hazırlanıyor");
        }
        private void BilgiEkranıYaz()
        {
            var handle = this.gridViewMusteriler.GetSelectedRows()[0];
            SeciliMusteri = Session.FirmaService.GetById(Convert.ToInt32(gridViewMusteriler.GetRowCellValue(handle, "FirmaId")));
            lblUnvan.Text = SeciliMusteri.Unvan;
            
            List<Police> list = Session.PoliceService.GetMusteriPoliceleri(SeciliMusteri);
            var policeleri= list.Where(t=>t.PoliceBitisTarih>DateTime.Now).ToList();
            var a = from pol in policeleri
                    join sig in Session.SigortaciService.GetAll() on pol.SigortaciId equals sig.SigortaciId
                    select new
                    {
                        pol.PoliceId,
                        pol.PoliceTuru,
                        pol.PoliceNo,
                        pol.Policelenen,
                        pol.Tutar,
                        pol.ArtisYuzdesi,                        
                        pol.PoliceBaslangicTarih,
                        pol.PoliceBitisTarih,
                        pol.PoliceGeldimi,
                        sig.Unvan,pol.Aciklama
                        
                    };
            SeciliMusteri.Policeler = policeleri;
            var ToplamTutari = a.Sum(t => t.Tutar).ToString();
            lblUnvan.Text += " ait Toplam = " + String.Format("{0:C}", Convert.ToDouble(ToplamTutari))+" Poliçe Ödemesi Olmuş";
            gridControlPoliceler.DataSource = a.OrderBy(t => t.PoliceBitisTarih).ToList();//Police;
            GridDüzenlePolice();
            
        }
        private void BtnPoliceSil_Click(object sender, EventArgs e)
        {
            //Hazırlanacak
            MessageBox.Show("Hazırlanıyor");
        }
        private void FrmMusteriler_Shown(object sender, EventArgs e)
        {
            SplashScreenManager.CloseForm();
        }

        private void BtnPoliceYenileme_Click(object sender, EventArgs e)
        {
            var handle = this.gridViewPoliceler.GetSelectedRows()[0];
            // Var olan poliçeyi yenileme
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
            FrmPolice f = new FrmPolice(yeniPolice, true,true);
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                //eski policeye yeni police bilgilerini vereğiz.
                eskiPolice.Yenilendimi = 1;
                eskiPolice.YeniPoliceId=f.policem.PoliceId;
                Session.PoliceService.Update(eskiPolice);
                BilgiEkranıYaz();
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridViewMusteriler_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var handle = this.gridViewMusteriler.GetSelectedRows()[0];
            SeciliMusteri= Session.FirmaService.GetById(Convert.ToInt32(gridViewMusteriler.GetRowCellValue(handle, "FirmaId")));
            lblUnvan.Text = SeciliMusteri.Unvan;           
            List<Police> list = Session.PoliceService.GetMusteriPoliceleri(SeciliMusteri);
            var policeleri = list.Where(t => t.PoliceBitisTarih > DateTime.Now).ToList();
            var a = from pol in policeleri
                    join sig in Session.SigortaciService.GetAll() on pol.SigortaciId equals sig.SigortaciId
                    select new
                    {
                        pol.PoliceId,
                        pol.PoliceTuru,
                        pol.PoliceNo,
                        pol.Policelenen,
                        pol.Tutar,
                        pol.ArtisYuzdesi,
                        pol.PoliceBaslangicTarih,
                        pol.PoliceBitisTarih,
                        pol.PoliceGeldimi,
                        sig.Unvan,
                        pol.Aciklama

                    };
            SeciliMusteri.Policeler = policeleri;
            var ToplamTutari = a.Sum(t => t.Tutar).ToString();
            lblUnvan.Text += " ait Toplam = " + String.Format("{0:C}", Convert.ToDouble(ToplamTutari)) + " Poliçe Ödemesi Olmuş";
            gridControlPoliceler.DataSource = a.OrderBy(t => t.PoliceBitisTarih).ToList();//Police;
            //GridDüzenlePolice();
        }

        private void MusteriBilgileriAc(bool EskiMusteri=true)
        {
            FrmMusteri f;
            if (EskiMusteri)
                f = new FrmMusteri(SeciliMusteri);
            else
                f = new FrmMusteri();
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
                MusteriListesi();
        }
        public int seciliSatir = 999999999; // 999999999 olmasının sebebi herhangi bir çakışmayı engelleme amaçlıdır.

        private void GridViewMusteriler_RowClick(object sender, RowClickEventArgs e)
        {
            gridViewMusteriler.SelectRow(gridViewMusteriler.FocusedRowHandle); // gridview'de tıklanan satırı seçmek için
            gridViewMusteriler.ShowEditor(); // seçimi göstermek için
            gridViewMusteriler.Appearance.FocusedCell.BackColor = Color.Transparent; // Tıklanan hücrenin arkaplanını transparan yapmak için
            if (seciliSatir == gridViewMusteriler.FocusedRowHandle) // bir önceki tıklanan satır ile şimdi tıklanan satır aynı mı diye kontrol ediyor
            {
                seciliSatir = 999999999; // Tıklamayı sıfırlamak için tekrar başlangıç değerine dönüyoruz.
                // Çift tıklandığında yapılacak işlemler yazılacak..
                MusteriBilgileriAc();
            }
            else { seciliSatir = gridViewMusteriler.FocusedRowHandle; }  // aynı değlse son tıklananı alıyor.          
        }

        private void GridViewPoliceler_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView currentView = sender as GridView;
            if (e.Column.FieldName == "ArtisYuzdesi")
            {
                decimal value = Convert.ToDecimal(currentView.GetRowCellValue(e.RowHandle, "ArtisYuzdesi"));
                if (value>20)
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

        public int seciliSatirPolice = 999999999; // 999999999 olmasının sebebi herhangi bir çakışmayı engelleme amaçlıdır.

        private void GridViewPoliceler_RowClick(object sender, RowClickEventArgs e)
        {
            gridViewPoliceler.SelectRow(gridViewMusteriler.FocusedRowHandle); // gridview'de tıklanan satırı seçmek için
            gridViewPoliceler.ShowEditor(); // seçimi göstermek için
            gridViewPoliceler.Appearance.FocusedCell.BackColor = Color.Transparent; // Tıklanan hücrenin arkaplanını transparan yapmak için
            if (seciliSatirPolice == gridViewPoliceler.FocusedRowHandle) // bir önceki tıklanan satır ile şimdi tıklanan satır aynı mı diye kontrol ediyor
            {
                seciliSatirPolice = 999999999; // Tıklamayı sıfırlamak için tekrar başlangıç değerine dönüyoruz.
                // Çift tıklandığında yapılacak işlemler yazılacak..
                PoliceBilgileriAc(true);
            }
            else { seciliSatirPolice = gridViewPoliceler.FocusedRowHandle; }  // aynı değlse son tıklananı alıyor.  
        }

        private void PoliceBilgileriAc(bool EskiPolice = true)
        {
            FrmPolice f;
            if (EskiPolice)
            {
                SeciliPolice.Firma = SeciliMusteri;
                SeciliPolice.Sigortaci = Session.SigortaciService.GetById(SeciliPolice.SigortaciId);
                f = new FrmPolice(SeciliPolice,false);
            }
            else
            {
                f = new FrmPolice(SeciliMusteri);
            }
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                var handle = this.gridViewMusteriler.GetSelectedRows()[0];
                Firma policeMusteri = Session.FirmaService.GetById(Convert.ToInt32(gridViewMusteriler.GetRowCellValue(handle, "FirmaId")));
                //List<Police> Police = Session2.PoliceService.GetMusteriPoliceleri(policeMusteri);
                policeMusteri.Policeler = Session.PoliceService.GetMusteriPoliceleri(policeMusteri);

                var policeleri = policeMusteri.Policeler.Where(t => t.PoliceBitisTarih > DateTime.Now).ToList();
                var a = from pol in policeleri
                        orderby pol.PoliceBitisTarih descending
                        join sig in Session.SigortaciService.GetAll() on pol.SigortaciId equals sig.SigortaciId
                        select new
                        {
                            pol.PoliceId,
                            pol.PoliceTuru,
                            pol.PoliceNo,
                            pol.Policelenen,
                            pol.Tutar,
                            pol.ArtisYuzdesi,
                            pol.PoliceBaslangicTarih,
                            pol.PoliceBitisTarih,
                            pol.PoliceGeldimi,
                            sig.Unvan,
                            pol.Aciklama

                        };
                gridControlPoliceler.DataSource = a.OrderBy(t => t.PoliceBitisTarih).ToList();
                //List<SigortaFirma> Liste = Session2.SigortaFirmaService.GetAll();
                //dataSetSigortacilar2 = Liste.ConvertGenericList("Sigortacilar");
                //dataSetSigortacilar.Merge(dataSetSigortacilar2,true,MissingSchemaAction.Add); 
                GridDüzenle();
            }
        }
    }
}
