using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBSV_DoiTuongTroCap : cBBase
    {
        private cDSV_DoiTuongTroCap oDSV_DoiTuongTroCap;
        private SV_DoiTuongTroCapInfo oSV_DoiTuongTroCapInfo;

        public cBSV_DoiTuongTroCap()        
        {
            oDSV_DoiTuongTroCap = new cDSV_DoiTuongTroCap();
        }

        public DataTable Get(SV_DoiTuongTroCapInfo pSV_DoiTuongTroCapInfo)        
        {
            return oDSV_DoiTuongTroCap.Get(pSV_DoiTuongTroCapInfo);
        }

        public DataTable GetSinhVien(int IDDM_Khoa, int IDDM_He, int IDDM_TrinhDo, int IDDM_KhoaHoc, int IDDM_Nganh, int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            return oDSV_DoiTuongTroCap.GetSinhVien(IDDM_Khoa, IDDM_He, IDDM_TrinhDo, IDDM_KhoaHoc, IDDM_Nganh, IDDM_Lop, IDDM_NamHoc, HocKy);
        }

        public int Add(SV_DoiTuongTroCapInfo pSV_DoiTuongTroCapInfo)
        {
			int ID = 0;
            ID = oDSV_DoiTuongTroCap.Add(pSV_DoiTuongTroCapInfo);
            mErrorMessage = oDSV_DoiTuongTroCap.ErrorMessages;
            mErrorNumber = oDSV_DoiTuongTroCap.ErrorNumber;
            return ID;
        }

        public void Update(SV_DoiTuongTroCapInfo pSV_DoiTuongTroCapInfo)
        {
            oDSV_DoiTuongTroCap.Update(pSV_DoiTuongTroCapInfo);
            mErrorMessage = oDSV_DoiTuongTroCap.ErrorMessages;
            mErrorNumber = oDSV_DoiTuongTroCap.ErrorNumber;
        }
        
        public void Delete(SV_DoiTuongTroCapInfo pSV_DoiTuongTroCapInfo)
        {
            oDSV_DoiTuongTroCap.Delete(pSV_DoiTuongTroCapInfo);
            mErrorMessage = oDSV_DoiTuongTroCap.ErrorMessages;
            mErrorNumber = oDSV_DoiTuongTroCap.ErrorNumber;
        }

        public List<SV_DoiTuongTroCapInfo> GetList(SV_DoiTuongTroCapInfo pSV_DoiTuongTroCapInfo)
        {
            List<SV_DoiTuongTroCapInfo> oSV_DoiTuongTroCapInfoList = new List<SV_DoiTuongTroCapInfo>();
            DataTable dtb = Get(pSV_DoiTuongTroCapInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oSV_DoiTuongTroCapInfo = new SV_DoiTuongTroCapInfo();

                    oSV_DoiTuongTroCapInfo.SV_DoiTuongTroCapID = int.Parse(dtb.Rows[i]["SV_DoiTuongTroCapID"].ToString());
                    oSV_DoiTuongTroCapInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oSV_DoiTuongTroCapInfo.IDDM_DoiTuongTroCap = int.Parse(dtb.Rows[i]["IDDM_DoiTuongTroCap"].ToString());
                    oSV_DoiTuongTroCapInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    oSV_DoiTuongTroCapInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oSV_DoiTuongTroCapInfo.GhiChu = dtb.Rows[i]["GhiChu"].ToString();
                    
                    oSV_DoiTuongTroCapInfoList.Add(oSV_DoiTuongTroCapInfo);
                }
            }
            return oSV_DoiTuongTroCapInfoList;
        }
        
        public void ToDataRow(SV_DoiTuongTroCapInfo pSV_DoiTuongTroCapInfo, ref DataRow dr)
        {

			dr[pSV_DoiTuongTroCapInfo.strSV_DoiTuongTroCapID] = pSV_DoiTuongTroCapInfo.SV_DoiTuongTroCapID;
			dr[pSV_DoiTuongTroCapInfo.strIDSV_SinhVien] = pSV_DoiTuongTroCapInfo.IDSV_SinhVien;
			dr[pSV_DoiTuongTroCapInfo.strIDDM_DoiTuongTroCap] = pSV_DoiTuongTroCapInfo.IDDM_DoiTuongTroCap;
			dr[pSV_DoiTuongTroCapInfo.strHocKy] = pSV_DoiTuongTroCapInfo.HocKy;
			dr[pSV_DoiTuongTroCapInfo.strIDDM_NamHoc] = pSV_DoiTuongTroCapInfo.IDDM_NamHoc;
			dr[pSV_DoiTuongTroCapInfo.strGhiChu] = pSV_DoiTuongTroCapInfo.GhiChu;
        }
        
        public void ToInfo(ref SV_DoiTuongTroCapInfo pSV_DoiTuongTroCapInfo, DataRow dr)
        {

			pSV_DoiTuongTroCapInfo.SV_DoiTuongTroCapID = int.Parse(dr[pSV_DoiTuongTroCapInfo.strSV_DoiTuongTroCapID].ToString());
			pSV_DoiTuongTroCapInfo.IDSV_SinhVien = int.Parse(dr[pSV_DoiTuongTroCapInfo.strIDSV_SinhVien].ToString());
			pSV_DoiTuongTroCapInfo.IDDM_DoiTuongTroCap = int.Parse(dr[pSV_DoiTuongTroCapInfo.strIDDM_DoiTuongTroCap].ToString());
			pSV_DoiTuongTroCapInfo.HocKy = int.Parse(dr[pSV_DoiTuongTroCapInfo.strHocKy].ToString());
			pSV_DoiTuongTroCapInfo.IDDM_NamHoc = int.Parse(dr[pSV_DoiTuongTroCapInfo.strIDDM_NamHoc].ToString());
			pSV_DoiTuongTroCapInfo.GhiChu = dr[pSV_DoiTuongTroCapInfo.strGhiChu].ToString();
        }
    }
}
