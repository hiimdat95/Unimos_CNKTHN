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
    public partial class frmQuaTrinhCongTac : frmBase
    {
        private cBNS_DonVi oBDonVi;
        private NS_DonViInfo pDonViInfo;
        private cBNS_GiaoVien oBGiaoVien;
        public NS_GiaoVienInfo pGiaoVienInfo;
        public cBNS_QuaTrinhCongTac oBQuaTrinhCongTac;
        public NS_QuaTrinhCongTacInfo pNS_QuaTrinhCongTacInfo;
        private DataTable dtTree, dtGiaoVien, dtQuaTrinhCongTac;
        DataRow drGiaoVien, drQuaTrinhCongTac;
        private bool Loaded = false;
        private int idxGV;
        private EDIT_MODE edit;
        public int IDDM_QuocTich;

        public frmQuaTrinhCongTac()
        {
            InitializeComponent();
            oBGiaoVien = new cBNS_GiaoVien();
            pGiaoVienInfo = new NS_GiaoVienInfo();
            pDonViInfo = new NS_DonViInfo();
            oBQuaTrinhCongTac = new cBNS_QuaTrinhCongTac();
            pNS_QuaTrinhCongTacInfo = new NS_QuaTrinhCongTacInfo();
            SetButton(false);
            btnThem.Enabled = true;
            SetControl(true);
            btnLuu.Enabled = false;
            dtpDenNgay.Enabled = false;
        }

        private void frmQuaTrinhBoiDuong_Load(object sender, EventArgs e)
        {
            LoadTreeView();
            Loaded = true;
            trvDonVi_FocusedNodeChanged(null, null);
            LoadCombo();
        }

        private void LoadQuaTrinhCongTac()
        {
            dtQuaTrinhCongTac = oBQuaTrinhCongTac.GetBy_IDNS_GiaoVien(int.Parse(grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle)["NS_GiaoVienID"].ToString()));
            grdQuaTrinhCongTac.DataSource = dtQuaTrinhCongTac;
        }

        private void LoadCombo()
        {
            cmbQuocTich.Properties.DataSource = LoadQuocTich();
            reposQuocTich.DataSource = LoadQuocTich();
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
            txtNoiCongTac.Properties.ReadOnly = mbool;
            txtNoiDungCongTac.Properties.ReadOnly = mbool;
            txtChucVuDamNhiem.Properties.ReadOnly = mbool;
            dtpTuNgay.Properties.ReadOnly = mbool;
            cmbQuocTich.Properties.ReadOnly = mbool;
            chkDiNuocNgoai.Checked = false;
            chkDiNuocNgoai.Properties.ReadOnly = mbool;
            txtNoiCongTac.Focus();
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
            grdQuaTrinhCongTac.Enabled = status;
        }

        private void ClearText()
        {
            txtNoiCongTac.Text = "";
            txtNoiDungCongTac.Text = "";
            txtChucVuDamNhiem.Text = "";
            dtpTuNgay.EditValue = null;
            dtpDenNgay.Checked = false;
            cmbQuocTich.EditValue = null;
            chkDiNuocNgoai.Checked = false;
        }

        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txtNoiCongTac.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtNoiCongTac, "Nơi bồi dưỡng không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtNoiCongTac;
            }
            if (dtpTuNgay.EditValue == null)
            {
                dxErrorProvider.SetError(dtpTuNgay, "Từ ngày không thể rỗng.");
                if (CtrlErr == null) CtrlErr = dtpTuNgay;
            }
            if (chkDiNuocNgoai.Checked == true)
            {
                if (cmbQuocTich.EditValue == null)
                {
                    dxErrorProvider.SetError(cmbQuocTich, "Quốc gia đến không thể rỗng.");
                    if (CtrlErr == null) CtrlErr = cmbQuocTich;
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
            txtNoiCongTac.Text = "" + pNS_QuaTrinhCongTacInfo.NoiCongTac;
            txtNoiDungCongTac.Text = "" + pNS_QuaTrinhCongTacInfo.NoiDungCongTac;
            txtChucVuDamNhiem.Text = "" + pNS_QuaTrinhCongTacInfo.ChucVuDamNhiem;
            if ("" + drQuaTrinhCongTac[pNS_QuaTrinhCongTacInfo.strTuNgay] == "")
                dtpTuNgay.EditValue = null;
            else
            {
                dtpTuNgay.EditValue = drQuaTrinhCongTac[pNS_QuaTrinhCongTacInfo.strTuNgay];
            }
            if ("" + drQuaTrinhCongTac[pNS_QuaTrinhCongTacInfo.strDenNgay] == "" || (DateTime.Parse(drQuaTrinhCongTac[pNS_QuaTrinhCongTacInfo.strDenNgay].ToString()).ToString("dd/MM/yyyy")) == "31/12/9999")
            {
                dtpDenNgay.Value = DateTime.Today;
                dtpDenNgay.Checked = false;
            }
            else
            {
                dtpDenNgay.Value = DateTime.Parse(drQuaTrinhCongTac[pNS_QuaTrinhCongTacInfo.strDenNgay].ToString());
                dtpDenNgay.Checked = true;
            }
            chkDiNuocNgoai.Checked = bool.Parse(pNS_QuaTrinhCongTacInfo.DiNuocNgoai.ToString());
            cmbQuocTich.EditValue = int.Parse("0" + pNS_QuaTrinhCongTacInfo.IDDM_QuocTich);
            txtNoiCongTac.Focus();
        }

        private void GetpInfo()
        {
            pNS_QuaTrinhCongTacInfo.IDNS_GiaoVien = int.Parse(drGiaoVien[pGiaoVienInfo.strNS_GiaoVienID].ToString());
            pNS_QuaTrinhCongTacInfo.NoiCongTac = txtNoiCongTac.Text;
            pNS_QuaTrinhCongTacInfo.NoiDungCongTac = txtNoiDungCongTac.Text;
            pNS_QuaTrinhCongTacInfo.ChucVuDamNhiem = txtChucVuDamNhiem.Text;
            if (dtpTuNgay.EditValue == null)
            {
                pNS_QuaTrinhCongTacInfo.TuNgay = DateTime.Parse("01/01/1900");
            }
            else
            {
                pNS_QuaTrinhCongTacInfo.TuNgay = DateTime.Parse(dtpTuNgay.EditValue.ToString());
            }
            pNS_QuaTrinhCongTacInfo.DenNgay = dtpDenNgay.Checked == false ? DateTime.ParseExact("31/12/9999", "dd/MM/yyyy", null) : dtpDenNgay.Value;
            pNS_QuaTrinhCongTacInfo.DiNuocNgoai = chkDiNuocNgoai.Checked;
            pNS_QuaTrinhCongTacInfo.IDDM_QuocTich = int.Parse("0" + cmbQuocTich.EditValue);
        }

        private void grvGiaoVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvGiaoVien.DataRowCount > 0)
            {
                idxGV = grvGiaoVien.FocusedRowHandle;
                DataRow dr = grvGiaoVien.GetDataRow(idxGV);
                oBGiaoVien.ToInfo(ref pGiaoVienInfo, dr);
                drGiaoVien = grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle);
                LoadQuaTrinhCongTac();
                ClearText();
                grvQuaTrinhCongTac_FocusedRowChanged(null, null);
                if (grvQuaTrinhCongTac.DataRowCount > 0)
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
                grdQuaTrinhCongTac.DataSource = null;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetGrvTrv(false);
            SetControl(false);
            SetButton(false);
            dtpDenNgay.Enabled = true;
            btnLuu.Enabled = true;
            edit = EDIT_MODE.THEM;
            ClearText();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetGrvTrv(false);
            SetControl(false);
            SetButton(false);
            dtpDenNgay.Enabled = true;
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
                    pNS_QuaTrinhCongTacInfo.NS_QuaTrinhCongTacID = int.Parse(drQuaTrinhCongTac[pNS_QuaTrinhCongTacInfo.strNS_QuaTrinhCongTacID].ToString());
                    oBQuaTrinhCongTac.Delete(pNS_QuaTrinhCongTacInfo);
                    // ghi log
                    GhiLog("Xóa quá trình công tác giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " nơi công tác " + pNS_QuaTrinhCongTacInfo.NoiCongTac + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtQuaTrinhCongTac.Rows.Remove(drQuaTrinhCongTac);
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
                    pNS_QuaTrinhCongTacInfo.NS_QuaTrinhCongTacID = oBQuaTrinhCongTac.Add(pNS_QuaTrinhCongTacInfo);
                    GhiLog("Thêm quá trình công tác giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " nơi bồi dưỡng " + pNS_QuaTrinhCongTacInfo.NoiCongTac + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    drQuaTrinhCongTac = dtQuaTrinhCongTac.NewRow();
                    oBQuaTrinhCongTac.ToDataRow(pNS_QuaTrinhCongTacInfo, ref drQuaTrinhCongTac);
                    dtQuaTrinhCongTac.Rows.Add(drQuaTrinhCongTac);
                    ClearText();
                }
                else
                {
                    pNS_QuaTrinhCongTacInfo.NS_QuaTrinhCongTacID = int.Parse(drQuaTrinhCongTac[pNS_QuaTrinhCongTacInfo.strNS_QuaTrinhCongTacID].ToString());
                    oBQuaTrinhCongTac.Update(pNS_QuaTrinhCongTacInfo);
                    GhiLog("Sửa quá trình công tác giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " nơi bồi dưỡng " + pNS_QuaTrinhCongTacInfo.NoiCongTac + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    oBQuaTrinhCongTac.ToDataRow(pNS_QuaTrinhCongTacInfo, ref drQuaTrinhCongTac);
                    SuaThanhCong();
                    btnHuy_Click(null, null);
                }
                LoadQuaTrinhCongTac();
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
            dtpDenNgay.Enabled = false;
            SetControl(true);
            btnLuu.Enabled = false;
            grvQuaTrinhCongTac_FocusedRowChanged(null, null);
        }

        private void grvQuaTrinhCongTac_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvQuaTrinhCongTac_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvQuaTrinhCongTac.FocusedRowHandle >= 0)
            {
                drQuaTrinhCongTac = grvQuaTrinhCongTac.GetDataRow(grvQuaTrinhCongTac.FocusedRowHandle);
                oBQuaTrinhCongTac.ToInfo(ref pNS_QuaTrinhCongTacInfo, drQuaTrinhCongTac);
                SetText();
            }
            if (grvQuaTrinhCongTac != null)
                if (grvQuaTrinhCongTac.DataRowCount > 0 && grvQuaTrinhCongTac.FocusedRowHandle >= 0)
                {
                    SetButton(true);
                    drQuaTrinhCongTac = grvQuaTrinhCongTac.GetDataRow(grvQuaTrinhCongTac.FocusedRowHandle);
                    return;
                }
            SetButton(false);
            btnThem.Enabled = true;
            drQuaTrinhCongTac = null;
        }

        private void cmbQuocTich_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmDM_QuocTich frm = new frmDM_QuocTich(this);
                frm.ShowDialog();
                if (IDDM_QuocTich > 0)
                {
                    cmbQuocTich.Properties.DataSource = LoadQuocTich();
                    reposQuocTich.DataSource = LoadQuocTich();
                    cmbQuocTich.EditValue = IDDM_QuocTich;

                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                cmbQuocTich.EditValue = null;
            }
        }
    }
}