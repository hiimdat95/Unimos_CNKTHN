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
    public partial class frmDM_DanhHieuDuocPhongTang : frmBase
    {
        private cBDM_DanhHieuDuocPhongTang oBDM_DanhHieuDuocPhongTang;
        private DM_DanhHieuDuocPhongTangInfo pDM_DanhHieuDuocPhongTangInfo;
        private DataTable dtDanhHieuDuocPhongTang;
        private DataRow drDanhHieuDuocPhongTang;
        private EDIT_MODE edit;
        public frmHoSoGiaoVien ofrmHoSoGiaoVien;

        public frmDM_DanhHieuDuocPhongTang(frmHoSoGiaoVien _frmHoSoGiaoVien)
        {
            InitializeComponent();
            oBDM_DanhHieuDuocPhongTang = new cBDM_DanhHieuDuocPhongTang();
            pDM_DanhHieuDuocPhongTangInfo = new DM_DanhHieuDuocPhongTangInfo();
            SetControl(false);
            ofrmHoSoGiaoVien = _frmHoSoGiaoVien;
        }

        private void GetDanhHieuDuocPhongTang()
        {
            pDM_DanhHieuDuocPhongTangInfo.DM_DanhHieuDuocPhongTangID = 0;
            dtDanhHieuDuocPhongTang = oBDM_DanhHieuDuocPhongTang.Get(pDM_DanhHieuDuocPhongTangInfo);
            grdDanhHieuDuocPhongTang.DataSource = dtDanhHieuDuocPhongTang;
        }

        private void SetControl(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }

        private void ClearText()
        {
            txtDanhHieuDuocPhongTang.Text = "";
            txtDanhHieuDuocPhongTang.Focus();
        }
        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txtDanhHieuDuocPhongTang.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtDanhHieuDuocPhongTang, "Tên danh hiệu được phong tặng không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtDanhHieuDuocPhongTang;
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
            txtDanhHieuDuocPhongTang.Text = pDM_DanhHieuDuocPhongTangInfo.TenDanhHieuDuocPhongTang;
            txtDanhHieuDuocPhongTang.Focus();
        }

        private void GetpInfo()
        {
            pDM_DanhHieuDuocPhongTangInfo.TenDanhHieuDuocPhongTang = txtDanhHieuDuocPhongTang.Text;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdDanhHieuDuocPhongTang.Enabled = false;
            edit = EDIT_MODE.THEM;
            panelTop.Visible = true;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdDanhHieuDuocPhongTang.Enabled = false;
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
                    pDM_DanhHieuDuocPhongTangInfo.DM_DanhHieuDuocPhongTangID = int.Parse(drDanhHieuDuocPhongTang[pDM_DanhHieuDuocPhongTangInfo.strDM_DanhHieuDuocPhongTangID].ToString());
                    oBDM_DanhHieuDuocPhongTang.Delete(pDM_DanhHieuDuocPhongTangInfo);
                    // ghi log
                    GhiLog("Xóa chức danh '" + pDM_DanhHieuDuocPhongTangInfo.TenDanhHieuDuocPhongTang + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtDanhHieuDuocPhongTang.Rows.Remove(drDanhHieuDuocPhongTang);
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
                    pDM_DanhHieuDuocPhongTangInfo.DM_DanhHieuDuocPhongTangID = oBDM_DanhHieuDuocPhongTang.Add(pDM_DanhHieuDuocPhongTangInfo);
                    GhiLog("Thêm danh hiệu được phong tặng '" + pDM_DanhHieuDuocPhongTangInfo.TenDanhHieuDuocPhongTang + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtDanhHieuDuocPhongTang.NewRow();
                    oBDM_DanhHieuDuocPhongTang.ToDataRow(pDM_DanhHieuDuocPhongTangInfo, ref drNew);
                    dtDanhHieuDuocPhongTang.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pDM_DanhHieuDuocPhongTangInfo.DM_DanhHieuDuocPhongTangID = int.Parse(drDanhHieuDuocPhongTang[pDM_DanhHieuDuocPhongTangInfo.strDM_DanhHieuDuocPhongTangID].ToString());
                    oBDM_DanhHieuDuocPhongTang.Update(pDM_DanhHieuDuocPhongTangInfo);
                    GhiLog("Sửa danh hiệu được phong tặng '" + pDM_DanhHieuDuocPhongTangInfo.TenDanhHieuDuocPhongTang + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    drDanhHieuDuocPhongTang[pDM_DanhHieuDuocPhongTangInfo.strTenDanhHieuDuocPhongTang] = txtDanhHieuDuocPhongTang.Text;
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
            grdDanhHieuDuocPhongTang.Enabled = true;
            dxErrorProvider.ClearErrors();
            panelTop.Visible = false;
        }

        private void grvDanhHieuDuocPhongTang_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvDanhHieuDuocPhongTang.FocusedRowHandle >= 0)
            {
                drDanhHieuDuocPhongTang = grvDanhHieuDuocPhongTang.GetDataRow(grvDanhHieuDuocPhongTang.FocusedRowHandle);
                oBDM_DanhHieuDuocPhongTang.ToInfo(ref pDM_DanhHieuDuocPhongTangInfo, drDanhHieuDuocPhongTang);
                if (ofrmHoSoGiaoVien != null)
                {
                    ofrmHoSoGiaoVien.IDDM_DanhHieu = int.Parse(drDanhHieuDuocPhongTang[pDM_DanhHieuDuocPhongTangInfo.strDM_DanhHieuDuocPhongTangID].ToString());
                }
            }
            if (grvDanhHieuDuocPhongTang != null)
                if (grvDanhHieuDuocPhongTang.DataRowCount > 0 && grvDanhHieuDuocPhongTang.FocusedRowHandle >= 0)
                {
                    SetControl(true);
                    drDanhHieuDuocPhongTang = grvDanhHieuDuocPhongTang.GetDataRow(grvDanhHieuDuocPhongTang.FocusedRowHandle);
                    return;
                }
            SetControl(false);
            drDanhHieuDuocPhongTang = null;
        }

        private void grvDanhHieuDuocPhongTang_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void frmDM_DanhHieuDuocPhongTang_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            GetDanhHieuDuocPhongTang();
        }
    }
}