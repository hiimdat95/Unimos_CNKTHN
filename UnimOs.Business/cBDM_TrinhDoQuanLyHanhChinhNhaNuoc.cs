using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_TrinhDoQuanLyHanhChinhNhaNuoc : cBBase
    {
        private cDDM_TrinhDoQuanLyHanhChinhNhaNuoc oDDM_TrinhDoQuanLyHanhChinhNhaNuoc;
        private DM_TrinhDoQuanLyHanhChinhNhaNuocInfo oDM_TrinhDoQuanLyHanhChinhNhaNuocInfo;

        public cBDM_TrinhDoQuanLyHanhChinhNhaNuoc()        
        {
            oDDM_TrinhDoQuanLyHanhChinhNhaNuoc = new cDDM_TrinhDoQuanLyHanhChinhNhaNuoc();
        }

        public DataTable Get(DM_TrinhDoQuanLyHanhChinhNhaNuocInfo pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo)        
        {
            return oDDM_TrinhDoQuanLyHanhChinhNhaNuoc.Get(pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo);
        }

        public int Add(DM_TrinhDoQuanLyHanhChinhNhaNuocInfo pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo)
        {
			int ID = 0;
            ID = oDDM_TrinhDoQuanLyHanhChinhNhaNuoc.Add(pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo);
            mErrorMessage = oDDM_TrinhDoQuanLyHanhChinhNhaNuoc.ErrorMessages;
            mErrorNumber = oDDM_TrinhDoQuanLyHanhChinhNhaNuoc.ErrorNumber;
            return ID;
        }

        public void Update(DM_TrinhDoQuanLyHanhChinhNhaNuocInfo pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo)
        {
            oDDM_TrinhDoQuanLyHanhChinhNhaNuoc.Update(pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo);
            mErrorMessage = oDDM_TrinhDoQuanLyHanhChinhNhaNuoc.ErrorMessages;
            mErrorNumber = oDDM_TrinhDoQuanLyHanhChinhNhaNuoc.ErrorNumber;
        }
        
        public void Delete(DM_TrinhDoQuanLyHanhChinhNhaNuocInfo pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo)
        {
            oDDM_TrinhDoQuanLyHanhChinhNhaNuoc.Delete(pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo);
            mErrorMessage = oDDM_TrinhDoQuanLyHanhChinhNhaNuoc.ErrorMessages;
            mErrorNumber = oDDM_TrinhDoQuanLyHanhChinhNhaNuoc.ErrorNumber;
        }

        public List<DM_TrinhDoQuanLyHanhChinhNhaNuocInfo> GetList(DM_TrinhDoQuanLyHanhChinhNhaNuocInfo pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo)
        {
            List<DM_TrinhDoQuanLyHanhChinhNhaNuocInfo> oDM_TrinhDoQuanLyHanhChinhNhaNuocInfoList = new List<DM_TrinhDoQuanLyHanhChinhNhaNuocInfo>();
            DataTable dtb = Get(pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_TrinhDoQuanLyHanhChinhNhaNuocInfo = new DM_TrinhDoQuanLyHanhChinhNhaNuocInfo();

                    oDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.DM_TrinhDoQuanLyHanhChinhNhaNuocID = int.Parse(dtb.Rows[i]["DM_TrinhDoQuanLyHanhChinhNhaNuocID"].ToString());
                    oDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.TenTrinhDoQuanLyHanhChinhNhaNuoc = dtb.Rows[i]["TenTrinhDoQuanLyHanhChinhNhaNuoc"].ToString();
                    
                    oDM_TrinhDoQuanLyHanhChinhNhaNuocInfoList.Add(oDM_TrinhDoQuanLyHanhChinhNhaNuocInfo);
                }
            }
            return oDM_TrinhDoQuanLyHanhChinhNhaNuocInfoList;
        }
        
        public void ToDataRow(DM_TrinhDoQuanLyHanhChinhNhaNuocInfo pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo, ref DataRow dr)
        {

			dr[pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.strDM_TrinhDoQuanLyHanhChinhNhaNuocID] = pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.DM_TrinhDoQuanLyHanhChinhNhaNuocID;
			dr[pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.strTenTrinhDoQuanLyHanhChinhNhaNuoc] = pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.TenTrinhDoQuanLyHanhChinhNhaNuoc;
        }
        
        public void ToInfo(ref DM_TrinhDoQuanLyHanhChinhNhaNuocInfo pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo, DataRow dr)
        {

			pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.DM_TrinhDoQuanLyHanhChinhNhaNuocID = int.Parse(dr[pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.strDM_TrinhDoQuanLyHanhChinhNhaNuocID].ToString());
			pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.TenTrinhDoQuanLyHanhChinhNhaNuoc = dr[pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.strTenTrinhDoQuanLyHanhChinhNhaNuoc].ToString();
        }
    }
}
