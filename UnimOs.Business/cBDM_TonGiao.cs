using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_TonGiao : cBBase
    {
        private cDDM_TonGiao oDDM_TonGiao;
        private DM_TonGiaoInfo oDM_TonGiaoInfo;

        public cBDM_TonGiao()        
        {
            oDDM_TonGiao = new cDDM_TonGiao();
        }

        public DataTable Get(DM_TonGiaoInfo pDM_TonGiaoInfo)        
        {
            return oDDM_TonGiao.Get(pDM_TonGiaoInfo);
        }

        public int Add(DM_TonGiaoInfo pDM_TonGiaoInfo)
        {
			int ID = 0;
            ID = oDDM_TonGiao.Add(pDM_TonGiaoInfo);
            mErrorMessage = oDDM_TonGiao.ErrorMessages;
            mErrorNumber = oDDM_TonGiao.ErrorNumber;
            return ID;
        }

        public void Update(DM_TonGiaoInfo pDM_TonGiaoInfo)
        {
            oDDM_TonGiao.Update(pDM_TonGiaoInfo);
            mErrorMessage = oDDM_TonGiao.ErrorMessages;
            mErrorNumber = oDDM_TonGiao.ErrorNumber;
        }
        
        public void Delete(DM_TonGiaoInfo pDM_TonGiaoInfo)
        {
            oDDM_TonGiao.Delete(pDM_TonGiaoInfo);
            mErrorMessage = oDDM_TonGiao.ErrorMessages;
            mErrorNumber = oDDM_TonGiao.ErrorNumber;
        }

        public List<DM_TonGiaoInfo> GetList(DM_TonGiaoInfo pDM_TonGiaoInfo)
        {
            List<DM_TonGiaoInfo> oDM_TonGiaoInfoList = new List<DM_TonGiaoInfo>();
            DataTable dtb = Get(pDM_TonGiaoInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_TonGiaoInfo = new DM_TonGiaoInfo();
                    

                    oDM_TonGiaoInfo.DM_TonGiaoID = int.Parse(dtb.Rows[i]["DM_TonGiaoID"].ToString());
                    oDM_TonGiaoInfo.MaTonGiao = dtb.Rows[i]["MaTonGiao"].ToString();
                    oDM_TonGiaoInfo.TenTonGiao = dtb.Rows[i]["TenTonGiao"].ToString();
                    
                    oDM_TonGiaoInfoList.Add(oDM_TonGiaoInfo);
                }
            }
            return oDM_TonGiaoInfoList;
        }
    }
}
