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

namespace UnimOs.UI
{
    public partial class frmLogIn : frmBase
    {
        #region Biến toàn cục
        private int mCountLog = 0;
        private int mMountLog = 3;
        cBHT_User oBHT_User;
        HT_UserInfo pHT_UserInfo;
        #endregion

        public frmLogIn()
        {
            InitializeComponent();
            oBHT_User = new cBHT_User();
            pHT_UserInfo = new HT_UserInfo();
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
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                //Load mật khẩu
                string strRegistryKey = "Software\\TruongViet\\UnimOs";
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
                ThongBaoLoi(ex.Message);
            }
        }

        public void DocThamSoXepLich()
        {
            // Đọc tham số hệ thống
            HT_ThamSoHeThongInfo pThamSoHeThongInfo = new HT_ThamSoHeThongInfo();
            pThamSoHeThongInfo.HT_ThamSoHeThongID = 0;
            DataTable dtThamSo = new cBHT_ThamSoHeThong().Get(pThamSoHeThongInfo);
            DocThamSoXepLich(dtThamSo);
        }

        private void DocThamSoXepLich(DataTable dtThamSo)
        {
            try
            {
                if (dtThamSo.Rows.Count > 0)
                {
                    DataRow[] drThamSo;
                    drThamSo = dtThamSo.Select("MaThamSoHeThong = 'SoTietSang'");
                    if (drThamSo.Length > 0)
                        Program.pgrThamSo.SO_TIET_CASANG = int.Parse(drThamSo[0]["GiaTri"].ToString());

                    drThamSo = dtThamSo.Select("MaThamSoHeThong = 'SoTietChieu'");
                    if (drThamSo.Length > 0)
                        Program.pgrThamSo.SO_TIET_CACHIEU = int.Parse(drThamSo[0]["GiaTri"].ToString());

                    drThamSo = dtThamSo.Select("MaThamSoHeThong = 'SoTietToi'");
                    if (drThamSo.Length > 0)
                        Program.pgrThamSo.SO_TIET_CATOI = int.Parse(drThamSo[0]["GiaTri"].ToString());

                    drThamSo = dtThamSo.Select("MaThamSoHeThong = 'ThuBatDau'");
                    if (drThamSo.Length > 0)
                        Program.pgrThamSo.THU_BAT_DAU = int.Parse(drThamSo[0]["GiaTri"].ToString());

                    drThamSo = dtThamSo.Select("MaThamSoHeThong = 'ThuKetThuc'");
                    if (drThamSo.Length > 0)
                        Program.pgrThamSo.THU_KET_THUC = int.Parse(drThamSo[0]["GiaTri"].ToString());

                    drThamSo = dtThamSo.Select("MaThamSoHeThong = 'SoBuoiHoc'");
                    if (drThamSo.Length > 0)
                        Program.pgrThamSo.SO_BUOI_HOC = int.Parse(drThamSo[0]["GiaTri"].ToString());

                    drThamSo = dtThamSo.Select("MaThamSoHeThong = 'SoNhomTietTrongBuoi'");
                    if (drThamSo.Length > 0)
                        Program.pgrThamSo.SO_NHOMTIET_TRONG_BUOI = int.Parse(drThamSo[0]["GiaTri"].ToString());

                    drThamSo = dtThamSo.Select("MaThamSoHeThong = 'SoNhomTietTrongNgay'");
                    if (drThamSo.Length > 0)
                        Program.pgrThamSo.SO_NHOMTIET_TRONG_NGAY = int.Parse(drThamSo[0]["GiaTri"].ToString());

                    drThamSo = dtThamSo.Select("MaThamSoHeThong = 'SuDungBaoBanTrongXepLich'");
                    if (drThamSo.Length > 0)
                        Program.pgrThamSo.SUDUNG_BAOBAN_TRONG_XEPLICH = int.Parse(drThamSo[0]["GiaTri"].ToString());

                    drThamSo = dtThamSo.Select("MaThamSoHeThong = 'SoTietCacNhom'");
                    if (drThamSo.Length > 0)
                        Program.pgrThamSo.SO_TIET_CAC_NHOM = drThamSo[0]["GiaTri"].ToString();

                    drThamSo = dtThamSo.Select("MaThamSoHeThong = 'ThucHanhTuThu'");
                    if (drThamSo.Length > 0)
                        Program.pgrThamSo.THUCHANH_TU_THU = int.Parse(drThamSo[0]["GiaTri"].ToString());

                    drThamSo = dtThamSo.Select("MaThamSoHeThong = 'ThucHanhDenThu'");
                    if (drThamSo.Length > 0)
                        Program.pgrThamSo.THUCHANH_DEN_THU = int.Parse(drThamSo[0]["GiaTri"].ToString());

                    drThamSo = dtThamSo.Select("MaThamSoHeThong = 'SoTietThucHanhTrong1Tuan'");
                    if (drThamSo.Length > 0)
                        Program.pgrThamSo.SO_TIET_THUCHANH_TRONGTUAN = int.Parse(drThamSo[0]["GiaTri"].ToString());
                }
            }
            catch (Exception ex)
            {
                ThongBaoLoi(ex.Message);
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
                    DocThamSoXepLich();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ThongBaoLoi(ex.Message);
            }
        }

        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if (DxErrorProvider != null) DxErrorProvider.Dispose();
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
            string strRegistryKey = "Software\\TruongViet\\UnimOs";            
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
            DataTable dt = oBHT_User.GetByUserName(UserName.Trim());
            if (dt.Rows.Count > 0)
            {
                if (Lib.clsAuthentication.Decrypt(dt.Rows[0]["Password"].ToString()) == Password)
                {
                    oBHT_User.ToInfo(ref pHT_UserInfo, dt.Rows[0]);
                    Program.objUserCurrent = pHT_UserInfo;
                    return true;
                }
            }
            return false;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConfigServer_Click(object sender, EventArgs e)
        {
            frmConfigServer frm = new frmConfigServer();
            frm.ShowDialog();
        }
    }
}