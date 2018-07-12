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
    public partial class frmDM_VanBangChungChi : frmBase
    {
        private cBDM_VanBangChungChi oBDM_VanBangChungChi;
        private DM_VanBangChungChiInfo pDM_VanBangChungChiInfo;
        private DataTable dtVanBangChungChi;
        private DataRow drVanBangChungChi;
        private EDIT_MODE edit;
        public frmQuaTrinhBoiDuong ofrmQuaTrinhBoiDuong;

        public frmDM_VanBangChungChi(frmQuaTrinhBoiDuong _frmQuaTrinhBoiDuong)
        {
            InitializeComponent();
            oBDM_VanBangChungChi = new cBDM_VanBangChungChi();
            pDM_VanBangChungChiInfo = new DM_VanBangChungChiInfo();
            SetControl(false);
            ofrmQuaTrinhBoiDuong = _frmQuaTrinhBoiDuong;
        }

        private void GetVanBangChungChi()
        {
            pDM_VanBangChungChiInfo.DM_VanBangChungChiID = 0;
            dtVanBangChungChi = oBDM_VanBangChungChi.Get(pDM_VanBangChungChiInfo);
            grdVanBangChungChi.DataSource = dtVanBangChungChi;
        }

        private void SetControl(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }

        private void ClearText()
        {
            txtTenVanBangChungChi.Text = "";
            rdPhanLoai.EditValue = null;
            txtTenVanBangChungChi.Focus();
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txtTenVanBangChungChi.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTenVanBangChungChi, "Tên văn bằng, chứng chỉ không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenVanBangChungChi;
            }

            if (rdPhanLoai.EditValue == null)
            {
                dxErrorProvider.SetError(rdPhanLoai, "Phân loại văn bằng, chứng chỉ không thể rỗng.");
                if (CtrlErr == null) CtrlErr = rdPhanLoai;
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
            txtTenVanBangChungChi.Text = pDM_VanBangChungChiInfo.Ten;
            if (pDM_VanBangChungChiInfo.VanBang == false && pDM_VanBangChungChiInfo.ChungChi == false)
            {
                rdPhanLoai.EditValue = null;
            }
            else
            {
                if (pDM_VanBangChungChiInfo.VanBang == true)
                {
                    rdPhanLoai.EditValue = 1;
                }
                if (pDM_VanBangChungChiInfo.ChungChi == true)
                {
                    rdPhanLoai.EditValue = 2;
                }
            }
            txtTenVanBangChungChi.Focus();
        }

        private void GetpInfo()
        {
            pDM_VanBangChungChiInfo.Ten = txtTenVanBangChungChi.Text;
            if (rdPhanLoai.EditValue == null)
            {
                pDM_VanBangChungChiInfo.VanBang = false;
                pDM_VanBangChungChiInfo.ChungChi = false;
            }
            else
            {
                if (int.Parse(rdPhanLoai.EditValue.ToString()) == 1)
                {
                    pDM_VanBangChungChiInfo.VanBang = true;
                    pDM_VanBangChungChiInfo.ChungChi = false;
                }
                if (int.Parse(rdPhanLoai.EditValue.ToString()) == 2)
                {
                    pDM_VanBangChungChiInfo.ChungChi = true;
                    pDM_VanBangChungChiInfo.VanBang = false;
                }
            }
        }


        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdVanBangChungChi.Enabled = false;
            edit = EDIT_MODE.THEM;
            panelTop.Visible = true;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdVanBangChungChi.Enabled = false;
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
                    pDM_VanBangChungChiInfo.DM_VanBangChungChiID = int.Parse(drVanBangChungChi[pDM_VanBangChungChiInfo.strDM_VanBangChungChiID].ToString());
                    oBDM_VanBangChungChi.Delete(pDM_VanBangChungChiInfo);
                    // ghi log
                    GhiLog("Xóa văn bằng chứng chỉ '" + pDM_VanBangChungChiInfo.Ten + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtVanBangChungChi.Rows.Remove(drVanBangChungChi);
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
                    pDM_VanBangChungChiInfo.DM_VanBangChungChiID = oBDM_VanBangChungChi.Add(pDM_VanBangChungChiInfo);
                    GhiLog("Thêm văn bằng chứng chỉ '" + pDM_VanBangChungChiInfo.Ten + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtVanBangChungChi.NewRow();
                    oBDM_VanBangChungChi.ToDataRow(pDM_VanBangChungChiInfo, ref drNew);
                    dtVanBangChungChi.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pDM_VanBangChungChiInfo.DM_VanBangChungChiID = int.Parse(drVanBangChungChi[pDM_VanBangChungChiInfo.strDM_VanBangChungChiID].ToString());
                    oBDM_VanBangChungChi.Update(pDM_VanBangChungChiInfo);
                    GhiLog("Sửa văn bằng chứng chỉ '" + pDM_VanBangChungChiInfo.Ten + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    drVanBangChungChi[pDM_VanBangChungChiInfo.strTen] = txtTenVanBangChungChi.Text;
                    if (rdPhanLoai.EditValue == null)
                    {
                        drVanBangChungChi[pDM_VanBangChungChiInfo.strVanBang] = false;
                        drVanBangChungChi[pDM_VanBangChungChiInfo.strChungChi] = false;
                    }
                    else
                    {
                        if (int.Parse(rdPhanLoai.EditValue.ToString()) == 1)
                        {
                            drVanBangChungChi[pDM_VanBangChungChiInfo.strVanBang] = true;
                            drVanBangChungChi[pDM_VanBangChungChiInfo.strChungChi] = false;
                        }
                        if (int.Parse(rdPhanLoai.EditValue.ToString()) == 2)
                        {
                            drVanBangChungChi[pDM_VanBangChungChiInfo.strChungChi] = true;
                            drVanBangChungChi[pDM_VanBangChungChiInfo.strVanBang] = false;
                        }
                    }
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
            grdVanBangChungChi.Enabled = true;
            dxErrorProvider.ClearErrors();
            panelTop.Visible = false;
        }

        private void grvVanBangChungChi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvVanBangChungChi.FocusedRowHandle >= 0)
            {
                drVanBangChungChi = grvVanBangChungChi.GetDataRow(grvVanBangChungChi.FocusedRowHandle);
                oBDM_VanBangChungChi.ToInfo(ref pDM_VanBangChungChiInfo, drVanBangChungChi);
                if (ofrmQuaTrinhBoiDuong != null)
                {
                    ofrmQuaTrinhBoiDuong.IDDM_VanBangChungChi = int.Parse(drVanBangChungChi[pDM_VanBangChungChiInfo.strDM_VanBangChungChiID].ToString());
                }
            }
            if (grvVanBangChungChi != null)
                if (grvVanBangChungChi.DataRowCount > 0 && grvVanBangChungChi.FocusedRowHandle >= 0)
                {
                    SetControl(true);
                    drVanBangChungChi = grvVanBangChungChi.GetDataRow(grvVanBangChungChi.FocusedRowHandle);
                    return;
                }
            SetControl(false);
            drVanBangChungChi = null;
        }

        private void grvVanBangChungChi_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void frmDM_VanBangChungChi_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            GetVanBangChungChi();
        }
    }
}