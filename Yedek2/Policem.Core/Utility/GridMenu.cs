using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Policem.Core.Utility
{
    public class GridMenu
    {
        private List<EventHandler> customEvents = new List<EventHandler>();
        private List<EventHandler> customColumnEvents = new List<EventHandler>();
        private DXSubMenuItem miDuzenle = new DXSubMenuItem("Edit");
        private bool isReadOnly = false;
        private string currentColumnName = "";
        private string currentBandName = "";
        private GridManager gridManager;
        private GridViewMenu customMenu;
        private GridViewMenu customColumnMenu;
        public GridViewMenu RowMenu;
        public GridViewMenu ColumnMenu;

        public GridManager GridManager
        {
            get
            {
                return this.gridManager;
            }
            set
            {
                this.gridManager = value;
            }
        }

        public GridView GridView
        {
            get
            {
                return this.GridManager.GridView;
            }
        }

        public GridUtility Utility
        {
            get
            {
                return this.GridManager.gridUtility;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return this.isReadOnly;
            }
            set
            {
                this.isReadOnly = value;
                this.CreateRowMenu();
            }
        }

        public GridMenu(GridManager gridManager)
        {
            this.GridManager = gridManager;
            this.customMenu = new GridViewMenu(this.GridView);
            this.customColumnMenu = new GridViewMenu(this.GridView);
            this.miDuzenle = new DXSubMenuItem("Edit");
            this.CreateRowMenu();
            //this.CreateColumnMenu();
        }

        public string CurrentColumnName
        {
            get
            {
                return this.currentColumnName;
            }
            set
            {
                this.currentColumnName = value;
                this.CreateColumnMenu();
            }
        }

        public string CurrentBandName
        {
            get
            {
                return this.currentBandName;
            }
            set
            {
                this.currentBandName = value;
                this.CreateColumnMenu();
            }
        }

        public void CreateColumnMenu()
        {
            //this.ColumnMenu = new GridViewMenu(this.GridView);
            //if (this.CurrentColumnName != "" && this.CurrentColumnName != "DX$CheckboxSelectorColumn")
            //{
            //    DXSubMenuItem dxSubMenuItem = new DXSubMenuItem("Dondur");
            //    dxSubMenuItem.BeginGroup = true;
            //    DXMenuCheckItem dxMenuCheckItem1 = new DXMenuCheckItem();
            //    dxMenuCheckItem1.Checked = this.GridView.Columns[this.CurrentColumnName].Fixed == FixedStyle.Left;
            //    dxMenuCheckItem1.Caption = "Bu sütunu";
            //    dxMenuCheckItem1.CheckedChanged += new EventHandler(this.chkDondur_CheckedChanged);
            //    dxSubMenuItem.Items.Add((DXMenuItem)dxMenuCheckItem1);
            //    DXMenuCheckItem dxMenuCheckItem2 = new DXMenuCheckItem();
            //    dxMenuCheckItem2.Caption = "Bu ve solundaki sütunları";
            //    dxMenuCheckItem2.Checked = this.GridView.Columns[this.CurrentColumnName].Fixed == FixedStyle.Left;
            //    dxMenuCheckItem2.CheckedChanged += new EventHandler(this.chk_SoldanDondur);
            //    dxSubMenuItem.Items.Add((DXMenuItem)dxMenuCheckItem2);
            //    this.ColumnMenu.Items.Add((DXMenuItem)dxSubMenuItem);
            //}
            //else if (this.CurrentBandName != "")
            //{
            //    DXMenuCheckItem dxMenuCheckItem = new DXMenuCheckItem();
            //    dxMenuCheckItem.BeginGroup = true;
            //    BandedGridView gridView = (BandedGridView)this.GridView;
            //    dxMenuCheckItem.Checked = gridView.Bands[this.CurrentBandName].Fixed == FixedStyle.Left;
            //    dxMenuCheckItem.Caption = "Bu bandı dondur";
            //    dxMenuCheckItem.CheckedChanged += new EventHandler(this.chkBandiDondur_CheckedChanged);
            //    this.ColumnMenu.Items.Add((DXMenuItem)dxMenuCheckItem);
            //}
            //this.ColumnMenu.Items.Add(new DXMenuItem("Hücre Birleştir/Ayır", new EventHandler(this.AllowCellMerge_Click)));
            //DXSubMenuItem dxSubMenuItem1 = new DXSubMenuItem("Görünüm Özellikleri");
            //dxSubMenuItem1.BeginGroup = true;
            //this.ColumnMenu.Items.Add((DXMenuItem)dxSubMenuItem1);
            //DXSubMenuItem dxSubMenuItem2 = new DXSubMenuItem("Davranış Özellikleri");
            //this.ColumnMenu.Items.Add((DXMenuItem)dxSubMenuItem2);
            //DXSubMenuItem dxSubMenuItem3 = new DXSubMenuItem("Değişiklik Özellikleri");
            //this.ColumnMenu.Items.Add((DXMenuItem)dxSubMenuItem3);
            //DXSubMenuItem dxSubMenuItem4 = new DXSubMenuItem("Detay Özellikleri");
            //this.ColumnMenu.Items.Add((DXMenuItem)dxSubMenuItem4);
            //DXSubMenuItem dxSubMenuItem5 = new DXSubMenuItem("Navigasyon Özellikleri");
            //this.ColumnMenu.Items.Add((DXMenuItem)dxSubMenuItem5);
            //DXSubMenuItem dxSubMenuItem6 = new DXSubMenuItem("Yazdırma Özellikleri");
            //this.ColumnMenu.Items.Add((DXMenuItem)dxSubMenuItem6);


            
            //dxSubMenuItem1.Items.Add((DXMenuItem)new DXMenuCheckItem("Otomatik Filtreleme Satırı", this.GridView.OptionsView.ShowAutoFilterRow, (Image)null, new EventHandler(this.AutoFilterRow_Click)));
            //dxSubMenuItem1.Items.Add((DXMenuItem)new DXMenuCheckItem("Dipnot Alanı", this.GridView.OptionsView.ShowFooter, (Image)null, new EventHandler(this.ShowFooter_Click)));
            //DXMenuCheckItem dxMenuCheckItem3 = new DXMenuCheckItem("Otomatik Kolon Genişliği", this.GridView.OptionsView.ColumnAutoWidth, (Image)null, new EventHandler(this.ColumnAutoWidth_Click));
            //dxMenuCheckItem3.BeginGroup = true;
            //dxSubMenuItem1.Items.Add((DXMenuItem)dxMenuCheckItem3);
            //dxSubMenuItem1.Items.Add((DXMenuItem)new DXMenuCheckItem("Sütun Başlıkları", this.GridView.OptionsView.ShowColumnHeaders, (Image)null, new EventHandler(this.ShowColumnHeaders_Click)));
            //dxSubMenuItem1.Items.Add((DXMenuItem)new DXMenuCheckItem("Detay Butonları", this.GridView.OptionsView.ShowDetailButtons, (Image)null, new EventHandler(this.ShowDetailButtons_Click)));
            //DXSubMenuItem dxSubMenuItem8 = new DXSubMenuItem("Filtreleme Paneli Modu");
            //dxSubMenuItem1.Items.Add((DXMenuItem)dxSubMenuItem8);
            //DXMenuCheckItem dxMenuCheckItem4 = new DXMenuCheckItem("Normal", this.GridView.OptionsView.ShowFilterPanelMode == ShowFilterPanelMode.Default, (Image)null, new EventHandler(this.ShowFilterPanelModeDefault_Click));
            //dxSubMenuItem8.Items.Add((DXMenuItem)dxMenuCheckItem4);
            //DXMenuCheckItem dxMenuCheckItem5 = new DXMenuCheckItem("Daima", this.GridView.OptionsView.ShowFilterPanelMode == ShowFilterPanelMode.ShowAlways, (Image)null, new EventHandler(this.ShowFilterPanelModeShowAlways_Click));
            //dxSubMenuItem8.Items.Add((DXMenuItem)dxMenuCheckItem5);
            //DXMenuCheckItem dxMenuCheckItem6 = new DXMenuCheckItem("Asla", this.GridView.OptionsView.ShowFilterPanelMode == ShowFilterPanelMode.Never, (Image)null, new EventHandler(this.ShowFilterPanelModeNever_Click));
            //dxSubMenuItem8.Items.Add((DXMenuItem)dxMenuCheckItem6);
            //dxSubMenuItem1.Items.Add((DXMenuItem)new DXMenuCheckItem("Gruplanan Sütunları Göster", this.GridView.OptionsView.ShowGroupedColumns, (Image)null, new EventHandler(this.ShowGroupedColumns_Click)));
            //dxSubMenuItem1.Items.Add((DXMenuItem)new DXMenuCheckItem("İmleci Göster", this.GridView.OptionsView.ShowIndicator, (Image)null, new EventHandler(this.ShowIndicator_Click)));
            //DXMenuCheckItem dxMenuCheckItem7 = new DXMenuCheckItem("Önİzleme", this.GridView.OptionsView.ShowPreview, (Image)null, new EventHandler(this.ShowPreview_Click));
            
            
            
            //dxSubMenuItem2.Items.Add((DXMenuItem)new DXMenuCheckItem("Ardışık Arama", GridView.OptionsBehavior.AllowIncrementalSearch, (Image)null, new EventHandler(this.AllowIncrementalSearch_Click)));
            //dxSubMenuItem2.Items.Add((DXMenuItem)new DXMenuCheckItem("Scrollda Kısmi Satır", GridView.OptionsBehavior.AllowPartialRedrawOnScrolling, (Image)null, new EventHandler(this.AllowPartialRedrawOnScrolling_Click)));
            //dxSubMenuItem2.Items.Add((DXMenuItem)new DXMenuCheckItem("Tüm Grupları Otomatik Aç", GridView.OptionsBehavior.AutoExpandAllGroups, (Image)null, new EventHandler(this.AutoExpandAllGroups_Click)));
            //dxSubMenuItem2.Items.Add(new DXMenuCheckItem("Alan Editte Tüm Değerleri Seç", GridView.OptionsBehavior.AutoSelectAllInEditor, (Image)null, new EventHandler(this.AutoSelectAllInEditor_Click)));
            //dxSubMenuItem2.Items.Add(new DXMenuCheckItem("Sütun başlıkları ile kopyala", GridView.OptionsBehavior.CopyToClipboardWithColumnHeaders, (Image)null, new EventHandler(CopyToClipboardWithColumnHeaders_Click)));
            //DXMenuCheckItem dxMenuCheckItem9 = new DXMenuCheckItem("Çoklu Seçme", GridView.OptionsSelection.MultiSelect, (Image)null, new EventHandler(this.MultiSelect_Click));
            //dxMenuCheckItem9.BeginGroup = true;
            //dxSubMenuItem2.Items.Add((DXMenuItem)dxMenuCheckItem9);
            //DXSubMenuItem dxSubMenuItem9 = new DXSubMenuItem("Çoklu Seçme Modu");
            //dxSubMenuItem2.Items.Add((DXMenuItem)dxSubMenuItem9);
            //DXMenuCheckItem dxMenuCheckItem10 = new DXMenuCheckItem("Satır", this.GridView.OptionsSelection.MultiSelectMode == GridMultiSelectMode.RowSelect, (Image)null, new EventHandler(this.MultiSelectRow_Click));
            //dxSubMenuItem9.Items.Add((DXMenuItem)dxMenuCheckItem10);
            //DXMenuCheckItem dxMenuCheckItem11 = new DXMenuCheckItem("Hücre", this.GridView.OptionsSelection.MultiSelectMode == GridMultiSelectMode.CellSelect, (Image)null, new EventHandler(this.MultiSelectCell_Click));
            //dxSubMenuItem9.Items.Add((DXMenuItem)dxMenuCheckItem11);
            //dxSubMenuItem3.Items.Add((DXMenuItem)new DXMenuCheckItem("Sütun Kaydırma", this.GridView.OptionsCustomization.AllowColumnMoving, (Image)null, new EventHandler(this.AllowColumnMoving_Click)));
            //dxSubMenuItem3.Items.Add((DXMenuItem)new DXMenuCheckItem("Sütun Genişletme", this.GridView.OptionsCustomization.AllowColumnResizing, (Image)null, new EventHandler(this.AllowColumnResizing_Click)));
            //dxSubMenuItem3.Items.Add((DXMenuItem)new DXMenuCheckItem("Satır Genişletme", this.GridView.OptionsCustomization.AllowRowSizing, (Image)null, new EventHandler(this.AllowRowSizing_Click)));
            //DXMenuCheckItem dxMenuCheckItem12 = new DXMenuCheckItem("Filtreleme", this.GridView.OptionsCustomization.AllowFilter, (Image)null, new EventHandler(this.AllowFilter_Click));
            //dxMenuCheckItem12.BeginGroup = true;
            //dxSubMenuItem2.Items.Add((DXMenuItem)dxMenuCheckItem12);
            //dxSubMenuItem3.Items.Add((DXMenuItem)new DXMenuCheckItem("Gruplama", this.GridView.OptionsCustomization.AllowGroup, (Image)null, new EventHandler(this.AllowGroup_Click)));
            //dxSubMenuItem3.Items.Add((DXMenuItem)new DXMenuCheckItem("Sıralama", this.GridView.OptionsCustomization.AllowSort, (Image)null, new EventHandler(this.AllowSort_Click)));
            //dxSubMenuItem4.Items.Add((DXMenuItem)new DXMenuCheckItem("Boş Detayları Aç", this.GridView.OptionsDetail.AllowExpandEmptyDetails, (Image)null, new EventHandler(this.AllowExpandEmptyDetails_Click)));
            //dxSubMenuItem4.Items.Add((DXMenuItem)new DXMenuCheckItem("Aynı Anda Tek Master Satırı Açılabilsin", this.GridView.OptionsDetail.AllowOnlyOneMasterRowExpanded, (Image)null, new EventHandler(this.AllowOnlyOneMasterRowExpanded_Click)));
            //dxSubMenuItem4.Items.Add((DXMenuItem)new DXMenuCheckItem("Detay Odaklaması Olsun", this.GridView.OptionsDetail.AllowZoomDetail, (Image)null, new EventHandler(this.AllowZoomDetail_Click)));
            //dxSubMenuItem4.Items.Add((DXMenuItem)new DXMenuCheckItem("Otomatik Detay Odaklaması", this.GridView.OptionsDetail.AutoZoomDetail, (Image)null, new EventHandler(this.AutoZoomDetail_Click)));
            //dxSubMenuItem4.Items.Add((DXMenuItem)new DXMenuCheckItem("Detay İpuçlarını Göster", this.GridView.OptionsDetail.EnableDetailToolTip, (Image)null, new EventHandler(this.EnableDetailToolTip_Click)));
            //dxSubMenuItem4.Items.Add((DXMenuItem)new DXMenuCheckItem("Master Kayıtlar Açılabilsin", this.GridView.OptionsDetail.EnableMasterViewMode, (Image)null, new EventHandler(this.EnableMasterViewMode_Click)));
            //dxSubMenuItem4.Items.Add((DXMenuItem)new DXMenuCheckItem("Detay Tab Başlıklarını Göster", this.GridView.OptionsDetail.ShowDetailTabs, (Image)null, new EventHandler(this.ShowDetailTabs_Click)));
            //dxSubMenuItem5.Items.Add((DXMenuItem)new DXMenuCheckItem("Yeni Kayda Otomatik Geç", this.GridView.OptionsNavigation.AutoFocusNewRow, (Image)null, new EventHandler(this.AutoFocusNewRow_Click)));
            //dxSubMenuItem5.Items.Add((DXMenuItem)new DXMenuCheckItem("Enter Tuşu Sonraki Sütuna Geçirsin", this.GridView.OptionsNavigation.EnterMoveNextColumn, (Image)null, new EventHandler(this.EnterMoveNextColumn_Click)));
            //dxSubMenuItem5.Items.Add((DXMenuItem)new DXMenuCheckItem("Tab Tuşu Sonraki Sütuna Geçirsin", this.GridView.OptionsNavigation.UseTabKey, (Image)null, new EventHandler(this.UseTabKey_Click)));
            //dxSubMenuItem5.Items.Add((DXMenuItem)new DXMenuCheckItem("Tab Tuşu Diğer Kontrole Geçirsin", this.GridView.OptionsBehavior.FocusLeaveOnTab, (Image)null, new EventHandler(this.FocusLeaveOnTab_Click)));
            //dxSubMenuItem6.Items.Add((DXMenuItem)new DXMenuCheckItem("Otomatik Genişlik", this.GridView.OptionsPrint.AutoWidth, (Image)null, new EventHandler(this.AutoWidth_Click)));
            //dxSubMenuItem6.Items.Add((DXMenuItem)new DXMenuCheckItem("Detayları Yazdır", this.GridView.OptionsPrint.PrintDetails, (Image)null, new EventHandler(this.PrintDetails_Click)));
            //dxSubMenuItem6.Items.Add((DXMenuItem)new DXMenuCheckItem("Filtre Bilgisini Yazdır", this.GridView.OptionsPrint.PrintFilterInfo, (Image)null, new EventHandler(this.PrintFilterInfo_Click)));
            //dxSubMenuItem6.Items.Add((DXMenuItem)new DXMenuCheckItem("Dipnot Yazdır", this.GridView.OptionsPrint.PrintFooter, (Image)null, new EventHandler(this.PrintFooter_Click)));
            //dxSubMenuItem6.Items.Add((DXMenuItem)new DXMenuCheckItem("Grup Dipnot Alanını Yazdır", this.GridView.OptionsPrint.PrintGroupFooter, (Image)null, new EventHandler(this.PrintGroupFooter_Click)));
            //dxSubMenuItem6.Items.Add((DXMenuItem)new DXMenuCheckItem("Başlık Alanını Yazdır", this.GridView.OptionsPrint.PrintHeader, (Image)null, new EventHandler(this.PrintHeader_Click)));
            //dxSubMenuItem6.Items.Add((DXMenuItem)new DXMenuCheckItem("Ön İzleme Alanını Yazdır", this.GridView.OptionsPrint.PrintPreview, (Image)null, new EventHandler(this.PrintPreview_Click)));
            //dxSubMenuItem6.Items.Add((DXMenuItem)new DXMenuCheckItem("Tüm Detayları Aç", this.GridView.OptionsPrint.ExpandAllDetails, (Image)null, new EventHandler(this.ExpandAllDetails_Click)));
            //dxSubMenuItem6.Items.Add((DXMenuItem)new DXMenuCheckItem("Tüm Grupları Aç", this.GridView.OptionsPrint.ExpandAllGroups, (Image)null, new EventHandler(this.ExpandAllGroups_Click)));
            //dxSubMenuItem6.Items.Add((DXMenuItem)new DXMenuCheckItem("Satır Çizgilerini Yazdır", this.GridView.OptionsPrint.PrintHorzLines, (Image)null, new EventHandler(this.PrintHorzLines_Click)));
            //dxSubMenuItem6.Items.Add((DXMenuItem)new DXMenuCheckItem("Sütun Çizgilerini Yazdır", this.GridView.OptionsPrint.PrintVertLines, (Image)null, new EventHandler(this.PrintVertLines_Click)));

        }

        private void ChkBandiDondur_CheckedChanged(object sender, EventArgs e)
        {
            BandedGridView gridView = (BandedGridView)this.GridView;
            gridView.Bands[this.CurrentBandName].Fixed = gridView.Bands[this.CurrentBandName].Fixed != FixedStyle.Left ? FixedStyle.Left : FixedStyle.None;
            this.CreateColumnMenu();
        }

        private void Chk_SoldanDondur(object sender, EventArgs e)
        {
            int visibleIndex = this.GridView.Columns[this.CurrentColumnName].VisibleIndex;
            bool flag = this.GridView.Columns[this.CurrentColumnName].Fixed == FixedStyle.Left;
            List<GridColumn> gridColumnList = new List<GridColumn>();
            for (int index = 0; index < visibleIndex + 1; ++index)
                gridColumnList.Add(this.GridView.VisibleColumns[index]);
            foreach (GridColumn gridColumn in gridColumnList)
                gridColumn.Fixed = !flag ? FixedStyle.Left : FixedStyle.None;
            this.CreateColumnMenu();
        }

        private void ChkDondur_CheckedChanged(object sender, EventArgs e)
        {
            if (this.GridView.Columns[this.CurrentColumnName].Fixed == FixedStyle.Left)
                this.GridView.Columns[this.CurrentColumnName].Fixed = FixedStyle.None;
            else
                this.GridView.Columns[this.CurrentColumnName].Fixed = FixedStyle.Left;
            this.CreateColumnMenu();
        }

        public void CreateRowMenu()
        {
            this.RowMenu = new GridViewMenu(this.GridView);
            
            if (this.customMenu.Items.Count > 0)
            {
                for (int index = 0; index < this.customMenu.Items.Count; ++index)
                {
                    DXMenuItem dxMenuItem = this.customMenu.Items[index];
                    dxMenuItem.Click -= this.customEvents[index];
                    dxMenuItem.Click += this.customEvents[index];
                    this.RowMenu.Items.Add(dxMenuItem);
                }
                
            }
            
        }

        public void AddMenu(string caption, EventHandler click)
        {
            DXMenuItem dxMenuItem = new DXMenuItem(caption);
            this.customEvents.Add(click);
            this.customMenu.Items.Add(dxMenuItem);
            this.CreateRowMenu();
        }

        public void AddColumnMenu(string caption, EventHandler click)
        {
            DXMenuItem dxMenuItem = new DXMenuItem(caption);
            this.customColumnEvents.Add(click);
            this.customColumnMenu.Items.Add(dxMenuItem);
            this.CreateColumnMenu();
        }

        public void AddColumnMenu(string caption, string Base, EventHandler click)
        {
            DXMenuItem dxMenuItem = new DXMenuItem(caption);
            this.customColumnEvents.Add(click);
            this.customColumnMenu.Items.Add(dxMenuItem);
            this.CreateColumnMenu();
        }

        public void AddMenu(string caption, EventHandler click, Image image)
        {
            DXMenuItem dxMenuItem = new DXMenuItem(caption)
            {
                Image = image
            };
            this.customEvents.Add(click);
            this.customMenu.Items.Add(dxMenuItem);
            this.CreateRowMenu();
        }

        public void AddMenu(string caption, EventHandler click, Image image, Shortcut Kisayol)
        {
            DXMenuItem dxMenuItem = new DXMenuItem(caption)
            {
                Image = image,
                Shortcut = Kisayol
            };
            this.customEvents.Add(click);
            this.customMenu.Items.Add(dxMenuItem);
            this.CreateRowMenu();
        }

        public void AddMenu(string caption, EventHandler click, Image image, bool beginGroup)
        {
            DXMenuItem dxMenuItem = new DXMenuItem(caption)
            {
                Image = image
            };
            this.customEvents.Add(click);
            this.customMenu.Items.Add(dxMenuItem);
            dxMenuItem.BeginGroup = beginGroup;
            this.CreateRowMenu();
        }

        public void RemoveColumnMenu(string caption)
        {
            for (int index = 0; index < this.customColumnMenu.Items.Count; ++index)
            {
                if (this.customColumnMenu.Items[index].Caption == caption)
                {
                    this.customColumnMenu.Items.RemoveAt(index);
                    this.customColumnEvents.RemoveAt(index);
                    this.CreateColumnMenu();
                    break;
                }
            }
        }

        public void RemoveMenu(string caption)
        {
            for (int index = 0; index < this.customMenu.Items.Count; ++index)
            {
                if (this.customMenu.Items[index].Caption == caption)
                {
                    this.customMenu.Items.RemoveAt(index);
                    this.customEvents.RemoveAt(index);
                    this.CreateRowMenu();
                    break;
                }
            }
        }

        private void AddToMenu(DXMenuItem menuItem)
        {
            if (this.customMenu.Items.Count > 0)
                this.miDuzenle.Items.Add(menuItem);
            else
                this.RowMenu.Items.Add(menuItem);
        }

        private void AddToMenu(DXSubMenuItem subMenu)
        {
            if (this.customMenu.Items.Count > 0)
                this.miDuzenle.Items.Add((DXMenuItem)subMenu);
            else
                this.RowMenu.Items.Add((DXMenuItem)subMenu);
        }

        

        private void NewItemRowNone_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
        }

        private void NewItemRowTop_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
        }

        private void NewItemRowBottom_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
        }

        private void AutoFilterRow_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsView.ShowAutoFilterRow = !this.GridView.OptionsView.ShowAutoFilterRow;
        }

        private void ShowFooter_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsView.ShowFooter = !this.GridView.OptionsView.ShowFooter;
        }

        private void AllowCellMerge_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsView.AllowCellMerge = !this.GridView.OptionsView.AllowCellMerge;
        }

        private void Yazdir_Click(object sender, EventArgs e)
        {
            if (!this.GridView.GridControl.IsPrintingAvailable)
            {
                int num = (int)XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error");
            }
            else
                this.GridView.ShowPrintPreview();
        }

        private void ColumnAutoWidth_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsView.ColumnAutoWidth = !this.GridView.OptionsView.ColumnAutoWidth;
        }

        private void ShowColumnHeaders_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsView.ShowColumnHeaders = !this.GridView.OptionsView.ShowColumnHeaders;
        }

        private void ShowDetailButtons_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsView.ShowDetailButtons = !this.GridView.OptionsView.ShowDetailButtons;
        }

        private void ShowFilterPanelModeDefault_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Default;
        }

        private void ShowFilterPanelModeShowAlways_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.ShowAlways;
        }

        private void ShowFilterPanelModeNever_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
        }

        private void ShowGroupedColumns_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsView.ShowGroupedColumns = !this.GridView.OptionsView.ShowGroupedColumns;
        }

        private void ShowIndicator_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsView.ShowIndicator = !this.GridView.OptionsView.ShowIndicator;
        }

        private void ShowPreview_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsView.ShowPreview = !this.GridView.OptionsView.ShowPreview;
        }

        

        private void AllowIncrementalSearch_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsBehavior.AllowIncrementalSearch = !this.GridView.OptionsBehavior.AllowIncrementalSearch;
        }

        private void CopyToClipboardWithColumnHeaders_Click(object sender, EventArgs e)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            GridView.OptionsBehavior.CopyToClipboardWithColumnHeaders = !GridView.OptionsBehavior.CopyToClipboardWithColumnHeaders;
