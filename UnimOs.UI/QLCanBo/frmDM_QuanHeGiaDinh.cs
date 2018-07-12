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
    public partial class frmDM_QuanHeGiaDinh : frmBase
    {
        private cBDM_QuanHeGiaDinh oBDM_QuanHeGiaDinh;
        private DM_QuanHeGiaDinhInfo pDM_QuanHeGiaDinhInfo;
        private DataTable dtQuanHeGiaDinh;
        private DataRow drQuanHeGiaDinh;
        private EDIT_MODE edit;
        public frmHoSoGiaoVien ofrmHoSoGiaoVien;

        public frmDM_QuanHeGiaDinh(frmHoSoGiaoVien _frmHoSoGiaoVien)
        {
            InitializeComponent();
            oBDM_QuanHeGiaDinh = new cBDM_QuanHeGiaDinh();
            pDM_QuanHeGiaDinhInfo = new DM_QuanHeGiaDinhInfo();
            SetControl(false);
            ofrmHoSoGiaoVien = _frmHoSoGiaoVien;
        }

        private void GetQuanHeGiaDinh()
        {
            pDM_QuanHeGiaDinhInfo.DM_QuanHeGiaDinhID = 0;
            dtQuanHeGiaDinh = oBDM_QuanHeGiaDinh.Get(pDM_QuanHeGiaDinhInfo);
            grdMoiQuanHeGiaDinh.DataSource = dtQuanHeGiaDinh;
        }

        private void SetControl(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }

        private void ClearText()
        {
            txtTenMoiQuanHe.Text = "";
            rdMoiLienHe.EditValue = null;
            txtTenMoiQuanHe.Focus();
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txtTenMoiQuanHe.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTenMoiQuanHe, "Tên mối quan hệ gia đình không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenMoiQuanHe;
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
            txtTenMoiQuanHe.Text = pDM_QuanHeGiaDinhInfo.TenMoiQuanHe;
            if (pDM_QuanHeGiaDinhInfo.Bo == false && pDM_QuanHeGiaDinhInfo.Me == false)
            {
                rdMoiLienHe.EditValue = null;
            }
            else
            {
                if (pDM_QuanHeGiaDinhInfo.Bo == true)
                {
                    rdMoiLienHe.EditValue = 1;
                }
                if (pDM_QuanHeGiaDinhInfo.Me == true)
                {
                    rdMoiLienHe.EditValue = 2;
                }
            }
            txtTenMoiQuanHe.Focus();
        }

        private void GetpInfo()
        {
            pDM_QuanHeGiaDinhInfo.TenMoiQuanHe = txtTenMoiQuanHe.Text;
            if (rdMoiLienHe.EditValue == null)
            {
                pDM_QuanHeGiaDinhInfo.Bo = false;
                pDM_QuanHeGiaDinhInfo.Me = false;
            }
            else
            {
                if (int.Parse(rdMoiLienHe.EditValue.ToString()) == 1)
                {
                    pDM_QuanHeGiaDinhInfo.Bo = true;
                    pDM_QuanHeGiaDinhInfo.Me = false;
                }
                if (int.Parse(rdMoiLienHe.EditValue.ToString()) == 2)
                {
                    pDM_QuanHeGiaDinhInfo.Me = true;
                    pDM_QuanHeGiaDinhInfo.Bo = false;
                }
            }
        }


        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdMoiQuanHeGiaDinh.Enabled = false;
            edit = EDIT_MODE.THEM;
            panelTop.Visible = true;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdMoiQuanHeGiaDinh.Enabled = false;
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
                    pDM_QuanHeGiaDinhInfo.DM_QuanHeGiaDinhID = int.Parse(drQuanHeGiaDinh[pDM_QuanHeGiaDinhInfo.strDM_QuanHeGiaDinhID].ToString());
                    oBDM_QuanHeGiaDinh.Delete(pDM_QuanHeGiaDinhInfo);
                    // ghi log
                    GhiLog("Xóa quan hệ gia đình '" + pDM_QuanHeGiaDinhInfo.TenMoiQuanHe + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtQuanHeGiaDinh.Rows.Remove(drQuanHeGiaDinh);
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
                    pDM_QuanHeGiaDinhInfo.DM_QuanHeGiaDinhID = oBDM_QuanHeGiaDinh.Add(pDM_QuanHeGiaDinhInfo);
                    GhiLog("Thêm quan hệ gia đình '" + pDM_QuanHeGiaDinhInfo.TenMoiQuanHe + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtQuanHeGiaDinh.NewRow();
                    oBDM_QuanHeGiaDinh.ToDataRow(pDM_QuanHeGiaDinhInfo, ref drNew);
                    dtQuanHeGiaDinh.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pDM_QuanHeGiaDinhInfo.DM_QuanHeGiaDinhID = int.Parse(drQuanHeGiaDinh[pDM_QuanHeGiaDinhInfo.strDM_QuanHeGiaDinhID].ToString());
                    oBDM_QuanHeGiaDinh.Update(pDM_QuanHeGiaDinhInfo);
                    GhiLog("Sửa quan hệ gia đình '" + pDM_QuanHeGiaDinhInfo.TenMoiQuanHe + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    drQuanHeGiaDinh[pDM_QuanHeGiaDinhInfo.strTenMoiQuanHe] = txtTenMoiQuanHe.Text;
                    if (rdMoiLienHe.EditValue == null)
                    {
                        drQuanHeGiaDinh[pDM_QuanHeGiaDinhInfo.strBo] = false;
                        drQuanHeGiaDinh[pDM_QuanHeGiaDinhInfo.strMe] = false;
                    }
                    else
                    {
                        if (int.Parse(rdMoiLienHe.EditValue.ToString()) == 1)
                        {
                            drQuanHeGiaDinh[pDM_QuanHeGiaDinhInfo.strBo] = true;
                            drQuanHeGiaDinh[pDM_QuanHeGiaDinhInfo.strMe] = false;
                        }
                        if (int.Parse(rdMoiLienHe.EditValue.ToString()) == 2)
                        {
                            drQuanHeGiaDinh[pDM_QuanHeGiaDinhInfo.strMe] = true;
                            drQuanHeGiaDinh[pDM_QuanHeGiaDinhInfo.strBo] = false;
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
            grdMoiQuanHeGiaDinh.Enabled = true;
            dxErrorProvider.ClearErrors();
            panelTop.Visible = false;
        }

        private void grvHinhThucDaoTao_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvMoiQuanHeGiaDinh.FocusedRowHandle >= 0)
            {
                drQuanHeGiaDinh = grvMoiQuanHeGiaDinh.GetDataRow(grvMoiQuanHeGiaDinh.FocusedRowHandle);
                oBDM_QuanHeGiaDinh.ToInfo(ref pDM_QuanHeGiaDinhInfo, drQuanHeGiaDinh);
                if (ofrmHoSoGiaoVien != null)
                {
                    ofrmHoSoGiaoVien.IDDM_QuanHeGiaDinh = int.Parse(drQuanHeGiaDinh[pDM_QuanHeGiaDinhInfo.strDM_QuanHeGiaDinhID].ToString());
                }
            }
            if (grvMoiQuanHeGiaDinh != null)
                if (grvMoiQuanHeGiaDinh.DataRowCount > 0 && grvMoiQuanHeGiaDinh.FocusedRowHandle >= 0)
                {
                    SetControl(true);
                    drQuanHeGiaDinh = grvMoiQuanHeGiaDinh.GetDataRow(grvMoiQuanHeGiaDinh.FocusedRowHandle);
                    return;
                }
            SetControl(false);
            drQuanHeGiaDinh = null;
        }

        private void grvHinhThucDaoTao_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void frmDM_HinhThucDaoTao_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            GetQuanHeGiaDinh();
        }
    }
}