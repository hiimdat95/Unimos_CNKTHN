using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_DiemDanh_ChiTiet : cBBase
    {
        private cDKQHT_DiemDanh_ChiTiet oDKQHT_DiemDanh_ChiTiet;
        private KQHT_DiemDanh_ChiTietInfo oKQHT_DiemDanh_ChiTietInfo;

        public cBKQHT_DiemDanh_ChiTiet()        
        {
            oDKQHT_DiemDanh_ChiTiet = new cDKQHT_DiemDanh_ChiTiet();
        }

        public DataTable Get(KQHT_DiemDanh_ChiTietInfo pKQHT_DiemDanh_ChiTietInfo)        
        {
            return oDKQHT_DiemDanh_ChiTiet.Get(pKQHT_DiemDanh_ChiTietInfo);
        }

        public int Add(KQHT_DiemDanh_ChiTietInfo pKQHT_DiemDanh_ChiTietInfo)
        {
			int ID = 0;
            ID = oDKQHT_DiemDanh_ChiTiet.Add(pKQHT_DiemDanh_ChiTietInfo);
            mErrorMessage = oDKQHT_DiemDanh_ChiTiet.ErrorMessages;
            mErrorNumber = oDKQHT_DiemDanh_ChiTiet.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_DiemDanh_ChiTietInfo pKQHT_DiemDanh_ChiTietInfo)
        {
            oDKQHT_DiemDanh_ChiTiet.Update(pKQHT_DiemDanh_ChiTietInfo);
            mErrorMessage = oDKQHT_DiemDanh_ChiTiet.ErrorMessages;
            mErrorNumber = oDKQHT_DiemDanh_ChiTiet.ErrorNumber;
        }
        
        public void Delete(KQHT_DiemDanh_ChiTietInfo pKQHT_DiemDanh_ChiTietInfo)
        {
            oDKQHT_DiemDanh_ChiTiet.Delete(pKQHT_DiemDanh_ChiTietInfo);
            mErrorMessage = oDKQHT_DiemDanh_ChiTiet.ErrorMessages;
            mErrorNumber = oDKQHT_DiemDanh_ChiTiet.ErrorNumber;
        }

        public List<KQHT_DiemDanh_ChiTietInfo> GetList(KQHT_DiemDanh_ChiTietInfo pKQHT_DiemDanh_ChiTietInfo)
        {
            List<KQHT_DiemDanh_ChiTietInfo> oKQHT_DiemDanh_ChiTietInfoList = new List<KQHT_DiemDanh_ChiTietInfo>();
            DataTable dtb = Get(pKQHT_DiemDanh_ChiTietInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_DiemDanh_ChiTietInfo = new KQHT_DiemDanh_ChiTietInfo();

                    oKQHT_DiemDanh_ChiTietInfo.KQHT_DiemDanh_ChiTietID = int.Parse(dtb.Rows[i]["KQHT_DiemDanh_ChiTietID"].ToString());
                    oKQHT_DiemDanh_ChiTietInfo.IDKQHT_DiemDanh = int.Parse(dtb.Rows[i]["IDKQHT_DiemDanh"].ToString());
                    oKQHT_DiemDanh_ChiTietInfo.IDXL_Tuan = long.Parse(dtb.Rows[i]["IDXL_Tuan"].ToString());
                    oKQHT_DiemDanh_ChiTietInfo.SoTiet = int.Parse(dtb.Rows[i]["SoTiet"].ToString());
                    oKQHT_DiemDanh_ChiTietInfo.LyDo = dtb.Rows[i]["LyDo"].ToString();
                    
                    oKQHT_DiemDanh_ChiTietInfoList.Add(oKQHT_DiemDanh_ChiTietInfo);
                }
            }
            return oKQHT_DiemDanh_ChiTietInfoList;
        }
        
        public void ToDataRow(KQHT_DiemDanh_ChiTietInfo pKQHT_DiemDanh_ChiTietInfo, ref DataRow dr)
        {

			dr[pKQHT_DiemDanh_ChiTietInfo.strKQHT_DiemDanh_ChiTietID] = pKQHT_DiemDanh_ChiTietInfo.KQHT_DiemDanh_ChiTietID;
			dr[pKQHT_DiemDanh_ChiTietInfo.strIDKQHT_DiemDanh] = pKQHT_DiemDanh_ChiTietInfo.IDKQHT_DiemDanh;
			dr[pKQHT_DiemDanh_ChiTietInfo.strIDXL_Tuan] = pKQHT_DiemDanh_ChiTietInfo.IDXL_Tuan;
			dr[pKQHT_DiemDanh_ChiTietInfo.strSoTiet] = pKQHT_DiemDanh_ChiTietInfo.SoTiet;
			dr[pKQHT_DiemDanh_ChiTietInfo.strLyDo] = pKQHT_DiemDanh_ChiTietInfo.LyDo;
        }
        
        public void ToInfo(ref KQHT_DiemDanh_ChiTietInfo pKQHT_DiemDanh_ChiTietInfo, DataRow dr)
        {

			pKQHT_DiemDanh_ChiTietInfo.KQHT_DiemDanh_ChiTietID = int.Parse(dr[pKQHT_DiemDanh_ChiTietInfo.strKQHT_DiemDanh_ChiTietID].ToString());
			pKQHT_DiemDanh_ChiTietInfo.IDKQHT_DiemDanh = int.Parse(dr[pKQHT_DiemDanh_ChiTietInfo.strIDKQHT_DiemDanh].ToString());
			pKQHT_DiemDanh_ChiTietInfo.IDXL_Tuan = long.Parse(dr[pKQHT_DiemDanh_ChiTietInfo.strIDXL_Tuan].ToString());
			pKQHT_DiemDanh_ChiTietInfo.SoTiet = int.Parse(dr[pKQHT_DiemDanh_ChiTietInfo.strSoTiet].ToString());
			pKQHT_DiemDanh_ChiTietInfo.LyDo = dr[pKQHT_DiemDanh_ChiTietInfo.strLyDo].ToString();
        }
    }
}
