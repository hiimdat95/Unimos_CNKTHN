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
    public partial class frmHanhViViPham : frmBase
    {
        private int status;
        private cBDM_HanhVi oBDM_HanhVi;
        private DM_HanhViInfo pDM_HanhViInfo;
        private cBXL_MonHocTrongKy oBXL_MonHocTrongKy;
        private DataTable dtHanhVi;
        private DataRow drHanhVi;

        public frmHanhViViPham()
        {
            InitializeComponent();
            pDM_HanhViInfo = new DM_HanhViInfo();
            oBDM_HanhVi = new cBDM_HanhVi();
            oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();
        }

        private void frmHanhViViPham_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            GetHanhVi();
        }
        private void GetHanhVi()
        {
            pDM_HanhViInfo.DM_HanhViID = 0;
            dtHanhVi = oBDM_HanhVi.Get(pDM_HanhViInfo);
            grdHanhVi.DataSource = dtHanhVi;
        }
        private void ClearText()
        {
            txtMaHanhVi.Text = "";
            txtTenHanhVi.Text = "";
            txtMaHanhVi.Focus();
        }
        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txtMaHanhVi.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtMaHanhVi, "Mã hành vi không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMaHanhVi;
            }
            if (txtTenHanhVi.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTenHanhVi, "Tên hành vi không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenHanhVi;
            }
           
            //Kiểm tra cập nhật thành công
            if ((CtrlErr != null))
                return false;
            else
                return true;
        }
        private void GetInfo()
        {
            txtMaHanhVi.Text = pDM_HanhViInfo.MaHanhVi;
            txtTenHanhVi.Text = pDM_HanhViInfo.TenHanhVi;
        }

        private void SetInfo()
        {
            pDM_HanhViInfo.MaHanhVi = txtMaHanhVi.Text;
            pDM_HanhViInfo.TenHanhVi = txtTenHanhVi.Text;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearText();
            panelTop.Visible = true;
            txtMaHanhVi.Focus();
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
                grvHanhVi_FocusedRowChanged(null, null);
                try
                {
                    oBDM_HanhVi.Delete(pDM_HanhViInfo);
                    GetHanhVi();
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
                    oBDM_HanhVi.Add(pDM_HanhViInfo);
                    drHanhVi = dtHanhVi.NewRow();
                    oBDM_HanhVi.ToDataRow(pDM_HanhViInfo, ref drHanhVi);
                    dtHanhVi.Rows.Add(drHanhVi);
                    ThemThanhCong();
                   
                }
                else
                {
                    oBDM_HanhVi.Update(pDM_HanhViInfo);
                    drHanhVi[pDM_HanhViInfo.strMaHanhVi] = pDM_HanhViInfo.MaHanhVi;
                    drHanhVi[pDM_HanhViInfo.strTenHanhVi] = pDM_HanhViInfo.TenHanhVi;
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

        private void grvHanhVi_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvHanhVi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvHanhVi.FocusedRowHandle >= 0)
            {
                drHanhVi = grvHanhVi.GetDataRow(grvHanhVi.FocusedRowHandle);
                oBDM_HanhVi.ToInfo(ref pDM_HanhViInfo, drHanhVi);
            }
        }
    }
}