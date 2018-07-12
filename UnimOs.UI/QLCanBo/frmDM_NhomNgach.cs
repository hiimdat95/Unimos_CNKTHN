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
    public partial class frmDM_NhomNgach : frmBase
    {
        private cBNS_NhomNgach oBNS_NhomNgach;
        private NS_NhomNgachInfo pNS_NhomNgachInfo;
        private DataTable dtNhomNgach;
        private DataRow drNhomNgach;
        private int k = 0;
        private EDIT_MODE edit;
        public frmDM_NgachCongChuc ofrmDM_NgachCongChuc;

        public frmDM_NhomNgach(frmDM_NgachCongChuc _frmDM_NgachCongChuc)
        {
            InitializeComponent();
            oBNS_NhomNgach = new cBNS_NhomNgach();
            pNS_NhomNgachInfo = new NS_NhomNgachInfo();
            cmbLinhVucCongTac.Properties.DataSource = (new cBNS_LinhVucCongTac()).Get(new NS_LinhVucCongTacInfo());
            SetControl(false);
            SetTxtRerdOnly(true);
            ofrmDM_NgachCongChuc = _frmDM_NgachCongChuc;

        }

        private void frmDM_NhomNgach_Load(object sender, EventArgs e)
        {
            GetNhomNgach();
        }

        private void GetNhomNgach()
        {
            pNS_NhomNgachInfo.NS_NhomNgachID = 0;
            dtNhomNgach = oBNS_NhomNgach.Get(pNS_NhomNgachInfo);
            grdNhomNgach.DataSource = dtNhomNgach;
        }

        private void SetControl(bool status)
        {
            btnSua.Enabled = status;
            btnXoa.Enabled = status;
        }

        private void SetTxtRerdOnly(bool mbool)
        {
            txtMaNgach.Properties.ReadOnly = mbool;
            txtTenNgach.Properties.ReadOnly = mbool;
            txtLoaiCongChuc.Properties.ReadOnly = mbool;
            cmbLinhVucCongTac.Properties.ReadOnly = mbool;
            txtSoNamNangBac.Properties.ReadOnly = mbool;
            txtMoTa.Properties.ReadOnly = mbool;
            txtBac1.Properties.ReadOnly = mbool;
            txtBac2.Properties.ReadOnly = mbool;
            txtBac3.Properties.ReadOnly = mbool;
            txtBac4.Properties.ReadOnly = mbool;
            txtBac5.Properties.ReadOnly = mbool;
            txtBac6.Properties.ReadOnly = mbool;
            txtBac7.Properties.ReadOnly = mbool;
            txtBac8.Properties.ReadOnly = mbool;
            txtBac9.Properties.ReadOnly = mbool;
            txtBac10.Properties.ReadOnly = mbool;
            txtBac11.Properties.ReadOnly = mbool;
            txtBac12.Properties.ReadOnly = mbool;
            txtBac13.Properties.ReadOnly = mbool;
            txtBac14.Properties.ReadOnly = mbool;
            txtBac15.Properties.ReadOnly = mbool;
            txtBac16.Properties.ReadOnly = mbool;
        }

        private void ClearText()
        {
            txtMaNgach.Text = "";
            txtTenNgach.Text = "";
            txtLoaiCongChuc.Text = "";
            txtSoNamNangBac.Text = "";
            txtMoTa.Text = "";
            txtBac1.Text = "";
            txtBac2.Text = "";
            txtBac3.Text = "";
            txtBac4.Text = "";
            txtBac5.Text = "";
            txtBac6.Text = "";
            txtBac7.Text = "";
            txtBac8.Text = "";
            txtBac9.Text = "";
            txtBac10.Text = "";
            txtBac11.Text = "";
            txtBac12.Text = "";
            txtBac13.Text = "";
            txtBac14.Text = "";
            txtBac15.Text = "";
            txtBac16.Text = "";
            txtMaNgach.Focus();
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (cmbLinhVucCongTac.EditValue == null)
            {
                dxErrorProvider.SetError(cmbLinhVucCongTac, "Phải chọn lĩnh vực công tác.");
                if (CtrlErr == null) CtrlErr = cmbLinhVucCongTac;
            }

            if (txtMaNgach.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtMaNgach, "Ký hiệu không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMaNgach;
            }

            if (txtTenNgach.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTenNgach, "Tên nhóm ngạch không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenNgach;
            }

            if (txtLoaiCongChuc.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtLoaiCongChuc, "Loại công chức không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtLoaiCongChuc;
            }

            if (txtSoNamNangBac.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtSoNamNangBac, "Số năm nâng bậc không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtSoNamNangBac;
            }

            if (k == 0)
            {
                dxErrorProvider.SetError(txtBac1, "Hệ số lương các bậc không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtBac1;
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

        private void grvNhomNgach_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void SetText()
        {
            txtMaNgach.Text = pNS_NhomNgachInfo.KyHieu;
            txtTenNgach.Text = pNS_NhomNgachInfo.TenNhomNgach;
            txtLoaiCongChuc.Text = pNS_NhomNgachInfo.LoaiCongChuc;
            txtSoNamNangBac.Text = pNS_NhomNgachInfo.SoNamNangBac.ToString();
            cmbLinhVucCongTac.EditValue = pNS_NhomNgachInfo.IDNS_LinhVucCongTac;
            txtMoTa.Text = "" + pNS_NhomNgachInfo.MoTa;
            txtBac1.Text = pNS_NhomNgachInfo.HeSoLuongBac_1.ToString();
            txtBac2.Text = pNS_NhomNgachInfo.HeSoLuongBac_2.ToString();
            txtBac3.Text = pNS_NhomNgachInfo.HeSoLuongBac_3.ToString();
            txtBac4.Text = pNS_NhomNgachInfo.HeSoLuongBac_4.ToString();
            txtBac5.Text = pNS_NhomNgachInfo.HeSoLuongBac_5.ToString();
            txtBac6.Text = pNS_NhomNgachInfo.HeSoLuongBac_6.ToString();
            txtBac7.Text = pNS_NhomNgachInfo.HeSoLuongBac_7.ToString();
            txtBac8.Text = pNS_NhomNgachInfo.HeSoLuongBac_8.ToString();
            txtBac9.Text = pNS_NhomNgachInfo.HeSoLuongBac_9.ToString();
            txtBac10.Text = pNS_NhomNgachInfo.HeSoLuongBac_10.ToString();
            txtBac11.Text = pNS_NhomNgachInfo.HeSoLuongBac_11.ToString();
            txtBac12.Text = pNS_NhomNgachInfo.HeSoLuongBac_12.ToString();
            txtBac13.Text = pNS_NhomNgachInfo.HeSoLuongBac_13.ToString();
            txtBac14.Text = pNS_NhomNgachInfo.HeSoLuongBac_14.ToString();
            txtBac15.Text = pNS_NhomNgachInfo.HeSoLuongBac_15.ToString();
            txtBac16.Text = pNS_NhomNgachInfo.HeSoLuongBac_16.ToString();
            txtMaNgach.Focus();
        }

        private void GetpInfo()
        {
            pNS_NhomNgachInfo.KyHieu = txtMaNgach.Text;
            pNS_NhomNgachInfo.TenNhomNgach = txtTenNgach.Text;
            pNS_NhomNgachInfo.LoaiCongChuc = txtLoaiCongChuc.Text;
            pNS_NhomNgachInfo.SoNamNangBac = double.Parse("0" + txtSoNamNangBac.Text);
            pNS_NhomNgachInfo.IDNS_LinhVucCongTac = int.Parse(cmbLinhVucCongTac.EditValue.ToString());
            pNS_NhomNgachInfo.MoTa = txtMoTa.Text;
            if (double.Parse("0" + txtBac1.Text) > 0)
            {
                pNS_NhomNgachInfo.HeSoLuongBac_1 = double.Parse(txtBac1.Text);
                k = k+1;
            }
            else
            {
                pNS_NhomNgachInfo.HeSoLuongBac_1 = 0;
            }
            if (double.Parse("0" + txtBac2.Text) > 0)
            {
                pNS_NhomNgachInfo.HeSoLuongBac_2 = double.Parse(txtBac2.Text);
                k = k+1;
            }
            else
            {
                pNS_NhomNgachInfo.HeSoLuongBac_2 = 0;
            }
            if (double.Parse("0" + txtBac3.Text) > 0)
            {
                pNS_NhomNgachInfo.HeSoLuongBac_3 = double.Parse(txtBac3.Text);
                k = k+1;
            }
            else
            {
                pNS_NhomNgachInfo.HeSoLuongBac_3 = 0;
            }
            if (double.Parse("0" + txtBac4.Text) > 0)
            {
                pNS_NhomNgachInfo.HeSoLuongBac_4 = double.Parse(txtBac4.Text);
                k = k+1;
            }
            else
            {
                pNS_NhomNgachInfo.HeSoLuongBac_4 = 0;
            }
            if (double.Parse("0" + txtBac5.Text) > 0)
            {
                pNS_NhomNgachInfo.HeSoLuongBac_5 = double.Parse(txtBac5.Text);
                k = k+1;
            }
            else
            {
                pNS_NhomNgachInfo.HeSoLuongBac_5 = 0;
            }
            if (double.Parse("0" + txtBac6.Text) > 0)
            {
                pNS_NhomNgachInfo.HeSoLuongBac_6 = double.Parse(txtBac6.Text);
                k = k+1;
            }
            else
            {
                pNS_NhomNgachInfo.HeSoLuongBac_6 = 0;
            }
            if (double.Parse("0" + txtBac7.Text) > 0)
            {
                pNS_NhomNgachInfo.HeSoLuongBac_7 = double.Parse(txtBac7.Text);
                k = k+1;
            }
            else
            {
                pNS_NhomNgachInfo.HeSoLuongBac_7 = 0;
            }
            if (double.Parse("0" + txtBac8.Text) > 0)
            {
                pNS_NhomNgachInfo.HeSoLuongBac_8 = double.Parse(txtBac8.Text);
                k = k+1;
            }
            else
            {
                pNS_NhomNgachInfo.HeSoLuongBac_8 = 0;
            }
            if (double.Parse("0" + txtBac9.Text) > 0)
            {
                pNS_NhomNgachInfo.HeSoLuongBac_9 = double.Parse(txtBac9.Text);
                k = k+1;
            }
            else
            {
                pNS_NhomNgachInfo.HeSoLuongBac_9 = 0;
            }
            if (double.Parse("0" + txtBac10.Text) > 0)
            {
                pNS_NhomNgachInfo.HeSoLuongBac_10 = double.Parse(txtBac10.Text);
                k = k+1;
            }
            else
            {
                pNS_NhomNgachInfo.HeSoLuongBac_10 = 0;
            }
            if (double.Parse("0" + txtBac11.Text) > 0)
            {
                pNS_NhomNgachInfo.HeSoLuongBac_11 = double.Parse(txtBac11.Text);
                k = k+1;
            }
            else
            {
                pNS_NhomNgachInfo.HeSoLuongBac_11 = 0;
            }
            if (double.Parse("0" + txtBac12.Text) > 0)
            {
                pNS_NhomNgachInfo.HeSoLuongBac_12 = double.Parse(txtBac12.Text);
                k = k+1;
            }
            else
            {
                pNS_NhomNgachInfo.HeSoLuongBac_12 = 0;
            }
            if (double.Parse("0" + txtBac13.Text) > 0)
            {
                pNS_NhomNgachInfo.HeSoLuongBac_13 = double.Parse(txtBac13.Text);
                k = k+1;
            }
            else
            {
                pNS_NhomNgachInfo.HeSoLuongBac_13 = 0;
            }
            if (double.Parse("0" + txtBac14.Text) > 0)
            {
                pNS_NhomNgachInfo.HeSoLuongBac_14 = double.Parse(txtBac14.Text);
                k = k+1;
            }
            else
            {
                pNS_NhomNgachInfo.HeSoLuongBac_14 = 0;
            }
            if (double.Parse("0" + txtBac15.Text) > 0)
            {
                pNS_NhomNgachInfo.HeSoLuongBac_15 = double.Parse(txtBac15.Text);
                k = k+1;
            }
            else
            {
                pNS_NhomNgachInfo.HeSoLuongBac_15 = 0;
            }
            if (double.Parse("0" + txtBac16.Text) > 0)
            {
                pNS_NhomNgachInfo.HeSoLuongBac_16 = double.Parse(txtBac16.Text);
                k = k+1;
            }
            else
            {
                pNS_NhomNgachInfo.HeSoLuongBac_16 = 0;
            }
            pNS_NhomNgachInfo.BacCaoNhat = k;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            grdNhomNgach.Enabled = false;
            edit = EDIT_MODE.THEM;
            SetTxtRerdOnly(false);
            ClearText();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            grdNhomNgach.Enabled = false;
            edit = EDIT_MODE.SUA;
            SetTxtRerdOnly(false);
            SetText();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    pNS_NhomNgachInfo.NS_NhomNgachID = int.Parse(drNhomNgach[pNS_NhomNgachInfo.strNS_NhomNgachID].ToString());
                    oBNS_NhomNgach.Delete(pNS_NhomNgachInfo);
                    // ghi log
                    GhiLog("Xóa nhóm ngạch '" + pNS_NhomNgachInfo.TenNhomNgach + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    ClearText();
                    dtNhomNgach.Rows.Remove(drNhomNgach);
                    XoaThanhCong();
                }
                catch
                {
                    XoaThatBai();
                }
                k = 0;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            GetpInfo();
            if (!CheckValid()) return;
            try
            {
                if (edit == EDIT_MODE.THEM)
                {
                    pNS_NhomNgachInfo.NS_NhomNgachID = oBNS_NhomNgach.Add(pNS_NhomNgachInfo);
                    GhiLog("Thêm nhóm ngạch '" + pNS_NhomNgachInfo.TenNhomNgach + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtNhomNgach.NewRow();
                    oBNS_NhomNgach.ToDataRow(pNS_NhomNgachInfo, ref drNew);
                    dtNhomNgach.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pNS_NhomNgachInfo.NS_NhomNgachID = int.Parse(drNhomNgach[pNS_NhomNgachInfo.strNS_NhomNgachID].ToString());
                    oBNS_NhomNgach.Update(pNS_NhomNgachInfo);
                    GhiLog("Sửa nhóm ngạch '" + pNS_NhomNgachInfo.TenNhomNgach + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    oBNS_NhomNgach.ToDataRow(pNS_NhomNgachInfo, ref drNhomNgach);
                    SuaThanhCong();
                    btnHuy_Click(null, null);
                }
                k = 0;
            }
            catch
            {
                ThongBaoLoi("Có lỗi trong quá trình thêm hoặc sửa hoặc ghi log.");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            grdNhomNgach.Enabled = true;
            dxErrorProvider.ClearErrors();
            SetTxtRerdOnly(true);
        }

        private void grvNhomNgach_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvNhomNgach.FocusedRowHandle >= 0)
            {
                drNhomNgach = grvNhomNgach.GetDataRow(grvNhomNgach.FocusedRowHandle);
                oBNS_NhomNgach.ToInfo(ref pNS_NhomNgachInfo, drNhomNgach);
                if (ofrmDM_NgachCongChuc != null)
                {
                    ofrmDM_NgachCongChuc.IDNS_NhomNgach = int.Parse(drNhomNgach[pNS_NhomNgachInfo.strNS_NhomNgachID].ToString());
                }
                SetText();
            }
            if (grvNhomNgach != null)
                if (grvNhomNgach.DataRowCount > 0 && grvNhomNgach.FocusedRowHandle >= 0)
                {
                    SetControl(true);
                    drNhomNgach = grvNhomNgach.GetDataRow(grvNhomNgach.FocusedRowHandle);
                    return;
                }
            SetControl(false);
            drNhomNgach = null;
        }
    }
}