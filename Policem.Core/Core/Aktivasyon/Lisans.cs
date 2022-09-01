using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Net;
using System.Net.Mail;
using System.Reflection;

namespace Policem.Core.Core.Aktivasyon
{
    public class LisanslamaSistemi
    {
        public static String CPUSeriNoCek()
        {
            String processorID = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * FROM WIN32_Processor");
            ManagementObjectCollection mObject = searcher.Get();

            foreach (ManagementObject obj in mObject)
            {
                processorID = obj["ProcessorId"].ToString();
            }

            return processorID;
        }

        public static String SystemSeriNoCek()
        {
            String systemID = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * FROM WIN32_OperatingSystem");
            ManagementObjectCollection mObject = searcher.Get();

            foreach (ManagementObject obj in mObject)
            {
                systemID = obj["SerialNumber"].ToString();
            }

            return systemID;
        }
        /*
        string HDDserialNo = string.Empty;
        private void button2_Click(object sender, EventArgs e) //HDD Seri No
        {
            List<string> serialsList = HDDSeriNoCek();
            foreach (string s in serialsList)
            {
                HDDserialNo = HDDserialNo + s;
            }
            HDDserialNo = HDDserialNo.TrimStart(); //Baştaki Boşluğu Kaldırıyoruz.
            textBox2.Text = HDDserialNo;
        }
        */
        public static List<string> HDDSeriNoCek()
        {
            List<string> serials = new List<string>();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
            ManagementObjectCollection disks = searcher.Get();
            foreach (ManagementObject disk in disks)
            {
                if (disk["SerialNumber"] == null)
                    serials.Add("");
                else
                    serials.Add(disk["SerialNumber"].ToString());
            }
            return serials;
        }

        public static String LisansSeriUretimi()
        {
            string SerialCode;
            string HDDserialNo = string.Empty;
            string CPUseri = CPUSeriNoCek();
            string SystemSeri = SystemSeriNoCek();
            List<string> serialsList = HDDSeriNoCek();
            foreach (string s in serialsList)
            {
                HDDserialNo = HDDserialNo + s;
            }
            HDDserialNo = HDDserialNo.TrimStart();
            SerialCode = CPUseri.Substring(0, 4);
            SerialCode += "-" + SystemSeri.Substring(0, 4);
            SerialCode += "-" + CPUseri.Substring(4, 4);
            SerialCode += "-" + SystemSeri.Substring(10, 4);
            return SerialCode;
        }

