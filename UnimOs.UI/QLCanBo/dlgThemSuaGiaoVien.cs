using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TruongViet.UnimOs.Entity;
using Lib;
using TruongViet.UnimOs.Business;
using DevExpress.XtraEditors;

namespace UnimOs.UI
{
    public partial class dlgThemSuaGiaoVien : frmBase
    {
        private int IDDonVi;
        private cBNS_GiaoVien oBGiaoVien;
        public NS_GiaoVienInfo pGiaoVienInfo;
        private EDIT_MODE EditMode;
        private clsStringHelper cls;
        private frmDanhSachGiaoVien frm;
        private string Ma;

        public dlgThemSuaGiaoVien(frmDanhSachGiaoVien mfrm, int mIDDonVi, EDIT_MODE mEditMode)
        {
            InitializeComponent();
            IDDonVi = mIDDonVi;
            pGiaoVienInfo = mfrm.pGiaoVienInfo;
            EditMode = mEditMode;
            frm = mfrm;
            cls = new clsStringHelper();
        }

        private void dlgThemSuaGiaoVien_Load(object sender, EventArgs e)
        {
            LoadCombo();
            //if (EditMode == EDIT_MODE.SUA)
            //    FillData();
            //else
            {
                
                cmbIDDonVi.EditValue = IDDonVi;
                pGiaoVienInfo = new NS_GiaoVienInfo();
            }
        }

        private void LoadCombo()
        {
            cmbIDDonVi.Properties.DataSource = LoadDonVi();
            cmbGioiTinh.Properties.DataSource = LoadGioiTinh();
            cmbDanToc.Properties.DataSource = LoadDanToc();
        }

        private void ClearText()
        {
            txtMaGiaoVien.Text = "";
            chkGiangDay.Checked = false;
            txtHoVaTen.Text = "";
            txtTenVietTat.Text = "";
            dtpNgaySinh.EditValue = null;
            cmbGioiTinh.EditValue = null;
            txtSoCMND.Text = "";
            cmbDanToc.EditValue = null;
            txtSoDienThoai.Text = "";
            txtEmail.Text = "";
        }

        private void FillData()
        {
            cmbIDDonVi.EditValue = IDDonVi;
            chkGiangDay.Checked = pGiaoVienInfo.GiangDay;
            cmbGioiTinh.EditValue = (bool)pGiaoVienInfo.GioiTinh;
            cmbDanToc.EditValue = pGiaoVienInfo.IDDM_DanToc;
            //if (pGiaoVienInfo.NgaySinh != "")
            //     dtpNgaySinh.EditValue = DateTime.Parse(pGiaoVienInfo.NgaySinh).ToString("dd/MM/yyyy");
            txtHoVaTen.Text = pGiaoVienInfo.HoTen;
            txtTenVietTat.Text = pGiaoVienInfo.TenVietTat;
            txtMaGiaoVien.Text = pGiaoVienInfo.MaGiaoVien;
            txtSoCMND.Text = pGiaoVienInfo.SoCMND.ToString() == "0" ? "" : pGiaoVienInfo.SoCMND.ToString();
            txtSoDienThoai.Text = pGiaoVienInfo.DienThoai;
            txtEmail.Text = pGiaoVienInfo.Email;
        }

