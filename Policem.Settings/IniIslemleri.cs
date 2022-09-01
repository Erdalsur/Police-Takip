using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Policem.Settings
{
    public static class ExtensionMethods
    {
        public static string ToUnsecureString(this SecureString secureString)
        {
            if (secureString == null) throw new ArgumentNullException("secureString");

            var unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        public static SecureString ToSecureString(this string unsecureString)
        {
            if (unsecureString == null) throw new ArgumentNullException("unsecureString");

            return unsecureString.Aggregate(new SecureString(), AppendChar, MakeReadOnly);
        }

        private static SecureString MakeReadOnly(SecureString ss)
        {
            ss.MakeReadOnly();
            return ss;
        }

        private static SecureString AppendChar(SecureString ss, char c)
        {
            ss.AppendChar(c);
            return ss;
        }
        //public static string UnWrap(this SecureString value)
        //{
        //    if (value == null) throw new ArgumentNullException("value");
        //    IntPtr ptr = Marshal.SecureStringToCoTaskMemUnicode(value);
        //    try
        //    {
        //        return Marshal.PtrToStringUni(ptr);
        //    }
        //    finally
        //    {
        //        Marshal.ZeroFreeCoTaskMemUnicode(ptr);
        //    }
        //}
        //public static SecureString ToSecureString(this string source)
        //{
        //    if (string.IsNullOrWhiteSpace(source))
        //        return null;
        //    else
        //    {
        //        SecureString result = new SecureString();
        //        foreach (char c in source.ToCharArray())
        //            result.AppendChar(c);
        //        return result;
        //    }
        //}
        //public static SecureString ToSecureString(this IEnumerable value)
        //{
        //    if (value == null) throw new ArgumentNullException("value");
        //    var secured = new SecureString();

        //    var charArray = value.ToString().ToArray();
        //    for (int i = 0; i < charArray.Length; i++)
        //    {
        //        secured.AppendChar(charArray[i]);
        //    }

        //    secured.MakeReadOnly();
        //    return secured;
        //}
        public static string Encrypt(this SecureString value)
        {

            if (value == null) throw new ArgumentNullException("value");

            IntPtr ptr = Marshal.SecureStringToCoTaskMemUnicode(value);
            try
            {
                char[] buffer = new char[value.Length];
                Marshal.Copy(ptr, buffer, 0, value.Length);

                byte[] data = Encoding.Unicode.GetBytes(buffer);
                byte[] encrypted = ProtectedData.Protect(data, null, DataProtectionScope.LocalMachine);

                return Convert.ToBase64String(encrypted);
            }
            finally
            {
                Marshal.ZeroFreeCoTaskMemUnicode(ptr);
            }
        }

        public static SecureString DecryptSecure(this string encryptedText)
        {
            if (encryptedText == null) throw new ArgumentNullException("encryptedText");

            byte[] data = Convert.FromBase64String(encryptedText);
            byte[] decrypted = ProtectedData.Unprotect(data, null, DataProtectionScope.LocalMachine);

            SecureString ss = new SecureString();

            int count = Encoding.Unicode.GetCharCount(decrypted);
            int bc = decrypted.Length / count;
            for (int i = 0; i < count; i++)
            {
                ss.AppendChar(Encoding.Unicode.GetChars(decrypted, i * bc, bc)[0]);
            }

            ss.MakeReadOnly();
            return ss;
        }
        public static DateTime GetFirstDateOfWeek(DateTime dayInWeek, CultureInfo cultureInfo)
        {
            // var culture = CultureInfo.CurrentCulture;
            // Culture üzerinden haftanın ilk gününün hangisi olduğu alınıyor (Pazar veya Pazartesi)
            var firstDay = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            var firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
                firstDayInWeek = firstDayInWeek.AddDays(-1);
            return firstDayInWeek;
        }
        public static DateTime GetDayDate(DateTime dayInWeek, CultureInfo cultureInfo, int day)
        {
            // var culture = CultureInfo.CurrentCulture;
            // Culture üzerinden haftanın ilk gününün hangisi olduğu alınıyor (Pazar veya Pazartesi)
            var firstDay = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            var firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
                firstDayInWeek = firstDayInWeek.AddDays(day);
            return firstDayInWeek;
        }

        public static DateTime AyinBaslangici(DateTime Tarih)
        {
            return new DateTime(Tarih.Year, Tarih.Month, 1);
        }

        public static DateTime YilBaslangici(DateTime Tarih)
        {
            return new DateTime(Tarih.Year, 1, 1);
        }

        public static DateTime AyinBitisi(DateTime Tarih)
        {
            Tarih = new DateTime(Tarih.Year, Tarih.Month, 1);
            return Tarih.AddMonths(1).AddDays(-1.0);
        }


        public static Bitmap ToBitmap(this byte[] bytes)
        {
            Bitmap bitmap = (Bitmap)null;
            using (MemoryStream memoryStream = new MemoryStream(bytes))
                bitmap = (Bitmap)Image.FromStream((Stream)memoryStream);
            return bitmap;
        }
        public static bool IsNumeric(this object Expression)
        {
            if (Expression == null || Expression is DateTime)
                return false;
            if (Expression is short || Expression is int || (Expression is long || Expression is Decimal) || (Expression is float || Expression is double) || Expression is bool)
                return true;
            try
            {
                if (Expression is string)
                    double.Parse(Expression as string);
                else
                    double.Parse(Expression.ToString());
                return true;
            }
            catch
            {
            }
            return false;
        }

        public static List<string> ReverseStringFormat(this string @string, string template)
        {
            // create matches list
            List<string> matches = null;

            // replace slashes
            template = Regex.Replace(template, @"[\\\^\$\.\|\?\*\+\(\)]", p => "\\" + p.Value);

            // replace index numbers
            var pattern = "^" + Regex.Replace(template, @"\{[0-9]+\}", "(.*?)") + "$";

            // get matches
            var match = new Regex(pattern).Match(@string);

            // if there is not any match, return null matches
            if (match.Groups.Count <= 0) return matches;

            // set list
            matches = new List<string>();

            // loop with match count
            for (var i = 1; i < match.Groups.Count; i++)
            {
                // add to matches list
                matches.Add(match.Groups[i].Value);
            }

            return matches;
        }

    }
    public static class CryptoManager
    {
        public static string Sifrele(string Sifresiz)
        {
            SecureString secureString = Sifresiz.ToSecureString();
            return secureString.Encrypt();
        }

        public static string SifreCoz(string Sifreli)
        {
            var secureString = Sifreli.DecryptSecure();
            return secureString.ToUnsecureString();
        }
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
