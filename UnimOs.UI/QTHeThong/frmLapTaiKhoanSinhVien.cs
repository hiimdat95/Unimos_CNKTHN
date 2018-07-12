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
    public partial class frmLapTaiKhoanSinhVien : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private cBSV_SinhVien oBSV_SinhVien;
        private DataTable dtSinhVien, dtKhoaHoc;

        public frmLapTaiKhoanSinhVien()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            oBSV_SinhVien = new cBSV_SinhVien();
            pDM_LopInfo = new DM_LopInfo();
        }

        private void frmLapTaiKhoanSinhVien_Load(object sender, EventArgs e)
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

        private bool CheckValid()
        {
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
            cmbNganh.Properties.DataSource = LoadNganhByIDKhoa(int.Parse("0" + cmbKhoa.EditValue));
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
            //int IDDM_Khoa, IDDM_He, IDDM_TrinhDo, IDDM_Nganh, IDDM_KhoaHoc, IDDM_Lop;
            pDM_LopInfo.IDDM_Khoa = cmbKhoa.EditValue == null ? 0 : int.Parse(cmbKhoa.EditValue.ToString());
            pDM_LopInfo.IDDM_He = cmbHe.EditValue == null ? 0 : int.Parse(cmbHe.EditValue.ToString());
            pDM_LopInfo.IDDM_TrinhDo = cmbTrinhDo.EditValue == null ? 0 : int.Parse(cmbTrinhDo.EditValue.ToString());
            pDM_LopInfo.IDDM_Nganh = cmbNganh.EditValue == null ? 0 : int.Parse(cmbNganh.EditValue.ToString());
            pDM_LopInfo.IDDM_KhoaHoc = cmbKhoaHoc.EditValue == null ? 0 : int.Parse(cmbKhoaHoc.EditValue.ToString());
            pDM_LopInfo.DM_LopID = cmbLop.EditValue == null ? 0 : int.Parse(cmbLop.EditValue.ToString());
            dtSinhVien = oBSV_SinhVien.GetSinhVienLapTaiKhoan(pDM_LopInfo, Program.NamHoc, txtHoVaTen.Text.Trim(), txtMaSinhVien.Text.Trim());
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
                oBSV_SinhVien.UpdateTaiKhoan(dtChange);
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

        private void btnLapTaiKhoan_Click(object sender, EventArgs e)
        {
            if (!CheckValid()) return;
            if (dtSinhVien != null && dtSinhVien.Rows.Count > 0)
            {
                DataRow dr;
                for (int i = 0; i < grvSinhVien.DataRowCount; i++)
                {
                    dr = grvSinhVien.GetDataRow(i);
                    if ("" + dr["MaSinhVien"] != "")
                    {
                        dr["TenDangNhap"] = dr["MaSinhVien"].ToString() + txtMaSinhVien.Text.Trim();
                        dr["MatKhau"] = Lib.clsAuthentication.Encrypt(dr["MaSinhVien"].ToString() + txtMatKhau.Text.Trim());
                    }
                }
            }
            else
                ThongBao("Chưa có sinh viên nào để lập mã.");
        }

        private void cmb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                LookUpEdit cmb = sender as LookUpEdit;
                cmb.EditValue = null;
            }
        }

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {
            if (grvSinhVien.DataRowCount > 0)
            {
                Lib.clsExportToWord cls = new Lib.clsExportToWord();
                Microsoft.Office.Interop.Word.ApplicationClass WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                Microsoft.Office.Interop.Word.Document aDoc = null;
                cls.InitWord(WordApp, ref aDoc, 12);
                cls.AddText(aDoc, "Danh sách sinh viên được cấp quyền", 1, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter, 16);
                if (cmbHe.ItemIndex > -1)
                    cls.AddText(aDoc, "\tHệ: " + cmbHe.Text, 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft, 12);
                if (cmbTrinhDo.ItemIndex > -1)
                    cls.AddText(aDoc, "\tTrình độ: " + cmbTrinhDo.Text, 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft, 12);
                if (cmbKhoa.ItemIndex > -1)
                    cls.AddText(aDoc, "\tKhoa: " + cmbKhoa.Text, 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft, 12);
                if (cmbNganh.ItemIndex > -1)
                    cls.AddText(aDoc, "\tNgành: " + cmbNganh.Text, 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft, 12);
                if (cmbKhoaHoc.ItemIndex > -1)
                    cls.AddText(aDoc, "\tKhóa: " + cmbKhoaHoc.Text, 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft, 12);
                if (cmbLop.ItemIndex > -1)
                    cls.AddText(aDoc, "\tLớp: " + cmbLop.Text, 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft, 12);
                
                cls.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft, 12);
                cls.AddTable(aDoc, dtSinhVien, new string[] { "Mã sinh viên", "Họ và tên", "Ngày sinh", "Lớp", "Tên đăng nhập" },
                    new string[] { "MaSinhVien", "HoVaTen", "NgaySinh", "TenLop", "TenDangNhap" });
            }
            else
                ThongBao("Không có danh sách sinh viên.");
        }
    }
}