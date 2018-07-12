using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_Tang : cBBase
    {
        private cDDM_Tang oDDM_Tang;
        private DM_TangInfo oDM_TangInfo;

        public cBDM_Tang()        
        {
            oDDM_Tang = new cDDM_Tang();
        }

        public DataTable Get(DM_TangInfo pDM_TangInfo)        
        {
            return oDDM_Tang.Get(pDM_TangInfo);
        }

        public int Add(DM_TangInfo pDM_TangInfo)
        {
			int ID = 0;
            ID = oDDM_Tang.Add(pDM_TangInfo);
            mErrorMessage = oDDM_Tang.ErrorMessages;
            mErrorNumber = oDDM_Tang.ErrorNumber;
            return ID;
        }

        public void Update(DM_TangInfo pDM_TangInfo)
        {
            oDDM_Tang.Update(pDM_TangInfo);
            mErrorMessage = oDDM_Tang.ErrorMessages;
            mErrorNumber = oDDM_Tang.ErrorNumber;
        }
        
        public void Delete(DM_TangInfo pDM_TangInfo)
        {
            oDDM_Tang.Delete(pDM_TangInfo);
            mErrorMessage = oDDM_Tang.ErrorMessages;
            mErrorNumber = oDDM_Tang.ErrorNumber;
        }

        public List<DM_TangInfo> GetList(DM_TangInfo pDM_TangInfo)
        {
            List<DM_TangInfo> oDM_TangInfoList = new List<DM_TangInfo>();
            DataTable dtb = Get(pDM_TangInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_TangInfo = new DM_TangInfo();
                    

                    oDM_TangInfo.DM_TangID = int.Parse(dtb.Rows[i]["DM_TangID"].ToString());
                    oDM_TangInfo.TenTang = dtb.Rows[i]["TenTang"].ToString();
                    
                    oDM_TangInfoList.Add(oDM_TangInfo);
                }
            }
            return oDM_TangInfoList;
        }
    }
}
