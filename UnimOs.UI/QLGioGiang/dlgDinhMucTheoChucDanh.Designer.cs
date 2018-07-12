namespace UnimOs.UI
{
    partial class dlgDinhMucTheoChucDanh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgDinhMucTheoChucDanh));
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.ImageButton = new DevExpress.Utils.ImageCollection(this.components);
            this.cmbChucDanh = new DevExpress.XtraEditors.LookUpEdit();
            this.txtHeSoQuyDoi = new DevExpress.XtraEditors.TextEdit();
            this.txtHeSo = new DevExpress.XtraEditors.TextEdit();
            this.txtSoGioChuan = new DevExpress.XtraEditors.TextEdit();
            this.txtGioLamViec = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbChucDanh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeSoQuyDoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeSo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoGioChuan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGioLamViec.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.ImageIndex = 2;
            this.btnThoat.ImageList = this.ImageButton;
            this.btnThoat.Location = new System.Drawing.Point(295, 138);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(84, 22);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // ImageButton
            // 
            this.ImageButton.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ImageButton.ImageStream")));
            // 
            // cmbChucDanh
            // 
            this.cmbChucDanh.EnterMoveNextControl = true;
            this.cmbChucDanh.Location = new System.Drawing.Point(87, 9);
            this.cmbChucDanh.Name = "cmbChucDanh";
            this.cmbChucDanh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbChucDanh.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenChucDanh", "Tên chức danh")});
            this.cmbChucDanh.Properties.DisplayMember = "TenChucDanh";
            this.cmbChucDanh.Properties.NullText = "";
            this.cmbChucDanh.Properties.ValueMember = "DM_ChucDanhID";
            this.cmbChucDanh.Size = new System.Drawing.Size(289, 20);
            this.cmbChucDanh.TabIndex = 0;
            // 
            // txtHeSoQuyDoi
            // 
            this.txtHeSoQuyDoi.EditValue = "0";
            this.txtHeSoQuyDoi.EnterMoveNextControl = true;
            this.txtHeSoQuyDoi.Location = new System.Drawing.Point(169, 63);
            this.txtHeSoQuyDoi.Name = "txtHeSoQuyDoi";
            this.txtHeSoQuyDoi.Properties.DisplayFormat.FormatString = "f2";
            this.txtHeSoQuyDoi.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtHeSoQuyDoi.Properties.EditFormat.FormatString = "f2";
            this.txtHeSoQuyDoi.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtHeSoQuyDoi.Properties.Mask.EditMask = "f2";
            this.txtHeSoQuyDoi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtHeSoQuyDoi.Size = new System.Drawing.Size(62, 20);
            this.txtHeSoQuyDoi.TabIndex = 3;
            this.txtHeSoQuyDoi.Leave += new System.EventHandler(this.txtHeSoQuyDoi_Leave);
            // 
            // txtHeSo
            // 
            this.txtHeSo.EditValue = "0";
            this.txtHeSo.EnterMoveNextControl = true;
            this.txtHeSo.Location = new System.Drawing.Point(87, 35);
            this.txtHeSo.Name = "txtHeSo";
            this.txtHeSo.Properties.DisplayFormat.FormatString = "f2";
            this.txtHeSo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtHeSo.Properties.EditFormat.FormatString = "f2";
            this.txtHeSo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtHeSo.Properties.Mask.EditMask = "f2";
            this.txtHeSo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtHeSo.Size = new System.Drawing.Size(94, 20);
            this.txtHeSo.TabIndex = 1;
            // 
            // txtSoGioChuan
            // 
            this.txtSoGioChuan.EditValue = "0";
            this.txtSoGioChuan.EnterMoveNextControl = true;
            this.txtSoGioChuan.Location = new System.Drawing.Point(87, 92);
            this.txtSoGioChuan.Name = "txtSoGioChuan";
            this.txtSoGioChuan.Properties.DisplayFormat.FormatString = "f2";
            this.txtSoGioChuan.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSoGioChuan.Properties.EditFormat.FormatString = "f2";
            this.txtSoGioChuan.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSoGioChuan.Properties.Mask.EditMask = "f";
            this.txtSoGioChuan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSoGioChuan.Size = new System.Drawing.Size(94, 20);
            this.txtSoGioChuan.TabIndex = 4;
            // 
            // txtGioLamViec
            // 
            this.txtGioLamViec.EditValue = "0";
            this.txtGioLamViec.EnterMoveNextControl = true;
            this.txtGioLamViec.Location = new System.Drawing.Point(306, 35);
            this.txtGioLamViec.Name = "txtGioLamViec";
            this.txtGioLamViec.Properties.DisplayFormat.FormatString = "f2";
            this.txtGioLamViec.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtGioLamViec.Properties.EditFormat.FormatString = "f2";
            this.txtGioLamViec.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtGioLamViec.Properties.Mask.EditMask = "f2";
            this.txtGioLamViec.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtGioLamViec.Size = new System.Drawing.Size(70, 20);
            this.txtGioLamViec.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(25, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 13);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Chức danh:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(50, 38);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(31, 13);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "Hệ số:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 66);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(69, 13);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Hệ số quy đổi:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(230, 38);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 13);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Giờ làm việc:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(87, 66);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(76, 13);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "1 giờ chuẩn =";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(240, 66);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(68, 13);
            this.labelControl6.TabIndex = 11;
            this.labelControl6.Text = "Giờ làm việc";
            // 
            // btnLuu
            // 
            this.btnLuu.ImageIndex = 0;
            this.btnLuu.ImageList = this.ImageButton;
            this.btnLuu.Location = new System.Drawing.Point(202, 138);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(84, 22);
            this.btnLuu.TabIndex = 5;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(16, 95);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(65, 13);
            this.labelControl7.TabIndex = 11;
            this.labelControl7.Text = "Số giờ chuẩn:";
            // 
            // dlgDinhMucTheoChucDanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 175);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cmbChucDanh);
            this.Controls.Add(this.txtHeSoQuyDoi);
            this.Controls.Add(this.txtHeSo);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.txtSoGioChuan);
            this.Controls.Add(this.txtGioLamViec);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgDinhMucTheoChucDanh";
            this.Text = "DINH MUC THEO CHUC DANH";
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbChucDanh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeSoQuyDoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeSo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoGioChuan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGioLamViec.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtGioLamViec;
        private DevExpress.XtraEditors.TextEdit txtSoGioChuan;
        private DevExpress.XtraEditors.TextEdit txtHeSo;
        private DevExpress.XtraEditors.TextEdit txtHeSoQuyDoi;
        private DevExpress.XtraEditors.LookUpEdit cmbChucDanh;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.Utils.ImageCollection ImageButton;
    }
}