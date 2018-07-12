namespace UnimOs.UI
{
    partial class frmLogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogIn));
            this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.Password = new DevExpress.XtraEditors.TextEdit();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancle = new DevExpress.XtraEditors.SimpleButton();
            this.ImageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.UserName = new DevExpress.XtraEditors.TextEdit();
            this.checkNhoMatKhau = new DevExpress.XtraEditors.CheckEdit();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.PictureEdit = new DevExpress.XtraEditors.PictureEdit();
            this.btnConfigServer = new DevExpress.XtraEditors.SimpleButton();
            this.DxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Password.Properties)).BeginInit();
            this.TableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkNhoMatKhau.Properties)).BeginInit();
            this.TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel
            // 
            this.defaultLookAndFeel.LookAndFeel.SkinName = "Office 2010 Blue";
            // 
            // Password
            // 
            resources.ApplyResources(this.Password, "Password");
            this.TableLayoutPanel1.SetColumnSpan(this.Password, 2);
            this.Password.Name = "Password";
            this.Password.Properties.PasswordChar = '*';
            // 
            // TableLayoutPanel2
            // 
            resources.ApplyResources(this.TableLayoutPanel2, "TableLayoutPanel2");
            this.TableLayoutPanel1.SetColumnSpan(this.TableLayoutPanel2, 3);
            this.TableLayoutPanel2.Controls.Add(this.btnCancle, 1, 0);
            this.TableLayoutPanel2.Controls.Add(this.btnLogin, 0, 0);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            // 
            // btnCancle
            // 
            this.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancle.ImageIndex = 7;
            this.btnCancle.ImageList = this.ImageCollection;
            resources.ApplyResources(this.btnCancle, "btnCancle");
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // ImageCollection
            // 
            this.ImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ImageCollection.ImageStream")));
            // 
            // btnLogin
            // 
            this.btnLogin.ImageIndex = 9;
            this.btnLogin.ImageList = this.ImageCollection;
            resources.ApplyResources(this.btnLogin, "btnLogin");
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // UserName
            // 
            resources.ApplyResources(this.UserName, "UserName");
            this.TableLayoutPanel1.SetColumnSpan(this.UserName, 2);
            this.UserName.Name = "UserName";
            // 
            // checkNhoMatKhau
            // 
            resources.ApplyResources(this.checkNhoMatKhau, "checkNhoMatKhau");
            this.TableLayoutPanel1.SetColumnSpan(this.checkNhoMatKhau, 2);
            this.checkNhoMatKhau.Name = "checkNhoMatKhau";
            this.checkNhoMatKhau.Properties.Caption = resources.GetString("checkNhoMatKhau.Properties.Caption");
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.TableLayoutPanel1, "TableLayoutPanel1");
            this.TableLayoutPanel1.Controls.Add(this.Label2, 1, 2);
            this.TableLayoutPanel1.Controls.Add(this.Label1, 1, 1);
            this.TableLayoutPanel1.Controls.Add(this.GroupBox1, 0, 4);
            this.TableLayoutPanel1.Controls.Add(this.PictureEdit, 0, 1);
            this.TableLayoutPanel1.Controls.Add(this.btnConfigServer, 4, 1);
            this.TableLayoutPanel1.Controls.Add(this.UserName, 2, 1);
            this.TableLayoutPanel1.Controls.Add(this.Password, 2, 2);
            this.TableLayoutPanel1.Controls.Add(this.TableLayoutPanel2, 2, 5);
            this.TableLayoutPanel1.Controls.Add(this.checkNhoMatKhau, 2, 3);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            // 
            // Label2
            // 
            resources.ApplyResources(this.Label2, "Label2");
            this.Label2.Name = "Label2";
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.Name = "Label1";
            // 
            // GroupBox1
            // 
            this.TableLayoutPanel1.SetColumnSpan(this.GroupBox1, 6);
            resources.ApplyResources(this.GroupBox1, "GroupBox1");
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.TabStop = false;
            // 
            // PictureEdit
            // 
            resources.ApplyResources(this.PictureEdit, "PictureEdit");
            this.PictureEdit.Name = "PictureEdit";
            this.PictureEdit.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.PictureEdit.Properties.Appearance.Options.UseBackColor = true;
            this.PictureEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.PictureEdit.Properties.ReadOnly = true;
            this.PictureEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.TableLayoutPanel1.SetRowSpan(this.PictureEdit, 2);
            // 
            // btnConfigServer
            // 
            resources.ApplyResources(this.btnConfigServer, "btnConfigServer");
            this.btnConfigServer.ImageIndex = 8;
            this.btnConfigServer.ImageList = this.ImageCollection;
            this.btnConfigServer.Name = "btnConfigServer";
            this.btnConfigServer.Click += new System.EventHandler(this.btnConfigServer_Click);
            // 
            // DxErrorProvider
            // 
            this.DxErrorProvider.ContainerControl = this;
            // 
            // frmLogIn
            // 
            this.AcceptButton = this.btnLogin;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancle;
            this.Controls.Add(this.TableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmLogIn";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmLogIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mdtColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Password.Properties)).EndInit();
            this.TableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkNhoMatKhau.Properties)).EndInit();
            this.TableLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel;
        internal DevExpress.XtraEditors.TextEdit Password;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal DevExpress.XtraEditors.PictureEdit PictureEdit;
        internal DevExpress.XtraEditors.SimpleButton btnConfigServer;
        internal DevExpress.Utils.ImageCollection ImageCollection;
        internal DevExpress.XtraEditors.TextEdit UserName;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        internal DevExpress.XtraEditors.SimpleButton btnCancle;
        internal DevExpress.XtraEditors.SimpleButton btnLogin;
        internal DevExpress.XtraEditors.CheckEdit checkNhoMatKhau;
        internal DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider DxErrorProvider;
    }
}