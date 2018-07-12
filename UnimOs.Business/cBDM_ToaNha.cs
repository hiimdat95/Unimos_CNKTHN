using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_ToaNha : cBBase
    {
        private cDDM_ToaNha oDDM_ToaNha;
        private DM_ToaNhaInfo oDM_ToaNhaInfo;

        public cBDM_ToaNha()        
        {
            oDDM_ToaNha = new cDDM_ToaNha();
        }

        public DataTable Get(DM_ToaNhaInfo pDM_ToaNhaInfo)        
        {
            return oDDM_ToaNha.Get(pDM_ToaNhaInfo);
        }

        public DataTable GetByIDDiaDiem(int IDDM_DiaDiem)
        {
            return oDDM_ToaNha.GetByIDDiaDiem(IDDM_DiaDiem);
        }

        public int Add(DM_ToaNhaInfo pDM_ToaNhaInfo)
        {
			int ID = 0;
            ID = oDDM_ToaNha.Add(pDM_ToaNhaInfo);
            mErrorMessage = oDDM_ToaNha.ErrorMessages;
            mErrorNumber = oDDM_ToaNha.ErrorNumber;
            return ID;
        }

        public void Update(DM_ToaNhaInfo pDM_ToaNhaInfo)
        {
            oDDM_ToaNha.Update(pDM_ToaNhaInfo);
            mErrorMessage = oDDM_ToaNha.ErrorMessages;
            mErrorNumber = oDDM_ToaNha.ErrorNumber;
        }
        
        public void Delete(DM_ToaNhaInfo pDM_ToaNhaInfo)
        {
            oDDM_ToaNha.Delete(pDM_ToaNhaInfo);
            mErrorMessage = oDDM_ToaNha.ErrorMessages;
            mErrorNumber = oDDM_ToaNha.ErrorNumber;
        }

        public List<DM_ToaNhaInfo> GetList(DM_ToaNhaInfo pDM_ToaNhaInfo)
        {
            List<DM_ToaNhaInfo> oDM_ToaNhaInfoList = new List<DM_ToaNhaInfo>();
            DataTable dtb = Get(pDM_ToaNhaInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_ToaNhaInfo = new DM_ToaNhaInfo();

                    oDM_ToaNhaInfo.DM_ToaNhaID = int.Parse(dtb.Rows[i]["DM_ToaNhaID"].ToString());
                    oDM_ToaNhaInfo.IDDM_DiaDiem = int.Parse(dtb.Rows[i]["IDDM_DiaDiem"].ToString());
                    oDM_ToaNhaInfo.MaToaNha = dtb.Rows[i]["MaToaNha"].ToString();
                    oDM_ToaNhaInfo.TenToaNha = dtb.Rows[i]["TenToaNha"].ToString();
                    
                    oDM_ToaNhaInfoList.Add(oDM_ToaNhaInfo);
                }
            }
            return oDM_ToaNhaInfoList;
        }
        
        public void ToDataRow(DM_ToaNhaInfo pDM_ToaNhaInfo, ref DataRow dr)
        {

			dr[pDM_ToaNhaInfo.strDM_ToaNhaID] = pDM_ToaNhaInfo.DM_ToaNhaID;
			dr[pDM_ToaNhaInfo.strIDDM_DiaDiem] = pDM_ToaNhaInfo.IDDM_DiaDiem;
			dr[pDM_ToaNhaInfo.strMaToaNha] = pDM_ToaNhaInfo.MaToaNha;
			dr[pDM_ToaNhaInfo.strTenToaNha] = pDM_ToaNhaInfo.TenToaNha;
        }
    }
}
