using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    public class clsVietToEn
    {
        string[,] arrMang;
        public clsVietToEn()
        {
            arrMang = new string[14, 18];
            NapKyTu();
        }

        public string ConvertVietToEn(string str)
        {
            for (int i = 0; i < 14; i++)
            {
                for (int j = 1; j < 18; j++)
                {
                    str = str.Replace(arrMang[i, j], arrMang[i, 0]);
                }
            }
            return str;
        }

        private void NapKyTu()
        {
            string Thga = "aáàạảãăắằặẳẵâấầậẩẫ";
            string HoaA = Thga.ToUpper();
            string Thge = "eéèẹẻẽêếềệểễeeeeee";
            string HoaE = Thge.ToUpper();
            string Thgo = "oóòọỏõôốồộổỗơớờợởỡ";
            string HoaO = Thgo.ToUpper();
            string Thgu = "uúùụủũưứừựửữuuuuuu";
            string HoaU = Thgu.ToUpper();
            string Thgi = "iíìịỉĩiiiiiiiiiiii";
            string HoaI = Thgi.ToUpper();
            string Thgd = "dđdddddddddddddddd";
            string HoaD = Thgd.ToUpper();
            string Thgy = "yýỳỵỷỹyyyyyyyyyyyy";
            string HoaY = Thgy.ToUpper();
            for (int i = 0; i < 18; i++)
            {
                arrMang[0, i] = Thga.Substring(i, 1);
                arrMang[1, i] = HoaA.Substring(i, 1);
                arrMang[2, i] = Thge.Substring(i, 1);
                arrMang[3, i] = HoaE.Substring(i, 1);
                arrMang[4, i] = Thgo.Substring(i, 1);
                arrMang[5, i] = HoaO.Substring(i, 1);
                arrMang[6, i] = Thgu.Substring(i, 1);
                arrMang[7, i] = HoaU.Substring(i, 1);
                arrMang[8, i] = Thgi.Substring(i, 1);
                arrMang[9, i] = HoaI.Substring(i, 1);
                arrMang[10, i] = Thgd.Substring(i, 1);
                arrMang[11, i] = HoaD.Substring(i, 1);
                arrMang[12, i] = Thgy.Substring(i, 1);
                arrMang[13, i] = HoaY.Substring(i, 1);
            }
        }
    }
}
