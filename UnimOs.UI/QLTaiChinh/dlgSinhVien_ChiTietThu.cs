using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TruongViet.UnimOs.Business;

namespace UnimOs.UI
{
    public partial class dlgSinhVien_ChiTietThu : frmBase
    {
        private DataRow dr;
        private int ID_TCLoaiThuChi, HocKy, IDDM_NamHoc;
        private cBTC_BienLaiThuTien_ChiTiet oBTC_BienLaiThuTien_ChiTiet;
        private cBTC_DinhMucThuSinhVien oBTC_DinhMucThuSinhVien;

        public dlgSinhVien_ChiTietThu(DataRow mdr, int mID_TCLoaiThuChi, int mHocKy, int mIDDM_NamHoc)
        {
            InitializeComponent();
            oBTC_BienLaiThuTien_ChiTiet = new cBTC_BienLaiThuTien_ChiTiet();
            oBTC_DinhMucThuSinhVien = new cBTC_DinhMucThuSinhVien();

            dr = mdr;
            ID_TCLoaiThuChi = mID_TCLoaiThuChi;
            HocKy = mHocKy;
            IDDM_NamHoc = mIDDM_NamHoc;
        }

        private void dlgSinhVien_ChiTietThu_Load(object sender, EventArgs e)
        {
            txtMaSinhVien.Text = dr["MaSinhVien"].ToString();
            txtHoVaTen.Text = dr["HoVaTen"].ToString();
            txtTenLop.Text = dr["TenLop"].ToString();
            int IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());

            DataTable dtDaNop = oBTC_BienLaiThuTien_ChiTiet.GetBySinhVien(IDSV_SinhVien, ID_TCLoaiThuChi, IDDM_NamHoc, HocKy);
            dtDaNop.DefaultView.RowFilter = "PhieuThu=1";
            grdChiTiet.DataSource = dtDaNop.DefaultView;
            
            grdChuaNop.DataSource = oBTC_DinhMucThuSinhVien.GetChuaNopBy_SinhVien(IDSV_SinhVien, IDDM_NamHoc, HocKy, ID_TCLoaiThuChi);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}