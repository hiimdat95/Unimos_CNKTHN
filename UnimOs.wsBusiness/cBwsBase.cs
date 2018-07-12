using System;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.wsBusiness;

namespace TruongViet.UnimOs.wsBusiness
{
    public class cBwsBase
    {
        protected string mErrorMessage;
        protected int mErrorNumber;

        public int ErorrNumber
        {
            get
            {
                return mErrorNumber;
            }
        }

        public string ErrorMessages
        {
            get
            {
                return mErrorMessage;
            }
        }

        public string GetThu(int Thu)
        {
            string strThu = "";
            switch (Thu)
            {
                case 0:
                    strThu = "Chủ nhật";
                    break;
                case 1:
                    strThu = "Thứ 2";
                    break;
                case 2:
                    strThu = "Thứ 3";
                    break;
                case 3:
                    strThu = "Thứ 4";
                    break;
                case 4:
                    strThu = "Thứ 5";
                    break;
                case 5:
                    strThu = "Thứ 6";
                    break;
                case 6:
                    strThu = "Thứ 7";
                    break;
            }
            return strThu;
        }

        public string GetCa(int CaHoc)
        {
            string strCa = "";
            switch (CaHoc)
            {
                case 0:
                    strCa = "Sáng";
                    break;
                case 1:
                    strCa = "Chiều";
                    break;
                case 2:
                    strCa = "Tối";
                    break;
                default:
                    strCa = "Không xác định";
                    break;
            }
            return strCa;
        }

        protected string GetTen(string pHoVaTen)
        {
            string[] arrTemp = pHoVaTen.Trim().Split(new char[] { ' ' });
            if (arrTemp.Length == 0)
                return "";
            else
                return arrTemp[arrTemp.Length - 1];
        }
    }
}
