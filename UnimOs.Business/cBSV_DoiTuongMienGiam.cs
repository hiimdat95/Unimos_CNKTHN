using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBSV_DoiTuongMienGiam : cBBase
    {
        private cDSV_DoiTuongMienGiam oDSV_DoiTuongMienGiam;
        private SV_DoiTuongMienGiamInfo oSV_DoiTuongMienGiamInfo;

        public cBSV_DoiTuongMienGiam()        
        {
            oDSV_DoiTuongMienGiam = new cDSV_DoiTuongMienGiam();
        }

        public DataTable Get(SV_DoiTuongMienGiamInfo pSV_DoiTuongMienGiamInfo)        
        {
            return oDSV_DoiTuongMienGiam.Get(pSV_DoiTuongMienGiamInfo);
        }

        public DataTable GetSinhVien(int IDDM_Khoa, int IDDM_He, int IDDM_TrinhDo, int IDDM_KhoaHoc, int IDDM_Nganh, int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            return oDSV_DoiTuongMienGiam.GetSinhVien(IDDM_Khoa, IDDM_He, IDDM_TrinhDo, IDDM_KhoaHoc, IDDM_Nganh, IDDM_Lop, IDDM_NamHoc, HocKy);
        }

        public int Add(SV_DoiTuongMienGiamInfo pSV_DoiTuongMienGiamInfo)
        {
			int ID = 0;
            ID = oDSV_DoiTuongMienGiam.Add(pSV_DoiTuongMienGiamInfo);
            mErrorMessage = oDSV_DoiTuongMienGiam.ErrorMessages;
            mErrorNumber = oDSV_DoiTuongMienGiam.ErrorNumber;
            return ID;
        }

        public void Update(SV_DoiTuongMienGiamInfo pSV_DoiTuongMienGiamInfo)
        {
            oDSV_DoiTuongMienGiam.Update(pSV_DoiTuongMienGiamInfo);
            mErrorMessage = oDSV_DoiTuongMienGiam.ErrorMessages;
            mErrorNumber = oDSV_DoiTuongMienGiam.ErrorNumber;
        }
        
        public void Delete(SV_DoiTuongMienGiamInfo pSV_DoiTuongMienGiamInfo)
        {
            oDSV_DoiTuongMienGiam.Delete(pSV_DoiTuongMienGiamInfo);
            mErrorMessage = oDSV_DoiTuongMienGiam.ErrorMessages;
            mErrorNumber = oDSV_DoiTuongMienGiam.ErrorNumber;
        }

        public List<SV_DoiTuongMienGiamInfo> GetList(SV_DoiTuongMienGiamInfo pSV_DoiTuongMienGiamInfo)
        {
            List<SV_DoiTuongMienGiamInfo> oSV_DoiTuongMienGiamInfoList = new List<SV_DoiTuongMienGiamInfo>();
            DataTable dtb = Get(pSV_DoiTuongMienGiamInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oSV_DoiTuongMienGiamInfo = new SV_DoiTuongMienGiamInfo();

                    oSV_DoiTuongMienGiamInfo.SV_DoiTuongMienGiamID = int.Parse(dtb.Rows[i]["SV_DoiTuongMienGiamID"].ToString());
                    oSV_DoiTuongMienGiamInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oSV_DoiTuongMienGiamInfo.IDDM_DoiTuongMienGiam = int.Parse(dtb.Rows[i]["IDDM_DoiTuongMienGiam"].ToString());
                    oSV_DoiTuongMienGiamInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    oSV_DoiTuongMienGiamInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oSV_DoiTuongMienGiamInfo.GhiChu = dtb.Rows[i]["GhiChu"].ToString();
                    
                    oSV_DoiTuongMienGiamInfoList.Add(oSV_DoiTuongMienGiamInfo);
                }
            }
            return oSV_DoiTuongMienGiamInfoList;
        }
        
        public void ToDataRow(SV_DoiTuongMienGiamInfo pSV_DoiTuongMienGiamInfo, ref DataRow dr)
        {

			dr[pSV_DoiTuongMienGiamInfo.strSV_DoiTuongMienGiamID] = pSV_DoiTuongMienGiamInfo.SV_DoiTuongMienGiamID;
			dr[pSV_DoiTuongMienGiamInfo.strIDSV_SinhVien] = pSV_DoiTuongMienGiamInfo.IDSV_SinhVien;
			dr[pSV_DoiTuongMienGiamInfo.strIDDM_DoiTuongMienGiam] = pSV_DoiTuongMienGiamInfo.IDDM_DoiTuongMienGiam;
			dr[pSV_DoiTuongMienGiamInfo.strHocKy] = pSV_DoiTuongMienGiamInfo.HocKy;
			dr[pSV_DoiTuongMienGiamInfo.strIDDM_NamHoc] = pSV_DoiTuongMienGiamInfo.IDDM_NamHoc;
			dr[pSV_DoiTuongMienGiamInfo.strGhiChu] = pSV_DoiTuongMienGiamInfo.GhiChu;
        }
        
        public void ToInfo(ref SV_DoiTuongMienGiamInfo pSV_DoiTuongMienGiamInfo, DataRow dr)
        {

			pSV_DoiTuongMienGiamInfo.SV_DoiTuongMienGiamID = int.Parse(dr[pSV_DoiTuongMienGiamInfo.strSV_DoiTuongMienGiamID].ToString());
			pSV_DoiTuongMienGiamInfo.IDSV_SinhVien = int.Parse(dr[pSV_DoiTuongMienGiamInfo.strIDSV_SinhVien].ToString());
			pSV_DoiTuongMienGiamInfo.IDDM_DoiTuongMienGiam = int.Parse(dr[pSV_DoiTuongMienGiamInfo.strIDDM_DoiTuongMienGiam].ToString());
			pSV_DoiTuongMienGiamInfo.HocKy = int.Parse(dr[pSV_DoiTuongMienGiamInfo.strHocKy].ToString());
			pSV_DoiTuongMienGiamInfo.IDDM_NamHoc = int.Parse(dr[pSV_DoiTuongMienGiamInfo.strIDDM_NamHoc].ToString());
			pSV_DoiTuongMienGiamInfo.GhiChu = dr[pSV_DoiTuongMienGiamInfo.strGhiChu].ToString();
        }
    }
}
