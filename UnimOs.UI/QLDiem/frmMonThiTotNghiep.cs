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
    public partial class frmMonThiTotNghiep : frmBase
    {
        private int status;
        private cBKQHT_MonThiTotNghiep oBKQHT_MonThiTotNghiep;
        private KQHT_MonThiTotNghiepInfo pKQHT_MonThiTotNghiepInfo;
        private DataTable dtMon;
        private DataRow drMon;

        public frmMonThiTotNghiep()
        {
            InitializeComponent();
            pKQHT_MonThiTotNghiepInfo = new KQHT_MonThiTotNghiepInfo();
            oBKQHT_MonThiTotNghiep = new cBKQHT_MonThiTotNghiep();

        }
        private void frmMonThiTotNghiep_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            bar2.Visible = true;
            GetMon();
        }
        private void GetMon()
        {
            dtMon = oBKQHT_MonThiTotNghiep.Get(pKQHT_MonThiTotNghiepInfo);
            grdMon.DataSource = dtMon;
        }
        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearText();
            panelTop.Visible = true;
            txtMaMon.Focus();
            status = 0;
        }
        private void ClearText()
        {
            txtDiem.Text = "";
            txtTenMon.Text = "";
            txtMaMon.Text = "";
            txtSoHocTrinh.Text = "";
            txtMaMon.Focus();
        }
        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Mã và tên hệ không được rỗng
            if ( cbkTinhDiem.Checked == false &&  txtDiem.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtDiem, "Điểm không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtDiem;
            }
            if (txtTenMon.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTenMon, "Tên môn học ko thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenMon;
            }
            if (txtMaMon.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtMaMon, "Mã môn học ko thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenMon;
            }
           
            //Kiểm tra cập nhật thành công
            if ((CtrlErr != null))
                return false;
            else
                return true;
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            status = 1;
            panelTop.Visible = true;
            GetInfo();
        }


        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    grvMon_FocusedRowChanged(null, null);
                    oBKQHT_MonThiTotNghiep.Delete(pKQHT_MonThiTotNghiepInfo);
                    XoaThanhCong();
                    GetMon();
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }

        private void GetInfo()
        {
            txtDiem.Text = pKQHT_MonThiTotNghiepInfo.DiemDieuKien.ToString();
            txtTenMon.Text = pKQHT_MonThiTotNghiepInfo.TenMon;
            txtMaMon.Text = pKQHT_MonThiTotNghiepInfo.MaMon;
            cbkTinhDiem.Checked = pKQHT_MonThiTotNghiepInfo.TinhDiem;
            txtSoHocTrinh.Text = pKQHT_MonThiTotNghiepInfo.SoHocTrinh.ToString();
        }

        private void SetInfo()
        {
            pKQHT_MonThiTotNghiepInfo.TenMon = txtTenMon.Text;
            pKQHT_MonThiTotNghiepInfo.MaMon = txtMaMon.Text;
            pKQHT_MonThiTotNghiepInfo.DiemDieuKien = float.Parse("0" +  txtDiem.Text);
            pKQHT_MonThiTotNghiepInfo.SoHocTrinh = float.Parse("0" + txtSoHocTrinh.Text);
            pKQHT_MonThiTotNghiepInfo.TinhDiem = cbkTinhDiem.Checked ;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!Check_Valid()) return;
            try
            {
                SetInfo();
                if (status == 0)
                {
                    oBKQHT_MonThiTotNghiep.Add(pKQHT_MonThiTotNghiepInfo);
                    ThemThanhCong();
                    drMon = dtMon.NewRow();
                    oBKQHT_MonThiTotNghiep.ToDataRow(pKQHT_MonThiTotNghiepInfo, ref drMon);
                    dtMon.Rows.Add(drMon);
                }
                else
                {
                    oBKQHT_MonThiTotNghiep.Update(pKQHT_MonThiTotNghiepInfo);
                    SuaThanhCong();
                    oBKQHT_MonThiTotNghiep.ToDataRow(pKQHT_MonThiTotNghiepInfo, ref drMon);
                    panelTop.Visible =false;
                }
                ClearText();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dxErrorProvider.ClearErrors();
            panelTop.Visible = false;
        }
        private void grvMon_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
             if (grvMon.FocusedRowHandle >= 0)
             {
                 drMon = grvMon.GetDataRow(grvMon.FocusedRowHandle);
                 oBKQHT_MonThiTotNghiep.ToInfo(ref pKQHT_MonThiTotNghiepInfo, drMon);
             }
        }

        private void grvMon_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }
    }
}