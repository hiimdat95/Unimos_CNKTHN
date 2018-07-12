using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;
using DevExpress.XtraEditors;
using Microsoft.Win32;

namespace UnimOs.Khoa
{
    static class Program
    {
        public static string strRegistryKey = "Software\\TruongViet\\UnimOs";
        public static bool DaDangKy = false;
        public static int SoNgayDungThu = 1;

        public static string MaSanPham = "UnimOs_Khoa";
        public static string MaDangKy = "";

        public static SqlConnection sqlCn;
        public static string Server = ".\\SQL2005";
        public static string DataBase = "UnimOs";
        public static string User = "truongviet";
        public static string Password = "123";

        public static string TenBo = "";
        public static string TenTruong = "";
        public static string DiaChi = "";

        //Biến toàn cục
        public static string NamHoc = "2010-2011";
        public static int IDNamHoc = 8;
        public static int HocKy = 1;
        public static NS_GiaoVienInfo objUserCurrent;

        public static Hashtable htTable = new Hashtable();

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
            Lib.Ini clsIni = new Lib.Ini(Application.StartupPath + "\\unimos.ini");
            if ((SoNgayDungThu > 0) || DaDangKy)
            {
                //GetConn();
                //// Giải mã mật khẩu SQL
                //Password = Lib.clsAuthentication.Decrypt(Password);
                //if (SetConn(Server, DataBase, User, Password) == false)
                //{
                //    frmConfigServer frmConfig = new frmConfigServer();
                //    if (frmConfig.ShowDialog() == DialogResult.OK)
                //    {
                //        //UpdateNewVersion();
                //        Application.Run(new frmMain());
                //    }
                //}
                //else
                //{
                //UpdateNewVersion();
                //Application.Run(new frmMain());
                //}
                Application.Run(new frmMain());
            }
        }

        static void UpdateNewVersion()
        {
            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = "UpdateVersion.exe";
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Không tìm thấy file UpdateVersion.exe trong ứng dụng." + ex.Message);
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
