using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace UnimOs.UI
{
    public partial class frmQuaTrinhKyLuat : frmBase
    {
        private cBNS_DonVi oBDonVi;
        private NS_DonViInfo pDonViInfo;
        private cBNS_GiaoVien oBGiaoVien;
        public NS_GiaoVienInfo pGiaoVienInfo;
        public cBNS_QuaTrinhKyLuat oBQuaTrinhKyLuat;
        public NS_QuaTrinhKyLuatInfo pNS_QuaTrinhKyLuatInfo;
        private DataTable dtTree, dtGiaoVien, dtQuaTrinhKyLuat;
        DataRow drGiaoVien, drQuaTrinhKyLuat;
        private bool Loaded = false;
        private int idxGV;
        private EDIT_MODE edit;
        public int IDDM_CapKyLuat;

        public frmQuaTrinhKyLuat()
        {
            InitializeComponent();
            oBGiaoVien = new cBNS_GiaoVien();
            pGiaoVienInfo = new NS_GiaoVienInfo();
            pDonViInfo = new NS_DonViInfo();
            oBQuaTrinhKyLuat = new cBNS_QuaTrinhKyLuat();
            pNS_QuaTrinhKyLuatInfo = new NS_QuaTrinhKyLuatInfo();
            SetButton(false);
            btnThem.Enabled = true;
            SetControl(true);
            btnLuu.Enabled = false;
            layXoaKyLuat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            SetControlXoaKyLuat(true);
        }

        private void LoadQuaTrinhKyLuat()
        {
            dtQuaTrinhKyLuat = oBQuaTrinhKyLuat.GetBy_IDNS_GiaoVien(int.Parse(grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle)["NS_GiaoVienID"].ToString()));
            grdQuaTrinhKyLuat.DataSource = dtQuaTrinhKyLuat;
        }

        private void LoadCombo()
        {
            cmbCapKhenThuong.Properties.DataSource = LoadCapKhenThuong();
            reposCapKhenThuong.DataSource = LoadCapKhenThuong();
        }

        private void LoadGiaoVien(int IDDonVi)
        {
            pGiaoVienInfo.IDNS_DonVi = IDDonVi;
            dtGiaoVien = oBGiaoVien.GetByIDNS_DonVi(IDDonVi);
            grdGiaoVien.DataSource = dtGiaoVien;
            grvGiaoVien_FocusedRowChanged(null, null);
        }

        private void LoadTreeView()
        {
            oBDonVi = new cBNS_DonVi();
            dtTree = oBDonVi.Get_Tree();
            trvDonVi.DataSource = dtTree;
            trvDonVi.ExpandAll();

        }

        private void trvDonVi_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (Loaded == true)
            {
                if (trvDonVi.Nodes.Count > 0)
                {
                    LoadGiaoVien(int.Parse(trvDonVi.FocusedNode["NS_DonViID"].ToString()));
                    pDonViInfo.NS_DonViID = int.Parse(trvDonVi.FocusedNode["NS_DonViID"].ToString());
                    pDonViInfo.MaDonVi = trvDonVi.FocusedNode["MaDonVi"].ToString();
                    pDonViInfo.TenDonVi = trvDonVi.FocusedNode["TenDonVi"].ToString();
                    pDonViInfo.ParentID = int.Parse(trvDonVi.FocusedNode["ParentID"].ToString());
                    pDonViInfo.Level = int.Parse(trvDonVi.FocusedNode["Level"].ToString());
                    pDonViInfo.IDDM_Khoa = int.Parse(trvDonVi.FocusedNode["IDDM_Khoa"].ToString());
                    pDonViInfo.IDDM_BoMon = int.Parse(trvDonVi.FocusedNode["IDDM_BoMon"].ToString());
                }
            }
        }

        private void SetControl(bool mbool)
        {
            txtSoQuyetDinh.Properties.ReadOnly = mbool;
            dtpNgayQuyetDinh.Properties.ReadOnly = mbool;
            dtpNgayCoHieuLuc.Properties.ReadOnly = mbool;
            dtpNgayHetHieuLuc.Properties.ReadOnly = mbool;
            cmbCapKhenThuong.Properties.ReadOnly = mbool;
            txtNoiDung.Properties.ReadOnly = mbool;
            txtTangSoThangTangLuong.Properties.ReadOnly = mbool;
            txtSoQuyetDinh.Focus();
        }

        private void SetButton(bool status)
        {
            btnThem.Enabled = status;
            btnSua.Enabled = status;
            btnXoa.Enabled = status;
            btnXoaKyLuat.Enabled = status;
        }

        private void SetGrdTrv(bool status)
        {
            trvDonVi.Enabled = status;
            grdGiaoVien.Enabled = status;
            grdQuaTrinhKyLuat.Enabled = status;
        }

        private void ClearText()
        {
            txtSoQuyetDinh.Text = "";
            dtpNgayQuyetDinh.EditValue = null;
            dtpNgayCoHieuLuc.EditValue = null;
            dtpNgayHetHieuLuc.EditValue = null;
            cmbCapKhenThuong.EditValue = null;
            txtNoiDung.Text = "";
            txtTangSoThangTangLuong.Text = "";
        }

        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txtSoQuyetDinh.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtSoQuyetDinh, "Số quyết định không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtSoQuyetDinh;
            }
            if (dtpNgayQuyetDinh.EditValue == null)
            {
                dxErrorProvider.SetError(dtpNgayQuyetDinh, "Ngày quyết định không thể rỗng.");
                if (CtrlErr == null) CtrlErr = dtpNgayQuyetDinh;
            }
            if (dtpNgayCoHieuLuc.EditValue == null)
            {
                dxErrorProvider.SetError(dtpNgayCoHieuLuc, "Ngày có hiệu lực không thể rỗng không thể rỗng.");
                if (CtrlErr == null) CtrlErr = dtpNgayCoHieuLuc;
            }
            if (dtpNgayHetHieuLuc.EditValue == null)
            {
                dxErrorProvider.SetError(dtpNgayHetHieuLuc, "Ngày hết hiệu lực không thể rỗng không thể rỗng.");
                if (CtrlErr == null) CtrlErr = dtpNgayHetHieuLuc;
            }
            if (cmbCapKhenThuong.EditValue == null)
            {
                dxErrorProvider.SetError(cmbCapKhenThuong, "Cấp kỷ luật không thể rỗng không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbCapKhenThuong;
            }
            if (txtNoiDung.Text == "")
            {
                dxErrorProvider.SetError(txtNoiDung, "Nội dung kỷ luật không thể rỗng không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtNoiDung;
            }

            //Kiểm tra cập nhật thành công
            if (CtrlErr != null)
            {
                CtrlErr.Focus();
                return false;
            }
            else
                return true;
        }

        private void SetText()
        {
            txtSoQuyetDinh.Text = "" + pNS_QuaTrinhKyLuatInfo.SoQuyetDinh;
            if ("" + drQuaTrinhKyLuat[pNS_QuaTrinhKyLuatInfo.strNgayQuyetDinh] == "")
                dtpNgayQuyetDinh.EditValue = null;
            else
            {
                dtpNgayQuyetDinh.EditValue = drQuaTrinhKyLuat[pNS_QuaTrinhKyLuatInfo.strNgayQuyetDinh];
            }
            if ("" + drQuaTrinhKyLuat[pNS_QuaTrinhKyLuatInfo.strNgayCoHieuLuc] == "")
                dtpNgayCoHieuLuc.EditValue = null;
            else
            {
                dtpNgayCoHieuLuc.EditValue = drQuaTrinhKyLuat[pNS_QuaTrinhKyLuatInfo.strNgayCoHieuLuc];
            }
            if ("" + drQuaTrinhKyLuat[pNS_QuaTrinhKyLuatInfo.strNgayHetHieuLuc] == "")
                dtpNgayHetHieuLuc.EditValue = null;
            else
            {
                dtpNgayHetHieuLuc.EditValue = drQuaTrinhKyLuat[pNS_QuaTrinhKyLuatInfo.strNgayHetHieuLuc];
            }
            cmbCapKhenThuong.EditValue = int.Parse("0" + pNS_QuaTrinhKyLuatInfo.IDDM_CapKhenThuong);
            txtNoiDung.Text = "" + pNS_QuaTrinhKyLuatInfo.NoiDung;
            txtTangSoThangTangLuong.Text = pNS_QuaTrinhKyLuatInfo.TangSoThangTangLuong.ToString();
            if ("" + drQuaTrinhKyLuat[pNS_QuaTrinhKyLuatInfo.strNgayXoa] == "")
                dtpNgayXoa.EditValue = null;
            else
            {
                dtpNgayXoa.EditValue = drQuaTrinhKyLuat[pNS_QuaTrinhKyLuatInfo.strNgayXoa];
            }
            chkXoaTangSoThangTangLuong.Checked = bool.Parse(drQuaTrinhKyLuat[pNS_QuaTrinhKyLuatInfo.strXoaTangSoThangTangLuong].ToString());
            txtLyDoXoa.Text = "" + drQuaTrinhKyLuat[pNS_QuaTrinhKyLuatInfo.strLyDoXoa];
            txtSoQuyetDinh.Focus();
        }

        private void GetpInfo()
        {
            pNS_QuaTrinhKyLuatInfo.IDNS_GiaoVien = int.Parse(drGiaoVien[pGiaoVienInfo.strNS_GiaoVienID].ToString());
            pNS_QuaTrinhKyLuatInfo.SoQuyetDinh = txtSoQuyetDinh.Text;
            if (dtpNgayQuyetDinh.EditValue == null)
            {
                pNS_QuaTrinhKyLuatInfo.NgayQuyetDinh = DateTime.Parse("01/01/1900");
            }
            else
            {
                pNS_QuaTrinhKyLuatInfo.NgayQuyetDinh = DateTime.Parse(dtpNgayQuyetDinh.EditValue.ToString());
            }
            if (dtpNgayCoHieuLuc.EditValue == null)
            {
                pNS_QuaTrinhKyLuatInfo.NgayCoHieuLuc = DateTime.Parse("01/01/1900");
            }
            else
            {
                pNS_QuaTrinhKyLuatInfo.NgayCoHieuLuc = DateTime.Parse(dtpNgayCoHieuLuc.EditValue.ToString());
            }
            if (dtpNgayHetHieuLuc.EditValue == null)
            {
                pNS_QuaTrinhKyLuatInfo.NgayHetHieuLuc = DateTime.Parse("01/01/1900");
            }
            else
            {
                pNS_QuaTrinhKyLuatInfo.NgayHetHieuLuc = DateTime.Parse(dtpNgayHetHieuLuc.EditValue.ToString());
            }
            pNS_QuaTrinhKyLuatInfo.IDDM_CapKhenThuong = int.Parse("0" + cmbCapKhenThuong.EditValue);
            pNS_QuaTrinhKyLuatInfo.NoiDung = txtNoiDung.Text;
            pNS_QuaTrinhKyLuatInfo.TangSoThangTangLuong = int.Parse("0" + txtTangSoThangTangLuong.Text);
            if (edit == EDIT_MODE.THEM)
            {
                pNS_QuaTrinhKyLuatInfo.XoaKyLuat = false;
                pNS_QuaTrinhKyLuatInfo.NgayXoa = DateTime.Parse("01/01/1900");
                pNS_QuaTrinhKyLuatInfo.XoaTangSoThangTangLuong = false;
                pNS_QuaTrinhKyLuatInfo.LyDoXoa = "";
            }
        }

        private void grvGiaoVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvGiaoVien.DataRowCount > 0)
            {
                idxGV = grvGiaoVien.FocusedRowHandle;
                DataRow dr = grvGiaoVien.GetDataRow(idxGV);
                oBGiaoVien.ToInfo(ref pGiaoVienInfo, dr);
                drGiaoVien = grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle);
                LoadQuaTrinhKyLuat();
                ClearText();
                grvQuaTrinhKyLuat_FocusedRowChanged(null, null);
                if (grvQuaTrinhKyLuat.DataRowCount > 0)
                {
                    SetButton(true);
                }
                else
                {
                    SetButton(false);
                    btnThem.Enabled = true;
                }
            }
            else
            {
                SetButton(false);
                btnThem.Enabled = true;
                layXoaKyLuat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                grdQuaTrinhKyLuat.DataSource = null;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetGrdTrv(false);
            SetButton(false);
            layXoaKyLuat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            SetControl(false);
            btnLuu.Enabled = true;
            edit = EDIT_MODE.THEM;
            ClearText();
            ClearTextXoaKyLuat();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetGrdTrv(false);
            SetButton(false);
            SetControl(false);
            btnLuu.Enabled = true;
            edit = EDIT_MODE.SUA;
            SetText();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    pNS_QuaTrinhKyLuatInfo.NS_QuaTrinhKyLuatID = int.Parse(drQuaTrinhKyLuat[pNS_QuaTrinhKyLuatInfo.strNS_QuaTrinhKyLuatID].ToString());
                    oBQuaTrinhKyLuat.Delete(pNS_QuaTrinhKyLuatInfo);
                    // ghi log
                    GhiLog("Xóa quá trình kỷ luật giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " số quyết định " + pNS_QuaTrinhKyLuatInfo.SoQuyetDinh + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtQuaTrinhKyLuat.Rows.Remove(drQuaTrinhKyLuat);
                    XoaThanhCong();
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }

        private void ClearTextXoaKyLuat()
        {
            dtpNgayXoa.EditValue = null;
            chkXoaTangSoThangTangLuong.Checked = false;
            txtLyDoXoa.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (edit == EDIT_MODE.THEM || edit == EDIT_MODE.SUA)
            {
                if (!Check_Valid()) return;
                try
                {
                    GetpInfo();
                    if (edit == EDIT_MODE.THEM)
                    {
                        pNS_QuaTrinhKyLuatInfo.NS_QuaTrinhKyLuatID = oBQuaTrinhKyLuat.Add(pNS_QuaTrinhKyLuatInfo);
                        GhiLog("Thêm quá trình kỷ luật giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " số quyết định " + pNS_QuaTrinhKyLuatInfo.SoQuyetDinh + "' vào CSDL ", "Thêm", this.Tag.ToString());
                        DataRow drNew = dtQuaTrinhKyLuat.NewRow();
                        oBQuaTrinhKyLuat.ToDataRow(pNS_QuaTrinhKyLuatInfo, ref drNew);
                        dtQuaTrinhKyLuat.Rows.Add(drNew);
                        ClearText();
                    }
                    else
                    {
                        pNS_QuaTrinhKyLuatInfo.NS_QuaTrinhKyLuatID = int.Parse(drQuaTrinhKyLuat[pNS_QuaTrinhKyLuatInfo.strNS_QuaTrinhKyLuatID].ToString());
                        oBQuaTrinhKyLuat.Update(pNS_QuaTrinhKyLuatInfo);
                        GhiLog("Sửa quá trình kỷ luật giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " số quyết dịnh " + pNS_QuaTrinhKyLuatInfo.SoQuyetDinh + "' trong CSDL ", "Sửa", this.Tag.ToString());
                        oBQuaTrinhKyLuat.ToDataRow(pNS_QuaTrinhKyLuatInfo, ref drQuaTrinhKyLuat);
                        SuaThanhCong();
                        btnHuy_Click(null, null);
                    }
                }
                catch
                {
                    ThongBaoLoi("Có lỗi trong quá trình thêm hoặc sửa hoặc ghi log.");
                }
            }
            else
            {
                if (!Check_Valid_XoaKyLuat()) return;
                if (ThongBaoChon("Bạn có chắc chắn xóa kỷ luật này?") == DialogResult.Yes)
                {
                    try
                    {
                        int NS_QuaTrinhKyLuatID = int.Parse(drQuaTrinhKyLuat[pNS_QuaTrinhKyLuatInfo.strNS_QuaTrinhKyLuatID].ToString());
                        bool XoaKyLuat = true;
                        DateTime NgayXoa = DateTime.Parse(dtpNgayXoa.EditValue.ToString());
                        bool XoaTangSoThangTangLuong = chkXoaTangSoThangTangLuong.Checked;
                        string LyDoXoa = txtLyDoXoa.Text;
                        oBQuaTrinhKyLuat.UpdateBy_NSQuaTrinhKyLuatID(XoaKyLuat, NgayXoa, LyDoXoa, XoaTangSoThangTangLuong, NS_QuaTrinhKyLuatID);
                        GhiLog("Xoas quá trình kỷ luật giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " số quyết dịnh " + pNS_QuaTrinhKyLuatInfo.SoQuyetDinh + "' trong CSDL ", "Sửa", this.Tag.ToString());
                        drQuaTrinhKyLuat[pNS_QuaTrinhKyLuatInfo.strXoaKyLuat] = true;
                        drQuaTrinhKyLuat[pNS_QuaTrinhKyLuatInfo.strNgayXoa] = dtpNgayXoa.EditValue;
                        drQuaTrinhKyLuat[pNS_QuaTrinhKyLuatInfo.strXoaTangSoThangTangLuong] = chkXoaTangSoThangTangLuong.Checked;
                        drQuaTrinhKyLuat[pNS_QuaTrinhKyLuatInfo.strLyDoXoa] = txtLyDoXoa.Text;
                        XoaThanhCong();
                        btnHuy_Click(null, null);
                    }
                    catch
                    {
                        XoaThatBai();
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetGrdTrv(true);
            dxErrorProvider.ClearErrors();
            SetControl(true);
            SetControlXoaKyLuat(true);
            btnLuu.Enabled = false;
            grvQuaTrinhKyLuat_FocusedRowChanged(null, null);
        }

        private void cmbCapKhenThuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmDMCapKhenThuong frm = new frmDMCapKhenThuong(null, this, null, null);
                frm.ShowDialog();
                if (IDDM_CapKyLuat > 0)
                {
                    cmbCapKhenThuong.Properties.DataSource = LoadCapKhenThuong();
                    reposCapKhenThuong.DataSource = LoadCapKhenThuong();
                    cmbCapKhenThuong.EditValue = IDDM_CapKyLuat;

                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                cmbCapKhenThuong.EditValue = null;
            }
        }

        private void grvQuaTrinhKyLuat_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvQuaTrinhKyLuat.FocusedRowHandle >= 0)
            {
                drQuaTrinhKyLuat = grvQuaTrinhKyLuat.GetDataRow(grvQuaTrinhKyLuat.FocusedRowHandle);
                oBQuaTrinhKyLuat.ToInfo(ref pNS_QuaTrinhKyLuatInfo, drQuaTrinhKyLuat);
                if (bool.Parse(drQuaTrinhKyLuat[pNS_QuaTrinhKyLuatInfo.strXoaKyLuat].ToString()) == true)
                {
                    layXoaKyLuat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    SetControlXoaKyLuat(true);
                }
                else
                {
                    layXoaKyLuat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                SetText();
            }
            if (grvQuaTrinhKyLuat != null)
                if (grvQuaTrinhKyLuat.DataRowCount > 0 && grvQuaTrinhKyLuat.FocusedRowHandle >= 0)
                {
                    SetButton(true);
                    drQuaTrinhKyLuat = grvQuaTrinhKyLuat.GetDataRow(grvQuaTrinhKyLuat.FocusedRowHandle);
                    return;
                }
            SetButton(false);
            btnThem.Enabled = true;
            layXoaKyLuat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            drQuaTrinhKyLuat = null;
        }

        private void grvQuaTrinhKyLuat_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void frmQuaTrinhKyLuat_Load(object sender, EventArgs e)
        {
            LoadTreeView();
            Loaded = true;
            trvDonVi_FocusedNodeChanged(null, null);
            LoadCombo();
        }

        private void SetControlXoaKyLuat(bool mbool)
        {
            dtpNgayXoa.Properties.ReadOnly = mbool;
            chkXoaTangSoThangTangLuong.Checked = false;
            chkXoaTangSoThangTangLuong.Properties.ReadOnly = mbool;
            txtLyDoXoa.Properties.ReadOnly = mbool;
        }

        private bool Check_Valid_XoaKyLuat()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (dtpNgayXoa.EditValue == null)
            {
                dxErrorProvider.SetError(dtpNgayXoa, "Ngày xóa kỷ luật không thể rỗng không thể rỗng.");
                if (CtrlErr == null) CtrlErr = dtpNgayXoa;
            }

            //Kiểm tra cập nhật thành công
            if (CtrlErr != null)
            {
                CtrlErr.Focus();
                return false;
            }
            else
                return true;
        }


        private void btnXoaKyLuat_Click(object sender, EventArgs e)
        {
            if (grvQuaTrinhKyLuat.DataRowCount > 0 && bool.Parse(drQuaTrinhKyLuat[pNS_QuaTrinhKyLuatInfo.strXoaKyLuat].ToString()) == false)
            {
                SetControlXoaKyLuat(false);
                layXoaKyLuat.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                edit = EDIT_MODE.KHAC;
                btnLuu.Enabled = true;
                SetGrdTrv(false);
            }
            else
            {
                SetGrdTrv(true);
            }
        }
    }
}