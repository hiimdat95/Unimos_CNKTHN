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
    public partial class frmDM_XepLoaiRenLuyen : frmBase
    {
        private cBDM_XepLoaiRenLuyen oBDM_XepLoaiRenLuyen;
        private DM_XepLoaiRenLuyenInfo pDM_XepLoaiRenLuyenInfo;
        private DataTable dtXepLoaiRenLuyen;
        private DataRow drXepLoaiRenLuyen;
        private EDIT_MODE edit;

        public frmDM_XepLoaiRenLuyen()
        {
            InitializeComponent();

            oBDM_XepLoaiRenLuyen = new cBDM_XepLoaiRenLuyen();
            pDM_XepLoaiRenLuyenInfo = new DM_XepLoaiRenLuyenInfo();
            panelTop.Visible = false;
        }

        private void frmDM_XepLoaiRenLuyen_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            dtXepLoaiRenLuyen = oBDM_XepLoaiRenLuyen.Get(pDM_XepLoaiRenLuyenInfo);
            grdXepLoaiRenLuyen.DataSource = dtXepLoaiRenLuyen;
        }

        private void SetControl(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }

        private void ClearText()
        {
            txtKyHieu.Text = "";
            txtTenXepLoai.Text = "";
            txtTuDiem.Text = "0";
            txtDiemCongXetHB.Text = "0";
            txtKyHieu.Focus();
        }

        private void SetText()
        {
            txtKyHieu.Text = drXepLoaiRenLuyen[pDM_XepLoaiRenLuyenInfo.strKyHieu].ToString();
            txtTenXepLoai.Text = drXepLoaiRenLuyen[pDM_XepLoaiRenLuyenInfo.strTenXepLoaiRenLuyen].ToString();
            txtTuDiem.EditValue = drXepLoaiRenLuyen[pDM_XepLoaiRenLuyenInfo.strTuDiem];
            txtDiemCongXetHB.EditValue = drXepLoaiRenLuyen[pDM_XepLoaiRenLuyenInfo.strDiemCongXetHocBong];
            txtKyHieu.Focus();
        }

        private void GetpInfo()
        {
            pDM_XepLoaiRenLuyenInfo.KyHieu = txtKyHieu.Text.Trim();
            pDM_XepLoaiRenLuyenInfo.TenXepLoaiRenLuyen = txtTenXepLoai.Text.Trim();
            pDM_XepLoaiRenLuyenInfo.TuDiem = int.Parse(txtTuDiem.Text);
            pDM_XepLoaiRenLuyenInfo.DiemCongXetHocBong = double.Parse(txtDiemCongXetHB.EditValue.ToString());
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtKyHieu.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtKyHieu, "Ký hiệu không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtKyHieu;
            }
            if (txtTenXepLoai.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTenXepLoai, "Tên không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenXepLoai;
            }

            if (CtrlErr != null)
            {
                CtrlErr.Focus();
                return false;
            }
            else
                return true;
        }

        private void grvXepLoaiRenLuyen_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (grvXepLoaiRenLuyen.FocusedRowHandle >= 0)
            //{
            //    drXepLoaiRenLuyen = grvXepLoaiRenLuyen.GetDataRow(grvXepLoaiRenLuyen.FocusedRowHandle);
            //}
            if (grvXepLoaiRenLuyen != null)
                if (grvXepLoaiRenLuyen.DataRowCount > 0 && grvXepLoaiRenLuyen.FocusedRowHandle >= 0)
                {
                    SetControl(true);
                    drXepLoaiRenLuyen = grvXepLoaiRenLuyen.GetDataRow(grvXepLoaiRenLuyen.FocusedRowHandle);
                    return;
                }
            SetControl(false);
            drXepLoaiRenLuyen = null;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdXepLoaiRenLuyen.Enabled = false;
            edit = EDIT_MODE.THEM;
            panelTop.Visible = true;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdXepLoaiRenLuyen.Enabled = false;
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
                    pDM_XepLoaiRenLuyenInfo.DM_XepLoaiRenLuyenID = int.Parse(drXepLoaiRenLuyen[pDM_XepLoaiRenLuyenInfo.strDM_XepLoaiRenLuyenID].ToString());
                    oBDM_XepLoaiRenLuyen.Delete(pDM_XepLoaiRenLuyenInfo);
                    // ghi log
                    GhiLog("Xóa xếp loại rèn luyện '" + pDM_XepLoaiRenLuyenInfo.TenXepLoaiRenLuyen + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtXepLoaiRenLuyen.Rows.Remove(drXepLoaiRenLuyen);
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
                    pDM_XepLoaiRenLuyenInfo.DM_XepLoaiRenLuyenID = oBDM_XepLoaiRenLuyen.Add(pDM_XepLoaiRenLuyenInfo);
                    GhiLog("Thêm xếp loại rèn luyện '" + pDM_XepLoaiRenLuyenInfo.TenXepLoaiRenLuyen + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtXepLoaiRenLuyen.NewRow();
                    oBDM_XepLoaiRenLuyen.ToDataRow(pDM_XepLoaiRenLuyenInfo, ref drNew);
                    dtXepLoaiRenLuyen.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pDM_XepLoaiRenLuyenInfo.DM_XepLoaiRenLuyenID = int.Parse(drXepLoaiRenLuyen[pDM_XepLoaiRenLuyenInfo.strDM_XepLoaiRenLuyenID].ToString());
                    oBDM_XepLoaiRenLuyen.Update(pDM_XepLoaiRenLuyenInfo);
                    GhiLog("Sửa xếp loại rèn luyện '" + pDM_XepLoaiRenLuyenInfo.TenXepLoaiRenLuyen + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    oBDM_XepLoaiRenLuyen.ToDataRow(pDM_XepLoaiRenLuyenInfo, ref drXepLoaiRenLuyen);
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
            grdXepLoaiRenLuyen.Enabled = true;
            panelTop.Visible = false;
        }

        private void grvXepLoaiRenLuyen_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }
    }
}