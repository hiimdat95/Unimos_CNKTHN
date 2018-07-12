namespace UnimOs.UI
{
    partial class frmKeHoachToanTruong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKeHoachToanTruong));
            this.fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barbtnpopThemHoatDong = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barbtnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnXuatExcel = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.btnThemHoatDong = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnCaHoc = new DevExpress.XtraBars.BarButtonItem();
            this.btnKeHoachKhac = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnSua = new DevExpress.XtraBars.BarButtonItem();
            this.panelContent = new DevExpress.XtraEditors.PanelControl();
            this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnOpen = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // fg
            // 
            this.fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fg.AllowEditing = false;
            this.fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both;
            this.fg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.fg.ColumnInfo = "0,0,0,0,0,90,Columns:";
            this.fg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fg.Location = new System.Drawing.Point(2, 2);
            this.fg.Name = "fg";
            this.barManager1.SetPopupContextMenu(this.fg, this.popupMenu1);
            this.fg.Rows.Count = 6;
            this.fg.Rows.DefaultSize = 18;
            this.fg.Rows.Fixed = 6;
            this.fg.Size = new System.Drawing.Size(880, 430);
            this.fg.StyleInfo = resources.GetString("fg.StyleInfo");
            this.fg.TabIndex = 0;
            this.fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue;
            this.fg.MouseEnterCell += new C1.Win.C1FlexGrid.RowColEventHandler(this.fg_MouseEnterCell);
            this.fg.DoubleClick += new System.EventHandler(this.fg_DoubleClick);
            this.fg.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fg_KeyUp);
            this.fg.MouseLeaveCell += new C1.Win.C1FlexGrid.RowColEventHandler(this.fg_MouseLeaveCell);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnpopThemHoatDong)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // barbtnpopThemHoatDong
            // 
            this.barbtnpopThemHoatDong.Caption = "Thêm hoạt động";
            this.barbtnpopThemHoatDong.Id = 9;
            this.barbtnpopThemHoatDong.Name = "barbtnpopThemHoatDong";
            this.barbtnpopThemHoatDong.Tag = "barbtnpopThemHoatDong";
            this.barbtnpopThemHoatDong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnpopThemHoatDong_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barbtnpopThemHoatDong,
            this.barbtnLuu,
            this.btnThemHoatDong,
            this.barbtnCaHoc,
            this.btnKeHoachKhac,
            this.barbtnXuatExcel,
            this.barbtnOpen});
            this.barManager1.MaxItemId = 13;
            // 
            // bar2
            // 
            this.bar2.BarName = "Custom 3";
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
            this.bar2.Text = "Custom 3";
            // 
            // barbtnLuu
            // 
            this.barbtnLuu.Caption = "Lưu";
            this.barbtnLuu.Hint = "Lưu các thay đổi của kế hoạch toàn trường";
            this.barbtnLuu.Id = 6;
            this.barbtnLuu.Name = "barbtnLuu";
            this.barbtnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnLuu_ItemClick);
            // 
            // barbtnXuatExcel
            // 
            this.barbtnXuatExcel.Caption = "Xuất Excel";
            this.barbtnXuatExcel.Hint = "Xuất kế hoạch toàn trường ra file Excel";
            this.barbtnXuatExcel.Id = 11;
            this.barbtnXuatExcel.Name = "barbtnXuatExcel";
            this.barbtnXuatExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnXuatExcel_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Custom 4";
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThemHoatDong),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnCaHoc, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnKeHoachKhac, true)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Custom 4";
            // 
            // btnThemHoatDong
            // 
            this.btnThemHoatDong.Caption = "Thêm hoạt động";
            this.btnThemHoatDong.Id = 4;
            this.btnThemHoatDong.Name = "btnThemHoatDong";
            this.btnThemHoatDong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThemHoatDong_ItemClick);
            // 
            // barbtnCaHoc
            // 
            this.barbtnCaHoc.Caption = "Ca học";
            this.barbtnCaHoc.Id = 7;
            this.barbtnCaHoc.Name = "barbtnCaHoc";
            this.barbtnCaHoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnCaHoc_ItemClick);
            // 
            // btnKeHoachKhac
            // 
            this.btnKeHoachKhac.Caption = "Thêm loại hoạt động";
            this.btnKeHoachKhac.Id = 5;
            this.btnKeHoachKhac.Name = "btnKeHoachKhac";
            this.btnKeHoachKhac.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKeHoachKhac_ItemClick);
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 2;
            this.btnThem.Name = "btnThem";
            // 
            // btnSua
            // 
            this.btnSua.Caption = "Sửa";
            this.btnSua.Id = 1;
            this.btnSua.Name = "btnSua";
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.fg);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(29, 24);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(884, 434);
            this.panelContent.TabIndex = 8;
            // 
            // toolTipController
            // 
            this.toolTipController.AllowHtmlText = true;
            this.toolTipController.Rounded = true;
            this.toolTipController.ShowBeak = true;
            this.toolTipController.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Ngay";
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barbtnOpen
            // 
            this.barbtnOpen.Caption = "Open";
            this.barbtnOpen.Id = 12;
            this.barbtnOpen.Name = "barbtnOpen";
            this.barbtnOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnOpen_ItemClick);
            // 
            // frmKeHoachToanTruong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 458);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmKeHoachToanTruong";
            this.Tag = "frmKeHoachToanTruong";
            this.Text = "KE HOACH HOAT DONG TOAN TRUONG";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmKeHoachToanTruong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid fg;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnSua;
        private DevExpress.XtraEditors.PanelControl panelContent;
        private DevExpress.XtraBars.BarButtonItem btnThemHoatDong;
        private DevExpress.XtraBars.BarButtonItem btnKeHoachKhac;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem barbtnLuu;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarButtonItem barbtnCaHoc;
        private DevExpress.Utils.ToolTipController toolTipController;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barbtnpopThemHoatDong;
        private DevExpress.XtraBars.BarButtonItem barbtnXuatExcel;
        private DevExpress.XtraBars.BarButtonItem barbtnOpen;

    }
}