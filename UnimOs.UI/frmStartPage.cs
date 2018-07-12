using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UnimOs.UI
{
    public partial class frmStartPage : frmBase
    {
        public frmStartPage()
        {
            this.SuspendLayout();
            InitializeComponent();
            this.ResumeLayout();
        }

        private void frmStartPage_Load(object sender, EventArgs e)
        {
            lblTenTruong.Text = Program.TenTruong;
            lblDiaChi.Text = Program.DiaChi;
        }

        private void linkWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            // Set các tham số
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "iexplore";
            proc.StartInfo.Arguments = "http://truongviet.vn";
            // Chạy tiến trình
            proc.Start();
        }
    }
}