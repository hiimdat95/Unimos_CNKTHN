namespace UnimOs.UI
{
    partial class frmKeHoachChiTiet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKeHoachChiTiet));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barbtnOpen = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.bartxtSoTietTuan = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barbtnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnXuatExcel = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerBottom = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockGiaoVien = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.grdGiaoVien = new DevExpress.XtraGrid.GridControl();
            this.bgrvGiaoVien = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grbKy1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grbKy2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.barbtnNghi = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnGiaoVien = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnSoTiet = new DevExpress.XtraBars.BarButtonItem();
            this.fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.hideContainerBottom.SuspendLayout();
            this.dockGiaoVien.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGiaoVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgrvGiaoVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.AllowShowToolbarsPopup = false;
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2});
            this.barManager.Categories.AddRange(new DevExpress.XtraBars.BarManagerCategory[] {
            new DevExpress.XtraBars.BarManagerCategory("Popup", new System.Guid("0c6028db-accf-4400-9154-f770ceae324b"))});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.DockManager = this.dockManager;
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barbtnOpen,
            this.bartxtSoTietTuan,
            this.barStaticItem1,
            this.barbtnLuu,
            this.barbtnNghi,
            this.barbtnGiaoVien,
            this.barbtnSoTiet,
            this.barbtnXuatExcel});
            this.barManager.MaxItemId = 8;
            this.barManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnOpen),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.bartxtSoTietTuan, "", false, true, true, 41)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // barbtnOpen
            // 
            this.barbtnOpen.Caption = "Mở kế hoạch";
            this.barbtnOpen.Id = 0;
            this.barbtnOpen.Name = "barbtnOpen";
            this.barbtnOpen.Tag = "barbtnOpen";
            this.barbtnOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnOpen_ItemClick);
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "Số tiết tuần:";
            this.barStaticItem1.Id = 2;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bartxtSoTietTuan
            // 
            this.bartxtSoTietTuan.Edit = this.repositoryItemTextEdit1;
            this.bartxtSoTietTuan.EditValue = "30";
            this.bartxtSoTietTuan.Id = 1;
            this.bartxtSoTietTuan.Name = "bartxtSoTietTuan";
            this.bartxtSoTietTuan.EditValueChanged += new System.EventHandler(this.bartxtSoTietTuan_EditValueChanged);
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemTextEdit1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.Mask.EditMask = "d2";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit1.MaxLength = 2;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.NullText = "0";
            // 
            // bar2
            // 
            this.bar2.BarName = "LeftTools";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Left;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnLuu),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnXuatExcel, true)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "LeftTools";
            // 
            // barbtnLuu
            // 
            this.barbtnLuu.Caption = "Lưu";
            this.barbtnLuu.Description = "Lưu kế hoạch chi tiết";
            this.barbtnLuu.Id = 3;
            this.barbtnLuu.Name = "barbtnLuu";
            this.barbtnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnLuu_ItemClick);
            // 
            // barbtnXuatExcel
            // 
            this.barbtnXuatExcel.Caption = "Xuất Excel";
            this.barbtnXuatExcel.Hint = "Xuất kế hoạch chi tiết ra file Excel";
            this.barbtnXuatExcel.Id = 7;
            this.barbtnXuatExcel.Name = "barbtnXuatExcel";
            this.barbtnXuatExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnXuatExcel_ItemClick);
            // 
            // dockManager
            // 
            this.dockManager.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerBottom});
            this.dockManager.Form = this;
            this.dockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // hideContainerBottom
            // 
            this.hideContainerBottom.Controls.Add(this.dockGiaoVien);
            this.hideContainerBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hideContainerBottom.Location = new System.Drawing.Point(29, 436);
            this.hideContainerBottom.Name = "hideContainerBottom";
            this.hideContainerBottom.Size = new System.Drawing.Size(844, 19);
            // 
            // dockGiaoVien
            // 
            this.dockGiaoVien.Controls.Add(this.dockPanel1_Container);
            this.dockGiaoVien.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockGiaoVien.ID = new System.Guid("cbb7e11e-96fa-46f9-9850-f8b3dbca8763");
            this.dockGiaoVien.Location = new System.Drawing.Point(0, 0);
            this.dockGiaoVien.Name = "dockGiaoVien";
            this.dockGiaoVien.Options.ShowCloseButton = false;
            this.dockGiaoVien.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockGiaoVien.SavedIndex = 0;
            this.dockGiaoVien.Size = new System.Drawing.Size(844, 186);
            this.dockGiaoVien.Text = "Chi tiết giảng viên";
            this.dockGiaoVien.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.grdGiaoVien);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 25);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(838, 158);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // grdGiaoVien
            // 
            this.grdGiaoVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdGiaoVien.Location = new System.Drawing.Point(0, 0);
            this.grdGiaoVien.MainView = this.bgrvGiaoVien;
            this.grdGiaoVien.Name = "grdGiaoVien";
            this.grdGiaoVien.Size = new System.Drawing.Size(838, 158);
            this.grdGiaoVien.TabIndex = 0;
            this.grdGiaoVien.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bgrvGiaoVien});
            // 
            // bgrvGiaoVien
            // 
            this.bgrvGiaoVien.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.grbKy1,
            this.grbKy2});
            this.bgrvGiaoVien.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn1,
            this.bandedGridColumn2,
            this.bandedGridColumn3,
            this.bandedGridColumn4});
            this.bgrvGiaoVien.GridControl = this.grdGiaoVien;
            this.bgrvGiaoVien.GroupCount = 1;
            this.bgrvGiaoVien.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.bgrvGiaoVien.Name = "bgrvGiaoVien";
            this.bgrvGiaoVien.OptionsBehavior.Editable = false;
            this.bgrvGiaoVien.OptionsCustomization.AllowColumnMoving = false;
            this.bgrvGiaoVien.OptionsCustomization.AllowFilter = false;
            this.bgrvGiaoVien.OptionsCustomization.AllowSort = false;
            this.bgrvGiaoVien.OptionsView.ColumnAutoWidth = false;
            this.bgrvGiaoVien.OptionsView.ShowFooter = true;
            this.bgrvGiaoVien.OptionsView.ShowGroupPanel = false;
            this.bgrvGiaoVien.OptionsView.ShowIndicator = false;
            this.bgrvGiaoVien.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.bandedGridColumn4, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "Môn lớp";
            this.gridBand1.Columns.Add(this.bandedGridColumn1);
            this.gridBand1.Columns.Add(this.bandedGridColumn2);
            this.gridBand1.Columns.Add(this.bandedGridColumn3);
            this.gridBand1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 300;
            // 
            // bandedGridColumn1
            // 
            this.bandedGridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn1.Caption = "Tên lớp";
            this.bandedGridColumn1.FieldName = "TenLop";
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            this.bandedGridColumn1.OptionsColumn.FixedWidth = true;
            this.bandedGridColumn1.Visible = true;
            this.bandedGridColumn1.Width = 85;
            // 
            // bandedGridColumn2
            // 
            this.bandedGridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn2.Caption = "Tên môn";
            this.bandedGridColumn2.FieldName = "TenMonHoc";
            this.bandedGridColumn2.Name = "bandedGridColumn2";
            this.bandedGridColumn2.OptionsColumn.FixedWidth = true;
            this.bandedGridColumn2.Visible = true;
            this.bandedGridColumn2.Width = 145;
            // 
            // bandedGridColumn3
            // 
            this.bandedGridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn3.Caption = "Số tiết";
            this.bandedGridColumn3.FieldName = "TongSoTiet";
            this.bandedGridColumn3.Name = "bandedGridColumn3";
            this.bandedGridColumn3.OptionsColumn.FixedWidth = true;
            this.bandedGridColumn3.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.bandedGridColumn3.Visible = true;
            this.bandedGridColumn3.Width = 70;
            // 
            // grbKy1
            // 
            this.grbKy1.AppearanceHeader.Options.UseTextOptions = true;
            this.grbKy1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grbKy1.Caption = "grbKy2";
            this.grbKy1.Name = "grbKy1";
            // 
            // grbKy2
            // 
            this.grbKy2.Caption = "grbKy2";
            this.grbKy2.Name = "grbKy2";
            // 
            // bandedGridColumn4
            // 
            this.bandedGridColumn4.Caption = "Ca học";
            this.bandedGridColumn4.FieldName = "CaHoc";
            this.bandedGridColumn4.Name = "bandedGridColumn4";
            this.bandedGridColumn4.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn4.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.bandedGridColumn4.Visible = true;
            // 
            // barbtnNghi
            // 
            this.barbtnNghi.Caption = "Nghỉ";
            this.barbtnNghi.CategoryGuid = new System.Guid("0c6028db-accf-4400-9154-f770ceae324b");
            this.barbtnNghi.Id = 4;
            this.barbtnNghi.Name = "barbtnNghi";
            this.barbtnNghi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnNghi_ItemClick);
            // 
            // barbtnGiaoVien
            // 
            this.barbtnGiaoVien.Caption = "Giáo viên";
            this.barbtnGiaoVien.CategoryGuid = new System.Guid("0c6028db-accf-4400-9154-f770ceae324b");
            this.barbtnGiaoVien.Id = 5;
            this.barbtnGiaoVien.Name = "barbtnGiaoVien";
            this.barbtnGiaoVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnGiaoVien_ItemClick);
            // 
            // barbtnSoTiet
            // 
            this.barbtnSoTiet.Caption = "Số tiết tuần";
            this.barbtnSoTiet.CategoryGuid = new System.Guid("0c6028db-accf-4400-9154-f770ceae324b");
            this.barbtnSoTiet.Id = 6;
            this.barbtnSoTiet.Name = "barbtnSoTiet";
            this.barbtnSoTiet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnSoTiet_ItemClick);
            // 
            // fg
            // 
            this.fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fg.AllowEditing = false;
            this.fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both;
            this.fg.ColumnInfo = "0,0,0,0,0,90,Columns:";
            this.fg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fg.Location = new System.Drawing.Point(29, 25);
            this.fg.Name = "fg";
            this.fg.Rows.Count = 0;
            this.fg.Rows.DefaultSize = 18;
            this.fg.Rows.Fixed = 0;
            this.fg.Size = new System.Drawing.Size(844, 411);
            this.fg.StyleInfo = resources.GetString("fg.StyleInfo");
            this.fg.TabIndex = 5;
            this.fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue;
            this.fg.EnterCell += new System.EventHandler(this.fg_EnterCell);
            this.fg.MouseEnterCell += new C1.Win.C1FlexGrid.RowColEventHandler(this.fg_MouseEnterCell);
            this.fg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.fg_MouseUp);
            this.fg.DoubleClick += new System.EventHandler(this.fg_DoubleClick);
            this.fg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fg_KeyPress);
            this.fg.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fg_KeyUp);
            this.fg.MouseLeaveCell += new C1.Win.C1FlexGrid.RowColEventHandler(this.fg_MouseLeaveCell);
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnNghi),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnGiaoVien),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnSoTiet)});
            this.popupMenu.Manager = this.barManager;
            this.popupMenu.Name = "popupMenu";
            // 
            // toolTipController
            // 
            this.toolTipController.AllowHtmlText = true;
            this.toolTipController.Rounded = true;
            this.toolTipController.ShowBeak = true;
            this.toolTipController.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip;
            // 
            // frmKeHoachChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 455);
            this.Controls.Add(this.fg);
            this.Controls.Add(this.hideContainerBottom);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmKeHoachChiTiet";
            this.Tag = "frmKeHoachChiTiet";
            this.Text = "LAP KE HOACH CHI TIET";
            this.Load += new System.EventHandler(this.frmKeHoachChiTiet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.hideContainerBottom.ResumeLayout(false);
            this.dockGiaoVien.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGiaoVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgrvGiaoVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barbtnOpen;
        private DevExpress.XtraBars.BarEditItem bartxtSoTietTuan;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem barbtnLuu;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarButtonItem barbtnNghi;
        private DevExpress.XtraBars.BarButtonItem barbtnGiaoVien;
        private DevExpress.XtraBars.BarButtonItem barbtnSoTiet;
        public C1.Win.C1FlexGrid.C1FlexGrid fg;
        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraBars.Docking.DockPanel dockGiaoVien;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraGrid.GridControl grdGiaoVien;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bgrvGiaoVien;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand grbKy1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand grbKy2;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerBottom;
        private DevExpress.Utils.ToolTipController toolTipController;
        private DevExpress.XtraBars.BarButtonItem barbtnXuatExcel;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn4;
    }
}