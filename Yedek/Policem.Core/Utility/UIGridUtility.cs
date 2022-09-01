using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace Policem.Core.Utility
{
    public static class UIGridUtility
    {
        public static void GridAlanGizle(GridView gridview, string Alan)
        {
            string str = Alan;
            char[] chArray = new char[1] { ';' };
            foreach (string index in str.Split(chArray))
            {
                try
                {
                    gridview.Columns[index].Visible = false;
                }
                catch
                {
                }
            }
        }

        
        public static void AddGroupSummary(GridView gv, params string[] flds)
        {
            gv.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
            foreach (string fld in flds)
            {
                GridGroupSummaryItem groupSummaryItem = new GridGroupSummaryItem();
                if (fld == "Toplam Kayıt")
                {
                    foreach (GridColumn column in (CollectionBase)gv.Columns)
                    {
                        if (column.Visible)
                        {
                            groupSummaryItem.FieldName = column.FieldName;
                            groupSummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                            groupSummaryItem.DisplayFormat = "{0:#,##0} Kayıtlar";
                            break;
                        }
                    }
                }
                else
                {
                    groupSummaryItem.FieldName = fld;
                    groupSummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    groupSummaryItem.DisplayFormat = "{0:#,##0.00}";
                }
                groupSummaryItem.ShowInGroupColumnFooter = gv.Columns[fld];
                gv.GroupSummary.Add((GridSummaryItem)groupSummaryItem);
            }
        }
    }
}
