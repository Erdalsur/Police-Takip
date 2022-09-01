using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Policem.Data;
using Policem.UI.DependencyResolution;
using Policem.UI.Forms.Base;

namespace Policem.UI.Forms
{
    public partial class FrmPoliceOnizleme : XPopupForm
    {
        PoliceDosyaDetay policeDosyaDetay;
        public int DosyaId;
        public FrmPoliceOnizleme(int Id)
        {
            InitializeComponent();
            DosyaId = Id;
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            policeDosyaDetay = Session.PoliceDosyaService.GetById(DosyaId);
            this.Text = policeDosyaDetay.Aciklama + " " + this.Text;
            pdfViewer1.DetachStreamAfterLoadComplete = true;
            using (MemoryStream ms = new MemoryStream(policeDosyaDetay.Dosya))
                pdfViewer1.LoadDocument(ms);
        }
    }
}
