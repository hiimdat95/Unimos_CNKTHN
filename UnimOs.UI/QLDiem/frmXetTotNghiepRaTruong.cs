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
using DevExpress.Utils;

namespace UnimOs.UI
{
    public partial class frmXetTotNghiepRaTruong : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private cBSV_SinhVien oBSV_SinhVien;
        private KQHT_XepLoaiTotNghiepInfo pKQHT_XepLoaiTotNghiepInfo;
        private cBKQHT_XepLoaiTotNghiep oBKQHT_XepLoaiTotNghiep;
        private DataTable dtSinhVien, dtTrinhDo, dtXepLoai, dtKhoaHoc;
        //int IDDM_Khoa, IDDM_He, IDDM_TrinhDo, IDDM_Nganh, IDDM_KhoaHoc, IDDM_Lop;

        public frmXetTotNghiepRaTruong()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            pDM_LopInfo = new DM_LopInfo();
            oBSV_SinhVien = new cBSV_SinhVien();
            pKQHT_XepLoaiTotNghiepInfo = new KQHT_XepLoaiTotNghiepInfo();
            oBKQHT_XepLoaiTotNghiep = new cBKQHT_XepLoaiTotNghiep();
        }

        private void frmXetTotNghiepRaTruong_Load(object sender, EventArgs e)
        {
            LoadCombo();
            dtXepLoai = oBKQHT_XepLoaiTotNghiep.Get(pKQHT_XepLoaiTotNghiepInfo);
            repositoryXepLoai.DataSource = dtXepLoai;

        }
        private void LoadCombo()
        {
            cmbHe.Properties.DataSource = LoadHe();
            dtTrinhDo = LoadTrinhDo();
            cmbTrinhDo.Properties.DataSource = dtTrinhDo;
            cmbKhoa.Properties.DataSource = LoadKhoa();
            dtKhoaHoc = LoadKhoaHoc();
            cmbKhoaHoc.Properties.DataSource = dtKhoaHoc;
        }

        private void GetpLopInfo()
        {
            pDM_LopInfo.IDDM_Khoa = cmbKhoa.EditValue == null ? 0 : int.Parse(cmbKhoa.EditValue.ToString());
            pDM_LopInfo.IDDM_He = cmbHe.EditValue == null ? 0 : int.Parse(cmbHe.EditValue.ToString());
            pDM_LopInfo.IDDM_TrinhDo = cmbTrinhDo.EditValue == null ? 0 : int.Parse(cmbTrinhDo.EditValue.ToString());
            pDM_LopInfo.IDDM_Nganh = cmbNganh.EditValue == null ? 0 : int.Parse(cmbNganh.EditValue.ToString());
            pDM_LopInfo.IDDM_KhoaHoc = cmbKhoaHoc.EditValue == null ? 0 : int.Parse(cmbKhoaHoc.EditValue.ToString());
        }

        private void LoadDanhSachLop()
        {
            GetpLopInfo();
            cmbLop.Properties.DataSource = oBDM_Lop.GetDanhSachLop(pDM_LopInfo, Program.NamHoc);
        }

        public string GetNumber(string strChuoi)
        {
            string strNumber = "";
            while (char.IsNumber(char.Parse(strChuoi.Substring(strChuoi.Length - 1, 1))) && strChuoi.Length > 0)
            {
                strNumber = strChuoi.Substring(strChuoi.Length - 1, 1) + strNumber;
                strChuoi = strChuoi.Substring(0, strChuoi.Length - 1);
            }
            return strNumber;
        }

        private void cmbHe_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbHe.EditValue != null)
            {
                DataTable dtTrinhDo = LoadTrinhDoByIDHe(int.Parse(cmbHe.EditValue.ToString()));
                cmbTrinhDo.Properties.DataSource = dtTrinhDo;
                if (dtTrinhDo.Rows.Count > 0)
                    cmbTrinhDo.ItemIndex = 0;
            }
            LoadDanhSachLop();
        }

        private void cmbTrinhDo_EditValueChanged(object sender, EventArgs e)
        {
            //if (cmbTrinhDo.EditValue != null)
            //{
            //    string strFilter = "";
            //    if (cmbTrinhDo.EditValue != null)
            //        strFilter = "IDDM_TrinhDo = " + cmbTrinhDo.EditValue.ToString();
            //    if (cmbNganh.EditValue != null)
            //        strFilter += strFilter == "" ? "IDDM_Nganh = " + cmbNganh.EditValue.ToString() : " And IDDM_Nganh = " + cmbNganh.EditValue.ToString();

            //    if (strFilter != "")
            //    {
            //        DataView dv = new DataView(dtKhoaHoc);
            //        dv.RowFilter = strFilter;
            //        cmbKhoaHoc.Properties.DataSource = dv;
            //    }
            //    else
            //        cmbKhoaHoc.Properties.DataSource = dtKhoaHoc;
            //}
            LoadDanhSachLop();
        }

        private void cmbKhoa_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.EditValue != null)
            {
                cmbNganh.Properties.DataSource = LoadNganhByIDKhoa(int.Parse("0" + cmbKhoa.EditValue));
                LoadDanhSachLop();
            }
        }

        private void cmbNganh_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbNganh.EditValue != null)
            {
                pDM_LopInfo.IDDM_Nganh = int.Parse(cmbNganh.EditValue.ToString());
                LoadDanhSachLop();
            }
        }

        private void cmbKhoaHoc_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbKhoaHoc.EditValue != null)
            {
                try
                {
                    pDM_LopInfo.IDDM_TrinhDo = int.Parse("0" + cmbKhoaHoc.GetColumnValue("IDDM_TrinhDo"));
                    LoadDanhSachLop();
                }
                catch
                {
                    pDM_LopInfo.IDDM_TrinhDo = 0;
                    pDM_LopInfo.IDDM_KhoaHoc = 0;
                }
            }
        }

        private void cmbLop_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbLop.EditValue != null)
            {
                pDM_LopInfo.DM_LopID = int.Parse(cmbLop.EditValue.ToString());
            }
        }

        private void cmbKhoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbKhoa.EditValue = null;
                pDM_LopInfo.IDDM_Khoa = 0;
            }
        }

        private void cmbNganh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbNganh.EditValue = null;
                pDM_LopInfo.IDDM_Nganh = 0;
            }
        }

        private void cmbKhoaHoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbKhoaHoc.EditValue = null;
                pDM_LopInfo.IDDM_KhoaHoc = 0;
            }
        }

        private void cmbLop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbLop.EditValue = null;
                pDM_LopInfo.DM_LopID = 0;
            }
        }

        private void grvSinhVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnLocSV_Click(object sender, EventArgs e)
        {
            GetpLopInfo();
            pDM_LopInfo.DM_LopID = cmbLop.EditValue == null ? 0 : int.Parse(cmbLop.EditValue.ToString());
            dtSinhVien = oBSV_SinhVien.GetDaTotNghiep(pDM_LopInfo);
            grdDiem.DataSource = dtSinhVien;
            
        }

        private void btnDanhSoBang_Click(object sender, EventArgs e)
        {
            if (txtSoBang.Text.Trim() != "")
            {
                string ChuoiTuTang = GetNumber(txtSoBang.Text.Trim());
                string ChuoiMa = txtSoBang.Text.Trim().Replace(ChuoiTuTang, "");
                if (dtSinhVien != null && dtSinhVien.Rows.Count > 0 && ChuoiTuTang != "")
                {
                    foreach (DataRow dr in dtSinhVien.Rows)
                    {
                        dr["SoBang"] = ChuoiMa + ChuoiTuTang;
                        ChuoiTuTang = (int.Parse(ChuoiTuTang) + 1).ToString();
                    }
                }
            }
            else
                ThongBao("Chưa nhập số bằng!");
        }

        private void btnXetRaTruong_Click(object sender, EventArgs e)
        {
            if (dtSinhVien != null && dtSinhVien.Rows.Count > 0)
            {
                foreach (DataRow dr in dtSinhVien.Rows)
                {
                    oBSV_SinhVien.XetRaTruong(int.Parse(dr["SV_SinhVienID"].ToString()), dr["SoBang"].ToString(), 2);
                }
                ThongBao("Xét ra trường thành công!");
            }
            else
                ThongBao("Không có dữ liệu!");
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {

        }
    }
}