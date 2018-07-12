namespace UnimOs.UI
{
    partial class ucHeTrinhDo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.cmbNganh = new DevExpress.XtraEditors.LookUpEdit();
            this.cmbLop = new DevExpress.XtraEditors.LookUpEdit();
            this.cmbKhoaHoc = new DevExpress.XtraEditors.LookUpEdit();
            this.cmbKhoa = new DevExpress.XtraEditors.LookUpEdit();
            this.cmbTrinhDo = new DevExpress.XtraEditors.LookUpEdit();
            this.cmbHe = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNganh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoaHoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTrinhDo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.Options.UseForeColor = true;
            this.layoutControl1.Appearance.DisabledLayoutItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutItem.Options.UseForeColor = true;
            this.layoutControl1.Controls.Add(this.cmbNganh);
            this.layoutControl1.Controls.Add(this.cmbLop);
            this.layoutControl1.Controls.Add(this.cmbKhoaHoc);
            this.layoutControl1.Controls.Add(this.cmbKhoa);
            this.layoutControl1.Controls.Add(this.cmbTrinhDo);
            this.layoutControl1.Controls.Add(this.cmbHe);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(932, 69);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // cmbNganh
            // 
            this.cmbNganh.Location = new System.Drawing.Point(351, 38);
            this.cmbNganh.Name = "cmbNganh";
            this.cmbNganh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbNganh.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenNganh", "Tên ngành"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaNganh", 10, "Mã ngành")});
            this.cmbNganh.Properties.DisplayMember = "TenNganh";
            this.cmbNganh.Properties.NullText = "";
            this.cmbNganh.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbNganh.Properties.ValueMember = "DM_NganhID";
            this.cmbNganh.Size = new System.Drawing.Size(254, 20);
            this.cmbNganh.StyleController = this.layoutControl1;
            this.cmbNganh.TabIndex = 9;
            this.cmbNganh.EditValueChanged += new System.EventHandler(this.cmbTrinhDo_EditValueChanged);
            this.cmbNganh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbHe_KeyDown);
            // 
            // cmbLop
            // 
            this.cmbLop.Location = new System.Drawing.Point(664, 38);
            this.cmbLop.Name = "cmbLop";
            this.cmbLop.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbLop.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenLop", "Tên lớp")});
            this.cmbLop.Properties.DisplayMember = "TenLop";
            this.cmbLop.Properties.NullText = "";
            this.cmbLop.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbLop.Properties.ValueMember = "DM_LopID";
            this.cmbLop.Size = new System.Drawing.Size(262, 20);
            this.cmbLop.StyleController = this.layoutControl1;
            this.cmbLop.TabIndex = 8;
            this.cmbLop.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbHe_KeyDown);
            // 
            // cmbKhoaHoc
            // 
            this.cmbKhoaHoc.Location = new System.Drawing.Point(55, 38);
            this.cmbKhoaHoc.Name = "cmbKhoaHoc";
            this.cmbKhoaHoc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbKhoaHoc.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenKhoaHoc", "Tên khóa"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NamVaoTruong", 10, "Năm vào"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NamRaTruong", 10, "Năm ra")});
            this.cmbKhoaHoc.Properties.DisplayMember = "TenKhoaHoc";
            this.cmbKhoaHoc.Properties.NullText = "";
            this.cmbKhoaHoc.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbKhoaHoc.Properties.ValueMember = "DM_KhoaHocID";
            this.cmbKhoaHoc.Size = new System.Drawing.Size(237, 20);
            this.cmbKhoaHoc.StyleController = this.layoutControl1;
            this.cmbKhoaHoc.TabIndex = 7;
            this.cmbKhoaHoc.EditValueChanged += new System.EventHandler(this.cmbTrinhDo_EditValueChanged);
            this.cmbKhoaHoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbHe_KeyDown);
            // 
            // cmbKhoa
            // 
            this.cmbKhoa.Location = new System.Drawing.Point(664, 7);
            this.cmbKhoa.Name = "cmbKhoa";
            this.cmbKhoa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbKhoa.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenKhoa", "Tên khoa"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaKhoa", 10, "Mã khoa")});
            this.cmbKhoa.Properties.DisplayMember = "TenKhoa";
            this.cmbKhoa.Properties.NullText = "";
            this.cmbKhoa.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbKhoa.Properties.ValueMember = "DM_KhoaID";
            this.cmbKhoa.Size = new System.Drawing.Size(262, 20);
            this.cmbKhoa.StyleController = this.layoutControl1;
            this.cmbKhoa.TabIndex = 6;
            this.cmbKhoa.EditValueChanged += new System.EventHandler(this.cmbTrinhDo_EditValueChanged);
            this.cmbKhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbHe_KeyDown);
            // 
            // cmbTrinhDo
            // 
            this.cmbTrinhDo.Location = new System.Drawing.Point(351, 7);
            this.cmbTrinhDo.Name = "cmbTrinhDo";
            this.cmbTrinhDo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTrinhDo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenTrinhDo", "Trình độ"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenHe", 10, "Hệ")});
            this.cmbTrinhDo.Properties.DisplayMember = "TenTrinhDo";
            this.cmbTrinhDo.Properties.NullText = "";
            this.cmbTrinhDo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbTrinhDo.Properties.ValueMember = "DM_TrinhDoID";
            this.cmbTrinhDo.Size = new System.Drawing.Size(254, 20);
            this.cmbTrinhDo.StyleController = this.layoutControl1;
            this.cmbTrinhDo.TabIndex = 5;
            this.cmbTrinhDo.EditValueChanged += new System.EventHandler(this.cmbTrinhDo_EditValueChanged);
            this.cmbTrinhDo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbHe_KeyDown);
            // 
            // cmbHe
            // 
            this.cmbHe.Location = new System.Drawing.Point(55, 7);
            this.cmbHe.Name = "cmbHe";
            this.cmbHe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbHe.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenHe", "Tên hệ"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaHe", 10, "Mã hệ")});
            this.cmbHe.Properties.DisplayMember = "TenHe";
            this.cmbHe.Properties.NullText = "";
            this.cmbHe.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbHe.Properties.ValueMember = "DM_HeID";
            this.cmbHe.Size = new System.Drawing.Size(237, 20);
            this.cmbHe.StyleController = this.layoutControl1;
            this.cmbHe.TabIndex = 4;
            this.cmbHe.EditValueChanged += new System.EventHandler(this.cmbHe_EditValueChanged);
            this.cmbHe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbHe_KeyDown);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(932, 69);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem1.Control = this.cmbHe;
            this.layoutControlItem1.CustomizationFormText = "Hệ:";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(296, 31);
            this.layoutControlItem1.Text = "Hệ:";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(43, 20);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem2.Control = this.cmbTrinhDo;
            this.layoutControlItem2.CustomizationFormText = "Trình độ:";
            this.layoutControlItem2.Location = new System.Drawing.Point(296, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(313, 31);
            this.layoutControlItem2.Text = "Trình độ:";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(43, 20);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem3.Control = this.cmbKhoa;
            this.layoutControlItem3.CustomizationFormText = "Khoa:";
            this.layoutControlItem3.Location = new System.Drawing.Point(609, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(321, 31);
            this.layoutControlItem3.Text = "Khoa:";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(43, 20);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem4.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem4.Control = this.cmbKhoaHoc;
            this.layoutControlItem4.CustomizationFormText = "Khóa:";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 31);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(296, 36);
            this.layoutControlItem4.Text = "Khóa:";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(43, 20);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem5.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem5.Control = this.cmbLop;
            this.layoutControlItem5.CustomizationFormText = "Lớp";
            this.layoutControlItem5.Location = new System.Drawing.Point(609, 31);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(321, 36);
            this.layoutControlItem5.Text = "Lớp";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(43, 20);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem6.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem6.Control = this.cmbNganh;
            this.layoutControlItem6.CustomizationFormText = "Ngành:";
            this.layoutControlItem6.Location = new System.Drawing.Point(296, 31);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(313, 36);
            this.layoutControlItem6.Text = "Ngành:";
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(43, 20);
            // 
            // ucHeTrinhDo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "ucHeTrinhDo";
            this.Size = new System.Drawing.Size(932, 69);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbNganh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoaHoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKhoa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTrinhDo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        public DevExpress.XtraEditors.LookUpEdit cmbTrinhDo;
        public DevExpress.XtraEditors.LookUpEdit cmbHe;
        public DevExpress.XtraEditors.LookUpEdit cmbLop;
        public DevExpress.XtraEditors.LookUpEdit cmbKhoaHoc;
        public DevExpress.XtraEditors.LookUpEdit cmbKhoa;
        public DevExpress.XtraEditors.LookUpEdit cmbNganh;
    }
}
