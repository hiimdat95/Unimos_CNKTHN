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
    public partial class frmQuaTrinhKhenThuong : frmBase
    {
        private cBNS_DonVi oBDonVi;
        private NS_DonViInfo pDonViInfo;
        private cBNS_GiaoVien oBGiaoVien;
        public NS_GiaoVienInfo pGiaoVienInfo;
        public cBNS_QuaTrinhKhenThuong oBQuaTrinhKhenThuong;
        public NS_QuaTrinhKhenThuongInfo pNS_QuaTrinhKhenThuongInfo;
        private DataTable dtTree, dtGiaoVien, dtQuaTrinhKhenThuong;
        DataRow drGiaoVien, drQuaTrinhKhenThuong;
        private bool Loaded = false;
        private int idxGV;
        private EDIT_MODE edit;
        public int IDDM_CapKhenThuong;

        public frmQuaTrinhKhenThuong()
        {
            InitializeComponent();
            oBGiaoVien = new cBNS_GiaoVien();
            pGiaoVienInfo = new NS_GiaoVienInfo();
            pDonViInfo = new NS_DonViInfo();
            oBQuaTrinhKhenThuong = new cBNS_QuaTrinhKhenThuong();
            pNS_QuaTrinhKhenThuongInfo = new NS_QuaTrinhKhenThuongInfo();
            SetButton(false);
            btnThem.Enabled = true;
            SetControl(true);
            btnLuu.Enabled = false;
        }

        private void LoadQuaTrinhKhenThuong()
        {
            dtQuaTrinhKhenThuong = oBQuaTrinhKhenThuong.GetBy_IDNS_GiaoVien(int.Parse(grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle)["NS_GiaoVienID"].ToString()));
            grdQuaTrinhKhenThuong.DataSource = dtQuaTrinhKhenThuong;
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
            cmbCapKhenThuong.Properties.ReadOnly = mbool;
            txtNoiDung.Properties.ReadOnly = mbool;
            txtSoThangGiamTangLuong.Properties.ReadOnly = mbool;
            txtSoTien.Properties.ReadOnly = mbool;
            txtSoQuyetDinh.Focus();
        }

        private void SetButton(bool status)
        {
            btnThem.Enabled = status;
            btnSua.Enabled = status;
            btnXoa.Enabled = status;
        }

        private void SetTrvGrv(bool status)
        {
            trvDonVi.Enabled = status;
            grdGiaoVien.Enabled = status;
            grdQuaTrinhKhenThuong.Enabled = status;
        }

        private void ClearText()
        {
            txtSoQuyetDinh.Text = "";
            dtpNgayQuyetDinh.EditValue = null;
            dtpNgayCoHieuLuc.EditValue = null;
            cmbCapKhenThuong.EditValue = null;
            txtNoiDung.Text = "";
            txtSoThangGiamTangLuong.Text = "";
            txtSoTien.Text = "";
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
                dxErrorProvider.SetError(dtpNgayCoHieuLuc, "Ngày có hiệu lực không thể rỗng.");
                if (CtrlErr == null) CtrlErr = dtpNgayCoHieuLuc;
            }
            if (cmbCapKhenThuong.EditValue == null)
            {
                dxErrorProvider.SetError(cmbCapKhenThuong, "Cấp khen thưởng không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbCapKhenThuong;
            }
            if (txtNoiDung.Text == "")
            {
                dxErrorProvider.SetError(txtNoiDung, "Nội dung khen thưởng không thể rỗng.");
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
            txtSoQuyetDinh.Text = "" + pNS_QuaTrinhKhenThuongInfo.SoQuyetDinh;
            if ("" + drQuaTrinhKhenThuong[pNS_QuaTrinhKhenThuongInfo.strNgayQuyetDinh] == "")
                dtpNgayQuyetDinh.EditValue = null;
            else
            {
                dtpNgayQuyetDinh.EditValue = drQuaTrinhKhenThuong[pNS_QuaTrinhKhenThuongInfo.strNgayQuyetDinh];
            }
            if ("" + drQuaTrinhKhenThuong[pNS_QuaTrinhKhenThuongInfo.strNgayCoHieuLuc] == "")
                dtpNgayCoHieuLuc.EditValue = null;
            else
            {
                dtpNgayCoHieuLuc.EditValue = drQuaTrinhKhenThuong[pNS_QuaTrinhKhenThuongInfo.strNgayCoHieuLuc];
            }
            cmbCapKhenThuong.EditValue = int.Parse("0" + pNS_QuaTrinhKhenThuongInfo.IDDM_CapKhenThuong);
            txtNoiDung.Text = "" + pNS_QuaTrinhKhenThuongInfo.NoiDung;
            txtSoThangGiamTangLuong.Text = pNS_QuaTrinhKhenThuongInfo.GiamSoThangTangLuong.ToString();
            txtSoTien.Text = pNS_QuaTrinhKhenThuongInfo.SoTien.ToString();
            txtSoQuyetDinh.Focus();
        }

        private void GetpInfo()
        {
            pNS_QuaTrinhKhenThuongInfo.IDNS_GiaoVien = int.Parse(drGiaoVien[pGiaoVienInfo.strNS_GiaoVienID].ToString());
            pNS_QuaTrinhKhenThuongInfo.SoQuyetDinh = txtSoQuyetDinh.Text;
            if (dtpNgayQuyetDinh.EditValue == null)
            {
                pNS_QuaTrinhKhenThuongInfo.NgayQuyetDinh = DateTime.Parse("01/01/1900");
            }
            else
            {
                pNS_QuaTrinhKhenThuongInfo.NgayQuyetDinh = DateTime.Parse(dtpNgayQuyetDinh.EditValue.ToString());
            }
            if (dtpNgayCoHieuLuc.EditValue == null)
            {
                pNS_QuaTrinhKhenThuongInfo.NgayCoHieuLuc = DateTime.Parse("01/01/1900");
            }
            else
            {
                pNS_QuaTrinhKhenThuongInfo.NgayCoHieuLuc = DateTime.Parse(dtpNgayCoHieuLuc.EditValue.ToString());
            }
            pNS_QuaTrinhKhenThuongInfo.IDDM_CapKhenThuong = int.Parse("0" + cmbCapKhenThuong.EditValue);
            pNS_QuaTrinhKhenThuongInfo.NoiDung = txtNoiDung.Text;
            pNS_QuaTrinhKhenThuongInfo.GiamSoThangTangLuong = int.Parse("0" + txtSoThangGiamTangLuong.Text);
            pNS_QuaTrinhKhenThuongInfo.SoTien = double.Parse("0" + txtSoTien.Text);
        }

        private void grvGiaoVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvGiaoVien.DataRowCount > 0)
            {
                idxGV = grvGiaoVien.FocusedRowHandle;
                DataRow dr = grvGiaoVien.GetDataRow(idxGV);
                oBGiaoVien.ToInfo(ref pGiaoVienInfo, dr);
                drGiaoVien = grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle);
                LoadQuaTrinhKhenThuong();
                ClearText();
                grvQuaTrinhKhenThuong_FocusedRowChanged(null, null);
                if (grvQuaTrinhKhenThuong.DataRowCount > 0)
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
                grdQuaTrinhKhenThuong.DataSource = null;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetTrvGrv(false);
            SetControl(false);
            SetButton(false);
            btnLuu.Enabled = true;
            edit = EDIT_MODE.THEM;
            ClearText();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetTrvGrv(false);
            SetControl(false);
            SetButton(false);
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
                    pNS_QuaTrinhKhenThuongInfo.NS_QuaTrinhKhenThuongID = int.Parse(drQuaTrinhKhenThuong[pNS_QuaTrinhKhenThuongInfo.strNS_QuaTrinhKhenThuongID].ToString());
                    oBQuaTrinhKhenThuong.Delete(pNS_QuaTrinhKhenThuongInfo);
                    // ghi log
                    GhiLog("Xóa quá trình khen thưởng giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " số quyết định " + pNS_QuaTrinhKhenThuongInfo.SoQuyetDinh + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtQuaTrinhKhenThuong.Rows.Remove(drQuaTrinhKhenThuong);
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
                    pNS_QuaTrinhKhenThuongInfo.NS_QuaTrinhKhenThuongID = oBQuaTrinhKhenThuong.Add(pNS_QuaTrinhKhenThuongInfo);
                    GhiLog("Thêm quá trình khen thưởng giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " số quyết định " + pNS_QuaTrinhKhenThuongInfo.SoQuyetDinh + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtQuaTrinhKhenThuong.NewRow();
                    oBQuaTrinhKhenThuong.ToDataRow(pNS_QuaTrinhKhenThuongInfo, ref drNew);
                    dtQuaTrinhKhenThuong.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pNS_QuaTrinhKhenThuongInfo.NS_QuaTrinhKhenThuongID = int.Parse(drQuaTrinhKhenThuong[pNS_QuaTrinhKhenThuongInfo.strNS_QuaTrinhKhenThuongID].ToString());
                    oBQuaTrinhKhenThuong.Update(pNS_QuaTrinhKhenThuongInfo);
                    GhiLog("Sửa quá trình khen thưởng giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " số quyết dịnh " + pNS_QuaTrinhKhenThuongInfo.SoQuyetDinh + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    oBQuaTrinhKhenThuong.ToDataRow(pNS_QuaTrinhKhenThuongInfo, ref drQuaTrinhKhenThuong);
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
            SetTrvGrv(true);
            dxErrorProvider.ClearErrors();
            SetControl(true);
            btnLuu.Enabled = false;
            grvQuaTrinhKhenThuong_FocusedRowChanged(null, null);
        }

        private void frmQuaTrinhKhenThuong_Load(object sender, EventArgs e)
        {
            LoadTreeView();
            Loaded = true;
            trvDonVi_FocusedNodeChanged(null, null);
            LoadCombo();
        }

        private void cmbCapKhenThuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmDMCapKhenThuong frm = new frmDMCapKhenThuong(this, null, null, null);
                frm.ShowDialog();
                if (IDDM_CapKhenThuong > 0)
                {
                    cmbCapKhenThuong.Properties.DataSource = LoadCapKhenThuong();
                    reposCapKhenThuong.DataSource = LoadCapKhenThuong();
                    cmbCapKhenThuong.EditValue = IDDM_CapKhenThuong;

                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                cmbCapKhenThuong.EditValue = null;
            }
        }

        private void grvQuaTrinhKhenThuong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvQuaTrinhKhenThuong.FocusedRowHandle >= 0)
            {
                drQuaTrinhKhenThuong = grvQuaTrinhKhenThuong.GetDataRow(grvQuaTrinhKhenThuong.FocusedRowHandle);
                oBQuaTrinhKhenThuong.ToInfo(ref pNS_QuaTrinhKhenThuongInfo, drQuaTrinhKhenThuong);
                SetText();
            }
            if (grvQuaTrinhKhenThuong != null)
                if (grvQuaTrinhKhenThuong.DataRowCount > 0 && grvQuaTrinhKhenThuong.FocusedRowHandle >= 0)
                {
                    SetButton(true);
                    drQuaTrinhKhenThuong = grvQuaTrinhKhenThuong.GetDataRow(grvQuaTrinhKhenThuong.FocusedRowHandle);
                    return;
                }
            SetButton(false);
            btnThem.Enabled = true;
            drQuaTrinhKhenThuong = null;
        }

        private void grvQuaTrinhKhenThuong_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }
    }
}