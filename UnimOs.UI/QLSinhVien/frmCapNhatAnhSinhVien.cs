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
    public partial class frmCapNhatAnhSinhVien : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private cBSV_SinhVien oBSV_SinhVien;
        private DataTable dtSinhVien, dtKhoaHoc;

        public frmCapNhatAnhSinhVien()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            oBSV_SinhVien = new cBSV_SinhVien();
            pDM_LopInfo = new DM_LopInfo();
        }

        private void frmCapNhatAnhSinhVien_Load(object sender, EventArgs e)
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
            DM_LopInfo pDM_LopInfo = new DM_LopInfo();
            pDM_LopInfo.IDDM_Khoa = cmbKhoa.EditValue == null ? 0 : int.Parse(cmbKhoa.EditValue.ToString());
            pDM_LopInfo.IDDM_He = cmbHe.EditValue == null ? 0 : int.Parse(cmbHe.EditValue.ToString());
            pDM_LopInfo.IDDM_TrinhDo = cmbTrinhDo.EditValue == null ? 0 : int.Parse(cmbTrinhDo.EditValue.ToString());
            pDM_LopInfo.IDDM_Nganh = cmbNganh.EditValue == null ? 0 : int.Parse(cmbNganh.EditValue.ToString());
            pDM_LopInfo.IDDM_KhoaHoc = cmbKhoaHoc.EditValue == null ? 0 : int.Parse(cmbKhoaHoc.EditValue.ToString());
            cmbLop.Properties.DataSource = oBDM_Lop.GetDanhSachLop(pDM_LopInfo, Program.NamHoc);
        }

        private bool CheckValid()
        {
            if (txtThuMucAnh.Text.Trim() == "")
            {
                ThongBao("Bạn cần phải chọn thư mục ảnh.");
                btnChonThuMuc.Focus();
                return false;
            }
            return true;
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
            cmbNganh.Properties.DataSource = LoadNganhByIDKhoa(int.Parse(cmbKhoa.EditValue.ToString()));
            LoadDanhSachLop();
        }

        private void cmbTrinhDo_EditValueChanged(object sender, EventArgs e)
        {
            string strFilter = "";
            if (cmbTrinhDo.EditValue != null)
                strFilter = "IDDM_TrinhDo = " + cmbTrinhDo.EditValue.ToString();
            if (cmbNganh.EditValue != null)
                strFilter += strFilter == "" ? "IDDM_Nganh = " + cmbNganh.EditValue.ToString() : " And IDDM_Nganh = " + cmbNganh.EditValue.ToString();

            if (strFilter != "")
            {
                DataView dv = new DataView(dtKhoaHoc);
                dv.RowFilter = strFilter;
                cmbKhoaHoc.Properties.DataSource = dv;
            }
            else
                cmbKhoaHoc.Properties.DataSource = dtKhoaHoc;

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
            int IDDM_Khoa, IDDM_He, IDDM_TrinhDo, IDDM_Nganh, IDDM_KhoaHoc, IDDM_Lop;
            IDDM_Khoa = cmbKhoa.EditValue == null ? 0 : int.Parse(cmbKhoa.EditValue.ToString());
            IDDM_He = cmbHe.EditValue == null ? 0 : int.Parse(cmbHe.EditValue.ToString());
            IDDM_TrinhDo = cmbTrinhDo.EditValue == null ? 0 : int.Parse(cmbTrinhDo.EditValue.ToString());
            IDDM_Nganh = cmbNganh.EditValue == null ? 0 : int.Parse(cmbNganh.EditValue.ToString());
            IDDM_KhoaHoc = cmbKhoaHoc.EditValue == null ? 0 : int.Parse(cmbKhoaHoc.EditValue.ToString());
            IDDM_Lop = cmbLop.EditValue == null ? 0 : int.Parse(cmbLop.EditValue.ToString());
            dtSinhVien = oBSV_SinhVien.GetSinhVien(pDM_LopInfo, Program.NamHoc, false);
            grdSinhVien.DataSource = dtSinhVien;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckValid())
                return;
            if (dtSinhVien == null || dtSinhVien.Rows.Count <= 0)
            {
                ThongBao("Không có sinh viên nào để lưu.");
                return;
            }
            if (dtSinhVien.Columns.Contains("FileAnh"))
            {
                oBSV_SinhVien.UpdateAnhSinhVien(dtSinhVien, txtThuMucAnh.Text.Trim());
                ThongBao("Cập nhật ảnh sinh viên thành công.");
            }
            else
            {
                btnGhepAnh_Click(null, null);
                oBSV_SinhVien.UpdateAnhSinhVien(dtSinhVien, txtThuMucAnh.Text.Trim());
                ThongBao("Cập nhật ảnh sinh viên thành công.");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                LookUpEdit cmb = sender as LookUpEdit;
                cmb.EditValue = null;
            }
        }

        private void btnChonThuMuc_Click(object sender, EventArgs e)
        {
            if (folderThuMucAnh.ShowDialog() == DialogResult.OK)
                txtThuMucAnh.Text = folderThuMucAnh.SelectedPath + "\\";
        }

        private void btnGhepAnh_Click(object sender, EventArgs e)
        {
            if (!CheckValid())
                return;
            if (dtSinhVien == null)
            {
                ThongBao("Chưa có sinh viên nào");
                return;
            }
            if (!dtSinhVien.Columns.Contains("FileAnh"))
                dtSinhVien.Columns.Add("FileAnh", typeof(string));
            string FileName;
            foreach (DataRow dr in dtSinhVien.Rows)
            {
                FileName = "";
                if (System.IO.File.Exists(txtThuMucAnh.Text + txtKyTuDauFile.Text + dr["MaSinhVien"].ToString() + ".gif"))
                    FileName = txtKyTuDauFile.Text + dr["MaSinhVien"].ToString() + ".gif";
                else if (System.IO.File.Exists(txtThuMucAnh.Text + txtKyTuDauFile.Text + dr["MaSinhVien"].ToString() + ".jpg"))
                    FileName = txtKyTuDauFile.Text + dr["MaSinhVien"].ToString() + ".jpg";
                else if (System.IO.File.Exists(txtThuMucAnh.Text + txtKyTuDauFile.Text + dr["MaSinhVien"].ToString() + ".bmp"))
                    FileName = txtKyTuDauFile.Text + dr["MaSinhVien"].ToString() + ".bmp";
                else if (System.IO.File.Exists(txtThuMucAnh.Text + txtKyTuDauFile.Text + dr["MaSinhVien"].ToString() + ".png"))
                    FileName = txtKyTuDauFile.Text + dr["MaSinhVien"].ToString() + ".png";
                if (FileName != "")
                    dr["FileAnh"] = FileName;
            }
        }
    }
}