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
    public partial class frmBaoCaoDinhKy : frmBase
    {
        public frmBaoCaoDinhKy()
        {
            InitializeComponent();
        }

        private void navBarBaoCao_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            switch (e.Link.Item.Name)
            {
                case "itemBaoCaoSoLuongLanhDaoDoBoNhiem":
                    {
                        frmBaoCaoLanhDaoDoBoNhiem frm = new frmBaoCaoLanhDaoDoBoNhiem();
                        frm.WindowState = FormWindowState.Maximized;
                        frm.ShowDialog();
                        break;
                    }
                case "itemBaoCaoChatLuongCBCVTheoLinhVuc":
                    {
                        frmBaoCaoChatLuongCBVCTheoLinhVuc frm = new frmBaoCaoChatLuongCBVCTheoLinhVuc();
                        frm.WindowState = FormWindowState.Maximized;
                        frm.ShowDialog();
                        break;
                    }
                case "itemBaoCaoChatLuongDoiNguGiaoVien":
                    {
                        frmBaoCaoChatLuongDoiNguGV frm = new frmBaoCaoChatLuongDoiNguGV();
                        frm.WindowState = FormWindowState.Maximized;
                        frm.ShowDialog();
                        break;
                    }
                case "itemBaoCaoTangGiamBienChe":
                    {
                        frmBaoCaoTangGiamBienChe frm = new frmBaoCaoTangGiamBienChe();
                        frm.WindowState = FormWindowState.Maximized;
                        frm.ShowDialog();
                        break;
                    }
                case "itemBaoCaoKeHoachBienCheSuNghiep":
                    {
                        frmBaoCaoKeHoachBienCheSuNghiep frm = new frmBaoCaoKeHoachBienCheSuNghiep();
                        frm.WindowState = FormWindowState.Maximized;
                        frm.ShowDialog();
                        break;
                    }
                case "itemBaoCaoSoLuongCongChucVaHocSinh":
                    {
                        frmBaoCaoSoLuongCongChucVaHocSinh frm = new frmBaoCaoSoLuongCongChucVaHocSinh();
                        frm.WindowState = FormWindowState.Maximized;
                        frm.ShowDialog();
                        break;
                    }
            }
        }
    }
}