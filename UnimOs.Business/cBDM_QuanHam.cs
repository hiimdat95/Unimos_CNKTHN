using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_QuanHam : cBBase
    {
        private cDDM_QuanHam oDDM_QuanHam;
        private DM_QuanHamInfo oDM_QuanHamInfo;

        public cBDM_QuanHam()        
        {
            oDDM_QuanHam = new cDDM_QuanHam();
        }

        public DataTable Get(DM_QuanHamInfo pDM_QuanHamInfo)        
        {
            return oDDM_QuanHam.Get(pDM_QuanHamInfo);
        }

        public int Add(DM_QuanHamInfo pDM_QuanHamInfo)
        {
			int ID = 0;
            ID = oDDM_QuanHam.Add(pDM_QuanHamInfo);
            mErrorMessage = oDDM_QuanHam.ErrorMessages;
            mErrorNumber = oDDM_QuanHam.ErrorNumber;
            return ID;
        }

        public void Update(DM_QuanHamInfo pDM_QuanHamInfo)
        {
            oDDM_QuanHam.Update(pDM_QuanHamInfo);
            mErrorMessage = oDDM_QuanHam.ErrorMessages;
            mErrorNumber = oDDM_QuanHam.ErrorNumber;
        }
        
        public void Delete(DM_QuanHamInfo pDM_QuanHamInfo)
        {
            oDDM_QuanHam.Delete(pDM_QuanHamInfo);
            mErrorMessage = oDDM_QuanHam.ErrorMessages;
            mErrorNumber = oDDM_QuanHam.ErrorNumber;
        }

        public List<DM_QuanHamInfo> GetList(DM_QuanHamInfo pDM_QuanHamInfo)
        {
            List<DM_QuanHamInfo> oDM_QuanHamInfoList = new List<DM_QuanHamInfo>();
            DataTable dtb = Get(pDM_QuanHamInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_QuanHamInfo = new DM_QuanHamInfo();

                    oDM_QuanHamInfo.DM_QuanHamID = int.Parse(dtb.Rows[i]["DM_QuanHamID"].ToString());
                    oDM_QuanHamInfo.TenQuanHam = dtb.Rows[i]["TenQuanHam"].ToString();
                    
                    oDM_QuanHamInfoList.Add(oDM_QuanHamInfo);
                }
            }
            return oDM_QuanHamInfoList;
        }
        
        public void ToDataRow(DM_QuanHamInfo pDM_QuanHamInfo, ref DataRow dr)
        {

			dr[pDM_QuanHamInfo.strDM_QuanHamID] = pDM_QuanHamInfo.DM_QuanHamID;
			dr[pDM_QuanHamInfo.strTenQuanHam] = pDM_QuanHamInfo.TenQuanHam;
        }
        
        public void ToInfo(ref DM_QuanHamInfo pDM_QuanHamInfo, DataRow dr)
        {

			pDM_QuanHamInfo.DM_QuanHamID = int.Parse(dr[pDM_QuanHamInfo.strDM_QuanHamID].ToString());
			pDM_QuanHamInfo.TenQuanHam = dr[pDM_QuanHamInfo.strTenQuanHam].ToString();
        }
    }
}
