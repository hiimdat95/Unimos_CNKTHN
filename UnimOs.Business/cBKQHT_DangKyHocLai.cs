using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_DangKyHocLai : cBBase
    {
        private cDKQHT_DangKyHocLai oDKQHT_DangKyHocLai;
        private KQHT_DangKyHocLaiInfo oKQHT_DangKyHocLaiInfo;

        public cBKQHT_DangKyHocLai()        
        {
            oDKQHT_DangKyHocLai = new cDKQHT_DangKyHocLai();
        }

        public DataTable Get(KQHT_DangKyHocLaiInfo pKQHT_DangKyHocLaiInfo)        
        {
            return oDKQHT_DangKyHocLai.Get(pKQHT_DangKyHocLaiInfo);
        }
        public DataTable GetSinhVien(int IDDM_Lop,int IDDM_LopDangKy, int IDKQHT_LopHocLai, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int Kieu)
        {
            return oDKQHT_DangKyHocLai.GetSinhVien(IDDM_Lop,IDDM_LopDangKy,IDKQHT_LopHocLai, IDDM_MonHoc, IDDM_NamHoc, HocKy, Kieu);
        }
        public void DeleteByMonHoc(int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy)
        {
            oDKQHT_DangKyHocLai.DeleteByMonHoc( IDDM_Lop,  IDDM_MonHoc,  IDDM_NamHoc,  HocKy);
            mErrorMessage = oDKQHT_DangKyHocLai.ErrorMessages;
            mErrorNumber = oDKQHT_DangKyHocLai.ErrorNumber;
        }
        public int Add(KQHT_DangKyHocLaiInfo pKQHT_DangKyHocLaiInfo)
        {
			int ID = 0;
            ID = oDKQHT_DangKyHocLai.Add(pKQHT_DangKyHocLaiInfo);
            mErrorMessage = oDKQHT_DangKyHocLai.ErrorMessages;
            mErrorNumber = oDKQHT_DangKyHocLai.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_DangKyHocLaiInfo pKQHT_DangKyHocLaiInfo)
        {
            oDKQHT_DangKyHocLai.Update(pKQHT_DangKyHocLaiInfo);
            mErrorMessage = oDKQHT_DangKyHocLai.ErrorMessages;
            mErrorNumber = oDKQHT_DangKyHocLai.ErrorNumber;
        }
        
        public void Delete(KQHT_DangKyHocLaiInfo pKQHT_DangKyHocLaiInfo)
        {
            oDKQHT_DangKyHocLai.Delete(pKQHT_DangKyHocLaiInfo);
            mErrorMessage = oDKQHT_DangKyHocLai.ErrorMessages;
            mErrorNumber = oDKQHT_DangKyHocLai.ErrorNumber;
        }

        public List<KQHT_DangKyHocLaiInfo> GetList(KQHT_DangKyHocLaiInfo pKQHT_DangKyHocLaiInfo)
        {
            List<KQHT_DangKyHocLaiInfo> oKQHT_DangKyHocLaiInfoList = new List<KQHT_DangKyHocLaiInfo>();
            DataTable dtb = Get(pKQHT_DangKyHocLaiInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_DangKyHocLaiInfo = new KQHT_DangKyHocLaiInfo();

                    oKQHT_DangKyHocLaiInfo.KQHT_DangKyHocLaiID = int.Parse(dtb.Rows[i]["KQHT_DangKyHocLaiID"].ToString());
                    oKQHT_DangKyHocLaiInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oKQHT_DangKyHocLaiInfo.IDDM_MonHoc = int.Parse(dtb.Rows[i]["IDDM_MonHoc"].ToString());
                    oKQHT_DangKyHocLaiInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oKQHT_DangKyHocLaiInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    oKQHT_DangKyHocLaiInfo.IDDM_LopDangKy = int.Parse(dtb.Rows[i]["IDDM_LopDangKy"].ToString());
                    oKQHT_DangKyHocLaiInfo.GhiChu = dtb.Rows[i]["GhiChu"].ToString();
                    oKQHT_DangKyHocLaiInfo.TienLePhi = double.Parse(dtb.Rows[i]["TienLePhi"].ToString());
                    oKQHT_DangKyHocLaiInfo.IDHT_User = int.Parse(dtb.Rows[i]["IDHT_User"].ToString());
                    oKQHT_DangKyHocLaiInfo.NgayDangKy = DateTime.Parse(dtb.Rows[i]["NgayDangKy"].ToString());
                    
                    oKQHT_DangKyHocLaiInfoList.Add(oKQHT_DangKyHocLaiInfo);
                }
            }
            return oKQHT_DangKyHocLaiInfoList;
        }
        
        public void ToDataRow(KQHT_DangKyHocLaiInfo pKQHT_DangKyHocLaiInfo, ref DataRow dr)
        {

			dr[pKQHT_DangKyHocLaiInfo.strKQHT_DangKyHocLaiID] = pKQHT_DangKyHocLaiInfo.KQHT_DangKyHocLaiID;
			dr[pKQHT_DangKyHocLaiInfo.strIDSV_SinhVien] = pKQHT_DangKyHocLaiInfo.IDSV_SinhVien;
			dr[pKQHT_DangKyHocLaiInfo.strIDDM_MonHoc] = pKQHT_DangKyHocLaiInfo.IDDM_MonHoc;
			dr[pKQHT_DangKyHocLaiInfo.strIDDM_NamHoc] = pKQHT_DangKyHocLaiInfo.IDDM_NamHoc;
			dr[pKQHT_DangKyHocLaiInfo.strHocKy] = pKQHT_DangKyHocLaiInfo.HocKy;
			dr[pKQHT_DangKyHocLaiInfo.strIDDM_LopDangKy] = pKQHT_DangKyHocLaiInfo.IDDM_LopDangKy;
			dr[pKQHT_DangKyHocLaiInfo.strGhiChu] = pKQHT_DangKyHocLaiInfo.GhiChu;
			dr[pKQHT_DangKyHocLaiInfo.strTienLePhi] = pKQHT_DangKyHocLaiInfo.TienLePhi;
			dr[pKQHT_DangKyHocLaiInfo.strIDHT_User] = pKQHT_DangKyHocLaiInfo.IDHT_User;
			dr[pKQHT_DangKyHocLaiInfo.strNgayDangKy] = pKQHT_DangKyHocLaiInfo.NgayDangKy;
        }
        
        public void ToInfo(ref KQHT_DangKyHocLaiInfo pKQHT_DangKyHocLaiInfo, DataRow dr)
        {

			pKQHT_DangKyHocLaiInfo.KQHT_DangKyHocLaiID = int.Parse(dr[pKQHT_DangKyHocLaiInfo.strKQHT_DangKyHocLaiID].ToString());
			pKQHT_DangKyHocLaiInfo.IDSV_SinhVien = int.Parse(dr[pKQHT_DangKyHocLaiInfo.strIDSV_SinhVien].ToString());
			pKQHT_DangKyHocLaiInfo.IDDM_MonHoc = int.Parse(dr[pKQHT_DangKyHocLaiInfo.strIDDM_MonHoc].ToString());
			pKQHT_DangKyHocLaiInfo.IDDM_NamHoc = int.Parse(dr[pKQHT_DangKyHocLaiInfo.strIDDM_NamHoc].ToString());
			pKQHT_DangKyHocLaiInfo.HocKy = int.Parse(dr[pKQHT_DangKyHocLaiInfo.strHocKy].ToString());
			pKQHT_DangKyHocLaiInfo.IDDM_LopDangKy = int.Parse(dr[pKQHT_DangKyHocLaiInfo.strIDDM_LopDangKy].ToString());
			pKQHT_DangKyHocLaiInfo.GhiChu = dr[pKQHT_DangKyHocLaiInfo.strGhiChu].ToString();
			pKQHT_DangKyHocLaiInfo.TienLePhi = double.Parse(dr[pKQHT_DangKyHocLaiInfo.strTienLePhi].ToString());
			pKQHT_DangKyHocLaiInfo.IDHT_User = int.Parse(dr[pKQHT_DangKyHocLaiInfo.strIDHT_User].ToString());
			pKQHT_DangKyHocLaiInfo.NgayDangKy = DateTime.Parse(dr[pKQHT_DangKyHocLaiInfo.strNgayDangKy].ToString());
        }
    }
}
