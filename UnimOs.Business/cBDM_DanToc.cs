using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_DanToc : cBBase
    {
        private cDDM_DanToc oDDM_DanToc;
        private DM_DanTocInfo oDM_DanTocInfo;

        public cBDM_DanToc()        
        {
            oDDM_DanToc = new cDDM_DanToc();
        }

        public DataTable Get(DM_DanTocInfo pDM_DanTocInfo)        
        {
            return oDDM_DanToc.Get(pDM_DanTocInfo);
        }

        public int Add(DM_DanTocInfo pDM_DanTocInfo)
        {
			int ID = 0;
            ID = oDDM_DanToc.Add(pDM_DanTocInfo);
            mErrorMessage = oDDM_DanToc.ErrorMessages;
            mErrorNumber = oDDM_DanToc.ErrorNumber;
            return ID;
        }

        public void Update(DM_DanTocInfo pDM_DanTocInfo)
        {
            oDDM_DanToc.Update(pDM_DanTocInfo);
            mErrorMessage = oDDM_DanToc.ErrorMessages;
            mErrorNumber = oDDM_DanToc.ErrorNumber;
        }
        
        public void Delete(DM_DanTocInfo pDM_DanTocInfo)
        {
            oDDM_DanToc.Delete(pDM_DanTocInfo);
            mErrorMessage = oDDM_DanToc.ErrorMessages;
            mErrorNumber = oDDM_DanToc.ErrorNumber;
        }

        public List<DM_DanTocInfo> GetList(DM_DanTocInfo pDM_DanTocInfo)
        {
            List<DM_DanTocInfo> oDM_DanTocInfoList = new List<DM_DanTocInfo>();
            DataTable dtb = Get(pDM_DanTocInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_DanTocInfo = new DM_DanTocInfo();
                    

                    oDM_DanTocInfo.DM_DanTocID = int.Parse(dtb.Rows[i]["DM_DanTocID"].ToString());
                    oDM_DanTocInfo.MaDanToc = dtb.Rows[i]["MaDanToc"].ToString();
                    oDM_DanTocInfo.TenDanToc = dtb.Rows[i]["TenDanToc"].ToString();
                    
                    oDM_DanTocInfoList.Add(oDM_DanTocInfo);
                }
            }
            return oDM_DanTocInfoList;
        }
    }
}
