using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_HoiDongMon_Diem : cBBase
    {
        private cDKQHT_HoiDongMon_Diem oDKQHT_HoiDongMon_Diem;
        private KQHT_HoiDongMon_DiemInfo oKQHT_HoiDongMon_DiemInfo;

        public cBKQHT_HoiDongMon_Diem()        
        {
            oDKQHT_HoiDongMon_Diem = new cDKQHT_HoiDongMon_Diem();
        }

        public DataTable Get(KQHT_HoiDongMon_DiemInfo pKQHT_HoiDongMon_DiemInfo)        
        {
            return oDKQHT_HoiDongMon_Diem.Get(pKQHT_HoiDongMon_DiemInfo);
        }

        public DataTable GetDanhSach(int KQHT_HoiDongMonID)
        {
            return oDKQHT_HoiDongMon_Diem.GetDanhSach(KQHT_HoiDongMonID);
        }

        public int Add(KQHT_HoiDongMon_DiemInfo pKQHT_HoiDongMon_DiemInfo)
        {
			int ID = 0;
            ID = oDKQHT_HoiDongMon_Diem.Add(pKQHT_HoiDongMon_DiemInfo);
            mErrorMessage = oDKQHT_HoiDongMon_Diem.ErrorMessages;
            mErrorNumber = oDKQHT_HoiDongMon_Diem.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_HoiDongMon_DiemInfo pKQHT_HoiDongMon_DiemInfo)
        {
            oDKQHT_HoiDongMon_Diem.Update(pKQHT_HoiDongMon_DiemInfo);
            mErrorMessage = oDKQHT_HoiDongMon_Diem.ErrorMessages;
            mErrorNumber = oDKQHT_HoiDongMon_Diem.ErrorNumber;
        }
        
        public void Delete(KQHT_HoiDongMon_DiemInfo pKQHT_HoiDongMon_DiemInfo)
        {
            oDKQHT_HoiDongMon_Diem.Delete(pKQHT_HoiDongMon_DiemInfo);
            mErrorMessage = oDKQHT_HoiDongMon_Diem.ErrorMessages;
            mErrorNumber = oDKQHT_HoiDongMon_Diem.ErrorNumber;
        }

        public List<KQHT_HoiDongMon_DiemInfo> GetList(KQHT_HoiDongMon_DiemInfo pKQHT_HoiDongMon_DiemInfo)
        {
            List<KQHT_HoiDongMon_DiemInfo> oKQHT_HoiDongMon_DiemInfoList = new List<KQHT_HoiDongMon_DiemInfo>();
            DataTable dtb = Get(pKQHT_HoiDongMon_DiemInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_HoiDongMon_DiemInfo = new KQHT_HoiDongMon_DiemInfo();

                    oKQHT_HoiDongMon_DiemInfo.KQHT_HoiDongMon_DiemID = long.Parse(dtb.Rows[i]["KQHT_HoiDongMon_DiemID"].ToString());
                    oKQHT_HoiDongMon_DiemInfo.IDKQHT_HoiDongMon_ChiTiet = int.Parse(dtb.Rows[i]["IDKQHT_HoiDongMon_ChiTiet"].ToString());
                    oKQHT_HoiDongMon_DiemInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oKQHT_HoiDongMon_DiemInfo.Diem = double.Parse(dtb.Rows[i]["Diem"].ToString());
                    
                    oKQHT_HoiDongMon_DiemInfoList.Add(oKQHT_HoiDongMon_DiemInfo);
                }
            }
            return oKQHT_HoiDongMon_DiemInfoList;
        }
        
        public void ToDataRow(KQHT_HoiDongMon_DiemInfo pKQHT_HoiDongMon_DiemInfo, ref DataRow dr)
        {

			dr[pKQHT_HoiDongMon_DiemInfo.strKQHT_HoiDongMon_DiemID] = pKQHT_HoiDongMon_DiemInfo.KQHT_HoiDongMon_DiemID;
			dr[pKQHT_HoiDongMon_DiemInfo.strIDKQHT_HoiDongMon_ChiTiet] = pKQHT_HoiDongMon_DiemInfo.IDKQHT_HoiDongMon_ChiTiet;
			dr[pKQHT_HoiDongMon_DiemInfo.strIDSV_SinhVien] = pKQHT_HoiDongMon_DiemInfo.IDSV_SinhVien;
			dr[pKQHT_HoiDongMon_DiemInfo.strDiem] = pKQHT_HoiDongMon_DiemInfo.Diem;
        }
        
        public void ToInfo(ref KQHT_HoiDongMon_DiemInfo pKQHT_HoiDongMon_DiemInfo, DataRow dr)
        {

			pKQHT_HoiDongMon_DiemInfo.KQHT_HoiDongMon_DiemID = long.Parse(dr[pKQHT_HoiDongMon_DiemInfo.strKQHT_HoiDongMon_DiemID].ToString());
			pKQHT_HoiDongMon_DiemInfo.IDKQHT_HoiDongMon_ChiTiet = int.Parse(dr[pKQHT_HoiDongMon_DiemInfo.strIDKQHT_HoiDongMon_ChiTiet].ToString());
			pKQHT_HoiDongMon_DiemInfo.IDSV_SinhVien = int.Parse(dr[pKQHT_HoiDongMon_DiemInfo.strIDSV_SinhVien].ToString());
			pKQHT_HoiDongMon_DiemInfo.Diem = double.Parse(dr[pKQHT_HoiDongMon_DiemInfo.strDiem].ToString());
        }
    }
}
