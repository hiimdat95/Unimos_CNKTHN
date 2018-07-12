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
    public partial class frmDM_LoaiLuanChuyen : frmBase
    {
        private cBNS_LoaiLuanChuyen oBNS_LoaiLuanChuyen;
        private NS_LoaiLuanChuyenInfo pNS_LoaiLuanChuyenInfo;
        private DataTable dtLoaiLuanChuyen;
        private DataRow drLoaiLuanChuyen;
        private EDIT_MODE edit;
        public frmQuaTrinhLuanChuyen ofrmQuaTrinhLuanChuyen;

        public frmDM_LoaiLuanChuyen(frmQuaTrinhLuanChuyen _frmQuaTrinhLuanChuyen)
        {
            InitializeComponent();
            oBNS_LoaiLuanChuyen = new cBNS_LoaiLuanChuyen();
            pNS_LoaiLuanChuyenInfo = new NS_LoaiLuanChuyenInfo();
            SetControl(false);
            ofrmQuaTrinhLuanChuyen = _frmQuaTrinhLuanChuyen;
        }

        private void GetLoaiLuanChuyen()
        {
            cmbTrangThaiGiaoVien.Properties.DataSource = LoadTrangThaiGiaoVien();
            reposTranngThaiGiaoVien.DataSource = LoadTrangThaiGiaoVien();
            pNS_LoaiLuanChuyenInfo.NS_LoaiLuanChuyenID = 0;
            dtLoaiLuanChuyen = oBNS_LoaiLuanChuyen.Get(pNS_LoaiLuanChuyenInfo);
            grdLoaiLuanChuyen.DataSource = dtLoaiLuanChuyen;
        }

        private void SetControl(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }

        private void ClearText()
        {
            txtTenLoaiLuanChuyen.Text = "";
            cmbTrangThaiGiaoVien.EditValue = null;
            txtTenLoaiLuanChuyen.Focus();
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txtTenLoaiLuanChuyen.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTenLoaiLuanChuyen, "Tên loại luân chuyển không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenLoaiLuanChuyen;
            }
            if (cmbTrangThaiGiaoVien.EditValue == null)
            {
                dxErrorProvider.SetError(cmbTrangThaiGiaoVien, "Trạng thái giáo viên không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbTrangThaiGiaoVien;
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
            txtTenLoaiLuanChuyen.Text = pNS_LoaiLuanChuyenInfo.TenLoaiLuanChuyen;
            cmbTrangThaiGiaoVien.EditValue = int.Parse("0" + pNS_LoaiLuanChuyenInfo.TrangThaiGiaoVien);
            txtTenLoaiLuanChuyen.Focus();
        }

        private void GetpInfo()
        {
            pNS_LoaiLuanChuyenInfo.TenLoaiLuanChuyen = txtTenLoaiLuanChuyen.Text;
            pNS_LoaiLuanChuyenInfo.TrangThaiGiaoVien = int.Parse("0" + cmbTrangThaiGiaoVien.EditValue);
        }


        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdLoaiLuanChuyen.Enabled = false;
            edit = EDIT_MODE.THEM;
            panelTop.Visible = true;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdLoaiLuanChuyen.Enabled = false;
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
                    pNS_LoaiLuanChuyenInfo.NS_LoaiLuanChuyenID = int.Parse(drLoaiLuanChuyen[pNS_LoaiLuanChuyenInfo.strNS_LoaiLuanChuyenID].ToString());
                    oBNS_LoaiLuanChuyen.Delete(pNS_LoaiLuanChuyenInfo);
                    // ghi log
                    GhiLog("Xóa loại luân chuyển '" + pNS_LoaiLuanChuyenInfo.TenLoaiLuanChuyen + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtLoaiLuanChuyen.Rows.Remove(drLoaiLuanChuyen);
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
                    pNS_LoaiLuanChuyenInfo.NS_LoaiLuanChuyenID = oBNS_LoaiLuanChuyen.Add(pNS_LoaiLuanChuyenInfo);
                    GhiLog("Thêm loại luân chuyển '" + pNS_LoaiLuanChuyenInfo.TenLoaiLuanChuyen + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtLoaiLuanChuyen.NewRow();
                    oBNS_LoaiLuanChuyen.ToDataRow(pNS_LoaiLuanChuyenInfo, ref drNew);
                    dtLoaiLuanChuyen.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pNS_LoaiLuanChuyenInfo.NS_LoaiLuanChuyenID = int.Parse(drLoaiLuanChuyen[pNS_LoaiLuanChuyenInfo.strNS_LoaiLuanChuyenID].ToString());
                    oBNS_LoaiLuanChuyen.Update(pNS_LoaiLuanChuyenInfo);
                    GhiLog("Sửa loại luân chuyển '" + pNS_LoaiLuanChuyenInfo.TenLoaiLuanChuyen + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    oBNS_LoaiLuanChuyen.ToDataRow(pNS_LoaiLuanChuyenInfo, ref drLoaiLuanChuyen);
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
            grdLoaiLuanChuyen.Enabled = true;
            dxErrorProvider.ClearErrors();
            panelTop.Visible = false;
        }

        private void grvLoaiLuanChuyen_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvLoaiLuanChuyen.FocusedRowHandle >= 0)
            {
                drLoaiLuanChuyen = grvLoaiLuanChuyen.GetDataRow(grvLoaiLuanChuyen.FocusedRowHandle);
                oBNS_LoaiLuanChuyen.ToInfo(ref pNS_LoaiLuanChuyenInfo, drLoaiLuanChuyen);
                if (ofrmQuaTrinhLuanChuyen != null)
                {
                    ofrmQuaTrinhLuanChuyen.IDDM_LoaiLuanChuyen = int.Parse(drLoaiLuanChuyen[pNS_LoaiLuanChuyenInfo.strNS_LoaiLuanChuyenID].ToString());
                }
            }
            if (grvLoaiLuanChuyen != null)
                if (grvLoaiLuanChuyen.DataRowCount > 0 && grvLoaiLuanChuyen.FocusedRowHandle >= 0)
                {
                    SetControl(true);
                    drLoaiLuanChuyen = grvLoaiLuanChuyen.GetDataRow(grvLoaiLuanChuyen.FocusedRowHandle);
                    return;
                }
            SetControl(false);
            drLoaiLuanChuyen = null;
        }

        private void grvLoaiLuanChuyen_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void frmDM_LoaiLuanChuyen_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            GetLoaiLuanChuyen();
        }
    }
}