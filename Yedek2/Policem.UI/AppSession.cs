using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Policem.UI.Forms;

namespace Policem.UI
{
    public class AppSession
    {
        private static PrgSettings settings = (PrgSettings)null;
        private static PrgSettings prgSettingsOrg = (PrgSettings)null;
        public static RibbonMainForm mainForm;
        public static DateTime LaunchingTime;
        private static string version = (string)null;
        public static string ScannerDeviceId;

        public static RibbonMainForm MainForm
        {
            get
            {
                return AppSession.mainForm;
            }
            set
            {
                AppSession.mainForm = value;
            }
        }
        public static string Version
        {
            get
            {
                return AppSession.version;
            }
            set
            {
                AppSession.version = value;
            }
        }
        public static PrgSettings Settings
        {
            get
            {
                return AppSession.settings;
            }
            set
            {
                AppSession.settings = value;
            }
        }

        public static PrgSettings PrgSettingsOrg
        {
            get
            {
                return AppSession.prgSettingsOrg;
            }
            set
            {
                AppSession.prgSettingsOrg = value;
            }
        }
    }
}
