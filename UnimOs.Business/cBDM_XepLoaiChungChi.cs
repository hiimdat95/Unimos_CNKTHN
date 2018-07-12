using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_XepLoaiChungChi : cBBase
    {
        private cDDM_XepLoaiChungChi oDDM_XepLoaiChungChi;
        private DM_XepLoaiChungChiInfo oDM_XepLoaiChungChiInfo;

        public cBDM_XepLoaiChungChi()        
        {
            oDDM_XepLoaiChungChi = new cDDM_XepLoaiChungChi();
        }

        public DataTable Get(DM_XepLoaiChungChiInfo pDM_XepLoaiChungChiInfo)        
        {
            return oDDM_XepLoaiChungChi.Get(pDM_XepLoaiChungChiInfo);
        }

        public int Add(DM_XepLoaiChungChiInfo pDM_XepLoaiChungChiInfo)
        {
			int ID = 0;
            ID = oDDM_XepLoaiChungChi.Add(pDM_XepLoaiChungChiInfo);
            mErrorMessage = oDDM_XepLoaiChungChi.ErrorMessages;
            mErrorNumber = oDDM_XepLoaiChungChi.ErrorNumber;
            return ID;
        }

        public void Update(DM_XepLoaiChungChiInfo pDM_XepLoaiChungChiInfo)
        {
            oDDM_XepLoaiChungChi.Update(pDM_XepLoaiChungChiInfo);
            mErrorMessage = oDDM_XepLoaiChungChi.ErrorMessages;
            mErrorNumber = oDDM_XepLoaiChungChi.ErrorNumber;
        }
        
        public void Delete(DM_XepLoaiChungChiInfo pDM_XepLoaiChungChiInfo)
        {
            oDDM_XepLoaiChungChi.Delete(pDM_XepLoaiChungChiInfo);
            mErrorMessage = oDDM_XepLoaiChungChi.ErrorMessages;
            mErrorNumber = oDDM_XepLoaiChungChi.ErrorNumber;
        }

        public List<DM_XepLoaiChungChiInfo> GetList(DM_XepLoaiChungChiInfo pDM_XepLoaiChungChiInfo)
        {
            List<DM_XepLoaiChungChiInfo> oDM_XepLoaiChungChiInfoList = new List<DM_XepLoaiChungChiInfo>();
            DataTable dtb = Get(pDM_XepLoaiChungChiInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_XepLoaiChungChiInfo = new DM_XepLoaiChungChiInfo();

                    oDM_XepLoaiChungChiInfo.DM_XepLoaiChungChiID = int.Parse(dtb.Rows[i]["DM_XepLoaiChungChiID"].ToString());
                    oDM_XepLoaiChungChiInfo.TenXepLoaiChungChi = dtb.Rows[i]["TenXepLoaiChungChi"].ToString();
                    
                    oDM_XepLoaiChungChiInfoList.Add(oDM_XepLoaiChungChiInfo);
                }
            }
            return oDM_XepLoaiChungChiInfoList;
        }
        
        public void ToDataRow(DM_XepLoaiChungChiInfo pDM_XepLoaiChungChiInfo, ref DataRow dr)
        {

			dr[pDM_XepLoaiChungChiInfo.strDM_XepLoaiChungChiID] = pDM_XepLoaiChungChiInfo.DM_XepLoaiChungChiID;
			dr[pDM_XepLoaiChungChiInfo.strTenXepLoaiChungChi] = pDM_XepLoaiChungChiInfo.TenXepLoaiChungChi;
        }
        
        public void ToInfo(ref DM_XepLoaiChungChiInfo pDM_XepLoaiChungChiInfo, DataRow dr)
        {

			pDM_XepLoaiChungChiInfo.DM_XepLoaiChungChiID = int.Parse(dr[pDM_XepLoaiChungChiInfo.strDM_XepLoaiChungChiID].ToString());
			pDM_XepLoaiChungChiInfo.TenXepLoaiChungChi = dr[pDM_XepLoaiChungChiInfo.strTenXepLoaiChungChi].ToString();
        }
    }
}
