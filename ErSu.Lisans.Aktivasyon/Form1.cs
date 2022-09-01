using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ErSu.Lisans.Aktivasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGanerate_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 19)
            {
                textBox2.Text = LisansKodUret(textBox1.Text);
            }
            else
                MessageBox.Show("Hatalı Aktivasyon Kodu", "Hata");
        }

        public static String LisansKodUret(string Anahtar)
        {
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

            return _Key;
        }
    }
}
