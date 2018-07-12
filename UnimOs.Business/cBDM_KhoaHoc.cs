using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_KhoaHoc : cBBase
    {
        private cDDM_KhoaHoc oDDM_KhoaHoc;
        private DM_KhoaHocInfo oDM_KhoaHocInfo;

        public cBDM_KhoaHoc()        
        {
            oDDM_KhoaHoc = new cDDM_KhoaHoc();
        }

        public DataTable Get(DM_KhoaHocInfo pDM_KhoaHocInfo)        
        {
            return oDDM_KhoaHoc.Get(pDM_KhoaHocInfo);
        }

        public DataTable GetAll()
        {
            return oDDM_KhoaHoc.GetAll();
        }

        public int Add(DM_KhoaHocInfo pDM_KhoaHocInfo)
        {
			int ID = 0;
            ID = oDDM_KhoaHoc.Add(pDM_KhoaHocInfo);
            mErrorMessage = oDDM_KhoaHoc.ErrorMessages;
            mErrorNumber = oDDM_KhoaHoc.ErrorNumber;
            return ID;
        }

        public void Update(DM_KhoaHocInfo pDM_KhoaHocInfo)
        {
            oDDM_KhoaHoc.Update(pDM_KhoaHocInfo);
            mErrorMessage = oDDM_KhoaHoc.ErrorMessages;
            mErrorNumber = oDDM_KhoaHoc.ErrorNumber;
        }
        
        public void Delete(DM_KhoaHocInfo pDM_KhoaHocInfo)
        {
            oDDM_KhoaHoc.Delete(pDM_KhoaHocInfo);
            mErrorMessage = oDDM_KhoaHoc.ErrorMessages;
            mErrorNumber = oDDM_KhoaHoc.ErrorNumber;
        }

        public List<DM_KhoaHocInfo> GetList(DM_KhoaHocInfo pDM_KhoaHocInfo)
        {
            List<DM_KhoaHocInfo> oDM_KhoaHocInfoList = new List<DM_KhoaHocInfo>();
            DataTable dtb = Get(pDM_KhoaHocInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_KhoaHocInfo = new DM_KhoaHocInfo();

                    oDM_KhoaHocInfo.DM_KhoaHocID = int.Parse(dtb.Rows[i]["DM_KhoaHocID"].ToString());
                    oDM_KhoaHocInfo.TenKhoaHoc = dtb.Rows[i]["TenKhoaHoc"].ToString();
                    oDM_KhoaHocInfo.IDDM_TrinhDo = int.Parse(dtb.Rows[i]["IDDM_TrinhDo"].ToString());
                    oDM_KhoaHocInfo.IDDM_Nganh = int.Parse(dtb.Rows[i]["IDDM_Nganh"].ToString());
                    oDM_KhoaHocInfo.IDDM_ChuyenNganh = int.Parse(dtb.Rows[i]["IDDM_ChuyenNganh"].ToString());
                    oDM_KhoaHocInfo.NamVaoTruong = int.Parse(dtb.Rows[i]["NamVaoTruong"].ToString());
                    oDM_KhoaHocInfo.NamRaTruong = int.Parse(dtb.Rows[i]["NamRaTruong"].ToString());
                    
                    oDM_KhoaHocInfoList.Add(oDM_KhoaHocInfo);
                }
            }
            return oDM_KhoaHocInfoList;
        }
        
        public void ToDataRow(DM_KhoaHocInfo pDM_KhoaHocInfo, ref DataRow dr)
        {

			dr[pDM_KhoaHocInfo.strDM_KhoaHocID] = pDM_KhoaHocInfo.DM_KhoaHocID;
			dr[pDM_KhoaHocInfo.strTenKhoaHoc] = pDM_KhoaHocInfo.TenKhoaHoc;
			dr[pDM_KhoaHocInfo.strIDDM_TrinhDo] = pDM_KhoaHocInfo.IDDM_TrinhDo;
			dr[pDM_KhoaHocInfo.strIDDM_Nganh] = pDM_KhoaHocInfo.IDDM_Nganh;
			dr[pDM_KhoaHocInfo.strIDDM_ChuyenNganh] = pDM_KhoaHocInfo.IDDM_ChuyenNganh;
			dr[pDM_KhoaHocInfo.strNamVaoTruong] = pDM_KhoaHocInfo.NamVaoTruong;
			dr[pDM_KhoaHocInfo.strNamRaTruong] = pDM_KhoaHocInfo.NamRaTruong;
        }
    }
}
