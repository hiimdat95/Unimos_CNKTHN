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
    public partial class frmThanhTichKhenThuong : frmBase
    {
        private int status;
        private cBDM_LoaiKhenThuong oBDM_LoaiKhenThuong;
        private DM_LoaiKhenThuongInfo pDM_LoaiKhenThuongInfo;
        private cBXL_MonHocTrongKy oBXL_MonHocTrongKy;
        private DataTable dtLoaiKhenThuong;
        private DataRow drLoaiKhenThuong;

        public frmThanhTichKhenThuong()
        {
            InitializeComponent();
            pDM_LoaiKhenThuongInfo = new DM_LoaiKhenThuongInfo();
            oBDM_LoaiKhenThuong = new cBDM_LoaiKhenThuong();
            oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();
        }

        private void frmThanhTichKhenThuong_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            GetLoaiKhenThuong();
        }
        private void GetLoaiKhenThuong()
        {
            pDM_LoaiKhenThuongInfo.DM_LoaiKhenThuongID = 0;
            dtLoaiKhenThuong = oBDM_LoaiKhenThuong.Get(pDM_LoaiKhenThuongInfo);
            grdLoaiKhenThuong.DataSource = dtLoaiKhenThuong;
        }
        private void ClearText()
        {
            txtMaLoaiKhenThuong.Text = "";
            txtTenLoaiKhenThuong.Text = "";
            txtMaLoaiKhenThuong.Focus();
        }
        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txtMaLoaiKhenThuong.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtMaLoaiKhenThuong, "Mã loại khen thưởng không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMaLoaiKhenThuong;
            }
            if (txtTenLoaiKhenThuong.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTenLoaiKhenThuong, "Tên loại khen thưởng không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenLoaiKhenThuong;
            }
           
            //Kiểm tra cập nhật thành công
            if ((CtrlErr != null))
                return false;
            else
                return true;
        }
        private void GetInfo()
        {
            txtMaLoaiKhenThuong.Text = pDM_LoaiKhenThuongInfo.MaLoaiKhenThuong;
            txtTenLoaiKhenThuong.Text = pDM_LoaiKhenThuongInfo.TenLoaiKhenThuong;
        }

        private void SetInfo()
        {
            pDM_LoaiKhenThuongInfo.MaLoaiKhenThuong = txtMaLoaiKhenThuong.Text;
            pDM_LoaiKhenThuongInfo.TenLoaiKhenThuong = txtTenLoaiKhenThuong.Text;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearText();
            panelTop.Visible = true;
            txtMaLoaiKhenThuong.Focus();
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
                grvLoaiKhenThuong_FocusedRowChanged(null, null);
                try
                {
                    oBDM_LoaiKhenThuong.Delete(pDM_LoaiKhenThuongInfo);
                    GetLoaiKhenThuong();
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
                    oBDM_LoaiKhenThuong.Add(pDM_LoaiKhenThuongInfo);
                    drLoaiKhenThuong = dtLoaiKhenThuong.NewRow();
                    oBDM_LoaiKhenThuong.ToDataRow(pDM_LoaiKhenThuongInfo, ref drLoaiKhenThuong);
                    dtLoaiKhenThuong.Rows.Add(drLoaiKhenThuong);
                    ThemThanhCong();
                   
                }
                else
                {
                    oBDM_LoaiKhenThuong.Update(pDM_LoaiKhenThuongInfo);
                    drLoaiKhenThuong[pDM_LoaiKhenThuongInfo.strMaLoaiKhenThuong] = pDM_LoaiKhenThuongInfo.MaLoaiKhenThuong;
                    drLoaiKhenThuong[pDM_LoaiKhenThuongInfo.strTenLoaiKhenThuong] = pDM_LoaiKhenThuongInfo.TenLoaiKhenThuong;
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

        private void grvLoaiKhenThuong_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvLoaiKhenThuong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvLoaiKhenThuong.FocusedRowHandle >= 0)
            {
                drLoaiKhenThuong = grvLoaiKhenThuong.GetDataRow(grvLoaiKhenThuong.FocusedRowHandle);
                oBDM_LoaiKhenThuong.ToInfo(ref pDM_LoaiKhenThuongInfo, drLoaiKhenThuong);
            }
        }
    }
}