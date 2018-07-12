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
    public partial class frmQuaTrinhBoiDuong : frmBase
    {
        private cBNS_DonVi oBDonVi;
        private NS_DonViInfo pDonViInfo;
        private cBNS_GiaoVien oBGiaoVien;
        public NS_GiaoVienInfo pGiaoVienInfo;
        public cBNS_QuaTrinhBoiDuong oBQuaTrinhBoiDuong;
        public NS_QuaTrinhBoiDuongInfo pNS_QuaTrinhBoiDuongInfo;
        private DataTable dtTree, dtGiaoVien, dtQuaTrinhBoiDuong;
        DataRow drGiaoVien, drQuaTrinhBoiDuong;
        private bool Loaded = false;
        private int idxGV;
        private EDIT_MODE edit;
        public int IDDM_VanBangChungChi, IDDM_XepLoaiChungChi, IDDM_HinhThucDaoTao;

        public frmQuaTrinhBoiDuong()
        {
            InitializeComponent();
            oBGiaoVien = new cBNS_GiaoVien();
            pGiaoVienInfo = new NS_GiaoVienInfo();
            pDonViInfo = new NS_DonViInfo();
            oBQuaTrinhBoiDuong = new cBNS_QuaTrinhBoiDuong();
            pNS_QuaTrinhBoiDuongInfo = new NS_QuaTrinhBoiDuongInfo();
            SetButton(false);
            btnThem.Enabled = true;
            SetControl(true);
            dtpDenNgay.Enabled = false;
            dtpThoiHanTuNgay.Enabled = false;
            dtpThoiHanDenNgay.Enabled = false;
            btnLuu.Enabled = false;
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
            dtQuaTrinhBoiDuong = oBQuaTrinhBoiDuong.GetBy_IDNS_GiaoVien(int.Parse(grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle)["NS_GiaoVienID"].ToString()));
            grdQuaTrinhBoiDuong.DataSource = dtQuaTrinhBoiDuong;
        }

        private void LoadCombo()
        {
            cmbVanBangChungChi.Properties.DataSource = LoadVanBangChungChi();
            cmbXepLoai.Properties.DataSource = LoadXepLoaiChungChi();
            cmbHinhThucDaoTao.Properties.DataSource = LoadHinhThucDaoTao();
            reposVanBangChungChi.DataSource = LoadVanBangChungChi();
            reposXepLoaiChungChi.DataSource = LoadXepLoaiChungChi();
            reposHinhThucDaoTao.DataSource = LoadHinhThucDaoTao();
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
            txtNoiBoiDuong.Properties.ReadOnly = mbool;
            txtNoiDungBoiDuong.Properties.ReadOnly = mbool;
            dtpTuNgay.Properties.ReadOnly = mbool;
            cmbVanBangChungChi.Properties.ReadOnly = mbool;
            cmbXepLoai.Properties.ReadOnly = mbool;
            cmbHinhThucDaoTao.Properties.ReadOnly = mbool;
            chkCoThoiHan.Checked = false;
            chkCoThoiHan.Properties.ReadOnly = mbool;
            txtNoiBoiDuong.Focus();
        }

        private void SetButton(bool status)
        {
            btnThem.Enabled = status;
            btnSua.Enabled = status;
            btnXoa.Enabled = status;
        }

        private void SetGrdTrv(bool status)
        {
            trvDonVi.Enabled = status;
            grdGiaoVien.Enabled = status;
            grdQuaTrinhBoiDuong.Enabled = status;
        }

        private void ClearText()
        {
            txtNoiBoiDuong.Text = "";
            txtNoiDungBoiDuong.Text = "";
            dtpTuNgay.EditValue = null;
            dtpDenNgay.Checked = false;
            cmbVanBangChungChi.EditValue = null;
            cmbXepLoai.EditValue = null;
            cmbHinhThucDaoTao.EditValue = null;
            chkCoThoiHan.Checked = false;
            dtpThoiHanTuNgay.Checked = false;
            dtpThoiHanDenNgay.Checked = false;
        }

        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txtNoiBoiDuong.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtNoiBoiDuong, "Nơi bồi dưỡng không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtNoiBoiDuong;
            }
            if (dtpTuNgay.EditValue == null)
            {
                dxErrorProvider.SetError(dtpTuNgay, "Từ ngày không thể rỗng.");
                if (CtrlErr == null) CtrlErr = dtpTuNgay;
            }
            if (cmbVanBangChungChi.EditValue == null)
            {
                dxErrorProvider.SetError(cmbVanBangChungChi, "Văn bằng chứng chỉ không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbVanBangChungChi;
            }
            if (chkCoThoiHan.Checked == true)
            {
                if (dtpThoiHanTuNgay.Checked == false)
                {
                    dxErrorProvider.SetError(dtpThoiHanTuNgay, "Thời hạn từ ngày không thể rỗng.");
                    if (CtrlErr == null) CtrlErr = dtpThoiHanTuNgay;
                }
                if (dtpThoiHanDenNgay.Checked == false)
                {
                    dxErrorProvider.SetError(dtpThoiHanDenNgay, "Thời hạn đến ngày không thể rỗng.");
                    if (CtrlErr == null) CtrlErr = dtpThoiHanDenNgay;
                }
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
            txtNoiBoiDuong.Text = "" + pNS_QuaTrinhBoiDuongInfo.NoiBoiDuong;
            txtNoiDungBoiDuong.Text = "" + pNS_QuaTrinhBoiDuongInfo.NoiDungBoiDuong;
            if ("" + drQuaTrinhBoiDuong[pNS_QuaTrinhBoiDuongInfo.strTuNgay] == "")
                dtpTuNgay.EditValue = null;
            else
            {
                dtpTuNgay.EditValue = drQuaTrinhBoiDuong[pNS_QuaTrinhBoiDuongInfo.strTuNgay];
            }
            if ("" + drQuaTrinhBoiDuong[pNS_QuaTrinhBoiDuongInfo.strDenNgay] == "" || (DateTime.Parse(drQuaTrinhBoiDuong[pNS_QuaTrinhBoiDuongInfo.strDenNgay].ToString()).ToString("dd/MM/yyyy")) == "31/12/9999")
            {
                dtpDenNgay.Value = DateTime.Today;
                dtpDenNgay.Checked = false;
            }
            else
            {
                dtpDenNgay.Value = DateTime.Parse(drQuaTrinhBoiDuong[pNS_QuaTrinhBoiDuongInfo.strDenNgay].ToString());
                dtpDenNgay.Checked = true;
            }
            cmbVanBangChungChi.EditValue = int.Parse("0" + pNS_QuaTrinhBoiDuongInfo.IDDM_VanBangChungChi);
            cmbXepLoai.EditValue = int.Parse("0" + pNS_QuaTrinhBoiDuongInfo.IDDM_XepLoaiChungChi);
            cmbHinhThucDaoTao.EditValue = int.Parse("0" + pNS_QuaTrinhBoiDuongInfo.IDDM_HinhThucDaoTao);
            chkCoThoiHan.Checked = bool.Parse(pNS_QuaTrinhBoiDuongInfo.CoThoiHan.ToString());
            if ("" + drQuaTrinhBoiDuong[pNS_QuaTrinhBoiDuongInfo.strThoiHanTuNgay] == "")
            {
                dtpThoiHanTuNgay.Value = DateTime.Today;
                dtpThoiHanTuNgay.Checked = false;
            }
            else
            {
                dtpThoiHanTuNgay.Value = DateTime.Parse(drQuaTrinhBoiDuong[pNS_QuaTrinhBoiDuongInfo.strThoiHanTuNgay].ToString());
                dtpThoiHanTuNgay.Checked = true;
            }
            if ("" + drQuaTrinhBoiDuong[pNS_QuaTrinhBoiDuongInfo.strThoiHanDenNgay] == "")
            {
                dtpThoiHanDenNgay.Value = DateTime.Today;
                dtpThoiHanDenNgay.Checked = false;
            }
            else
            {
                dtpThoiHanDenNgay.Value = DateTime.Parse(drQuaTrinhBoiDuong[pNS_QuaTrinhBoiDuongInfo.strThoiHanDenNgay].ToString());
                dtpThoiHanDenNgay.Checked = true;
            }
            txtNoiBoiDuong.Focus();
        }

        private void GetpInfo()
        {
            pNS_QuaTrinhBoiDuongInfo.IDNS_GiaoVien = int.Parse(drGiaoVien[pGiaoVienInfo.strNS_GiaoVienID].ToString());
            pNS_QuaTrinhBoiDuongInfo.NoiBoiDuong = txtNoiBoiDuong.Text;
            pNS_QuaTrinhBoiDuongInfo.NoiDungBoiDuong = txtNoiDungBoiDuong.Text;
            if (dtpTuNgay.EditValue == null)
            {
                pNS_QuaTrinhBoiDuongInfo.TuNgay = DateTime.Parse("01/01/1900");
            }
            else
            {
                pNS_QuaTrinhBoiDuongInfo.TuNgay = DateTime.Parse(dtpTuNgay.EditValue.ToString());
            }
            pNS_QuaTrinhBoiDuongInfo.DenNgay = dtpDenNgay.Checked == false ? DateTime.ParseExact("31/12/9999", "dd/MM/yyyy", null) : dtpDenNgay.Value;
            pNS_QuaTrinhBoiDuongInfo.IDDM_VanBangChungChi = int.Parse("0" + cmbVanBangChungChi.EditValue);
            pNS_QuaTrinhBoiDuongInfo.IDDM_XepLoaiChungChi = int.Parse("0" + cmbXepLoai.EditValue);
            pNS_QuaTrinhBoiDuongInfo.IDDM_HinhThucDaoTao = int.Parse("0" + cmbHinhThucDaoTao.EditValue);
            pNS_QuaTrinhBoiDuongInfo.CoThoiHan = chkCoThoiHan.Checked;
            pNS_QuaTrinhBoiDuongInfo.ThoiHanTuNgay = dtpThoiHanTuNgay.Checked == false ? DateTime.Parse("01/01/1900") : dtpThoiHanTuNgay.Value;
            pNS_QuaTrinhBoiDuongInfo.ThoiHanDenNgay = dtpThoiHanDenNgay.Checked == false ? DateTime.Parse("01/01/1900") : dtpThoiHanDenNgay.Value;
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
                grvQuaTrinhBoiDuong_FocusedRowChanged(null, null);
                if (grvQuaTrinhBoiDuong.DataRowCount > 0)
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
                grdQuaTrinhBoiDuong.DataSource = null;
                SetButton(false);
                btnThem.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetGrdTrv(false);
            SetControl(false);
            SetButton(false);
            dtpDenNgay.Enabled = true;
            dtpThoiHanTuNgay.Enabled = true;
            dtpThoiHanDenNgay.Enabled = true;
            btnLuu.Enabled = true;
            edit = EDIT_MODE.THEM;
            ClearText();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetGrdTrv(false);
            SetControl(false);
            SetButton(false);
            dtpDenNgay.Enabled = true;
            dtpThoiHanTuNgay.Enabled = true;
            dtpThoiHanDenNgay.Enabled = true;
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
                    pNS_QuaTrinhBoiDuongInfo.NS_QuaTrinhBoiDuongID = int.Parse(drQuaTrinhBoiDuong[pNS_QuaTrinhBoiDuongInfo.strNS_QuaTrinhBoiDuongID].ToString());
                    oBQuaTrinhBoiDuong.Delete(pNS_QuaTrinhBoiDuongInfo);
                    // ghi log
                    GhiLog("Xóa quá trình bồi dưỡng giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " nơi bồi dưỡng " + pNS_QuaTrinhBoiDuongInfo.NoiBoiDuong + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtQuaTrinhBoiDuong.Rows.Remove(drQuaTrinhBoiDuong);
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
                    pNS_QuaTrinhBoiDuongInfo.NS_QuaTrinhBoiDuongID = oBQuaTrinhBoiDuong.Add(pNS_QuaTrinhBoiDuongInfo);
                    GhiLog("Thêm quá trình bồi dưỡng giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " nơi bồi dưỡng " + pNS_QuaTrinhBoiDuongInfo.NoiBoiDuong + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtQuaTrinhBoiDuong.NewRow();
                    oBQuaTrinhBoiDuong.ToDataRow(pNS_QuaTrinhBoiDuongInfo, ref drNew);
                    dtQuaTrinhBoiDuong.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pNS_QuaTrinhBoiDuongInfo.NS_QuaTrinhBoiDuongID = int.Parse(drQuaTrinhBoiDuong[pNS_QuaTrinhBoiDuongInfo.strNS_QuaTrinhBoiDuongID].ToString());
                    oBQuaTrinhBoiDuong.Update(pNS_QuaTrinhBoiDuongInfo);
                    GhiLog("Sửa quá trình bồi dưỡng giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " nơi bồi dưỡng " + pNS_QuaTrinhBoiDuongInfo.NoiBoiDuong + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    oBQuaTrinhBoiDuong.ToDataRow(pNS_QuaTrinhBoiDuongInfo, ref drQuaTrinhBoiDuong);
                    SuaThanhCong();
                    btnHuy_Click(null, null);
                }
                LoadQuatrinhBoiDuong();
            }
            catch
            {
                ThongBaoLoi("Có lỗi trong quá trình thêm hoặc sửa hoặc ghi log.");
            }
        }

        private void grvQuaTrinhBoiDuong_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvQuaTrinhBoiDuong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvQuaTrinhBoiDuong.FocusedRowHandle >= 0)
            {
                drQuaTrinhBoiDuong = grvQuaTrinhBoiDuong.GetDataRow(grvQuaTrinhBoiDuong.FocusedRowHandle);
                oBQuaTrinhBoiDuong.ToInfo(ref pNS_QuaTrinhBoiDuongInfo, drQuaTrinhBoiDuong);
                SetText();
            }
            if (grvQuaTrinhBoiDuong != null)
                if (grvQuaTrinhBoiDuong.DataRowCount > 0 && grvQuaTrinhBoiDuong.FocusedRowHandle >= 0)
                {
                    SetButton(true);
                    drQuaTrinhBoiDuong = grvQuaTrinhBoiDuong.GetDataRow(grvQuaTrinhBoiDuong.FocusedRowHandle);
                    return;
                }
            SetButton(false);
            btnThem.Enabled = true;
            drQuaTrinhBoiDuong = null;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetGrdTrv(true);
            dxErrorProvider.ClearErrors();
            SetControl(true);
            dtpDenNgay.Enabled = false;
            dtpThoiHanTuNgay.Enabled = false;
            dtpThoiHanDenNgay.Enabled = false;
            btnLuu.Enabled = false;
            grvQuaTrinhBoiDuong_FocusedRowChanged(null, null);
        }

        private void cmbVanBangChungChi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmDM_VanBangChungChi frm = new frmDM_VanBangChungChi(this);
                frm.ShowDialog();
                if (IDDM_VanBangChungChi > 0)
                {
                    cmbVanBangChungChi.Properties.DataSource = LoadVanBangChungChi();
                    reposVanBangChungChi.DataSource = LoadVanBangChungChi();
                    cmbVanBangChungChi.EditValue = IDDM_VanBangChungChi;

                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                cmbVanBangChungChi.EditValue = null;
            }
        }

        private void cmbXepLoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmDM_XepLoaiChungChi frm = new frmDM_XepLoaiChungChi(this);
                frm.ShowDialog();
                if (IDDM_XepLoaiChungChi > 0)
                {
                    cmbXepLoai.Properties.DataSource = LoadXepLoaiChungChi();
                    reposXepLoaiChungChi.DataSource = LoadXepLoaiChungChi();
                    cmbXepLoai.EditValue = IDDM_XepLoaiChungChi;
                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                cmbXepLoai.EditValue = null;
            }
        }

        private void cmbHinhThucDaoTao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmDM_HinhThucDaoTao frm = new frmDM_HinhThucDaoTao(this);
                frm.ShowDialog();
                if (IDDM_HinhThucDaoTao > 0)
                {
                    cmbHinhThucDaoTao.Properties.DataSource = LoadHinhThucDaoTao();
                    cmbHinhThucDaoTao.EditValue = IDDM_HinhThucDaoTao;
                    reposHinhThucDaoTao.DataSource = LoadHinhThucDaoTao();
                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                cmbHinhThucDaoTao.EditValue = null;
            }
        }

    }
}