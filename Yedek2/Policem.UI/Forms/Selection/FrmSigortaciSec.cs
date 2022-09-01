using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Policem.Core.Utility;
using Policem.Data;
using Policem.UI.DependencyResolution;
using Policem.UI.Forms.Base;

namespace Policem.UI.Forms.Selection
{
    public partial class FrmSigortaciSec : XPopupForm
    {
        public Sigortaci sigortaFirma = new Sigortaci();
        List<Sigortaci> sigortaFirmalari = Session.SigortaciService.GetAll().ToList();
        public bool Secildi = false;
        public FrmSigortaciSec()
        {
            InitializeComponent();
        }

        private void FrmSigortaciSec_Load(object sender, EventArgs e)
        {
            MusteriListesi();
        }
        private void MusteriListesi()
        {
            gridControl1.DataSource = sigortaFirmalari;
            
            GridDuzen();
        }

        private void GridDuzen()
        {
            UIGridUtility.GridAlanGizle(this.gridView1, "SigortaciId;SigortaciAdi;Policeler;HasarNumarasi;TemsilciTel;TemsilciAdi");
            //Önce Alan Gizleme
            gridView1.Columns["SigortaciId"].Visible = false;
            gridView1.Columns["SigortaciId"].Caption = "Referans No";
            gridView1.Columns["SigortaciAdi"].Visible = false;
            gridView1.Columns["SigortaciAdi"].Caption = "Sigortaci Adı";
            gridView1.Columns["FirmaNo"].Caption = "Kodu";
            gridView1.Columns["Unvan"].Caption = "Firma Ünvanı";
            gridView1.Columns["HasarNumarasi"].Caption = "Hasar Telefonu";
            gridView1.Columns["TemsilciAdi"].Caption = "Temsilci Adı";
            gridView1.Columns["TemsilciTel"].Caption = "Temsilci Telefonu";

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            sigortaFirmalari = Session.SigortaciService.GetAll().ToList();
            var t = sigortaFirmalari.Where(item => item.Unvan.ToLower().Contains(textBox1.Text.Trim().ToLower())||
                item.FirmaNo.ToLower().Contains(textBox1.Text.Trim().ToLower())).ToList();
            gridControl1.DataSource = t;
            GridDuzen();
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var handle = this.gridView1.GetSelectedRows()[0];
            sigortaFirma = Session.SigortaciService.GetById(Convert.ToInt32(this.gridView1.GetRowCellValue(handle, "SigortaciId")));
            this.Secildi = true;
            this.DialogResult = DialogResult.OK;
        }
        public int seciliSatir = 999999999; // 999999999 olmasının sebebi herhangi bir çakışmayı engelleme amaçlıdır.

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            gridView1.SelectRow(gridView1.FocusedRowHandle); // gridview'de tıklanan satırı seçmek için
            gridView1.ShowEditor(); // seçimi göstermek için
            gridView1.Appearance.FocusedCell.BackColor = Color.Transparent; // Tıklanan hücrenin arkaplanını transparan yapmak için
            if (seciliSatir == gridView1.FocusedRowHandle) // bir önceki tıklanan satır ile şimdi tıklanan satır aynı mı diye kontrol ediyor
            {
                seciliSatir = 999999999; // Tıklamayı sıfırlamak için tekrar başlangıç değerine dönüyoruz.
                // Çift tıklandığında yapılacak işlemler yazılacak..
                sigortaFirma = Session.SigortaciService.GetById(Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SigortaciId")));
                this.Secildi = true;
                this.DialogResult = DialogResult.OK;
            }
            else { seciliSatir = gridView1.FocusedRowHandle; }  // aynı değlse son tıklananı alıyor.   
        }
    }
}
