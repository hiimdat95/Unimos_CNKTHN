using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_DangKyThiLai : cBBase
    {
        private cDKQHT_DangKyThiLai oDKQHT_DangKyThiLai;
        private KQHT_DangKyThiLaiInfo oKQHT_DangKyThiLaiInfo;

        public cBKQHT_DangKyThiLai()        
        {
            oDKQHT_DangKyThiLai = new cDKQHT_DangKyThiLai();
        }

        public DataTable Get(KQHT_DangKyThiLaiInfo pKQHT_DangKyThiLaiInfo)        
        {
            return oDKQHT_DangKyThiLai.Get(pKQHT_DangKyThiLaiInfo);
        }

        public DataTable GetSinhVien( int IDDM_Lop,int IDDM_MonHoc,int IDNamHoc,int HocKy ,int Kieu,int LanThi)
        {
            return oDKQHT_DangKyThiLai.GetSinhVien(IDDM_Lop, IDDM_MonHoc, IDNamHoc, HocKy, Kieu, LanThi);
        }
        public void DeleteByMonHoc(int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi)
        {
            oDKQHT_DangKyThiLai.DeleteByMonHoc(IDDM_Lop, IDDM_MonHoc, IDDM_NamHoc, HocKy, LanThi);
            mErrorMessage = oDKQHT_DangKyThiLai.ErrorMessages;
            mErrorNumber = oDKQHT_DangKyThiLai.ErrorNumber;
        }
        public int Add(KQHT_DangKyThiLaiInfo pKQHT_DangKyThiLaiInfo)
        {
			int ID = 0;
            ID = oDKQHT_DangKyThiLai.Add(pKQHT_DangKyThiLaiInfo);
            mErrorMessage = oDKQHT_DangKyThiLai.ErrorMessages;
            mErrorNumber = oDKQHT_DangKyThiLai.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_DangKyThiLaiInfo pKQHT_DangKyThiLaiInfo)
        {
            oDKQHT_DangKyThiLai.Update(pKQHT_DangKyThiLaiInfo);
            mErrorMessage = oDKQHT_DangKyThiLai.ErrorMessages;
            mErrorNumber = oDKQHT_DangKyThiLai.ErrorNumber;
        }
        
        public void Delete(KQHT_DangKyThiLaiInfo pKQHT_DangKyThiLaiInfo)
        {
            oDKQHT_DangKyThiLai.Delete(pKQHT_DangKyThiLaiInfo);
            mErrorMessage = oDKQHT_DangKyThiLai.ErrorMessages;
            mErrorNumber = oDKQHT_DangKyThiLai.ErrorNumber;
        }

        public List<KQHT_DangKyThiLaiInfo> GetList(KQHT_DangKyThiLaiInfo pKQHT_DangKyThiLaiInfo)
        {
            List<KQHT_DangKyThiLaiInfo> oKQHT_DangKyThiLaiInfoList = new List<KQHT_DangKyThiLaiInfo>();
            DataTable dtb = Get(pKQHT_DangKyThiLaiInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_DangKyThiLaiInfo = new KQHT_DangKyThiLaiInfo();

                    oKQHT_DangKyThiLaiInfo.KQHT_DangKyThiLaiID = int.Parse(dtb.Rows[i]["KQHT_DangKyThiLaiID"].ToString());
                    oKQHT_DangKyThiLaiInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oKQHT_DangKyThiLaiInfo.IDDM_MonHoc = int.Parse(dtb.Rows[i]["IDDM_MonHoc"].ToString());
                    oKQHT_DangKyThiLaiInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oKQHT_DangKyThiLaiInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    oKQHT_DangKyThiLaiInfo.IDKQHT_ToChucThi = int.Parse(dtb.Rows[i]["IDKQHT_ToChucThi"].ToString());
                    oKQHT_DangKyThiLaiInfo.GhiChu = dtb.Rows[i]["GhiChu"].ToString();
                    oKQHT_DangKyThiLaiInfo.TienLePhi = double.Parse(dtb.Rows[i]["TienLePhi"].ToString());
                    oKQHT_DangKyThiLaiInfo.IDHT_User = int.Parse(dtb.Rows[i]["IDHT_User"].ToString());
                    oKQHT_DangKyThiLaiInfo.NgayDangKy = DateTime.Parse(dtb.Rows[i]["NgayDangKy"].ToString());
                    
                    oKQHT_DangKyThiLaiInfoList.Add(oKQHT_DangKyThiLaiInfo);
                }
            }
            return oKQHT_DangKyThiLaiInfoList;
        }
        
        public void ToDataRow(KQHT_DangKyThiLaiInfo pKQHT_DangKyThiLaiInfo, ref DataRow dr)
        {

			dr[pKQHT_DangKyThiLaiInfo.strKQHT_DangKyThiLaiID] = pKQHT_DangKyThiLaiInfo.KQHT_DangKyThiLaiID;
			dr[pKQHT_DangKyThiLaiInfo.strIDSV_SinhVien] = pKQHT_DangKyThiLaiInfo.IDSV_SinhVien;
			dr[pKQHT_DangKyThiLaiInfo.strIDDM_MonHoc] = pKQHT_DangKyThiLaiInfo.IDDM_MonHoc;
			dr[pKQHT_DangKyThiLaiInfo.strIDDM_NamHoc] = pKQHT_DangKyThiLaiInfo.IDDM_NamHoc;
			dr[pKQHT_DangKyThiLaiInfo.strHocKy] = pKQHT_DangKyThiLaiInfo.HocKy;
			dr[pKQHT_DangKyThiLaiInfo.strIDKQHT_ToChucThi] = pKQHT_DangKyThiLaiInfo.IDKQHT_ToChucThi;
			dr[pKQHT_DangKyThiLaiInfo.strGhiChu] = pKQHT_DangKyThiLaiInfo.GhiChu;
			dr[pKQHT_DangKyThiLaiInfo.strTienLePhi] = pKQHT_DangKyThiLaiInfo.TienLePhi;
			dr[pKQHT_DangKyThiLaiInfo.strIDHT_User] = pKQHT_DangKyThiLaiInfo.IDHT_User;
			dr[pKQHT_DangKyThiLaiInfo.strNgayDangKy] = pKQHT_DangKyThiLaiInfo.NgayDangKy;
        }
        
        public void ToInfo(ref KQHT_DangKyThiLaiInfo pKQHT_DangKyThiLaiInfo, DataRow dr)
        {

			pKQHT_DangKyThiLaiInfo.KQHT_DangKyThiLaiID = int.Parse(dr[pKQHT_DangKyThiLaiInfo.strKQHT_DangKyThiLaiID].ToString());
			pKQHT_DangKyThiLaiInfo.IDSV_SinhVien = int.Parse(dr[pKQHT_DangKyThiLaiInfo.strIDSV_SinhVien].ToString());
			pKQHT_DangKyThiLaiInfo.IDDM_MonHoc = int.Parse(dr[pKQHT_DangKyThiLaiInfo.strIDDM_MonHoc].ToString());
			pKQHT_DangKyThiLaiInfo.IDDM_NamHoc = int.Parse(dr[pKQHT_DangKyThiLaiInfo.strIDDM_NamHoc].ToString());
			pKQHT_DangKyThiLaiInfo.HocKy = int.Parse(dr[pKQHT_DangKyThiLaiInfo.strHocKy].ToString());
			pKQHT_DangKyThiLaiInfo.IDKQHT_ToChucThi = int.Parse(dr[pKQHT_DangKyThiLaiInfo.strIDKQHT_ToChucThi].ToString());
			pKQHT_DangKyThiLaiInfo.GhiChu = dr[pKQHT_DangKyThiLaiInfo.strGhiChu].ToString();
			pKQHT_DangKyThiLaiInfo.TienLePhi = double.Parse(dr[pKQHT_DangKyThiLaiInfo.strTienLePhi].ToString());
			pKQHT_DangKyThiLaiInfo.IDHT_User = int.Parse(dr[pKQHT_DangKyThiLaiInfo.strIDHT_User].ToString());
			pKQHT_DangKyThiLaiInfo.NgayDangKy = DateTime.Parse(dr[pKQHT_DangKyThiLaiInfo.strNgayDangKy].ToString());
        }
    }
}
