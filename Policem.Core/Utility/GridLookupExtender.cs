using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Policem.Core.Utility
{
    public class GridLookupExtender
    {
        public GridLookupExtender(GridLookUpEdit gle)
        {
            Extend(gle);
        }
        public void Extend(GridLookUpEdit gle)
        {
            gle.PreviewKeyDown += new PreviewKeyDownEventHandler(gle_PreviewKeyDown);
            gle.MouseWheel += new MouseEventHandler(gle_MouseWheel);
            gle.Validating += new CancelEventHandler(gle_Validating);
            gle.InvalidValue += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(gle_InvalidValue);
        }

        void gle_MouseWheel(object sender, MouseEventArgs e)
        {
            GridLookUpEdit edit = (GridLookUpEdit)sender;
            {
                int RowHandle = edit.Properties.GetIndexByKeyValue(edit.EditValue);
                if (RowHandle < 0)
                {
                    RowHandle = 0;
                }
                if (Math.Abs(e.Delta) > 0)
                {
                    RowHandle -= Math.Abs(e.Delta) / e.Delta;
                }

                if (RowHandle >= 0 && RowHandle < edit.Properties.View.RowCount)
                {
                    edit.EditValue = edit.Properties.GetKeyValue(RowHandle);
                }
                isScrolling = true;
            }
        }

        bool isScrolling = false;
        void gle_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            GridLookUpEdit edit = (GridLookUpEdit)sender;
            {
                if ((e.KeyCode == Keys.Down | e.KeyCode == Keys.Up) & !(e.Modifiers == Keys.Alt))
                {
                    int RowHandle = edit.Properties.GetIndexByKeyValue(edit.EditValue);
                    if (RowHandle < 0)
                    {
                        RowHandle = 0;
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        RowHandle = RowHandle + 1;
                    }
                    else
                    {
                        RowHandle = RowHandle - 1;
                    }
                    if (RowHandle >= 0 && RowHandle < edit.Properties.View.RowCount)
                    {
                        edit.EditValue = edit.Properties.GetKeyValue(RowHandle);
                    }
                    isScrolling = true;
                }
            }
        }

        void gle_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = isScrolling;
            isScrolling = false;
        }

        void gle_InvalidValue(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

    }
}
