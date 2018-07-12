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
    public partial class frmDM_HinhThucDaoTao : frmBase
    {
        private cBDM_HinhThucDaoTao oBDM_HinhThucDaoTao;
        private DM_HinhThucDaoTaoInfo pDM_HinhThucDaoTaoInfo;
        private DataTable dtHinhThucDaoTao;
        private DataRow drHinhThucDaoTao;
        private EDIT_MODE edit;
        public frmQuaTrinhBoiDuong ofrmQuaTrinhBoiDuong;

        public frmDM_HinhThucDaoTao(frmQuaTrinhBoiDuong _frmQuaTrinhBoiDuong)
        {
            InitializeComponent();
            oBDM_HinhThucDaoTao = new cBDM_HinhThucDaoTao();
            pDM_HinhThucDaoTaoInfo = new DM_HinhThucDaoTaoInfo();
            SetControl(false);
            ofrmQuaTrinhBoiDuong = _frmQuaTrinhBoiDuong;
        }

        private void SetControl(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }

        private void GetHinhThucDaoTao()
        {
            pDM_HinhThucDaoTaoInfo.DM_HinhThucDaoTaoID = 0;
            dtHinhThucDaoTao = oBDM_HinhThucDaoTao.Get(pDM_HinhThucDaoTaoInfo);
            grdHinhThucDaoTao.DataSource = dtHinhThucDaoTao;
        }

        private void ClearText()
        {
            txtTenHinhThucDaoTao.Text = "";
            txtTenHinhThucDaoTao.Focus();
        }
        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txtTenHinhThucDaoTao.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTenHinhThucDaoTao, "Tên hình thức đào tạo không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenHinhThucDaoTao;
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
            txtTenHinhThucDaoTao.Text = pDM_HinhThucDaoTaoInfo.TenHinhThucDaoTao;
            txtTenHinhThucDaoTao.Focus();
        }

        private void GetpInfo()
        {
            pDM_HinhThucDaoTaoInfo.TenHinhThucDaoTao = txtTenHinhThucDaoTao.Text;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdHinhThucDaoTao.Enabled = false;
            edit = EDIT_MODE.THEM;
            panelTop.Visible = true;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdHinhThucDaoTao.Enabled = false;
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
                    pDM_HinhThucDaoTaoInfo.DM_HinhThucDaoTaoID = int.Parse(drHinhThucDaoTao[pDM_HinhThucDaoTaoInfo.strDM_HinhThucDaoTaoID].ToString());
                    oBDM_HinhThucDaoTao.Delete(pDM_HinhThucDaoTaoInfo);
                    // ghi log
                    GhiLog("Xóa hình thức đào tạo '" + pDM_HinhThucDaoTaoInfo.TenHinhThucDaoTao + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtHinhThucDaoTao.Rows.Remove(drHinhThucDaoTao);
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
                    pDM_HinhThucDaoTaoInfo.DM_HinhThucDaoTaoID = oBDM_HinhThucDaoTao.Add(pDM_HinhThucDaoTaoInfo);
                    GhiLog("Thêm hình thức đào tạo '" + pDM_HinhThucDaoTaoInfo.TenHinhThucDaoTao + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtHinhThucDaoTao.NewRow();
                    oBDM_HinhThucDaoTao.ToDataRow(pDM_HinhThucDaoTaoInfo, ref drNew);
                    dtHinhThucDaoTao.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pDM_HinhThucDaoTaoInfo.DM_HinhThucDaoTaoID = int.Parse(drHinhThucDaoTao[pDM_HinhThucDaoTaoInfo.strDM_HinhThucDaoTaoID].ToString());
                    oBDM_HinhThucDaoTao.Update(pDM_HinhThucDaoTaoInfo);
                    GhiLog("Sửa hình thức đào tạo '" + pDM_HinhThucDaoTaoInfo.TenHinhThucDaoTao + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    drHinhThucDaoTao[pDM_HinhThucDaoTaoInfo.strTenHinhThucDaoTao] = txtTenHinhThucDaoTao.Text;
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
            grdHinhThucDaoTao.Enabled = true;
            dxErrorProvider.ClearErrors();
            panelTop.Visible = false;
        }

        private void grvHinhThucDaoTao_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvHinhThucDaoTao.FocusedRowHandle >= 0)
            {
                drHinhThucDaoTao = grvHinhThucDaoTao.GetDataRow(grvHinhThucDaoTao.FocusedRowHandle);
                oBDM_HinhThucDaoTao.ToInfo(ref pDM_HinhThucDaoTaoInfo, drHinhThucDaoTao);
                if (ofrmQuaTrinhBoiDuong != null)
                {
                    ofrmQuaTrinhBoiDuong.IDDM_HinhThucDaoTao = int.Parse(drHinhThucDaoTao[pDM_HinhThucDaoTaoInfo.strDM_HinhThucDaoTaoID].ToString());
                }
            }
            if (grvHinhThucDaoTao != null)
                if (grvHinhThucDaoTao.DataRowCount > 0 && grvHinhThucDaoTao.FocusedRowHandle >= 0)
                {
                    SetControl(true);
                    drHinhThucDaoTao = grvHinhThucDaoTao.GetDataRow(grvHinhThucDaoTao.FocusedRowHandle);
                    return;
                }
            SetControl(false);
            drHinhThucDaoTao = null;
        }

        private void grvHinhThucDaoTao_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void frmDM_HinhThucDaoTao_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            GetHinhThucDaoTao();
        }
    }
}