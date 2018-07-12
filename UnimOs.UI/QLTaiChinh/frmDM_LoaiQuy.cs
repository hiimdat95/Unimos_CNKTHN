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
    public partial class frmDM_LoaiQuy : frmBase
    {
        private int status;
        private cBDM_LoaiQuy oBDM_LoaiQuy;
        private DM_LoaiQuyInfo pDM_LoaiQuyInfo;
        private DataTable dtLoaiQuy;
        private DataRow drLoaiQuy;

        public frmDM_LoaiQuy()
        {
            InitializeComponent();
            pDM_LoaiQuyInfo = new DM_LoaiQuyInfo();
            oBDM_LoaiQuy = new cBDM_LoaiQuy();
        }

        private void frmDM_LoaiQuy_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            GetLoaiQuy();
        }
        private void GetLoaiQuy()
        {
            pDM_LoaiQuyInfo.DM_LoaiQuyID = 0;
            dtLoaiQuy = oBDM_LoaiQuy.Get(pDM_LoaiQuyInfo);
            grdLoaiQuy.DataSource = dtLoaiQuy;
        }
        private void ClearText()
        {
            txtTenLoaiQuy.Text = "";
            txtGhiChu.Text = "";
            txtTenLoaiQuy.Focus();
        }
        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txtTenLoaiQuy.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTenLoaiQuy, "Tên loại quỹ không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenLoaiQuy;
            }
           
            //Kiểm tra cập nhật thành công
            if ((CtrlErr != null))
                return false;
            else
                return true;
        }
        private void GetInfo()
        {
            txtTenLoaiQuy.Text = pDM_LoaiQuyInfo.TenLoaiQuy;
            txtGhiChu.Text = pDM_LoaiQuyInfo.GhiChu;
        }

        private void SetInfo()
        {
            pDM_LoaiQuyInfo.TenLoaiQuy= txtTenLoaiQuy.Text;
            pDM_LoaiQuyInfo.GhiChu = txtGhiChu.Text;
        }

        private void grvLoaiQuy_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvLoaiQuy_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvLoaiQuy.FocusedRowHandle >= 0)
            {
                drLoaiQuy = grvLoaiQuy.GetDataRow(grvLoaiQuy.FocusedRowHandle);
                oBDM_LoaiQuy.ToInfo(ref pDM_LoaiQuyInfo, drLoaiQuy);
            }
        }
        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearText();
            panelTop.Visible = true;
            txtTenLoaiQuy.Focus();
            status = 0;
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            status = 1;
            panelTop.Visible = true;
            GetInfo();
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                grvLoaiQuy_FocusedRowChanged(null, null);
                try
                {
                    oBDM_LoaiQuy.Delete(pDM_LoaiQuyInfo);
                    GetLoaiQuy();
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
            if (!Check_Valid()) return;
            try
            {
                SetInfo();
                if (status == 0)
                {
                    int mLoaiQuyID = oBDM_LoaiQuy.Add(pDM_LoaiQuyInfo);
                    drLoaiQuy = dtLoaiQuy.NewRow();
                    oBDM_LoaiQuy.ToDataRow(pDM_LoaiQuyInfo, ref drLoaiQuy);
                    drLoaiQuy["DM_LoaiQuyID"] = mLoaiQuyID;
                    dtLoaiQuy.Rows.Add(drLoaiQuy);
                    ThemThanhCong();
                   
                }
                else
                {

                    oBDM_LoaiQuy.Update(pDM_LoaiQuyInfo);
                    drLoaiQuy[pDM_LoaiQuyInfo.strGhiChu] = pDM_LoaiQuyInfo.GhiChu;
                    drLoaiQuy[pDM_LoaiQuyInfo.strTenLoaiQuy] = pDM_LoaiQuyInfo.TenLoaiQuy;
                    SuaThanhCong();
                    panelTop.Visible = false;
                }
                ClearText();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dxErrorProvider.ClearErrors();
            panelTop.Visible = false;
        }

    }
}