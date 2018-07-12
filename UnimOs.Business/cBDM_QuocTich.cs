using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_QuocTich : cBBase
    {
        private cDDM_QuocTich oDDM_QuocTich;
        private DM_QuocTichInfo oDM_QuocTichInfo;

        public cBDM_QuocTich()        
        {
            oDDM_QuocTich = new cDDM_QuocTich();
        }

        public DataTable Get(DM_QuocTichInfo pDM_QuocTichInfo)        
        {
            return oDDM_QuocTich.Get(pDM_QuocTichInfo);
        }

        public int Add(DM_QuocTichInfo pDM_QuocTichInfo)
        {
			int ID = 0;
            ID = oDDM_QuocTich.Add(pDM_QuocTichInfo);
            mErrorMessage = oDDM_QuocTich.ErrorMessages;
            mErrorNumber = oDDM_QuocTich.ErrorNumber;
            return ID;
        }

        public void Update(DM_QuocTichInfo pDM_QuocTichInfo)
        {
            oDDM_QuocTich.Update(pDM_QuocTichInfo);
            mErrorMessage = oDDM_QuocTich.ErrorMessages;
            mErrorNumber = oDDM_QuocTich.ErrorNumber;
        }
        
        public void Delete(DM_QuocTichInfo pDM_QuocTichInfo)
        {
            oDDM_QuocTich.Delete(pDM_QuocTichInfo);
            mErrorMessage = oDDM_QuocTich.ErrorMessages;
            mErrorNumber = oDDM_QuocTich.ErrorNumber;
        }

        public List<DM_QuocTichInfo> GetList(DM_QuocTichInfo pDM_QuocTichInfo)
        {
            List<DM_QuocTichInfo> oDM_QuocTichInfoList = new List<DM_QuocTichInfo>();
            DataTable dtb = Get(pDM_QuocTichInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_QuocTichInfo = new DM_QuocTichInfo();

                    oDM_QuocTichInfo.DM_QuocTichID = int.Parse(dtb.Rows[i]["DM_QuocTichID"].ToString());
                    oDM_QuocTichInfo.MaNuoc = dtb.Rows[i]["MaNuoc"].ToString();
                    oDM_QuocTichInfo.TenNuoc = dtb.Rows[i]["TenNuoc"].ToString();
                    
                    oDM_QuocTichInfoList.Add(oDM_QuocTichInfo);
                }
            }
            return oDM_QuocTichInfoList;
        }
        
        public void ToDataRow(DM_QuocTichInfo pDM_QuocTichInfo, ref DataRow dr)
        {

			dr[pDM_QuocTichInfo.strDM_QuocTichID] = pDM_QuocTichInfo.DM_QuocTichID;
			dr[pDM_QuocTichInfo.strMaNuoc] = pDM_QuocTichInfo.MaNuoc;
			dr[pDM_QuocTichInfo.strTenNuoc] = pDM_QuocTichInfo.TenNuoc;
        }
        
        public void ToInfo(ref DM_QuocTichInfo pDM_QuocTichInfo, DataRow dr)
        {

			pDM_QuocTichInfo.DM_QuocTichID = int.Parse(dr[pDM_QuocTichInfo.strDM_QuocTichID].ToString());
			pDM_QuocTichInfo.MaNuoc = dr[pDM_QuocTichInfo.strMaNuoc].ToString();
			pDM_QuocTichInfo.TenNuoc = dr[pDM_QuocTichInfo.strTenNuoc].ToString();
        }
    }
}
