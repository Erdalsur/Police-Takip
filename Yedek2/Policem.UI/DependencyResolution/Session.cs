using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Policem.Core.Business.Abstract;
using Policem.Core.Utility;
using Policem.Data;


namespace Policem.UI.DependencyResolution
{
    public class Session
    {
        public Session(IPoliceService policeService, IPoliceMusteriService musteriService, ISigortaFirmaService sigortaService, IPoliceDosyaService policeDosyaService)
        {
            
            PoliceService = policeService;
            FirmaService = musteriService;
            SigortaciService = sigortaService;
            PoliceDosyaService = policeDosyaService;
            AppDosyaYolu = Application.StartupPath.ToString();
            if (Directory.Exists(AppDosyaYolu + "\\Temp"))
                TempDosyaYolu = AppDosyaYolu + "\\Temp";
            else
            {
                Directory.CreateDirectory("Temp");
                TempDosyaYolu = AppDosyaYolu + "\\Temp";
            }
            SmptService = new StmpSettingsPolice();
            SmptService.Host = IniIslemleri.VeriOku("MailSetting", "Host");
            SmptService.Port = Convert.ToInt32(IniIslemleri.VeriOku("MailSetting", "Port"));
            var ssl = IniIslemleri.VeriOku("MailSetting", "SSL");
            if (ssl == "True")
                SmptService.SSL = true;
            else
                SmptService.SSL = false;
            SmptService.Kullanici = true;
            SmptService.KullaniciAdi = IniIslemleri.VeriOku("MailSetting", "Kullanici");
            SmptService.Sifre = CryptoManager.SifreCoz(IniIslemleri.VeriOku("MailSetting", "Password"));
            MailGonderilecekAdresler = IniIslemleri.VeriOku("Guvercin", "Adres");
            //MailGonderilecekAdresler = "erdal@semsamakina.com;erdalsur@hotmail.com";
        }

        public static StmpSettingsPolice SmptService;
        public static IPoliceService PoliceService;
        public static IPoliceMusteriService FirmaService;
        public static ISigortaFirmaService SigortaciService;
        public static IPoliceDosyaService PoliceDosyaService;
        public static string TempDosyaYolu;
        public static string AppDosyaYolu;
        public static string MailGonderilecekAdresler;
    }

    public static class IniIslemleri
    {
        //Sınıfımızı Extension Method olarak kullanmak istediğimiz için static tanımlıyoruz.

        static string dizinYolu = Application.StartupPath.ToString();
        static string dosyaAdi = dizinYolu + "\\Ayarlar.ini";


        //Yazma işlemleri için gerekli olan dll'i import edip, ini için WritePrivateProfileString metodunun görüntüsünü aldık
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool WritePrivateProfileString(string kategori, string anahtar, string deger, string dosyaAdi);


        //Yazma işlemleri için gerekli olan dll'i import edip, ini için GetPrivateProfileString metodunun görüntüsünü aldık
        [DllImport("kernel32.dll")]
        static extern uint GetPrivateProfileString(string kategori, string anahtar, string lpDefault, StringBuilder sb, int sbKapasite, string dosyaAdi);

        public static bool VeriYaz(string kategori, string anahtar, string deger)
        {
            if (!Directory.Exists(dizinYolu)) //Dizin yoksa oluşturalım.
                Directory.CreateDirectory(dizinYolu);

            return WritePrivateProfileString(kategori, anahtar, deger, dosyaAdi);
        }

        public static string VeriOku(string kategori, string anahtar)
        {
            //Okunacak veriyi okumak ve kapasitesini sınırlandırmak ve performans için StringBuilder sınıfını kullanıyoruz.
            StringBuilder sb = new StringBuilder(500);

            GetPrivateProfileString(kategori, anahtar, "", sb, sb.Capacity, dosyaAdi);

            string veri = sb.ToString();
            sb.Clear();
            return veri;
        }
    }
}
