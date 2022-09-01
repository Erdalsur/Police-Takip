using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using System.Xml;
using System.Xml.Serialization;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Policem.UI
{
    [Serializable]
    public class PrgSettings
    {
        public bool EnableAppearanceEvenRow = true;
        public string ZorunluAlanRengi = "Gold";//Color.FromName("Gold");
        public string SkinName = "Office 2010 Black";
        public string AktifAlanRengi ="Red";//Color.FromName("Gold");
        public string OutlookMailAdresi = "semsa@semsamakina.com";
        public int MuayeneTakvimHatirlatici = 5;
        public void Apply()
        {
            PrgSettings settings = new PrgSettings();
            settings.EnableAppearanceEvenRow = this.EnableAppearanceEvenRow;
            if (AppSession.PrgSettingsOrg.EnableAppearanceEvenRow != this.EnableAppearanceEvenRow)
                foreach (XtraForm form in AppSession.MainForm.MdiChildren)
                    SetEvenRow(form);
            settings.SkinName = this.SkinName;
            settings.ZorunluAlanRengi = this.ZorunluAlanRengi;
            settings.AktifAlanRengi = this.AktifAlanRengi;
            settings.OutlookMailAdresi = this.OutlookMailAdresi;
            settings.MuayeneTakvimHatirlatici = this.MuayeneTakvimHatirlatici;
            //if (Session.PrgSettingsOrg.AllowFormGlass != this.AllowFormGlass)
            //    Session.MainForm.AllowFormGlass = this.AllowFormGlass;
            //settings.AllowFormGlass = this.AllowFormGlass;




            AppSession.PrgSettingsOrg = settings;
        }

        public static PrgSettings LoadSettings(string xmlSettings)
        {
            if (xmlSettings.Trim() == string.Empty)
                return new PrgSettings();
            
            byte[] buffer = System.Text.Encoding.GetEncoding("ISO-8859-9").GetBytes(xmlSettings);
            MemoryStream fs = new MemoryStream(buffer);
            XmlReader reader = XmlReader.Create(fs);
            XmlSerializer serializer = new XmlSerializer(typeof(PrgSettings));
            PrgSettings oSettings = (PrgSettings)serializer.Deserialize(reader);
            fs.Close();

            return oSettings;
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PrgSettings));

            MemoryStream ms = new MemoryStream();
            serializer.Serialize(ms, this);
            ms.Seek(0, SeekOrigin.Begin);
            byte[] bytes = new byte[ms.Length];
            ms.Read(bytes, 0, (int)ms.Length);
            string xml = System.Text.Encoding.GetEncoding("ISO-8859-9").GetString(bytes);

            //Session.DataManager.ExecuteNonQuery("UpdUserSettings", Session.CurrentUser.UserId, xml);

            //Apply();

            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(PrgSettings));
            //MemoryStream memoryStream = new MemoryStream();
            //xmlSerializer.Serialize((Stream)memoryStream, (object)this);
            //memoryStream.Seek(0L, SeekOrigin.Begin);
            //byte[] numArray = new byte[memoryStream.Length];
            //memoryStream.Read(numArray, 0, (int)memoryStream.Length);
            File.WriteAllText("Settings.xml", Encoding.GetEncoding("ISO-8859-9").GetString(bytes));
            this.Apply();
        }

        private void SetEvenRow(Control Page)
        {
            foreach (Control control in (ArrangedElementCollection)Page.Controls)
            {
                if (control is GridControl)
                {
                    if ((control as GridControl).MainView is GridView)
                        ((control as GridControl).MainView as GridView).OptionsView.EnableAppearanceEvenRow = this.EnableAppearanceEvenRow;
                }
                else if (control.Controls.Count > 0)
                    this.SetEvenRow(control);
            }
        }
    }
}
