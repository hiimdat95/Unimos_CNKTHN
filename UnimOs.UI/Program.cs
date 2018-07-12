using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;
using Microsoft.Win32;
using DevExpress.XtraEditors;
using System.Collections;

namespace UnimOs.UI
{
    static class Program
    {
        public static string strRegistryKey = "Software\\TruongViet\\UnimOs";
        public static bool DaDangKy = false;
        public static int SoNgayDungThu = 1;

        public static string MaSanPham = "UnimOs";
        public static string MaDangKy = "";

        public static SqlConnection sqlCn;
        public static string Server = ".\\SQL2005";
        public static string DataBase = "UnimOs";
        public static string User = "truongviet";
        public static string Password = "123";

        public static string TenBo = "";
        public static string TenTruong = "";
        public static string DiaChi = "";

        public static DateTime TuNgay = DateTime.Parse("10/8/2009");
        public static DateTime DenNgay = DateTime.Parse("8/8/2010");
        //Biến toàn cục
        public static string NamHoc = "2009-2010";
        public static int IDNamHoc = 3;
        public static int HocKy = 1;
        public static HT_ThamSoXepLichInfo pgrThamSo;
        public static HT_UserInfo objUserCurrent;

        public static Hashtable htTable = new Hashtable();

        public static string DuongDanThuMucBaoCao = Properties.Settings.Default.DuongDanThuMucBaoCao;
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //// Kiem tra ban quyen
            //cXacThucWinForms.KhoiTao(MaSanPham, ref MaDangKy);
            //if (!cXacThucWinForms.KiemTraDaDangKyBanQuyen())
            //{
            //    frmDangKy frmDangKy = new frmDangKy();
            //    frmDangKy.ShowDialog();
            //    if ((int)frmDangKy.Tag == -1)
            //        return;
            //}
            //else
            //{
            //    DaDangKy = true;
            //}
            if ((SoNgayDungThu > 0) || DaDangKy)
            {
                GetConn();
                // Giải mã mật khẩu SQL
                Password = Lib.clsAuthentication.Decrypt(Password);
                if (SetConn(Server, DataBase, User, Password) == false)
                {
                    frmConfigServer frmConfig = new frmConfigServer();
                    if (frmConfig.ShowDialog() == DialogResult.OK)
                        Application.Run(new frmMain());
                }
                else
                    Application.Run(new frmMain());
            }
        }

        static void GetConn()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(strRegistryKey, true);
                if ((key != null))
                {
                    // lấy tên server
                    byte[] arrServerName = (byte[])key.GetValue("Server", new byte[-1 + 1]);
                    if (arrServerName.Length == 0)
                    {
                        Server = "";
                    }
                    else
                    {
                        Server = System.Text.Encoding.Unicode.GetString(arrServerName);
                    }

                    // lấy tên Database
                    byte[] arrDataBase = (byte[])key.GetValue("Database", new byte[-1 + 1]);
                    if (arrDataBase.Length == 0)
                    {
                        DataBase = "";
                    }
                    else
                    {
                        DataBase = System.Text.Encoding.Unicode.GetString(arrDataBase);
                    }

                    // lấy tên User
                    byte[] arrUser = (byte[])key.GetValue("UserSQL", new byte[-1 + 1]);
                    if (arrUser.Length == 0)
                    {
                        User = "";
                    }
                    else
                    {
                        User = System.Text.Encoding.Unicode.GetString(arrUser);
                    }

                    // lấy PasswordSQL
                    byte[] arrPassword = (byte[])key.GetValue("PasswordSQL", new byte[-1 + 1]);
                    if (arrPassword.Length == 0)
                    {
                        Password = "";
                    }
                    else
                    {
                        Password = System.Text.Encoding.Unicode.GetString(arrPassword);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        public static bool SetConn(string _Server, string _DataBase, string _User, string _Password)
        {
            try
            {
                sqlCn = new SqlConnection();
                sqlCn.ConnectionString = "Server=" + _Server + "; Database=" + _DataBase + "; UID=" + _User + "; PWD=" + _Password;
                TruongViet.UnimOs.Data.cDBase.sqlCn = sqlCn;
                TruongViet.UnimOs.Data.cDBase.sqlCn.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
