namespace UnimOs.UI
{
    partial class frmPhanBoPhongHoc
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.rdCaHoc = new DevExpress.XtraEditors.RadioGroup();
            this.cmbTuTuan = new DevExpress.XtraEditors.LookUpEdit();
            this.cmbDenTuan = new DevExpress.XtraEditors.LookUpEdit();
            this.txtNamHoc = new DevExpress.XtraEditors.TextEdit();
            this.rdApDung = new DevExpress.XtraEditors.RadioGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.grdPhongHoc = new DevExpress.XtraGrid.GridControl();
            this.grvPhongHoc = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdLop = new DevExpress.XtraGrid.GridControl();
            this.grvLop = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdCaHoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTuTuan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDenTuan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNamHoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdApDung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPhongHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPhongHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.Options.UseForeColor = true;
            this.layoutControl1.Appearance.DisabledLayoutItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutItem.Options.UseForeColor = true;
            this.layoutControl1.Controls.Add(this.rdCaHoc);
            this.layoutControl1.Controls.Add(this.cmbTuTuan);
            this.layoutControl1.Controls.Add(this.cmbDenTuan);
            this.layoutControl1.Controls.Add(this.txtNamHoc);
            this.layoutControl1.Controls.Add(this.rdApDung);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(967, 81);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // rdCaHoc
            // 
            this.rdCaHoc.EditValue = 0;
            this.rdCaHoc.Location = new System.Drawing.Point(497, 8);
            this.rdCaHoc.Name = "rdCaHoc";
            this.rdCaHoc.Properties.Columns = 3;
            this.rdCaHoc.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Sáng"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Chiều"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Tối")});
            this.rdCaHoc.Size = new System.Drawing.Size(350, 24);
            this.rdCaHoc.StyleController = this.layoutControl1;
            this.rdCaHoc.TabIndex = 9;
            this.rdCaHoc.EditValueChanged += new System.EventHandler(this.rdCaHoc_EditValueChanged);
            // 
            // cmbTuTuan
            // 
            this.cmbTuTuan.Location = new System.Drawing.Point(222, 8);
            this.cmbTuTuan.Name = "cmbTuTuan";
            this.cmbTuTuan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTuTuan.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TuanThu", "Tuần thứ"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TuNgay", "Từ ngày", 20, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy", true, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DenNgay", "Đến ngày", 20, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy", true, DevExpress.Utils.HorzAlignment.Default)});
            this.cmbTuTuan.Properties.DisplayMember = "TuanThu";
            this.cmbTuTuan.Properties.NullText = "";
            this.cmbTuTuan.Properties.ValueMember = "XL_TuanID";
            this.cmbTuTuan.Size = new System.Drawing.Size(97, 20);
            this.cmbTuTuan.StyleController = this.layoutControl1;
            this.cmbTuTuan.TabIndex = 6;
            this.cmbTuTuan.EditValueChanged += new System.EventHandler(this.cmbTuTuan_EditValueChanged);
            // 
            // cmbDenTuan
            // 
            this.cmbDenTuan.Location = new System.Drawing.Point(384, 8);
            this.cmbDenTuan.Name = "cmbDenTuan";
            this.cmbDenTuan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDenTuan.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TuanThu", "Tuần thứ"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TuNgay", "Từ ngày", 20, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy", true, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DenNgay", "Đến ngày", 20, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy", true, DevExpress.Utils.HorzAlignment.Default)});
            this.cmbDenTuan.Properties.DisplayMember = "TuanThu";
            this.cmbDenTuan.Properties.NullText = "";
            this.cmbDenTuan.Properties.ValueMember = "XL_TuanID";
            this.cmbDenTuan.Size = new System.Drawing.Size(102, 20);
            this.cmbDenTuan.StyleController = this.layoutControl1;
            this.cmbDenTuan.TabIndex = 5;
            this.cmbDenTuan.EditValueChanged += new System.EventHandler(this.cmbDenTuan_EditValueChanged);
            // 
            // txtNamHoc
            // 
            this.txtNamHoc.Location = new System.Drawing.Point(62, 8);
            this.txtNamHoc.Name = "txtNamHoc";
            this.txtNamHoc.Properties.ReadOnly = true;
            this.txtNamHoc.Size = new System.Drawing.Size(95, 20);
            this.txtNamHoc.StyleController = this.layoutControl1;
            this.txtNamHoc.TabIndex = 4;
            // 
            // rdApDung
            // 
            this.rdApDung.EditValue = 0;
            this.rdApDung.Location = new System.Drawing.Point(8, 43);
            this.rdApDung.Name = "rdApDung";
            this.rdApDung.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Phân phòng áp dụng cho tất cả các tuần"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Áp dụng cho các tuần được chọn")});
            this.rdApDung.Size = new System.Drawing.Size(952, 31);
            this.rdApDung.StyleController = this.layoutControl1;
            this.rdApDung.TabIndex = 10;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem6,
            this.layoutControlItem4,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(967, 81);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem2.Control = this.cmbDenTuan;
            this.layoutControlItem2.CustomizationFormText = "Đến tuần:";
            this.layoutControlItem2.Location = new System.Drawing.Point(322, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(167, 35);
            this.layoutControlItem2.Text = "Đến tuần:";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(49, 20);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem1.Control = this.txtNamHoc;
            this.layoutControlItem1.CustomizationFormText = "Năm học:";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(160, 35);
            this.layoutControlItem1.Text = "Năm học:";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(49, 20);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem3.Control = this.cmbTuTuan;
            this.layoutControlItem3.CustomizationFormText = "Từ tuần:";
            this.layoutControlItem3.Location = new System.Drawing.Point(160, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(162, 35);
            this.layoutControlItem3.Text = "Từ tuần:";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(49, 20);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.rdCaHoc;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(489, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(361, 35);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.rdApDung;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 35);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(963, 42);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(850, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(113, 35);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // grdPhongHoc
            // 
            this.grdPhongHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPhongHoc.Location = new System.Drawing.Point(0, 0);
            this.grdPhongHoc.MainView = this.grvPhongHoc;
            this.grdPhongHoc.Name = "grdPhongHoc";
            this.grdPhongHoc.Size = new System.Drawing.Size(367, 406);
            this.grdPhongHoc.TabIndex = 12;
            this.grdPhongHoc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPhongHoc});
            this.grdPhongHoc.DragOver += new System.Windows.Forms.DragEventHandler(this.grdPhongHoc_DragOver);
            this.grdPhongHoc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grdPhongHoc_MouseMove);
            // 
            // grvPhongHoc
            // 
            this.grvPhongHoc.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.grvPhongHoc.GridControl = this.grdPhongHoc;
            this.grvPhongHoc.GroupCount = 1;
            this.grvPhongHoc.Name = "grvPhongHoc";
            this.grvPhongHoc.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvPhongHoc.OptionsBehavior.Editable = false;
            this.grvPhongHoc.OptionsView.EnableAppearanceEvenRow = true;
            this.grvPhongHoc.OptionsView.EnableAppearanceOddRow = true;
            this.grvPhongHoc.OptionsView.ShowGroupPanel = false;
            this.grvPhongHoc.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn4, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvPhongHoc.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvPhongHoc_FocusedRowChanged);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tên tòa nhà";
            this.gridColumn4.FieldName = "TenToaNha";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Tên phòng học";
            this.gridColumn5.FieldName = "TenPhongHoc";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Sức chứa";
            this.gridColumn6.FieldName = "SucChua";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            // 
            // grdLop
            // 
            this.grdLop.AllowDrop = true;
            this.grdLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLop.Location = new System.Drawing.Point(0, 0);
            this.grdLop.MainView = this.grvLop;
            this.grdLop.Name = "grdLop";
            this.grdLop.Size = new System.Drawing.Size(582, 406);
            this.grdLop.TabIndex = 11;
            this.grdLop.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLop});
            this.grdLop.DragOver += new System.Windows.Forms.DragEventHandler(this.grdLop_DragOver);
            this.grdLop.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdLop_DragDrop);
            // 
            // grvLop
            // 
            this.grvLop.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.grvLop.GridControl = this.grdLop;
            this.grvLop.Name = "grvLop";
            this.grvLop.OptionsBehavior.Editable = false;
            this.grvLop.OptionsView.EnableAppearanceEvenRow = true;
            this.grvLop.OptionsView.EnableAppearanceOddRow = true;
            this.grvLop.OptionsView.ShowGroupPanel = false;
            this.grvLop.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvLop_KeyDown);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tên lớp";
            this.gridColumn1.FieldName = "TenLop";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Số sinh viên";
            this.gridColumn2.FieldName = "SoSinhVien";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Phòng học";
            this.gridColumn3.FieldName = "TenPhongHoc";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 81);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.grdLop);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grdPhongHoc);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(967, 412);
            this.splitContainerControl1.SplitterPosition = 588;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // frmPhanBoPhongHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 493);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmPhanBoPhongHoc";
            this.Tag = "frmPhanBoPhongHoc";
            this.Text = "PHAN BO PHONG HOC CO DINH CHO CAC LOP";
            this.Load += new System.EventHandler(this.frmPhanBoPhongHoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdCaHoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTuTuan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDenTuan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNamHoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdApDung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPhongHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPhongHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.RadioGroup rdCaHoc;
        private DevExpress.XtraEditors.LookUpEdit cmbTuTuan;
        private DevExpress.XtraEditors.LookUpEdit cmbDenTuan;
        private DevExpress.XtraEditors.TextEdit txtNamHoc;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.RadioGroup rdApDung;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.GridControl grdLop;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLop;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.GridControl grdPhongHoc;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPhongHoc;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
    }
}