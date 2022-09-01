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
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using Policem.Core.Utility;
using Policem.Data;
using Policem.Data.Enums;
using Policem.UI.Core;
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
            gvMusteriler.Focus();
            GridManager manager = GridManager.GetManager(this.gvMusteriler);
            manager.GridMenu.AddMenu("Aç", new EventHandler(BtnAc_Click));
            manager.GridMenu.AddMenu("Yeni Poliçe Ekle", new EventHandler(BtnYeniPolice_Click));
            manager.GridMenu.AddMenu("Yeni Müşteri Ekle", new EventHandler(BtnYeniMusteri_Click));
            //manager.GridMenu.AddMenu("Alınan Poliçeler", new EventHandler(BtnPoliceleri_Click));
            manager.GridMenu.AddMenu("Sil", new EventHandler(BtnMusteriSil_Click), (Image)Resources.Delete_16x16);
            GridManager manager2 = GridManager.GetManager(this.gvPoliceler);
            manager2.GridMenu.AddMenu("Aç", new EventHandler(BtnPoliceAc_Click));
            manager2.GridMenu.AddMenu("Yeni Poliçe Ekle", new EventHandler(BtnYeniPolice_Click));
            manager2.GridMenu.AddMenu("Police Sil", new EventHandler(BtnPoliceSil_Click), (Image)Resources.Delete_16x16);
            manager2.GridMenu.AddMenu("Seçili Poliçeyi Yenile", new EventHandler(BtnPoliceYenileme_Click), (Image)Resources.refresh);
            manager2.GridMenu.AddMenu("Outlook Takvimini Oluştur", new EventHandler(BtnTakvimOlustur_Click), (Image)Resources.Calendar);
            //manager2.Grid.ContextMenuStrip=contextMenuStrip2;
            InitGridView(gvMusteriler);
            InitGridView(gvPoliceler);
        }

        private void BtnTakvimOlustur_Click(object sender, EventArgs e)
        {
            string MailAdresi = AppSession.Settings.OutlookMailAdresi;
            int KacGunOncesi = AppSession.Settings.MuayeneTakvimHatirlatici*(-1);
            OutlookTakvim.CreateMeetingRequest(MailAdresi, SeciliPolice.Policelenen+" - "+SeciliPolice.PoliceBitisTarih.ToLongDateString(),
                "Hatırlacı Takvim Sistemi Üzerinden \n" +
                "Bir önceki Tutarı = "+ SeciliPolice.Tutar+
                "\n"+SeciliPolice.Aciklama, 
                Convert.ToDateTime(SeciliPolice.PoliceBitisTarih.AddDays(KacGunOncesi)), Convert.ToDateTime(SeciliPolice.PoliceBitisTarih));
            AppSession.MainForm.NotifyMain(SeciliPolice.Policelenen+" için Outlook Takvim Bilgisi Gönderildi.");
        }
        //private void ThisAddIn_Startup(object sender, System.EventArgs e)
        //{
        //    Microsoft.Office.Interop.Outlook.AppointmentItem agendaMeeting = 
        //        (Microsoft.Office.Interop.Outlook.AppointmentItem)
        //        this.Application.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.
        //        olAppointmentItem);

        //    if (agendaMeeting != null)
        //    {
        //        agendaMeeting.MeetingStatus =
        //            Microsoft.Office.Interop.Outlook.OlMeetingStatus.olMeeting;
        //        agendaMeeting.Location = "Conference Room";
        //        agendaMeeting.Subject = "Discussing the Agenda";
        //        agendaMeeting.Body = "Let's discuss the agenda.";
        //        agendaMeeting.Start = new DateTime(2005, 5, 5, 5, 0, 0);
        //        agendaMeeting.Duration = 60;
        //        Microsoft.Office.Interop.Outlook.Recipient recipient =
        //            agendaMeeting.Recipients.Add("Nate Sun");
        //        recipient.Type =
        //            (int)Microsoft.Office.Interop.Outlook.OlMeetingRecipientType.olRequired;
        //        ((Microsoft.Office.Interop.Outlook._AppointmentItem)agendaMeeting).Send();
        //    }
        //}


        private void MusteriListesi()
        {
            List<Firma> Musteriler = Session.FirmaService.GetAll();

            //dataSetSigortacilar2 = dataSetSigortacilar = Liste.ConvertGenericList("Sigortacilar");
            //gridSigortacilar.DataSource = dataSetSigortacilar.Tables["Sigortacilar"];
            gcMusteriler.DataSource = Musteriler;
            try
            {
                var handle = this.gvMusteriler.GetSelectedRows()[0];
                Firma policeMusteri = Session.FirmaService.GetById(Convert.ToInt32(gvMusteriler.GetRowCellValue(handle, "FirmaId")));
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
                gcPoliceler.DataSource = a.OrderBy(t => t.PoliceBitisTarih).ToList();
                gcMusteriler.ContextMenuStrip = null;
                //if (a.Count() > 0)
                //    gridControlPoliceler.ContextMenuStrip = null;
                //else
                //    gridControlPoliceler.ContextMenuStrip = contextMenuStrip2;
            }
            catch { }
            //List<SigortaFirma> Liste = Session2.SigortaFirmaService.GetAll();
            //dataSetSigortacilar2 = Liste.ConvertGenericList("Sigortacilar");
            //dataSetSigortacilar.Merge(dataSetSigortacilar2,true,MissingSchemaAction.Add); 
            GridDüzenle();

        }
        private void GridDüzenle()
        {
            UIGridUtility.GridAlanGizle(this.gvMusteriler, "FirmaId;Name;Policeler");
            //Önce Alan Gizleme
            gvMusteriler.Columns["FirmaId"].Caption = "Referans No";
            gvMusteriler.Columns["Name"].Caption = "Adı";
            gvMusteriler.Columns["Kod"].Caption = "Kodu";
            gvMusteriler.Columns["Unvan"].Caption = "Müşteri Ünvanı";
            gvMusteriler.Columns["Yetkili"].Caption = "Yetkilisi";
            gvMusteriler.Columns["VKNO"].Caption = "Kimlik No";
            gvMusteriler.Columns["Policeler"].Caption = "Policeleri";
            gvMusteriler.BestFitColumns();
            //Poliçe grid düzeni
            GridDüzenlePolice();
        }
        private void GridDüzenlePolice()
        {
            try
            {
                UIGridUtility.GridAlanGizle(gvPoliceler, "PoliceId");
                gvPoliceler.Columns["PoliceId"].Caption = "Referans No";
                //gridPoliceler.Columns["Firma"].Visible = false;
                //gridPoliceler.Columns["Firma"].HeaderText = "Kime Ait";
                gvPoliceler.Columns["PoliceTuru"].Caption = "Poliçe Tipi";
                gvPoliceler.Columns["PoliceTuru"].ColumnEdit = GetCustomPoliceTipi();
                gvPoliceler.Columns["PoliceTuru"].AppearanceCell.TextOptions.RightToLeft = true;
                //gridPoliceler.Columns["Sigortaci"].HeaderText = "Sigorta Firması";
                gvPoliceler.Columns["PoliceNo"].Caption = "Poliçenin Numarası";
                gvPoliceler.Columns["PoliceBaslangicTarih"].Caption = "Başlangıç Tarihi";
                gvPoliceler.Columns["PoliceBitisTarih"].Caption = "Bitiş Tarihi";
                gvPoliceler.Columns["Policelenen"].Caption = "Neyin Poliçelendiği";
                gvPoliceler.Columns["Aciklama"].Caption = "Açıklama";
                //gridPoliceler.Columns["OdemeTuru"].HeaderText = "Ödeme Tipi";
                gvPoliceler.Columns["Tutar"].Caption = "Tutar";
                gvPoliceler.Columns["Tutar"].AppearanceCell.TextOptions.RightToLeft = true;
                gvPoliceler.Columns["Tutar"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                NumberFormatInfo nf = new NumberFormatInfo() { CurrencySymbol = "TL" };
                gvPoliceler.Columns["Tutar"].DisplayFormat.Format = nf;
                gvPoliceler.Columns["Tutar"].DisplayFormat.FormatString = "#.###,## TL";
                //gridPoliceler.Columns["OncekiTutar"].Visible = false;
                //gridPoliceler.Columns["OncekiTutar"].HeaderText = "Önceki Poliçe Tutarı";
                gvPoliceler.Columns["ArtisYuzdesi"].Caption = "Artış Oranı";
                gvPoliceler.Columns["ArtisYuzdesi"].AppearanceCell.TextOptions.RightToLeft = true;
                gvPoliceler.Columns["ArtisYuzdesi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                gvPoliceler.Columns["ArtisYuzdesi"].DisplayFormat.Format = new FormatYuzde();
                //gridPoliceler.Columns["Taksit"].Visible = false;
                //gridPoliceler.Columns["Taksit"].HeaderText = "Taksit Varmı";
                //gridPoliceler.Columns["TaksitSayisi"].Visible = false;
                //gridPoliceler.Columns["TaksitSayisi"].HeaderText = "Taksit Sayısı";
                //gridPoliceler.Columns["Yenilendimi"].Visible = false;
                //gridPoliceler.Columns["Yenilendimi"].HeaderText = "Yenilendimi";
                //gridPoliceler.Columns["YeniPoliceId"].Visible = false;
                //gridPoliceler.Columns["YeniPoliceId"].HeaderText = "Yeni Referans No";

                gvPoliceler.Columns["PoliceGeldimi"].Caption = "Poliçe Basıldı";
                gvPoliceler.Columns["PoliceGeldimi"].AppearanceCell.TextOptions.RightToLeft = true;
                gvPoliceler.Columns["Unvan"].Caption = "Sigorta Firması";
                gvPoliceler.BestFitColumns();
            }
            catch { }
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
            var handle = this.gvMusteriler.GetSelectedRows()[0];
            SeciliMusteri = Session.FirmaService.GetById(Convert.ToInt32(gvMusteriler.GetRowCellValue(handle, "FirmaId")));
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
            gcPoliceler.DataSource = a.OrderBy(t => t.PoliceBitisTarih).ToList();//Police;
            if (gvPoliceler.RowCount > 0)
                gcPoliceler.ContextMenuStrip = null;
            else
                gcPoliceler.ContextMenuStrip = contextMenuStrip2;
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
            var handle = this.gvPoliceler.GetSelectedRows()[0];
            // Var olan poliçeyi yenileme
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
                PoliceBaslangicTarih = eskiPolice.PoliceBitisTarih,
                PoliceBitisTarih = eskiPolice.PoliceBitisTarih.AddYears(1),
                OncekiTutar = eskiPolice.Tutar,
                Policelenen = eskiPolice.Policelenen,
                PoliceNo = eskiPolice.PoliceNo,
                PoliceTuru = eskiPolice.PoliceTuru,
                Aciklama=eskiPolice.Aciklama
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
            SeciliMusteri = null;
            var handle = this.gvMusteriler.GetSelectedRows()[0];
            SeciliMusteri= Session.FirmaService.GetById(Convert.ToInt32(gvMusteriler.GetRowCellValue(handle, "FirmaId")));
            if (SeciliMusteri == null)
                return;
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
            gcPoliceler.DataSource = a.OrderBy(t => t.PoliceBitisTarih).ToList();//Police;
            if (gvPoliceler.RowCount > 0)
                gcPoliceler.ContextMenuStrip = null;
            else
                gcPoliceler.ContextMenuStrip = contextMenuStrip2;
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
            gvMusteriler.SelectRow(gvMusteriler.FocusedRowHandle); // gridview'de tıklanan satırı seçmek için
            gvMusteriler.ShowEditor(); // seçimi göstermek için
            gvMusteriler.Appearance.FocusedCell.BackColor = Color.Transparent; // Tıklanan hücrenin arkaplanını transparan yapmak için
            if (seciliSatir == gvMusteriler.FocusedRowHandle) // bir önceki tıklanan satır ile şimdi tıklanan satır aynı mı diye kontrol ediyor
            {
                seciliSatir = 999999999; // Tıklamayı sıfırlamak için tekrar başlangıç değerine dönüyoruz.
                // Çift tıklandığında yapılacak işlemler yazılacak..
                MusteriBilgileriAc();
            }
            else { seciliSatir = gvMusteriler.FocusedRowHandle; }  // aynı değlse son tıklananı alıyor.          
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
                var handle = this.gvPoliceler.GetSelectedRows()[0];
                SeciliPolice = Session.PoliceService.GetById(Convert.ToInt32(gvPoliceler.GetRowCellValue(handle, "PoliceId")));

            }
            catch
            {
                SeciliPolice = null;
            }
            
        }

        public int seciliSatirPolice = 999999999; // 999999999 olmasının sebebi herhangi bir çakışmayı engelleme amaçlıdır.

        private void GridViewPoliceler_RowClick(object sender, RowClickEventArgs e)
        {
            gvPoliceler.SelectRow(gvMusteriler.FocusedRowHandle); // gridview'de tıklanan satırı seçmek için
            gvPoliceler.ShowEditor(); // seçimi göstermek için
            gvPoliceler.Appearance.FocusedCell.BackColor = Color.Transparent; // Tıklanan hücrenin arkaplanını transparan yapmak için
            if (seciliSatirPolice == gvPoliceler.FocusedRowHandle) // bir önceki tıklanan satır ile şimdi tıklanan satır aynı mı diye kontrol ediyor
            {
                seciliSatirPolice = 999999999; // Tıklamayı sıfırlamak için tekrar başlangıç değerine dönüyoruz.
                // Çift tıklandığında yapılacak işlemler yazılacak..
                PoliceBilgileriAc(true);
            }
            else { seciliSatirPolice = gvPoliceler.FocusedRowHandle; }  // aynı değlse son tıklananı alıyor.  
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
                var handle = this.gvMusteriler.GetSelectedRows()[0];
                Firma policeMusteri = Session.FirmaService.GetById(Convert.ToInt32(gvMusteriler.GetRowCellValue(handle, "FirmaId")));
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
                gcPoliceler.DataSource = a.OrderBy(t => t.PoliceBitisTarih).ToList();
                //List<SigortaFirma> Liste = Session2.SigortaFirmaService.GetAll();
                //dataSetSigortacilar2 = Liste.ConvertGenericList("Sigortacilar");
                //dataSetSigortacilar.Merge(dataSetSigortacilar2,true,MissingSchemaAction.Add); 
                GridDüzenle();
            }
        }

        private void gridViewPoliceler_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (gvPoliceler.DataRowCount < 0)
                popupMenu1.ShowPopup(MousePosition);
        }

        private void barSubItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("Yeni Poliçe");
        }
    }
}
