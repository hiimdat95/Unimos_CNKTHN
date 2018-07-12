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
    public partial class frmQuaTrinhThamGiaTCCTXH : frmBase
    {
        private cBNS_DonVi oBDonVi;
        private NS_DonViInfo pDonViInfo;
        private cBNS_GiaoVien oBGiaoVien;
        public NS_GiaoVienInfo pGiaoVienInfo;
        public cBNS_QuaTrinhThamGiaToChucCTXH oBQuaTrinhThamGiaToChucCTXH;
        public NS_QuaTrinhThamGiaToChucCTXHInfo pNS_QuaTrinhThamGiaToChucCTXHInfo;
        private DataTable dtTree, dtGiaoVien, dtQuaTrinhThamGiaToChucCTXH;
        DataRow drGiaoVien, drQuaTrinhThamGiaToChucCTXH;
        private bool Loaded = false;
        private int idxGV;
        private EDIT_MODE edit;

        public frmQuaTrinhThamGiaTCCTXH()
        {
            InitializeComponent();
            oBGiaoVien = new cBNS_GiaoVien();
            pGiaoVienInfo = new NS_GiaoVienInfo();
            pDonViInfo = new NS_DonViInfo();
            oBQuaTrinhThamGiaToChucCTXH = new cBNS_QuaTrinhThamGiaToChucCTXH();
            pNS_QuaTrinhThamGiaToChucCTXHInfo = new NS_QuaTrinhThamGiaToChucCTXHInfo();
            SetButton(false);
            btnThem.Enabled = true;
            SetControl(true);
            btnLuu.Enabled = false;
        }

        private void LoadQuaTrinhThamGiaLLVT()
        {
            dtQuaTrinhThamGiaToChucCTXH = oBQuaTrinhThamGiaToChucCTXH.GetBy_IDNS_GiaoVien(int.Parse(grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle)["NS_GiaoVienID"].ToString()));
            grdQuaTrinhThamGiaTCCTXH.DataSource = dtQuaTrinhThamGiaToChucCTXH;
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
            dtpNgayThamGia.Properties.ReadOnly = mbool;
            txtTenToChuc.Properties.ReadOnly = mbool;
            txtCongViec.Properties.ReadOnly = mbool;
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
            grdQuaTrinhThamGiaTCCTXH.Enabled = status;
        }

        private void ClearText()
        {
            dtpNgayThamGia.EditValue = null;
            txtTenToChuc.Text = "";
            txtCongViec.Text = "";
        }

        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (dtpNgayThamGia.EditValue == null)
            {
                dxErrorProvider.SetError(dtpNgayThamGia, "Ngày tham gia không thể rỗng.");
                if (CtrlErr == null) CtrlErr = dtpNgayThamGia;
            }

            if (txtTenToChuc.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTenToChuc, "Tên tổ chức không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenToChuc;
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
            if ("" + drQuaTrinhThamGiaToChucCTXH[pNS_QuaTrinhThamGiaToChucCTXHInfo.strNgayThamGia] == "")
                dtpNgayThamGia.EditValue = null;
            else
            {
                dtpNgayThamGia.EditValue = drQuaTrinhThamGiaToChucCTXH[pNS_QuaTrinhThamGiaToChucCTXHInfo.strNgayThamGia];
            }
            txtTenToChuc.Text = "" + pNS_QuaTrinhThamGiaToChucCTXHInfo.TenToChuc;
            txtCongViec.Text = "" + pNS_QuaTrinhThamGiaToChucCTXHInfo.CongViec;
            dtpNgayThamGia.Focus();
        }

        private void GetpInfo()
        {
            pNS_QuaTrinhThamGiaToChucCTXHInfo.IDNS_GiaoVien = int.Parse(drGiaoVien[pGiaoVienInfo.strNS_GiaoVienID].ToString());
            if (dtpNgayThamGia.EditValue == null)
            {
                pNS_QuaTrinhThamGiaToChucCTXHInfo.NgayThamGia = DateTime.Parse("01/01/1900");
            }
            else
            {
                pNS_QuaTrinhThamGiaToChucCTXHInfo.NgayThamGia = DateTime.Parse(dtpNgayThamGia.EditValue.ToString());
            }
            pNS_QuaTrinhThamGiaToChucCTXHInfo.TenToChuc = txtTenToChuc.Text;
            pNS_QuaTrinhThamGiaToChucCTXHInfo.CongViec = txtCongViec.Text;
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
                grvQuaTrinhThamGiaTCCTXH_FocusedRowChanged(null, null);
                if (grvQuaTrinhThamGiaTCCTXH.DataRowCount > 0)
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
                grdQuaTrinhThamGiaTCCTXH.DataSource = null;
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
                    pNS_QuaTrinhThamGiaToChucCTXHInfo.NS_QuaTrinhThamGiaToChucCTXHID = int.Parse(drQuaTrinhThamGiaToChucCTXH[pNS_QuaTrinhThamGiaToChucCTXHInfo.strNS_QuaTrinhThamGiaToChucCTXHID].ToString());
                    oBQuaTrinhThamGiaToChucCTXH.Delete(pNS_QuaTrinhThamGiaToChucCTXHInfo);
                    // ghi log
                    GhiLog("Xóa quá trình tham gia TCCTXH giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " tổ chức tham gia " + pNS_QuaTrinhThamGiaToChucCTXHInfo.TenToChuc + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtQuaTrinhThamGiaToChucCTXH.Rows.Remove(drQuaTrinhThamGiaToChucCTXH);
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
                    pNS_QuaTrinhThamGiaToChucCTXHInfo.NS_QuaTrinhThamGiaToChucCTXHID = oBQuaTrinhThamGiaToChucCTXH.Add(pNS_QuaTrinhThamGiaToChucCTXHInfo);
                    GhiLog("Thêm quá trình tham gia TCCTXH giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " tổ chức tham gia " + pNS_QuaTrinhThamGiaToChucCTXHInfo.TenToChuc + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtQuaTrinhThamGiaToChucCTXH.NewRow();
                    oBQuaTrinhThamGiaToChucCTXH.ToDataRow(pNS_QuaTrinhThamGiaToChucCTXHInfo, ref drNew);
                    dtQuaTrinhThamGiaToChucCTXH.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pNS_QuaTrinhThamGiaToChucCTXHInfo.NS_QuaTrinhThamGiaToChucCTXHID = int.Parse(drQuaTrinhThamGiaToChucCTXH[pNS_QuaTrinhThamGiaToChucCTXHInfo.strNS_QuaTrinhThamGiaToChucCTXHID].ToString());
                    oBQuaTrinhThamGiaToChucCTXH.Update(pNS_QuaTrinhThamGiaToChucCTXHInfo);
                    GhiLog("Sửa quá trình tham gia TCCTXH giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " tổ chức tham gia " + pNS_QuaTrinhThamGiaToChucCTXHInfo.TenToChuc + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    oBQuaTrinhThamGiaToChucCTXH.ToDataRow(pNS_QuaTrinhThamGiaToChucCTXHInfo, ref drQuaTrinhThamGiaToChucCTXH);
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
            btnLuu.Enabled = false;
            grvQuaTrinhThamGiaTCCTXH_FocusedRowChanged(null, null);
        }

        private void grvQuaTrinhThamGiaTCCTXH_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvQuaTrinhThamGiaTCCTXH.FocusedRowHandle >= 0)
            {
                drQuaTrinhThamGiaToChucCTXH = grvQuaTrinhThamGiaTCCTXH.GetDataRow(grvQuaTrinhThamGiaTCCTXH.FocusedRowHandle);
                oBQuaTrinhThamGiaToChucCTXH.ToInfo(ref pNS_QuaTrinhThamGiaToChucCTXHInfo, drQuaTrinhThamGiaToChucCTXH);
                SetText();
            }
            if (grvQuaTrinhThamGiaTCCTXH != null)
                if (grvQuaTrinhThamGiaTCCTXH.DataRowCount > 0 && grvQuaTrinhThamGiaTCCTXH.FocusedRowHandle >= 0)
                {
                    SetButton(true);
                    drQuaTrinhThamGiaToChucCTXH = grvQuaTrinhThamGiaTCCTXH.GetDataRow(grvQuaTrinhThamGiaTCCTXH.FocusedRowHandle);
                    return;
                }
            SetButton(false);
            btnThem.Enabled = true;
            drQuaTrinhThamGiaToChucCTXH = null;
        }

        private void grvQuaTrinhThamGiaTCCTXH_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void frmQuaTrinhThamGiaTCCTXH_Load(object sender, EventArgs e)
        {
            LoadTreeView();
            Loaded = true;
            trvDonVi_FocusedNodeChanged(null, null);
        }
    }
}