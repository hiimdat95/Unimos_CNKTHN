namespace UnimOs.UI
{
    partial class frmKeHoachThucHanh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKeHoachThucHanh));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barbtnLop = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnPhong = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnGiangVien = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barbtnOpen = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnXuatExcel = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerRight = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockGiangVien = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.hideContainerBottom = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockMonLop = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdMonLop = new DevExpress.XtraGrid.GridControl();
            this.grvMonLop = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.barbtnLapLichChoMon = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnSuaCaThucHanh = new DevExpress.XtraBars.BarButtonItem();
            this.fg = new UnimOs.UI.FlexThucHanh();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.hideContainerRight.SuspendLayout();
            this.dockGiangVien.SuspendLayout();
            this.hideContainerBottom.SuspendLayout();
            this.dockMonLop.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMonLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMonLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2});
            this.barManager.Categories.AddRange(new DevExpress.XtraBars.BarManagerCategory[] {
            new DevExpress.XtraBars.BarManagerCategory("ThemMonLopThucHanh", new System.Guid("68a46108-6163-4bae-940c-cba610a9fe29"))});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.DockManager = this.dockManager;
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barbtnPhong,
            this.barbtnLop,
            this.barbtnGiangVien,
            this.barbtnLuu,
            this.barbtnLapLichChoMon,
            this.barbtnOpen,
            this.barbtnXuatExcel,
            this.barbtnSuaCaThucHanh});
            this.barManager.MaxItemId = 9;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnLop),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnPhong, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnGiangVien, true)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // barbtnLop
            // 
            this.barbtnLop.Caption = "Lớp thực hành";
            this.barbtnLop.Id = 1;
            this.barbtnLop.Name = "barbtnLop";
            this.barbtnLop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnLop_ItemClick);
            // 
            // barbtnPhong
            // 
            this.barbtnPhong.Caption = "Phòng thực hành";
            this.barbtnPhong.Id = 0;
            this.barbtnPhong.Name = "barbtnPhong";
            this.barbtnPhong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnPhong_ItemClick);
            // 
            // barbtnGiangVien
            // 
            this.barbtnGiangVien.Caption = "Giảng viên";
            this.barbtnGiangVien.Id = 2;
            this.barbtnGiangVien.Name = "barbtnGiangVien";
            this.barbtnGiangVien.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bar2
            // 
            this.bar2.BarName = "MenuNgang";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Left;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnOpen),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnLuu, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnXuatExcel, true)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "MenuNgang";
            // 
            // barbtnOpen
            // 
            this.barbtnOpen.Caption = "Open";
            this.barbtnOpen.Hint = "Mở lại kế hoạch";
            this.barbtnOpen.Id = 6;
            this.barbtnOpen.Name = "barbtnOpen";
            this.barbtnOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnOpen_ItemClick);
            // 
            // barbtnLuu
            // 
            this.barbtnLuu.Caption = "Lưu";
            this.barbtnLuu.Id = 3;
            this.barbtnLuu.Name = "barbtnLuu";
            this.barbtnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnLuu_ItemClick);
            // 
            // barbtnXuatExcel
            // 
            this.barbtnXuatExcel.Caption = "Xuất Excel";
            this.barbtnXuatExcel.Hint = "Xuất kế hoạch thực hành ra file excel";
            this.barbtnXuatExcel.Id = 7;
            this.barbtnXuatExcel.Name = "barbtnXuatExcel";
            this.barbtnXuatExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnXuatExcel_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(903, 29);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 451);
            this.barDockControlBottom.Size = new System.Drawing.Size(903, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 29);
            this.barDockControlLeft.Size = new System.Drawing.Size(29, 422);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(903, 29);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 422);
            // 
            // dockManager
            // 
            this.dockManager.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerRight,
            this.hideContainerBottom});
            this.dockManager.Form = this;
            this.dockManager.MenuManager = this.barManager;
            this.dockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // hideContainerRight
            // 
            this.hideContainerRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.hideContainerRight.Controls.Add(this.dockGiangVien);
            this.hideContainerRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.hideContainerRight.Location = new System.Drawing.Point(884, 29);
            this.hideContainerRight.Name = "hideContainerRight";
            this.hideContainerRight.Size = new System.Drawing.Size(19, 422);
            // 
            // dockGiangVien
            // 
            this.dockGiangVien.Controls.Add(this.dockPanel1_Container);
            this.dockGiangVien.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockGiangVien.FloatVertical = true;
            this.dockGiangVien.ID = new System.Guid("ee800833-08ce-49d2-b604-2ea7576f560c");
            this.dockGiangVien.Location = new System.Drawing.Point(0, 0);
            this.dockGiangVien.Name = "dockGiangVien";
            this.dockGiangVien.OriginalSize = new System.Drawing.Size(0, 0);
            this.dockGiangVien.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockGiangVien.SavedIndex = 0;
            this.dockGiangVien.Size = new System.Drawing.Size(237, 437);
            this.dockGiangVien.Text = "Chi tiết giảng viên:";
            this.dockGiangVien.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 25);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(231, 409);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // hideContainerBottom
            // 
            this.hideContainerBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.hideContainerBottom.Controls.Add(this.dockMonLop);
            this.hideContainerBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hideContainerBottom.Location = new System.Drawing.Point(29, 432);
            this.hideContainerBottom.Name = "hideContainerBottom";
            this.hideContainerBottom.Size = new System.Drawing.Size(855, 19);
            // 
            // dockMonLop
            // 
            this.dockMonLop.Controls.Add(this.dockPanel2_Container);
            this.dockMonLop.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockMonLop.ID = new System.Guid("4bd4abd5-5983-415a-9332-69183f4c0bf9");
            this.dockMonLop.Location = new System.Drawing.Point(0, 0);
            this.dockMonLop.Name = "dockMonLop";
            this.dockMonLop.OriginalSize = new System.Drawing.Size(0, 0);
            this.dockMonLop.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockMonLop.SavedIndex = 0;
            this.dockMonLop.Size = new System.Drawing.Size(807, 179);
            this.dockMonLop.Text = "Môn lớp";
            this.dockMonLop.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.layoutControl1);
            this.dockPanel2_Container.Location = new System.Drawing.Point(3, 25);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(801, 151);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdMonLop);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(801, 151);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdMonLop
            // 
            this.grdMonLop.Location = new System.Drawing.Point(233, 12);
            this.grdMonLop.MainView = this.grvMonLop;
            this.grdMonLop.Name = "grdMonLop";
            this.grdMonLop.Size = new System.Drawing.Size(556, 127);
            this.grdMonLop.TabIndex = 4;
            this.grdMonLop.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMonLop,
            this.gridView2});
            // 
            // grvMonLop
            // 
            this.grvMonLop.GridControl = this.grdMonLop;
            this.grvMonLop.Name = "grvMonLop";
            this.grvMonLop.OptionsView.ShowGroupPanel = false;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdMonLop;
            this.gridView2.Name = "gridView2";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(801, 151);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdMonLop;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(221, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(560, 131);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(221, 131);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // barbtnLapLichChoMon
            // 
            this.barbtnLapLichChoMon.Caption = "Lập lịch thực hành cho môn";
            this.barbtnLapLichChoMon.CategoryGuid = new System.Guid("68a46108-6163-4bae-940c-cba610a9fe29");
            this.barbtnLapLichChoMon.Id = 5;
            this.barbtnLapLichChoMon.Name = "barbtnLapLichChoMon";
            this.barbtnLapLichChoMon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnLapLichChoMon_ItemClick);
            // 
            // barbtnSuaCaThucHanh
            // 
            this.barbtnSuaCaThucHanh.Caption = "Sửa ca thực hành cho môn";
            this.barbtnSuaCaThucHanh.Id = 8;
            this.barbtnSuaCaThucHanh.Name = "barbtnSuaCaThucHanh";
            this.barbtnSuaCaThucHanh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnSuaCaThucHanh_ItemClick);
            // 
            // fg
            // 
            this.fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fg.AllowEditing = false;
            this.fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both;
            this.fg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.fg.ColumnInfo = "0,0,0,0,0,90,Columns:";
            this.fg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fg.Location = new System.Drawing.Point(29, 29);
            this.fg.Name = "fg";
            this.barManager.SetPopupContextMenu(this.fg, this.popupMenu);
            this.fg.Rows.Count = 7;
            this.fg.Rows.DefaultSize = 18;
            this.fg.Rows.Fixed = 7;
            this.fg.Size = new System.Drawing.Size(855, 403);
            this.fg.StyleInfo = resources.GetString("fg.StyleInfo");
            this.fg.TabIndex = 4;
            this.fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue;
            this.fg.MouseEnterCell += new C1.Win.C1FlexGrid.RowColEventHandler(this.fg_MouseEnterCell);
            this.fg.MouseLeaveCell += new C1.Win.C1FlexGrid.RowColEventHandler(this.fg_MouseLeaveCell);
            this.fg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fg_KeyDown);
            this.fg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fg_MouseDown);
            this.fg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fg_MouseMove);
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnLapLichChoMon),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnSuaCaThucHanh)});
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
            // frmKeHoachThucHanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 451);
            this.Controls.Add(this.fg);
            this.Controls.Add(this.hideContainerBottom);
            this.Controls.Add(this.hideContainerRight);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmKeHoachThucHanh";
            this.Tag = "frmKeHoachThucHanh";
            this.Text = "KE HOACH THUC HANH";
            this.Load += new System.EventHandler(this.frmKeHoachThucHanh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.hideContainerRight.ResumeLayout(false);
            this.dockGiangVien.ResumeLayout(false);
            this.hideContainerBottom.ResumeLayout(false);
            this.dockMonLop.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMonLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMonLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
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
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraBars.Docking.DockPanel dockGiangVien;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockMonLop;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.BarButtonItem barbtnPhong;
        private DevExpress.XtraBars.BarButtonItem barbtnLop;
        private DevExpress.XtraBars.BarButtonItem barbtnGiangVien;
        private DevExpress.XtraBars.BarButtonItem barbtnLuu;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerRight;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl grdMonLop;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMonLop;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraBars.BarButtonItem barbtnLapLichChoMon;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerBottom;
        private DevExpress.XtraBars.BarButtonItem barbtnOpen;
        public FlexThucHanh fg;
        private DevExpress.Utils.ToolTipController toolTipController;
        private DevExpress.XtraBars.BarButtonItem barbtnXuatExcel;
        private DevExpress.XtraBars.BarButtonItem barbtnSuaCaThucHanh;
    }
}