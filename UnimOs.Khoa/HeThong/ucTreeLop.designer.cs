namespace UnimOs.Khoa
{
    partial class ucTreeLop
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTreeLop));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkExpandAll = new DevExpress.XtraEditors.CheckEdit();
            this.imageTreeLop = new DevExpress.Utils.ImageCollection(this.components);
            this.trlLop = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkExpandAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageTreeLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlLop)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkExpandAll);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(269, 28);
            this.panelControl1.TabIndex = 0;
            // 
            // chkExpandAll
            // 
            this.chkExpandAll.Location = new System.Drawing.Point(24, 6);
            this.chkExpandAll.Name = "chkExpandAll";
            this.chkExpandAll.Properties.Caption = "Mở rộng tất cả";
            this.chkExpandAll.Size = new System.Drawing.Size(105, 19);
            this.chkExpandAll.TabIndex = 0;
            this.chkExpandAll.CheckedChanged += new System.EventHandler(this.chkExpandAll_CheckedChanged);
            // 
            // imageTreeLop
            // 
            this.imageTreeLop.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageTreeLop.ImageStream")));
            // 
            // trlLop
            // 
            this.trlLop.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.trlLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trlLop.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.trlLop.Location = new System.Drawing.Point(0, 28);
            this.trlLop.Name = "trlLop";
            this.trlLop.OptionsBehavior.Editable = false;
            this.trlLop.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.trlLop.OptionsView.ShowIndicator = false;
            this.trlLop.SelectImageList = this.imageTreeLop;
            this.trlLop.Size = new System.Drawing.Size(269, 453);
            this.trlLop.TabIndex = 1;
            this.trlLop.AfterExpand += new DevExpress.XtraTreeList.NodeEventHandler(this.trlLop_AfterExpand);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.treeListColumn1.AppearanceCell.Options.UseFont = true;
            this.treeListColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.treeListColumn1.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn1.Caption = "Lớp";
            this.treeListColumn1.FieldName = "TenLop";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 159;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn2.Caption = "Ngành";
            this.treeListColumn2.FieldName = "TenNganh";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Width = 116;
            // 
            // ucTreeLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.trlLop);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucTreeLop";
            this.Size = new System.Drawing.Size(269, 481);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkExpandAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageTreeLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlLop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.Utils.ImageCollection imageTreeLop;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        public DevExpress.XtraTreeList.TreeList trlLop;
        public DevExpress.XtraEditors.CheckEdit chkExpandAll;
    }
}
