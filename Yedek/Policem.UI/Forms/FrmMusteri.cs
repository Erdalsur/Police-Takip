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

namespace Policem.UI.Forms
{
    public partial class FrmMusteri : Form
    {
        bool YeniKayit = true;
        Firma musteri;
        public FrmMusteri()
        {
            InitializeComponent();
            musteri = new Firma();
        }

        public FrmMusteri(Firma Musteri)
        {
            InitializeComponent();
            musteri = Musteri;
            YeniKayit = false;
            txtKod.Text = musteri.Kod;
            txtUnvan.Text = musteri.Unvan;
            txtYetkili.Text = musteri.Yetkili;
            txtVergiNo.Text = musteri.VKNO;
        }
        private void FrmMusteri_Load(object sender, EventArgs e)
        {
            if (YeniKayit == true)
            {
                this.Text = "Yeni Müşteri Girişi";
            }
            else
            {
                this.Text = musteri.Unvan.ToString();
                
            }
        }
        private void FrmMusteri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

        }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            musteri.Kod = txtKod.Text;
            musteri.Name=musteri.Unvan = txtUnvan.Text;
            musteri.Yetkili = txtYetkili.Text;
            musteri.VKNO = txtVergiNo.Text;
            
            try
            {
                musteri = YeniKayit ? Session.FirmaService.Add(musteri) : Session.FirmaService.Update(musteri);
                this.DialogResult = DialogResult.OK;
            }
            catch
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

    }
}
