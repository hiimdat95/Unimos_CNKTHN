using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_QuyChe : cBBase
    {
        private cDKQHT_QuyChe oDKQHT_QuyChe;
        private KQHT_QuyCheInfo oKQHT_QuyCheInfo;

        public cBKQHT_QuyChe()        
        {
            oDKQHT_QuyChe = new cDKQHT_QuyChe();
        }

        public DataTable Get(KQHT_QuyCheInfo pKQHT_QuyCheInfo)        
        {
            return oDKQHT_QuyChe.Get(pKQHT_QuyCheInfo);
        }

        public DataTable GetThamSo(int KQHT_QuyCheID)
        {
            return oDKQHT_QuyChe.GetThamSo(KQHT_QuyCheID);
        }

        public DataTable GetThamSo_NotIn(int KQHT_QuyCheID)
        {
            return oDKQHT_QuyChe.GetThamSo_NotIn(KQHT_QuyCheID);
        }

        public string GetByMaThamSo(int IDDM_TrinhDo, string MaThamSo)
        {
            return oDKQHT_QuyChe.GetByMaThamSo(IDDM_TrinhDo, MaThamSo);
        }

        public int Add(KQHT_QuyCheInfo pKQHT_QuyCheInfo)
        {
			int ID = 0;
            ID = oDKQHT_QuyChe.Add(pKQHT_QuyCheInfo);
            mErrorMessage = oDKQHT_QuyChe.ErrorMessages;
            mErrorNumber = oDKQHT_QuyChe.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_QuyCheInfo pKQHT_QuyCheInfo)
        {
            oDKQHT_QuyChe.Update(pKQHT_QuyCheInfo);
            mErrorMessage = oDKQHT_QuyChe.ErrorMessages;
            mErrorNumber = oDKQHT_QuyChe.ErrorNumber;
        }
        
        public void Delete(KQHT_QuyCheInfo pKQHT_QuyCheInfo)
        {
            oDKQHT_QuyChe.Delete(pKQHT_QuyCheInfo);
            mErrorMessage = oDKQHT_QuyChe.ErrorMessages;
            mErrorNumber = oDKQHT_QuyChe.ErrorNumber;
        }

        public List<KQHT_QuyCheInfo> GetList(KQHT_QuyCheInfo pKQHT_QuyCheInfo)
        {
            List<KQHT_QuyCheInfo> oKQHT_QuyCheInfoList = new List<KQHT_QuyCheInfo>();
            DataTable dtb = Get(pKQHT_QuyCheInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_QuyCheInfo = new KQHT_QuyCheInfo();
                    

                    oKQHT_QuyCheInfo.KQHT_QuyCheID = int.Parse(dtb.Rows[i]["KQHT_QuyCheID"].ToString());
                    oKQHT_QuyCheInfo.MaQuyChe = dtb.Rows[i]["MaQuyChe"].ToString();
                    oKQHT_QuyCheInfo.TenQuyChe = dtb.Rows[i]["TenQuyChe"].ToString();
                    
                    oKQHT_QuyCheInfoList.Add(oKQHT_QuyCheInfo);
                }
            }
            return oKQHT_QuyCheInfoList;
        }
    }
}
