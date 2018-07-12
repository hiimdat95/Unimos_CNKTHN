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
    public partial class frmDMCapKhenThuong : frmBase
    {
        private cBDM_CapKhenThuong oBDM_CapKhenThuong;
        private DM_CapKhenThuongInfo pDM_CapKhenThuongInfo;
        private DataTable dtCapKhenThuong;
        private DataRow drCapKhenThuong;
        private EDIT_MODE edit;
        public frmQuaTrinhKhenThuong ofrmQuaTrinhKhenThuong;
        public frmQuaTrinhKyLuat ofmQuaTrinhKyLuat;
        public frmQuaTrinhBoNhiemChucVu ofrmQuaTrinhBoNhiemChucVu;
        public frmQuaTrinhMienNhiemTuChuc ofrmQuaTrinhMienNhiemTuChuc;

        public frmDMCapKhenThuong(frmQuaTrinhKhenThuong _frmQuaTrinhKhenThuong, frmQuaTrinhKyLuat _frmQuaTrinhKyLuat, frmQuaTrinhBoNhiemChucVu _frmQuaTrinhBoNhiemChucVu, frmQuaTrinhMienNhiemTuChuc _frmQuaTrinhMienNhiemTuChuc)
        {
            InitializeComponent();
            oBDM_CapKhenThuong = new cBDM_CapKhenThuong();
            pDM_CapKhenThuongInfo = new DM_CapKhenThuongInfo();
            SetControl(false);
            ofrmQuaTrinhKhenThuong = _frmQuaTrinhKhenThuong;
            ofmQuaTrinhKyLuat = _frmQuaTrinhKyLuat;
            ofrmQuaTrinhBoNhiemChucVu = _frmQuaTrinhBoNhiemChucVu;
            ofrmQuaTrinhMienNhiemTuChuc = _frmQuaTrinhMienNhiemTuChuc;
        }

        private void frmDMCapKhenThuong_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            dtCapKhenThuong = oBDM_CapKhenThuong.Get(pDM_CapKhenThuongInfo);
            grdCapKhenThuong.DataSource = dtCapKhenThuong;
        }

        private void SetControl(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }

        private void ClearText()
        {
            txtTenCapKhenThuong.Text = "";
            txtTenCapKhenThuong.Focus();
        }

        private void SetText()
        {
            txtTenCapKhenThuong.Text = drCapKhenThuong[pDM_CapKhenThuongInfo.strTenCapKhenThuong].ToString();
            txtTenCapKhenThuong.Focus();
        }

        private void GetpInfo()
        {
            pDM_CapKhenThuongInfo.TenCapKhenThuong = txtTenCapKhenThuong.Text;
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtTenCapKhenThuong.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTenCapKhenThuong, "Tên không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenCapKhenThuong;
            }

            if (CtrlErr != null)
            {
                CtrlErr.Focus();
                return false;
            }
            else
                return true;
        }

        private void grvCapKhenThuong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvCapKhenThuong.FocusedRowHandle >= 0)
            {
                drCapKhenThuong = grvCapKhenThuong.GetDataRow(grvCapKhenThuong.FocusedRowHandle);
                oBDM_CapKhenThuong.ToInfo(ref pDM_CapKhenThuongInfo, drCapKhenThuong);
                if (ofrmQuaTrinhKhenThuong != null)
                {
                    ofrmQuaTrinhKhenThuong.IDDM_CapKhenThuong = int.Parse(drCapKhenThuong[pDM_CapKhenThuongInfo.strDM_CapKhenThuongID].ToString());
                }
                if (ofmQuaTrinhKyLuat != null)
                {
                    ofmQuaTrinhKyLuat.IDDM_CapKyLuat = int.Parse(drCapKhenThuong[pDM_CapKhenThuongInfo.strDM_CapKhenThuongID].ToString());
                }
                if (ofrmQuaTrinhBoNhiemChucVu != null)
                {
                    ofrmQuaTrinhBoNhiemChucVu.IDDM_CapQuyetDinh = int.Parse(drCapKhenThuong[pDM_CapKhenThuongInfo.strDM_CapKhenThuongID].ToString());
                }
                if (ofrmQuaTrinhMienNhiemTuChuc != null)
                {
                    ofrmQuaTrinhMienNhiemTuChuc.IDDM_CapQuyetDinh = int.Parse(drCapKhenThuong[pDM_CapKhenThuongInfo.strDM_CapKhenThuongID].ToString());
                }
            }
            if (grvCapKhenThuong != null)
                if (grvCapKhenThuong.DataRowCount > 0 && grvCapKhenThuong.FocusedRowHandle >= 0)
                {
                    SetControl(true);
                    drCapKhenThuong = grvCapKhenThuong.GetDataRow(grvCapKhenThuong.FocusedRowHandle);
                    return;
                }
            SetControl(false);
            drCapKhenThuong = null;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdCapKhenThuong.Enabled = false;
            edit = EDIT_MODE.THEM;
            panelTop.Visible = true;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdCapKhenThuong.Enabled = false;
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
                    pDM_CapKhenThuongInfo.DM_CapKhenThuongID = int.Parse(drCapKhenThuong[pDM_CapKhenThuongInfo.strDM_CapKhenThuongID].ToString());
                    oBDM_CapKhenThuong.Delete(pDM_CapKhenThuongInfo);
                    // ghi log
                    GhiLog("Xóa cấp khen thưởng '" + pDM_CapKhenThuongInfo.TenCapKhenThuong + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtCapKhenThuong.Rows.Remove(drCapKhenThuong);
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
                    pDM_CapKhenThuongInfo.DM_CapKhenThuongID = oBDM_CapKhenThuong.Add(pDM_CapKhenThuongInfo);
                    GhiLog("Thêm cấp khen thưởng '" + pDM_CapKhenThuongInfo.TenCapKhenThuong + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtCapKhenThuong.NewRow();
                    oBDM_CapKhenThuong.ToDataRow(pDM_CapKhenThuongInfo, ref drNew);
                    dtCapKhenThuong.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pDM_CapKhenThuongInfo.DM_CapKhenThuongID = int.Parse(drCapKhenThuong[pDM_CapKhenThuongInfo.strDM_CapKhenThuongID].ToString());
                    oBDM_CapKhenThuong.Update(pDM_CapKhenThuongInfo);
                    GhiLog("Sửa cấp khen thưởng '" + pDM_CapKhenThuongInfo.TenCapKhenThuong + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    drCapKhenThuong[pDM_CapKhenThuongInfo.strTenCapKhenThuong] = txtTenCapKhenThuong.Text;
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
            grdCapKhenThuong.Enabled = true;
            panelTop.Visible = false;
        }

        private void grvCapKhenThuong_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }
    }
}