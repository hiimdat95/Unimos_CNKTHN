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
    public partial class frmQuaTrinhMienNhiemTuChuc : frmBase
    {
        private cBNS_DonVi oBDonVi;
        private NS_DonViInfo pDonViInfo;
        private cBNS_GiaoVien oBGiaoVien;
        public NS_GiaoVienInfo pGiaoVienInfo;
        cBDM_ChucVu oBDM_ChucVu;
        public cBNS_QuaTrinhMienNhiemTuChuc oBQuaTrinhMienNhiemTuChuc;
        public NS_QuaTrinhMienNhiemTuChucInfo pNS_QuaTrinhMienNhiemTuChucInfo;
        private DataTable dtTree, dtGiaoVien, dtQuaTrinhMienNhiemTuChuc;
        DataRow drGiaoVien, drQuaTrinhMienNhiemTuChuc;
        private bool Loaded = false;
        private int idxGV;
        private EDIT_MODE edit;
        public int NS_QuaTrinhBoNhiemChucVuID = 0, NS_QuaTrinhBoNhiemChucVuID1 = 0;
        public int IDDM_CapQuyetDinh;

        public frmQuaTrinhMienNhiemTuChuc()
        {
            InitializeComponent();
            oBGiaoVien = new cBNS_GiaoVien();
            pGiaoVienInfo = new NS_GiaoVienInfo();
            pDonViInfo = new NS_DonViInfo();
            oBDM_ChucVu = new cBDM_ChucVu();
            oBQuaTrinhMienNhiemTuChuc = new cBNS_QuaTrinhMienNhiemTuChuc();
            pNS_QuaTrinhMienNhiemTuChucInfo = new NS_QuaTrinhMienNhiemTuChucInfo();
            SetButton(false);
            btnThem.Enabled = true;
            SetControl(true);
            btnLuu.Enabled = false;
        }

        private void LoadQuaTrinhMienNhiemTuChuc()
        {
            dtQuaTrinhMienNhiemTuChuc = oBQuaTrinhMienNhiemTuChuc.GetBy_IDNS_GiaoVien(int.Parse(grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle)["NS_GiaoVienID"].ToString()));
            grdQuaTrinhMienNhiemTuChuc.DataSource = dtQuaTrinhMienNhiemTuChuc;
        }

        private void LoadCombo()
        {
            cmbCapQuyetDinh.Properties.DataSource = LoadCapKhenThuong();
            reposChuVuBoNhiemMienNhiem.DataSource = LoadChucVu();
        }

        private void LoadChucVuBoNhiem(int IDNS_GiaoVien)
        {
            cmbMienNhiemChucVu.Properties.DataSource = oBDM_ChucVu.ChucVu_QuaTrinhBoNhiem_GetBy_IDNS_GiaoVien(IDNS_GiaoVien);
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
            dtpNgayRaQuyetDinh.Properties.ReadOnly = mbool;
            dtpNgayCoHieuLuc.Properties.ReadOnly = mbool;
            cmbCapQuyetDinh.Properties.ReadOnly = mbool;
            cmbMienNhiemChucVu.Properties.ReadOnly = mbool;
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
            grdQuaTrinhMienNhiemTuChuc.Enabled = status;
        }

        private void ClearText()
        {
            txtSoQuyetDinh.Text = "";
            dtpNgayRaQuyetDinh.EditValue = null;
            dtpNgayCoHieuLuc.EditValue = null;
            cmbCapQuyetDinh.EditValue = null;
            cmbMienNhiemChucVu.EditValue = null;
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
            if (dtpNgayRaQuyetDinh.EditValue == null)
            {
                dxErrorProvider.SetError(dtpNgayRaQuyetDinh, "Ngày ra quyết định không thể rỗng.");
                if (CtrlErr == null) CtrlErr = dtpNgayRaQuyetDinh;
            }
            if (dtpNgayCoHieuLuc.EditValue == null)
            {
                dxErrorProvider.SetError(dtpNgayCoHieuLuc, "Ngày có hiệu lực không thể rỗng.");
                if (CtrlErr == null) CtrlErr = dtpNgayCoHieuLuc;
            }
            if (cmbCapQuyetDinh.EditValue == null)
            {
                dxErrorProvider.SetError(cmbCapQuyetDinh, "Cấp quyết định không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbCapQuyetDinh;
            }
            if (cmbMienNhiemChucVu.EditValue == null)
            {
                dxErrorProvider.SetError(cmbMienNhiemChucVu, "Chức vụ miễn nhiệm không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbMienNhiemChucVu;
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
            txtSoQuyetDinh.Text = "" + pNS_QuaTrinhMienNhiemTuChucInfo.SoQuyetDinh;
            if ("" + drQuaTrinhMienNhiemTuChuc[pNS_QuaTrinhMienNhiemTuChucInfo.strNgayRaQuyetDinh] == "")
                dtpNgayRaQuyetDinh.EditValue = null;
            else
            {
                dtpNgayRaQuyetDinh.EditValue = drQuaTrinhMienNhiemTuChuc[pNS_QuaTrinhMienNhiemTuChucInfo.strNgayRaQuyetDinh];
            }
            if ("" + drQuaTrinhMienNhiemTuChuc[pNS_QuaTrinhMienNhiemTuChucInfo.strNgayCoHieuLuc] == "")
                dtpNgayCoHieuLuc.EditValue = null;
            else
            {
                dtpNgayCoHieuLuc.EditValue = drQuaTrinhMienNhiemTuChuc[pNS_QuaTrinhMienNhiemTuChucInfo.strNgayCoHieuLuc];
            }
            cmbCapQuyetDinh.EditValue = int.Parse("0" + pNS_QuaTrinhMienNhiemTuChucInfo.IDDM_CapQuyetDinh);
            cmbMienNhiemChucVu.EditValue = int.Parse("0" + grvQuaTrinhMienNhiemTuChuc.GetDataRow(grvQuaTrinhMienNhiemTuChuc.FocusedRowHandle)["NS_QuaTrinhBoNhiemChucVuID"]);
            txtSoQuyetDinh.Focus();
        }

        private void GetpInfo()
        {
            pNS_QuaTrinhMienNhiemTuChucInfo.IDNS_GiaoVien = int.Parse(drGiaoVien[pGiaoVienInfo.strNS_GiaoVienID].ToString());
            pNS_QuaTrinhMienNhiemTuChucInfo.SoQuyetDinh = txtSoQuyetDinh.Text;
            if (dtpNgayRaQuyetDinh.EditValue == null)
            {
                pNS_QuaTrinhMienNhiemTuChucInfo.NgayRaQuyetDinh = DateTime.Parse("01/01/1900");
            }
            else
            {
                pNS_QuaTrinhMienNhiemTuChucInfo.NgayRaQuyetDinh = DateTime.Parse(dtpNgayRaQuyetDinh.EditValue.ToString());
            }
            if (dtpNgayCoHieuLuc.EditValue == null)
            {
                pNS_QuaTrinhMienNhiemTuChucInfo.NgayCoHieuLuc = DateTime.Parse("01/01/1900");
            }
            else
            {
                pNS_QuaTrinhMienNhiemTuChucInfo.NgayCoHieuLuc = DateTime.Parse(dtpNgayCoHieuLuc.EditValue.ToString());
            }
            pNS_QuaTrinhMienNhiemTuChucInfo.IDDM_CapQuyetDinh = int.Parse("0" + cmbCapQuyetDinh.EditValue);
        }

        private void grvGiaoVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvGiaoVien.DataRowCount > 0)
            {
                idxGV = grvGiaoVien.FocusedRowHandle;
                LoadChucVuBoNhiem(int.Parse(grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle)["NS_GiaoVienID"].ToString()));
                DataRow dr = grvGiaoVien.GetDataRow(idxGV);
                oBGiaoVien.ToInfo(ref pGiaoVienInfo, dr);
                drGiaoVien = grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle);
                LoadQuaTrinhMienNhiemTuChuc();
                ClearText();
                grvQuaTrinhMienNhiemTuChuc_FocusedRowChanged(null, null);
                if (grvQuaTrinhMienNhiemTuChuc.DataRowCount > 0)
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
                grdQuaTrinhMienNhiemTuChuc.DataSource = null;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetGrvTrv(false);
            SetButton(false);
            SetControl(false);
            btnLuu.Enabled = true;
            edit = EDIT_MODE.THEM;
            ClearText();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetGrvTrv(false);
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
                    pNS_QuaTrinhMienNhiemTuChucInfo.NS_QuaTrinhMienNhiemTuChucID = int.Parse(drQuaTrinhMienNhiemTuChuc[pNS_QuaTrinhMienNhiemTuChucInfo.strNS_QuaTrinhMienNhiemTuChucID].ToString());
                    oBQuaTrinhMienNhiemTuChuc.Delete_QuaTrinhBoNhiemChucVu(pNS_QuaTrinhMienNhiemTuChucInfo, NS_QuaTrinhBoNhiemChucVuID);
                    // ghi log
                    GhiLog("Xóa quá trình miễn nhiệm từ chức giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " số quyết định " + pNS_QuaTrinhMienNhiemTuChucInfo.SoQuyetDinh + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtQuaTrinhMienNhiemTuChuc.Rows.Remove(drQuaTrinhMienNhiemTuChuc);
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
                    pNS_QuaTrinhMienNhiemTuChucInfo.NS_QuaTrinhMienNhiemTuChucID = oBQuaTrinhMienNhiemTuChuc.Add_QuaTrinhBoNhiemChucVu(pNS_QuaTrinhMienNhiemTuChucInfo, NS_QuaTrinhBoNhiemChucVuID1);
                    GhiLog("Thêm quá trình miễn nhiệm từ chức giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " số quyết định " + pNS_QuaTrinhMienNhiemTuChucInfo.SoQuyetDinh + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtQuaTrinhMienNhiemTuChuc.NewRow();
                    oBQuaTrinhMienNhiemTuChuc.ToDataRow(pNS_QuaTrinhMienNhiemTuChucInfo, ref drNew);
                    dtQuaTrinhMienNhiemTuChuc.Rows.Add(drNew);
                }
                else
                {
                    pNS_QuaTrinhMienNhiemTuChucInfo.NS_QuaTrinhMienNhiemTuChucID = int.Parse(drQuaTrinhMienNhiemTuChuc[pNS_QuaTrinhMienNhiemTuChucInfo.strNS_QuaTrinhMienNhiemTuChucID].ToString());
                    oBQuaTrinhMienNhiemTuChuc.Update_QuaTrinhBoNhiem(pNS_QuaTrinhMienNhiemTuChucInfo, NS_QuaTrinhBoNhiemChucVuID, NS_QuaTrinhBoNhiemChucVuID1);
                    GhiLog("Sửa quá trình miễn giảm từ chức giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " số quyết định " + pNS_QuaTrinhMienNhiemTuChucInfo.SoQuyetDinh + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    oBQuaTrinhMienNhiemTuChuc.ToDataRow(pNS_QuaTrinhMienNhiemTuChucInfo, ref drQuaTrinhMienNhiemTuChuc);
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
            grvQuaTrinhMienNhiemTuChuc_FocusedRowChanged(null, null);
        }

        private void frmQuaTrinhMienNhiemTuChuc_Load(object sender, EventArgs e)
        {
            LoadTreeView();
            Loaded = true;
            trvDonVi_FocusedNodeChanged(null, null);
            LoadCombo();
        }

        private void grvQuaTrinhMienNhiemTuChuc_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvQuaTrinhMienNhiemTuChuc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvQuaTrinhMienNhiemTuChuc.FocusedRowHandle >= 0)
            {
                drQuaTrinhMienNhiemTuChuc = grvQuaTrinhMienNhiemTuChuc.GetDataRow(grvQuaTrinhMienNhiemTuChuc.FocusedRowHandle);
                oBQuaTrinhMienNhiemTuChuc.ToInfo(ref pNS_QuaTrinhMienNhiemTuChucInfo, drQuaTrinhMienNhiemTuChuc);
                NS_QuaTrinhBoNhiemChucVuID = int.Parse("0" + grvQuaTrinhMienNhiemTuChuc.GetDataRow(grvQuaTrinhMienNhiemTuChuc.FocusedRowHandle)["NS_QuaTrinhBoNhiemChucVuID"]);
                SetText();
            }
            if (grvQuaTrinhMienNhiemTuChuc != null)
                if (grvQuaTrinhMienNhiemTuChuc.DataRowCount > 0 && grvQuaTrinhMienNhiemTuChuc.FocusedRowHandle >= 0)
                {
                    SetButton(true);
                    drQuaTrinhMienNhiemTuChuc = grvQuaTrinhMienNhiemTuChuc.GetDataRow(grvQuaTrinhMienNhiemTuChuc.FocusedRowHandle);
                    return;
                }
            SetButton(false);
            btnThem.Enabled = true;
            drQuaTrinhMienNhiemTuChuc = null;
        }

        private void cmbMienNhiemChucVu_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbMienNhiemChucVu.EditValue != null)
            {
                NS_QuaTrinhBoNhiemChucVuID1 = int.Parse("0" + cmbMienNhiemChucVu.EditValue);
            }
        }

        private void cmbCapQuyetDinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmDMCapKhenThuong frm = new frmDMCapKhenThuong(null, null, null, this);
                frm.ShowDialog();
                if (IDDM_CapQuyetDinh > 0)
                {
                    cmbCapQuyetDinh.Properties.DataSource = LoadCapKhenThuong();
                    cmbCapQuyetDinh.EditValue = IDDM_CapQuyetDinh;

                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                cmbCapQuyetDinh.EditValue = null;
            }
        }
    }
}