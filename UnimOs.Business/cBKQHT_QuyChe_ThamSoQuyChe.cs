using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_QuyChe_ThamSoQuyChe : cBBase
    {
        private cDKQHT_QuyChe_ThamSoQuyChe oDKQHT_QuyChe_ThamSoQuyChe;
        private KQHT_QuyChe_ThamSoQuyCheInfo oKQHT_QuyChe_ThamSoQuyCheInfo;

        public cBKQHT_QuyChe_ThamSoQuyChe()        
        {
            oDKQHT_QuyChe_ThamSoQuyChe = new cDKQHT_QuyChe_ThamSoQuyChe();
        }

        public DataTable Get(KQHT_QuyChe_ThamSoQuyCheInfo pKQHT_QuyChe_ThamSoQuyCheInfo)        
        {
            return oDKQHT_QuyChe_ThamSoQuyChe.Get(pKQHT_QuyChe_ThamSoQuyCheInfo);
        }

        public int Add(KQHT_QuyChe_ThamSoQuyCheInfo pKQHT_QuyChe_ThamSoQuyCheInfo)
        {
			int ID = 0;
            ID = oDKQHT_QuyChe_ThamSoQuyChe.Add(pKQHT_QuyChe_ThamSoQuyCheInfo);
            mErrorMessage = oDKQHT_QuyChe_ThamSoQuyChe.ErrorMessages;
            mErrorNumber = oDKQHT_QuyChe_ThamSoQuyChe.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_QuyChe_ThamSoQuyCheInfo pKQHT_QuyChe_ThamSoQuyCheInfo)
        {
            oDKQHT_QuyChe_ThamSoQuyChe.Update(pKQHT_QuyChe_ThamSoQuyCheInfo);
            mErrorMessage = oDKQHT_QuyChe_ThamSoQuyChe.ErrorMessages;
            mErrorNumber = oDKQHT_QuyChe_ThamSoQuyChe.ErrorNumber;
        }
        
        public void Delete(KQHT_QuyChe_ThamSoQuyCheInfo pKQHT_QuyChe_ThamSoQuyCheInfo)
        {
            oDKQHT_QuyChe_ThamSoQuyChe.Delete(pKQHT_QuyChe_ThamSoQuyCheInfo);
            mErrorMessage = oDKQHT_QuyChe_ThamSoQuyChe.ErrorMessages;
            mErrorNumber = oDKQHT_QuyChe_ThamSoQuyChe.ErrorNumber;
        }
        public void Delete_By_QuyChe(int KQHT_QuyCheID)
        {
            oDKQHT_QuyChe_ThamSoQuyChe.Delete_By_QuyChe(KQHT_QuyCheID);
            mErrorMessage = oDKQHT_QuyChe_ThamSoQuyChe.ErrorMessages;
            mErrorNumber = oDKQHT_QuyChe_ThamSoQuyChe.ErrorNumber;
        }
        public List<KQHT_QuyChe_ThamSoQuyCheInfo> GetList(KQHT_QuyChe_ThamSoQuyCheInfo pKQHT_QuyChe_ThamSoQuyCheInfo)
        {
            List<KQHT_QuyChe_ThamSoQuyCheInfo> oKQHT_QuyChe_ThamSoQuyCheInfoList = new List<KQHT_QuyChe_ThamSoQuyCheInfo>();
            DataTable dtb = Get(pKQHT_QuyChe_ThamSoQuyCheInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_QuyChe_ThamSoQuyCheInfo = new KQHT_QuyChe_ThamSoQuyCheInfo();

                    oKQHT_QuyChe_ThamSoQuyCheInfo.KQHT_QuyChe_ThamSoQuyCheID = int.Parse(dtb.Rows[i]["KQHT_QuyChe_ThamSoQuyCheID"].ToString());
                    oKQHT_QuyChe_ThamSoQuyCheInfo.IDKQHT_QuyChe = int.Parse(dtb.Rows[i]["IDKQHT_QuyChe"].ToString());
                    oKQHT_QuyChe_ThamSoQuyCheInfo.IDKQHT_ThamSoQuyChe = int.Parse(dtb.Rows[i]["IDKQHT_ThamSoQuyChe"].ToString());
                    oKQHT_QuyChe_ThamSoQuyCheInfo.GiaTri = dtb.Rows[i]["GiaTri"].ToString();
                    
                    oKQHT_QuyChe_ThamSoQuyCheInfoList.Add(oKQHT_QuyChe_ThamSoQuyCheInfo);
                }
            }
            return oKQHT_QuyChe_ThamSoQuyCheInfoList;
        }
        
        public void ToDataRow(KQHT_QuyChe_ThamSoQuyCheInfo pKQHT_QuyChe_ThamSoQuyCheInfo, ref DataRow dr)
        {

			dr[pKQHT_QuyChe_ThamSoQuyCheInfo.strKQHT_QuyChe_ThamSoQuyCheID] = pKQHT_QuyChe_ThamSoQuyCheInfo.KQHT_QuyChe_ThamSoQuyCheID;
			dr[pKQHT_QuyChe_ThamSoQuyCheInfo.strIDKQHT_QuyChe] = pKQHT_QuyChe_ThamSoQuyCheInfo.IDKQHT_QuyChe;
			dr[pKQHT_QuyChe_ThamSoQuyCheInfo.strIDKQHT_ThamSoQuyChe] = pKQHT_QuyChe_ThamSoQuyCheInfo.IDKQHT_ThamSoQuyChe;
			dr[pKQHT_QuyChe_ThamSoQuyCheInfo.strGiaTri] = pKQHT_QuyChe_ThamSoQuyCheInfo.GiaTri;
        }
        
        public void ToInfo(ref KQHT_QuyChe_ThamSoQuyCheInfo pKQHT_QuyChe_ThamSoQuyCheInfo, DataRow dr)
        {

			pKQHT_QuyChe_ThamSoQuyCheInfo.KQHT_QuyChe_ThamSoQuyCheID = int.Parse(dr[pKQHT_QuyChe_ThamSoQuyCheInfo.strKQHT_QuyChe_ThamSoQuyCheID].ToString());
			pKQHT_QuyChe_ThamSoQuyCheInfo.IDKQHT_QuyChe = int.Parse(dr[pKQHT_QuyChe_ThamSoQuyCheInfo.strIDKQHT_QuyChe].ToString());
			pKQHT_QuyChe_ThamSoQuyCheInfo.IDKQHT_ThamSoQuyChe = int.Parse(dr[pKQHT_QuyChe_ThamSoQuyCheInfo.strIDKQHT_ThamSoQuyChe].ToString());
			pKQHT_QuyChe_ThamSoQuyCheInfo.GiaTri = dr[pKQHT_QuyChe_ThamSoQuyCheInfo.strGiaTri].ToString();
        }
    }
}
