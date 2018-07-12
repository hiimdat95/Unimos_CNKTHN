using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Win32;

namespace UnimOs.Khoa
{
    public partial class frmConfigServer : frmBase
    {
        public frmConfigServer()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConfigServer_Load(object sender, EventArgs e)
        {
            try
            {               
                RegistryKey key = Registry.CurrentUser.OpenSubKey(Program.strRegistryKey, true);
                if ((key != null))
                {
                    // lấy tên server
                    byte[] arrServerName = (byte[])key.GetValue("Server", new byte[-1 + 1]);
                    if (arrServerName.Length == 0)
                    {
                        txtTenmaychu.Text = "";
                    }
                    else
                    {
                        txtTenmaychu.Text = System.Text.Encoding.Unicode.GetString(arrServerName);
                    }

                    // lấy tên Database
                    byte[] arrDataBase = (byte[])key.GetValue("Database", new byte[-1 + 1]);
                    if (arrDataBase.Length == 0)
                    {
                        txtTenCSDL.Text = "";
                    }
                    else
                    {
                        txtTenCSDL.Text = System.Text.Encoding.Unicode.GetString(arrDataBase);
                    }

                    // lấy tên User
                    byte[] arrUser = (byte[])key.GetValue("UserSQL", new byte[-1 + 1]);
                    if (arrUser.Length == 0)
                    {
                        txtTaikhoan.Text = "";
                    }
                    else
                    {
                        txtTaikhoan.Text = System.Text.Encoding.Unicode.GetString(arrUser);
                    }

                    // lấy PasswordSQL
                    byte[] arrPassword = (byte[])key.GetValue("PasswordSQL", new byte[-1 + 1]);
                    if (arrPassword.Length == 0)
                    {
                        txtMatkhau.Text = "";
                    }
                    else
                    {
                        string Password = System.Text.Encoding.Unicode.GetString(arrPassword);
                        Password  = Lib.clsAuthentication.Decrypt(Password);
                        txtMatkhau.Text = Password;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }                
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Program.SetConn(txtTenmaychu.Text, txtTenCSDL.Text, txtTaikhoan.Text, txtMatkhau.Text) == true)
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(Program.strRegistryKey, true);
                if (key == null)
                {
                    key = Registry.CurrentUser.CreateSubKey(Program.strRegistryKey);
                }
                try
                {
                    byte[] arrServerName = System.Text.Encoding.Unicode.GetBytes(txtTenmaychu.Text);
                    byte[] arrDataBase = System.Text.Encoding.Unicode.GetBytes(txtTenCSDL.Text);
                    byte[] arrUserSQL = System.Text.Encoding.Unicode.GetBytes(txtTaikhoan.Text);
                    byte[] arrPassword = System.Text.Encoding.Unicode.GetBytes(Lib.clsAuthentication.Encrypt(txtMatkhau.Text));

                    key.SetValue("Server", arrServerName, RegistryValueKind.Binary);
                    key.SetValue("Database", arrDataBase, RegistryValueKind.Binary);
                    key.SetValue("UserSQL", arrUserSQL, RegistryValueKind.Binary);
                    key.SetValue("PasswordSQL", arrPassword, RegistryValueKind.Binary);
                    ThongBao("Lưu thông tin thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    ThongBaoLoi(ex.Message);
                }
                finally
                {
                    if (key != null)
                    {
                        key.Close();
                    }
                }
            }
            else
            {
                ThongBao("Kết nối không thành công! \n Bạn phải kiểm tra kết nối thành công trước khi lưu!");
            }
        }

        private void btnKiemtra_Click(object sender, EventArgs e)
        {
            if (Program.SetConn(txtTenmaychu.Text, txtTenCSDL.Text, txtTaikhoan.Text, txtMatkhau.Text) == true)
            {
                ThongBao("Kết nối thành công!");
            }
            else
            {
                ThongBao("Kết nối không thành công!");
            }
        }
    }
}