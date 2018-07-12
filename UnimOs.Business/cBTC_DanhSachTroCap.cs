using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBTC_DanhSachTroCap : cBBase
    {
        private cDTC_DanhSachTroCap oDTC_DanhSachTroCap;
        private TC_DanhSachTroCapInfo oTC_DanhSachTroCapInfo;

        public cBTC_DanhSachTroCap()        
        {
            oDTC_DanhSachTroCap = new cDTC_DanhSachTroCap();
        }
        public DataTable GetInSinhVien(int IDDM_Khoa, int IDDM_He, int IDDM_TrinhDo, int IDDM_KhoaHoc, int IDDM_Nganh, int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            return oDTC_DanhSachTroCap.GetInSinhVien(IDDM_Khoa, IDDM_He, IDDM_TrinhDo, IDDM_KhoaHoc, IDDM_Nganh, IDDM_Lop, IDDM_NamHoc, HocKy);
        }
        public DataTable GetNotInSinhVien(int IDDM_Khoa, int IDDM_He, int IDDM_TrinhDo, int IDDM_KhoaHoc, int IDDM_Nganh, int IDDM_Lop, int IDDM_NamHoc, int HocKy, string NamHoc)
        {
            return oDTC_DanhSachTroCap.GetNotInSinhVien(IDDM_Khoa, IDDM_He, IDDM_TrinhDo, IDDM_KhoaHoc, IDDM_Nganh, IDDM_Lop, IDDM_NamHoc, HocKy, NamHoc);
        }
        public DataTable Get(TC_DanhSachTroCapInfo pTC_DanhSachTroCapInfo)        
        {
            return oDTC_DanhSachTroCap.Get(pTC_DanhSachTroCapInfo);
        }

        public int Add(TC_DanhSachTroCapInfo pTC_DanhSachTroCapInfo)
        {
			int ID = 0;
            ID = oDTC_DanhSachTroCap.Add(pTC_DanhSachTroCapInfo);
            mErrorMessage = oDTC_DanhSachTroCap.ErrorMessages;
            mErrorNumber = oDTC_DanhSachTroCap.ErrorNumber;
            return ID;
        }

        public void Update(TC_DanhSachTroCapInfo pTC_DanhSachTroCapInfo)
        {
            oDTC_DanhSachTroCap.Update(pTC_DanhSachTroCapInfo);
            mErrorMessage = oDTC_DanhSachTroCap.ErrorMessages;
            mErrorNumber = oDTC_DanhSachTroCap.ErrorNumber;
        }
        
        public void Delete(TC_DanhSachTroCapInfo pTC_DanhSachTroCapInfo)
        {
            oDTC_DanhSachTroCap.Delete(pTC_DanhSachTroCapInfo);
            mErrorMessage = oDTC_DanhSachTroCap.ErrorMessages;
            mErrorNumber = oDTC_DanhSachTroCap.ErrorNumber;
        }

        public List<TC_DanhSachTroCapInfo> GetList(TC_DanhSachTroCapInfo pTC_DanhSachTroCapInfo)
        {
            List<TC_DanhSachTroCapInfo> oTC_DanhSachTroCapInfoList = new List<TC_DanhSachTroCapInfo>();
            DataTable dtb = Get(pTC_DanhSachTroCapInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oTC_DanhSachTroCapInfo = new TC_DanhSachTroCapInfo();

                    oTC_DanhSachTroCapInfo.TC_DanhSachTroCapID = int.Parse(dtb.Rows[i]["TC_DanhSachTroCapID"].ToString());
                    oTC_DanhSachTroCapInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oTC_DanhSachTroCapInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oTC_DanhSachTroCapInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    oTC_DanhSachTroCapInfo.SoTien = double.Parse(dtb.Rows[i]["SoTien"].ToString());
                    oTC_DanhSachTroCapInfo.GhiChu = dtb.Rows[i]["GhiChu"].ToString();
                    
                    oTC_DanhSachTroCapInfoList.Add(oTC_DanhSachTroCapInfo);
                }
            }
            return oTC_DanhSachTroCapInfoList;
        }
        
        public void ToDataRow(TC_DanhSachTroCapInfo pTC_DanhSachTroCapInfo, ref DataRow dr)
        {

			dr[pTC_DanhSachTroCapInfo.strTC_DanhSachTroCapID] = pTC_DanhSachTroCapInfo.TC_DanhSachTroCapID;
			dr[pTC_DanhSachTroCapInfo.strIDSV_SinhVien] = pTC_DanhSachTroCapInfo.IDSV_SinhVien;
			dr[pTC_DanhSachTroCapInfo.strIDDM_NamHoc] = pTC_DanhSachTroCapInfo.IDDM_NamHoc;
			dr[pTC_DanhSachTroCapInfo.strHocKy] = pTC_DanhSachTroCapInfo.HocKy;
			dr[pTC_DanhSachTroCapInfo.strSoTien] = pTC_DanhSachTroCapInfo.SoTien;
			dr[pTC_DanhSachTroCapInfo.strGhiChu] = pTC_DanhSachTroCapInfo.GhiChu;
        }
        
        public void ToInfo(ref TC_DanhSachTroCapInfo pTC_DanhSachTroCapInfo, DataRow dr)
        {

			pTC_DanhSachTroCapInfo.TC_DanhSachTroCapID = int.Parse(dr[pTC_DanhSachTroCapInfo.strTC_DanhSachTroCapID].ToString());
			pTC_DanhSachTroCapInfo.IDSV_SinhVien = int.Parse(dr[pTC_DanhSachTroCapInfo.strIDSV_SinhVien].ToString());
			pTC_DanhSachTroCapInfo.IDDM_NamHoc = int.Parse(dr[pTC_DanhSachTroCapInfo.strIDDM_NamHoc].ToString());
			pTC_DanhSachTroCapInfo.HocKy = int.Parse(dr[pTC_DanhSachTroCapInfo.strHocKy].ToString());
			pTC_DanhSachTroCapInfo.SoTien = double.Parse(dr[pTC_DanhSachTroCapInfo.strSoTien].ToString());
			pTC_DanhSachTroCapInfo.GhiChu = dr[pTC_DanhSachTroCapInfo.strGhiChu].ToString();
        }
    }
}
