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
    public partial class frmDM_QuanHam : frmBase
    {
        private cBDM_QuanHam oBDM_QuanHam;
        private DM_QuanHamInfo pDM_QuanHamInfo;
        private DataTable dtQuanHam;
        private DataRow drQuanHam;
        private EDIT_MODE edit;
        public frmQuaTrinhThamGiaLLVT ofrmQuaTrinhThamGiaLLVT;

        public frmDM_QuanHam(frmQuaTrinhThamGiaLLVT _frmQuaTrinhThamGiaLLVT)
        {
            InitializeComponent();
            oBDM_QuanHam = new cBDM_QuanHam();
            pDM_QuanHamInfo = new DM_QuanHamInfo();
            SetControl(false);
            ofrmQuaTrinhThamGiaLLVT = _frmQuaTrinhThamGiaLLVT;
        }

        private void GetQuanHam()
        {
            pDM_QuanHamInfo.DM_QuanHamID = 0;
            dtQuanHam = oBDM_QuanHam.Get(pDM_QuanHamInfo);
            grdQuanHam.DataSource = dtQuanHam;
        }

        private void SetControl(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }

        private void ClearText()
        {
            txtTenQuanHam.Text = "";
            txtTenQuanHam.Focus();
        }
        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txtTenQuanHam.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTenQuanHam, "Tên quân hàm không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenQuanHam;
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
            txtTenQuanHam.Text = pDM_QuanHamInfo.TenQuanHam;
            txtTenQuanHam.Focus();
        }

        private void GetpInfo()
        {
            pDM_QuanHamInfo.TenQuanHam= txtTenQuanHam.Text;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdQuanHam.Enabled = false;
            edit = EDIT_MODE.THEM;
            panelTop.Visible = true;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdQuanHam.Enabled = false;
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
                    pDM_QuanHamInfo.DM_QuanHamID = int.Parse(drQuanHam[pDM_QuanHamInfo.strDM_QuanHamID].ToString());
                    oBDM_QuanHam.Delete(pDM_QuanHamInfo);
                    // ghi log
                    GhiLog("Xóa quân hàm '" + pDM_QuanHamInfo.TenQuanHam + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtQuanHam.Rows.Remove(drQuanHam);
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
                    pDM_QuanHamInfo.DM_QuanHamID = oBDM_QuanHam.Add(pDM_QuanHamInfo);
                    GhiLog("Thêm quân hàm '" + pDM_QuanHamInfo.TenQuanHam + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtQuanHam.NewRow();
                    oBDM_QuanHam.ToDataRow(pDM_QuanHamInfo, ref drNew);
                    dtQuanHam.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pDM_QuanHamInfo.DM_QuanHamID = int.Parse(drQuanHam[pDM_QuanHamInfo.strDM_QuanHamID].ToString());
                    oBDM_QuanHam.Update(pDM_QuanHamInfo);
                    GhiLog("Sửa quân hàm '" + pDM_QuanHamInfo.TenQuanHam + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    drQuanHam[pDM_QuanHamInfo.strTenQuanHam] = txtTenQuanHam.Text;
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
            grdQuanHam.Enabled = true;
            dxErrorProvider.ClearErrors();
            panelTop.Visible = false;
        }

        private void grvQuanHam_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvQuanHam.FocusedRowHandle >= 0)
            {
                drQuanHam = grvQuanHam.GetDataRow(grvQuanHam.FocusedRowHandle);
                oBDM_QuanHam.ToInfo(ref pDM_QuanHamInfo, drQuanHam);
                if (ofrmQuaTrinhThamGiaLLVT != null)
                {
                    ofrmQuaTrinhThamGiaLLVT.IDDM_QuanHam = int.Parse(drQuanHam[pDM_QuanHamInfo.strDM_QuanHamID].ToString());
                }
            }
            if (grvQuanHam != null)
                if (grvQuanHam.DataRowCount > 0 && grvQuanHam.FocusedRowHandle >= 0)
                {
                    SetControl(true);
                    drQuanHam = grvQuanHam.GetDataRow(grvQuanHam.FocusedRowHandle);
                    return;
                }
            SetControl(false);
            drQuanHam = null;
        }

        private void grvQuanHam_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void frmDM_QuanHam_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            GetQuanHam();
        }
    }
}