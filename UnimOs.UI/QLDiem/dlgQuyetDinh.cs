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
    public partial class dlgQuyetDinh : frmBase
    {
        private cBSV_SinhVien oBSinhVien;
        private SV_SinhVienInfo pSV_SinhVienInfo;
        private cBKQHT_DanhSachNgungHoc oBKQHT_DanhSachNgungHoc;
        private KQHT_DanhSachNgungHocInfo pKQHT_DanhSachNgungHocInfo;
        private cBKQHT_DanhSachHocTiep oBKQHT_DanhSachHocTiep;
        private KQHT_DanhSachHocTiepInfo pKQHT_DanhSachHocTiepInfo; 
        private DataRow dr;
        string SinhVienIDs = "",TrangThai;
        string KQHT_DanhSachNgungHocIDs;

        public dlgQuyetDinh(string mSinhVienIDs, string mTrangThai, string mKQHT_DanhSachNgungHocIDs, DataRow mdr)
        {
            InitializeComponent();

            oBSinhVien = new cBSV_SinhVien();
            oBKQHT_DanhSachNgungHoc = new cBKQHT_DanhSachNgungHoc();
            pKQHT_DanhSachNgungHocInfo = new KQHT_DanhSachNgungHocInfo();
            pSV_SinhVienInfo = new SV_SinhVienInfo();
            pKQHT_DanhSachNgungHocInfo = new KQHT_DanhSachNgungHocInfo();
            oBKQHT_DanhSachHocTiep = new cBKQHT_DanhSachHocTiep();
            pKQHT_DanhSachHocTiepInfo = new KQHT_DanhSachHocTiepInfo();

            SinhVienIDs = mSinhVienIDs;
            dtNgayQD.EditValue = DateTime.Now;
            dr = mdr;
            TrangThai = mTrangThai;
            KQHT_DanhSachNgungHocIDs = mKQHT_DanhSachNgungHocIDs;

            //load combobox
            cmbTrangThai.Properties.DataSource = oBSinhVien.CreateTableTrangThai();
            cmbLop.Properties.DataSource = LoadLopTheoKhoa(0);

            // Sửa quyết định
            if (TrangThai == "1")
            { 
                txtSoQuyetDinh.Text = dr["SoQuyetDinh"].ToString();
                txtNoiDung.Text = dr["GhiChu"].ToString();
            }
            else if (TrangThai == "2")
            {
                // xet hoc tiep
                txtSoQuyetDinh.Text = dr["SoQuyetDinh"].ToString();
                txtNoiDung.Text = dr["GhiChu"].ToString();
                cmbLop.Enabled = true;
                cmbLop.EditValue = dr["IDDM_Lop"];
            }
        }

        private void dlgQuyetDinh_Load(object sender, EventArgs e)
        {
            if (SinhVienIDs.IndexOf(",") == SinhVienIDs.LastIndexOf(","))
            {
                if (dr != null)
                {
                    txtMaSinhVien.Text = dr["MaSinhVien"].ToString();
                    txtHoVaTen.Text = dr["HoVaTen"].ToString();
                    cmbTrangThai.EditValue = dr["TrangThai"];
                }
            }
            else
            {
                txtMaSinhVien.Text = "...";
                txtHoVaTen.Text = "...";
            }
        }
        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtSoQuyetDinh.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtSoQuyetDinh, "Số quyết định không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtSoQuyetDinh;
            }
            if (txtNoiDung.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtNoiDung, "Nội dung quyết định không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtNoiDung;
            }
            if (cmbTrangThai.EditValue == null)
            {
                dxErrorProvider.SetError(cmbTrangThai, "Trạng thái không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbTrangThai;
            }
            if (cmbLop.EditValue == null && TrangThai == "2")
            {
                dxErrorProvider.SetError(cmbLop, "Lớp mới không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbLop;
            }

             if ((CtrlErr != null))
                return false;
             else
                return true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckValid()) return;

            string[] arrSinhVien, arrKQHT_NgungHocID;
            arrSinhVien = SinhVienIDs.Split(',');
            arrKQHT_NgungHocID = KQHT_DanhSachNgungHocIDs.Split(',');

            for (int i = 0; i < arrSinhVien.Length; i++)
            {
                if (arrSinhVien[i] != "" && arrSinhVien[i] != "0")
                {
                    if (cmbTrangThai.EditValue.ToString() == "8")
                    {
                        // Thêm quyết định
                        pKQHT_DanhSachNgungHocInfo.HocKy = Program.HocKy;
                        pKQHT_DanhSachNgungHocInfo.IDDM_NamHoc = Program.IDNamHoc;
                        pKQHT_DanhSachNgungHocInfo.IDDM_LopCu = 1;
                        pKQHT_DanhSachNgungHocInfo.NoiDung = txtNoiDung.Text;
                        pKQHT_DanhSachNgungHocInfo.SoQuyetDinh = txtSoQuyetDinh.Text;
                        pKQHT_DanhSachNgungHocInfo.NgayQuyetDinh = DateTime.Parse(dtNgayQD.EditValue.ToString());
                        pKQHT_DanhSachNgungHocInfo.IDSV_SinhVien = int.Parse(arrSinhVien[i]);
                        pKQHT_DanhSachNgungHocInfo.TrangThai = int.Parse(cmbTrangThai.EditValue.ToString());
                        oBKQHT_DanhSachNgungHoc.Add(pKQHT_DanhSachNgungHocInfo);
                        // Chuyển sinh viên vào lớp mới
                        oBSinhVien.ChuyenLop(pKQHT_DanhSachNgungHocInfo.IDSV_SinhVien, 1, 
                            int.Parse(cmbLop.EditValue.ToString()), (int)TRANGTHAISINHVIEN.CHUYENLOP);
                    }
                    else if (TrangThai == "0")
                    {
                        // Thêm quyết định
                        pKQHT_DanhSachNgungHocInfo.HocKy = Program.HocKy;
                        pKQHT_DanhSachNgungHocInfo.IDDM_NamHoc = Program.IDNamHoc;
                        pKQHT_DanhSachNgungHocInfo.IDDM_LopCu = 1;
                        pKQHT_DanhSachNgungHocInfo.NoiDung = txtNoiDung.Text;
                        pKQHT_DanhSachNgungHocInfo.SoQuyetDinh = txtSoQuyetDinh.Text;
                        pKQHT_DanhSachNgungHocInfo.NgayQuyetDinh = DateTime.Parse(dtNgayQD.EditValue.ToString());
                        pKQHT_DanhSachNgungHocInfo.IDSV_SinhVien = int.Parse(arrSinhVien[i]);
                        pKQHT_DanhSachNgungHocInfo.TrangThai = int.Parse(cmbTrangThai.EditValue.ToString());
                        oBKQHT_DanhSachNgungHoc.Add(pKQHT_DanhSachNgungHocInfo);
                        // update trang thai
                        oBSinhVien.UpdateTrangThaiSinhVien(int.Parse(cmbTrangThai.EditValue.ToString()), SinhVienIDs + ",0");
                    }
                    else if (TrangThai == "1")
                    {
                        // Sửa quyết định
                        pKQHT_DanhSachNgungHocInfo.HocKy = Program.HocKy;
                        pKQHT_DanhSachNgungHocInfo.IDDM_NamHoc = Program.IDNamHoc;
                        pKQHT_DanhSachNgungHocInfo.IDDM_LopCu = 1;
                        pKQHT_DanhSachNgungHocInfo.NoiDung = txtNoiDung.Text;
                        pKQHT_DanhSachNgungHocInfo.SoQuyetDinh = txtSoQuyetDinh.Text;
                        pKQHT_DanhSachNgungHocInfo.NgayQuyetDinh = DateTime.Parse(dtNgayQD.EditValue.ToString());
                        pKQHT_DanhSachNgungHocInfo.IDSV_SinhVien = int.Parse(arrSinhVien[i]);
                        pKQHT_DanhSachNgungHocInfo.KQHT_DanhSachNgungHocID = int.Parse(arrKQHT_NgungHocID[i]);
                        pKQHT_DanhSachNgungHocInfo.TrangThai = int.Parse(cmbTrangThai.EditValue.ToString());
                        oBKQHT_DanhSachNgungHoc.Update(pKQHT_DanhSachNgungHocInfo);
                        // update trang thai
                        oBSinhVien.UpdateTrangThaiSinhVien(int.Parse(cmbTrangThai.EditValue.ToString()), SinhVienIDs + ",0");
                    }
                    else
                    {
                        // Xét học tiếp
                        pKQHT_DanhSachHocTiepInfo.Hocky = Program.HocKy;
                        pKQHT_DanhSachHocTiepInfo.IDDM_Namhoc = Program.IDNamHoc;
                        pKQHT_DanhSachHocTiepInfo.IDDM_Lop = int.Parse(cmbLop.EditValue.ToString());
                        pKQHT_DanhSachHocTiepInfo.IDKQHT_DanhSachNgungHoc = 0;
                        pKQHT_DanhSachHocTiepInfo.IDSV_SinhVien = int.Parse(arrSinhVien[i]);
                        pKQHT_DanhSachHocTiepInfo.Lydo = txtNoiDung.Text;
                        pKQHT_DanhSachHocTiepInfo.SoQuyetDinh = txtSoQuyetDinh.Text;
                        pKQHT_DanhSachHocTiepInfo.NgayQuyetDinh = DateTime.Parse(dtNgayQD.EditValue.ToString());
                        try
                        {
                            pKQHT_DanhSachHocTiepInfo.KQHT_DanhSachHocTiepID = int.Parse(dr["KQHT_DanhSachHocTiepID"].ToString());
                            oBKQHT_DanhSachHocTiep.Update(pKQHT_DanhSachHocTiepInfo);
                        }
                        catch
                        {
                            oBKQHT_DanhSachHocTiep.Add(pKQHT_DanhSachHocTiepInfo);
                        }
                    }
                }
            }
            ThongBao("Cập nhật thành công");
            this.Close();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbTrangThai_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbTrangThai.EditValue != null && cmbTrangThai.EditValue.ToString() == "8")
                cmbLop.Enabled = true;
            else
                cmbLop.Enabled = false;
        }
    }
}