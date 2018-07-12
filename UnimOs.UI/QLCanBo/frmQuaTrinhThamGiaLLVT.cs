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
    public partial class frmQuaTrinhThamGiaLLVT : frmBase
    {
        private cBNS_DonVi oBDonVi;
        private NS_DonViInfo pDonViInfo;
        private cBNS_GiaoVien oBGiaoVien;
        public NS_GiaoVienInfo pGiaoVienInfo;
        public cBNS_QuaTrinhThamGiaLucLuongVuTrang oBQuaTrinhThamGiaLucLuongVuTrang;
        public NS_QuaTrinhThamGiaLucLuongVuTrangInfo pNS_QuaTrinhThamGiaLucLuongVuTrangInfo;
        private DataTable dtTree, dtGiaoVien, dtQuaTrinhThamGiaLucLuongVuTrang;
        DataRow drGiaoVien, drQuaTrinhThamGiaLucLuongVuTrang;
        private bool Loaded = false;
        private int idxGV;
        private EDIT_MODE edit;
        public int IDDM_QuanHam;

        public frmQuaTrinhThamGiaLLVT()
        {
            InitializeComponent();
            oBGiaoVien = new cBNS_GiaoVien();
            pGiaoVienInfo = new NS_GiaoVienInfo();
            pDonViInfo = new NS_DonViInfo();
            oBQuaTrinhThamGiaLucLuongVuTrang = new cBNS_QuaTrinhThamGiaLucLuongVuTrang();
            pNS_QuaTrinhThamGiaLucLuongVuTrangInfo = new NS_QuaTrinhThamGiaLucLuongVuTrangInfo();
            dtpDenNgay.Enabled = false;
            SetButton(false);
            btnThem.Enabled = true;
            SetControl(true);
            btnLuu.Enabled = false;
        }

        private void LoadQuaTrinhThamGiaLLVT()
        {
            dtQuaTrinhThamGiaLucLuongVuTrang = oBQuaTrinhThamGiaLucLuongVuTrang.GetBy_IDNS_GiaoVien(int.Parse(grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle)["NS_GiaoVienID"].ToString()));
            grdQuaTrinhThamGiaLLVT.DataSource = dtQuaTrinhThamGiaLucLuongVuTrang;
        }

        private void LoadCombo()
        {
            cmbQuanHam.Properties.DataSource = LoadQuanHam();
            reposQuanHam.DataSource = LoadQuanHam();
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
            dtpNgayNhapNgu.Properties.ReadOnly = mbool;
            txtDonVi.Properties.ReadOnly = mbool;
            txtChucVu.Properties.ReadOnly = mbool;
            cmbQuanHam.Properties.ReadOnly = mbool;
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
            grdQuaTrinhThamGiaLLVT.Enabled = status;
        }

        private void ClearText()
        {
            dtpNgayNhapNgu.EditValue = null;
            dtpDenNgay.Checked = false;
            txtDonVi.Text = "";
            txtChucVu.Text = "";
            cmbQuanHam.EditValue = null;
        }

        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (dtpNgayNhapNgu.EditValue == null)
            {
                dxErrorProvider.SetError(dtpNgayNhapNgu, "Ngày nhập ngũ không thể rỗng.");
                if (CtrlErr == null) CtrlErr = dtpNgayNhapNgu;
            }

            if (txtDonVi.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtDonVi, "Đơn vị không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtDonVi;
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
            if ("" + drQuaTrinhThamGiaLucLuongVuTrang[pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.strNgayNhapNgu] == "")
                dtpNgayNhapNgu.EditValue = null;
            else
            {
                dtpNgayNhapNgu.EditValue = drQuaTrinhThamGiaLucLuongVuTrang[pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.strNgayNhapNgu];
            }
            if ("" + drQuaTrinhThamGiaLucLuongVuTrang[pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.strNgayXuatNgu] == "" || (DateTime.Parse(drQuaTrinhThamGiaLucLuongVuTrang[pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.strNgayXuatNgu].ToString()).ToString("dd/MM/yyyy")) == "31/12/9999")
            {
                dtpDenNgay.Value = DateTime.Today;
                dtpDenNgay.Checked = false;
            }
            else
            {
                dtpDenNgay.Value = DateTime.Parse(drQuaTrinhThamGiaLucLuongVuTrang[pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.strNgayXuatNgu].ToString());
                dtpDenNgay.Checked = true;
            }
            txtDonVi.Text = "" + pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.DonVi;
            cmbQuanHam.EditValue = int.Parse("0" + pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.IDDM_QuanHam);
            txtChucVu.Text = "" + pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.ChucVu;
            dtpNgayNhapNgu.Focus();
        }

        private void GetpInfo()
        {
            pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.IDNS_GiaoVien = int.Parse(drGiaoVien[pGiaoVienInfo.strNS_GiaoVienID].ToString());
            if (dtpNgayNhapNgu.EditValue == null)
            {
                pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.NgayNhapNgu = DateTime.Parse("01/01/1900");
            }
            else
            {
                pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.NgayNhapNgu = DateTime.Parse(dtpNgayNhapNgu.EditValue.ToString());
            }
            pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.NgayXuatNgu = dtpDenNgay.Checked == false ? DateTime.ParseExact("31/12/9999", "dd/MM/yyyy", null) : dtpDenNgay.Value;
            pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.DonVi = txtDonVi.Text;
            pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.IDDM_QuanHam = int.Parse("0" + cmbQuanHam.EditValue);
            pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.ChucVu = txtChucVu.Text;
        }

        private void grvGiaoVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvGiaoVien.DataRowCount > 0)
            {
                idxGV = grvGiaoVien.FocusedRowHandle;
                DataRow dr = grvGiaoVien.GetDataRow(idxGV);
                oBGiaoVien.ToInfo(ref pGiaoVienInfo, dr);
                drGiaoVien = grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle);
                LoadQuaTrinhThamGiaLLVT();
                ClearText();
                grvQuaTrinhThamGiaLLVT_FocusedRowChanged(null, null);
                if (grvQuaTrinhThamGiaLLVT.DataRowCount > 0)
                {
                    SetButton(true);
                }
                else
                {
                    SetButton(false);
                    btnThem.Enabled = false;
                }
            }
            else
            {
                SetButton(false);
                btnThem.Enabled = true;
                grdQuaTrinhThamGiaLLVT.DataSource = null;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetGrvTrv(false);
            SetButton(false);
            dtpDenNgay.Enabled = true;
            SetControl(false);
            btnLuu.Enabled = true;
            edit = EDIT_MODE.THEM;
            ClearText();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetGrvTrv(false);
            SetButton(false);
            dtpDenNgay.Enabled = true;
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
                    pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.NS_QuaTrinhThamGiaLucLuongVuTrangID = int.Parse(drQuaTrinhThamGiaLucLuongVuTrang[pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.strNS_QuaTrinhThamGiaLucLuongVuTrangID].ToString());
                    oBQuaTrinhThamGiaLucLuongVuTrang.Delete(pNS_QuaTrinhThamGiaLucLuongVuTrangInfo);
                    // ghi log
                    GhiLog("Xóa quá trình tham gia LLVT giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " đơn vị tham gia " + pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.DonVi + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtQuaTrinhThamGiaLucLuongVuTrang.Rows.Remove(drQuaTrinhThamGiaLucLuongVuTrang);
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
                    pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.NS_QuaTrinhThamGiaLucLuongVuTrangID = oBQuaTrinhThamGiaLucLuongVuTrang.Add(pNS_QuaTrinhThamGiaLucLuongVuTrangInfo);
                    GhiLog("Thêm quá trình tham gia LLVT giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " đơn vị tham gia " + pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.DonVi + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtQuaTrinhThamGiaLucLuongVuTrang.NewRow();
                    oBQuaTrinhThamGiaLucLuongVuTrang.ToDataRow(pNS_QuaTrinhThamGiaLucLuongVuTrangInfo, ref drNew);
                    dtQuaTrinhThamGiaLucLuongVuTrang.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.NS_QuaTrinhThamGiaLucLuongVuTrangID = int.Parse(drQuaTrinhThamGiaLucLuongVuTrang[pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.strNS_QuaTrinhThamGiaLucLuongVuTrangID].ToString());
                    oBQuaTrinhThamGiaLucLuongVuTrang.Update(pNS_QuaTrinhThamGiaLucLuongVuTrangInfo);
                    GhiLog("Sửa quá trình tham gia LLVT giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " đơn vị tham gia " + pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.DonVi + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    oBQuaTrinhThamGiaLucLuongVuTrang.ToDataRow(pNS_QuaTrinhThamGiaLucLuongVuTrangInfo, ref drQuaTrinhThamGiaLucLuongVuTrang);
                    SuaThanhCong();
                    btnHuy_Click(null, null);
                }
                LoadQuaTrinhThamGiaLLVT();
            }
            catch
            {
                ThongBaoLoi("Có lỗi trong quá trình thêm hoặc sửa hoặc ghi log.");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetGrvTrv(true);
            dtpDenNgay.Enabled = false;
            dxErrorProvider.ClearErrors();
            SetControl(true);
            btnLuu.Enabled = false;
            grvQuaTrinhThamGiaLLVT_FocusedRowChanged(null, null);
        }

        private void grvQuaTrinhThamGiaLLVT_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvQuaTrinhThamGiaLLVT.FocusedRowHandle >= 0)
            {
                drQuaTrinhThamGiaLucLuongVuTrang = grvQuaTrinhThamGiaLLVT.GetDataRow(grvQuaTrinhThamGiaLLVT.FocusedRowHandle);
                oBQuaTrinhThamGiaLucLuongVuTrang.ToInfo(ref pNS_QuaTrinhThamGiaLucLuongVuTrangInfo, drQuaTrinhThamGiaLucLuongVuTrang);
                SetText();
            }
            if (grvQuaTrinhThamGiaLLVT != null)
                if (grvQuaTrinhThamGiaLLVT.DataRowCount > 0 && grvQuaTrinhThamGiaLLVT.FocusedRowHandle >= 0)
                {
                    SetButton(true);
                    drQuaTrinhThamGiaLucLuongVuTrang = grvQuaTrinhThamGiaLLVT.GetDataRow(grvQuaTrinhThamGiaLLVT.FocusedRowHandle);
                    return;
                }
            SetButton(false);
            btnThem.Enabled = true;
            drQuaTrinhThamGiaLucLuongVuTrang = null;
        }

        private void grvQuaTrinhThamGiaLLVT_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void frmQuaTrinhThamGiaLLVT_Load(object sender, EventArgs e)
        {
            LoadTreeView();
            Loaded = true;
            trvDonVi_FocusedNodeChanged(null, null);
            LoadCombo();
        }

        private void cmbQuanHam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmDM_QuanHam frm = new frmDM_QuanHam(this);
                frm.ShowDialog();
                if (IDDM_QuanHam > 0)
                {
                    cmbQuanHam.Properties.DataSource = LoadQuanHam();
                    reposQuanHam.DataSource = LoadQuanHam();
                    cmbQuanHam.EditValue = IDDM_QuanHam;

                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                cmbQuanHam.EditValue = null;
            }
        }
    }
}