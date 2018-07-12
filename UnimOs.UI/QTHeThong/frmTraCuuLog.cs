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
using Lib;

namespace UnimOs.UI 
{
    public partial class frmTraCuuLog : frmBase
    {
        private cBHT_PhanHe oBPhanHe;
        private HT_PhanHeInfo pPhanHeInfo;
        private cBHT_ChucNang oBChucNang;
        private HT_ChucNangInfo pChucNangInfo;
        private HT_LogInfo pHT_LogInfo;
        private cBHT_Log oBHT_Log;
        private cBHT_User oBHT_User;
        private HT_UserInfo pHT_UserInfo;

        public frmTraCuuLog()
        {
            InitializeComponent();
         
            oBPhanHe = new cBHT_PhanHe();
            pPhanHeInfo = new HT_PhanHeInfo();
            oBChucNang = new cBHT_ChucNang();
            pChucNangInfo = new HT_ChucNangInfo();
            pHT_LogInfo = new HT_LogInfo();
            oBHT_Log = new cBHT_Log();
            pHT_UserInfo = new HT_UserInfo();
            oBHT_User = new cBHT_User();
        }

        private void frmTraCuuLog_Load(object sender, EventArgs e)
        {
            
            // do du lieu vao combobox
            DataTable dtTemp;

            dtTemp = oBChucNang.Get(pChucNangInfo);
            if (dtTemp != null)
                cmbChucNang.Properties.DataSource = dtTemp;

            dtTemp = oBPhanHe.Get(pPhanHeInfo);
            if (dtTemp != null)
                cmbPhanHe.Properties.DataSource = dtTemp;

            dtTemp = oBHT_User.Get(pHT_UserInfo);
            if (dtTemp != null)
                cmbNguoiDung.Properties.DataSource = dtTemp;

            dtpTuNgay.EditValue = DateTime.Now;
            dtpDenNgay.EditValue = DateTime.Now;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dtTemp = oBHT_Log.Search(cmbPhanHe.EditValue == null ? -1 : int.Parse(cmbPhanHe.EditValue.ToString()),
                cmbChucNang.EditValue == null ? -1 : int.Parse(cmbChucNang.EditValue.ToString()), cmbSuKien.Text,
                cmbNguoiDung.EditValue == null ? "" : cmbNguoiDung.GetColumnValue("UserName").ToString(), txtNoiDung.Text.Trim(),
                 DateTime.Parse(dtpTuNgay.EditValue.ToString()), DateTime.Parse(dtpDenNgay.EditValue.ToString()));
            if (dtTemp != null)
                grdLog.DataSource = dtTemp;
            else
                grdLog.DataSource = null;

        }
        private void grvLog_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnXoaLog_Click(object sender, EventArgs e)
        {
            if (grvLog.SelectedRowsCount > 0)
            {
                if (ThongBaoChon("Bạn có chắc chắn muốn xóa?") == DialogResult.Yes)
                {
                    foreach (int i in grvLog.GetSelectedRows())
                    {
                        pHT_LogInfo.HT_LogID =int.Parse(grvLog.GetDataRow(i)["HT_LogID"].ToString());
                        oBHT_Log.Delete(pHT_LogInfo);
                    }
                    btnSearch_Click(null, null);
                    XoaThanhCong();
                }
            }
            else
                ThongBao("Bạn phải chọn ít nhất 1 dòng dữ liệu!");
        }

        private void cmbPhanHe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbPhanHe.EditValue = null;
        }

        private void cmbSuKien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbSuKien.EditValue = null;
        }

        private void cmbNguoiDung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbNguoiDung.EditValue = null;
        }

        private void cmbChucNang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbChucNang.EditValue = null;
        }
    }
}