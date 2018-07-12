using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;
using C1.Win.C1FlexGrid;

namespace UnimOs.UI
{
    public partial class dlgChonGiaoVien : frmBase
    {
        private frmKeHoachChiTiet frmKeHoach;
        private XL_KeHoachChiTietInfo pXL_KeHoachChiTietInfo;
        private cBXL_GiaoVien_MonHoc oBXL_GiaoVien_MonHoc;
        private string TenLop, TenMon, IDNS_GiaoVien;
        private CellRange rg;
        private bool SelectButton = false;

        public dlgChonGiaoVien(frmKeHoachChiTiet _frm, XL_KeHoachChiTietInfo _XL_KeHoachChiTietInfo, string _TenLop, string _TenMon, string _IDNS_GiaoVien)
        {
            InitializeComponent();
            oBXL_GiaoVien_MonHoc = new cBXL_GiaoVien_MonHoc();
            frmKeHoach = _frm;
            pXL_KeHoachChiTietInfo = _XL_KeHoachChiTietInfo;
            TenLop = _TenLop;
            TenMon = _TenMon;
            IDNS_GiaoVien = _IDNS_GiaoVien;
        }

        private void dlgChonGiaoVien_Load(object sender, EventArgs e)
        {
            txtTenLop.Text = TenLop;
            txtTenMon.Text = TenMon;
            rg = frmKeHoach.fg.Selection;
            txtTuTuan.Text = frmKeHoach.fg[3, rg.LeftCol].ToString();
            txtDenTuan.Text = frmKeHoach.fg[3, rg.RightCol].ToString();
            grdGiaoVien.DataSource = oBXL_GiaoVien_MonHoc.GetByIDDM_MonHoc(pXL_KeHoachChiTietInfo.IDDM_MonHoc, IDNS_GiaoVien);
        }

        private void btnKhac_Click(object sender, EventArgs e)
        {
            SelectButton = !SelectButton;
            if (!SelectButton)
            {
                btnKhac.Text = "Giảng viên môn";
                grdGiaoVien.DataSource = oBXL_GiaoVien_MonHoc.GetByIDDM_MonHoc(0, "");
            }
            else
            {
                btnKhac.Text = "Tất cả GV";
                grdGiaoVien.DataSource = oBXL_GiaoVien_MonHoc.GetByIDDM_MonHoc(pXL_KeHoachChiTietInfo.IDDM_MonHoc, "");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (grvGiaoVien.DataRowCount > 0 && grvGiaoVien.FocusedRowHandle >= 0)
            {
                CellRange rg1;
                frmKeHoachChiTiet.Cell_KeHoach ud;
                for (int c = rg.LeftCol; c <= rg.RightCol; c++)
                {
                    rg1 = frmKeHoach.fg.GetCellRange(rg.TopRow, c, rg.TopRow, c);
                    if (rg1.UserData != null)
                    {
                        ud = (frmKeHoachChiTiet.Cell_KeHoach)rg1.UserData;
                        if (ud.SoTiet > 0)
                        {
                            ud.IDNS_GiaoVien = int.Parse(grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle)["IDNS_GiaoVien"].ToString());
                            ud.Changed = true;
                            rg1.Style = frmKeHoach.fg.Styles["MyCellStyleGiaoVien"];
                            rg1.UserData = ud;
                        }
                    }
                }
                this.Close();
            }
            else
                ThongBao("Bạn chưa chọn giảng viên nào.");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            CellRange rg1;
            frmKeHoachChiTiet.Cell_KeHoach ud;
            for (int c = rg.LeftCol; c <= rg.RightCol; c++)
            {
                rg1 = frmKeHoach.fg.GetCellRange(rg.TopRow, c, rg.TopRow, c);
                if (rg1.UserData != null)
                {
                    ud = (frmKeHoachChiTiet.Cell_KeHoach)rg1.UserData;
                    if (ud.SoTiet > 0)
                    {
                        ud.IDNS_GiaoVien = 0;
                        ud.Changed = true;
                        rg1.Style = frmKeHoach.fg.Styles["MyCellStyle"];
                        rg1.UserData = ud;
                    }
                }
            }
            this.Close();
        }
    }
}