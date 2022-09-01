using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Policem.Data;
using Policem.UI.DependencyResolution;

namespace Policem.UI.Forms.Selection
{
    public partial class FrmSigortaciSec : Form
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
            gridMusteri.DataSource = sigortaFirmalari;
            GridDuzen();
        }

        private void GridDuzen()
        {
            gridMusteri.Columns["SigortaciId"].Visible = false;
            gridMusteri.Columns["SigortaciId"].HeaderText = "Referans No";
            gridMusteri.Columns["Unvan"].HeaderText = "Firma Ünvanı";
            gridMusteri.Columns["FirmaNo"].Visible =
            gridMusteri.Columns["HasarNumarasi"].Visible =
            gridMusteri.Columns["TemsilciAdi"].Visible =
            gridMusteri.Columns["Policeler"].Visible =
            gridMusteri.Columns["TemsilciTel"].Visible = false;

        }



        private void gridMusteri_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sigortaFirma = Session.SigortaciService.GetById(Convert.ToInt32(gridMusteri.CurrentRow.Cells[0].Value.ToString()));
            this.Secildi = true;
            this.DialogResult = DialogResult.OK;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            sigortaFirmalari = Session.SigortaciService.GetAll().ToList();
            var t = sigortaFirmalari.Where(item => item.Unvan.Contains(textBox1.Text)).ToList();
            gridMusteri.DataSource = t;
            GridDuzen();
        }
    }
}
