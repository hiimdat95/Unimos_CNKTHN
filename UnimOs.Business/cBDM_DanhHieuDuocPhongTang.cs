using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_DanhHieuDuocPhongTang : cBBase
    {
        private cDDM_DanhHieuDuocPhongTang oDDM_DanhHieuDuocPhongTang;
        private DM_DanhHieuDuocPhongTangInfo oDM_DanhHieuDuocPhongTangInfo;

        public cBDM_DanhHieuDuocPhongTang()        
        {
            oDDM_DanhHieuDuocPhongTang = new cDDM_DanhHieuDuocPhongTang();
        }

        public DataTable Get(DM_DanhHieuDuocPhongTangInfo pDM_DanhHieuDuocPhongTangInfo)        
        {
            return oDDM_DanhHieuDuocPhongTang.Get(pDM_DanhHieuDuocPhongTangInfo);
        }

        public int Add(DM_DanhHieuDuocPhongTangInfo pDM_DanhHieuDuocPhongTangInfo)
        {
			int ID = 0;
            ID = oDDM_DanhHieuDuocPhongTang.Add(pDM_DanhHieuDuocPhongTangInfo);
            mErrorMessage = oDDM_DanhHieuDuocPhongTang.ErrorMessages;
            mErrorNumber = oDDM_DanhHieuDuocPhongTang.ErrorNumber;
            return ID;
        }

        public void Update(DM_DanhHieuDuocPhongTangInfo pDM_DanhHieuDuocPhongTangInfo)
        {
            oDDM_DanhHieuDuocPhongTang.Update(pDM_DanhHieuDuocPhongTangInfo);
            mErrorMessage = oDDM_DanhHieuDuocPhongTang.ErrorMessages;
            mErrorNumber = oDDM_DanhHieuDuocPhongTang.ErrorNumber;
        }
        
        public void Delete(DM_DanhHieuDuocPhongTangInfo pDM_DanhHieuDuocPhongTangInfo)
        {
            oDDM_DanhHieuDuocPhongTang.Delete(pDM_DanhHieuDuocPhongTangInfo);
            mErrorMessage = oDDM_DanhHieuDuocPhongTang.ErrorMessages;
            mErrorNumber = oDDM_DanhHieuDuocPhongTang.ErrorNumber;
        }

        public List<DM_DanhHieuDuocPhongTangInfo> GetList(DM_DanhHieuDuocPhongTangInfo pDM_DanhHieuDuocPhongTangInfo)
        {
            List<DM_DanhHieuDuocPhongTangInfo> oDM_DanhHieuDuocPhongTangInfoList = new List<DM_DanhHieuDuocPhongTangInfo>();
            DataTable dtb = Get(pDM_DanhHieuDuocPhongTangInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_DanhHieuDuocPhongTangInfo = new DM_DanhHieuDuocPhongTangInfo();

                    oDM_DanhHieuDuocPhongTangInfo.DM_DanhHieuDuocPhongTangID = int.Parse(dtb.Rows[i]["DM_DanhHieuDuocPhongTangID"].ToString());
                    oDM_DanhHieuDuocPhongTangInfo.TenDanhHieuDuocPhongTang = dtb.Rows[i]["TenDanhHieuDuocPhongTang"].ToString();
                    
                    oDM_DanhHieuDuocPhongTangInfoList.Add(oDM_DanhHieuDuocPhongTangInfo);
                }
            }
            return oDM_DanhHieuDuocPhongTangInfoList;
        }
        
        public void ToDataRow(DM_DanhHieuDuocPhongTangInfo pDM_DanhHieuDuocPhongTangInfo, ref DataRow dr)
        {

			dr[pDM_DanhHieuDuocPhongTangInfo.strDM_DanhHieuDuocPhongTangID] = pDM_DanhHieuDuocPhongTangInfo.DM_DanhHieuDuocPhongTangID;
			dr[pDM_DanhHieuDuocPhongTangInfo.strTenDanhHieuDuocPhongTang] = pDM_DanhHieuDuocPhongTangInfo.TenDanhHieuDuocPhongTang;
        }
        
        public void ToInfo(ref DM_DanhHieuDuocPhongTangInfo pDM_DanhHieuDuocPhongTangInfo, DataRow dr)
        {

			pDM_DanhHieuDuocPhongTangInfo.DM_DanhHieuDuocPhongTangID = int.Parse(dr[pDM_DanhHieuDuocPhongTangInfo.strDM_DanhHieuDuocPhongTangID].ToString());
			pDM_DanhHieuDuocPhongTangInfo.TenDanhHieuDuocPhongTang = dr[pDM_DanhHieuDuocPhongTangInfo.strTenDanhHieuDuocPhongTang].ToString();
        }
    }
}
