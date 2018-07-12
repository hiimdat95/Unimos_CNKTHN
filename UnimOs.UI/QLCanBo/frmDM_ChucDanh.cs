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
    public partial class frmDM_ChucDanh : frmBase
    {
        private cBDM_ChucDanh oBDM_ChucDanh;
        private DM_ChucDanhInfo pDM_ChucDanhInfo;
        private DataTable dtChucDanh;
        private DataRow drChucDanh;
        private EDIT_MODE edit;
        public frmHoSoGiaoVien ofrmHoSoGiaoVien;

        public frmDM_ChucDanh(frmHoSoGiaoVien _frmHoSoGiaoVien)
        {
            InitializeComponent();
            oBDM_ChucDanh = new cBDM_ChucDanh();
            pDM_ChucDanhInfo = new DM_ChucDanhInfo();
            SetControl(false);
            ofrmHoSoGiaoVien = _frmHoSoGiaoVien;
        }

        private void GetChucDanh()
        {
            pDM_ChucDanhInfo.DM_ChucDanhID = 0;
            dtChucDanh = oBDM_ChucDanh.Get(pDM_ChucDanhInfo);
            grdChucDanh.DataSource = dtChucDanh;
        }

        private void SetControl(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }

        private void frmDM_ChucDanh_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            GetChucDanh();
        }

        private void ClearText()
        {
            txtTenChucDanh.Text = "";
            txtTenChucDanh.Focus();
        }
        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txtTenChucDanh.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTenChucDanh, "Tên chức danh không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenChucDanh;
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
            txtTenChucDanh.Text = pDM_ChucDanhInfo.TenChucDanh;
            txtTenChucDanh.Focus();
        }

        private void GetpInfo()
        {
            pDM_ChucDanhInfo.TenChucDanh= txtTenChucDanh.Text;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdChucDanh.Enabled = false;
            edit = EDIT_MODE.THEM;
            panelTop.Visible = true;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdChucDanh.Enabled = false;
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
                    pDM_ChucDanhInfo.DM_ChucDanhID = int.Parse(drChucDanh[pDM_ChucDanhInfo.strDM_ChucDanhID].ToString());
                    oBDM_ChucDanh.Delete(pDM_ChucDanhInfo);
                    // ghi log
                    GhiLog("Xóa chức danh '" + pDM_ChucDanhInfo.TenChucDanh + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtChucDanh.Rows.Remove(drChucDanh);
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
                    pDM_ChucDanhInfo.DM_ChucDanhID = oBDM_ChucDanh.Add(pDM_ChucDanhInfo);
                    GhiLog("Thêm chức danh '" + pDM_ChucDanhInfo.TenChucDanh + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtChucDanh.NewRow();
                    oBDM_ChucDanh.ToDataRow(pDM_ChucDanhInfo, ref drNew);
                    dtChucDanh.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pDM_ChucDanhInfo.DM_ChucDanhID = int.Parse(drChucDanh[pDM_ChucDanhInfo.strDM_ChucDanhID].ToString());
                    oBDM_ChucDanh.Update(pDM_ChucDanhInfo);
                    GhiLog("Sửa chức danh '" + pDM_ChucDanhInfo.TenChucDanh + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    drChucDanh[pDM_ChucDanhInfo.strTenChucDanh] = txtTenChucDanh.Text;
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
            grdChucDanh.Enabled = true;
            dxErrorProvider.ClearErrors();
            panelTop.Visible = false;
        }

        private void grvChucDanh_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvChucDanh_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvChucDanh.FocusedRowHandle >= 0)
            {
                drChucDanh = grvChucDanh.GetDataRow(grvChucDanh.FocusedRowHandle);
                oBDM_ChucDanh.ToInfo(ref pDM_ChucDanhInfo, drChucDanh);
                if (ofrmHoSoGiaoVien != null)
                {
                    ofrmHoSoGiaoVien.IDDM_ChucDanh = int.Parse(drChucDanh[pDM_ChucDanhInfo.strDM_ChucDanhID].ToString());
                }
            }
            if (grvChucDanh != null)
                if (grvChucDanh.DataRowCount > 0 && grvChucDanh.FocusedRowHandle >= 0)
                {
                    SetControl(true);
                    drChucDanh = grvChucDanh.GetDataRow(grvChucDanh.FocusedRowHandle);
                    return;
                }
            SetControl(false);
            drChucDanh = null;
        }
    }
}