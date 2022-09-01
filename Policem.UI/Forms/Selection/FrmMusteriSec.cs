using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Policem.Data;
using Policem.UI.DependencyResolution;
using Policem.UI.Forms.Base;

namespace Policem.UI.Forms.Selection
{
    public partial class FrmMusteriSec : XPopupForm
    {
        public Firma policeMusteri=null;
        public bool Secildi = false;
        List<Firma> Musteriler=null;
        public FrmMusteriSec()
        {
            InitializeComponent();
        }

        private void FrmMusteriSec_Load(object sender, EventArgs e)
        {
            policeMusteri = new Firma();
            MusteriListesi();
        }
        private void MusteriListesi()
        {
            Musteriler = Session.FirmaService.GetAll();
            gridControlMusteriler.DataSource = Musteriler;
            GridDuzen();
        }
        private void GridDuzen()
        {
            gridMusteri.Columns["FirmaId"].Visible = false;
            gridMusteri.Columns["FirmaId"].Caption = "Referans No";
            gridMusteri.Columns["Unvan"].Caption = "Müşteri Ünvanı";
            gridMusteri.Columns["Name"].Visible =
            gridMusteri.Columns["Kod"].Visible =
            gridMusteri.Columns["Yetkili"].Visible =
            gridMusteri.Columns["VKNO"].Visible =
            gridMusteri.Columns["Policeler"].Visible = false;
            gridMusteri.BestFitColumns();
        }
        public int seciliSatir = 999999999; // 999999999 olmasının sebebi herhangi bir çakışmayı engelleme amaçlıdır.

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Musteriler = Session.FirmaService.GetAll();//.Where(ta=>ta.Unvan.Contains(textBox1.Text)).ToList();
            var t = Musteriler.Where(item => item.Unvan.ToLower().Contains(textBox1.Text.ToLower())).ToList();
            gridControlMusteriler.DataSource = t;
            GridDuzen();
        }

        private void gridMusteri_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            gridMusteri.SelectRow(gridMusteri.FocusedRowHandle); // gridview'de tıklanan satırı seçmek için
            gridMusteri.ShowEditor(); // seçimi göstermek için
            gridMusteri.Appearance.FocusedCell.BackColor = Color.Transparent; // Tıklanan hücrenin arkaplanını transparan yapmak için
            if (seciliSatir == gridMusteri.FocusedRowHandle) // bir önceki tıklanan satır ile şimdi tıklanan satır aynı mı diye kontrol ediyor
            {
                seciliSatir = 999999999; // Tıklamayı sıfırlamak için tekrar başlangıç değerine dönüyoruz.
                // Çift tıklandığında yapılacak işlemler yazılacak..
                policeMusteri = Session.FirmaService.GetById(Convert.ToInt32(gridMusteri.GetRowCellValue(gridMusteri.FocusedRowHandle, "FirmaId")));
                this.Secildi = true;
                this.DialogResult = DialogResult.OK;
            }
            else { seciliSatir = gridMusteri.FocusedRowHandle; }  // aynı değlse son tıklananı alıyor.    
        }

        private void gridMusteri_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                var handle = this.gridMusteri.GetSelectedRows()[0];
                policeMusteri = Session.FirmaService.GetById(Convert.ToInt32(gridMusteri.GetRowCellValue(handle, "FirmaId")));

            }
            catch
            {
                policeMusteri = null;
            }
        }
    }
}
