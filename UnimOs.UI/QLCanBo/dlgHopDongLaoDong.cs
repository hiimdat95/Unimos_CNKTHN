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
    public partial class dlgHopDongLaoDong : frmBase
    {
        private cBNS_GiaoVien_HDLD oBNS_GiaoVien_HDLD;
        private NS_GiaoVien_HDLDInfo pNS_GiaoVien_HDLDInfo;
        private DataTable dtNS_GiaoVien_HDLD;
        private DataRow drNS_GiaoVien_HDLD;
        private EDIT_MODE edit;
        private int NS_GiaoVienID;

        public dlgHopDongLaoDong(int _NS_GiaoVienID)
        {
            InitializeComponent();
            NS_GiaoVienID = _NS_GiaoVienID;
            oBNS_GiaoVien_HDLD = new cBNS_GiaoVien_HDLD();
            pNS_GiaoVien_HDLDInfo = new NS_GiaoVien_HDLDInfo();
            SetControl(false);
        }

        private void dlgHopDongLaoDong_Load(object sender, EventArgs e)
        {
            bar2.Visible = true;
            DataTable dtHinhThuc = bLoadHinhThucHDLD();
            repositoryItemcmbHinhThucHDLD.DataSource = dtHinhThuc;
            cmbHinhThucHopDong.Properties.DataSource = dtHinhThuc;
            GetHinhThucHopDong();
        }

        private void GetHinhThucHopDong()
        {
            dtNS_GiaoVien_HDLD = oBNS_GiaoVien_HDLD.GetBy_NS_GiaoienID(NS_GiaoVienID);
            grdGiaoVienHDLD.DataSource = dtNS_GiaoVien_HDLD;
        }

        private void SetControl(bool status)
        {
            barbtnSuaHopDong.Enabled = status;
            barbtnXoaHopDong.Enabled = status;
        }

        private void ClearText()
        {
            txtSoHopDong.Text = "";
            cmbHinhThucHopDong.EditValue = null;
            txtSoThangHopDong.Text = "0";
            dtpThoiGianBatDau.EditValue = null;
            dtpThoiGianKetThuc.Checked = false;
            txtGhiChu.Text = "";
            txtSoHopDong.Focus();
        }
        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (cmbHinhThucHopDong.EditValue == null)
            {
                dxErrorProvider.SetError(cmbHinhThucHopDong, "Loại hợp đồng không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbHinhThucHopDong;
            }

            if (txtSoThangHopDong.Text == "")
            {
                dxErrorProvider.SetError(txtSoThangHopDong, "Số tháng hợp đồng không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtSoThangHopDong;
            }
            
            if (dtpThoiGianBatDau.EditValue == null)
            {
                dxErrorProvider.SetError(dtpThoiGianBatDau, "Thời gian bắt đầu không thể rỗng.");
                if (CtrlErr == null) CtrlErr = dtpThoiGianBatDau;
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
            cmbHinhThucHopDong.EditValue = pNS_GiaoVien_HDLDInfo.IDHinhThucHDLD;
            txtSoHopDong.Text = pNS_GiaoVien_HDLDInfo.SoHopDong;
            txtSoThangHopDong.Text = pNS_GiaoVien_HDLDInfo.SoThangHopDong.ToString();
            if ("" + drNS_GiaoVien_HDLD[pNS_GiaoVien_HDLDInfo.strThoiGianBatDau] == "" || (DateTime.Parse(drNS_GiaoVien_HDLD[pNS_GiaoVien_HDLDInfo.strThoiGianBatDau].ToString()).ToString("dd/MM/yyyy")) == "01/01/1900")
                dtpThoiGianBatDau.EditValue = null;
            else
            {
                dtpThoiGianBatDau.EditValue = drNS_GiaoVien_HDLD[pNS_GiaoVien_HDLDInfo.strThoiGianBatDau];
            }
            if ("" + drNS_GiaoVien_HDLD[pNS_GiaoVien_HDLDInfo.strThoiGianKetThuc] == "" || (DateTime.Parse(drNS_GiaoVien_HDLD[pNS_GiaoVien_HDLDInfo.strThoiGianKetThuc].ToString()).ToString("dd/MM/yyyy")) == "31/12/9999")
            {
                dtpThoiGianKetThuc.Value = DateTime.Today;
                dtpThoiGianKetThuc.Checked = false;
            }
            else
            {
                dtpThoiGianKetThuc.Value = DateTime.Parse(drNS_GiaoVien_HDLD[pNS_GiaoVien_HDLDInfo.strThoiGianKetThuc].ToString());
                dtpThoiGianKetThuc.Checked = true;
            }
            txtGhiChu.Text = pNS_GiaoVien_HDLDInfo.GhiChu;
            txtSoHopDong.Focus();
        }

        private void GetpInfo()
        {
            pNS_GiaoVien_HDLDInfo.IDNS_GiaoVien = NS_GiaoVienID;
            pNS_GiaoVien_HDLDInfo.IDHinhThucHDLD = cmbHinhThucHopDong.EditValue.ToString();
            pNS_GiaoVien_HDLDInfo.SoHopDong = txtSoHopDong.Text;
            pNS_GiaoVien_HDLDInfo.SoThangHopDong = int.Parse(txtSoThangHopDong.Text);
            if (dtpThoiGianBatDau.EditValue == null)
            {
                pNS_GiaoVien_HDLDInfo.ThoiGianBatDau = DateTime.Parse("01/01/1900");
            }
            else
            {
                pNS_GiaoVien_HDLDInfo.ThoiGianBatDau = DateTime.Parse(dtpThoiGianBatDau.EditValue.ToString());
            }
            pNS_GiaoVien_HDLDInfo.ThoiGianKetThuc = dtpThoiGianKetThuc.Checked == false ? DateTime.ParseExact("31/12/9999", "dd/MM/yyyy", null) : dtpThoiGianKetThuc.Value;
            pNS_GiaoVien_HDLDInfo.GhiChu = txtGhiChu.Text;
        }

        private void barbtnThemHopDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdGiaoVienHDLD.Enabled = false;
            edit = EDIT_MODE.THEM;
            panelTop.Visible = true;
            ClearText();
        }

        private void barbtnSuaHopDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdGiaoVienHDLD.Enabled = false;
            edit = EDIT_MODE.SUA;
            panelTop.Visible = true;
            SetText();
        }

        private void barbtnXoaHopDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    pNS_GiaoVien_HDLDInfo.NS_GiaoVien_HDLDID = int.Parse(drNS_GiaoVien_HDLD[pNS_GiaoVien_HDLDInfo.strNS_GiaoVien_HDLDID].ToString());
                    oBNS_GiaoVien_HDLD.Delete(pNS_GiaoVien_HDLDInfo);
                    // ghi log
                    GhiLog("Xóa hợp đồng lao động, số hợp đồng '" + pNS_GiaoVien_HDLDInfo.SoHopDong + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtNS_GiaoVien_HDLD.Rows.Remove(drNS_GiaoVien_HDLD);
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
                    pNS_GiaoVien_HDLDInfo.NS_GiaoVien_HDLDID = oBNS_GiaoVien_HDLD.Add(pNS_GiaoVien_HDLDInfo);
                    GhiLog("Thêm hợp đồng lao động, số hợp đồng '" + pNS_GiaoVien_HDLDInfo.SoHopDong + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtNS_GiaoVien_HDLD.NewRow();
                    oBNS_GiaoVien_HDLD.ToDataRow(pNS_GiaoVien_HDLDInfo, ref drNew);
                    dtNS_GiaoVien_HDLD.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pNS_GiaoVien_HDLDInfo.NS_GiaoVien_HDLDID = int.Parse(drNS_GiaoVien_HDLD[pNS_GiaoVien_HDLDInfo.strNS_GiaoVien_HDLDID].ToString());
                    oBNS_GiaoVien_HDLD.Update(pNS_GiaoVien_HDLDInfo);
                    GhiLog("Sử hợp đồng lao động, số hợp đồng '" + pNS_GiaoVien_HDLDInfo.SoHopDong + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    oBNS_GiaoVien_HDLD.ToDataRow(pNS_GiaoVien_HDLDInfo, ref drNS_GiaoVien_HDLD);
                    SuaThanhCong();
                    btnHuyBo_Click(null, null);
                }
                GetHinhThucHopDong();
            }
            catch
            {
                ThongBaoLoi("Có lỗi trong quá trình thêm hoặc sửa hoặc ghi log.");
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            grdGiaoVienHDLD.Enabled = true;
            dxErrorProvider.ClearErrors();
            panelTop.Visible = false;
        }

        private void grvGiaoVienHDLD_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvGiaoVienHDLD_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvGiaoVienHDLD.FocusedRowHandle >= 0)
            {
                drNS_GiaoVien_HDLD = grvGiaoVienHDLD.GetDataRow(grvGiaoVienHDLD.FocusedRowHandle);
                oBNS_GiaoVien_HDLD.ToInfo(ref pNS_GiaoVien_HDLDInfo, drNS_GiaoVien_HDLD);
            }
            if (grvGiaoVienHDLD != null)
                if (grvGiaoVienHDLD.DataRowCount > 0 && grvGiaoVienHDLD.FocusedRowHandle >= 0)
                {
                    SetControl(true);
                    drNS_GiaoVien_HDLD = grvGiaoVienHDLD.GetDataRow(grvGiaoVienHDLD.FocusedRowHandle);
                    return;
                }
            SetControl(false);
            drNS_GiaoVien_HDLD = null;
        }

    }
}