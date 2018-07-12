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

namespace UnimOs.UI
{
    public partial class frmLapMaSinhVien : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private cBSV_SinhVien oBSV_SinhVien;
        private DataTable dtSinhVien, dtKhoaHoc;

        public frmLapMaSinhVien()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            oBSV_SinhVien = new cBSV_SinhVien();
            pDM_LopInfo = new DM_LopInfo();
        }

        private void frmLapMaSinhVien_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }

        private void LoadCombo()
        {
            cmbHe.Properties.DataSource = LoadHe();
            cmbTrinhDo.Properties.DataSource = LoadTrinhDo();
            cmbKhoa.Properties.DataSource = LoadKhoa();
            dtKhoaHoc = LoadKhoaHoc();
            cmbKhoaHoc.Properties.DataSource = dtKhoaHoc;
        }

        private void LoadDanhSachLop()
        {
            pDM_LopInfo.IDDM_Khoa = cmbKhoa.EditValue == null ? 0 : int.Parse(cmbKhoa.EditValue.ToString());
            pDM_LopInfo.IDDM_He = cmbHe.EditValue == null ? 0 : int.Parse(cmbHe.EditValue.ToString());
            pDM_LopInfo.IDDM_TrinhDo = cmbTrinhDo.EditValue == null ? 0 : int.Parse(cmbTrinhDo.EditValue.ToString());
            pDM_LopInfo.IDDM_Nganh = cmbNganh.EditValue == null ? 0 : int.Parse(cmbNganh.EditValue.ToString());
            pDM_LopInfo.IDDM_KhoaHoc = cmbKhoaHoc.EditValue == null ? 0 : int.Parse(cmbKhoaHoc.EditValue.ToString());
            cmbLop.Properties.DataSource = oBDM_Lop.GetDanhSachLop(pDM_LopInfo, Program.NamHoc);
        }

        private bool CheckValid(ref DataRow[] arrDr)
        {
            if (dtSinhVien == null)
                return false;

            arrDr = dtSinhVien.Select("Chon = 1");
            if (arrDr.Length == 0)
                return false;

            return true;
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            if (txtDoDaiTuTang.Text.Trim() != "" && txtBatDauTu.Text.Trim() != "")
            {
                int DoDaiTuTang = int.Parse(txtDoDaiTuTang.Text.Trim());
                string MaSinhVien, PhanDauMa = txtPhanDauMa.Text.Trim(), PhanCuoiMa = txtPhanCuoiMa.Text.Trim();

                MaSinhVien = txtBatDauTu.Text.Trim();
                while (MaSinhVien.Length < DoDaiTuTang)
                {
                    MaSinhVien = "0" + MaSinhVien;
                }
                MaSinhVien = PhanDauMa + MaSinhVien + PhanCuoiMa;
                txtDangMa.Text = MaSinhVien;
            }
            else
                txtDangMa.Text = "";
        }

        private void cmbHe_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dtTrinhDo = LoadTrinhDoByIDHe(int.Parse(cmbHe.EditValue.ToString()));
            cmbTrinhDo.Properties.DataSource = dtTrinhDo;
            if (dtTrinhDo.Rows.Count > 0)
                cmbTrinhDo.ItemIndex = 0;
            LoadDanhSachLop();
        }

        private void cmbKhoa_EditValueChanged(object sender, EventArgs e)
        {
            cmbNganh.Properties.DataSource = LoadNganhByIDKhoa(int.Parse("0" + cmbKhoa.EditValue));
            LoadDanhSachLop();
        }

        private void cmbTrinhDo_EditValueChanged(object sender, EventArgs e)
        {
            //string strFilter = "";
            //if (cmbTrinhDo.EditValue != null)
            //    strFilter = "IDDM_TrinhDo = " + cmbTrinhDo.EditValue.ToString();
            //if (cmbNganh.EditValue != null)
            //    strFilter += strFilter == "" ? "IDDM_Nganh = " + cmbNganh.EditValue.ToString() : " And IDDM_Nganh = " + cmbNganh.EditValue.ToString();

            //if (strFilter != "")
            //{
            //    DataView dv = new DataView(dtKhoaHoc);
            //    dv.RowFilter = strFilter;
            //    cmbKhoaHoc.Properties.DataSource = dv;
            //}
            //else
            //    cmbKhoaHoc.Properties.DataSource = dtKhoaHoc;

            LoadDanhSachLop();
        }

        private void cmbKhoaHoc_EditValueChanged(object sender, EventArgs e)
        {
            LoadDanhSachLop();
        }

        private void grvSinhVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnLocSV_Click(object sender, EventArgs e)
        {
            //int IDDM_Khoa, IDDM_He, IDDM_TrinhDo, IDDM_Nganh, IDDM_KhoaHoc, IDDM_Lop;
            pDM_LopInfo.IDDM_Khoa = cmbKhoa.EditValue == null ? 0 : int.Parse(cmbKhoa.EditValue.ToString());
            pDM_LopInfo.IDDM_He = cmbHe.EditValue == null ? 0 : int.Parse(cmbHe.EditValue.ToString());
            pDM_LopInfo.IDDM_TrinhDo = cmbTrinhDo.EditValue == null ? 0 : int.Parse(cmbTrinhDo.EditValue.ToString());
            pDM_LopInfo.IDDM_Nganh = cmbNganh.EditValue == null ? 0 : int.Parse(cmbNganh.EditValue.ToString());
            pDM_LopInfo.IDDM_KhoaHoc = cmbKhoaHoc.EditValue == null ? 0 : int.Parse(cmbKhoaHoc.EditValue.ToString());
            pDM_LopInfo.DM_LopID = cmbLop.EditValue == null ? 0 : int.Parse(cmbLop.EditValue.ToString());
            dtSinhVien = oBSV_SinhVien.GetSinhVien(pDM_LopInfo, Program.NamHoc, chkChuaCoMa.Checked);
            grdSinhVien.DataSource = dtSinhVien;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dtSinhVien == null)
            {
                ThongBao("Không có sinh viên nào để lưu.");
                return;
            }
            DataTable dtChange = dtSinhVien.GetChanges();
            if (dtChange != null)
            {
                oBSV_SinhVien.UpdateMaSinhVien(ref dtChange);
                dtSinhVien.AcceptChanges();
                ThongBao("Cập nhật mã sinh viên thành công.");
            }
            else
                ThongBao("Không có sự thay đổi về mã sinh viên.");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (dtSinhVien != null && dtSinhVien.GetChanges() != null)
                if (ThongBaoChon("Dữ liệu đã thay đổi, bạn có thực sự muốn thoát không?") != DialogResult.Yes)
                    return;
            this.Close();
        }

        private void btnLapMa_Click(object sender, EventArgs e)
        {
            DataRow[] arrDr = null;
            if (!CheckValid(ref arrDr))
            {
                ThongBao("Bạn chưa chọn sinh viên nào để lập mã !");
                return;
            }

            long TuTang;
            int DoDaiTuTang = int.Parse(txtDoDaiTuTang.Text.Trim());
            string MaSinhVien, PhanDauMa = txtPhanDauMa.Text.Trim(), PhanCuoiMa = txtPhanCuoiMa.Text.Trim();
            string MaLonNhat = oBSV_SinhVien.GetMaLonNhat(txtDangMa.Text.Length, PhanDauMa, PhanCuoiMa);

            if (MaLonNhat == "")
            {
                TuTang = long.Parse(txtBatDauTu.Text) - 1;
            }
            else
            {
                if (PhanCuoiMa.Length > 0)
                    MaLonNhat = MaLonNhat.Substring(MaLonNhat.Length - PhanCuoiMa.Length - 1);
                TuTang = long.Parse(MaLonNhat.Substring(PhanDauMa.Length));
            }

            if (TuTang < 0)
                TuTang = 0;

            foreach (DataRow dr in arrDr)
            {
                TuTang++;
                MaSinhVien = TuTang.ToString();

                MaSinhVien = MaSinhVien.PadLeft(DoDaiTuTang, '0');

                MaSinhVien = PhanDauMa + MaSinhVien + PhanCuoiMa;
                dr["MaSinhVien"] = MaSinhVien;
            }
        }

        private void cmb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                LookUpEdit cmb = sender as LookUpEdit;
                cmb.EditValue = null;
            }
        }

        private void grvSinhVien_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvSinhVien, "Chon", e);
        }
    }
}