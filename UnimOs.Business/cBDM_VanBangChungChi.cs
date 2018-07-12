using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_VanBangChungChi : cBBase
    {
        private cDDM_VanBangChungChi oDDM_VanBangChungChi;
        private DM_VanBangChungChiInfo oDM_VanBangChungChiInfo;

        public cBDM_VanBangChungChi()        
        {
            oDDM_VanBangChungChi = new cDDM_VanBangChungChi();
        }

        public DataTable Get(DM_VanBangChungChiInfo pDM_VanBangChungChiInfo)        
        {
            return oDDM_VanBangChungChi.Get(pDM_VanBangChungChiInfo);
        }

        public int Add(DM_VanBangChungChiInfo pDM_VanBangChungChiInfo)
        {
			int ID = 0;
            ID = oDDM_VanBangChungChi.Add(pDM_VanBangChungChiInfo);
            mErrorMessage = oDDM_VanBangChungChi.ErrorMessages;
            mErrorNumber = oDDM_VanBangChungChi.ErrorNumber;
            return ID;
        }

        public void Update(DM_VanBangChungChiInfo pDM_VanBangChungChiInfo)
        {
            oDDM_VanBangChungChi.Update(pDM_VanBangChungChiInfo);
            mErrorMessage = oDDM_VanBangChungChi.ErrorMessages;
            mErrorNumber = oDDM_VanBangChungChi.ErrorNumber;
        }
        
        public void Delete(DM_VanBangChungChiInfo pDM_VanBangChungChiInfo)
        {
            oDDM_VanBangChungChi.Delete(pDM_VanBangChungChiInfo);
            mErrorMessage = oDDM_VanBangChungChi.ErrorMessages;
            mErrorNumber = oDDM_VanBangChungChi.ErrorNumber;
        }

        public List<DM_VanBangChungChiInfo> GetList(DM_VanBangChungChiInfo pDM_VanBangChungChiInfo)
        {
            List<DM_VanBangChungChiInfo> oDM_VanBangChungChiInfoList = new List<DM_VanBangChungChiInfo>();
            DataTable dtb = Get(pDM_VanBangChungChiInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_VanBangChungChiInfo = new DM_VanBangChungChiInfo();

                    oDM_VanBangChungChiInfo.DM_VanBangChungChiID = int.Parse(dtb.Rows[i]["DM_VanBangChungChiID"].ToString());
                    oDM_VanBangChungChiInfo.Ten = dtb.Rows[i]["Ten"].ToString();
                    oDM_VanBangChungChiInfo.VanBang = bool.Parse(dtb.Rows[i]["VanBang"].ToString());
                    oDM_VanBangChungChiInfo.ChungChi = bool.Parse(dtb.Rows[i]["ChungChi"].ToString());
                    
                    oDM_VanBangChungChiInfoList.Add(oDM_VanBangChungChiInfo);
                }
            }
            return oDM_VanBangChungChiInfoList;
        }
        
        public void ToDataRow(DM_VanBangChungChiInfo pDM_VanBangChungChiInfo, ref DataRow dr)
        {

			dr[pDM_VanBangChungChiInfo.strDM_VanBangChungChiID] = pDM_VanBangChungChiInfo.DM_VanBangChungChiID;
			dr[pDM_VanBangChungChiInfo.strTen] = pDM_VanBangChungChiInfo.Ten;
			dr[pDM_VanBangChungChiInfo.strVanBang] = pDM_VanBangChungChiInfo.VanBang;
			dr[pDM_VanBangChungChiInfo.strChungChi] = pDM_VanBangChungChiInfo.ChungChi;
        }
        
        public void ToInfo(ref DM_VanBangChungChiInfo pDM_VanBangChungChiInfo, DataRow dr)
        {

			pDM_VanBangChungChiInfo.DM_VanBangChungChiID = int.Parse(dr[pDM_VanBangChungChiInfo.strDM_VanBangChungChiID].ToString());
			pDM_VanBangChungChiInfo.Ten = dr[pDM_VanBangChungChiInfo.strTen].ToString();
			pDM_VanBangChungChiInfo.VanBang = bool.Parse(dr[pDM_VanBangChungChiInfo.strVanBang].ToString());
			pDM_VanBangChungChiInfo.ChungChi = bool.Parse(dr[pDM_VanBangChungChiInfo.strChungChi].ToString());
        }
    }
}
