using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_LoaiChuyenMon : cBBase
    {
        private cDDM_LoaiChuyenMon oDDM_LoaiChuyenMon;

        public cBDM_LoaiChuyenMon()        
        {
            oDDM_LoaiChuyenMon = new cDDM_LoaiChuyenMon();
        }

        public DataTable Get(DM_LoaiChuyenMonInfo pDM_LoaiChuyenMonInfo)        
        {
            return oDDM_LoaiChuyenMon.Get(pDM_LoaiChuyenMonInfo);
        }

        public int Add(DM_LoaiChuyenMonInfo pDM_LoaiChuyenMonInfo)
        {
			int ID = 0;
            ID = oDDM_LoaiChuyenMon.Add(pDM_LoaiChuyenMonInfo);
            mErrorMessage = oDDM_LoaiChuyenMon.ErrorMessages;
            mErrorNumber = oDDM_LoaiChuyenMon.ErrorNumber;
            return ID;
        }

        public void Update(DM_LoaiChuyenMonInfo pDM_LoaiChuyenMonInfo)
        {
            oDDM_LoaiChuyenMon.Update(pDM_LoaiChuyenMonInfo);
            mErrorMessage = oDDM_LoaiChuyenMon.ErrorMessages;
            mErrorNumber = oDDM_LoaiChuyenMon.ErrorNumber;
        }
        
        public void Delete(DM_LoaiChuyenMonInfo pDM_LoaiChuyenMonInfo)
        {
            oDDM_LoaiChuyenMon.Delete(pDM_LoaiChuyenMonInfo);
            mErrorMessage = oDDM_LoaiChuyenMon.ErrorMessages;
            mErrorNumber = oDDM_LoaiChuyenMon.ErrorNumber;
        }

        public List<DM_LoaiChuyenMonInfo> GetList(DM_LoaiChuyenMonInfo pDM_LoaiChuyenMonInfo)
        {
            List<DM_LoaiChuyenMonInfo> oDM_LoaiChuyenMonInfoList = new List<DM_LoaiChuyenMonInfo>();
            DataTable dtb = Get(pDM_LoaiChuyenMonInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    pDM_LoaiChuyenMonInfo = new DM_LoaiChuyenMonInfo();

                    pDM_LoaiChuyenMonInfo.DM_LoaiChuyenMonID = int.Parse(dtb.Rows[i][pDM_LoaiChuyenMonInfo.strDM_LoaiChuyenMonID].ToString());
                    pDM_LoaiChuyenMonInfo.MaLoaiChuyenMon = dtb.Rows[i][pDM_LoaiChuyenMonInfo.strMaLoaiChuyenMon].ToString();
                    pDM_LoaiChuyenMonInfo.TenLoaiChuyenMon = dtb.Rows[i][pDM_LoaiChuyenMonInfo.strTenLoaiChuyenMon].ToString();
                    
                    oDM_LoaiChuyenMonInfoList.Add(pDM_LoaiChuyenMonInfo);
                }
            }
            return oDM_LoaiChuyenMonInfoList;
        }
        
        public void ToDataRow(DM_LoaiChuyenMonInfo pDM_LoaiChuyenMonInfo, ref DataRow dr)
        {

			dr[pDM_LoaiChuyenMonInfo.strDM_LoaiChuyenMonID] = pDM_LoaiChuyenMonInfo.DM_LoaiChuyenMonID;
			dr[pDM_LoaiChuyenMonInfo.strMaLoaiChuyenMon] = pDM_LoaiChuyenMonInfo.MaLoaiChuyenMon;
			dr[pDM_LoaiChuyenMonInfo.strTenLoaiChuyenMon] = pDM_LoaiChuyenMonInfo.TenLoaiChuyenMon;
        }
        
        public void ToInfo(ref DM_LoaiChuyenMonInfo pDM_LoaiChuyenMonInfo, DataRow dr)
        {

			pDM_LoaiChuyenMonInfo.DM_LoaiChuyenMonID = int.Parse(dr[pDM_LoaiChuyenMonInfo.strDM_LoaiChuyenMonID].ToString());
			pDM_LoaiChuyenMonInfo.MaLoaiChuyenMon = dr[pDM_LoaiChuyenMonInfo.strMaLoaiChuyenMon].ToString();
			pDM_LoaiChuyenMonInfo.TenLoaiChuyenMon = dr[pDM_LoaiChuyenMonInfo.strTenLoaiChuyenMon].ToString();
        }
    }
}
