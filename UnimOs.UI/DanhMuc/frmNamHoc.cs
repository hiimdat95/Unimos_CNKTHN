using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;
using DevExpress.XtraEditors;

namespace UnimOs.UI
{
    public partial class frmNamHoc : frmBase
    {
        private cBDM_NamHoc oBNamHoc;
        private DM_NamHocInfo pNamHocInfo;
        List<DM_NamHocInfo> lstNamHoc;
        int status = 0;
        int IndexList;
        public frmNamHoc()
        {
            InitializeComponent();
            oBNamHoc = new cBDM_NamHoc();
            pNamHocInfo = new DM_NamHocInfo();
            lstNamHoc = new List<DM_NamHocInfo>();
        }
        private void frmNamHoc_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            try
            {
                SetControl(false);
                cmbKy2TuTuan.Properties.DataSource = ListTuan();
                GetData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void GetData()
        {
            lstNamHoc = oBNamHoc.GetList(pNamHocInfo);
            grdNamHoc.DataSource = lstNamHoc;
            if (grvNamHoc.RowCount > 0)
            {
                SetControl(true);
            }
            else
            {
                SetControl(false);
            }
        }

        private void SetControl(bool val)
        {
            barbtnSua.Enabled = val;
            barbtnXoa.Enabled = val;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelTop.Visible = true;
            status = 0;
            ClearText();
        }   

        private void ClearText()
        {
            txtNamHoc.Text = "";
            dtpTuNgay.EditValue = DateTime.Today.AddYears(-1);
            dtpDenNgay.EditValue = DateTime.Today;
            cmbKy2TuTuan.EditValue = null;
        }

        private void grvNamHoc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                SetControl(true);
                pNamHocInfo = (DM_NamHocInfo)grvNamHoc.GetRow(grvNamHoc.FocusedRowHandle);
                IndexList = lstNamHoc.IndexOf(pNamHocInfo);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            status = 1;
            panelTop.Visible = true;
            txtNamHoc.Text = pNamHocInfo.TenNamHoc;
            dtpTuNgay.EditValue = pNamHocInfo.TuNgay;
            dtpDenNgay.EditValue = pNamHocInfo.DenNgay;
            cmbKy2TuTuan.EditValue = oBNamHoc.GetKy2(pNamHocInfo);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Check_Valid()) return;
                if (status == 0)
                {
                    pNamHocInfo.DM_NamHocID = oBNamHoc.Add(GetpNamHoc());
                    lstNamHoc.Add(pNamHocInfo);
                    SetSelectedRow(grvNamHoc, grvNamHoc.DataRowCount);
                    // ghi log
                    GhiLog("Thêm năm học '" + pNamHocInfo.TenNamHoc + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    ThemThanhCong();
                }
                else
                {
                    oBNamHoc.Update(GetpNamHoc());
                    lstNamHoc[IndexList] = pNamHocInfo;
                    SetSelectedRow(grvNamHoc, IndexList);
                    // ghi log
                    GhiLog("Sửa năm học '" + pNamHocInfo.TenNamHoc + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    SuaThanhCong();
                }
                oBNamHoc.TaoKeHoachTuan(pNamHocInfo.DM_NamHocID, (DateTime)dtpTuNgay.EditValue, (DateTime)dtpDenNgay.EditValue, int.Parse(cmbKy2TuTuan.Text));
                pNamHocInfo.DM_NamHocID = 0;
                GetData();
                ClearText();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private DM_NamHocInfo GetpNamHoc()
        {
            pNamHocInfo.TenNamHoc = txtNamHoc.Text;
            pNamHocInfo.TuNgay = ((DateTime)dtpTuNgay.EditValue).Date;
            pNamHocInfo.DenNgay = ((DateTime)dtpDenNgay.EditValue).Date;
            return pNamHocInfo;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            panelTop.Visible = false;
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    if (pNamHocInfo.DM_NamHocID > 0)
                    {
                        oBNamHoc.Delete(pNamHocInfo);
                        // ghi log
                        GhiLog("Xóa năm học '" + pNamHocInfo.TenNamHoc + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                        pNamHocInfo.DM_NamHocID = 0;
                        GetData();
                        XoaThanhCong();
                    }
                    else
                        ThongBao("Bạn chưa chọn năm học nào!");
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }

        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((DxErrorProvider != null)) DxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtNamHoc.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtNamHoc, "Năm học không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtNamHoc;
            }
            if (dtpTuNgay.Text == string.Empty)
            {
                DxErrorProvider.SetError(dtpTuNgay, "Ngày bắt đầu không thể rỗng.");
                if (CtrlErr == null) CtrlErr = dtpTuNgay;
            }
            if (dtpDenNgay.Text == string.Empty)
            {
                DxErrorProvider.SetError(dtpDenNgay, "Ngày kết thúc không thể rỗng.");
                if (CtrlErr == null) CtrlErr = dtpDenNgay;
            }
            if (cmbKy2TuTuan.ItemIndex == -1)
            {
                DxErrorProvider.SetError(cmbKy2TuTuan, "Bạn phải xác định thời điểm bắt đầu của kỳ 2.");
                if (CtrlErr == null) CtrlErr = cmbKy2TuTuan;
            }
            //Kiểm tra thông tin thành công
            if ((CtrlErr != null))
            {
                CtrlErr.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }       
    }
}
