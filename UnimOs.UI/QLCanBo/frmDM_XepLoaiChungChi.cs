using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;

namespace UnimOs.UI
{
    public partial class frmDM_XepLoaiChungChi : frmBase
    {
        private cBDM_XepLoaiChungChi oBDM_XepLoaiChungChi;
        private DM_XepLoaiChungChiInfo pDM_XepLoaiChungChiInfo;
        private DataTable dtXepLoaiChungChi;
        private DataRow drXepLoaiChungChi;
        private EDIT_MODE edit;
        public frmQuaTrinhBoiDuong ofrmQuaTrinhBoiDuong;

        public frmDM_XepLoaiChungChi(frmQuaTrinhBoiDuong _frmQuaTrinhBoiDuong)
        {
            InitializeComponent();
            oBDM_XepLoaiChungChi = new cBDM_XepLoaiChungChi();
            pDM_XepLoaiChungChiInfo = new DM_XepLoaiChungChiInfo();
            SetControl(false);
            ofrmQuaTrinhBoiDuong = _frmQuaTrinhBoiDuong;
        }

        private void GetXepLoaiChungChi()
        {
            pDM_XepLoaiChungChiInfo.DM_XepLoaiChungChiID = 0;
            dtXepLoaiChungChi = oBDM_XepLoaiChungChi.Get(pDM_XepLoaiChungChiInfo);
            grdXepLoaiChungChi.DataSource = dtXepLoaiChungChi;
        }

        private void SetControl(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }

        private void ClearText()
        {
            txtTenXepLoaiChungChi.Text = "";
            txtTenXepLoaiChungChi.Focus();
        }
        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txtTenXepLoaiChungChi.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTenXepLoaiChungChi, "Tên xếp loại chứng chỉ không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenXepLoaiChungChi;
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
            txtTenXepLoaiChungChi.Text = pDM_XepLoaiChungChiInfo.TenXepLoaiChungChi;
            txtTenXepLoaiChungChi.Focus();
        }

        private void GetpInfo()
        {
            pDM_XepLoaiChungChiInfo.TenXepLoaiChungChi = txtTenXepLoaiChungChi.Text;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdXepLoaiChungChi.Enabled = false;
            edit = EDIT_MODE.THEM;
            panelTop.Visible = true;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdXepLoaiChungChi.Enabled = false;
            edit = EDIT_MODE.SUA;
            panelTop.Visible = true;
            SetText();
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    pDM_XepLoaiChungChiInfo.DM_XepLoaiChungChiID = int.Parse(drXepLoaiChungChi[pDM_XepLoaiChungChiInfo.strDM_XepLoaiChungChiID].ToString());
                    oBDM_XepLoaiChungChi.Delete(pDM_XepLoaiChungChiInfo);
                    // ghi log
                    GhiLog("Xóa xếp loại chứng chỉ '" + pDM_XepLoaiChungChiInfo.TenXepLoaiChungChi + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtXepLoaiChungChi.Rows.Remove(drXepLoaiChungChi);
                    XoaThanhCong();
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckValid()) return;
            try
            {
                GetpInfo();
                if (edit == EDIT_MODE.THEM)
                {
                    pDM_XepLoaiChungChiInfo.DM_XepLoaiChungChiID = oBDM_XepLoaiChungChi.Add(pDM_XepLoaiChungChiInfo);
                    GhiLog("Thêm xếp loại chứng chỉ '" + pDM_XepLoaiChungChiInfo.TenXepLoaiChungChi + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtXepLoaiChungChi.NewRow();
                    oBDM_XepLoaiChungChi.ToDataRow(pDM_XepLoaiChungChiInfo, ref drNew);
                    dtXepLoaiChungChi.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pDM_XepLoaiChungChiInfo.DM_XepLoaiChungChiID = int.Parse(drXepLoaiChungChi[pDM_XepLoaiChungChiInfo.strDM_XepLoaiChungChiID].ToString());
                    oBDM_XepLoaiChungChi.Update(pDM_XepLoaiChungChiInfo);
                    GhiLog("Sửa xếp loại chứng chỉ '" + pDM_XepLoaiChungChiInfo.TenXepLoaiChungChi + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    drXepLoaiChungChi[pDM_XepLoaiChungChiInfo.strTenXepLoaiChungChi] = txtTenXepLoaiChungChi.Text;
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
            grdXepLoaiChungChi.Enabled = true;
            dxErrorProvider.ClearErrors();
            panelTop.Visible = false;
        }

        private void grvXepLoaiChungChi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvXepLoaiChungChi.FocusedRowHandle >= 0)
            {
                drXepLoaiChungChi = grvXepLoaiChungChi.GetDataRow(grvXepLoaiChungChi.FocusedRowHandle);
                oBDM_XepLoaiChungChi.ToInfo(ref pDM_XepLoaiChungChiInfo, drXepLoaiChungChi);
                if (ofrmQuaTrinhBoiDuong != null)
                {
                    ofrmQuaTrinhBoiDuong.IDDM_XepLoaiChungChi = int.Parse(drXepLoaiChungChi[pDM_XepLoaiChungChiInfo.strDM_XepLoaiChungChiID].ToString());
                }
            }
            if (grvXepLoaiChungChi != null)
                if (grvXepLoaiChungChi.DataRowCount > 0 && grvXepLoaiChungChi.FocusedRowHandle >= 0)
                {
                    SetControl(true);
                    drXepLoaiChungChi = grvXepLoaiChungChi.GetDataRow(grvXepLoaiChungChi.FocusedRowHandle);
                    return;
                }
            SetControl(false);
            drXepLoaiChungChi = null;
        }

        private void grvXepLoaiChungChi_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void frmDM_XepLoaiChungChi_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            GetXepLoaiChungChi();
        }
    }
}