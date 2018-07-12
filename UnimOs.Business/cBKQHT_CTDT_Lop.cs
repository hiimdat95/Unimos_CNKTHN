using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_CTDT_Lop : cBBase
    {
        private cDKQHT_CTDT_Lop oDKQHT_CTDT_Lop;
        private KQHT_CTDT_LopInfo oKQHT_CTDT_LopInfo;

        public cBKQHT_CTDT_Lop()        
        {
            oDKQHT_CTDT_Lop = new cDKQHT_CTDT_Lop();
        }

        public DataTable Get(KQHT_CTDT_LopInfo pKQHT_CTDT_LopInfo)        
        {
            return oDKQHT_CTDT_Lop.Get(pKQHT_CTDT_LopInfo);
        }

        public int Add(KQHT_CTDT_LopInfo pKQHT_CTDT_LopInfo)
        {
			int ID = 0;
            ID = oDKQHT_CTDT_Lop.Add(pKQHT_CTDT_LopInfo);
            mErrorMessage = oDKQHT_CTDT_Lop.ErrorMessages;
            mErrorNumber = oDKQHT_CTDT_Lop.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_CTDT_LopInfo pKQHT_CTDT_LopInfo)
        {
            oDKQHT_CTDT_Lop.Update(pKQHT_CTDT_LopInfo);
            mErrorMessage = oDKQHT_CTDT_Lop.ErrorMessages;
            mErrorNumber = oDKQHT_CTDT_Lop.ErrorNumber;
        }
        
        public void Delete(KQHT_CTDT_LopInfo pKQHT_CTDT_LopInfo)
        {
            oDKQHT_CTDT_Lop.Delete(pKQHT_CTDT_LopInfo);
            mErrorMessage = oDKQHT_CTDT_Lop.ErrorMessages;
            mErrorNumber = oDKQHT_CTDT_Lop.ErrorNumber;
        }

        public List<KQHT_CTDT_LopInfo> GetList(KQHT_CTDT_LopInfo pKQHT_CTDT_LopInfo)
        {
            List<KQHT_CTDT_LopInfo> oKQHT_CTDT_LopInfoList = new List<KQHT_CTDT_LopInfo>();
            DataTable dtb = Get(pKQHT_CTDT_LopInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_CTDT_LopInfo = new KQHT_CTDT_LopInfo();

                    oKQHT_CTDT_LopInfo.KQHT_CTDT_LopID = int.Parse(dtb.Rows[i]["KQHT_CTDT_LopID"].ToString());
                    oKQHT_CTDT_LopInfo.IDDM_Lop = int.Parse(dtb.Rows[i]["IDDM_Lop"].ToString());
                    oKQHT_CTDT_LopInfo.IDKQHT_ChuongTrinhDaoTao = int.Parse(dtb.Rows[i]["IDKQHT_ChuongTrinhDaoTao"].ToString());
                    
                    oKQHT_CTDT_LopInfoList.Add(oKQHT_CTDT_LopInfo);
                }
            }
            return oKQHT_CTDT_LopInfoList;
        }
        
        public void ToDataRow(KQHT_CTDT_LopInfo pKQHT_CTDT_LopInfo, ref DataRow dr)
        {

			dr[pKQHT_CTDT_LopInfo.strKQHT_CTDT_LopID] = pKQHT_CTDT_LopInfo.KQHT_CTDT_LopID;
			dr[pKQHT_CTDT_LopInfo.strIDDM_Lop] = pKQHT_CTDT_LopInfo.IDDM_Lop;
			dr[pKQHT_CTDT_LopInfo.strIDKQHT_ChuongTrinhDaoTao] = pKQHT_CTDT_LopInfo.IDKQHT_ChuongTrinhDaoTao;
        }
    }
}
