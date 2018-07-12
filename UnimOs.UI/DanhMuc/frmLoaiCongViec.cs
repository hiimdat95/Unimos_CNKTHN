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
    public partial class frmLoaiCongViec : frmBase
    {        
        private cBDM_LoaiCongViec oBLoaiCongViec;
        private DM_LoaiCongViecInfo pLoaiCongViecInfo;
        int status = 0;
        int index;
        private DataRow drLoaiCongViec;

        public frmLoaiCongViec()
        {
            InitializeComponent();
            oBLoaiCongViec = new cBDM_LoaiCongViec();
            pLoaiCongViecInfo = new DM_LoaiCongViecInfo();
            panelTop.Visible = false;
        }
        private void frmTrinhDo_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            try
            {
                SetControl(false);
                GetData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void SetControl(bool val)
        {
            barbtnSua.Enabled = val;
            barbtnXoa.Enabled = val;
        }

        private void GetData()
        {
            grdLoaiCongViec.DataSource = oBLoaiCongViec.Get(pLoaiCongViecInfo);
            if (grvLoaiCongViec.RowCount > 0)
            {
                SetControl(true);
            }
            else
            {
                SetControl(false);
            }
        }     

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelTop.Visible = true;
            status = 0;
            ClearText();
        }

        private void ClearText()
        {
            txtTenCongViec.Text = "";
            txtSoLuong.Text = "";
            txtDonVi.Text = "";
            txtQuyChuan.Text = "";
        }

        private void grvHeDaoTao_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (grvLoaiCongViec.DataRowCount > 0)
                {
                    SetControl(true);
                    index = grvLoaiCongViec.FocusedRowHandle;
                    drLoaiCongViec = grvLoaiCongViec.GetDataRow(index);
                    pLoaiCongViecInfo.DM_LoaiCongViecID = (int)drLoaiCongViec["DM_LoaiCongViecID"];
                    pLoaiCongViecInfo.TenLoaiCongViec = drLoaiCongViec[pLoaiCongViecInfo.strTenLoaiCongViec].ToString();
                    pLoaiCongViecInfo.DonVi = drLoaiCongViec["DonVi"].ToString();
                    pLoaiCongViecInfo.QuyChuan = (double)drLoaiCongViec["QuyChuan"];
                    pLoaiCongViecInfo.SoLuong = (double)drLoaiCongViec["SoLuong"];
                }
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
            txtTenCongViec.Text = pLoaiCongViecInfo.TenLoaiCongViec;
            txtSoLuong.Text = pLoaiCongViecInfo.SoLuong.ToString();
            txtDonVi.Text = pLoaiCongViecInfo.DonVi;
            txtQuyChuan.Text = pLoaiCongViecInfo.QuyChuan.ToString();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {                
                if (!Check_Valid()) return;
                if (status == 0)
                {
                    oBLoaiCongViec.Add(GetpLoaiCongViec());
                    // ghi log
                    GhiLog("Thêm loại công việc'" + pLoaiCongViecInfo.TenLoaiCongViec + "'", "Thêm", this.Tag.ToString());
                    ThemThanhCong();
                }
                else
                {
                    if (status == 1)
                    {
                        oBLoaiCongViec.Update(GetpLoaiCongViec());
                        // ghi log
                        GhiLog("Sửa loại công việc '" + pLoaiCongViecInfo.TenLoaiCongViec + "'", "Sửa", this.Tag.ToString());
                        SuaThanhCong();
                    }
                }
                pLoaiCongViecInfo.DM_LoaiCongViecID = 0;
                GetData();                
                ClearText();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    if (pLoaiCongViecInfo.DM_LoaiCongViecID > 0)
                    {
                        oBLoaiCongViec.Delete(pLoaiCongViecInfo);
                        pLoaiCongViecInfo.DM_LoaiCongViecID = 0;
                        GetData();                        
                        // ghi log
                        GhiLog("Xóa loại công việc '" + pLoaiCongViecInfo.TenLoaiCongViec + "'", "Xóa", this.Tag.ToString());
                        XoaThanhCong();
                    }
                    else
                        CanhBao("Bạn chưa chọn loại công việc!");
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }

        private DM_LoaiCongViecInfo GetpLoaiCongViec()
        {
            pLoaiCongViecInfo.DonVi = txtDonVi.Text;
            pLoaiCongViecInfo.QuyChuan = Math.Abs(double.Parse(txtQuyChuan.Text));
            pLoaiCongViecInfo.SoLuong = Math.Abs(double.Parse(txtSoLuong.Text));
            pLoaiCongViecInfo.TenLoaiCongViec = txtTenCongViec.Text.Trim();            
            return pLoaiCongViecInfo;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            panelTop.Visible = false;
            ClearText();
            DxErrorProvider.ClearErrors();
        }

        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((DxErrorProvider != null)) DxErrorProvider.Dispose();            
            
            //Mã trình độ đào tạo không được rỗng
            if (txtTenCongViec.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtTenCongViec, "Tên công việc không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenCongViec;
            }
            if (txtSoLuong.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtSoLuong, "Số lượng không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtSoLuong;
            }

            if (txtQuyChuan.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtQuyChuan, "Quy chuẩn không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtQuyChuan;
            }
            if (txtDonVi.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtDonVi, "Đơn vị không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtDonVi;
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
    }
}
