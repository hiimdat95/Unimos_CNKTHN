using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TruongViet.UnimOs.wsBusiness;
using TruongViet.UnimOs.Entity;

namespace UnimOs.Khoa
{
    public partial class dlgPhanCongGiaoVien_SoTiet : frmBase
    {
        private cBwsXL_PhanCongGiaoVien oBXL_PhanCongGiaoVien;
        private XL_PhanCongGiaoVienInfo pXL_PhanCongGiaoVienInfo;
        private int IDNS_GiaoVien;
        private DataTable dtPhanCong, dtGiaoVien;
        private DataRow drPhanCong;

        public dlgPhanCongGiaoVien_SoTiet(ref DataRow _drPhanCong, int _IDNS_GiaoVien, ref DataTable _dtGiaoVien)
        {
            InitializeComponent();
            drPhanCong = _drPhanCong;
            IDNS_GiaoVien = _IDNS_GiaoVien;
            dtGiaoVien = _dtGiaoVien;
            oBXL_PhanCongGiaoVien = new cBwsXL_PhanCongGiaoVien();
            pXL_PhanCongGiaoVienInfo = new XL_PhanCongGiaoVienInfo();
            this.DialogResult = DialogResult.Cancel;
        }

        private void dlgPhanCongGiaoVien_SoTiet_Load(object sender, EventArgs e)
        {
            txtMonHoc.Text = drPhanCong["TenMonHoc"].ToString();
            txtLop.Text = drPhanCong["TenLop"].ToString();
            txtSoTiet.Text = drPhanCong["SoTiet"].ToString();

            dtPhanCong = oBXL_PhanCongGiaoVien.GetGiaoVien(int.Parse(drPhanCong["XL_MonHocTrongKyID"].ToString()), IDNS_GiaoVien);
            grdGiaoVien.DataSource = dtPhanCong;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // Cập nhật số tiết
            pXL_PhanCongGiaoVienInfo.IDXL_MonHocTrongKy = int.Parse(drPhanCong["XL_MonHocTrongKyID"].ToString());
            DataRow[] arrDr;
            drPhanCong["IDNS_GiaoViens"] = "";
            drPhanCong["HoTens"] = "";
            drPhanCong["SoTiets"] = "";
            foreach (DataRow dr in dtPhanCong.Rows)
            {
                pXL_PhanCongGiaoVienInfo.IDNS_GiaoVien = int.Parse(dr["IDNS_GiaoVien"].ToString());
                pXL_PhanCongGiaoVienInfo.SoTiet = int.Parse(dr["SoTiet"].ToString());
                if (int.Parse(dr["XL_PhanCongGiaoVienID"].ToString()) > 0)
                {
                    pXL_PhanCongGiaoVienInfo.XL_PhanCongGiaoVienID = int.Parse(dr["XL_PhanCongGiaoVienID"].ToString());
                    oBXL_PhanCongGiaoVien.Update(pXL_PhanCongGiaoVienInfo);
                }
                else
                    oBXL_PhanCongGiaoVien.Add(pXL_PhanCongGiaoVienInfo);
                // Cập nhật lại số tiết kỳ của GV
                arrDr = dtGiaoVien.Select("IDNS_GiaoVien = " + pXL_PhanCongGiaoVienInfo.IDNS_GiaoVien.ToString());
                if (arrDr.Length > 0)
                {
                    arrDr[0]["TongSoTiet"] = int.Parse("0" + arrDr[0]["TongSoTiet"]) - int.Parse(dr["SoTietCu"].ToString()) 
                        + int.Parse(dr["SoTiet"].ToString());
                }
                drPhanCong["IDNS_GiaoViens"] = ("" + drPhanCong["IDNS_GiaoViens"] == "" ? dr["IDNS_GiaoVien"].ToString() :
                                drPhanCong["IDNS_GiaoViens"] + "," + dr["IDNS_GiaoVien"]);
                drPhanCong["HoTens"] = ("" + drPhanCong["HoTens"] == "" ? dr["HoTen"].ToString() : drPhanCong["HoTens"] + ", " + dr["HoTen"]);
                drPhanCong["SoTiets"] = ("" + drPhanCong["SoTiets"] == "" ? dr["SoTiet"].ToString() : drPhanCong["SoTiets"] + ", " + dr["SoTiet"]);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}