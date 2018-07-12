using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_TrinhDo : cBBase
    {
        private cDDM_TrinhDo oDDM_TrinhDo;
        private DM_TrinhDoInfo oDM_TrinhDoInfo;

        public cBDM_TrinhDo()        
        {
            oDDM_TrinhDo = new cDDM_TrinhDo();
        }

        public DataTable Get(DM_TrinhDoInfo pDM_TrinhDoInfo)        
        {
            return oDDM_TrinhDo.Get(pDM_TrinhDoInfo);
        }

        public int Add(DM_TrinhDoInfo pDM_TrinhDoInfo)
        {
			int ID = 0;
            ID = oDDM_TrinhDo.Add(pDM_TrinhDoInfo);
            mErrorMessage = oDDM_TrinhDo.ErrorMessages;
            mErrorNumber = oDDM_TrinhDo.ErrorNumber;
            return ID;
        }

        public void Update(DM_TrinhDoInfo pDM_TrinhDoInfo)
        {
            oDDM_TrinhDo.Update(pDM_TrinhDoInfo);
            mErrorMessage = oDDM_TrinhDo.ErrorMessages;
            mErrorNumber = oDDM_TrinhDo.ErrorNumber;
        }
        
        public void Delete(DM_TrinhDoInfo pDM_TrinhDoInfo)
        {
            oDDM_TrinhDo.Delete(pDM_TrinhDoInfo);
            mErrorMessage = oDDM_TrinhDo.ErrorMessages;
            mErrorNumber = oDDM_TrinhDo.ErrorNumber;
        }

        public List<DM_TrinhDoInfo> GetList(DM_TrinhDoInfo pDM_TrinhDoInfo)
        {
            List<DM_TrinhDoInfo> oDM_TrinhDoInfoList = new List<DM_TrinhDoInfo>();
            DataTable dtb = Get(pDM_TrinhDoInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_TrinhDoInfo = new DM_TrinhDoInfo();
                    

                    oDM_TrinhDoInfo.DM_TrinhDoID = int.Parse(dtb.Rows[i]["DM_TrinhDoID"].ToString());
                    oDM_TrinhDoInfo.IDDM_He = int.Parse(dtb.Rows[i]["IDDM_He"].ToString());
                    oDM_TrinhDoInfo.IDKQHT_QuyChe = int.Parse(dtb.Rows[i]["IDKQHT_QuyChe"].ToString());
                    oDM_TrinhDoInfo.MaTrinhDo = dtb.Rows[i]["MaTrinhDo"].ToString();
                    oDM_TrinhDoInfo.TenTrinhDo = dtb.Rows[i]["TenTrinhDo"].ToString();
                    oDM_TrinhDoInfo.TenTrinhDo_E = dtb.Rows[i]["TenTrinhDo_E"].ToString();
                    
                    oDM_TrinhDoInfoList.Add(oDM_TrinhDoInfo);
                }
            }
            return oDM_TrinhDoInfoList;
        }

        public DataTable GetByIDHe(int IDDM_He)
        {
            return oDDM_TrinhDo.GetByIDHe(IDDM_He);
        }
    }
}
