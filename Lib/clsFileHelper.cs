using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Lib
{
    class clsFileHelper
    {
    }

    public class Ini
    {
        //Muốn sử dụng thì cứ khai báo:
        //Ini ini=new Ini("ex.ini");
        //ini.WriteValue("aa","bb","noi dung"); //Ghi vào Ini
        //string st=ini.ReadValue("aa","bbb"); //Đọc từ Ini
        private string path;
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        
        public Ini(string path_ini)
        {
            path = path_ini;
        }

        public string ReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, this.path);
            return temp.ToString();
        }

        public void WriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.path);
        }
    }    
}
