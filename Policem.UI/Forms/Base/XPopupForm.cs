using System;
using System.Windows.Forms;

namespace Policem.UI.Forms.Base
{
    public partial class XPopupForm : XForm
    {
        private bool escCloses = true;
        public XPopupForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(this.XPopupForm_KeyDown);
        }
        public bool ESCCloses
        {
            get
            {
                return this.escCloses;
            }
            set
            {
                this.escCloses = value;
            }
        }
        private void XPopupForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!this.ESCCloses || e.KeyCode != Keys.Escape)
                return;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        

        private void XPopupForm_Load(object sender, EventArgs e)
        {

        }
    }
}