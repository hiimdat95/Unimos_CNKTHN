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
    public partial class frmPhuCap : frmBase
    {
        private cBNS_DonVi oBDonVi;
        private NS_DonViInfo pDonViInfo;
        private cBNS_GiaoVien oBGiaoVien;
        public NS_GiaoVienInfo pGiaoVienInfo;
        public cBNS_PhuCap oBPhuCap;
        public NS_PhuCapInfo pNS_PhuCapInfo;
        private DataTable dtTree, dtGiaoVien, dtPhuCap;
        DataRow drGiaoVien, drPhuCap;
        private bool Loaded = false;
        private int idxGV;
        private EDIT_MODE edit;
        public int IDNS_LoaiPhuCap;

        public frmPhuCap()
        {
            InitializeComponent();
            oBGiaoVien = new cBNS_GiaoVien();
            pGiaoVienInfo = new NS_GiaoVienInfo();
            pDonViInfo = new NS_DonViInfo();
            oBPhuCap = new cBNS_PhuCap();
            pNS_PhuCapInfo = new NS_PhuCapInfo();
            SetButton(false);
            btnThem.Enabled = true;
            SetControl(true);
            dtpDenNgay.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void LoadPhuCap()
        {
            dtPhuCap = oBPhuCap.GetBy_IDNS_GiaoVien(int.Parse(grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle)["NS_GiaoVienID"].ToString()));
            grdPhuCap.DataSource = dtPhuCap;
        }

        private void LoadCombo()
        {
            cmbLoaiPhuCap.Properties.DataSource = LoadLoaiPhuCap();
            reposLoaiPhuCap.DataSource = LoadLoaiPhuCap();
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
            cmbLoaiPhuCap.Properties.ReadOnly = mbool;
            txtHeSoPhuCap.Properties.ReadOnly = mbool;
            txtPhanTramHuong.Properties.ReadOnly = mbool;
            dtpTuNgay.Properties.ReadOnly = mbool;
            chkTinhBHXH.Checked = false;
            chkTinhBHXH.Properties.ReadOnly = mbool;
            cmbLoaiPhuCap.Focus();
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
            grdPhuCap.Enabled = status;
        }

        private void ClearText()
        {
            cmbLoaiPhuCap.EditValue = null;
            txtHeSoPhuCap.Text = "";
            dtpTuNgay.EditValue = null;
            dtpDenNgay.Checked = false;
            chkTinhBHXH.Checked = false;
        }

        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (cmbLoaiPhuCap.EditValue == null)
            {
                dxErrorProvider.SetError(cmbLoaiPhuCap, "Loại phụ cấp không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbLoaiPhuCap;
            }
            if (txtHeSoPhuCap.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtHeSoPhuCap, "Hệ số phụ cấp không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtHeSoPhuCap;
            }
            if (dtpTuNgay.EditValue == null)
            {
                dxErrorProvider.SetError(dtpTuNgay, "Từ ngày không thể rỗng.");
                if (CtrlErr == null) CtrlErr = dtpTuNgay;
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
            txtHeSoPhuCap.Text = pNS_PhuCapInfo.HeSoPhuCap.ToString();
            txtPhanTramHuong.Text = pNS_PhuCapInfo.PhanTramHuong.ToString();
            if ("" + drPhuCap[pNS_PhuCapInfo.strPhuCapTuNgay] == "")
                dtpTuNgay.EditValue = null;
            else
            {
                dtpTuNgay.EditValue = drPhuCap[pNS_PhuCapInfo.strPhuCapTuNgay];
            }
            if ("" + drPhuCap[pNS_PhuCapInfo.strPhuCapDenNgay] == "" || (DateTime.Parse(drPhuCap[pNS_PhuCapInfo.strPhuCapDenNgay].ToString()).ToString("dd/MM/yyyy")) == "31/12/9999")
            {
                dtpDenNgay.Value = DateTime.Today;
                dtpDenNgay.Checked = false;
            }
            else
            {
                dtpDenNgay.Value = DateTime.Parse(drPhuCap[pNS_PhuCapInfo.strPhuCapDenNgay].ToString());
                dtpDenNgay.Checked = true;
            }
            cmbLoaiPhuCap.EditValue = int.Parse("0" + pNS_PhuCapInfo.IDNS_LoaiPhuCap);
            chkTinhBHXH.Checked = bool.Parse(pNS_PhuCapInfo.TinhBHXH.ToString());
            cmbLoaiPhuCap.Focus();
        }

        private void GetpInfo()
        {
            pNS_PhuCapInfo.IDNS_GiaoVien = int.Parse(drGiaoVien[pGiaoVienInfo.strNS_GiaoVienID].ToString());
            pNS_PhuCapInfo.HeSoPhuCap = double.Parse("0" + txtHeSoPhuCap.Text);
            pNS_PhuCapInfo.PhanTramHuong = double.Parse("0" + txtPhanTramHuong.Text);
            if (dtpTuNgay.EditValue == null)
            {
                pNS_PhuCapInfo.PhuCapTuNgay = DateTime.Parse("01/01/1900");
            }
            else
            {
                pNS_PhuCapInfo.PhuCapTuNgay = DateTime.Parse(dtpTuNgay.EditValue.ToString());
            }
            pNS_PhuCapInfo.PhuCapDenNgay = dtpDenNgay.Checked == false ? DateTime.ParseExact("31/12/9999", "dd/MM/yyyy", null) : dtpDenNgay.Value;
            pNS_PhuCapInfo.IDNS_LoaiPhuCap = int.Parse("0" + cmbLoaiPhuCap.EditValue);
            pNS_PhuCapInfo.TinhBHXH = chkTinhBHXH.Checked;
        }

        private void grvGiaoVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvGiaoVien.DataRowCount > 0)
            {
                idxGV = grvGiaoVien.FocusedRowHandle;
                DataRow dr = grvGiaoVien.GetDataRow(idxGV);
                oBGiaoVien.ToInfo(ref pGiaoVienInfo, dr);
                drGiaoVien = grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle);
                LoadPhuCap();
                ClearText();
                grvPhuCap_FocusedRowChanged(null, null);
                if (grvPhuCap.DataRowCount > 0)
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
                grdPhuCap.DataSource = null;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetGrvTrv(false);
            SetButton(false);
            SetControl(false);
            dtpDenNgay.Enabled = true;
            btnLuu.Enabled = true;
            edit = EDIT_MODE.THEM;
            ClearText();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetGrvTrv(false);
            SetButton(false);
            SetControl(false);
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
                    pNS_PhuCapInfo.NS_PhuCapID = int.Parse(drPhuCap[pNS_PhuCapInfo.strNS_PhuCapID].ToString());
                    oBPhuCap.Delete(pNS_PhuCapInfo);
                    // ghi log
                    GhiLog("Xóa phụ cấp giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " hệ số phụ cấp " + pNS_PhuCapInfo.HeSoPhuCap + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtPhuCap.Rows.Remove(drPhuCap);
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
                    DataRow[] arrDr = dtPhuCap.Select("IDNS_LoaiPhuCap = " + pNS_PhuCapInfo.IDNS_LoaiPhuCap.ToString() + " AND PhuCapTuNgay <= '" + pNS_PhuCapInfo.PhuCapTuNgay.ToString("MM/dd/yyyy") + "' AND PhuCapDenNgay>='" + pNS_PhuCapInfo.PhuCapTuNgay.ToString("MM/dd/yyyy") + "'");
                    if (arrDr.Length > 0)
                    {
                        ThongBaoLoi("Đã có loại phụ cấp tương tự chưa cập nhật thông tin đến ngày.\nHoặc từ ngày của loại phụ cấp này nằm trong khoảng từ ngày và đến ngày của loại phụ cấp tương tự trong quá trình loại phụ cấp này.\n Đề nghị kiểm tra và cập nhật lại thông tin quá trình phụ cấp.");
                        return;
                    }
                    pNS_PhuCapInfo.NS_PhuCapID = oBPhuCap.Add(pNS_PhuCapInfo);
                    GhiLog("Thêm phụ cấp giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " hệ số phụ cấp " + pNS_PhuCapInfo.HeSoPhuCap + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    drPhuCap = dtPhuCap.NewRow();
                    oBPhuCap.ToDataRow(pNS_PhuCapInfo, ref drPhuCap);
                    dtPhuCap.Rows.Add(drPhuCap);
                    ClearText();
                }
                else
                {
                    DataRow[] arrDr = dtPhuCap.Select("NS_PhuCapID<> " + drPhuCap[pNS_PhuCapInfo.strNS_PhuCapID].ToString() + " AND IDNS_LoaiPhuCap = " + pNS_PhuCapInfo.IDNS_LoaiPhuCap.ToString() + " AND PhuCapTuNgay <= '" + pNS_PhuCapInfo.PhuCapTuNgay.ToString("MM/dd/yyyy") + "' AND PhuCapDenNgay>='" + pNS_PhuCapInfo.PhuCapTuNgay.ToString("MM/dd/yyyy") + "'");
                    if (arrDr.Length > 0)
                    {
                        ThongBaoLoi("Đã có loại phụ cấp tương tự chưa cập nhật thông tin đến ngày.\nHoặc từ ngày của loại phụ cấp này nằm trong khoảng từ ngày và đến ngày của loại phụ cấp tương tự trong quá trình loại phụ cấp này.\n Đề nghị kiểm tra và cập nhật lại thông tin quá trình phụ cấp.");
                        return;
                    }
                    pNS_PhuCapInfo.NS_PhuCapID = int.Parse(drPhuCap[pNS_PhuCapInfo.strNS_PhuCapID].ToString());
                    oBPhuCap.Update(pNS_PhuCapInfo);
                    GhiLog("Sửa phụ cấp giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " hệ số phụ cấp " + pNS_PhuCapInfo.HeSoPhuCap + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    oBPhuCap.ToDataRow(pNS_PhuCapInfo, ref drPhuCap);
                    SuaThanhCong();
                    btnHuy_Click(null, null);
                }
                LoadPhuCap();
            }
            catch (Exception ex)
            {
                ThongBaoLoi("Có lỗi trong quá trình thêm hoặc sửa hoặc ghi log.\n Thông báo lỗi như sau: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetGrvTrv(true);
            SetButton(true);
            dxErrorProvider.ClearErrors();
            SetControl(true);
            dtpDenNgay.Enabled = false;
            btnLuu.Enabled = false;
            grvPhuCap_FocusedRowChanged(null, null);
        }

        private void frmPhuCap_Load(object sender, EventArgs e)
        {
            LoadTreeView();
            Loaded = true;
            trvDonVi_FocusedNodeChanged(null, null);
            LoadCombo();
        }

        private void grvPhuCap_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvPhuCap.FocusedRowHandle >= 0)
            {
                drPhuCap = grvPhuCap.GetDataRow(grvPhuCap.FocusedRowHandle);
                oBPhuCap.ToInfo(ref pNS_PhuCapInfo, drPhuCap);
                SetText();
            }
            if (grvPhuCap != null)
                if (grvPhuCap.DataRowCount > 0 && grvPhuCap.FocusedRowHandle >= 0)
                {
                    SetButton(true);
                    drPhuCap = grvPhuCap.GetDataRow(grvPhuCap.FocusedRowHandle);
                    return;
                }
            SetButton(false);
            btnThem.Enabled = true;
            drPhuCap = null;
        }

        private void grvPhuCap_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void cmbLoaiPhuCap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmDM_LoaiPhuCap frm = new frmDM_LoaiPhuCap(this);
                frm.ShowDialog();
                if (IDNS_LoaiPhuCap > 0)
                {
                    cmbLoaiPhuCap.Properties.DataSource = LoadLoaiPhuCap();
                    reposLoaiPhuCap.DataSource = LoadLoaiPhuCap();
                    cmbLoaiPhuCap.EditValue = IDNS_LoaiPhuCap;

                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                cmbLoaiPhuCap.EditValue = null;
            }
        }
    }
}