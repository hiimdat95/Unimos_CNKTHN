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
    public partial class frmQuaTrinhLuanChuyen : frmBase
    {
        private cBNS_DonVi oBDonVi;
        private NS_DonViInfo pDonViInfo;
        private cBNS_GiaoVien oBGiaoVien;
        public NS_GiaoVienInfo pGiaoVienInfo;
        public cBNS_QuaTrinhLuanChuyen oBQuaTrinhLuanChuyen;
        public NS_QuaTrinhLuanChuyenInfo pNS_QuaTrinhLuanChuyenInfo;
        private DataTable dtTree, dtGiaoVien, dtQuaTrinhLuanChuyen;
        DataRow drGiaoVien, drQuaTrinhLuanChuyen;
        private bool Loaded = false;
        private int idxGV;
        private EDIT_MODE edit;
        public int IDDM_LoaiLuanChuyen;

        public frmQuaTrinhLuanChuyen()
        {
            InitializeComponent();
            oBGiaoVien = new cBNS_GiaoVien();
            pGiaoVienInfo = new NS_GiaoVienInfo();
            pDonViInfo = new NS_DonViInfo();
            oBQuaTrinhLuanChuyen = new cBNS_QuaTrinhLuanChuyen();
            pNS_QuaTrinhLuanChuyenInfo = new NS_QuaTrinhLuanChuyenInfo();
            SetButton(false);
            btnThem.Enabled = true;
            SetControl(true);
            dtpNgayQuyetDinh.Enabled = false;
            dtpNgayCoHieuLuc.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void LoadQuaTrinhLuanChuyen()
        {
            dtQuaTrinhLuanChuyen = oBQuaTrinhLuanChuyen.GetBy_IDNS_GiaoVien(int.Parse(grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle)["NS_GiaoVienID"].ToString()));
            grdQuaTrinhLuanChuyen.DataSource = dtQuaTrinhLuanChuyen;
        }

        private void LoadCombo()
        {
            cmbDonViMoi.Properties.DataSource = LoadDonVi();
            cmbLoaiLuanChuyen.Properties.DataSource = LoadLoaiLuanChuyen();
            reposDonViMoi.DataSource = LoadDonVi();
            reposLoaiLuanChuyen.DataSource = LoadLoaiLuanChuyen();
        }

        private void LoadGiaoVien(int IDDonVi)
        {
            pGiaoVienInfo.IDNS_DonVi = IDDonVi;
            dtGiaoVien = oBGiaoVien.GetGiaoVien_DangGiangDay_ByIDNS_DonVi(IDDonVi);
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
            cmbLoaiLuanChuyen.Properties.ReadOnly = mbool;
            cmbDonViMoi.Properties.ReadOnly = mbool;
            txtNoiDung.Properties.ReadOnly = mbool;
            txtSoQuyetDinh.Focus();
        }

        private void SetButton(bool status)
        {
            btnThem.Enabled = status;
            btnSua.Enabled = status;
            btnXoa.Enabled = status;
        }

        private void SetGrvTrv(bool status)
        {
            trvDonVi.Enabled = status;
            grdGiaoVien.Enabled = status;
            grdQuaTrinhLuanChuyen.Enabled = status;
        }

        private void ClearText()
        {
            txtSoQuyetDinh.Text = "";
            dtpNgayQuyetDinh.EditValue = null;
            dtpNgayCoHieuLuc.EditValue = null;
            cmbLoaiLuanChuyen.EditValue = null;
            cmbDonViMoi.EditValue = null;
            txtNoiDung.Text = "";
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
                dxErrorProvider.SetError(dtpNgayQuyetDinh, "Ngày quyết định luân chuyển không thể rỗng.");
                if (CtrlErr == null) CtrlErr = dtpNgayQuyetDinh;
            }
            if (dtpNgayCoHieuLuc.EditValue == null)
            {
                dxErrorProvider.SetError(dtpNgayCoHieuLuc, "Ngày có hiệu lực luân chuyển không thể rỗng.");
                if (CtrlErr == null) CtrlErr = dtpNgayCoHieuLuc;
            }
            if (cmbLoaiLuanChuyen.EditValue == null)
            {
                dxErrorProvider.SetError(cmbLoaiLuanChuyen, "Loại luân chuyển không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbLoaiLuanChuyen;
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
            txtSoQuyetDinh.Text = "" + pNS_QuaTrinhLuanChuyenInfo.SoQuyetDinh;

            if ("" + drQuaTrinhLuanChuyen[pNS_QuaTrinhLuanChuyenInfo.strNgayQuyetDinh] == "")
            {
                dtpNgayQuyetDinh.EditValue = null;
            }
            else
            {
                dtpNgayQuyetDinh.EditValue = DateTime.Parse(drQuaTrinhLuanChuyen[pNS_QuaTrinhLuanChuyenInfo.strNgayQuyetDinh].ToString());
            }
            if ("" + drQuaTrinhLuanChuyen[pNS_QuaTrinhLuanChuyenInfo.strNgayCoHieuLuc] == "")
            {
                dtpNgayCoHieuLuc.EditValue = null;
            }
            else
            {
                dtpNgayCoHieuLuc.EditValue = DateTime.Parse(drQuaTrinhLuanChuyen[pNS_QuaTrinhLuanChuyenInfo.strNgayCoHieuLuc].ToString());
            }
            cmbLoaiLuanChuyen.EditValue = int.Parse("0" + pNS_QuaTrinhLuanChuyenInfo.IDNS_LoaiLuanChuyen);
            cmbDonViMoi.EditValue = int.Parse("0" + pNS_QuaTrinhLuanChuyenInfo.IDNS_DonViMoi);
            txtNoiDung.Text = "" + pNS_QuaTrinhLuanChuyenInfo.NoiDung;
            txtSoQuyetDinh.Focus();
        }

        private void GetpInfo()
        {
            pNS_QuaTrinhLuanChuyenInfo.IDNS_GiaoVien = int.Parse(drGiaoVien[pGiaoVienInfo.strNS_GiaoVienID].ToString());
            pNS_QuaTrinhLuanChuyenInfo.SoQuyetDinh = txtSoQuyetDinh.Text;
            if (dtpNgayQuyetDinh.EditValue == null)
            {
                pNS_QuaTrinhLuanChuyenInfo.NgayQuyetDinh = DateTime.Parse("01/01/1900");
            }
            else
            {
                pNS_QuaTrinhLuanChuyenInfo.NgayQuyetDinh = DateTime.Parse(dtpNgayQuyetDinh.EditValue.ToString());
            }
            if (dtpNgayCoHieuLuc.EditValue == null)
            {
                pNS_QuaTrinhLuanChuyenInfo.NgayCoHieuLuc = DateTime.Parse("01/01/1900");
            }
            else
            {
                pNS_QuaTrinhLuanChuyenInfo.NgayCoHieuLuc = DateTime.Parse(dtpNgayCoHieuLuc.EditValue.ToString());
            }
            pNS_QuaTrinhLuanChuyenInfo.IDNS_LoaiLuanChuyen = int.Parse("0" + cmbLoaiLuanChuyen.EditValue);
            pNS_QuaTrinhLuanChuyenInfo.IDNS_DonViCu = int.Parse("0" + pDonViInfo.NS_DonViID);
            pNS_QuaTrinhLuanChuyenInfo.IDNS_DonViMoi = int.Parse("0" + cmbDonViMoi.EditValue);
            pNS_QuaTrinhLuanChuyenInfo.NoiDung = txtNoiDung.Text;
            
        }

        private void grvGiaoVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvGiaoVien.DataRowCount > 0)
            {
                idxGV = grvGiaoVien.FocusedRowHandle;
                DataRow dr = grvGiaoVien.GetDataRow(idxGV);
                oBGiaoVien.ToInfo(ref pGiaoVienInfo, dr);
                drGiaoVien = grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle);
                LoadQuaTrinhLuanChuyen();
                ClearText();
                grvQuaTrinhLuanChuyen_FocusedRowChanged(null, null);
                if (grvQuaTrinhLuanChuyen.DataRowCount > 0)
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
                grdQuaTrinhLuanChuyen.DataSource = null;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetGrvTrv(false);
            SetButton(false);
            SetControl(false);
            dtpNgayQuyetDinh.Enabled = true;
            dtpNgayCoHieuLuc.Enabled = true;
            btnLuu.Enabled = true;
            edit = EDIT_MODE.THEM;
            ClearText();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetGrvTrv(false);
            SetButton(false);
            SetControl(false);
            dtpNgayQuyetDinh.Enabled = true;
            dtpNgayCoHieuLuc.Enabled = true;
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
                    pNS_QuaTrinhLuanChuyenInfo.NS_QuaTrinhLuanChuyenID = int.Parse(drQuaTrinhLuanChuyen[pNS_QuaTrinhLuanChuyenInfo.strNS_QuaTrinhLuanChuyenID].ToString());
                    oBQuaTrinhLuanChuyen.Delete(pNS_QuaTrinhLuanChuyenInfo);
                    // ghi log
                    GhiLog("Xóa quá trình luân chuyển giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " số quyết định " + pNS_QuaTrinhLuanChuyenInfo.SoQuyetDinh + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtQuaTrinhLuanChuyen.Rows.Remove(drQuaTrinhLuanChuyen);
                    XoaThanhCong();
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!Check_Valid()) return;
            try
            {
                GetpInfo();
                if (edit == EDIT_MODE.THEM)
                {
                    pNS_QuaTrinhLuanChuyenInfo.NS_QuaTrinhLuanChuyenID = oBQuaTrinhLuanChuyen.Add(pNS_QuaTrinhLuanChuyenInfo);
                    GhiLog("Thêm quá trình luân chuyển giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " số quyết định " + pNS_QuaTrinhLuanChuyenInfo.SoQuyetDinh + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtQuaTrinhLuanChuyen.NewRow();
                    oBQuaTrinhLuanChuyen.ToDataRow(pNS_QuaTrinhLuanChuyenInfo, ref drNew);
                    dtQuaTrinhLuanChuyen.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pNS_QuaTrinhLuanChuyenInfo.NS_QuaTrinhLuanChuyenID = int.Parse(drQuaTrinhLuanChuyen[pNS_QuaTrinhLuanChuyenInfo.strNS_QuaTrinhLuanChuyenID].ToString());
                    oBQuaTrinhLuanChuyen.Update(pNS_QuaTrinhLuanChuyenInfo);
                    GhiLog("Sửa quá trình luân chuyển giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " số quyết định " + pNS_QuaTrinhLuanChuyenInfo.SoQuyetDinh + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    oBQuaTrinhLuanChuyen.ToDataRow(pNS_QuaTrinhLuanChuyenInfo, ref drQuaTrinhLuanChuyen);
                    SuaThanhCong();
                    btnHuy_Click(null, null);
                }
            }
            catch
            {
                ThongBaoLoi("Có lỗi trong quá trình thêm hoặc sửa hoặc ghi log.");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetGrvTrv(true);
            dxErrorProvider.ClearErrors();
            SetControl(true);
            dtpNgayQuyetDinh.Enabled = false;
            dtpNgayCoHieuLuc.Enabled = false;
            btnLuu.Enabled = false;
            grvQuaTrinhLuanChuyen_FocusedRowChanged(null, null);
        }

        private void frmQuaTrinhLuanChuyen_Load(object sender, EventArgs e)
        {
            LoadTreeView();
            Loaded = true;
            trvDonVi_FocusedNodeChanged(null, null);
            LoadCombo();
        }

        private void grvQuaTrinhLuanChuyen_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvQuaTrinhLuanChuyen.FocusedRowHandle >= 0)
            {
                drQuaTrinhLuanChuyen = grvQuaTrinhLuanChuyen.GetDataRow(grvQuaTrinhLuanChuyen.FocusedRowHandle);
                oBQuaTrinhLuanChuyen.ToInfo(ref pNS_QuaTrinhLuanChuyenInfo, drQuaTrinhLuanChuyen);
                SetText();
            }
            if (grvQuaTrinhLuanChuyen != null)
                if (grvQuaTrinhLuanChuyen.DataRowCount > 0 && grvQuaTrinhLuanChuyen.FocusedRowHandle >= 0)
                {
                    SetButton(true);
                    drQuaTrinhLuanChuyen = grvQuaTrinhLuanChuyen.GetDataRow(grvQuaTrinhLuanChuyen.FocusedRowHandle);
                    return;
                }
            SetButton(false);
            btnThem.Enabled = true;
            drQuaTrinhLuanChuyen = null;
        }

        private void grvQuaTrinhLuanChuyen_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void barbtnLuanChuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dtQuaTrinhLuanChuyen.DefaultView.RowFilter = "IDNS_GiaoVien=" + drGiaoVien["NS_GiaoVienID"].ToString();
            if (dtQuaTrinhLuanChuyen.DefaultView.Count > 0)
            {
                if (ThongBaoChon("Bạn có chắc chắn luân chuyển cán bộ này.") == DialogResult.Yes)
                {
                    try
                    {
                        oBQuaTrinhLuanChuyen.Get_UpdateBy_IDNS_GiaoVien(int.Parse(drGiaoVien[pGiaoVienInfo.strNS_GiaoVienID].ToString()));
                        // ghi log
                        GhiLog("Luân chuyển giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " số quyết định " + pNS_QuaTrinhLuanChuyenInfo.SoQuyetDinh + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                        dtGiaoVien.Rows.Remove(drGiaoVien);
                        ThongBao("Quá trình luân chuyển giáo viên thành công.");
                    }
                    catch
                    {
                        ThongBao("Quá trình luân chuyển giáo viên có lỗi, kiểm tra lại.");
                    }
                }
            }
            else
            {
                ThongBao("Bạn phải nhập thông tin luân chuyển trước khi luân chuyển giáo viên.");
                return;
            }
        }

        private void grdGiaoVien_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && grdGiaoVien.ClientRectangle.Contains(e.X, e.Y))
            {
                popupMenuLuanChuyen.ShowPopup(MousePosition);
            }
        }

        private void cmbLoaiLuanChuyen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmDM_LoaiLuanChuyen frm = new frmDM_LoaiLuanChuyen(this);
                frm.ShowDialog();
                if (IDDM_LoaiLuanChuyen > 0)
                {
                    cmbLoaiLuanChuyen.Properties.DataSource = LoadLoaiLuanChuyen();
                    cmbLoaiLuanChuyen.EditValue = IDDM_LoaiLuanChuyen;
                    reposLoaiLuanChuyen.DataSource = LoadLoaiLuanChuyen();
                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                cmbLoaiLuanChuyen.EditValue = null;
            }
        }
    }
}