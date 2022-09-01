using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Policem.Core.Core.Aktivasyon;
using Policem.UI.Forms.Base;

namespace Policem.UI.Forms
{
    public partial class FrmLisans : XPopupForm
    {
        public bool LisansDurum = false;

        public FrmLisans()
        {
            InitializeComponent();
        }

        private void FrmLisans_Load(object sender, EventArgs e)
        {
            System.Reflection.AssemblyProductAttribute assemblyProduct = (System.Reflection.AssemblyProductAttribute)Attribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(), typeof(System.Reflection.AssemblyProductAttribute));
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

            txtAktivasyonKodu.Text = LisanslamaSistemi.LisansSeriUretimi();
            txtAd.Text = AppSession.Lisansim.Adi ?? string.Empty;
            txtFirma.Text = AppSession.Lisansim.Firma ?? string.Empty;
            txtEmail.Text = AppSession.Lisansim.Email??string.Empty;
            txtSerial.Text = AppSession.Lisansim.SerialNumber??string.Empty;
            LisansDurum = LisanslamaSistemi.LisansKontrol(txtAktivasyonKodu.Text, txtSerial.Text);
            if (LisansDurum)
                btnAktivasyon.Enabled = false;
            else
                btnAktivasyon.Enabled = true;
        }
        private void btnAktivasyon_Click(object sender, EventArgs e)
        {
            bool RegisterDurum = false;
            bool durum = false;
            bool durum2 = false;
            bool LisansKontrol = false;
            //Bilgiler Girildimi Kontrol Et
            //Key Doğru ise Bilgileri Mail At

            if (LisansKontrol = LisanslamaSistemi.LisansKontrol(txtAktivasyonKodu.Text, txtSerial.Text))
            {
                durum = Gmail.LisansMailGonder(txtAd.Text, txtFirma.Text, txtEmail.Text, txtAktivasyonKodu.Text, txtSerial.Text);
                if (durum)
                {
                    //Teşekkür Maili
                    string Cevap;
                    Cevap = "Merhaba " + txtAd.Text + ",<br/> Poliçe Takip Yazılımını tercih ettiğiniz için teşekürler. Yazılım Aktivasyonu tamamlanmıştır. Bütün öneri veya şikeyatleriniz için bu mail adresini kullanabilirsiniz.<br/><br/> Lisans Serial Numaranız :" + txtSerial.Text;
                    durum2 = Gmail.mailGonder(txtEmail.Text, "Poliçe Takip Yazılımınız Serial Numarası", Cevap);
                }
                //Register Kayıtlarını Gerçekleştir.
                if (durum)
                {
                    AppSession.Lisansim.SerialNumber = txtSerial.Text;
                    AppSession.Lisansim.Adi = txtAd.Text;
                    AppSession.Lisansim.Email = txtEmail.Text;
                    AppSession.Lisansim.LisansDurum = LisansKontrol;
                    AppSession.Lisansim.YüklenenTarih = DateTime.Now;
                    RegisterDurum = LisanslamaSistemi.SetKey(txtSerial.Text, txtAktivasyonKodu.Text, txtAd.Text, txtFirma.Text, txtEmail.Text);
                    if (!RegisterDurum)
                        MessageBox.Show("Aktivasyon Gerçekleşmedi. Kullanıcı Haklarınızı Kontrol Ediniz.", "Aktivasyon Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("Yazılımızın Full Sürüm Yapıldı.", "Aktivasyon", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Aktivasyon Gerçekleşmedi. İnternet Bağlantınızı Kontrol Ediniz.", "Aktivasyon Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Lütfen geçerli Lisans Anahtarınızı giriniz!", "Aktivasyon Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);


        }
    }
}
