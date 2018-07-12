using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_TrinhDoLyLuan : cBBase
    {
        private cDDM_TrinhDoLyLuan oDDM_TrinhDoLyLuan;
        private DM_TrinhDoLyLuanInfo oDM_TrinhDoLyLuanInfo;

        public cBDM_TrinhDoLyLuan()        
        {
            oDDM_TrinhDoLyLuan = new cDDM_TrinhDoLyLuan();
        }

        public DataTable Get(DM_TrinhDoLyLuanInfo pDM_TrinhDoLyLuanInfo)        
        {
            return oDDM_TrinhDoLyLuan.Get(pDM_TrinhDoLyLuanInfo);
        }

        public int Add(DM_TrinhDoLyLuanInfo pDM_TrinhDoLyLuanInfo)
        {
			int ID = 0;
            ID = oDDM_TrinhDoLyLuan.Add(pDM_TrinhDoLyLuanInfo);
            mErrorMessage = oDDM_TrinhDoLyLuan.ErrorMessages;
            mErrorNumber = oDDM_TrinhDoLyLuan.ErrorNumber;
            return ID;
        }

        public void Update(DM_TrinhDoLyLuanInfo pDM_TrinhDoLyLuanInfo)
        {
            oDDM_TrinhDoLyLuan.Update(pDM_TrinhDoLyLuanInfo);
            mErrorMessage = oDDM_TrinhDoLyLuan.ErrorMessages;
            mErrorNumber = oDDM_TrinhDoLyLuan.ErrorNumber;
        }
        
        public void Delete(DM_TrinhDoLyLuanInfo pDM_TrinhDoLyLuanInfo)
        {
            oDDM_TrinhDoLyLuan.Delete(pDM_TrinhDoLyLuanInfo);
            mErrorMessage = oDDM_TrinhDoLyLuan.ErrorMessages;
            mErrorNumber = oDDM_TrinhDoLyLuan.ErrorNumber;
        }

        public List<DM_TrinhDoLyLuanInfo> GetList(DM_TrinhDoLyLuanInfo pDM_TrinhDoLyLuanInfo)
        {
            List<DM_TrinhDoLyLuanInfo> oDM_TrinhDoLyLuanInfoList = new List<DM_TrinhDoLyLuanInfo>();
            DataTable dtb = Get(pDM_TrinhDoLyLuanInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_TrinhDoLyLuanInfo = new DM_TrinhDoLyLuanInfo();

                    oDM_TrinhDoLyLuanInfo.DM_TrinhDoLyLuanID = int.Parse(dtb.Rows[i]["DM_TrinhDoLyLuanID"].ToString());
                    oDM_TrinhDoLyLuanInfo.TenTrinhDoLyLuan = dtb.Rows[i]["TenTrinhDoLyLuan"].ToString();
                    
                    oDM_TrinhDoLyLuanInfoList.Add(oDM_TrinhDoLyLuanInfo);
                }
            }
            return oDM_TrinhDoLyLuanInfoList;
        }
        
        public void ToDataRow(DM_TrinhDoLyLuanInfo pDM_TrinhDoLyLuanInfo, ref DataRow dr)
        {

			dr[pDM_TrinhDoLyLuanInfo.strDM_TrinhDoLyLuanID] = pDM_TrinhDoLyLuanInfo.DM_TrinhDoLyLuanID;
			dr[pDM_TrinhDoLyLuanInfo.strTenTrinhDoLyLuan] = pDM_TrinhDoLyLuanInfo.TenTrinhDoLyLuan;
        }
        
        public void ToInfo(ref DM_TrinhDoLyLuanInfo pDM_TrinhDoLyLuanInfo, DataRow dr)
        {

			pDM_TrinhDoLyLuanInfo.DM_TrinhDoLyLuanID = int.Parse(dr[pDM_TrinhDoLyLuanInfo.strDM_TrinhDoLyLuanID].ToString());
			pDM_TrinhDoLyLuanInfo.TenTrinhDoLyLuan = dr[pDM_TrinhDoLyLuanInfo.strTenTrinhDoLyLuan].ToString();
        }
    }
}
