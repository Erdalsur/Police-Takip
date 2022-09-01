using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Policem.Data;
using Policem.UI.DependencyResolution;

namespace Policem.UI.Forms.Selection
{
    public partial class FrmMusteriSec : Form
    {
        public Firma policeMusteri = new Firma();
        public bool Secildi = false;
        List<Firma> Musteriler = Session.FirmaService.GetAll().ToList();
        public FrmMusteriSec()
        {
            InitializeComponent();
        }

        private void FrmMusteriSec_Load(object sender, EventArgs e)
        {
            MusteriListesi();
        }
        private void MusteriListesi()
        {
            gridMusteri.DataSource = Musteriler;
            GridDuzen();
        }
        private void GridDuzen()
        {
            gridMusteri.Columns["Id"].Visible = false;
            gridMusteri.Columns["Id"].HeaderText = "Referans No";
            gridMusteri.Columns["Unvan"].HeaderText = "Müşteri Ünvanı";
            gridMusteri.Columns["Kod"].Visible =
            gridMusteri.Columns["Yetkili"].Visible =
            gridMusteri.Columns["VKNO"].Visible =
            gridMusteri.Columns["Policeler"].Visible = false;
        }
        private void gridMusteri_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            policeMusteri = Session.FirmaService.GetById(Convert.ToInt32(gridMusteri.CurrentRow.Cells[0].Value.ToString()));
            this.Secildi = true;
            this.DialogResult = DialogResult.OK;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Musteriler = Session.FirmaService.GetAll().ToList();
            var t = Musteriler.Where(item => item.Unvan.Contains(textBox1.Text)).ToList();
            gridMusteri.DataSource = t;
            GridDuzen();
        }
    }
}
