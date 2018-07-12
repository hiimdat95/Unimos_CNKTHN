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
    public partial class frmDM_QuocTich : frmBase
    {
        private cBDM_QuocTich oBDM_QuocTich;
        private DM_QuocTichInfo pDM_QuocTichInfo;
        private DataTable dtQuocTich;
        private DataRow drQuocTich;
        private EDIT_MODE edit;
        public frmQuaTrinhCongTac ofrmQuaTrinhCongTac;

        public frmDM_QuocTich(frmQuaTrinhCongTac _frmQuaTrinhCongTac)
        {
            InitializeComponent();
            oBDM_QuocTich = new cBDM_QuocTich();
            pDM_QuocTichInfo = new DM_QuocTichInfo();
            SetControl(false);
            ofrmQuaTrinhCongTac = _frmQuaTrinhCongTac;
        }

        private void GetQuocTich()
        {
            pDM_QuocTichInfo.DM_QuocTichID = 0;
            dtQuocTich = oBDM_QuocTich.Get(pDM_QuocTichInfo);
            grdQuocTich.DataSource = dtQuocTich;
        }

        private void SetControl(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }

        private void ClearText()
        {
            txtTenQuocTich.Text = "";
            txtMaQuocTich.Text = "";
            txtMaQuocTich.Focus();
        }
        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txtMaQuocTich.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtMaQuocTich, "Mã quốc tịch không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMaQuocTich;
            }

            if (txtTenQuocTich.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTenQuocTich, "Tên chức danh không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenQuocTich;
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
            txtMaQuocTich.Text = pDM_QuocTichInfo.MaNuoc;
            txtTenQuocTich.Text = pDM_QuocTichInfo.TenNuoc;
            txtMaQuocTich.Focus();
        }

        private void GetpInfo()
        {
            pDM_QuocTichInfo.MaNuoc= txtMaQuocTich.Text;
            pDM_QuocTichInfo.TenNuoc = txtTenQuocTich.Text;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdQuocTich.Enabled = false;
            edit = EDIT_MODE.THEM;
            panelTop.Visible = true;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdQuocTich.Enabled = false;
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
                    pDM_QuocTichInfo.DM_QuocTichID = int.Parse(drQuocTich[pDM_QuocTichInfo.strDM_QuocTichID].ToString());
                    oBDM_QuocTich.Delete(pDM_QuocTichInfo);
                    // ghi log
                    GhiLog("Xóa quốc tịch '" + pDM_QuocTichInfo.TenNuoc + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtQuocTich.Rows.Remove(drQuocTich);
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
                    pDM_QuocTichInfo.DM_QuocTichID = oBDM_QuocTich.Add(pDM_QuocTichInfo);
                    GhiLog("Thêm quốc tịch '" + pDM_QuocTichInfo.TenNuoc + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtQuocTich.NewRow();
                    oBDM_QuocTich.ToDataRow(pDM_QuocTichInfo, ref drNew);
                    dtQuocTich.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pDM_QuocTichInfo.DM_QuocTichID = int.Parse(drQuocTich[pDM_QuocTichInfo.strDM_QuocTichID].ToString());
                    oBDM_QuocTich.Update(pDM_QuocTichInfo);
                    GhiLog("Sửa quốc tịch '" + pDM_QuocTichInfo.TenNuoc + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    drQuocTich[pDM_QuocTichInfo.strMaNuoc] = txtMaQuocTich.Text;
                    drQuocTich[pDM_QuocTichInfo.strTenNuoc] = txtTenQuocTich.Text;
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
            grdQuocTich.Enabled = true;
            dxErrorProvider.ClearErrors();
            panelTop.Visible = false;
        }

        private void frmDM_QuocTich_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            GetQuocTich();
        }

        private void grvQuocTich_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvQuocTich_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvQuocTich.FocusedRowHandle >= 0)
            {
                drQuocTich = grvQuocTich.GetDataRow(grvQuocTich.FocusedRowHandle);
                oBDM_QuocTich.ToInfo(ref pDM_QuocTichInfo, drQuocTich);
                if (ofrmQuaTrinhCongTac != null)
                {
                    ofrmQuaTrinhCongTac.IDDM_QuocTich = int.Parse(drQuocTich[pDM_QuocTichInfo.strDM_QuocTichID].ToString());
                }
            }
            if (grvQuocTich != null)
                if (grvQuocTich.DataRowCount > 0 && grvQuocTich.FocusedRowHandle >= 0)
                {
                    SetControl(true);
                    drQuocTich = grvQuocTich.GetDataRow(grvQuocTich.FocusedRowHandle);
                    return;
                }
            SetControl(false);
            drQuocTich = null;
        }
    }
}