using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_ChuyenNganh : cBBase
    {
        private cDDM_ChuyenNganh oDDM_ChuyenNganh;
        private DM_ChuyenNganhInfo oDM_ChuyenNganhInfo;

        public cBDM_ChuyenNganh()        
        {
            oDDM_ChuyenNganh = new cDDM_ChuyenNganh();
        }

        public DataTable Get(DM_ChuyenNganhInfo pDM_ChuyenNganhInfo)        
        {
            return oDDM_ChuyenNganh.Get(pDM_ChuyenNganhInfo);
        }

        public DataTable GetByIDNganh(int IDDM_Nganh)
        {
            return oDDM_ChuyenNganh.GetByIDNganh(IDDM_Nganh);
        }

        public int Add(DM_ChuyenNganhInfo pDM_ChuyenNganhInfo)
        {
			int ID = 0;
            ID = oDDM_ChuyenNganh.Add(pDM_ChuyenNganhInfo);
            mErrorMessage = oDDM_ChuyenNganh.ErrorMessages;
            mErrorNumber = oDDM_ChuyenNganh.ErrorNumber;
            return ID;
        }

        public void Update(DM_ChuyenNganhInfo pDM_ChuyenNganhInfo)
        {
            oDDM_ChuyenNganh.Update(pDM_ChuyenNganhInfo);
            mErrorMessage = oDDM_ChuyenNganh.ErrorMessages;
            mErrorNumber = oDDM_ChuyenNganh.ErrorNumber;
        }
        
        public void Delete(DM_ChuyenNganhInfo pDM_ChuyenNganhInfo)
        {
            oDDM_ChuyenNganh.Delete(pDM_ChuyenNganhInfo);
            mErrorMessage = oDDM_ChuyenNganh.ErrorMessages;
            mErrorNumber = oDDM_ChuyenNganh.ErrorNumber;
        }

        public List<DM_ChuyenNganhInfo> GetList(DM_ChuyenNganhInfo pDM_ChuyenNganhInfo)
        {
            List<DM_ChuyenNganhInfo> oDM_ChuyenNganhInfoList = new List<DM_ChuyenNganhInfo>();
            DataTable dtb = Get(pDM_ChuyenNganhInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_ChuyenNganhInfo = new DM_ChuyenNganhInfo();

                    oDM_ChuyenNganhInfo.DM_ChuyenNganhID = int.Parse(dtb.Rows[i]["DM_ChuyenNganhID"].ToString());
                    oDM_ChuyenNganhInfo.IDDM_Nganh = int.Parse(dtb.Rows[i]["IDDM_Nganh"].ToString());
                    oDM_ChuyenNganhInfo.MaChuyenNganh = dtb.Rows[i]["MaChuyenNganh"].ToString();
                    oDM_ChuyenNganhInfo.TenChuyenNganh = dtb.Rows[i]["TenChuyenNganh"].ToString();
                    oDM_ChuyenNganhInfo.TenChuyenNganh_E = dtb.Rows[i]["TenChuyenNganh_E"].ToString();
                    
                    oDM_ChuyenNganhInfoList.Add(oDM_ChuyenNganhInfo);
                }
            }
            return oDM_ChuyenNganhInfoList;
        }

        public void ToDataRow(DM_ChuyenNganhInfo pDM_ChuyenNganhInfo, ref DataRow dr)
        {
            dr[pDM_ChuyenNganhInfo.strDM_ChuyenNganhID] = pDM_ChuyenNganhInfo.DM_ChuyenNganhID;
            dr[pDM_ChuyenNganhInfo.strIDDM_Nganh] = pDM_ChuyenNganhInfo.IDDM_Nganh;
            dr[pDM_ChuyenNganhInfo.strMaChuyenNganh] = pDM_ChuyenNganhInfo.MaChuyenNganh;
            dr[pDM_ChuyenNganhInfo.strTenChuyenNganh] = pDM_ChuyenNganhInfo.TenChuyenNganh;
            dr[pDM_ChuyenNganhInfo.strTenChuyenNganh_E] = pDM_ChuyenNganhInfo.TenChuyenNganh_E;
        }
    }
}
