using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TruongViet.UnimOs.wsBusiness;
using Lib;
using DevExpress.XtraEditors;


namespace UnimOs.Khoa
{
    public partial class frmChangePassword : frmBase
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
           try
           {
                if (!Check_Valid()) return;
                cBwsNS_GiaoVien objUser = new cBwsNS_GiaoVien();
                Program.objUserCurrent.Password = Lib.clsAuthentication.Encrypt(txtMatKhauMoi.Text.Trim());
                objUser.UpdatePassword(Program.objUserCurrent.NS_GiaoVienID, Program.objUserCurrent.Password);
                ThongBao("Đổi mật khẩu thành công!");
                this.Close();
           }
           catch (Exception ex)
           {
               XtraMessageBox.Show(ex.Message);
           }
        }

        private bool Check_Valid()
        {
            bool functionReturnValue = false;
            Control CtrlErr = null;
            if ((DxErrorProvider != null)) DxErrorProvider.Dispose();
            //Kiem tra thông tin nhập vào
            if (Lib.clsAuthentication.Decrypt(Program.objUserCurrent.Password) != txtMatKhauCu.Text.Trim())
            {
                DxErrorProvider.SetError(txtMatKhauCu, "Bạn nhập mật khẩu cũ không đúng.");
                if (CtrlErr == null) CtrlErr = txtMatKhauCu;
            }
            if (txtMatKhauCu.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtMatKhauCu, "Mật khẩu cũ không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMatKhauCu;
            }
            if (txtMatKhauMoi.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtMatKhauMoi, "Mật khẩu mới không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMatKhauMoi;
            }
            if (txtNhapLaiMatKhau.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtNhapLaiMatKhau, "Nhập Lại Mật Khẩu không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtNhapLaiMatKhau;
            }
            if (txtMatKhauMoi.Text.Trim() != txtNhapLaiMatKhau.Text.Trim())
            {
                DxErrorProvider.SetError(txtNhapLaiMatKhau, "Nhập lại mật khẩu phải trùng với mật khẩu mới.");
                if (CtrlErr == null) CtrlErr = txtNhapLaiMatKhau;
            }  
            //Kiểm tra đăng nhập thành công
            if ((CtrlErr != null)) goto QUIT;
            functionReturnValue = true;
            return functionReturnValue;
        QUIT:
            functionReturnValue = false;
            CtrlErr.Focus();
            return functionReturnValue;
        }
    }
}
