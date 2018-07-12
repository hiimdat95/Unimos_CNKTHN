using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_HanhVi : cBBase
    {
        private cDDM_HanhVi oDDM_HanhVi;
        private DM_HanhViInfo oDM_HanhViInfo;

        public cBDM_HanhVi()        
        {
            oDDM_HanhVi = new cDDM_HanhVi();
        }

        public DataTable Get(DM_HanhViInfo pDM_HanhViInfo)        
        {
            return oDDM_HanhVi.Get(pDM_HanhViInfo);
        }

        public int Add(DM_HanhViInfo pDM_HanhViInfo)
        {
			int ID = 0;
            ID = oDDM_HanhVi.Add(pDM_HanhViInfo);
            mErrorMessage = oDDM_HanhVi.ErrorMessages;
            mErrorNumber = oDDM_HanhVi.ErrorNumber;
            return ID;
        }

        public void Update(DM_HanhViInfo pDM_HanhViInfo)
        {
            oDDM_HanhVi.Update(pDM_HanhViInfo);
            mErrorMessage = oDDM_HanhVi.ErrorMessages;
            mErrorNumber = oDDM_HanhVi.ErrorNumber;
        }
        
        public void Delete(DM_HanhViInfo pDM_HanhViInfo)
        {
            oDDM_HanhVi.Delete(pDM_HanhViInfo);
            mErrorMessage = oDDM_HanhVi.ErrorMessages;
            mErrorNumber = oDDM_HanhVi.ErrorNumber;
        }

        public List<DM_HanhViInfo> GetList(DM_HanhViInfo pDM_HanhViInfo)
        {
            List<DM_HanhViInfo> oDM_HanhViInfoList = new List<DM_HanhViInfo>();
            DataTable dtb = Get(pDM_HanhViInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_HanhViInfo = new DM_HanhViInfo();

                    oDM_HanhViInfo.DM_HanhViID = int.Parse(dtb.Rows[i]["DM_HanhViID"].ToString());
                    oDM_HanhViInfo.MaHanhVi = dtb.Rows[i]["MaHanhVi"].ToString();
                    oDM_HanhViInfo.TenHanhVi = dtb.Rows[i]["TenHanhVi"].ToString();
                    
                    oDM_HanhViInfoList.Add(oDM_HanhViInfo);
                }
            }
            return oDM_HanhViInfoList;
        }
        
        public void ToDataRow(DM_HanhViInfo pDM_HanhViInfo, ref DataRow dr)
        {

			dr[pDM_HanhViInfo.strDM_HanhViID] = pDM_HanhViInfo.DM_HanhViID;
			dr[pDM_HanhViInfo.strMaHanhVi] = pDM_HanhViInfo.MaHanhVi;
			dr[pDM_HanhViInfo.strTenHanhVi] = pDM_HanhViInfo.TenHanhVi;
        }
        
        public void ToInfo(ref DM_HanhViInfo pDM_HanhViInfo, DataRow dr)
        {

			pDM_HanhViInfo.DM_HanhViID = int.Parse(dr[pDM_HanhViInfo.strDM_HanhViID].ToString());
			pDM_HanhViInfo.MaHanhVi = dr[pDM_HanhViInfo.strMaHanhVi].ToString();
			pDM_HanhViInfo.TenHanhVi = dr[pDM_HanhViInfo.strTenHanhVi].ToString();
        }
    }
}
