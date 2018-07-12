namespace UnimOs.UI
{
    partial class dlgChuyenDiem
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkThiLan2 = new DevExpress.XtraEditors.CheckEdit();
            this.chkThiLan1 = new DevExpress.XtraEditors.CheckEdit();
            this.chkDiemThanhPhan = new DevExpress.XtraEditors.CheckEdit();
            this.btnDongY = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.chkDiemThanhPhanL2 = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkThiLan2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkThiLan1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDiemThanhPhan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDiemThanhPhanL2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(9, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(439, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Thực hiện việc chuyển điểm đã nhập cho phòng đào tạo tổng hợp điểm";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(9, 51);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(456, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Sau khi thực hiện chuyển điểm mọi yêu cầu về thay đổi điểm cho sinh viên";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(9, 71);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(300, 14);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "phải thực hiện qua phòng đào tạo bằng văn bản";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(9, 107);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(436, 14);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Việc chuyển điểm được chia làm 2 giai đoạn là chuyển điểm thành phần";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(9, 127);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(124, 14);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "và chuyển điểm thi. ";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.chkThiLan2);
            this.groupControl1.Controls.Add(this.chkThiLan1);
            this.groupControl1.Controls.Add(this.chkDiemThanhPhanL2);
            this.groupControl1.Controls.Add(this.chkDiemThanhPhan);
            this.groupControl1.Location = new System.Drawing.Point(4, 160);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(465, 58);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Lựa chọn loại điểm để chuyển cho phòng đào tạo";
            // 
            // chkThiLan2
            // 
            this.chkThiLan2.Location = new System.Drawing.Point(393, 26);
            this.chkThiLan2.Name = "chkThiLan2";
            this.chkThiLan2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.chkThiLan2.Properties.Appearance.Options.UseFont = true;
            this.chkThiLan2.Properties.Caption = "Thi lần 2";
            this.chkThiLan2.Size = new System.Drawing.Size(75, 21);
            this.chkThiLan2.TabIndex = 2;
            // 
            // chkThiLan1
            // 
            this.chkThiLan1.Location = new System.Drawing.Point(159, 26);
            this.chkThiLan1.Name = "chkThiLan1";
            this.chkThiLan1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.chkThiLan1.Properties.Appearance.Options.UseFont = true;
            this.chkThiLan1.Properties.Caption = "Thi lần 1";
            this.chkThiLan1.Size = new System.Drawing.Size(75, 21);
            this.chkThiLan1.TabIndex = 1;
            // 
            // chkDiemThanhPhan
            // 
            this.chkDiemThanhPhan.Location = new System.Drawing.Point(2, 26);
            this.chkDiemThanhPhan.Name = "chkDiemThanhPhan";
            this.chkDiemThanhPhan.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.chkDiemThanhPhan.Properties.Appearance.Options.UseFont = true;
            this.chkDiemThanhPhan.Properties.Caption = "Điểm thành phần lần 1";
            this.chkDiemThanhPhan.Size = new System.Drawing.Size(157, 21);
            this.chkDiemThanhPhan.TabIndex = 0;
            // 
            // btnDongY
            // 
            this.btnDongY.Location = new System.Drawing.Point(309, 224);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(75, 23);
            this.btnDongY.TabIndex = 2;
            this.btnDongY.Text = "Đồng ý";
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(390, 224);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // chkDiemThanhPhanL2
            // 
            this.chkDiemThanhPhanL2.Location = new System.Drawing.Point(237, 26);
            this.chkDiemThanhPhanL2.Name = "chkDiemThanhPhanL2";
            this.chkDiemThanhPhanL2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.chkDiemThanhPhanL2.Properties.Appearance.Options.UseFont = true;
            this.chkDiemThanhPhanL2.Properties.Caption = "Điểm thành phần lần 2";
            this.chkDiemThanhPhanL2.Size = new System.Drawing.Size(157, 21);
            this.chkDiemThanhPhanL2.TabIndex = 0;
            // 
            // dlgChuyenDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 254);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDongY);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgChuyenDiem";
            this.Tag = "dlgChuyenDiem";
            this.Text = "CHUYEN DIEM CHO PHONG DAO TAO";
            this.Load += new System.EventHandler(this.dlgChuyenDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkThiLan2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkThiLan1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDiemThanhPhan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDiemThanhPhanL2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnDongY;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        public DevExpress.XtraEditors.CheckEdit chkDiemThanhPhan;
        public DevExpress.XtraEditors.CheckEdit chkThiLan2;
        public DevExpress.XtraEditors.CheckEdit chkThiLan1;
        public DevExpress.XtraEditors.CheckEdit chkDiemThanhPhanL2;
    }
}