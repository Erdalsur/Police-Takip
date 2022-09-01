using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Policem.Core.Utility
{
    public class ControlColorizer
    {
        private Color _setBColor = SystemColors.Window;
        private Color _setBCol = SystemColors.Window;

        public ControlColorizer(Color color, Color Back, params Control[] ctls)
        {
            this._setBColor = color;
            this._setBCol = Back;
            foreach (Control ctl in ctls)
            {
                ctl.Enter += new EventHandler(this.O_Enter);
                ctl.Leave += new EventHandler(this.O_Leave);
            }
        }

        public void ControlColor(Color bkg, Color Back2, params Control[] ctls)
        {
            this._setBColor = bkg;
            this._setBCol = Back2;
            foreach (Control ctl in ctls)
            {
                ctl.Enter += new EventHandler(this.O_Enter);
                ctl.Leave += new EventHandler(this.O_Leave);
            }
        }

        private void O_Enter(object sender, EventArgs e)
        {
            if (!(sender is Control))
                return;
            ((Control)sender).BackColor = this._setBColor;
        }

        private void O_Leave(object sender, EventArgs e)
        {
            (sender as Control).BackColor = this._setBCol;
        }
    }
}
