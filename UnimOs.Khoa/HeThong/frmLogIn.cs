using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Win32;
using Lib;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;
using System.Collections;

namespace UnimOs.Khoa
{
    public partial class frmLogIn : frmBase
    {
        #region Biến toàn cục
        private int mCountLog = 0;
        private int mMountLog = 3;
        cBNS_GiaoVien oBNS_GiaoVien;
        NS_GiaoVienInfo pNS_GiaoVienInfo;
        #endregion

        public frmLogIn()
        {
            InitializeComponent();
            oBNS_GiaoVien = new cBNS_GiaoVien();
            pNS_GiaoVienInfo = new NS_GiaoVienInfo();
            LoadData();
        }
        // Hàm này để set form không cho di chuyển
        //protected override void WndProc(ref Message m)
        //{
        //    const int WM_NCLBUTTONDOWN = 161;
        //    const int WM_SYSCOMMAND = 274;
        //    const int HTCAPTION = 2;
        //    const int SC_MOVE = 61456;

        //    if ((m.Msg == WM_SYSCOMMAND) && (m.WParam.ToInt32() == SC_MOVE))
        //        return;
        //    if ((m.Msg == WM_NCLBUTTONDOWN) && (m.WParam.ToInt32() == HTCAPTION))
        //        return;

        //    base.WndProc(ref m);
        //}


        private void frmLogIn_Load(object sender, EventArgs e)
        {
            
        }
        private void LoadData()
        {
            try
            {
                //Load mật khẩu
                string strRegistryKey = "Software\\TruongViet\\UnimOs_Khoa";
                RegistryKey key = Registry.CurrentUser.OpenSubKey(strRegistryKey, true);
                if ((key != null))
                {
                    // lấy tên đăng nhập
                    byte[] arrUsername = (byte[])key.GetValue("UserName", new byte[-1 + 1]);
                    if (arrUsername.Length == 0)
                    {
                        UserName.Text = "";
                    }
                    else
                    {
                        UserName.Text = System.Text.Encoding.Unicode.GetString(arrUsername);
                    }
                    // giải mã mật khẩu lưu trong registry
                    byte[] arrPassword = (byte[])key.GetValue("PassWord", new byte[-1 + 1]);
                    if (arrPassword.Length == 0)
                    {
                        Password.Text = "";
                        return;
                    }
                    Password.Text = Lib.clsAuthentication.Decrypt(System.Text.Encoding.Unicode.GetString(arrPassword));
                    checkNhoMatKhau.Checked = true;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }                
         
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Check_Valid()) return;
                if (!CheckLogIn(UserName.Text, Password.Text))
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.");
                    mCountLog += 1;
                    if (mCountLog == mMountLog)
                    {
                        MessageBox.Show("Bạn đã đăng nhập " + mMountLog.ToString() + " lần không thành công.\n Chương trình sẽ kết thúc.");
                        Application.Exit();
                    }
                }
                else
                {

                    //Lưu thông tin đăng nhập
                    SaveRegeditLoginInfo();
                    Hashtable hTable = new Hashtable();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((DxErrorProvider != null)) DxErrorProvider.Dispose();
            //Tên đăng nhập không được rỗng
            if (UserName.Text == string.Empty)
            {
                DxErrorProvider.SetError(UserName, "Tên đăng nhập không thể rỗng.");
                if (CtrlErr == null) CtrlErr = UserName;
            }
            if (Password.Text == string.Empty)
            {
                DxErrorProvider.SetError(Password, "Mật khẩu không thể rỗng.");
                if (CtrlErr == null) CtrlErr = Password;
            }
            //Kiểm tra đăng nhập thành công
            if (CtrlErr != null)
            {
                CtrlErr.Focus();
                return false;
            }
            return true;
        }
        /// <summary>
        /// Save to regedit info login
        /// </summary>
        /// <remarks></remarks>
        private void SaveRegeditLoginInfo()
        {
            string strRegistryKey = "Software\\TruongViet\\UnimOs_Khoa";            
            if (checkNhoMatKhau.Checked)
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(strRegistryKey, true);
                if (key == null)
                {
                    key = Registry.CurrentUser.CreateSubKey(strRegistryKey);
                }
                try
                {
                    byte[] arrUsername = System.Text.Encoding.Unicode.GetBytes(UserName.Text);
                    byte[] arrPasword = System.Text.Encoding.Unicode.GetBytes(Lib.clsAuthentication.Encrypt(Password.Text));
                    // Lưu tên đăng nhập
                    key.SetValue("UserName", arrUsername, RegistryValueKind.Binary);
                    // Lưu mật khẩu
                    key.SetValue("PassWord", arrPasword, RegistryValueKind.Binary);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
                RegistryKey key = Registry.CurrentUser.OpenSubKey(strRegistryKey, true);
                if (key == null)
                {
                    key = Registry.CurrentUser.CreateSubKey(strRegistryKey);
                }
                try
                {
                    key.SetValue("UserName", new byte[-1 + 1]);
                    key.SetValue("PassWord", new byte[-1 + 1]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (key != null)
                    {
                        key.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Kiểm tra đăng nhập
        /// </summary>
        /// <param name="UserName">Tên đăng nhập</param>
        /// <param name="Password">Mật khẩu</param>
        /// <param name="lstUsers">Danh sách người dùng</param>
        /// <param name="objUser">Đối tượng người dùng</param>
        /// <returns>True/False</returns>
        /// <remarks></remarks>
        private bool CheckLogIn(string UserName, string Password)
        {
            DataTable dtGiaoVien = oBNS_GiaoVien.GetByUsername(UserName);
            if (dtGiaoVien.Rows.Count > 0)
            {
                if (Lib.clsAuthentication.Decrypt("" + dtGiaoVien.Rows[0]["Password"]) == Password)
                {
                    oBNS_GiaoVien.ToInfo(ref pNS_GiaoVienInfo, dtGiaoVien.Rows[0]);
                    Program.objUserCurrent = pNS_GiaoVienInfo;
                    return true;
                }
            }
            return false;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {          
                //this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                //this.Close();           
            Application.Exit();
        }

        private void btnConfigServer_Click(object sender, EventArgs e)
        {
            frmConfigServer frm = new frmConfigServer();
            frm.ShowDialog();
        }
    }
}