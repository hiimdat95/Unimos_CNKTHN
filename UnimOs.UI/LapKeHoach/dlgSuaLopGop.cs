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
    public partial class dlgSuaLopGop : frmBase
    {
        string strXL_LopTachGopIDs,TenLopTachGop;
        XL_LopTachGopInfo pXL_LopTachGopInfo;
        cBXL_LopTachGop oBXL_LopTachGop;
        public dlgSuaLopGop(string mIDXL_LopTachGops, string mTenLopTachGop)
        {
            InitializeComponent();
            oBXL_LopTachGop = new cBXL_LopTachGop();
            pXL_LopTachGopInfo = new XL_LopTachGopInfo();
            strXL_LopTachGopIDs = mIDXL_LopTachGops ;
            TenLopTachGop = mTenLopTachGop;
            txtTenLopGop.Text = TenLopTachGop;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckValid()) return;
            // Thiết lập lại giá trị HocOLopTachGop của bảng MonHocTrongKy thành true
            try
            {
                if (txtTenLopGop.Text.Trim() != TenLopTachGop)
                {
                    oBXL_LopTachGop.UpdateTenLopGop(strXL_LopTachGopIDs, txtTenLopGop.Text.Trim());
                    // ghi log
                    GhiLog("Sửa tên lớp gộp '" + TenLopTachGop + "' thành '" + txtTenLopGop.Text + "'", "Sửa", this.Tag.ToString());
                    SuaThanhCong();
                }
            }
            catch (Exception exp)
            {
                ThongBao(exp.Message);
            }

            this.Tag = "1";
            this.Close();
        }
        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtTenLopGop.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTenLopGop, "Bạn chưa nhập dữ liệu.");
                if (CtrlErr == null) CtrlErr = txtTenLopGop;
            }
        
            if ((CtrlErr != null))
                return false;
            else
                return true;
        }
    }
}