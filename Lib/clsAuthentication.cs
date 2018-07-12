using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security;
using System.Security.Cryptography;
using System.Management;
using System.Runtime.InteropServices;
using POSServices.classes;

namespace Lib
{
    public static class clsAuthentication
    {
        [DllImport("TruongViet.dll", EntryPoint = "tvkt")]
        public static extern bool tvkt(string xau);
        [DllImport("TruongViet.dll", EntryPoint = "tvdk")]
        public static extern void tvdk(string xau);
        [DllImport("TruongViet.dll", EntryPoint = "tvkttime")]
        public static extern int tvkttime();
        [DllImport("TruongViet.dll", EntryPoint = "tvdktime")]
        public static extern void tvdktime(string TimeCount);
        [DllImport("TruongViet.dll", EntryPoint = "tvgiamtime")]
        public static extern int tvgiamtime();
        [DllImport("TruongViet.dll", EntryPoint = "tvreadtimecount")]
        public static extern int tvreadtimecount();

        private const string KeyOne = "w1E2r3T4y5U6i7O8";
        private const string KeyTwo = "1111222233334444";

        public static string Decrypt(string str)
        {
            return (new POSServices.classes.Cipher()).Decrypt(str, KeyOne, KeyTwo);
        }

        public static string Encrypt(string str)
        {
            return (new POSServices.classes.Cipher()).Encrypt(str, KeyOne, KeyTwo);
        }
        
        public static string Encrypt()
        {
            string strIn = GetVolumeSerial() + "TVSchool";//FindMACAddress();
            UnicodeEncoding encoding = new UnicodeEncoding();
            Byte[] hashBytes = encoding.GetBytes(strIn);

            // Compute the SHA-1 hash
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            Byte[] cryptPassword = sha1.ComputeHash(hashBytes);

            string strTmp = BitConverter.ToString(cryptPassword).Replace("-", "").Substring(10, 20);
            string strResult = "";
            for (int i = 0; i < strTmp.Length; i++)
                if ((i + 1) % 5 == 0 && i < strTmp.Length - 1)
                    strResult += strTmp[i].ToString() + "-";
                else
                    strResult += strTmp[i].ToString();
            return strResult;
        }

        public static string FindMACAddress()
        {
            ManagementClass mgmt = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objCol = mgmt.GetInstances();
            string address = String.Empty;
            foreach (ManagementObject obj in objCol)
            {
                if (address == String.Empty)  // only return MAC Address from first card
                {
                    if ((bool)obj["IPEnabled"] == true) address = obj["MacAddress"].ToString();
                }
                obj.Dispose();
            }
            address = address.Replace(":", "");
            return address;
        }
        public static string FindIPAddress()
        {
            ManagementClass mgmt = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objCol = mgmt.GetInstances();
            string[] addresses = new  string[objCol.Count] ;
            foreach (ManagementObject obj in objCol)
            {
              
                    if ((bool)obj["IPEnabled"] == true) addresses = (string[])obj["IPAddress"];

                obj.Dispose();
            }
            //address = address.Replace(":", "");
            return "" + addresses[0];
        }

        public static string GetVolumeSerial()
        {
            string Value = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_Processor");

            foreach (ManagementObject share in searcher.Get())
            {
                foreach (PropertyData PC in share.Properties)
                {
                    if (PC.Name == "ProcessorId")
                    {
                        Value = PC.Value.ToString();
                    }
                }
            }
            return Value;
        }
    }
}
