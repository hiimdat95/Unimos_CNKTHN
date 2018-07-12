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
    public partial class frmDM_LoaiHocBong : frmBase
    {
        private int status;
        private cBTC_LoaiHocBong oBTC_LoaiHocBong;
        private TC_LoaiHocBongInfo pTC_LoaiHocBongInfo;
        private DataTable dtLoaiHocBong;
        private DataRow drLoaiHocBong;

        public frmDM_LoaiHocBong()
        {
            InitializeComponent();
            pTC_LoaiHocBongInfo = new TC_LoaiHocBongInfo();
            oBTC_LoaiHocBong = new cBTC_LoaiHocBong();
        }

        private void frmDM_LoaiHocBong_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            cmbHe.Properties.DataSource = LoadHe();
            cmbTrinhDo.Properties.DataSource = LoadTrinhDo();
            GetLoaiHocBong();
        }
        private void GetLoaiHocBong()
        {
            pTC_LoaiHocBongInfo.TC_LoaiHocBongID = 0;
            dtLoaiHocBong = oBTC_LoaiHocBong.Get(pTC_LoaiHocBongInfo);
            grdLoaiHocBong.DataSource = dtLoaiHocBong;
        }
        private void ClearText()
        {
            txtTenLoaiHocBong.Text = "";
            txtSoTien.Text = "";
            txtTenLoaiHocBong.Focus();
            txtKyHieu.Text = "";
        }
        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txtTenLoaiHocBong.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTenLoaiHocBong, "Tên loại thu chi không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenLoaiHocBong;
            }
            if (txtKyHieu.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtKyHieu, "Tên loại thu chi không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtKyHieu;
            }
            if (txtSoTien.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtSoTien, "Tên loại thu chi không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtSoTien;
            }
            if (cmbHe.EditValue == null)
            {
                dxErrorProvider.SetError(cmbHe, "Tên loại thu chi không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbHe;
            }
            if (cmbTrinhDo.EditValue == null)
            {
                dxErrorProvider.SetError(cmbTrinhDo, "Tên loại thu chi không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbTrinhDo;
            }

            //Kiểm tra cập nhật thành công
            if ((CtrlErr != null))
                return false;
            else
                return true;
        }
        private void GetInfo()
        {
            txtTenLoaiHocBong.Text = pTC_LoaiHocBongInfo.TenLoaiHocBong;
            txtSoTien.Text = pTC_LoaiHocBongInfo.SoTien.ToString();
            txtKyHieu.Text = pTC_LoaiHocBongInfo.KyHieu;
            cmbTrinhDo.EditValue = pTC_LoaiHocBongInfo.IDDM_TrinhDo;
            if (cmbTrinhDo.EditValue != null)
                cmbHe.EditValue = cmbTrinhDo.GetColumnValue("IDDM_He");
        }

        private void SetInfo()
        {
            pTC_LoaiHocBongInfo.TenLoaiHocBong = txtTenLoaiHocBong.Text.Trim();
            pTC_LoaiHocBongInfo.KyHieu = txtKyHieu.Text.Trim();
            pTC_LoaiHocBongInfo.SoTien = float.Parse( txtSoTien.Text.Trim());
            pTC_LoaiHocBongInfo.IDDM_TrinhDo = int.Parse(cmbTrinhDo.EditValue.ToString());
        }

        private void cmbHe_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dtTrinhDo = LoadTrinhDoByIDHe(int.Parse(cmbHe.EditValue.ToString()));
            cmbTrinhDo.Properties.DataSource = dtTrinhDo;
            if (dtTrinhDo.Rows.Count > 0)
                cmbTrinhDo.ItemIndex = 0;
        }
        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearText();
            panelTop.Visible = true;
            txtTenLoaiHocBong.Focus();
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
                 grvLoaiHocBong_FocusedRowChanged(null, null);
                 try
                 {
                     oBTC_LoaiHocBong.Delete(pTC_LoaiHocBongInfo);
                     GetLoaiHocBong();
                     XoaThanhCong();
                 }
                 catch
                 {
                     XoaThatBai();
                 }
             }
        }

        private void grvLoaiHocBong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
             if (grvLoaiHocBong.FocusedRowHandle >= 0)
             {
                 drLoaiHocBong = grvLoaiHocBong.GetDataRow(grvLoaiHocBong.FocusedRowHandle);
                 oBTC_LoaiHocBong.ToInfo(ref pTC_LoaiHocBongInfo, drLoaiHocBong);
             }
        }

        private void grvLoaiHocBong_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!Check_Valid()) return;
            try
            {
                SetInfo();
                if (status == 0)
                {
                    oBTC_LoaiHocBong.Add(pTC_LoaiHocBongInfo);
                    drLoaiHocBong = dtLoaiHocBong.NewRow();
                    oBTC_LoaiHocBong.ToDataRow(pTC_LoaiHocBongInfo, ref drLoaiHocBong);
                    drLoaiHocBong["TenHe"] = cmbHe.Text;
                    drLoaiHocBong["TenTrinhDo"] = cmbTrinhDo.Text;
                    dtLoaiHocBong.Rows.Add(drLoaiHocBong);
                    ThemThanhCong();

                }
                else
                {
                    oBTC_LoaiHocBong.Update(pTC_LoaiHocBongInfo);
                    drLoaiHocBong[pTC_LoaiHocBongInfo.strTenLoaiHocBong] = pTC_LoaiHocBongInfo.TenLoaiHocBong;
                    drLoaiHocBong[pTC_LoaiHocBongInfo.strSoTien] = pTC_LoaiHocBongInfo.SoTien;
                    drLoaiHocBong[pTC_LoaiHocBongInfo.strKyHieu] = pTC_LoaiHocBongInfo.KyHieu;
                    drLoaiHocBong["TenTrinhDo"] = cmbTrinhDo.Text;
                    drLoaiHocBong["TenHe"] = cmbHe.Text;
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