using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    public class clsStringHelper
    {
        public string FormatTenVietTat(string Ho_ten)
        {
            string TenVT = null;
            string[] str = null;
            str = Ho_ten.Trim().Split(new char[] { ' ' });
            if (str.Length > 1)
            {
                TenVT = str[str.Length - 1];
                for (int i = 0; i <= str.Length - 2; i++)
                {
                    if (str[i] != string.Empty)
                    {
                        TenVT += str[i].Substring(0, 1);
                    }
                }
                return TenVT;
            }
            else
            {
                return Ho_ten;
            }
        }

        public string GetTen(string Ho_ten)
        {
            string Ten = null;
            string[] str = null;
            str = Ho_ten.Trim().Split(new char[] { ' ' });
            Ten = str[str.Length - 1];
            return Ten;
        }

        public string[] TenThu()
        {
            string[] strThu = new string[7];
            strThu[0] = "CN";
            strThu[1] = "T2";
            strThu[2] = "T3";
            strThu[3] = "T4";
            strThu[4] = "T5";
            strThu[5] = "T6";
            strThu[6] = "T7";
            return strThu;
        }

        #region Đọc tiền bằng tiếng việt
        private string ReadGroup3(string G3)
        {
            string[] ReadDigit = new string[10] { " Không", " Một", " Hai", " Ba", " Bốn", " Năm", " Sáu", " Bảy", " Tám", " Chín" };
            string temp = "";
            if (G3 == "000") return "";

            //Đọc số hàng trăm
            temp = ReadDigit[int.Parse(G3[0].ToString())] + " Trăm";
            //Đọc số hàng chục
            if (G3[1].ToString() == "0")
                if (G3[2].ToString() == "0") return temp;
                else
                {
                    if (G3[2].ToString() != "." && G3[2].ToString() != ",")
                        temp += " Lẻ" + ReadDigit[int.Parse(G3[2].ToString())];
                    return temp;
                }
            else
            {
                if (G3[1].ToString() != "." && G3[1].ToString() != ",")
                    temp += ReadDigit[int.Parse(G3[1].ToString())] + " Mươi";
            }
            //--------------Đọc hàng đơn vị

            if (G3[2].ToString() == "5") temp += " Lăm";
            else if (G3[2].ToString() != "0") temp += ReadDigit[int.Parse(G3[2].ToString())];
            return temp;


        }
        public string ReadMoney(double Money)
        {
            string temp = "";
            string strMoney = Money.ToString();
            // Cho đủ 12 số
            while (strMoney.Length < 12)
            {
                strMoney = "0" + strMoney;
            }
            string g1 = strMoney.Substring(0, 3);
            string g2 = strMoney.Substring(3, 3);
            string g3 = strMoney.Substring(6, 3);
            string g4 = strMoney.Substring(9, 3);

            //Đọc nhóm 1 ---------------------
            if (g1 != "000")
            {
                temp = ReadGroup3(g1);
                temp += " Tỷ";
            }
            //Đọc nhóm 2-----------------------
            if (g2 != "000")
            {
                temp += ReadGroup3(g2);
                temp += " Triệu";
            }
            //---------------------------------
            if (g3 != "000")
            {
                temp += ReadGroup3(g3);
                temp += " Nghìn";
            }
            //-----------------------------------
            //Chỗ này ko biết có nên ko ?
            //temp =temp + ReadGroup3(g4).Replace("Không Trăm Lẻ","Lẻ"); // Đọc 1000001 là Một Triệu Lẻ Một thay vì Một Triệu Không Trăm Lẻ 1;
            temp = temp + ReadGroup3(g4);
            //---------------------------------
            // Tinh chỉnh
            temp = temp.Replace("Một Mươi", "Mười");
            temp = temp.Trim();
            if (temp.IndexOf("Không Trăm") == 0)
                temp = temp.Remove(0, 10);
            temp = temp.Trim();
            if (temp.IndexOf("Lẻ") == 0)
                temp = temp.Remove(0, 2);
            temp = temp.Trim();
            temp = temp.Replace("Mươi Một", "Mươi Mốt");
            temp = temp.Trim();
            //Change Case
            return temp.Substring(0, 1).ToUpper() + temp.Substring(1).ToLower();

        }
        #endregion

        //#region 
    }

}
