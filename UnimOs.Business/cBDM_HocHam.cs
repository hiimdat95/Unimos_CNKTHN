using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_HocHam : cBBase
    {
        private cDDM_HocHam oDDM_HocHam;
        private DM_HocHamInfo oDM_HocHamInfo;

        public cBDM_HocHam()        
        {
            oDDM_HocHam = new cDDM_HocHam();
        }

        public DataTable Get(DM_HocHamInfo pDM_HocHamInfo)        
        {
            return oDDM_HocHam.Get(pDM_HocHamInfo);
        }

        public int Add(DM_HocHamInfo pDM_HocHamInfo)
        {
			int ID = 0;
            ID = oDDM_HocHam.Add(pDM_HocHamInfo);
            mErrorMessage = oDDM_HocHam.ErrorMessages;
            mErrorNumber = oDDM_HocHam.ErrorNumber;
            return ID;
        }

        public void Update(DM_HocHamInfo pDM_HocHamInfo)
        {
            oDDM_HocHam.Update(pDM_HocHamInfo);
            mErrorMessage = oDDM_HocHam.ErrorMessages;
            mErrorNumber = oDDM_HocHam.ErrorNumber;
        }
        
        public void Delete(DM_HocHamInfo pDM_HocHamInfo)
        {
            oDDM_HocHam.Delete(pDM_HocHamInfo);
            mErrorMessage = oDDM_HocHam.ErrorMessages;
            mErrorNumber = oDDM_HocHam.ErrorNumber;
        }

        public List<DM_HocHamInfo> GetList(DM_HocHamInfo pDM_HocHamInfo)
        {
            List<DM_HocHamInfo> oDM_HocHamInfoList = new List<DM_HocHamInfo>();
            DataTable dtb = Get(pDM_HocHamInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_HocHamInfo = new DM_HocHamInfo();

                    oDM_HocHamInfo.DM_HocHamID = int.Parse(dtb.Rows[i]["DM_HocHamID"].ToString());
                    oDM_HocHamInfo.TenHocHam = dtb.Rows[i]["TenHocHam"].ToString();
                    
                    oDM_HocHamInfoList.Add(oDM_HocHamInfo);
                }
            }
            return oDM_HocHamInfoList;
        }
        
        public void ToDataRow(DM_HocHamInfo pDM_HocHamInfo, ref DataRow dr)
        {

			dr[pDM_HocHamInfo.strDM_HocHamID] = pDM_HocHamInfo.DM_HocHamID;
			dr[pDM_HocHamInfo.strTenHocHam] = pDM_HocHamInfo.TenHocHam;
        }
        
        public void ToInfo(ref DM_HocHamInfo pDM_HocHamInfo, DataRow dr)
        {

			pDM_HocHamInfo.DM_HocHamID = int.Parse(dr[pDM_HocHamInfo.strDM_HocHamID].ToString());
			pDM_HocHamInfo.TenHocHam = dr[pDM_HocHamInfo.strTenHocHam].ToString();
        }
    }
}