#pragma warning restore CS0618 // Type or member is obsolete
        }

        private void AllowPartialRedrawOnScrolling_Click(object sender, EventArgs e)
        {
            GridView.OptionsBehavior.AllowPartialRedrawOnScrolling = !GridView.OptionsBehavior.AllowPartialRedrawOnScrolling;
        }

        private void AutoExpandAllGroups_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsBehavior.AutoExpandAllGroups = !this.GridView.OptionsBehavior.AutoExpandAllGroups;
        }

        private void AutoSelectAllInEditor_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsBehavior.AutoSelectAllInEditor = !this.GridView.OptionsBehavior.AutoSelectAllInEditor;
        }

        private void MultiSelect_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsSelection.MultiSelect = !this.GridView.OptionsSelection.MultiSelect;
        }

        private void MultiSelectRow_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
        }

        private void MultiSelectCell_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
        }

        private void AllowColumnMoving_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsCustomization.AllowColumnMoving = !this.GridView.OptionsCustomization.AllowColumnMoving;
        }

        private void AllowColumnResizing_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsCustomization.AllowColumnResizing = !this.GridView.OptionsCustomization.AllowColumnResizing;
        }

        private void AllowRowSizing_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsCustomization.AllowRowSizing = !this.GridView.OptionsCustomization.AllowRowSizing;
        }

        private void AllowFilter_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsCustomization.AllowFilter = !this.GridView.OptionsCustomization.AllowFilter;
        }

        private void AllowGroup_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsCustomization.AllowGroup = !this.GridView.OptionsCustomization.AllowGroup;
        }

        private void AllowSort_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsCustomization.AllowSort = !this.GridView.OptionsCustomization.AllowSort;
        }

        private void AllowExpandEmptyDetails_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsDetail.AllowExpandEmptyDetails = !this.GridView.OptionsDetail.AllowExpandEmptyDetails;
        }

        private void AllowOnlyOneMasterRowExpanded_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsDetail.AllowOnlyOneMasterRowExpanded = !this.GridView.OptionsDetail.AllowOnlyOneMasterRowExpanded;
        }

        private void AllowZoomDetail_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsDetail.AllowZoomDetail = !this.GridView.OptionsDetail.AllowZoomDetail;
        }

        private void AutoZoomDetail_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsDetail.AutoZoomDetail = !this.GridView.OptionsDetail.AutoZoomDetail;
        }

        private void EnableDetailToolTip_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsDetail.EnableDetailToolTip = !this.GridView.OptionsDetail.EnableDetailToolTip;
        }

        private void EnableMasterViewMode_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsDetail.EnableMasterViewMode = !this.GridView.OptionsDetail.EnableMasterViewMode;
        }

        private void ShowDetailTabs_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsDetail.ShowDetailTabs = !this.GridView.OptionsDetail.ShowDetailTabs;
        }

        private void AutoFocusNewRow_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsNavigation.AutoFocusNewRow = !this.GridView.OptionsNavigation.AutoFocusNewRow;
        }

        private void EnterMoveNextColumn_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsNavigation.EnterMoveNextColumn = !this.GridView.OptionsNavigation.EnterMoveNextColumn;
        }

        private void UseTabKey_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsNavigation.UseTabKey = !this.GridView.OptionsNavigation.UseTabKey;
        }

        private void FocusLeaveOnTab_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsBehavior.FocusLeaveOnTab = !this.GridView.OptionsBehavior.FocusLeaveOnTab;
        }

        private void AutoWidth_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsPrint.AutoWidth = !this.GridView.OptionsPrint.AutoWidth;
        }

        private void PrintDetails_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsPrint.PrintDetails = !this.GridView.OptionsPrint.PrintDetails;
        }

        private void PrintFilterInfo_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsPrint.PrintFilterInfo = !this.GridView.OptionsPrint.PrintFilterInfo;
        }

        private void PrintFooter_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsPrint.PrintFooter = !this.GridView.OptionsPrint.PrintFooter;
        }

        private void PrintGroupFooter_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsPrint.PrintGroupFooter = !this.GridView.OptionsPrint.PrintFooter;
        }

        private void PrintHeader_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsPrint.PrintHeader = !this.GridView.OptionsPrint.PrintHeader;
        }

        private void PrintPreview_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsPrint.PrintPreview = !this.GridView.OptionsPrint.PrintPreview;
        }

        private void ExpandAllDetails_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsPrint.ExpandAllDetails = !this.GridView.OptionsPrint.ExpandAllDetails;
        }

        private void ExpandAllGroups_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsPrint.ExpandAllGroups = !this.GridView.OptionsPrint.ExpandAllGroups;
        }

        private void PrintHorzLines_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsPrint.PrintHorzLines = !this.GridView.OptionsPrint.PrintHorzLines;
        }

        private void PrintVertLines_Click(object sender, EventArgs e)
        {
            this.GridView.OptionsPrint.PrintVertLines = !this.GridView.OptionsPrint.PrintVertLines;
        }

    }
    public class GridManager
    {
        public static Dictionary<int, GridManager> Items = new Dictionary<int, GridManager>();
        public GridUtility gridUtility;
        private GridMenu gridMenu;
        private GridView gridView;

        public GridMenu GridMenu
        {
            get
            {
                return gridMenu;
            }
            set
            {
                gridMenu = value;
            }
        }

        private GridManager(GridView gridView)
        {
            GridView = gridView;
            gridMenu = new GridMenu(this);
            gridUtility = new GridUtility(this);
            Grid.KeyPress += new KeyPressEventHandler(Grid_KeyPress);
            GridView.PopupMenuShowing += new PopupMenuShowingEventHandler(GridView_PopupMenuShowing);
            GridView.RowCellStyle += new RowCellStyleEventHandler(GridView_RowCellStyle);
            GridView.InvalidValueException += new InvalidValueExceptionEventHandler(GridView_InvalidValueException);
        }

        private void GridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            this.gridMenu.CurrentColumnName = "";
            this.gridMenu.CurrentBandName = "";
            if (e.MenuType == GridMenuType.Row)
            {
                e.Menu = this.gridMenu.RowMenu;
            }
            else
            {
                if (e.MenuType != GridMenuType.Column)
                    return;
                //if (e.HitInfo.GetType() == typeof(BandedGridHitInfo))
                //{
                //    BandedGridHitInfo hitInfo = (BandedGridHitInfo)e.HitInfo;
                //    if (hitInfo.Column == null && hitInfo.Band != null)
                //        this.gridMenu.CurrentBandName = hitInfo.Band.Name;
                //}
                //else if (e.HitInfo.GetType() == typeof(GridHitInfo))
                //{
                //    GridColumn column = e.HitInfo.Column;
                //    if (column != null)
                //        this.GridMenu.CurrentColumnName = column.FieldName;
                //}
                //foreach (DXMenuItem dxMenuItem in (CollectionBase)this.gridMenu.ColumnMenu.Items)
                //    e.Menu.Items.Add(dxMenuItem);
            }
        }

        private void GridView_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            if (!this.gridUtility.ShowValidationException)
                throw e.Exception;
        }

        private void Grid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\x0016' && e.KeyChar != '\a')
                return;
            e.Handled = true;
        }

        public GridView GridView
        {
            get
            {
                return this.gridView;
            }
            set
            {
                this.gridView = value;
            }
        }

        public GridControl Grid
        {
            get
            {
                return this.gridView.GridControl;
            }
        }

        public static GridManager GetManager(GridView gridView)
        {
            GridManager gridManager1 = (GridManager)null;
            if (!GridManager.Items.TryGetValue(gridView.GetHashCode(), out gridManager1))
            {
                GridManager gridManager2 = new GridManager(gridView);
                GridManager.Items.Add(gridView.GetHashCode(), gridManager2);
                GridManager.Items.TryGetValue(gridView.GetHashCode(), out gridManager1);
            }
            return gridManager1;
        }              

        private void GridView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle != -999997)
                return;
            e.Appearance.BackColor = Color.LightGoldenrodYellow;
        }

        
    }
    public class GridUtility
    {
        private bool showValidationException = true;
        private GridView gridView;

        public GridView GridView
        {
            get
            {
                return this.gridView;
            }
            set
            {
                this.gridView = value;
            }
        }

        public bool ShowValidationException
        {
            get
            {
                return this.showValidationException;
            }
            set
            {
                this.showValidationException = value;
            }
        }

        public GridUtility(GridView view)
        {
            this.gridView = view;
        }

        public GridUtility(GridManager gridManager)
        {
            this.gridView = gridManager.GridView;
        }        

        public string GetSelectionInfo()
        {
            double num1 = 0.0;
            int num2 = 0;
            int num3 = 0;
            foreach (GridCell selectedCell in this.GridView.GetSelectedCells())
            {
                object rowCellDisplayText = (object)this.GridView.GetRowCellDisplayText(selectedCell.RowHandle, selectedCell.Column);
                if (rowCellDisplayText.ToString() != string.Empty)
                    ++num2;
                if (this.GridView.GetRowCellValue(selectedCell.RowHandle, selectedCell.Column) != null && this.GridView.GetRowCellValue(selectedCell.RowHandle, selectedCell.Column).GetType() != typeof(DateTime))
                {
                    if (double.TryParse(rowCellDisplayText.ToString(), out double result))
                        ++num3;
                    num1 += result;
                }
            }
            int selectedRowsCount = this.GridView.SelectedRowsCount;
            double num4 = num1 > 0.0 ? num1 / (double)num3 : 0.0;
            return "Adet:" + (object)num2 + "\t Toplam:" + num1.ToString("N") + "\t Ortalama:" + num4.ToString("N");
        }
        public static bool IsReadOnly(GridColumn col)
        {
            return col.View.OptionsBehavior.ReadOnly || !col.OptionsColumn.AllowEdit;
        }

        public static bool IsReadOnly(GridView GridView)
        {
            return GridView.OptionsBehavior.ReadOnly;
        }
    }
}
