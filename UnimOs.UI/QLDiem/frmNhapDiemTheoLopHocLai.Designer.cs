namespace UnimOs.UI
{
    partial class frmNhapDiemTheoLopHocLai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhapDiemTheoLopHocLai));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdLopHocLai = new DevExpress.XtraGrid.GridControl();
            this.grvLopHocLai = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnTongHop = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.cmbLanThi = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnCapNhat = new DevExpress.XtraEditors.SimpleButton();
            this.grdDiem = new DevExpress.XtraGrid.GridControl();
            this.bgvDiem = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.grbSinhVien = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.TenLop = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grbNhapDiem = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grbDiemThi = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grbDiemTK = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLopHocLai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLopHocLai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLanThi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgvDiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.grdLopHocLai);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.layoutControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(894, 412);
            this.splitContainerControl1.SplitterPosition = 300;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // grdLopHocLai
            // 
            this.grdLopHocLai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLopHocLai.Location = new System.Drawing.Point(0, 0);
            this.grdLopHocLai.MainView = this.grvLopHocLai;
            this.grdLopHocLai.Name = "grdLopHocLai";
            this.grdLopHocLai.Size = new System.Drawing.Size(296, 408);
            this.grdLopHocLai.TabIndex = 0;
            this.grdLopHocLai.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLopHocLai});
            // 
            // grvLopHocLai
            // 
            this.grvLopHocLai.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.grvLopHocLai.GridControl = this.grdLopHocLai;
            this.grvLopHocLai.IndicatorWidth = 25;
            this.grvLopHocLai.Name = "grvLopHocLai";
            this.grvLopHocLai.OptionsBehavior.Editable = false;
            this.grvLopHocLai.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvLopHocLai.OptionsView.ShowGroupPanel = false;
            this.grvLopHocLai.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvLopHocLai_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Tên lớp";
            this.gridColumn1.FieldName = "TenLop";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Tên môn học";
            this.gridColumn2.FieldName = "TenMonHoc";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.Options.UseForeColor = true;
            this.layoutControl1.Appearance.DisabledLayoutItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutItem.Options.UseForeColor = true;
            this.layoutControl1.Controls.Add(this.btnTongHop);
            this.layoutControl1.Controls.Add(this.cmbLanThi);
            this.layoutControl1.Controls.Add(this.btnCapNhat);
            this.layoutControl1.Controls.Add(this.grdDiem);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(584, 408);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnTongHop
            // 
            this.btnTongHop.ImageIndex = 14;
            this.btnTongHop.ImageList = this.imageCollection2;
            this.btnTongHop.Location = new System.Drawing.Point(393, 378);
            this.btnTongHop.Name = "btnTongHop";
            this.btnTongHop.Size = new System.Drawing.Size(85, 24);
            this.btnTongHop.StyleController = this.layoutControl1;
            this.btnTongHop.TabIndex = 27;
            this.btnTongHop.Text = "Tổng hợp";
            this.btnTongHop.Click += new System.EventHandler(this.btnTongHop_Click);
            // 
            // imageCollection2
            // 
            this.imageCollection2.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection2.ImageStream")));
            // 
            // cmbLanThi
            // 
            this.cmbLanThi.EditValue = "1";
            this.cmbLanThi.Location = new System.Drawing.Point(48, 7);
            this.cmbLanThi.Name = "cmbLanThi";
            this.cmbLanThi.Properties.Appearance.Options.UseTextOptions = true;
            this.cmbLanThi.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cmbLanThi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbLanThi.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cmbLanThi.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbLanThi.Size = new System.Drawing.Size(58, 20);
            this.cmbLanThi.StyleController = this.layoutControl1;
            this.cmbLanThi.TabIndex = 26;
            this.cmbLanThi.SelectedIndexChanged += new System.EventHandler(this.cmbLanThi_SelectedIndexChanged);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.ImageIndex = 10;
            this.btnCapNhat.ImageList = this.imageCollection2;
            this.btnCapNhat.Location = new System.Drawing.Point(489, 378);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(89, 24);
            this.btnCapNhat.StyleController = this.layoutControl1;
            this.btnCapNhat.TabIndex = 23;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // grdDiem
            // 
            this.grdDiem.Location = new System.Drawing.Point(7, 43);
            this.grdDiem.MainView = this.bgvDiem;
            this.grdDiem.Name = "grdDiem";
            this.grdDiem.Size = new System.Drawing.Size(571, 324);
            this.grdDiem.TabIndex = 22;
            this.grdDiem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bgvDiem});
            // 
            // bgvDiem
            // 
            this.bgvDiem.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.grbSinhVien,
            this.grbNhapDiem,
            this.grbDiemThi,
            this.grbDiemTK});
            this.bgvDiem.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gridColumn6,
            this.gridColumn7,
            this.TenLop,
            this.bandedGridColumn1});
            this.bgvDiem.GridControl = this.grdDiem;
            this.bgvDiem.IndicatorWidth = 30;
            this.bgvDiem.Name = "bgvDiem";
            this.bgvDiem.OptionsSelection.MultiSelect = true;
            this.bgvDiem.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.bgvDiem.OptionsView.ColumnAutoWidth = false;
            this.bgvDiem.OptionsView.EnableAppearanceEvenRow = true;
            this.bgvDiem.OptionsView.EnableAppearanceOddRow = true;
            this.bgvDiem.OptionsView.ShowGroupPanel = false;
            this.bgvDiem.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.bgvDiem_ValidatingEditor);
            this.bgvDiem.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.bgvDiem_CustomDrawRowIndicator);
            this.bgvDiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bgvDiem_KeyDown);
            // 
            // grbSinhVien
            // 
            this.grbSinhVien.AppearanceHeader.Options.UseTextOptions = true;
            this.grbSinhVien.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grbSinhVien.Caption = "Danh sách sinh viên";
            this.grbSinhVien.Columns.Add(this.gridColumn6);
            this.grbSinhVien.Columns.Add(this.gridColumn7);
            this.grbSinhVien.Columns.Add(this.TenLop);
            this.grbSinhVien.Name = "grbSinhVien";
            this.grbSinhVien.Width = 300;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "Mã SV";
            this.gridColumn6.FieldName = "MaSinhVien";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "Tên sinh viên";
            this.gridColumn7.FieldName = "HoVaTen";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.Width = 150;
            // 
            // TenLop
            // 
            this.TenLop.Caption = "Tên lớp";
            this.TenLop.FieldName = "TenLop";
            this.TenLop.Name = "TenLop";
            this.TenLop.OptionsColumn.AllowEdit = false;
            this.TenLop.Visible = true;
            // 
            // grbNhapDiem
            // 
            this.grbNhapDiem.AppearanceHeader.Options.UseTextOptions = true;
            this.grbNhapDiem.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grbNhapDiem.Caption = "Nhập điểm thành phần";
            this.grbNhapDiem.Name = "grbNhapDiem";
            // 
            // grbDiemThi
            // 
            this.grbDiemThi.AppearanceHeader.Options.UseTextOptions = true;
            this.grbDiemThi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grbDiemThi.Caption = "Điểm Thi";
            this.grbDiemThi.Name = "grbDiemThi";
            // 
            // grbDiemTK
            // 
            this.grbDiemTK.AppearanceHeader.Options.UseTextOptions = true;
            this.grbDiemTK.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grbDiemTK.Caption = "Tổng kết";
            this.grbDiemTK.Columns.Add(this.bandedGridColumn1);
            this.grbDiemTK.Name = "grbDiemTK";
            this.grbDiemTK.Width = 75;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5,
            this.layoutControlItem2,
            this.emptySpaceItem3,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(584, 408);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.grdDiem;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 36);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(582, 335);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnCapNhat;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(482, 371);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(100, 35);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(100, 35);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(100, 35);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 371);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(386, 35);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(110, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(472, 36);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem3.Control = this.cmbLanThi;
            this.layoutControlItem3.CustomizationFormText = "Lần thi:";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(110, 36);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(110, 36);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(110, 36);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Lần thi:";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(36, 20);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnTongHop;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(386, 371);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(96, 35);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(96, 35);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(96, 35);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // bandedGridColumn1
            // 
            this.bandedGridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn1.Caption = "TBMH";
            this.bandedGridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn1.FieldName = "DiemTK";
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            this.bandedGridColumn1.Visible = true;
            // 
            // frmNhapDiemTheoLopHocLai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 412);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmNhapDiemTheoLopHocLai";
            this.Tag = "frmNhapDiemTheoLopHocLai";
            this.Text = "NHAP DIEM MON HOC THEO LOP TO CHUC HOC LAI";
            this.Load += new System.EventHandler(this.frmNhapDiemTheoLopHocLai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLopHocLai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLopHocLai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLanThi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgvDiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdDiem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton btnCapNhat;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.Utils.ImageCollection imageCollection2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bgvDiem;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand grbSinhVien;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn6;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn7;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand grbNhapDiem;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbLanThi;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TenLop;
        private DevExpress.XtraGrid.GridControl grdLopHocLai;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLopHocLai;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand grbDiemThi;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand grbDiemTK;
        private DevExpress.XtraEditors.SimpleButton btnTongHop;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn1;
    }
}