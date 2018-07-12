namespace UnimOs.UI
{
    partial class frmThamSoHeThong
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
            this.tabThamSo = new DevExpress.XtraTab.XtraTabControl();
            this.tabXepLich = new DevExpress.XtraTab.XtraTabPage();
            this.grdXepLich = new DevExpress.XtraGrid.GridControl();
            this.grvXepLich = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabThamSo)).BeginInit();
            this.tabThamSo.SuspendLayout();
            this.tabXepLich.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdXepLich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXepLich)).BeginInit();
            this.SuspendLayout();
            // 
            // tabThamSo
            // 
            this.tabThamSo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabThamSo.Location = new System.Drawing.Point(0, 0);
            this.tabThamSo.Name = "tabThamSo";
            this.tabThamSo.SelectedTabPage = this.tabXepLich;
            this.tabThamSo.Size = new System.Drawing.Size(760, 436);
            this.tabThamSo.TabIndex = 0;
            this.tabThamSo.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabXepLich});
            // 
            // tabXepLich
            // 
            this.tabXepLich.Controls.Add(this.grdXepLich);
            this.tabXepLich.Name = "tabXepLich";
            this.tabXepLich.Size = new System.Drawing.Size(751, 405);
            this.tabXepLich.Text = "Tham số xếp lịch";
            // 
            // grdXepLich
            // 
            this.grdXepLich.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdXepLich.Location = new System.Drawing.Point(0, 0);
            this.grdXepLich.MainView = this.grvXepLich;
            this.grdXepLich.Name = "grdXepLich";
            this.grdXepLich.Size = new System.Drawing.Size(751, 405);
            this.grdXepLich.TabIndex = 0;
            this.grdXepLich.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvXepLich});
            // 
            // grvXepLich
            // 
            this.grvXepLich.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.grvXepLich.GridControl = this.grdXepLich;
            this.grvXepLich.IndicatorWidth = 35;
            this.grvXepLich.Name = "grvXepLich";
            this.grvXepLich.OptionsView.EnableAppearanceEvenRow = true;
            this.grvXepLich.OptionsView.EnableAppearanceOddRow = true;
            this.grvXepLich.OptionsView.ShowGroupPanel = false;
            this.grvXepLich.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvXepLich_FocusedRowChanged);
            this.grvXepLich.DoubleClick += new System.EventHandler(this.grvXepLich_DoubleClick);
            this.grvXepLich.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvXepLich_CustomDrawRowIndicator);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Mã tham số";
            this.gridColumn1.FieldName = "MaThamSoHeThong";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 150;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Tên tham số";
            this.gridColumn2.FieldName = "TenThamSoHeThong";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 250;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Giá trị";
            this.gridColumn3.FieldName = "GiaTri";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.FixedWidth = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 60;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Ghi chú";
            this.gridColumn4.FieldName = "GhiChu";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 200;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Sử dụng";
            this.gridColumn5.FieldName = "TrangThai";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.FixedWidth = true;
            this.gridColumn5.Width = 70;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "Thứ tự";
            this.gridColumn6.FieldName = "SapXep";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.FixedWidth = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            // 
            // frmThamSoHeThong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 436);
            this.Controls.Add(this.tabThamSo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThamSoHeThong";
            this.Tag = "frmThamSoHeThong";
            this.Text = "THAM SO HE THONG";
            this.Load += new System.EventHandler(this.frmThamSoHeThong_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmThamSoHeThong_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabThamSo)).EndInit();
            this.tabThamSo.ResumeLayout(false);
            this.tabXepLich.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdXepLich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXepLich)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabThamSo;
        private DevExpress.XtraTab.XtraTabPage tabXepLich;
        private DevExpress.XtraGrid.GridControl grdXepLich;
        private DevExpress.XtraGrid.Views.Grid.GridView grvXepLich;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}