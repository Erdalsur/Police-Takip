using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using Policem.Data;
using Policem.Data.Enums;
using Policem.UI.DependencyResolution;

namespace Policem.UI.Forms
{
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
            SplashScreenManager.ShowForm(typeof(WaitForm1));
        }

        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            
            lblUnvan.Text = string.Empty;
            gridMusteriler.Focus();
            MusteriListesi();
            gridMusteriler.Select();
        }
        private void MusteriListesi()
        {
            List<Firma> Musteriler = Session.FirmaService.GetAll();

            //dataSetSigortacilar2 = dataSetSigortacilar = Liste.ConvertGenericList("Sigortacilar");
            //gridSigortacilar.DataSource = dataSetSigortacilar.Tables["Sigortacilar"];
            gridMusteriler.DataSource = Musteriler;
            Firma policeMusteri = Session.FirmaService.GetById(Convert.ToInt32(gridMusteriler.CurrentRow.Cells[0].Value.ToString()));
            //List<Police> Police = Session.PoliceService.GetMusteriPoliceleri(policeMusteri);
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
            gridPoliceler.DataSource = a.OrderBy(t => t.PoliceBitisTarih).ToList();
            
            //List<SigortaFirma> Liste = Session.SigortaFirmaService.GetAll();
            //dataSetSigortacilar2 = Liste.ConvertGenericList("Sigortacilar");
            //dataSetSigortacilar.Merge(dataSetSigortacilar2,true,MissingSchemaAction.Add); 
            GridDüzenle();

        }
        private void GridDüzenle()
        {
            //Önce Alan Gizleme
            gridMusteriler.Columns["FirmaId"].Visible = false;
            gridMusteriler.Columns["FirmaId"].HeaderText = "Referans No";
            gridMusteriler.Columns["Name"].Visible = false;
            gridMusteriler.Columns["Name"].HeaderText = "Adı";
            gridMusteriler.Columns["Kod"].HeaderText = "Kodu";
            gridMusteriler.Columns["Unvan"].HeaderText = "Müşteri Ünvanı";
            gridMusteriler.Columns["Yetkili"].HeaderText = "Yetkilisi";
            gridMusteriler.Columns["VKNO"].HeaderText = "Kimlik No";
            gridMusteriler.Columns["Policeler"].Visible = false;
            gridMusteriler.Columns["Policeler"].HeaderText = "Policeleri";

            //Poliçe grid düzeni
            GridDüzenlePolice();
        }
        private void GridDüzenlePolice()
        {
            gridPoliceler.Columns["PoliceId"].Visible = false;
            gridPoliceler.Columns["PoliceId"].HeaderText = "Referans No";
            //gridPoliceler.Columns["Firma"].Visible = false;
            //gridPoliceler.Columns["Firma"].HeaderText = "Kime Ait";
            gridPoliceler.Columns["PoliceTuru"].HeaderText = "Poliçe Tipi";
            gridPoliceler.Columns["PoliceTuru"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //gridPoliceler.Columns["Sigortaci"].HeaderText = "Sigorta Firması";
            gridPoliceler.Columns["PoliceNo"].HeaderText = "Poliçenin Numarası";
            gridPoliceler.Columns["PoliceBaslangicTarih"].HeaderText = "Başlangıç Tarihi";
            gridPoliceler.Columns["PoliceBitisTarih"].HeaderText = "Bitiş Tarihi";
            gridPoliceler.Columns["Policelenen"].HeaderText = "Neyin Poliçelendiği";
            gridPoliceler.Columns["Aciklama"].HeaderText = "Açıklama";
            //gridPoliceler.Columns["OdemeTuru"].HeaderText = "Ödeme Tipi";
            gridPoliceler.Columns["Tutar"].HeaderText = "Tutar";
            gridPoliceler.Columns["Tutar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
            //gridPoliceler.Columns["OncekiTutar"].Visible = false;
            //gridPoliceler.Columns["OncekiTutar"].HeaderText = "Önceki Poliçe Tutarı";
            gridPoliceler.Columns["ArtisYuzdesi"].HeaderText = "Artış Oranı";
            gridPoliceler.Columns["ArtisYuzdesi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //gridPoliceler.Columns["Taksit"].Visible = false;
            //gridPoliceler.Columns["Taksit"].HeaderText = "Taksit Varmı";
            //gridPoliceler.Columns["TaksitSayisi"].Visible = false;
            //gridPoliceler.Columns["TaksitSayisi"].HeaderText = "Taksit Sayısı";
            //gridPoliceler.Columns["Yenilendimi"].Visible = false;
            //gridPoliceler.Columns["Yenilendimi"].HeaderText = "Yenilendimi";
            //gridPoliceler.Columns["YeniPoliceId"].Visible = false;
            //gridPoliceler.Columns["YeniPoliceId"].HeaderText = "Yeni Referans No";

            gridPoliceler.Columns["PoliceGeldimi"].HeaderText = "Poliçe Basıldı";
            gridPoliceler.Columns["PoliceGeldimi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridPoliceler.Columns["Unvan"].HeaderText = "Sigorta Firması";
            ArtısOranıRenklendir();
        }

        private void ArtısOranıRenklendir()
        {
            //for(int i=0;i<gridPoliceler.Rows.Count;i++)
            //{
            //    DataGridViewCellStyle renk = new DataGridViewCellStyle();
            //    if (Convert.ToInt16(gridPoliceler.Rows[i].Cells["ArtisYuzdesi"].Value) >= (30))
            //    {
            //        renk.BackColor = Color.Red;
            //    }
            //    else
            //    if (Convert.ToInt16(gridPoliceler.Rows[i].Cells["ArtisYuzdesi"].Value) <= (0))
            //    {
            //        renk.BackColor = Color.Green;
            //    }
            //    else
            //        renk.BackColor = Color.White;
            //    gridPoliceler.Rows[i].Cells["ArtisYuzdesi"].Style = renk;
            //}
            foreach (DataGridViewRow row in gridPoliceler.Rows)
            {
                row.Cells["Tutar"].Style.Format = "C";
                if (row.Cells["PoliceGeldimi"].Value.ToString() == "Hayır")
                {
                    row.Cells["PoliceGeldimi"].Style.BackColor = Color.Red;
                }
                row.Cells["ArtisYuzdesi"].Style.Format = "'%' ###.##";
                if (Convert.ToDecimal(row.Cells["ArtisYuzdesi"].Value) > 30)
                {
                    row.Cells["ArtisYuzdesi"].Style.BackColor = Color.Red;
                }
                if (Convert.ToDecimal(row.Cells["ArtisYuzdesi"].Value) < 0)
                {
                    row.Cells["ArtisYuzdesi"].Style.BackColor = Color.Green;
                }
            }

        }

        private void BtnYeniMusteri_Click(object sender, EventArgs e)
        {
            YeniMusteri();
        }

        private void YeniMusteri()
        {
            FrmMusteri f = new FrmMusteri();
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) MusteriListesi();
        }

        private void BtnAc_Click(object sender, EventArgs e)
        {
            var musteri = Session.FirmaService.GetById(Convert.ToInt32(gridMusteriler.CurrentRow.Cells[0].Value.ToString()));
            FrmMusteri f = new FrmMusteri(musteri);
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
                MusteriListesi();
        }

        private void GridMusteriler_SelectionChanged(object sender, EventArgs e)
        {
            if (gridMusteriler.Focused)
            {
                BilgiEkranıYaz();
            }
        }

        private void BilgiEkranıYaz()
        {
            var unvan = gridMusteriler.CurrentRow.Cells[2].Value.ToString();
            lblUnvan.Text = unvan.ToString();
            Firma policeMusteri = Session.FirmaService.GetById(Convert.ToInt32(gridMusteriler.CurrentRow.Cells[0].Value.ToString()));
            List<Police> list = Session.PoliceService.GetMusteriPoliceleri(policeMusteri);
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
            policeMusteri.Policeler = policeleri;
            var ToplamTutari = a.Sum(t => t.Tutar).ToString();
            lblUnvan.Text += " ait Toplam = " + String.Format("{0:C}", Convert.ToDouble(ToplamTutari))+" Poliçe Ödemesi Olmuş";
            gridPoliceler.DataSource = a.OrderBy(t => t.PoliceBitisTarih).ToList();//Police;
            GridDüzenlePolice();
            
        }

        private void GridMusteriler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnAc_Click(sender, e);
        }

        private void GridMusteriler_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;

        }

        private void BtnPoliceEkle_Click(object sender, EventArgs e)
        {
            var musteri = Session.FirmaService.GetById(Convert.ToInt32(gridMusteriler.CurrentRow.Cells[0].Value.ToString()));
            FrmPolice f = new FrmPolice(musteri);
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
                BilgiEkranıYaz();
        }

        private void AcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PoliceyiAc();
        }

        private void PoliceyiAc()
        {
            var musteri = Session.FirmaService.GetById(Convert.ToInt32(gridMusteriler.CurrentRow.Cells[0].Value.ToString()));
            var policesi = Session.PoliceService.GetById(Convert.ToInt32(gridPoliceler.CurrentRow.Cells[0].Value.ToString()));
            policesi.Firma = Session.FirmaService.GetById(policesi.FirmaId);
            policesi.Sigortaci = Session.SigortaciService.GetById(policesi.SigortaciId);
            FrmPolice f = new FrmPolice(policesi);
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
                BilgiEkranıYaz();
        }

        private void GridPoliceler_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PoliceyiAc();
        }

        private void FrmMusteriler_Shown(object sender, EventArgs e)
        {
            ArtısOranıRenklendir();
            SplashScreenManager.CloseForm();
        }

        private void GridPoliceler_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ArtısOranıRenklendir();
            
        }

        private void PoliçeyiYenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Var olan poliçeyi yenileme
            Police eskiPolice = Session.PoliceService.GetById(Convert.ToInt32(gridPoliceler.CurrentRow.Cells[0].Value.ToString())); ;
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
            FrmPolice f = new FrmPolice(yeniPolice, false);
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
    }
}
