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
using Lib;

namespace UnimOs.UI
{
    public partial class dlgToChucThi_ThiSinhTuDo : frmBase
    {
        private DataTable dtSinhVien;
        private EDIT_MODE edit;
        private int IDDM_Lop;
        private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private SV_SinhVienInfo pSV_SinhVienInfo;
        private cBSV_SinhVien oBSV_SinhVien;
        private cBSV_SinhVien_Lop oBSV_SinhVien_Lop;
        private SV_SinhVien_LopInfo pSV_SinhVien_LopInfo;
        private DataRow drSinhVien;
        private clsStringHelper cls;

        public dlgToChucThi_ThiSinhTuDo(DataTable mdtSinhVien, DataRow mdrSinhVien, int mIDDM_Lop, EDIT_MODE mEditMode)
        {
            InitializeComponent();
            this.Tag = "";
            IDDM_Lop = mIDDM_Lop;
            dtSinhVien = mdtSinhVien;
            edit = mEditMode;
            drSinhVien = mdrSinhVien;
            pDM_LopInfo = new DM_LopInfo();
            oBDM_Lop = new cBDM_Lop();
            pSV_SinhVienInfo = new SV_SinhVienInfo();
            oBSV_SinhVien = new cBSV_SinhVien();
            pSV_SinhVien_LopInfo = new SV_SinhVien_LopInfo();
            oBSV_SinhVien_Lop = new cBSV_SinhVien_Lop();
            cls = new clsStringHelper();
        }

        private void LoadComBo()
        {
            cmbGioiTinh.Properties.DataSource = LoadGioiTinh();
            cmbDanToc.Properties.DataSource = LoadDanToc();
            LoadComboLop();
        }

        private void LoadComboLop()
        {
            cmbDM_Lop.Properties.DataSource = oBDM_Lop.GetDanhSachLop_ThiSinhTuDo(Program.NamHoc);
        }

