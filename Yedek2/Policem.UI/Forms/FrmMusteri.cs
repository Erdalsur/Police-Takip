using System;
using System.Drawing;
using System.Windows.Forms;
using Policem.Core.Utility;
using Policem.Data;
using Policem.UI.DependencyResolution;
using Policem.UI.Forms.Base;

namespace Policem.UI.Forms
{
    public partial class FrmMusteri : XPopupForm
    {
        bool YeniKayit = true;
        Firma musteri;
        public FrmMusteri()
        {
            InitializeComponent();
            ControlColoriezrSystem();
            musteri = new Firma();
        }

        private void ControlColoriezrSystem()
        {
            ControlColorizer controlColorizer1 = new ControlColorizer
                            (Color.FromName(AppSession.PrgSettingsOrg.AktifAlanRengi), SystemColors.Window,
                            new Control[4]
                  {
        (Control) this.txtKod,
        (Control) this.txtUnvan,
        (Control) this.txtVergiNo,
        (Control) this.txtYetkili
                  });
        }

        public FrmMusteri(Firma Musteri)
        {
            InitializeComponent();
            ControlColoriezrSystem();
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
                AppSession.MainForm.NotifyMain(musteri.Unvan+" Adlı Poliçe Müşterisi Kayıt Edildi.");
                this.DialogResult = DialogResult.OK;
            }
            catch
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

    }
}
