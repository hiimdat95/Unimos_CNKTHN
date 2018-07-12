namespace UnimOs.UI
{
    partial class frmTreeLop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTreeLop));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.uctrlLop = new UnimOs.UI.ucTreeLop();
            this.grdLop = new DevExpress.XtraGrid.GridControl();
            this.grvLop = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.imageTreeLop = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageTreeLop)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.uctrlLop);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grdLop);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(701, 437);
            this.splitContainerControl1.SplitterPosition = 300;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // uctrlLop
            // 
            this.uctrlLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctrlLop.Location = new System.Drawing.Point(0, 0);
            this.uctrlLop.Name = "uctrlLop";
            this.uctrlLop.Size = new System.Drawing.Size(296, 433);
            this.uctrlLop.TabIndex = 0;
            // 
            // grdLop
            // 
            this.grdLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLop.Location = new System.Drawing.Point(0, 0);
            this.grdLop.MainView = this.grvLop;
            this.grdLop.Name = "grdLop";
            this.grdLop.Size = new System.Drawing.Size(391, 433);
            this.grdLop.TabIndex = 0;
            this.grdLop.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLop});
            // 
            // grvLop
            // 
            this.grvLop.GridControl = this.grdLop;
            this.grvLop.Name = "grvLop";
            // 
            // imageTreeLop
            // 
            this.imageTreeLop.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageTreeLop.ImageStream")));
            // 
            // frmTreeLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 437);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmTreeLop";
            this.Tag = "frmTreeLop";
            this.Text = "TREE LOP";
            this.Load += new System.EventHandler(this.frmTreeLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageTreeLop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl grdLop;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLop;
        private DevExpress.Utils.ImageCollection imageTreeLop;
        private ucTreeLop uctrlLop;
    }
}