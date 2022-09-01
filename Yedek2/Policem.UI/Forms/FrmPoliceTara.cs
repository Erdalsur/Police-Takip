using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using Policem.Data;
using Policem.UI.Core.Peripheral;
using Policem.UI.Core.Peripheral.PoliceScan;
using Policem.UI.DependencyResolution;
using Policem.UI.Forms.Base;

namespace Policem.UI.Forms
{    
    public partial class FrmPoliceTara : XPopupForm
    {
        public bool Yeni = true;
        PoliceDosyaDetay policeDosyaDetay = new PoliceDosyaDetay();
        RichEditDocumentServer server = new RichEditDocumentServer();
        DocumentImage docImage;
        DocumentImage bosdocImage;
        List<Image> CevrilecekImages;
        public FrmPoliceTara(int PoliceID)
        {
            InitializeComponent();
            policeDosyaDetay.PoliceId = PoliceID;
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            policeDosyaDetay.DosyaType = "PDF";
            policeDosyaDetay.Aciklama = Session.PoliceService.GetById(policeDosyaDetay.PoliceId).Policelenen;
            policeDosyaDetay.Dosyalandimi = Data.Enums.EvetHayir.Hayır;
            docImage = null;
            CevrilecekImages=new List<Image>();
            ımageSlider1.Images.Clear();
            var durum = Session.PoliceDosyaService.GetPoliceById(policeDosyaDetay.PoliceId);
            if (durum.Count > 0)
            {
                Yeni = false;
                policeDosyaDetay.Id = durum.FirstOrDefault().Id;
            }
            else
                Yeni = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image ımage = Scanner.ScanImage();            
            CevrilecekImages.Add((Image)ımage);
            ımageSlider1.Images.Add(ımage);
            ımageSlider1.SlideNext();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            docImage=bosdocImage;
            server = new RichEditDocumentServer();
            var filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            foreach (Image image in CevrilecekImages)
                docImage = server.Document.Images.Append
                (DocumentImageSource.FromImage(image));
            server.Document.Sections[0].Page.Width = docImage.Size.Width;// + server.Document.Sections[0].Margins.Right + server.Document.Sections[0].Margins.Left;
            server.Document.Sections[0].Page.Height = docImage.Size.Height;// + server.Document.Sections[0].Margins.Top + server.Document.Sections[0].Margins.Bottom;
            server.Document.Sections[0].Margins.Left = 0;
            server.Document.Sections[0].Margins.Top = 0;
            server.Document.Sections[0].Margins.Right = 0;
            server.Document.Sections[0].Margins.Bottom = 0;

            using (System.IO.FileStream fs = new System.IO.FileStream(Session.TempDosyaYolu + "\\TarananPolice.pdf", System.IO.FileMode.Create))
            {
                server.ExportToPdf(fs);
                
            }
            policeDosyaDetay.Dosya = System.IO.File.ReadAllBytes(Session.TempDosyaYolu + "\\TarananPolice.pdf");
            if (Yeni)
            {
                policeDosyaDetay = Session.PoliceDosyaService.Add(policeDosyaDetay);
                var police = Session.PoliceService.GetById(policeDosyaDetay.PoliceId);
                police.PoliceGeldimi = Data.Enums.EvetHayir.Evet;
                police = Session.PoliceService.Update(police);
            }
            else
            {
                policeDosyaDetay = Session.PoliceDosyaService.Update(policeDosyaDetay);
                var police = Session.PoliceService.GetById(policeDosyaDetay.PoliceId);
                police.PoliceGeldimi = Data.Enums.EvetHayir.Evet;
                police = Session.PoliceService.Update(police);
            }
            Yeni = false;
            this.DialogResult = DialogResult.OK;
        }

        private void ımageSlider1_ContextButtonClick(object sender, DevExpress.Utils.ContextItemClickEventArgs e)
        {
            if (e.Item.Name == "btnSayfaSil")
            {
                var i = ımageSlider1.CurrentImageIndex;
                var durum=CevrilecekImages.Remove(CevrilecekImages[i]);
                ımageSlider1.Images.Remove(ımageSlider1.CurrentImage);
            }
        }
    }
}
