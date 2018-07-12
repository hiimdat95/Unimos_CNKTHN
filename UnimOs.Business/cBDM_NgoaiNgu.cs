using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_NgoaiNgu : cBBase
    {
        private cDDM_NgoaiNgu oDDM_NgoaiNgu;
        private DM_NgoaiNguInfo oDM_NgoaiNguInfo;

        public cBDM_NgoaiNgu()        
        {
            oDDM_NgoaiNgu = new cDDM_NgoaiNgu();
        }

        public DataTable Get(DM_NgoaiNguInfo pDM_NgoaiNguInfo)        
        {
            return oDDM_NgoaiNgu.Get(pDM_NgoaiNguInfo);
        }

        public int Add(DM_NgoaiNguInfo pDM_NgoaiNguInfo)
        {
			int ID = 0;
            ID = oDDM_NgoaiNgu.Add(pDM_NgoaiNguInfo);
            mErrorMessage = oDDM_NgoaiNgu.ErrorMessages;
            mErrorNumber = oDDM_NgoaiNgu.ErrorNumber;
            return ID;
        }

        public void Update(DM_NgoaiNguInfo pDM_NgoaiNguInfo)
        {
            oDDM_NgoaiNgu.Update(pDM_NgoaiNguInfo);
            mErrorMessage = oDDM_NgoaiNgu.ErrorMessages;
            mErrorNumber = oDDM_NgoaiNgu.ErrorNumber;
        }
        
        public void Delete(DM_NgoaiNguInfo pDM_NgoaiNguInfo)
        {
            oDDM_NgoaiNgu.Delete(pDM_NgoaiNguInfo);
            mErrorMessage = oDDM_NgoaiNgu.ErrorMessages;
            mErrorNumber = oDDM_NgoaiNgu.ErrorNumber;
        }

        public List<DM_NgoaiNguInfo> GetList(DM_NgoaiNguInfo pDM_NgoaiNguInfo)
        {
            List<DM_NgoaiNguInfo> oDM_NgoaiNguInfoList = new List<DM_NgoaiNguInfo>();
            DataTable dtb = Get(pDM_NgoaiNguInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_NgoaiNguInfo = new DM_NgoaiNguInfo();

                    oDM_NgoaiNguInfo.DM_NgoaiNguID = int.Parse(dtb.Rows[i]["DM_NgoaiNguID"].ToString());
                    oDM_NgoaiNguInfo.TenNgoaiNgu = dtb.Rows[i]["TenNgoaiNgu"].ToString();
                    
                    oDM_NgoaiNguInfoList.Add(oDM_NgoaiNguInfo);
                }
            }
            return oDM_NgoaiNguInfoList;
        }
        
        public void ToDataRow(DM_NgoaiNguInfo pDM_NgoaiNguInfo, ref DataRow dr)
        {

			dr[pDM_NgoaiNguInfo.strDM_NgoaiNguID] = pDM_NgoaiNguInfo.DM_NgoaiNguID;
			dr[pDM_NgoaiNguInfo.strTenNgoaiNgu] = pDM_NgoaiNguInfo.TenNgoaiNgu;
        }
        
        public void ToInfo(ref DM_NgoaiNguInfo pDM_NgoaiNguInfo, DataRow dr)
        {

			pDM_NgoaiNguInfo.DM_NgoaiNguID = int.Parse(dr[pDM_NgoaiNguInfo.strDM_NgoaiNguID].ToString());
			pDM_NgoaiNguInfo.TenNgoaiNgu = dr[pDM_NgoaiNguInfo.strTenNgoaiNgu].ToString();
        }
    }
}