        private void GetDataFromForm()
        {
            pGiaoVienInfo.IDNS_DonVi = int.Parse(cmbIDDonVi.EditValue.ToString());
            pGiaoVienInfo.GiangDay = chkGiangDay.Checked;
            pGiaoVienInfo.GioiTinh = cmbGioiTinh.EditValue.ToString() == "0" ? false : true;
            pGiaoVienInfo.IDDM_DanToc = int.Parse("0" + cmbDanToc.EditValue);
            if (dtpNgaySinh.EditValue != null)
                pGiaoVienInfo.NgaySinh = DateTime.Parse(dtpNgaySinh.EditValue.ToString());
            else
                pGiaoVienInfo.NgaySinh = DateTime.Parse("1/1/1900");
            pGiaoVienInfo.HoTen = txtHoVaTen.Text;
            pGiaoVienInfo.Ten = cls.GetTen(txtHoVaTen.Text.Trim());
            pGiaoVienInfo.TenVietTat = txtTenVietTat.Text;
            pGiaoVienInfo.MaGiaoVien = txtMaGiaoVien.Text;
            pGiaoVienInfo.SoCMND = txtSoCMND.Text;
            pGiaoVienInfo.NgayCap = DateTime.Parse("1/1/1900");
            pGiaoVienInfo.DienThoai = txtSoDienThoai.Text;
            pGiaoVienInfo.Email = txtEmail.Text;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Ma = pGiaoVienInfo.MaGiaoVien;
            if (!CheckValid()) return;
            oBGiaoVien = new cBNS_GiaoVien();
            GetDataFromForm();
            if (EditMode == EDIT_MODE.SUA)
            {
                oBGiaoVien.Update(pGiaoVienInfo);

                // Ghi Log
                GhiLog("Sửa thông tin giáo viên '" + pGiaoVienInfo.HoTen, "Sửa", this.Tag.ToString());

                frm.pGiaoVienInfo = pGiaoVienInfo;
                frm.EditGiaoVien(EditMode);
                SuaThanhCong();
                this.Close();
            }
            else if (EditMode == EDIT_MODE.THEM)
            {
                pGiaoVienInfo.TrangThaiGiaoVien = 1;
                pGiaoVienInfo.NS_GiaoVienID = oBGiaoVien.Add(pGiaoVienInfo);

                // Ghi Log
                GhiLog("Thêm giáo viên '" + pGiaoVienInfo.HoTen , "Thêm", this.Tag.ToString());

                frm.pGiaoVienInfo = pGiaoVienInfo;
                frm.EditGiaoVien(EditMode);
                ClearText();
                txtMaGiaoVien.Focus();
            }
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
            if (cmbIDDonVi.Text == string.Empty)
            {
                dxErrorProvider.SetError(cmbIDDonVi, "Bạn chưa chọn đơn vị.");
                if (CtrlErr == null) CtrlErr = cmbIDDonVi;
            }
            if (cmbGioiTinh.EditValue == null)
            {
                dxErrorProvider.SetError(cmbGioiTinh, "Bạn chưa chọn giới tính.");
                if (CtrlErr == null) CtrlErr = cmbGioiTinh;
            }
            if (dtpNgaySinh.EditValue == null)
            {
                dxErrorProvider.SetError(dtpNgaySinh, "Bạn chưa chọn ngày sinh.");
                if (CtrlErr == null) CtrlErr = dtpNgaySinh;
            }
            if (txtMaGiaoVien.Text != "")
            {
                if (EditMode == EDIT_MODE.SUA && txtMaGiaoVien.Text.Trim() == Ma)
                {
                    EditMode = EDIT_MODE.SUA;
                }
                else
                {
                    //kiểm tra mã nhập vào có trùng với dữ liệu trước không.
                    if (frm.grvGiaoVien.RowCount != 0)
                    {
                        for (int i = 0; i < frm.grvGiaoVien.RowCount; i++)
                        {
                            if (txtMaGiaoVien.Text.Trim() == frm.grvGiaoVien.GetDataRow(i)[pGiaoVienInfo.strMaGiaoVien].ToString())
                            {

                                if (CtrlErr == null) CtrlErr = txtMaGiaoVien;
                                txtMaGiaoVien.Text = "";
                                txtMaGiaoVien.Focus();
                                ThongBao("Mã giáo viên bạn nhập đã bị trùng");
                                break;
                            }
                        }
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

        private void txtHoVaTen_EditValueChanged(object sender, EventArgs e)
        {
            txtTenVietTat.Text = cls.FormatTenVietTat(txtHoVaTen.Text.Trim());
        }

        private void dtpNgaySinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                dtpNgaySinh.EditValue = null;   
        }
    }
}
