using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_DoiTuongMienGiam : cBBase
    {
        private cDDM_DoiTuongMienGiam oDDM_DoiTuongMienGiam;
        private DM_DoiTuongMienGiamInfo oDM_DoiTuongMienGiamInfo;

        public cBDM_DoiTuongMienGiam()        
        {
            oDDM_DoiTuongMienGiam = new cDDM_DoiTuongMienGiam();
        }

        public DataTable Get(DM_DoiTuongMienGiamInfo pDM_DoiTuongMienGiamInfo)        
        {
            return oDDM_DoiTuongMienGiam.Get(pDM_DoiTuongMienGiamInfo);
        }

        public int Add(DM_DoiTuongMienGiamInfo pDM_DoiTuongMienGiamInfo)
        {
			int ID = 0;
            ID = oDDM_DoiTuongMienGiam.Add(pDM_DoiTuongMienGiamInfo);
            mErrorMessage = oDDM_DoiTuongMienGiam.ErrorMessages;
            mErrorNumber = oDDM_DoiTuongMienGiam.ErrorNumber;
            return ID;
        }

        public void Update(DM_DoiTuongMienGiamInfo pDM_DoiTuongMienGiamInfo)
        {
            oDDM_DoiTuongMienGiam.Update(pDM_DoiTuongMienGiamInfo);
            mErrorMessage = oDDM_DoiTuongMienGiam.ErrorMessages;
            mErrorNumber = oDDM_DoiTuongMienGiam.ErrorNumber;
        }
        
        public void Delete(DM_DoiTuongMienGiamInfo pDM_DoiTuongMienGiamInfo)
        {
            oDDM_DoiTuongMienGiam.Delete(pDM_DoiTuongMienGiamInfo);
            mErrorMessage = oDDM_DoiTuongMienGiam.ErrorMessages;
            mErrorNumber = oDDM_DoiTuongMienGiam.ErrorNumber;
        }

        public List<DM_DoiTuongMienGiamInfo> GetList(DM_DoiTuongMienGiamInfo pDM_DoiTuongMienGiamInfo)
        {
            List<DM_DoiTuongMienGiamInfo> oDM_DoiTuongMienGiamInfoList = new List<DM_DoiTuongMienGiamInfo>();
            DataTable dtb = Get(pDM_DoiTuongMienGiamInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_DoiTuongMienGiamInfo = new DM_DoiTuongMienGiamInfo();

                    oDM_DoiTuongMienGiamInfo.DM_DoiTuongMienGiamID = int.Parse(dtb.Rows[i]["DM_DoiTuongMienGiamID"].ToString());
                    oDM_DoiTuongMienGiamInfo.MaDoiTuongMienGiam = dtb.Rows[i]["MaDoiTuongMienGiam"].ToString();
                    oDM_DoiTuongMienGiamInfo.TenDoiTuongMienGiam = dtb.Rows[i]["TenDoiTuongMienGiam"].ToString();
                    oDM_DoiTuongMienGiamInfo.MienGiam = dtb.Rows[i]["PhanTramMienGiam"].ToString();
                    oDM_DoiTuongMienGiamInfo.SoTienMienGiam = double.Parse(dtb.Rows[i]["SoTienMienGiam"].ToString());
                    
                    oDM_DoiTuongMienGiamInfoList.Add(oDM_DoiTuongMienGiamInfo);
                }
            }
            return oDM_DoiTuongMienGiamInfoList;
        }
        
        public void ToDataRow(DM_DoiTuongMienGiamInfo pDM_DoiTuongMienGiamInfo, ref DataRow dr)
        {

			dr[pDM_DoiTuongMienGiamInfo.strDM_DoiTuongMienGiamID] = pDM_DoiTuongMienGiamInfo.DM_DoiTuongMienGiamID;
			dr[pDM_DoiTuongMienGiamInfo.strMaDoiTuongMienGiam] = pDM_DoiTuongMienGiamInfo.MaDoiTuongMienGiam;
			dr[pDM_DoiTuongMienGiamInfo.strTenDoiTuongMienGiam] = pDM_DoiTuongMienGiamInfo.TenDoiTuongMienGiam;
			dr[pDM_DoiTuongMienGiamInfo.strMienGiam] = pDM_DoiTuongMienGiamInfo.MienGiam;
			dr[pDM_DoiTuongMienGiamInfo.strSoTienMienGiam] = pDM_DoiTuongMienGiamInfo.SoTienMienGiam;
        }
        
        public void ToInfo(ref DM_DoiTuongMienGiamInfo pDM_DoiTuongMienGiamInfo, DataRow dr)
        {

			pDM_DoiTuongMienGiamInfo.DM_DoiTuongMienGiamID = int.Parse(dr[pDM_DoiTuongMienGiamInfo.strDM_DoiTuongMienGiamID].ToString());
			pDM_DoiTuongMienGiamInfo.MaDoiTuongMienGiam = dr[pDM_DoiTuongMienGiamInfo.strMaDoiTuongMienGiam].ToString();
			pDM_DoiTuongMienGiamInfo.TenDoiTuongMienGiam = dr[pDM_DoiTuongMienGiamInfo.strTenDoiTuongMienGiam].ToString();
			pDM_DoiTuongMienGiamInfo.MienGiam = dr[pDM_DoiTuongMienGiamInfo.strMienGiam].ToString();
			pDM_DoiTuongMienGiamInfo.SoTienMienGiam = double.Parse(dr[pDM_DoiTuongMienGiamInfo.strSoTienMienGiam].ToString());
        }
    }
}
