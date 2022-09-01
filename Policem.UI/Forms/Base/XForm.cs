using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace Policem.UI.Forms.Base
{
    public partial class XForm : XtraForm
    {
        public XForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void XForm_Load(object sender, EventArgs e)
        {

        }
        public void InitGridView(GridView gridview)
        {
            try
            {
                if (AppSession.Settings.EnableAppearanceEvenRow)
                {
                    gridview.Appearance.OddRow.BackColor = Color.AliceBlue;
                    gridview.Appearance.EvenRow.BackColor = Color.White;
                }
                else
                {
                    gridview.Appearance.OddRow.BackColor = Color.AliceBlue;
                    gridview.Appearance.EvenRow.BackColor = Color.White;
                }
                gridview.OptionsView.EnableAppearanceOddRow = AppSession.Settings.EnableAppearanceEvenRow;
                
                gridview.OptionsView.RowAutoHeight = true;
                gridview.OptionsView.ShowAutoFilterRow = true;
                gridview.OptionsView.ShowDetailButtons = false;
                gridview.OptionsView.ShowGroupPanel = false;
                gridview.OptionsHint.ShowColumnHeaderHints = true;
                gridview.OptionsMenu.EnableColumnMenu = true;
                gridview.OptionsSelection.MultiSelect = false;
                gridview.ViewCaption = gridview.ViewCaption.Replace("gv", string.Empty);
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
            finally
            {
                //gridview.EndUpdate();
            }
        }
    }
}