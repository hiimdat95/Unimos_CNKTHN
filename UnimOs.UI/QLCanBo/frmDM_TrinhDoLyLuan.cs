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
    public partial class frmDM_TrinhDoLyLuan : frmBase
    {
        private cBDM_TrinhDoLyLuan oBDM_TrinhDoLyLuan;
        private DM_TrinhDoLyLuanInfo pDM_TrinhDoLyLuanInfo;
        private DataTable dtTrinhDoLyLuan;
        private DataRow drTrinhDoLyLuan;
        private EDIT_MODE edit;
        public frmHoSoGiaoVien ofrmHoSoGiaoVien;

        public frmDM_TrinhDoLyLuan(frmHoSoGiaoVien _frmHoSoGiaoVien)
        {
            InitializeComponent();
            oBDM_TrinhDoLyLuan = new cBDM_TrinhDoLyLuan();
            pDM_TrinhDoLyLuanInfo = new DM_TrinhDoLyLuanInfo();
            SetControl(false);
            ofrmHoSoGiaoVien = _frmHoSoGiaoVien;
        }

        private void GetTrinhDoLyLuan()
        {
            pDM_TrinhDoLyLuanInfo.DM_TrinhDoLyLuanID = 0;
            dtTrinhDoLyLuan = oBDM_TrinhDoLyLuan.Get(pDM_TrinhDoLyLuanInfo);
            grdTrinhDoLyLuan.DataSource = dtTrinhDoLyLuan;
        }

        private void SetControl(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }

        private void ClearText()
        {
            txtTrinhDoLyLuan.Text = "";
            txtTrinhDoLyLuan.Focus();
        }
        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txtTrinhDoLyLuan.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTrinhDoLyLuan, "Tên trình độ lý luận không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTrinhDoLyLuan;
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
            txtTrinhDoLyLuan.Text = pDM_TrinhDoLyLuanInfo.TenTrinhDoLyLuan;
            txtTrinhDoLyLuan.Focus();
        }

        private void GetpInfo()
        {
            pDM_TrinhDoLyLuanInfo.TenTrinhDoLyLuan = txtTrinhDoLyLuan.Text;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdTrinhDoLyLuan.Enabled = false;
            edit = EDIT_MODE.THEM;
            panelTop.Visible = true;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdTrinhDoLyLuan.Enabled = false;
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
                    pDM_TrinhDoLyLuanInfo.DM_TrinhDoLyLuanID = int.Parse(drTrinhDoLyLuan[pDM_TrinhDoLyLuanInfo.strDM_TrinhDoLyLuanID].ToString());
                    oBDM_TrinhDoLyLuan.Delete(pDM_TrinhDoLyLuanInfo);
                    // ghi log
                    GhiLog("Xóa trình độ lý luận '" + pDM_TrinhDoLyLuanInfo.TenTrinhDoLyLuan + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtTrinhDoLyLuan.Rows.Remove(drTrinhDoLyLuan);
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
                    pDM_TrinhDoLyLuanInfo.DM_TrinhDoLyLuanID = oBDM_TrinhDoLyLuan.Add(pDM_TrinhDoLyLuanInfo);
                    GhiLog("Thêm trình độ lý luận '" + pDM_TrinhDoLyLuanInfo.TenTrinhDoLyLuan + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtTrinhDoLyLuan.NewRow();
                    oBDM_TrinhDoLyLuan.ToDataRow(pDM_TrinhDoLyLuanInfo, ref drNew);
                    dtTrinhDoLyLuan.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pDM_TrinhDoLyLuanInfo.DM_TrinhDoLyLuanID = int.Parse(drTrinhDoLyLuan[pDM_TrinhDoLyLuanInfo.strDM_TrinhDoLyLuanID].ToString());
                    oBDM_TrinhDoLyLuan.Update(pDM_TrinhDoLyLuanInfo);
                    GhiLog("Sửa trình độ lý luận '" + pDM_TrinhDoLyLuanInfo.TenTrinhDoLyLuan + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    drTrinhDoLyLuan[pDM_TrinhDoLyLuanInfo.strTenTrinhDoLyLuan] = txtTrinhDoLyLuan.Text;
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
            grdTrinhDoLyLuan.Enabled = true;
            dxErrorProvider.ClearErrors();
            panelTop.Visible = false;
        }

        private void grvTrinhDoLyLuan_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvTrinhDoLyLuan.FocusedRowHandle >= 0)
            {
                drTrinhDoLyLuan = grvTrinhDoLyLuan.GetDataRow(grvTrinhDoLyLuan.FocusedRowHandle);
                oBDM_TrinhDoLyLuan.ToInfo(ref pDM_TrinhDoLyLuanInfo, drTrinhDoLyLuan);
                if (ofrmHoSoGiaoVien != null)
                {
                    ofrmHoSoGiaoVien.IDDM_TrinhDoLyLuan = int.Parse(drTrinhDoLyLuan[pDM_TrinhDoLyLuanInfo.strDM_TrinhDoLyLuanID].ToString());
                }
            }
            if (grvTrinhDoLyLuan != null)
                if (grvTrinhDoLyLuan.DataRowCount > 0 && grvTrinhDoLyLuan.FocusedRowHandle >= 0)
                {
                    SetControl(true);
                    drTrinhDoLyLuan = grvTrinhDoLyLuan.GetDataRow(grvTrinhDoLyLuan.FocusedRowHandle);
                    return;
                }
            SetControl(false);
            drTrinhDoLyLuan = null;
        }

        private void grvTrinhDoLyLuan_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void frmDM_TrinhDoLyLuan_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            GetTrinhDoLyLuan();
        }
    }
}