        public static bool LisansKontrol(string Anahtar, string KontrolLisans)
        {
            bool Kontrol = false;
            string _Key = null;
            string _deger1 = null, _deger2 = null, _deger3 = null, _deger4 = null, _deger5 = null, _deger6 = null, _deger7 = null, _deger8 = null, _deger9 = null, _deger10 = null, _deger11 = null, _deger12 = null;
            //  (Math.Abs((Seri10 - Seri1 + Seri5 +Seri4 + Seri7) * 19 * (seri8 + seri2))) % 10)
            _deger1 = (Math.Abs(

                 (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(11, 1)))//Convert.ToInt32(Convert.ToChar(kelime.Substring(i, 1))).ToString()
                - Convert.ToInt16(Convert.ToChar(Anahtar.Substring(0, 1)))
                + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(5, 1)))
                + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(3, 1)))
                + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(7, 1))))
                * 19
                * (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(8, 1)))
                + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(1, 1))))) % 10).ToString();

            //  (Math.Abs(( Seri10 + Seri11 – Seri12 + Seri8) - (Seri8 + (Seri5 + Seri3)))* 7) % 10)
            _deger2 = (Math.Abs(

                 (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(11, 1)))
                + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(12, 1)))
                - Convert.ToInt16(Convert.ToChar(Anahtar.Substring(13, 1)))
                + Convert.ToInt16(Anahtar.Substring(8, 1)))

                - (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(8, 1)))
                + (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(5, 1)))
                + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(2, 1))))) * 7) % 10).ToString();
            //
            _deger3 = (Math.Abs(
               (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(5, 1)))
              * Convert.ToInt16(Convert.ToChar(Anahtar.Substring(8, 1)))
              * Convert.ToInt16(Convert.ToChar(Anahtar.Substring(6, 1)))
              + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(3, 1))))

              - (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(10, 1)))
              * (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(8, 1)))
              + (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(2, 1)))
              * (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(1, 1)))
              + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(0, 1))))))) * 19) % 10).ToString();
            // (Math.Abs((Seri9 - Seri1 + Seri5 + Seri4 + Seri7) - 19 - (Seri9 + Seri2)) % 10)
            _deger4 = (Math.Abs(

                            (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(10, 1)))
                           - Convert.ToInt16(Convert.ToChar(Anahtar.Substring(0, 1)))
                           + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(5, 1)))
                           + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(3, 1)))
                           + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(8, 1))))
                           - 19
                           - (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(10, 1)))
                           + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(1, 1))))) % 10).ToString();
            //
            _deger5 = (Math.Abs(

                  (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(10, 1)))
                 + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(15, 1)))
                 * Convert.ToInt16(Convert.ToChar(Anahtar.Substring(5, 1)))
                 + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(0, 1))))

                 - (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(5, 1)))
                 + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(6, 1)))
                 - Convert.ToInt16(Convert.ToChar(Anahtar.Substring(8, 1)))
                 + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(0, 1)))
                 - Convert.ToInt16(Convert.ToChar(Anahtar.Substring(1, 1)))) + 19) % 10).ToString();
            //
            _deger6 = (Math.Abs(

                 (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(1, 1)))
                * Convert.ToInt16(Convert.ToChar(Anahtar.Substring(4, 1)))
                * Convert.ToInt16(Convert.ToChar(Anahtar.Substring(6, 1)))
                * Convert.ToInt16(Convert.ToChar(Anahtar.Substring(9, 1))))

                + (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(2, 1)))
                + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(6, 1)))
                + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(10, 1)))
                + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(14, 1)))
                + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(15, 1)))) - 19) % 10).ToString();
            _deger7 = (Math.Abs(

               (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(12, 1)))
              + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(18, 1)))
              + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(15, 1))))
              * Convert.ToInt16(Convert.ToChar(Anahtar.Substring(13, 1)))

              + (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(8, 1)))
              + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(17, 1)))
              + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(0, 1)))
              - Convert.ToInt16(Convert.ToChar(Anahtar.Substring(2, 1)))
              - Convert.ToInt16(Convert.ToChar(Anahtar.Substring(6, 1)))
              - Convert.ToInt16(Convert.ToChar(Anahtar.Substring(16, 1)))) * 6) % 10).ToString();
            //
            _deger8 = (Math.Abs(

                             (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(13, 1)))
                            + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(16, 1)))
                            - Convert.ToInt16(Convert.ToChar(Anahtar.Substring(15, 1)))
                            + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(10, 1))))

                            + (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(10, 1)))
                            + (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(6, 1)))
                            + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(2, 1))))) * 19) % 10).ToString();

            //
            _deger9 = (Math.Abs(

              (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(12, 1)))
             + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(18, 1)))
             + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(15, 1))))

             * Convert.ToInt16(Convert.ToChar(Anahtar.Substring(13, 1)))

             + (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(8, 1)))
             + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(5, 1)))
             + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(0, 1)))
             - Convert.ToInt16(Convert.ToChar(Anahtar.Substring(2, 1)))
             - Convert.ToInt16(Convert.ToChar(Anahtar.Substring(6, 1)))
             - Convert.ToInt16(Convert.ToChar(Anahtar.Substring(15, 1)))) * 6) % 10).ToString();


            //          
            _deger10 = (Math.Abs(

                (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(13, 1)))
               + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(16, 1)))
               - Convert.ToInt16(Convert.ToChar(Anahtar.Substring(15, 1)))
               + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(10, 1))))

               - (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(10, 1)))
               + (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(6, 1)))
               + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(2, 1))))) * 7) % 10).ToString();



            //

            _deger11 = (Math.Abs(
               (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(6, 1)))
              * Convert.ToInt16(Convert.ToChar(Anahtar.Substring(8, 1)))
              * Convert.ToInt16(Convert.ToChar(Anahtar.Substring(11, 1)))
              + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(1, 1))))

              * (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(13, 1)))
              * (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(0, 1)))
              * (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(8, 1)))
              * (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(3, 1)))
              + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(12, 1))))))) + 4) % 10).ToString();

            //
            _deger12 = (Math.Abs(
               (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(5, 1)))
              * Convert.ToInt16(Convert.ToChar(Anahtar.Substring(8, 1)))
              * Convert.ToInt16(Convert.ToChar(Anahtar.Substring(6, 1)))
              + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(3, 1))))

              - (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(10, 1)))
              * (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(8, 1)))
              + (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(2, 1)))
              * (Convert.ToInt16(Convert.ToChar(Anahtar.Substring(1, 1)))
              + Convert.ToInt16(Convert.ToChar(Anahtar.Substring(0, 1))))))) * 19) % 10).ToString();

            _Key = _deger1 + _deger2 + _deger3 + _deger4 + "-" + _deger5 + _deger6 + _deger7 + _deger8 + "-" + _deger9 + _deger10 + _deger11 + _deger12;

            if (KontrolLisans == _Key)
                Kontrol = true;
            else
                Kontrol = false;
            return Kontrol;
        }

        public static bool SetKey(string serial, string AktivasyonKodu, string Ad, string Firma, string Email)
        {
            bool durum = false;
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\ErSu\" +fvi.ProductName , "Key", serial);
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\ErSu\" + fvi.ProductName, "ProductKey", AktivasyonKodu);
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\ErSu\" + fvi.ProductName, "RegisterUser", Ad);
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\ErSu\" + fvi.ProductName, "RegisterCompany", Firma);
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\ErSu\" + fvi.ProductName, "Email", Email);
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\ErSu\" + fvi.ProductName, "Datetime", DateTime.Now.ToShortDateString());
                durum = true;

            }
            catch (Exception ex)
            {
                durum = false;
            }
            return durum;
        }
    }
    public class Gmail
    {
        public static string MailIcerigi = null;
        public static bool LisansMailGonder(string Ad, string Sirket, string Email, string AktivasyonCode, string LisnsCode)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            bool Kontrol;
            //Mail İçeriğini Hazırla
            MailIcerigi = fvi.ProductName + " Yazılımı Lisans Aktifleştirmesi Bilgileri Aşağıda <br/>";
            MailIcerigi += "Adi   : " + Ad + " <br/>";
            MailIcerigi += "Firma : " + Sirket + " <br/>";
            MailIcerigi += "Email : " + Email + " <br/>";
            MailIcerigi += "A.Code: " + AktivasyonCode + " <br/><br/>";
            MailIcerigi += "L.Code: " + LisnsCode + " <br/>";
            MailIcerigi += "Tarih : " + DateTime.Now.ToShortDateString() + " <br/>";
            Kontrol = mailGonder("erdalsur@hotmail.com", fvi.ProductName+" Yazılımı Lisans İşlemi Gerçekleşti.", MailIcerigi);
            return Kontrol;
        }

        public static bool mailGonder(string Kime, string Konu, string Icerik)
        {
            bool Kontrol;
            try
            {
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.live.com");
                mailMessage.From = new MailAddress("erdalsur@hotmail.com");
                mailMessage.To.Add(Kime);
                mailMessage.Subject = Konu;
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = Icerik;

                smtpClient.Port = 25;
                smtpClient.Credentials = new NetworkCredential("erdalsur@hotmail.com", "alewim@alewim");
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);
                Kontrol = true;
            }
            catch
            {
                Kontrol = false;
            }
            return Kontrol;
        }
    }
}
