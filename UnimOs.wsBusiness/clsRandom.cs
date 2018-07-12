using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace TruongViet.UnimOs.wsBusiness
{
    public class clsRandom
    {
        /// <summary>
        /// TrungVK 14/08/2009
        /// </summary>
        /// <param name="TuSo"></param>
        /// <param name="DenSo"></param>
        /// <returns>mảng số không trùng nhau ngẫu nhiên</returns>
        public int[] RandomKhongTrung(int TuSo, int DenSo)
        {
            int Temp = TuSo;
            int your_number = DenSo - TuSo + 1;
            int[] mArray = new int[your_number];
            int[] result = new int[your_number];
            for (int j = 0; j <= your_number - 1; j++)
            {
                //tạo dãy số
                mArray[j] = Temp;
                Temp += 1;
            }
            Random r = new Random();
            int i = 0;
            while (i < mArray.Length)
            {
                int index = r.Next(your_number - 1);
                result[i] = mArray[index];
                //chọn số ngẫu nhiên
                //mảng số còn lại.
                mArray[index] = mArray[your_number - 1];
                i += 1;
                your_number -= 1;
            }
            return result;
        }

        /// <summary>
        /// Lấy chuỗi tăng tiếp theo của giá trị đưa vào
        /// DũngNT 17/8/2009
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string GetNextSring(string value)
        {
            string res = string.Empty;
            char[] Charactors = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char[] Numbers = "0123456789".ToCharArray();
            char[] cValue = value.ToCharArray();

            int idxThem = -1;
            for (int i = cValue.Length - 1; i >= 0; i--)
            {
                if (char.IsNumber(cValue[i]))
                {
                    if (cValue[i].CompareTo(Numbers[Numbers.Length - 1]) < 0)
                    {
                        idxThem = i;
                        break;
                    }
                }
                else
                {
                    if (cValue[i].CompareTo(Charactors[Charactors.Length - 1]) < 0)
                    {
                        idxThem = i;
                        break;
                    }
                }
            }

            if (idxThem == -1)
            {
                if (char.IsNumber(cValue[0]))
                    cValue = (Numbers[1].ToString() + value).ToCharArray();
                else
                    cValue = (Charactors[0].ToString() + value).ToCharArray();
                idxThem++;
            }
            else
            {
                if (char.IsNumber(cValue[idxThem]))
                {
                    string temp = (Int32.Parse(cValue[idxThem].ToString()) + 1).ToString();
                    cValue[idxThem] = temp.ToCharArray()[0];
                }
                else
                {
                    for (int i = 0; i < Charactors.Length; i++)
                        if (Charactors[i].CompareTo(cValue[idxThem]) == 0)
                        {
                            cValue[idxThem] = Charactors[i + 1];
                            break;
                        }

                }
            }


            for (int i = cValue.Length - 1; i > idxThem; i--)
            {
                if (char.IsNumber(cValue[i]))
                    cValue[i] = Numbers[0];
                else
                    cValue[i] = Charactors[0];
            }

            for (int i = 0; i < cValue.Length; i++)
                res += cValue[i].ToString();

            return res;
        }

        /// <summary>
        /// Tạo một mảng chuỗi tăng
        /// DũngNT 17/8/2009
        /// </summary>
        /// <param name="strBatDau"></param>
        /// <param name="iLenght"></param>
        /// <returns></returns>
        public string[] GetStringsIncrease(string strBatDau, int iLenght)
        {
            string[] strKetQua = new string[iLenght];
            strKetQua[0] = strBatDau;
            for (int i = 1; i <= iLenght - 1; i++)
            {
                strKetQua[i] = GetNextSring(strKetQua[i - 1]);
            }
            return strKetQua;
        }
    }
}
