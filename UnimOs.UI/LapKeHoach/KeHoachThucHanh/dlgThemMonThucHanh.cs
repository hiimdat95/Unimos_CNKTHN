using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Business;

namespace UnimOs.UI
{
    public partial class dlgThemMonThucHanh : frmBase
    {
        private EDIT_MODE edit;
        private int IDXL_KeHoachThucHanh, IDDM_Lop;
        private cBXL_KeHoachThucHanh oBXL_KeHoachThucHanh;
        private XL_KeHoachThucHanhInfo pXL_KeHoachThucHanhInfo;
        private DataRow drMonKy, drMonThucHanh;
        private bool Loaded = false;

        public dlgThemMonThucHanh(ref DataRow _drMonThucHanh, int _IDDM_Lop, DataRow _drMonKy, EDIT_MODE _edit)
        {
            InitializeComponent();
            oBXL_KeHoachThucHanh = new cBXL_KeHoachThucHanh();
            pXL_KeHoachThucHanhInfo = new XL_KeHoachThucHanhInfo();
            edit = _edit;
            IDDM_Lop = _IDDM_Lop;
            drMonKy = _drMonKy;
            drMonThucHanh = _drMonThucHanh;
            this.DialogResult = DialogResult.Cancel;
        }

        private void dlgThemMonThucHanh_Load(object sender, EventArgs e)
        {
            cmbPhongHoc.Properties.DataSource = LoadPhongHoc();
            cmbGiaoVien.Properties.DataSource = LoadGiaoVien();
            LoadKyHieuThucHanh();

            SetText(drMonKy);
            Loaded = true;
        }

        private void LoadKyHieuThucHanh()
        {
            cBXL_KeHoachThucHanhKyHieu oB = new cBXL_KeHoachThucHanhKyHieu();
            XL_KeHoachThucHanhKyHieuInfo pInfo = new XL_KeHoachThucHanhKyHieuInfo();
            DataTable dt = oB.Get(pInfo);
            cmbHienThi.Properties.DataSource = dt;
            if (edit == EDIT_MODE.THEM && !Loaded)
            {
                DataRow[] arrDr = dt.Select("IDDM_MonHoc = " + drMonKy["IDDM_MonHoc"]);
                if (arrDr.Length > 0)
                    cmbHienThi.EditValue = arrDr[0]["XL_KeHoachThucHanhKyHieuID"];
            }
        }

        private void SetText(DataRow dr)
        {
            txtMaMon.Text = dr["MaMonHoc"].ToString();
            txtTenMon.Text = dr["TenMonHoc"].ToString();
            txtDVHT.Text = dr["SoHocTrinh"].ToString();
            txtLyThuyet.Text = dr["LyThuyet"].ToString();
            txtThucHanh.Text = dr["ThucHanh"].ToString();
            if (edit == EDIT_MODE.SUA)
            {
                IDXL_KeHoachThucHanh = int.Parse(drMonThucHanh["XL_KeHoachThucHanhID"].ToString());
                DataTable dt = oBXL_KeHoachThucHanh.GetMonThucHanh(IDXL_KeHoachThucHanh, IDDM_Lop, Program.IDNamHoc, Program.HocKy);
                if (dt.Rows.Count > 0)
                {
                    cmbPhongHoc.EditValue = dt.Rows[0]["IDDM_PhongHoc"];
                    cmbGiaoVien.EditValue = dt.Rows[0]["IDNS_GiaoVien"];
                    txtSoTo.EditValue = dt.Rows[0]["SoTo"];
                    txtSoBuoi.Text = dt.Rows[0]["SoBuoi"].ToString();
                    txtSoTiet.Text = dt.Rows[0]["SoTiet"].ToString();
                    cmbHienThi.EditValue = dt.Rows[0]["IDXL_KeHoachThucHanhKyHieu"].ToString();
                }
            }
            else
            { 
                DataTable dt = new cBXL_PhanCongGiaoVien().GetGiaoVienByMonHocTrongKy(int.Parse(dr["XL_MonHocTrongKyID"].ToString()));
                if (dt.Rows.Count > 0)
                    cmbGiaoVien.EditValue = dt.Rows[0]["IDNS_GiaoVien"];
            }
        }

