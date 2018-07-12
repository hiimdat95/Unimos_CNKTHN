namespace UnimOs.UI
{
    partial class frmCongThucDiem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCongThucDiem));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdCongThucDiemMon = new DevExpress.XtraGrid.GridControl();
            this.grvCongThucDiemMon = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ImageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barbtnThem = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnSua = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.uctrlLop = new UnimOs.UI.ucTreeLop();
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCongThucDiemMon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCongThucDiemMon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.uctrlLop);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grdCongThucDiemMon);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(929, 493);
            this.splitContainerControl1.SplitterPosition = 300;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // grdCongThucDiemMon
            // 
            this.grdCongThucDiemMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCongThucDiemMon.Location = new System.Drawing.Point(0, 0);
            this.grdCongThucDiemMon.MainView = this.grvCongThucDiemMon;
            this.grdCongThucDiemMon.Name = "grdCongThucDiemMon";
            this.grdCongThucDiemMon.Size = new System.Drawing.Size(619, 489);
            this.grdCongThucDiemMon.TabIndex = 4;
            this.grdCongThucDiemMon.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCongThucDiemMon});
            this.grdCongThucDiemMon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdCongThucDiemMon_MouseUp);
            // 
            // grvCongThucDiemMon
            // 
            this.grvCongThucDiemMon.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn9,
            this.gridColumn10});
            this.grvCongThucDiemMon.GridControl = this.grdCongThucDiemMon;
            this.grvCongThucDiemMon.GroupPanelText = "Danh sách môn học và công thức điểm cho môn học(Thêm: F2; Sửa: F3; Xóa: Delete)";
            this.grvCongThucDiemMon.IndicatorWidth = 35;
            this.grvCongThucDiemMon.Name = "grvCongThucDiemMon";
            this.grvCongThucDiemMon.OptionsBehavior.Editable = false;
            this.grvCongThucDiemMon.OptionsNavigation.AutoFocusNewRow = true;
            this.grvCongThucDiemMon.OptionsView.EnableAppearanceEvenRow = true;
            this.grvCongThucDiemMon.OptionsView.EnableAppearanceOddRow = true;
            this.grvCongThucDiemMon.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvCongThucDiemMon_FocusedRowChanged);
            this.grvCongThucDiemMon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvCongThucDiemMon_KeyDown);
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.Caption = "Tên môn";
            this.gridColumn9.FieldName = "TenMonHoc";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 0;
            this.gridColumn9.Width = 191;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.Caption = "Công thức điểm";
            this.gridColumn10.FieldName = "CongThuc";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            this.gridColumn10.Width = 387;
            // 
            // ImageCollection1
            // 
            this.ImageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ImageCollection1.ImageStream")));
            // 
            // barManager
            // 
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barbtnThem,
            this.barbtnSua,
            this.barbtnXoa});
            this.barManager.MaxItemId = 3;
            // 
            // barbtnThem
            // 
            this.barbtnThem.Caption = "Thêm công thức";
            this.barbtnThem.Id = 0;
            this.barbtnThem.Name = "barbtnThem";
            this.barbtnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnThem_ItemClick);
            // 
            // barbtnSua
            // 
            this.barbtnSua.Caption = "Sửa công thức";
            this.barbtnSua.Id = 1;
            this.barbtnSua.Name = "barbtnSua";
            this.barbtnSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnSua_ItemClick);
            // 
            // barbtnXoa
            // 
            this.barbtnXoa.Caption = "Xóa công thức";
            this.barbtnXoa.Id = 2;
            this.barbtnXoa.Name = "barbtnXoa";
            this.barbtnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnXoa_ItemClick);
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnThem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnSua),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnXoa)});
            this.popupMenu.Manager = this.barManager;
            this.popupMenu.Name = "popupMenu";
            // 
            // uctrlLop
            // 
            this.uctrlLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctrlLop.Location = new System.Drawing.Point(0, 0);
            this.uctrlLop.Name = "uctrlLop";
            this.uctrlLop.Size = new System.Drawing.Size(296, 489);
            this.uctrlLop.TabIndex = 0;
            // 
            // frmCongThucDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 493);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmCongThucDiem";
            this.Tag = "frmCongThucDiem";
            this.Text = "CONG THUC DIEM";
            this.Load += new System.EventHandler(this.frmCongThucDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCongThucDiemMon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCongThucDiemMon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        internal DevExpress.Utils.ImageCollection ImageCollection1;
        private DevExpress.XtraGrid.GridControl grdCongThucDiemMon;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCongThucDiemMon;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barbtnThem;
        private DevExpress.XtraBars.BarButtonItem barbtnSua;
        private DevExpress.XtraBars.BarButtonItem barbtnXoa;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private ucTreeLop uctrlLop;
    }
}