using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_TrinhDoChuyenMon : cBBase
    {
        private cDDM_TrinhDoChuyenMon oDDM_TrinhDoChuyenMon;
        private DM_TrinhDoChuyenMonInfo oDM_TrinhDoChuyenMonInfo;

        public cBDM_TrinhDoChuyenMon()        
        {
            oDDM_TrinhDoChuyenMon = new cDDM_TrinhDoChuyenMon();
        }

        public DataTable Get(DM_TrinhDoChuyenMonInfo pDM_TrinhDoChuyenMonInfo)        
        {
            return oDDM_TrinhDoChuyenMon.Get(pDM_TrinhDoChuyenMonInfo);
        }

        public int Add(DM_TrinhDoChuyenMonInfo pDM_TrinhDoChuyenMonInfo)
        {
			int ID = 0;
            ID = oDDM_TrinhDoChuyenMon.Add(pDM_TrinhDoChuyenMonInfo);
            mErrorMessage = oDDM_TrinhDoChuyenMon.ErrorMessages;
            mErrorNumber = oDDM_TrinhDoChuyenMon.ErrorNumber;
            return ID;
        }

        public void Update(DM_TrinhDoChuyenMonInfo pDM_TrinhDoChuyenMonInfo)
        {
            oDDM_TrinhDoChuyenMon.Update(pDM_TrinhDoChuyenMonInfo);
            mErrorMessage = oDDM_TrinhDoChuyenMon.ErrorMessages;
            mErrorNumber = oDDM_TrinhDoChuyenMon.ErrorNumber;
        }
        
        public void Delete(DM_TrinhDoChuyenMonInfo pDM_TrinhDoChuyenMonInfo)
        {
            oDDM_TrinhDoChuyenMon.Delete(pDM_TrinhDoChuyenMonInfo);
            mErrorMessage = oDDM_TrinhDoChuyenMon.ErrorMessages;
            mErrorNumber = oDDM_TrinhDoChuyenMon.ErrorNumber;
        }

        public List<DM_TrinhDoChuyenMonInfo> GetList(DM_TrinhDoChuyenMonInfo pDM_TrinhDoChuyenMonInfo)
        {
            List<DM_TrinhDoChuyenMonInfo> oDM_TrinhDoChuyenMonInfoList = new List<DM_TrinhDoChuyenMonInfo>();
            DataTable dtb = Get(pDM_TrinhDoChuyenMonInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_TrinhDoChuyenMonInfo = new DM_TrinhDoChuyenMonInfo();

                    oDM_TrinhDoChuyenMonInfo.DM_TrinhDoChuyenMonID = int.Parse(dtb.Rows[i]["DM_TrinhDoChuyenMonID"].ToString());
                    oDM_TrinhDoChuyenMonInfo.TenTrinhDoChuyenMon = dtb.Rows[i]["TenTrinhDoChuyenMon"].ToString();
                    
                    oDM_TrinhDoChuyenMonInfoList.Add(oDM_TrinhDoChuyenMonInfo);
                }
            }
            return oDM_TrinhDoChuyenMonInfoList;
        }
        
        public void ToDataRow(DM_TrinhDoChuyenMonInfo pDM_TrinhDoChuyenMonInfo, ref DataRow dr)
        {
			dr[pDM_TrinhDoChuyenMonInfo.strDM_TrinhDoChuyenMonID] = pDM_TrinhDoChuyenMonInfo.DM_TrinhDoChuyenMonID;
			dr[pDM_TrinhDoChuyenMonInfo.strTenTrinhDoChuyenMon] = pDM_TrinhDoChuyenMonInfo.TenTrinhDoChuyenMon;
            dr["ParentID"] = pDM_TrinhDoChuyenMonInfo.ParentID;
        }
        
        public void ToInfo(ref DM_TrinhDoChuyenMonInfo pDM_TrinhDoChuyenMonInfo, DataRow dr)
        {
			pDM_TrinhDoChuyenMonInfo.DM_TrinhDoChuyenMonID = int.Parse(dr[pDM_TrinhDoChuyenMonInfo.strDM_TrinhDoChuyenMonID].ToString());
			pDM_TrinhDoChuyenMonInfo.TenTrinhDoChuyenMon = dr[pDM_TrinhDoChuyenMonInfo.strTenTrinhDoChuyenMon].ToString();
            pDM_TrinhDoChuyenMonInfo.ParentID = "" + dr["ParentID"] == "" ? 0 : int.Parse(dr["ParentID"].ToString());
        }
    }
}