        private void GetInfo()
        {
            if (edit == EDIT_MODE.THEM)
            {
                pXL_KeHoachThucHanhInfo.IDXL_MonHocTrongKy = int.Parse(drMonKy["XL_MonHocTrongKyID"].ToString());
                pXL_KeHoachThucHanhInfo.IDDM_MonHoc = int.Parse(drMonKy["IDDM_MonHoc"].ToString());
            }
            else
            {
                pXL_KeHoachThucHanhInfo.XL_KeHoachThucHanhID = IDXL_KeHoachThucHanh;
            }
            pXL_KeHoachThucHanhInfo.IDDM_PhongHoc = int.Parse("0" + cmbPhongHoc.EditValue);
            pXL_KeHoachThucHanhInfo.IDNS_GiaoVien = int.Parse("0" + cmbGiaoVien.EditValue);
            pXL_KeHoachThucHanhInfo.IDDM_Lop = IDDM_Lop;
            pXL_KeHoachThucHanhInfo.SoTo = int.Parse(txtSoTo.EditValue.ToString());
            pXL_KeHoachThucHanhInfo.SoBuoi = int.Parse(txtSoBuoi.Text);
            pXL_KeHoachThucHanhInfo.SoTiet = int.Parse(txtSoTiet.Text);
            pXL_KeHoachThucHanhInfo.IDXL_KeHoachThucHanhKyHieu = int.Parse(cmbHienThi.EditValue.ToString());
        }

        private bool CheckValid()
        {
            return true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckValid()) return;
            try
            {
                GetInfo();
                if (edit == EDIT_MODE.THEM)
                {
                    pXL_KeHoachThucHanhInfo.XL_KeHoachThucHanhID = oBXL_KeHoachThucHanh.Add(pXL_KeHoachThucHanhInfo);
                    oBXL_KeHoachThucHanh.ToDataRow(pXL_KeHoachThucHanhInfo, ref drMonThucHanh, EDIT_MODE.THEM);
                    drMonThucHanh["TenMonHoc"] = txtTenMon.Text;
                    drMonThucHanh["TenPhongHoc"] = cmbPhongHoc.Text;
                    drMonThucHanh["TenGiaoVien"] = cmbGiaoVien.Text;
                    drMonThucHanh["KyHieu"] = cmbHienThi.Text;
                    drMonThucHanh["MauChu"] = cmbHienThi.GetColumnValue("MauChu").ToString();
                    drMonThucHanh["MauNen"] = cmbHienThi.GetColumnValue("MauNen").ToString();
                }
                else
                {
                    oBXL_KeHoachThucHanh.Update(pXL_KeHoachThucHanhInfo);
                    oBXL_KeHoachThucHanh.ToDataRow(pXL_KeHoachThucHanhInfo, ref drMonThucHanh, EDIT_MODE.SUA);
                    drMonThucHanh["TenPhongHoc"] = cmbPhongHoc.Text;
                    drMonThucHanh["TenGiaoVien"] = cmbGiaoVien.Text;
                    drMonThucHanh["KyHieu"] = cmbHienThi.Text;
                    drMonThucHanh["MauChu"] = cmbHienThi.GetColumnValue("MauChu").ToString();
                    drMonThucHanh["MauNen"] = cmbHienThi.GetColumnValue("MauNen").ToString();
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ThongBaoLoi(ex.Message);
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChonKyHieu_Click(object sender, EventArgs e)
        {
            frmKyHieuThucHanh frm = new frmKyHieuThucHanh();
            frm.ShowDialog();
            LoadKyHieuThucHanh();
            cmbHienThi.EditValue = frm.IDKyHieuSelected;
        }

        private void txtSoBuoi_Leave(object sender, EventArgs e)
        {
            if (txtSoBuoi.Text != "")
            {
                txtSoTiet.Text = ((int)(Program.pgrThamSo.SO_TIET_THUCHANH_TRONGTUAN /
                    (Program.pgrThamSo.THUCHANH_DEN_THU - Program.pgrThamSo.THUCHANH_TU_THU + 1) * int.Parse(txtSoBuoi.Text))).ToString();
            }
        }
    }
}