        private void dlgSinhVien_Load(object sender, EventArgs e)
        {
            LoadComBo();
            if (edit == EDIT_MODE.SUA)
                FillData();
            else
            {
                cmbDM_Lop.EditValue = IDDM_Lop;
                if (dtSinhVien.Rows.Count > 0)
                    txtMaSV.Text = oBSV_SinhVien.GetNextMaSinhVien(IDDM_Lop, "" + dtSinhVien.Rows[0]["MaSinhVien"]);
                else
                    txtMaSV.Text = oBSV_SinhVien.GetNextMaSinhVien(IDDM_Lop, "");
                txtHoVaTen.Focus();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckValid()) return;
            GetDataFrom();
            if (edit == EDIT_MODE.SUA)
            {
                oBSV_SinhVien.Update(pSV_SinhVienInfo);

                oBSV_SinhVien.ToDataRow(pSV_SinhVienInfo, ref drSinhVien);
                // Ghi Log
                GhiLog("Sửa thông tin sinh viên '" + pSV_SinhVienInfo.MaSinhVien, "Sửa", this.Tag.ToString());
                SuaThanhCong();
                this.Close();
            }
            else
            {
                pSV_SinhVienInfo.SV_SinhVienID = oBSV_SinhVien.Add(pSV_SinhVienInfo);
                pSV_SinhVien_LopInfo.IDSV_SinhVien = pSV_SinhVienInfo.SV_SinhVienID;
                pSV_SinhVien_LopInfo.IDDM_Lop = IDDM_Lop;
                pSV_SinhVien_LopInfo.TrangThaiSinhVien = (int)TRANGTHAISINHVIEN.THISINHTUDO;
                oBSV_SinhVien_Lop.Add(pSV_SinhVien_LopInfo);
                DataRow dr = dtSinhVien.NewRow();
                ToDataRow(ref dr);
                dtSinhVien.Rows.Add(dr);
                // Ghi Log
                GhiLog("Thêm sinh viên có mã là '" + pSV_SinhVienInfo.MaSinhVien, "Thêm", this.Tag.ToString());
                ClearText();
                txtMaSV.Text = oBSV_SinhVien.GetNextMaSinhVien(IDDM_Lop, pSV_SinhVienInfo.MaSinhVien);
                txtHoVaTen.Focus();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void ClearText()
        {
            txtDienThoai.Text = "";
            txtEmail.Text = "";
            txtHoVaTen.Text = "";
            txtMaSV.Text = "";
            txtSoCMT.Text = "";
            cmbDanToc.EditValue = null;
            dtpNgaySinh.EditValue = "";
        }

        private void FillData()
        {
            cmbDM_Lop.EditValue = IDDM_Lop;
            cmbGioiTinh.EditValue = drSinhVien["GioiTinh"];
            cmbDanToc.EditValue = drSinhVien["IDDM_DanToc"];
            if ("" + drSinhVien["NgaySinh"] != "")
                dtpNgaySinh.EditValue = DateTime.Parse(drSinhVien["NgaySinh"].ToString()).ToString("dd/MM/yyyy");
            txtHoVaTen.Text = drSinhVien["HoVaTen"].ToString();
            txtMaSV.Text = drSinhVien["MaSinhVien"].ToString();
            txtSoCMT.Text = "" + drSinhVien["SoCMND"];
            txtDienThoai.Text = "" + drSinhVien["DienThoaiDiDong"];
            txtEmail.Text = "" + drSinhVien["Email"];
        }

        private void ToDataRow(ref DataRow dr)
        {
            //dr["GioiTinh"] = int.Parse(cmbGioiTinh.EditValue.ToString());
            //dr["IDDM_DanToc"] = cmbDanToc.EditValue == null ? 0 : int.Parse(cmbDanToc.EditValue.ToString());
            dr["Chon"] = false;
            dr["NgaySinh"] = DateTime.Parse(dtpNgaySinh.EditValue.ToString());
            dr["HoVaTen"] = txtHoVaTen.Text;
            string HoDem = "";
            dr["Ten"] = GetTen(txtHoVaTen.Text, ref HoDem);
            dr["HoVa"] = HoDem;
            dr["MaSinhVien"] = txtMaSV.Text;
            //dr["SoCMND"] = txtSoCMT.Text;
            //dr["DienThoaiDiDong"] = txtDienThoai.Text;
            //dr["Email"] = txtEmail.Text;
        }

        private void GetDataFrom()
        {
            pSV_SinhVienInfo.GioiTinh = cmbGioiTinh.EditValue.ToString() == "0" ? false : true;
            pSV_SinhVienInfo.IDDM_DanToc = int.Parse("0" + cmbDanToc.EditValue);
            if (dtpNgaySinh.EditValue != null)
                pSV_SinhVienInfo.NgaySinh = DateTime.Parse(dtpNgaySinh.EditValue.ToString());
            else
                pSV_SinhVienInfo.NgaySinh = DateTime.Parse("1/1/1900");
            pSV_SinhVienInfo.NgayVaoDang = DateTime.Parse("1/1/1900");
            pSV_SinhVienInfo.NgayVaoDoan = DateTime.Parse("1/1/1900");
            pSV_SinhVienInfo.NgayCapCMND = DateTime.Parse("1/1/1900");
            pSV_SinhVienInfo.HoVaTen = txtHoVaTen.Text;
            pSV_SinhVienInfo.MaSinhVien = txtMaSV.Text;
            pSV_SinhVienInfo.SoCMND = txtSoCMT.Text;
            pSV_SinhVienInfo.DienThoaiDiDong = txtDienThoai.Text;
            pSV_SinhVienInfo.Email = txtEmail.Text;
            pSV_SinhVienInfo.Ten = cls.GetTen(txtHoVaTen.Text);
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtHoVaTen.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtHoVaTen, "Họ tên không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtHoVaTen;
            }
            if (txtMaSV.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtMaSV, "Mã sinh viên không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMaSV;
            }
            if (cmbGioiTinh.EditValue == null)
            {
                dxErrorProvider.SetError(cmbGioiTinh, "Bạn chưa chọn giới tính.");
                if (CtrlErr == null) CtrlErr = cmbGioiTinh;
            }
            if (dtpNgaySinh.EditValue == null)
            {
                dxErrorProvider.SetError(dtpNgaySinh, "Ngày sinh không được để trống.");
                if (CtrlErr == null) CtrlErr = dtpNgaySinh;
            }
            //kiểm tra mã nhập vào có trùng với dữ liệu trước không.
            if (dtSinhVien.Rows.Count != 0)
            {
                for (int i = 0; i < dtSinhVien.Rows.Count; i++)
                {
                    if (txtMaSV.Text.Trim() == dtSinhVien.Rows[i]["MaSinhVien"].ToString() && (edit == EDIT_MODE.THEM ||
                        (dtSinhVien.Rows[i]["SV_SinhVienID"].ToString() != drSinhVien["SV_SinhVienID"].ToString() && edit == EDIT_MODE.SUA)))
                    {
                        if (CtrlErr == null) CtrlErr = txtMaSV;
                        txtMaSV.Text = "";
                        ThongBao("Mã sinh viên bạn nhập đã bị trùng");
                        break;
                    }
                }
            }
            if (CtrlErr != null)
            {
                CtrlErr.Focus();
                return false;
            }
            else
                return true;
        }

        private void cmbDanToc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbDanToc.EditValue = null;
        }

        private void btnThemLop_Click(object sender, EventArgs e)
        {
            frmLopHoc frm = new frmLopHoc();
            frm.ShowDialog();
            LoadComboLop();
            if (frm.pDM_LopInfo != null)
                cmbDM_Lop.EditValue = frm.pDM_LopInfo.DM_LopID;
        }
    }
}