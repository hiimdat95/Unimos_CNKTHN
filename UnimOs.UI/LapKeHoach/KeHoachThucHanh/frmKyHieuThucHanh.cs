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
    public partial class frmKyHieuThucHanh : frmBase
    {
        private cBXL_KeHoachThucHanhKyHieu oBXL_KeHoachThucHanhKyHieu;
        private XL_KeHoachThucHanhKyHieuInfo pXL_KeHoachThucHanhKyHieuInfo;
        private DataTable dtKyHieu;
        private DataRow drKyHieu;
        private EDIT_MODE edit;
        public int IDKyHieuSelected = 0;

        public frmKyHieuThucHanh()
        {
            InitializeComponent();
            oBXL_KeHoachThucHanhKyHieu = new cBXL_KeHoachThucHanhKyHieu();
            pXL_KeHoachThucHanhKyHieuInfo = new XL_KeHoachThucHanhKyHieuInfo();
            panelTop.Visible = false;
        }

        private void frmKyHieuThucHanh_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            try
            {
                cmbMonHoc.Properties.DataSource = LoadMonHoc();
                dtKyHieu = oBXL_KeHoachThucHanhKyHieu.Get(pXL_KeHoachThucHanhKyHieuInfo);
                grdKyHieu.DataSource = dtKyHieu;
                if (grvKyHieu.DataRowCount > 0)
                    SetControl(true);
                else
                    SetControl(false);
            }
            catch (Exception ex)
            {
                ThongBaoLoi(ex.Message);
            }
        }

        private void grvKyHieu_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.Name == "gridColumnKyHieu")
            {
                e.Appearance.BackColor = Color.FromArgb(int.Parse(grvKyHieu.GetDataRow(e.RowHandle)["MauNen"].ToString()));
                e.Appearance.ForeColor = Color.FromArgb(int.Parse(grvKyHieu.GetDataRow(e.RowHandle)["MauChu"].ToString()));
            }
        }

        private void grvKyHieu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvKyHieu.FocusedRowHandle >= 0)
                drKyHieu = grvKyHieu.GetDataRow(grvKyHieu.FocusedRowHandle);
            else
                drKyHieu = null;
        }

        private void SetControl(bool val)
        {
            barbtnSua.Enabled = val;
            barbtnXoa.Enabled = val;
        }

        private void ClearText()
        {
            cmbMonHoc.ItemIndex = -1;
            txtKyHieu.Text = "";
            cmbMonHoc.Focus();
        }

        private void GetInfo()
        {
            pXL_KeHoachThucHanhKyHieuInfo.IDDM_MonHoc = int.Parse(cmbMonHoc.EditValue.ToString());
            pXL_KeHoachThucHanhKyHieuInfo.KyHieu = txtKyHieu.Text.Trim();
            pXL_KeHoachThucHanhKyHieuInfo.MauChu = txtMauChu.Color.ToArgb();
            pXL_KeHoachThucHanhKyHieuInfo.MauNen = txtMauNen.Color.ToArgb();
        }

        private void SetText()
        {
            cmbMonHoc.EditValue = drKyHieu["IDDM_MonHoc"];
            txtKyHieu.Text = drKyHieu["KyHieu"].ToString();
            txtMauChu.EditValue = drKyHieu["MauChu"];
            txtMauNen.EditValue = drKyHieu["MauNen"];
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((DxErrorProvider != null)) DxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (cmbMonHoc.ItemIndex < 0)
            {
                DxErrorProvider.SetError(cmbMonHoc, "Bạn phải chọn môn học.");
                if (CtrlErr == null) CtrlErr = cmbMonHoc;
            }
            if (txtKyHieu.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtKyHieu, "Ký hiệu không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtKyHieu;
            }
            if (txtKyHieu.Text != "")
            {
                //kiểm tra ký hiệu nhập vào có trùng với dữ liệu trước không.
                if (dtKyHieu != null)
                {
                    for (int i = 0; i < dtKyHieu.Rows.Count; i++)
                    {
                        if (txtKyHieu.Text.Trim() == dtKyHieu.Rows[i]["KyHieu"].ToString() && (edit == EDIT_MODE.THEM ||
                            (dtKyHieu.Rows[i][pXL_KeHoachThucHanhKyHieuInfo.strXL_KeHoachThucHanhKyHieuID].ToString() != pXL_KeHoachThucHanhKyHieuInfo.XL_KeHoachThucHanhKyHieuID.ToString() && edit == EDIT_MODE.SUA)))
                        {
                            DxErrorProvider.SetError(txtKyHieu, "Ký hiệu này đã tồn tại.");
                            if (CtrlErr == null) CtrlErr = txtKyHieu;
                            txtKyHieu.Text = "";
                            break;
                        }
                    }
                }
            }
            //Kiểm tra thông tin thành công
            if (CtrlErr != null)
            {
                CtrlErr.Focus();
                return false;
            }
            else
                return true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckValid()) return;
            try
            {
                GetInfo();
                if (edit == EDIT_MODE.THEM)
                {
                    pXL_KeHoachThucHanhKyHieuInfo.XL_KeHoachThucHanhKyHieuID = oBXL_KeHoachThucHanhKyHieu.Add(pXL_KeHoachThucHanhKyHieuInfo);
                    DataRow drNew = dtKyHieu.NewRow();
                    oBXL_KeHoachThucHanhKyHieu.ToDataRow(pXL_KeHoachThucHanhKyHieuInfo, ref drNew);
                    drNew["TenMonHoc"] = cmbMonHoc.Text;
                    dtKyHieu.Rows.Add(drNew);
                    // ghi log
                    //GhiLog("Thêm giấy tờ nhập trường '" + pDM_GiayToNhapTruongInfo.TenGiayTo + "'", "Thêm", this.Tag.ToString());
                    ClearText();
                }
                else
                {
                    oBXL_KeHoachThucHanhKyHieu.Update(pXL_KeHoachThucHanhKyHieuInfo);
                    oBXL_KeHoachThucHanhKyHieu.ToDataRow(pXL_KeHoachThucHanhKyHieuInfo, ref drKyHieu);
                    // ghi log
                    //GhiLog("Sửa giấy tờ nhập trường '" + pDM_GiayToNhapTruongInfo.TenGiayTo + "'", "Sửa", this.Tag.ToString());
                    SuaThanhCong();
                    btnHuy_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                ThongBaoLoi(ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            panelTop.Visible = false;
            grdKyHieu.Enabled = true;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            edit = EDIT_MODE.THEM;
            panelTop.Visible = true;
            grdKyHieu.Enabled = false;
            cmbMonHoc.Properties.ReadOnly = false;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            edit = EDIT_MODE.SUA;
            panelTop.Visible = true;
            grdKyHieu.Enabled = false;
            cmbMonHoc.Properties.ReadOnly = true;
            SetText();
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (drKyHieu != null)
            {
                if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
                {
                    try
                    {
                        pXL_KeHoachThucHanhKyHieuInfo.XL_KeHoachThucHanhKyHieuID = int.Parse(drKyHieu["XL_KeHoachThucHanhKyHieuID"].ToString());
                        oBXL_KeHoachThucHanhKyHieu.Delete(pXL_KeHoachThucHanhKyHieuInfo);
                        dtKyHieu.Rows.Remove(drKyHieu);
                        // ghi log
                        //GhiLog("Xóa ký hiệu thực hành '" + pXL_KeHoachThucHanhKyHieuInfo.KyHieu + "'", "Xóa", this.Tag.ToString());
                        XoaThanhCong();
                    }
                    catch
                    {
                        XoaThatBai();
                    }
                }
                else
                    CanhBao("Bạn chưa chọn giấy tờ nhập trường nào!");
            }
        }

        private void grvKyHieu_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void frmKyHieuThucHanh_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (drKyHieu != null)
                IDKyHieuSelected = int.Parse(drKyHieu["XL_KeHoachThucHanhKyHieuID"].ToString());
        }

        private void cmbMonHoc_EditValueChanged(object sender, EventArgs e)
        {
            if (txtKyHieu.Text == "")
                txtKyHieu.Text = cmbMonHoc.GetColumnValue("TenVietTat").ToString();
        }
    }
}