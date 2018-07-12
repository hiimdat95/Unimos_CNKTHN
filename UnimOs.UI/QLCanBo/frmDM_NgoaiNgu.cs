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
    public partial class frmDM_NgoaiNgu : frmBase
    {
        private cBDM_NgoaiNgu oBDM_NgoaiNgu;
        private DM_NgoaiNguInfo pDM_NgoaiNguInfo;
        private DataTable dtNgoaiNgu;
        private DataRow drNgoaiNgu;
        private EDIT_MODE edit;
        public frmHoSoGiaoVien ofrmHoSoGiaoVien;

        public frmDM_NgoaiNgu(frmHoSoGiaoVien _frmHoSoGiaoVien)
        {
            InitializeComponent();
            oBDM_NgoaiNgu = new cBDM_NgoaiNgu();
            pDM_NgoaiNguInfo = new DM_NgoaiNguInfo();
            SetControl(false);
            ofrmHoSoGiaoVien = _frmHoSoGiaoVien;
        }

        private void GetNgoaiNgu()
        {
            pDM_NgoaiNguInfo.DM_NgoaiNguID = 0;
            dtNgoaiNgu = oBDM_NgoaiNgu.Get(pDM_NgoaiNguInfo);
            grdNgoaiNgu.DataSource = dtNgoaiNgu;
        }

        private void SetControl(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }

        private void ClearText()
        {
            txtTenNgoaiNgu.Text = "";
            txtTenNgoaiNgu.Focus();
        }
        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txtTenNgoaiNgu.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTenNgoaiNgu, "Tên ngoại ngữ không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenNgoaiNgu;
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
            txtTenNgoaiNgu.Text = pDM_NgoaiNguInfo.TenNgoaiNgu;
            txtTenNgoaiNgu.Focus();
        }

        private void GetpInfo()
        {
            pDM_NgoaiNguInfo.TenNgoaiNgu = txtTenNgoaiNgu.Text;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdNgoaiNgu.Enabled = false;
            edit = EDIT_MODE.THEM;
            panelTop.Visible = true;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdNgoaiNgu.Enabled = false;
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
                    pDM_NgoaiNguInfo.DM_NgoaiNguID = int.Parse(drNgoaiNgu[pDM_NgoaiNguInfo.strDM_NgoaiNguID].ToString());
                    oBDM_NgoaiNgu.Delete(pDM_NgoaiNguInfo);
                    // ghi log
                    GhiLog("Xóa ngoại ngữ '" + pDM_NgoaiNguInfo.TenNgoaiNgu + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtNgoaiNgu.Rows.Remove(drNgoaiNgu);
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
                    pDM_NgoaiNguInfo.DM_NgoaiNguID = oBDM_NgoaiNgu.Add(pDM_NgoaiNguInfo);
                    GhiLog("Thêm ngoại ngữ '" + pDM_NgoaiNguInfo.TenNgoaiNgu + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtNgoaiNgu.NewRow();
                    oBDM_NgoaiNgu.ToDataRow(pDM_NgoaiNguInfo, ref drNew);
                    dtNgoaiNgu.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pDM_NgoaiNguInfo.DM_NgoaiNguID = int.Parse(drNgoaiNgu[pDM_NgoaiNguInfo.strDM_NgoaiNguID].ToString());
                    oBDM_NgoaiNgu.Update(pDM_NgoaiNguInfo);
                    GhiLog("Sửa ngoại ngữ '" + pDM_NgoaiNguInfo.TenNgoaiNgu + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    drNgoaiNgu[pDM_NgoaiNguInfo.strTenNgoaiNgu] = txtTenNgoaiNgu.Text;
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
            grdNgoaiNgu.Enabled = true;
            dxErrorProvider.ClearErrors();
            panelTop.Visible = false;
        }

        private void grvNgoaiNgu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvNgoaiNgu.FocusedRowHandle >= 0)
            {
                drNgoaiNgu = grvNgoaiNgu.GetDataRow(grvNgoaiNgu.FocusedRowHandle);
                oBDM_NgoaiNgu.ToInfo(ref pDM_NgoaiNguInfo, drNgoaiNgu);
                if (ofrmHoSoGiaoVien != null)
                { 
                    ofrmHoSoGiaoVien.IDDM_NgoaiNgu = int.Parse(drNgoaiNgu[pDM_NgoaiNguInfo.strDM_NgoaiNguID].ToString());
                }
            }
            if (grvNgoaiNgu != null)
                if (grvNgoaiNgu.DataRowCount > 0 && grvNgoaiNgu.FocusedRowHandle >= 0)
                {
                    SetControl(true);
                    drNgoaiNgu = grvNgoaiNgu.GetDataRow(grvNgoaiNgu.FocusedRowHandle);
                    return;
                }
            SetControl(false);
            drNgoaiNgu = null;
        }

        private void grvNgoaiNgu_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void frmDM_NgoaiNgu_Load(object sender, EventArgs e)
        {
            GetNgoaiNgu();
        }
    }
}