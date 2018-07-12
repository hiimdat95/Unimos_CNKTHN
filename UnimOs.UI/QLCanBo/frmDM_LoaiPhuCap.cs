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
    public partial class frmDM_LoaiPhuCap : frmBase
    {
        private cBNS_LoaiPhuCap cBNS_LoaiPhuCap;
        private NS_LoaiPhuCapInfo pNS_LoaiPhuCapInfo;
        private DataTable dtLoaiPhuCap;
        private DataRow drLoaiPhuCap;
        private EDIT_MODE edit;
        public frmPhuCap ofrmPhuCap;

        public frmDM_LoaiPhuCap(frmPhuCap _frmPhuCap)
        {
            InitializeComponent();
            cBNS_LoaiPhuCap = new cBNS_LoaiPhuCap();
            pNS_LoaiPhuCapInfo = new NS_LoaiPhuCapInfo();
            SetControl(false);
            ofrmPhuCap = _frmPhuCap;
        }

        private void GetLoaiPhuCap()
        {
            pNS_LoaiPhuCapInfo.NS_LoaiPhuCapID = 0;
            dtLoaiPhuCap = cBNS_LoaiPhuCap.Get(pNS_LoaiPhuCapInfo);
            grdLoaiPhuCap.DataSource = dtLoaiPhuCap;
        }

        private void SetControl(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }

        private void ClearText()
        {
            txtKyHieu.Text = "";
            txtTenLoaiPhuCap.Text = "";
            chkLaPhuCapChucVu.Checked = false;
            chkBHXH.Checked = false;
            txtKyHieu.Focus();
        }
        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txtKyHieu.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtKyHieu, "Ký hiệu không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtKyHieu;
            }
            if (txtTenLoaiPhuCap.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTenLoaiPhuCap, "Tên loại phụ cấp không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenLoaiPhuCap;
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
            txtKyHieu.Text = "" + pNS_LoaiPhuCapInfo.KyHieu;
            txtTenLoaiPhuCap.Text = "" + pNS_LoaiPhuCapInfo.TenLoaiPhuCap;
            chkLaPhuCapChucVu.Checked = bool.Parse(pNS_LoaiPhuCapInfo.LaPhuCapChucVu.ToString());
            chkBHXH.Checked = bool.Parse(pNS_LoaiPhuCapInfo.BHXH.ToString());
            txtKyHieu.Focus();
        }

        private void GetpInfo()
        {
            pNS_LoaiPhuCapInfo.KyHieu= txtKyHieu.Text;
            pNS_LoaiPhuCapInfo.TenLoaiPhuCap = txtTenLoaiPhuCap.Text;
            pNS_LoaiPhuCapInfo.LaPhuCapChucVu = chkLaPhuCapChucVu.Checked;
            pNS_LoaiPhuCapInfo.BHXH = chkBHXH.Checked;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdLoaiPhuCap.Enabled = false;
            edit = EDIT_MODE.THEM;
            panelTop.Visible = true;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdLoaiPhuCap.Enabled = false;
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
                    pNS_LoaiPhuCapInfo.NS_LoaiPhuCapID = int.Parse(drLoaiPhuCap[pNS_LoaiPhuCapInfo.strNS_LoaiPhuCapID].ToString());
                    cBNS_LoaiPhuCap.Delete(pNS_LoaiPhuCapInfo);
                    // ghi log
                    GhiLog("Xóa loại phụ cấp '" + pNS_LoaiPhuCapInfo.TenLoaiPhuCap + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtLoaiPhuCap.Rows.Remove(drLoaiPhuCap);
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
                    pNS_LoaiPhuCapInfo.NS_LoaiPhuCapID = cBNS_LoaiPhuCap.Add(pNS_LoaiPhuCapInfo);
                    GhiLog("Thêm loại phụ cấp '" + pNS_LoaiPhuCapInfo.TenLoaiPhuCap + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtLoaiPhuCap.NewRow();
                    cBNS_LoaiPhuCap.ToDataRow(pNS_LoaiPhuCapInfo, ref drNew);
                    dtLoaiPhuCap.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pNS_LoaiPhuCapInfo.NS_LoaiPhuCapID = int.Parse(drLoaiPhuCap[pNS_LoaiPhuCapInfo.strNS_LoaiPhuCapID].ToString());
                    cBNS_LoaiPhuCap.Update(pNS_LoaiPhuCapInfo);
                    GhiLog("Sửa loại phụ cấp '" + pNS_LoaiPhuCapInfo.TenLoaiPhuCap + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    cBNS_LoaiPhuCap.ToDataRow(pNS_LoaiPhuCapInfo, ref drLoaiPhuCap);
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
            grdLoaiPhuCap.Enabled = true;
            dxErrorProvider.ClearErrors();
            panelTop.Visible = false;
        }

        private void grvLoaiPhuCap_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvLoaiPhuCap.FocusedRowHandle >= 0)
            {
                drLoaiPhuCap = grvLoaiPhuCap.GetDataRow(grvLoaiPhuCap.FocusedRowHandle);
                cBNS_LoaiPhuCap.ToInfo(ref pNS_LoaiPhuCapInfo, drLoaiPhuCap);
                if (ofrmPhuCap != null)
                {
                    ofrmPhuCap.IDNS_LoaiPhuCap = int.Parse(drLoaiPhuCap[pNS_LoaiPhuCapInfo.strNS_LoaiPhuCapID].ToString());
                }
            }
            if (grvLoaiPhuCap != null)
                if (grvLoaiPhuCap.DataRowCount > 0 && grvLoaiPhuCap.FocusedRowHandle >= 0)
                {
                    SetControl(true);
                    drLoaiPhuCap = grvLoaiPhuCap.GetDataRow(grvLoaiPhuCap.FocusedRowHandle);
                    return;
                }
            SetControl(false);
            drLoaiPhuCap = null;
        }

        private void grvLoaiPhuCap_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void frmDM_LoaiPhuCap_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            GetLoaiPhuCap();
        }
    }
}