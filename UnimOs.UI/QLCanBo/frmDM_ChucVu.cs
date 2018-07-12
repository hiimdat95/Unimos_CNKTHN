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
    public partial class frmDM_ChucVu : frmBase
    {
        private cBDM_ChucVu oBDM_ChucVu;
        private DM_ChucVuInfo pDM_ChucVuInfo;
        private DataTable dtChucVu;
        private DataRow drChucVu;
        private EDIT_MODE edit;
        public frmQuaTrinhBoNhiemChucVu ofrmQuaTrinhBoNhiemChucVu;

        public frmDM_ChucVu(frmQuaTrinhBoNhiemChucVu _frmQuaTrinhBoNhiemChucVu)
        {
            InitializeComponent();
            oBDM_ChucVu = new cBDM_ChucVu();
            pDM_ChucVuInfo = new DM_ChucVuInfo();
            SetControl(false);
            ofrmQuaTrinhBoNhiemChucVu = _frmQuaTrinhBoNhiemChucVu;
        }

        private void GetChucVu()
        {
            pDM_ChucVuInfo.DM_ChucVuID = 0;
            dtChucVu = oBDM_ChucVu.Get(pDM_ChucVuInfo);
            grdChucVu.DataSource = dtChucVu;
        }

        private void SetControl(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }

        private void ClearText()
        {
            txtTenChucVu.Text = "";
            rdLoaiVienChuc.EditValue = null;
            txtSoTietGiam.EditValue = null;
            txtPhanTramGiam.EditValue = null;
            txtTenChucVu.Focus();
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txtTenChucVu.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTenChucVu, "Tên chức vụ không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenChucVu;
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
            txtTenChucVu.Text = pDM_ChucVuInfo.TenChucVu;
            rdLoaiVienChuc.EditValue = pDM_ChucVuInfo.IDLoaiVienChuc;
            txtSoTietGiam.EditValue = pDM_ChucVuInfo.SoGioGiam;
            txtPhanTramGiam.EditValue = pDM_ChucVuInfo.PhanTramGioGiam;
            txtTenChucVu.Focus();
        }

        private void GetpInfo()
        {
            pDM_ChucVuInfo.TenChucVu= txtTenChucVu.Text;
            pDM_ChucVuInfo.IDLoaiVienChuc = "" + rdLoaiVienChuc.EditValue;
            pDM_ChucVuInfo.SoGioGiam = int.Parse(txtSoTietGiam.Text);
            pDM_ChucVuInfo.PhanTramGioGiam = double.Parse(txtPhanTramGiam.Text);
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdChucVu.Enabled = false;
            edit = EDIT_MODE.THEM;
            panelTop.Visible = true;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdChucVu.Enabled = false;
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
                    pDM_ChucVuInfo.DM_ChucVuID = int.Parse(drChucVu[pDM_ChucVuInfo.strDM_ChucVuID].ToString());
                    oBDM_ChucVu.Delete(pDM_ChucVuInfo);
                    dtChucVu.Rows.Remove(drChucVu);
                    // ghi log
                    GhiLog("Xóa chức vụ '" + pDM_ChucVuInfo.TenChucVu + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
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
                    pDM_ChucVuInfo.DM_ChucVuID = oBDM_ChucVu.Add(pDM_ChucVuInfo);
                    DataRow drNew = dtChucVu.NewRow();
                    oBDM_ChucVu.ToDataRow(pDM_ChucVuInfo, ref drNew);
                    dtChucVu.Rows.Add(drNew);
                    GhiLog("Thêm chức vụ '" + pDM_ChucVuInfo.TenChucVu + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    ClearText();
                }
                else
                {
                    pDM_ChucVuInfo.DM_ChucVuID = int.Parse(drChucVu[pDM_ChucVuInfo.strDM_ChucVuID].ToString());
                    oBDM_ChucVu.Update(pDM_ChucVuInfo);
                    drChucVu[pDM_ChucVuInfo.strTenChucVu] = txtTenChucVu.Text;
                    GhiLog("Sửa chức vụ '" + pDM_ChucVuInfo.TenChucVu + "' trong CSDL ", "Sửa", this.Tag.ToString());
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
            grdChucVu.Enabled = true;
            dxErrorProvider.ClearErrors();
            panelTop.Visible = false;
        }

        private void grvChucVu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvChucVu.FocusedRowHandle >= 0)
            {
                drChucVu = grvChucVu.GetDataRow(grvChucVu.FocusedRowHandle);
                oBDM_ChucVu.ToInfo(ref pDM_ChucVuInfo, drChucVu);
                if (ofrmQuaTrinhBoNhiemChucVu != null)
                {
                    ofrmQuaTrinhBoNhiemChucVu.IDDM_ChucVu = int.Parse(drChucVu[pDM_ChucVuInfo.strDM_ChucVuID].ToString());
                }
            }
            if (grvChucVu != null)
                if (grvChucVu.DataRowCount > 0 && grvChucVu.FocusedRowHandle >= 0)
                {
                    SetControl(true);
                    drChucVu = grvChucVu.GetDataRow(grvChucVu.FocusedRowHandle);
                    return;
                }
            SetControl(false);
            drChucVu = null;
        }

        private void grvChucVu_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void frmDM_ChucVu_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            GetChucVu();
        }

        private void rdLoaiVienChuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                rdLoaiVienChuc.EditValue = null;
            }
        }
    }
}