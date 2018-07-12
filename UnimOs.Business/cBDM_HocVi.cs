using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_HocVi : cBBase
    {
        private cDDM_HocVi oDDM_HocVi;
        private DM_HocViInfo oDM_HocViInfo;

        public cBDM_HocVi()        
        {
            oDDM_HocVi = new cDDM_HocVi();
        }

        public DataTable Get(DM_HocViInfo pDM_HocViInfo)        
        {
            return oDDM_HocVi.Get(pDM_HocViInfo);
        }

        public int Add(DM_HocViInfo pDM_HocViInfo)
        {
			int ID = 0;
            ID = oDDM_HocVi.Add(pDM_HocViInfo);
            mErrorMessage = oDDM_HocVi.ErrorMessages;
            mErrorNumber = oDDM_HocVi.ErrorNumber;
            return ID;
        }

        public void Update(DM_HocViInfo pDM_HocViInfo)
        {
            oDDM_HocVi.Update(pDM_HocViInfo);
            mErrorMessage = oDDM_HocVi.ErrorMessages;
            mErrorNumber = oDDM_HocVi.ErrorNumber;
        }
        
        public void Delete(DM_HocViInfo pDM_HocViInfo)
        {
            oDDM_HocVi.Delete(pDM_HocViInfo);
            mErrorMessage = oDDM_HocVi.ErrorMessages;
            mErrorNumber = oDDM_HocVi.ErrorNumber;
        }

        public List<DM_HocViInfo> GetList(DM_HocViInfo pDM_HocViInfo)
        {
            List<DM_HocViInfo> oDM_HocViInfoList = new List<DM_HocViInfo>();
            DataTable dtb = Get(pDM_HocViInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_HocViInfo = new DM_HocViInfo();

                    oDM_HocViInfo.DM_HocViID = int.Parse(dtb.Rows[i]["DM_HocViID"].ToString());
                    oDM_HocViInfo.TenHocVi = dtb.Rows[i]["TenHocVi"].ToString();
                    
                    oDM_HocViInfoList.Add(oDM_HocViInfo);
                }
            }
            return oDM_HocViInfoList;
        }
        
        public void ToDataRow(DM_HocViInfo pDM_HocViInfo, ref DataRow dr)
        {

			dr[pDM_HocViInfo.strDM_HocViID] = pDM_HocViInfo.DM_HocViID;
			dr[pDM_HocViInfo.strTenHocVi] = pDM_HocViInfo.TenHocVi;
            dr[pDM_HocViInfo.strIDDM_LoaiChuyenMon] = pDM_HocViInfo.IDDM_LoaiChuyenMon;
        }
        
        public void ToInfo(ref DM_HocViInfo pDM_HocViInfo, DataRow dr)
        {

			pDM_HocViInfo.DM_HocViID = int.Parse(dr[pDM_HocViInfo.strDM_HocViID].ToString());
			pDM_HocViInfo.TenHocVi = dr[pDM_HocViInfo.strTenHocVi].ToString();
            pDM_HocViInfo.IDDM_LoaiChuyenMon = int.Parse("0" + dr[pDM_HocViInfo.strIDDM_LoaiChuyenMon]);
        }
    }
}
