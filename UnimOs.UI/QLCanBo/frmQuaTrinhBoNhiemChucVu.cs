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
    public partial class frmQuaTrinhBoNhiemChucVu : frmBase
    {
        private cBNS_DonVi oBDonVi;
        private NS_DonViInfo pDonViInfo;
        private cBNS_GiaoVien oBGiaoVien;
        public NS_GiaoVienInfo pGiaoVienInfo;
        public cBNS_QuaTrinhBoNhiemChucVu oBQuaTrinhBoNhiemChucVu;
        public NS_QuaTrinhBoNhiemChucVuInfo pNS_QuaTrinhBoNhiemChucVuInfo;
        private DataTable dtTree, dtGiaoVien, dtQuaTrinhBoNhiemChucVu;
        DataRow drGiaoVien, drQuaTrinhBoNhiemChucVu;
        private bool Loaded = false;
        private int idxGV;
        private EDIT_MODE edit;
        public int IDDM_CapQuyetDinh, IDDM_ChucVu;

        public frmQuaTrinhBoNhiemChucVu()
        {
            InitializeComponent();
            oBGiaoVien = new cBNS_GiaoVien();
            pGiaoVienInfo = new NS_GiaoVienInfo();
            pDonViInfo = new NS_DonViInfo();
            oBQuaTrinhBoNhiemChucVu = new cBNS_QuaTrinhBoNhiemChucVu();
            pNS_QuaTrinhBoNhiemChucVuInfo = new NS_QuaTrinhBoNhiemChucVuInfo();
            SetButton(false);
            btnThem.Enabled = true;
            SetControl(true);
            btnLuu.Enabled = false;
            dtpNgayHetHieuLuc.Enabled = false;
        }

        private void frmQuaTrinhBoiDuong_Load(object sender, EventArgs e)
        {
            LoadTreeView();
            Loaded = true;
            trvDonVi_FocusedNodeChanged(null, null);
            LoadCombo();
        }

        private void LoadQuatrinhBoiDuong()
        {
            dtQuaTrinhBoNhiemChucVu = oBQuaTrinhBoNhiemChucVu.GetBy_IDNS_GiaoVien(int.Parse(grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle)["NS_GiaoVienID"].ToString()));
            grdQuaTrinhBoNhiemChucVu.DataSource = dtQuaTrinhBoNhiemChucVu;
        }

        private void LoadCombo()
        {
            cmbCapQuyetDinh.Properties.DataSource = LoadCapKhenThuong();
            cmbChucVuBoNhiem.Properties.DataSource = LoadChucVu();
            reposChucVu.DataSource = LoadChucVu();
            reposCapQuyetDinh.DataSource = LoadCapKhenThuong();
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
            cmbCapQuyetDinh.Properties.ReadOnly = mbool;
            cmbChucVuBoNhiem.Properties.ReadOnly = mbool;
            dtpNgayCoHieuLuc.Properties.ReadOnly = mbool;
            chkLaKiemNhiem.Checked = false;
            chkLaKiemNhiem.Properties.ReadOnly = mbool;
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
            grdQuaTrinhBoNhiemChucVu.Enabled = status;
        }

        private void ClearText()
        {
            txtSoQuyetDinh.Text = "";
            dtpNgayQuyetDinh.EditValue = null;
            cmbCapQuyetDinh.EditValue = null;
            cmbChucVuBoNhiem.EditValue = null;
            dtpNgayCoHieuLuc.EditValue = null;
            chkLaKiemNhiem.Checked = false;
            dtpNgayHetHieuLuc.Checked = false;
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
            if (cmbCapQuyetDinh.EditValue == null)
            {
                dxErrorProvider.SetError(cmbCapQuyetDinh, "Cấp quyết định không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbCapQuyetDinh;
            }
            if (cmbChucVuBoNhiem.EditValue == null)
            {
                dxErrorProvider.SetError(cmbChucVuBoNhiem, "Chức vụ bổ nhiệm, kiêm nhiệm không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbChucVuBoNhiem;
            }
            if (dtpNgayCoHieuLuc.EditValue == null)
            {
                dxErrorProvider.SetError(dtpNgayCoHieuLuc, "Ngày có hiệu lực không thể rỗng.");
                if (CtrlErr == null) CtrlErr = dtpNgayCoHieuLuc;
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
            txtSoQuyetDinh.Text = "" + pNS_QuaTrinhBoNhiemChucVuInfo.SoQuyetDinh;
            if ("" + drQuaTrinhBoNhiemChucVu[pNS_QuaTrinhBoNhiemChucVuInfo.strNgayRaQuyetDinh] == "")
                dtpNgayQuyetDinh.EditValue = null;
            else
                dtpNgayQuyetDinh.EditValue = drQuaTrinhBoNhiemChucVu[pNS_QuaTrinhBoNhiemChucVuInfo.strNgayRaQuyetDinh];
            if ("" + drQuaTrinhBoNhiemChucVu[pNS_QuaTrinhBoNhiemChucVuInfo.strNgayCoHieuLuc] == "")
                dtpNgayCoHieuLuc.EditValue = null;
            else
                dtpNgayCoHieuLuc.EditValue = drQuaTrinhBoNhiemChucVu[pNS_QuaTrinhBoNhiemChucVuInfo.strNgayCoHieuLuc];
            if ("" + drQuaTrinhBoNhiemChucVu[pNS_QuaTrinhBoNhiemChucVuInfo.strNgayHetHieuLuc] == "" || 
                DateTime.Parse(drQuaTrinhBoNhiemChucVu[pNS_QuaTrinhBoNhiemChucVuInfo.strNgayHetHieuLuc].ToString()) == 
                DateTime.ParseExact("31/12/9999", "dd/MM/yyyy", null))
            {
                dtpNgayHetHieuLuc.Value = DateTime.Today;
                dtpNgayHetHieuLuc.Checked = false;
            }
            else
            {
                dtpNgayHetHieuLuc.Value =DateTime.Parse(drQuaTrinhBoNhiemChucVu[pNS_QuaTrinhBoNhiemChucVuInfo.strNgayHetHieuLuc].ToString());
                dtpNgayHetHieuLuc.Checked = true;
            }
            cmbCapQuyetDinh.EditValue = int.Parse("0" + pNS_QuaTrinhBoNhiemChucVuInfo.IDDM_CapQuyetDinh);
            cmbChucVuBoNhiem.EditValue = int.Parse("0" + pNS_QuaTrinhBoNhiemChucVuInfo.IDDM_ChucVuBoNhiem);
            chkLaKiemNhiem.Checked = bool.Parse(pNS_QuaTrinhBoNhiemChucVuInfo.LaChucVuKiemNhiem.ToString());
            txtSoQuyetDinh.Focus();
        }

        private void GetpInfo()
        {
            pNS_QuaTrinhBoNhiemChucVuInfo.IDNS_GiaoVien = int.Parse(drGiaoVien[pGiaoVienInfo.strNS_GiaoVienID].ToString());
            pNS_QuaTrinhBoNhiemChucVuInfo.SoQuyetDinh = txtSoQuyetDinh.Text;
            if (dtpNgayQuyetDinh.EditValue == null)
                pNS_QuaTrinhBoNhiemChucVuInfo.NgayRaQuyetDinh = DateTime.Parse("01/01/1900");
            else
                pNS_QuaTrinhBoNhiemChucVuInfo.NgayRaQuyetDinh = DateTime.Parse(dtpNgayQuyetDinh.EditValue.ToString());
            if (dtpNgayCoHieuLuc.EditValue == null)
                pNS_QuaTrinhBoNhiemChucVuInfo.NgayCoHieuLuc = DateTime.Parse("01/01/1900");
            else
                pNS_QuaTrinhBoNhiemChucVuInfo.NgayCoHieuLuc = DateTime.Parse(dtpNgayCoHieuLuc.EditValue.ToString());
            pNS_QuaTrinhBoNhiemChucVuInfo.NgayHetHieuLuc = dtpNgayHetHieuLuc.Checked == false ? DateTime.ParseExact("31/12/9999", "dd/MM/yyyy", null) : dtpNgayHetHieuLuc.Value;
            pNS_QuaTrinhBoNhiemChucVuInfo.IDDM_CapQuyetDinh = int.Parse("0" + cmbCapQuyetDinh.EditValue);
            pNS_QuaTrinhBoNhiemChucVuInfo.IDDM_ChucVuBoNhiem = int.Parse("0" + cmbChucVuBoNhiem.EditValue);
            pNS_QuaTrinhBoNhiemChucVuInfo.LaChucVuKiemNhiem = chkLaKiemNhiem.Checked;
            pNS_QuaTrinhBoNhiemChucVuInfo.IDNS_MienNhiemTuChuc = 0;

        }

        private void grvGiaoVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvGiaoVien.DataRowCount > 0)
            {
                idxGV = grvGiaoVien.FocusedRowHandle;
                DataRow dr = grvGiaoVien.GetDataRow(idxGV);
                oBGiaoVien.ToInfo(ref pGiaoVienInfo, dr);
                drGiaoVien = grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle);
                LoadQuatrinhBoiDuong();
                ClearText();
                grvQuaTrinhBoNhiemChucVu_FocusedRowChanged(null, null);
                if (grvQuaTrinhBoNhiemChucVu.DataRowCount > 0)
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
                grdQuaTrinhBoNhiemChucVu.DataSource = null;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetGrvTrv(false);
            SetControl(false);
            SetButton(false);
            btnLuu.Enabled = true;
            dtpNgayHetHieuLuc.Enabled = true;
            edit = EDIT_MODE.THEM;
            ClearText();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetGrvTrv(false);
            SetControl(false);
            SetButton(false);
            btnLuu.Enabled = true;
            dtpNgayHetHieuLuc.Enabled = true;
            edit = EDIT_MODE.SUA;
            SetText();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    pNS_QuaTrinhBoNhiemChucVuInfo.NS_QuaTrinhBoNhiemChucVuID = int.Parse(drQuaTrinhBoNhiemChucVu[pNS_QuaTrinhBoNhiemChucVuInfo.strNS_QuaTrinhBoNhiemChucVuID].ToString());
                    oBQuaTrinhBoNhiemChucVu.Delete(pNS_QuaTrinhBoNhiemChucVuInfo);
                    // ghi log
                    GhiLog("Xóa quá trình bổ nhiệm chức vụ giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " số quyết định " + pNS_QuaTrinhBoNhiemChucVuInfo.SoQuyetDinh + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtQuaTrinhBoNhiemChucVu.Rows.Remove(drQuaTrinhBoNhiemChucVu);
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
                    pNS_QuaTrinhBoNhiemChucVuInfo.NS_QuaTrinhBoNhiemChucVuID = oBQuaTrinhBoNhiemChucVu.Add(pNS_QuaTrinhBoNhiemChucVuInfo);
                    GhiLog("Thêm quá trình bổ nhiệm chức vụ giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " số quyết định " + pNS_QuaTrinhBoNhiemChucVuInfo.SoQuyetDinh + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtQuaTrinhBoNhiemChucVu.NewRow();
                    oBQuaTrinhBoNhiemChucVu.ToDataRow(pNS_QuaTrinhBoNhiemChucVuInfo, ref drNew);
                    dtQuaTrinhBoNhiemChucVu.Rows.Add(drNew);
                }
                else
                {
                    pNS_QuaTrinhBoNhiemChucVuInfo.NS_QuaTrinhBoNhiemChucVuID = int.Parse(drQuaTrinhBoNhiemChucVu[pNS_QuaTrinhBoNhiemChucVuInfo.strNS_QuaTrinhBoNhiemChucVuID].ToString());
                    oBQuaTrinhBoNhiemChucVu.Update(pNS_QuaTrinhBoNhiemChucVuInfo);
                    GhiLog("Sửa quá trình bổ nhiệm chức vụ giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " số quyết định " + pNS_QuaTrinhBoNhiemChucVuInfo.SoQuyetDinh + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    oBQuaTrinhBoNhiemChucVu.ToDataRow(pNS_QuaTrinhBoNhiemChucVuInfo, ref drQuaTrinhBoNhiemChucVu);
                    SuaThanhCong();
                    btnHuy_Click(null, null);
                }
            }
            catch
            {
                ThongBaoLoi("Có lỗi trong quá trình thêm hoặc sửa hoặc ghi log.");
            }
            grvGiaoVien_FocusedRowChanged(null, null);
            ClearText();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetGrvTrv(true);
            dxErrorProvider.ClearErrors();
            SetControl(true);
            btnLuu.Enabled = false;
            dtpNgayHetHieuLuc.Enabled = false;
            grvQuaTrinhBoNhiemChucVu_FocusedRowChanged(null, null);
        }

        private void grvQuaTrinhBoNhiemChucVu_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvQuaTrinhBoNhiemChucVu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvQuaTrinhBoNhiemChucVu.FocusedRowHandle >= 0)
            {
                drQuaTrinhBoNhiemChucVu = grvQuaTrinhBoNhiemChucVu.GetDataRow(grvQuaTrinhBoNhiemChucVu.FocusedRowHandle);
                oBQuaTrinhBoNhiemChucVu.ToInfo(ref pNS_QuaTrinhBoNhiemChucVuInfo, drQuaTrinhBoNhiemChucVu);
                SetText();
            }
            if (grvQuaTrinhBoNhiemChucVu != null)
                if (grvQuaTrinhBoNhiemChucVu.DataRowCount > 0 && grvQuaTrinhBoNhiemChucVu.FocusedRowHandle >= 0)
                {
                    SetButton(true);
                    drQuaTrinhBoNhiemChucVu = grvQuaTrinhBoNhiemChucVu.GetDataRow(grvQuaTrinhBoNhiemChucVu.FocusedRowHandle);
                    return;
                }
            SetButton(false);
            btnThem.Enabled = true;
            drQuaTrinhBoNhiemChucVu = null;
        }

        private void cmbCapQuyetDinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmDMCapKhenThuong frm = new frmDMCapKhenThuong(null,null,this, null);
                frm.ShowDialog();
                if (IDDM_CapQuyetDinh > 0)
                {
                    cmbCapQuyetDinh.Properties.DataSource = LoadCapKhenThuong();
                    cmbCapQuyetDinh.EditValue = IDDM_CapQuyetDinh;
                    reposCapQuyetDinh.DataSource = LoadCapKhenThuong();
                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                cmbCapQuyetDinh.EditValue = null;
            }
        }

        private void cmbChucVuBoNhiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmDM_ChucVu frm = new frmDM_ChucVu(this);
                frm.ShowDialog();
                if (IDDM_ChucVu > 0)
                {
                    cmbChucVuBoNhiem.Properties.DataSource = LoadChucVu();
                    reposChucVu.DataSource = LoadChucVu();
                    cmbChucVuBoNhiem.EditValue = IDDM_ChucVu;

                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                cmbChucVuBoNhiem.EditValue = null;
            }
        }
    }
}