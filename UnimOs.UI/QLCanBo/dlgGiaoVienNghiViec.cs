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
    public partial class dlgGiaoVienNghiViec : frmBase
    {
        private cBNS_GiaoVien_NghiViec oBNS_GiaoVien_NghiViec;
        private NS_GiaoVien_NghiViecInfo pNS_GiaoVien_NghiViecInfo;
        private DataTable dtNS_GiaoVien_NghiViec;
        private DataRow drNS_GiaoVien_NghiViec;
        private EDIT_MODE edit;
        private int NS_GiaoVienID;

        public dlgGiaoVienNghiViec(int _NS_GiaoVienID)
        {
            InitializeComponent();
            NS_GiaoVienID = _NS_GiaoVienID;
            oBNS_GiaoVien_NghiViec = new cBNS_GiaoVien_NghiViec();
            pNS_GiaoVien_NghiViecInfo = new NS_GiaoVien_NghiViecInfo();
            dtpNgayCoHieuLuc.EditValue = DateTime.Now;
            SetControl(false);
        }

        private void GetGiaoVien_NghiViec()
        {
            dtNS_GiaoVien_NghiViec = oBNS_GiaoVien_NghiViec.GetBy_NS_GiaoienID(NS_GiaoVienID);
            grdGiaoVienNghiViec.DataSource = dtNS_GiaoVien_NghiViec;
        }

        private void SetControl(bool status)
        {
            barbtnSuaQuyetDinh.Enabled = status;
            barbtnXoaQuyetDinh.Enabled = status;
        }

        private void ClearText()
        {
            txtSoQuyetDinh.Text = "";
            cmbHinhThucNghiViec.EditValue = null;
            dtpNgayCoHieuLuc.EditValue = null;
            txtSoQuyetDinh.Focus();
        }
        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (cmbHinhThucNghiViec.EditValue == null)
            {
                dxErrorProvider.SetError(cmbHinhThucNghiViec, "Hình thức nghỉ việc không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbHinhThucNghiViec;
            }
            if (dtpNgayCoHieuLuc.EditValue == null)
            {
                dxErrorProvider.SetError(dtpNgayCoHieuLuc, "Ngày có hiệu lực không thể rỗng.");
                if (CtrlErr == null) CtrlErr = dtpNgayCoHieuLuc;
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
            txtSoQuyetDinh.Text = pNS_GiaoVien_NghiViecInfo.SoQuyetDinh;
            cmbHinhThucNghiViec.EditValue = pNS_GiaoVien_NghiViecInfo.IDNS_HinhThucNghiViec;
            if ("" + drNS_GiaoVien_NghiViec[pNS_GiaoVien_NghiViecInfo.strNgayCoHieuLuc] == "" || (DateTime.Parse(drNS_GiaoVien_NghiViec[pNS_GiaoVien_NghiViecInfo.strNgayCoHieuLuc].ToString()).ToString("dd/MM/yyyy")) == "01/01/1900")
                dtpNgayCoHieuLuc.EditValue = null;
            else
            {
                dtpNgayCoHieuLuc.EditValue = drNS_GiaoVien_NghiViec[pNS_GiaoVien_NghiViecInfo.strNgayCoHieuLuc];
            }
            txtSoQuyetDinh.Focus();
        }

        private void GetpInfo()
        {
            pNS_GiaoVien_NghiViecInfo.IDNS_GiaoVien = NS_GiaoVienID;
            pNS_GiaoVien_NghiViecInfo.SoQuyetDinh = txtSoQuyetDinh.Text;
            pNS_GiaoVien_NghiViecInfo.IDNS_HinhThucNghiViec = cmbHinhThucNghiViec.EditValue.ToString();
            if (dtpNgayCoHieuLuc.EditValue == null)
            {
                pNS_GiaoVien_NghiViecInfo.NgayCoHieuLuc = DateTime.Parse("01/01/1900");
            }
            else
            {
                pNS_GiaoVien_NghiViecInfo.NgayCoHieuLuc = DateTime.Parse(dtpNgayCoHieuLuc.EditValue.ToString());
            }
        }

        private void barbtnThemQuyetDinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdGiaoVienNghiViec.Enabled = false;
            edit = EDIT_MODE.THEM;
            panelTop.Visible = true;
            ClearText();
        }

        private void barbtnSuaQuyetDinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdGiaoVienNghiViec.Enabled = false;
            edit = EDIT_MODE.SUA;
            panelTop.Visible = true;
            SetText();
        }

        private void barbtnXoaQuyetDinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    pNS_GiaoVien_NghiViecInfo.NS_GiaoVien_NghiViecID = int.Parse(drNS_GiaoVien_NghiViec[pNS_GiaoVien_NghiViecInfo.strNS_GiaoVien_NghiViecID].ToString());
                    oBNS_GiaoVien_NghiViec.Delete(pNS_GiaoVien_NghiViecInfo);
                    // ghi log
                    GhiLog("Xóa quyết định nghỉ việc, số quyết dịnh '" + pNS_GiaoVien_NghiViecInfo.SoQuyetDinh + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtNS_GiaoVien_NghiViec.Rows.Remove(drNS_GiaoVien_NghiViec);
                    XoaThanhCong();
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }

        private void dlgGiaoVienNghiViec_Load(object sender, EventArgs e)
        {
            bar2.Visible = true;
            GetGiaoVien_NghiViec();
            cmbHinhThucNghiViec.Properties.DataSource = LoadTHinhThucNghiViec();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckValid()) return;
            try
            {
                GetpInfo();
                if (edit == EDIT_MODE.THEM)
                {
                    pNS_GiaoVien_NghiViecInfo.NS_GiaoVien_NghiViecID = oBNS_GiaoVien_NghiViec.Add(pNS_GiaoVien_NghiViecInfo);
                    GhiLog("Thêm số quyết định nghỉ việc, số quyết định '" + pNS_GiaoVien_NghiViecInfo.SoQuyetDinh + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtNS_GiaoVien_NghiViec.NewRow();
                    oBNS_GiaoVien_NghiViec.ToDataRow(pNS_GiaoVien_NghiViecInfo, ref drNew);
                    dtNS_GiaoVien_NghiViec.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pNS_GiaoVien_NghiViecInfo.NS_GiaoVien_NghiViecID = int.Parse(drNS_GiaoVien_NghiViec[pNS_GiaoVien_NghiViecInfo.strNS_GiaoVien_NghiViecID].ToString());
                    oBNS_GiaoVien_NghiViec.Update(pNS_GiaoVien_NghiViecInfo);
                    GhiLog("Sửa số quyết định nghỉ việc, số quyết định '" + pNS_GiaoVien_NghiViecInfo.SoQuyetDinh + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    oBNS_GiaoVien_NghiViec.ToDataRow(pNS_GiaoVien_NghiViecInfo, ref drNS_GiaoVien_NghiViec);
                    SuaThanhCong();
                    btnHuyBo_Click(null, null);
                }
                GetGiaoVien_NghiViec();
            }
            catch
            {
                ThongBaoLoi("Có lỗi trong quá trình thêm hoặc sửa hoặc ghi log.");
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            grdGiaoVienNghiViec.Enabled = true;
            dxErrorProvider.ClearErrors();
            panelTop.Visible = false;
        }

        private void grvGiaoVienNghiViec_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvGiaoVienNghiViec_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvGiaoVienNghiViec.FocusedRowHandle >= 0)
            {
                drNS_GiaoVien_NghiViec = grvGiaoVienNghiViec.GetDataRow(grvGiaoVienNghiViec.FocusedRowHandle);
                oBNS_GiaoVien_NghiViec.ToInfo(ref pNS_GiaoVien_NghiViecInfo, drNS_GiaoVien_NghiViec);
            }
            if (grvGiaoVienNghiViec != null)
                if (grvGiaoVienNghiViec.DataRowCount > 0 && grvGiaoVienNghiViec.FocusedRowHandle >= 0)
                {
                    SetControl(true);
                    drNS_GiaoVien_NghiViec = grvGiaoVienNghiViec.GetDataRow(grvGiaoVienNghiViec.FocusedRowHandle);
                    return;
                }
            SetControl(false);
            drNS_GiaoVien_NghiViec = null;
        }
    }
}