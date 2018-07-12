using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lib;
using DevExpress.XtraEditors;
using TruongViet.TVR.Win;

namespace UnimOs.Khoa
{
    public partial class frmDangKy : frmBase
    {

        public frmDangKy()
        {
            InitializeComponent();
            this.Tag = -1;
        }
        
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (cXacThucWinForms.KiemTraDaDangKyBanQuyen())
            {
                Program.DaDangKy = true;
                ThongBao("Đăng ký thành công.");
                this.Tag = 1;
                this.Close();
            }
            else
                ThongBaoLoi("File đăng ký không đúng.");
        }

        private void frmDangKy_Load(object sender, EventArgs e)
        {
            txtMaDangKy.Text = Program.MaDangKy;            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Tag = 0;
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreatInternetBrowser();
        }

        private void CreatInternetBrowser()
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            // Set các tham số
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "iexplore";
            proc.StartInfo.Arguments = "http://www.truongviet.vn";
            // Chạy tiến trình
            proc.Start();
        }

        private void btnDungThu_Click(object sender, EventArgs e)
        {
            //Program.SoNgayDungThu = clsAuthentication.tvgiamtime(Program.MaSanPham, Program.MaDangKy);
            //lblCount.Text = Program.SoNgayDungThu.ToString();
            //this.Close();
        }
    }
}