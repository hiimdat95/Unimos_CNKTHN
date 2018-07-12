namespace UnimOs.UI
{
    partial class frmTKB_Print
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
            this.tabInTKB = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabLop = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.uctrlLop = new UnimOs.UI.ucTreeLop();
            this.webBrowserLop = new System.Windows.Forms.WebBrowser();
            this.xtraTabGiaoVien = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPhongHoc = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabInTKB)).BeginInit();
            this.tabInTKB.SuspendLayout();
            this.xtraTabLop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabInTKB
            // 
            this.tabInTKB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabInTKB.Location = new System.Drawing.Point(0, 0);
            this.tabInTKB.Name = "tabInTKB";
            this.tabInTKB.SelectedTabPage = this.xtraTabLop;
            this.tabInTKB.Size = new System.Drawing.Size(824, 465);
            this.tabInTKB.TabIndex = 0;
            this.tabInTKB.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabLop,
            this.xtraTabGiaoVien,
            this.xtraTabPhongHoc});
            this.tabInTKB.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabInTKB_SelectedPageChanged);
            // 
            // xtraTabLop
            // 
            this.xtraTabLop.Controls.Add(this.splitContainerControl1);
            this.xtraTabLop.Name = "xtraTabLop";
            this.xtraTabLop.Size = new System.Drawing.Size(815, 434);
            this.xtraTabLop.Text = "Thời khóa biểu Lớp";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.uctrlLop);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.webBrowserLop);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(815, 434);
            this.splitContainerControl1.SplitterPosition = 250;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // uctrlLop
            // 
            this.uctrlLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctrlLop.Location = new System.Drawing.Point(0, 0);
            this.uctrlLop.Name = "uctrlLop";
            this.uctrlLop.Size = new System.Drawing.Size(246, 430);
            this.uctrlLop.TabIndex = 0;
            // 
            // webBrowserLop
            // 
            this.webBrowserLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserLop.Location = new System.Drawing.Point(0, 0);
            this.webBrowserLop.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserLop.Name = "webBrowserLop";
            this.webBrowserLop.Size = new System.Drawing.Size(555, 430);
            this.webBrowserLop.TabIndex = 0;
            // 
            // xtraTabGiaoVien
            // 
            this.xtraTabGiaoVien.Name = "xtraTabGiaoVien";
            this.xtraTabGiaoVien.Size = new System.Drawing.Size(815, 434);
            this.xtraTabGiaoVien.Text = "Thời khóa biểu Giáo viên";
            // 
            // xtraTabPhongHoc
            // 
            this.xtraTabPhongHoc.Name = "xtraTabPhongHoc";
            this.xtraTabPhongHoc.Size = new System.Drawing.Size(815, 434);
            this.xtraTabPhongHoc.Text = "Thời khóa biểu Phòng học";
            // 
            // frmTKB_Print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 465);
            this.Controls.Add(this.tabInTKB);
            this.Name = "frmTKB_Print";
            this.Tag = "frmTKB_Print";
            this.Text = "IN THOI KHOA BIEU";
            this.Load += new System.EventHandler(this.frmTKB_Print_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabInTKB)).EndInit();
            this.tabInTKB.ResumeLayout(false);
            this.xtraTabLop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabInTKB;
        private DevExpress.XtraTab.XtraTabPage xtraTabLop;
        private DevExpress.XtraTab.XtraTabPage xtraTabGiaoVien;
        private DevExpress.XtraTab.XtraTabPage xtraTabPhongHoc;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.WebBrowser webBrowserLop;
        private ucTreeLop uctrlLop;

    }
}