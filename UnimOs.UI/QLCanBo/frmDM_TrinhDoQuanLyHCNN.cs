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
    public partial class frmDM_TrinhDoQuanLyHCNN : frmBase
    {
        private cBDM_TrinhDoQuanLyHanhChinhNhaNuoc oBDM_TrinhDoQuanLyHanhChinhNhaNuoc;
        private DM_TrinhDoQuanLyHanhChinhNhaNuocInfo pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo;
        private DataTable dtTrinhDoQuanLyHanhChinhNhaNuoc;
        private DataRow drTrinhDoQuanLyHanhChinhNhaNuoc;
        private EDIT_MODE edit;
        public frmHoSoGiaoVien ofrmHoSoGiaoVien;

        public frmDM_TrinhDoQuanLyHCNN(frmHoSoGiaoVien _frmHoSoGiaoVien)
        {
            InitializeComponent();
            oBDM_TrinhDoQuanLyHanhChinhNhaNuoc = new cBDM_TrinhDoQuanLyHanhChinhNhaNuoc();
            pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo = new DM_TrinhDoQuanLyHanhChinhNhaNuocInfo();
            SetControl(false);
            ofrmHoSoGiaoVien = _frmHoSoGiaoVien;
        }

        private void GetdtTrinhDoQuanLyHanhChinhNhaNuoc()
        {
            pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.DM_TrinhDoQuanLyHanhChinhNhaNuocID = 0;
            dtTrinhDoQuanLyHanhChinhNhaNuoc = oBDM_TrinhDoQuanLyHanhChinhNhaNuoc.Get(pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo);
            grdTrinhDoQuanLyHCNN.DataSource = dtTrinhDoQuanLyHanhChinhNhaNuoc;
        }

        private void ClearText()
        {
            txttrinhDoQuanLyHCNN.Text = "";
            txttrinhDoQuanLyHCNN.Focus();
        }
        private void SetControl(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txttrinhDoQuanLyHCNN.Text == string.Empty)
            {
                dxErrorProvider.SetError(txttrinhDoQuanLyHCNN, "Tên trình độ quản lý hành chính nhà nước không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txttrinhDoQuanLyHCNN;
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
            txttrinhDoQuanLyHCNN.Text = pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.TenTrinhDoQuanLyHanhChinhNhaNuoc;
            txttrinhDoQuanLyHCNN.Focus();
        }

        private void GetpInfo()
        {
            pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.TenTrinhDoQuanLyHanhChinhNhaNuoc = txttrinhDoQuanLyHCNN.Text;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdTrinhDoQuanLyHCNN.Enabled = false;
            edit = EDIT_MODE.THEM;
            panelTop.Visible = true;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdTrinhDoQuanLyHCNN.Enabled = false;
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
                    pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.DM_TrinhDoQuanLyHanhChinhNhaNuocID = int.Parse(drTrinhDoQuanLyHanhChinhNhaNuoc[pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.strDM_TrinhDoQuanLyHanhChinhNhaNuocID].ToString());
                    oBDM_TrinhDoQuanLyHanhChinhNhaNuoc.Delete(pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo);
                    // ghi log
                    GhiLog("Xóa trình độ quản lý nhà nước '" + pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.TenTrinhDoQuanLyHanhChinhNhaNuoc + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtTrinhDoQuanLyHanhChinhNhaNuoc.Rows.Remove(drTrinhDoQuanLyHanhChinhNhaNuoc);
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
                    pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.DM_TrinhDoQuanLyHanhChinhNhaNuocID = oBDM_TrinhDoQuanLyHanhChinhNhaNuoc.Add(pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo);
                    GhiLog("Thêm trình độ quản lý nhà nước '" + pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.TenTrinhDoQuanLyHanhChinhNhaNuoc + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtTrinhDoQuanLyHanhChinhNhaNuoc.NewRow();
                    oBDM_TrinhDoQuanLyHanhChinhNhaNuoc.ToDataRow(pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo, ref drNew);
                    dtTrinhDoQuanLyHanhChinhNhaNuoc.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.DM_TrinhDoQuanLyHanhChinhNhaNuocID = int.Parse(drTrinhDoQuanLyHanhChinhNhaNuoc[pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.strDM_TrinhDoQuanLyHanhChinhNhaNuocID].ToString());
                    oBDM_TrinhDoQuanLyHanhChinhNhaNuoc.Update(pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo);
                    GhiLog("Sửa trình độ quản lý nhà nước '" + pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.TenTrinhDoQuanLyHanhChinhNhaNuoc + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    drTrinhDoQuanLyHanhChinhNhaNuoc[pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.strTenTrinhDoQuanLyHanhChinhNhaNuoc] = txttrinhDoQuanLyHCNN.Text;
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
            grdTrinhDoQuanLyHCNN.Enabled = true;
            dxErrorProvider.ClearErrors();
            panelTop.Visible = false;
        }

        private void grvTrinhDoQuanLyHCNN_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvTrinhDoQuanLyHCNN.FocusedRowHandle >= 0)
            {
                drTrinhDoQuanLyHanhChinhNhaNuoc = grvTrinhDoQuanLyHCNN.GetDataRow(grvTrinhDoQuanLyHCNN.FocusedRowHandle);
                oBDM_TrinhDoQuanLyHanhChinhNhaNuoc.ToInfo(ref pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo, drTrinhDoQuanLyHanhChinhNhaNuoc);
                if (ofrmHoSoGiaoVien != null)
                {
                    ofrmHoSoGiaoVien.IDDM_TrinhDoQuanLyHanhChinhNhaNuoc = int.Parse(drTrinhDoQuanLyHanhChinhNhaNuoc[pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.strDM_TrinhDoQuanLyHanhChinhNhaNuocID].ToString());
                }
            }
            if (grvTrinhDoQuanLyHCNN != null)
                if (grvTrinhDoQuanLyHCNN.DataRowCount > 0 && grvTrinhDoQuanLyHCNN.FocusedRowHandle >= 0)
                {
                    SetControl(true);
                    drTrinhDoQuanLyHanhChinhNhaNuoc = grvTrinhDoQuanLyHCNN.GetDataRow(grvTrinhDoQuanLyHCNN.FocusedRowHandle);
                    return;
                }
            SetControl(false);
            drTrinhDoQuanLyHanhChinhNhaNuoc = null;
        }

        private void grvTrinhDoQuanLyHCNN_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void frmDM_TrinhDoQuanLyHCNN_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            GetdtTrinhDoQuanLyHanhChinhNhaNuoc();
        }
    }
}