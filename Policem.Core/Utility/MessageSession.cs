using System.Timers;

namespace Policem.Core.Utility
{
    public class MessageSession
    {
        static Timer aTimer;

        public static string Mesaj { get; set; }
        public static int Durum { get; set; }

        private static bool otomatikSil;

        public static bool GetOtomatikSil()
        {
            return otomatikSil;
        }

        public static void SetOtomatikSil(bool value, int Sure)
        {
            otomatikSil = value;
            if (value)
            {
                //Belli Süre Sonra Otomatik Silme
                aTimer = new Timer();
                aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                aTimer.Interval = Sure;
                aTimer.Enabled = true;

            }
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Mesaj = "";
            aTimer.Enabled = false;
        }
    }
}
