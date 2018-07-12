using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_LoaiQuy : cBBase
    {
        private cDDM_LoaiQuy oDDM_LoaiQuy;
        private DM_LoaiQuyInfo oDM_LoaiQuyInfo;

        public cBDM_LoaiQuy()        
        {
            oDDM_LoaiQuy = new cDDM_LoaiQuy();
        }

        public DataTable Get(DM_LoaiQuyInfo pDM_LoaiQuyInfo)        
        {
            return oDDM_LoaiQuy.Get(pDM_LoaiQuyInfo);
        }

        public int Add(DM_LoaiQuyInfo pDM_LoaiQuyInfo)
        {
			int ID = 0;
            ID = oDDM_LoaiQuy.Add(pDM_LoaiQuyInfo);
            mErrorMessage = oDDM_LoaiQuy.ErrorMessages;
            mErrorNumber = oDDM_LoaiQuy.ErrorNumber;
            return ID;
        }

        public void Update(DM_LoaiQuyInfo pDM_LoaiQuyInfo)
        {
            oDDM_LoaiQuy.Update(pDM_LoaiQuyInfo);
            mErrorMessage = oDDM_LoaiQuy.ErrorMessages;
            mErrorNumber = oDDM_LoaiQuy.ErrorNumber;
        }
        
        public void Delete(DM_LoaiQuyInfo pDM_LoaiQuyInfo)
        {
            oDDM_LoaiQuy.Delete(pDM_LoaiQuyInfo);
            mErrorMessage = oDDM_LoaiQuy.ErrorMessages;
            mErrorNumber = oDDM_LoaiQuy.ErrorNumber;
        }

        public List<DM_LoaiQuyInfo> GetList(DM_LoaiQuyInfo pDM_LoaiQuyInfo)
        {
            List<DM_LoaiQuyInfo> oDM_LoaiQuyInfoList = new List<DM_LoaiQuyInfo>();
            DataTable dtb = Get(pDM_LoaiQuyInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_LoaiQuyInfo = new DM_LoaiQuyInfo();

                    oDM_LoaiQuyInfo.DM_LoaiQuyID = int.Parse(dtb.Rows[i]["DM_LoaiQuyID"].ToString());
                    oDM_LoaiQuyInfo.TenLoaiQuy = dtb.Rows[i]["TenLoaiQuy"].ToString();
                    oDM_LoaiQuyInfo.GhiChu = dtb.Rows[i]["GhiChu"].ToString();
                    
                    oDM_LoaiQuyInfoList.Add(oDM_LoaiQuyInfo);
                }
            }
            return oDM_LoaiQuyInfoList;
        }
        
        public void ToDataRow(DM_LoaiQuyInfo pDM_LoaiQuyInfo, ref DataRow dr)
        {

			dr[pDM_LoaiQuyInfo.strDM_LoaiQuyID] = pDM_LoaiQuyInfo.DM_LoaiQuyID;
			dr[pDM_LoaiQuyInfo.strTenLoaiQuy] = pDM_LoaiQuyInfo.TenLoaiQuy;
			dr[pDM_LoaiQuyInfo.strGhiChu] = pDM_LoaiQuyInfo.GhiChu;
        }
        
        public void ToInfo(ref DM_LoaiQuyInfo pDM_LoaiQuyInfo, DataRow dr)
        {

			pDM_LoaiQuyInfo.DM_LoaiQuyID = int.Parse(dr[pDM_LoaiQuyInfo.strDM_LoaiQuyID].ToString());
			pDM_LoaiQuyInfo.TenLoaiQuy = dr[pDM_LoaiQuyInfo.strTenLoaiQuy].ToString();
			pDM_LoaiQuyInfo.GhiChu = dr[pDM_LoaiQuyInfo.strGhiChu].ToString();
        }
    }
}
