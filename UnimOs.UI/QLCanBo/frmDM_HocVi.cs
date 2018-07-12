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
    public partial class frmDM_HocVi : frmBase
    {
        private cBDM_HocVi oBDM_HocVi;
        private DM_HocViInfo pDM_HocViInfo;
        private DataTable dtHocVi;
        private DataRow drHocVi;
        private EDIT_MODE edit;
        public frmHoSoGiaoVien ofrmHoSoGiaoVien;

        public frmDM_HocVi(frmHoSoGiaoVien _frmHoSoGiaoVien)
        {
            InitializeComponent();
            oBDM_HocVi = new cBDM_HocVi();
            pDM_HocViInfo = new DM_HocViInfo();
            SetControl(false);
            cmbLoaiChuyenMon.Properties.DataSource = (new cBDM_LoaiChuyenMon()).Get(new DM_LoaiChuyenMonInfo());
            ofrmHoSoGiaoVien = _frmHoSoGiaoVien;
        }

        private void frmDM_HocVi_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            GetHocVi();
        }

        private void GetHocVi()
        {
            pDM_HocViInfo.DM_HocViID = 0;
            dtHocVi = oBDM_HocVi.Get(pDM_HocViInfo);
            grdHocVi.DataSource = dtHocVi;
        }

        private void SetControl(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }

        private void ClearText()
        {
            txtTenHocVi.Text = "";
            txtTenHocVi.Focus();
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (cmbLoaiChuyenMon.EditValue == null)
            {
                dxErrorProvider.SetError(cmbLoaiChuyenMon, "Bạn phải chọn loại chuyên môn.");
                if (CtrlErr == null) CtrlErr = cmbLoaiChuyenMon;
            }
            if (txtTenHocVi.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTenHocVi, "Tên học vị không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenHocVi;
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
            txtTenHocVi.Text = pDM_HocViInfo.TenHocVi;
            cmbLoaiChuyenMon.EditValue = pDM_HocViInfo.IDDM_LoaiChuyenMon;
            txtTenHocVi.Focus();
        }

        private void GetpInfo()
        {
            pDM_HocViInfo.TenHocVi= txtTenHocVi.Text;
            pDM_HocViInfo.IDDM_LoaiChuyenMon = int.Parse(cmbLoaiChuyenMon.EditValue.ToString());
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdHocVi.Enabled = false;
            edit = EDIT_MODE.THEM;
            panelTop.Visible = true;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdHocVi.Enabled = false;
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
                    pDM_HocViInfo.DM_HocViID = int.Parse(drHocVi[pDM_HocViInfo.strDM_HocViID].ToString());
                    oBDM_HocVi.Delete(pDM_HocViInfo);
                    // ghi log
                    GhiLog("Xóa học vị '" + pDM_HocViInfo.TenHocVi + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtHocVi.Rows.Remove(drHocVi);
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
                    pDM_HocViInfo.DM_HocViID = oBDM_HocVi.Add(pDM_HocViInfo);
                    GhiLog("Thêm học vị '" + pDM_HocViInfo.TenHocVi + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtHocVi.NewRow();
                    oBDM_HocVi.ToDataRow(pDM_HocViInfo, ref drNew);
                    drNew["TenLoaiChuyenMon"] = cmbLoaiChuyenMon.Text;
                    dtHocVi.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pDM_HocViInfo.DM_HocViID = int.Parse(drHocVi[pDM_HocViInfo.strDM_HocViID].ToString());
                    oBDM_HocVi.Update(pDM_HocViInfo);
                    GhiLog("Sửa học vị '" + pDM_HocViInfo.TenHocVi + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    drHocVi[pDM_HocViInfo.strTenHocVi] = txtTenHocVi.Text;
                    drHocVi["TenLoaiChuyenMon"] = cmbLoaiChuyenMon.Text;
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
            grdHocVi.Enabled = true;
            dxErrorProvider.ClearErrors();
            panelTop.Visible = false;
        }

        private void grvHocVi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvHocVi.FocusedRowHandle >= 0)
            {
                drHocVi = grvHocVi.GetDataRow(grvHocVi.FocusedRowHandle);
                oBDM_HocVi.ToInfo(ref pDM_HocViInfo, drHocVi);
                if (ofrmHoSoGiaoVien != null)
                {
                    ofrmHoSoGiaoVien.IDDM_HocVi = int.Parse(drHocVi[pDM_HocViInfo.strDM_HocViID].ToString());
                }
            }
            if (grvHocVi != null)
                if (grvHocVi.DataRowCount > 0 && grvHocVi.FocusedRowHandle >= 0)
                {
                    SetControl(true);
                    drHocVi = grvHocVi.GetDataRow(grvHocVi.FocusedRowHandle);
                    return;
                }
            SetControl(false);
            drHocVi = null;
        }

        private void grvHocVi_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }
    }
}