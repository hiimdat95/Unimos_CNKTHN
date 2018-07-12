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
    public partial class frmDM_HocHam : frmBase
    {
        private cBDM_HocHam oBDM_HocHam;
        private DM_HocHamInfo pDM_HocHamInfo;
        private DataTable dtHocHam;
        private DataRow drHocHam;
        private EDIT_MODE edit;
        public frmHoSoGiaoVien ofrmHoSoGiaoVien;

        public frmDM_HocHam(frmHoSoGiaoVien _frmHoSoGiaoVien)
        {
            InitializeComponent();
            oBDM_HocHam = new cBDM_HocHam();
            pDM_HocHamInfo = new DM_HocHamInfo();
            SetControl(false);
            ofrmHoSoGiaoVien = _frmHoSoGiaoVien;
        }

        private void GetHocHam()
        {
            pDM_HocHamInfo.DM_HocHamID = 0;
            dtHocHam = oBDM_HocHam.Get(pDM_HocHamInfo);
            grdHocHam.DataSource = dtHocHam;
        }

        private void SetControl(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }

        private void ClearText()
        {
            txtTenHocHam.Text = "";
            txtTenHocHam.Focus();
        }
        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txtTenHocHam.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTenHocHam, "Tên học hàm không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenHocHam;
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
            txtTenHocHam.Text = pDM_HocHamInfo.TenHocHam;
            txtTenHocHam.Focus();
        }

        private void GetpInfo()
        {
            pDM_HocHamInfo.TenHocHam= txtTenHocHam.Text;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdHocHam.Enabled = false;
            edit = EDIT_MODE.THEM;
            panelTop.Visible = true;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdHocHam.Enabled = false;
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
                    pDM_HocHamInfo.DM_HocHamID = int.Parse(drHocHam[pDM_HocHamInfo.strDM_HocHamID].ToString());
                    oBDM_HocHam.Delete(pDM_HocHamInfo);
                    // ghi log
                    GhiLog("Xóa học hàm '" + pDM_HocHamInfo.TenHocHam + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtHocHam.Rows.Remove(drHocHam);
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
                    pDM_HocHamInfo.DM_HocHamID = oBDM_HocHam.Add(pDM_HocHamInfo);
                    GhiLog("Thêm học hàm '" + pDM_HocHamInfo.TenHocHam + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtHocHam.NewRow();
                    oBDM_HocHam.ToDataRow(pDM_HocHamInfo, ref drNew);
                    dtHocHam.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pDM_HocHamInfo.DM_HocHamID = int.Parse(drHocHam[pDM_HocHamInfo.strDM_HocHamID].ToString());
                    oBDM_HocHam.Update(pDM_HocHamInfo);
                    GhiLog("Sửa học hàm '" + pDM_HocHamInfo.TenHocHam + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    drHocHam[pDM_HocHamInfo.strTenHocHam] = txtTenHocHam.Text;
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
            grdHocHam.Enabled = true;
            dxErrorProvider.ClearErrors();
            panelTop.Visible = false;
        }


        private void grvHoaHam_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvHoaHam.FocusedRowHandle >= 0)
            {
                drHocHam = grvHoaHam.GetDataRow(grvHoaHam.FocusedRowHandle);
                oBDM_HocHam.ToInfo(ref pDM_HocHamInfo, drHocHam);
                if (ofrmHoSoGiaoVien != null)
                {
                    ofrmHoSoGiaoVien.IDDM_HocHam = int.Parse(drHocHam[pDM_HocHamInfo.strDM_HocHamID].ToString());
                }
            }
            if (grvHoaHam != null)
                if (grvHoaHam.DataRowCount > 0 && grvHoaHam.FocusedRowHandle >= 0)
                {
                    SetControl(true);
                    drHocHam = grvHoaHam.GetDataRow(grvHoaHam.FocusedRowHandle);
                    return;
                }
            SetControl(false);
            drHocHam = null;
        }

        private void grvHoaHam_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void frmDM_HocHam_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            GetHocHam();
        }
    }
}