using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBTC_DanhSachMienGiam : cBBase
    {
        private cDTC_DanhSachMienGiam oDTC_DanhSachMienGiam;
        private TC_DanhSachMienGiamInfo oTC_DanhSachMienGiamInfo;

        public cBTC_DanhSachMienGiam()        
        {
            oDTC_DanhSachMienGiam = new cDTC_DanhSachMienGiam();
        }
        public DataTable GetInSinhVien(int IDDM_Khoa, int IDDM_He, int IDDM_TrinhDo, int IDDM_KhoaHoc, int IDDM_Nganh, int IDDM_Lop, int IDDM_NamHoc, int HocKy, int IDTC_LoaiThuChi)
        {
            return oDTC_DanhSachMienGiam.GetInSinhVien(IDDM_Khoa, IDDM_He, IDDM_TrinhDo, IDDM_KhoaHoc, IDDM_Nganh, IDDM_Lop, IDDM_NamHoc, HocKy, IDTC_LoaiThuChi);
        }
        public DataTable GetNotInSinhVien(int IDDM_Khoa, int IDDM_He, int IDDM_TrinhDo, int IDDM_KhoaHoc, int IDDM_Nganh, int IDDM_Lop, int IDDM_NamHoc, int HocKy, string NamHoc, int IDTC_LoaiThuChi)
        {
            return oDTC_DanhSachMienGiam.GetNotInSinhVien(IDDM_Khoa, IDDM_He, IDDM_TrinhDo, IDDM_KhoaHoc, IDDM_Nganh, IDDM_Lop, IDDM_NamHoc, HocKy, NamHoc, IDTC_LoaiThuChi);
        }
        public DataTable Get(TC_DanhSachMienGiamInfo pTC_DanhSachMienGiamInfo)        
        {
            return oDTC_DanhSachMienGiam.Get(pTC_DanhSachMienGiamInfo);
        }

        public int Add(TC_DanhSachMienGiamInfo pTC_DanhSachMienGiamInfo)
        {
			int ID = 0;
            ID = oDTC_DanhSachMienGiam.Add(pTC_DanhSachMienGiamInfo);
            mErrorMessage = oDTC_DanhSachMienGiam.ErrorMessages;
            mErrorNumber = oDTC_DanhSachMienGiam.ErrorNumber;
            return ID;
        }

        public void Update(TC_DanhSachMienGiamInfo pTC_DanhSachMienGiamInfo)
        {
            oDTC_DanhSachMienGiam.Update(pTC_DanhSachMienGiamInfo);
            mErrorMessage = oDTC_DanhSachMienGiam.ErrorMessages;
            mErrorNumber = oDTC_DanhSachMienGiam.ErrorNumber;
        }
        
        public void Delete(TC_DanhSachMienGiamInfo pTC_DanhSachMienGiamInfo)
        {
            oDTC_DanhSachMienGiam.Delete(pTC_DanhSachMienGiamInfo);
            mErrorMessage = oDTC_DanhSachMienGiam.ErrorMessages;
            mErrorNumber = oDTC_DanhSachMienGiam.ErrorNumber;
        }

        public List<TC_DanhSachMienGiamInfo> GetList(TC_DanhSachMienGiamInfo pTC_DanhSachMienGiamInfo)
        {
            List<TC_DanhSachMienGiamInfo> oTC_DanhSachMienGiamInfoList = new List<TC_DanhSachMienGiamInfo>();
            DataTable dtb = Get(pTC_DanhSachMienGiamInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oTC_DanhSachMienGiamInfo = new TC_DanhSachMienGiamInfo();

                    oTC_DanhSachMienGiamInfo.TC_DanhSachMienGiamID = int.Parse(dtb.Rows[i]["TC_DanhSachMienGiamID"].ToString());
                    oTC_DanhSachMienGiamInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oTC_DanhSachMienGiamInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oTC_DanhSachMienGiamInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    oTC_DanhSachMienGiamInfo.IDTC_LoaiThuChi = int.Parse(dtb.Rows[i]["IDTC_LoaiThuChi"].ToString());
                    oTC_DanhSachMienGiamInfo.SoTienMienGiam = double.Parse(dtb.Rows[i]["SoTienMienGiam"].ToString());
                    oTC_DanhSachMienGiamInfo.GhiChu = dtb.Rows[i]["GhiChu"].ToString();
                    
                    oTC_DanhSachMienGiamInfoList.Add(oTC_DanhSachMienGiamInfo);
                }
            }
            return oTC_DanhSachMienGiamInfoList;
        }
        
        public void ToDataRow(TC_DanhSachMienGiamInfo pTC_DanhSachMienGiamInfo, ref DataRow dr)
        {

			dr[pTC_DanhSachMienGiamInfo.strTC_DanhSachMienGiamID] = pTC_DanhSachMienGiamInfo.TC_DanhSachMienGiamID;
			dr[pTC_DanhSachMienGiamInfo.strIDSV_SinhVien] = pTC_DanhSachMienGiamInfo.IDSV_SinhVien;
			dr[pTC_DanhSachMienGiamInfo.strIDDM_NamHoc] = pTC_DanhSachMienGiamInfo.IDDM_NamHoc;
			dr[pTC_DanhSachMienGiamInfo.strHocKy] = pTC_DanhSachMienGiamInfo.HocKy;
			dr[pTC_DanhSachMienGiamInfo.strIDTC_LoaiThuChi] = pTC_DanhSachMienGiamInfo.IDTC_LoaiThuChi;
			dr[pTC_DanhSachMienGiamInfo.strSoTienMienGiam] = pTC_DanhSachMienGiamInfo.SoTienMienGiam;
			dr[pTC_DanhSachMienGiamInfo.strGhiChu] = pTC_DanhSachMienGiamInfo.GhiChu;
        }
        
        public void ToInfo(ref TC_DanhSachMienGiamInfo pTC_DanhSachMienGiamInfo, DataRow dr)
        {

			pTC_DanhSachMienGiamInfo.TC_DanhSachMienGiamID = int.Parse(dr[pTC_DanhSachMienGiamInfo.strTC_DanhSachMienGiamID].ToString());
			pTC_DanhSachMienGiamInfo.IDSV_SinhVien = int.Parse(dr[pTC_DanhSachMienGiamInfo.strIDSV_SinhVien].ToString());
			pTC_DanhSachMienGiamInfo.IDDM_NamHoc = int.Parse(dr[pTC_DanhSachMienGiamInfo.strIDDM_NamHoc].ToString());
			pTC_DanhSachMienGiamInfo.HocKy = int.Parse(dr[pTC_DanhSachMienGiamInfo.strHocKy].ToString());
			pTC_DanhSachMienGiamInfo.IDTC_LoaiThuChi = int.Parse(dr[pTC_DanhSachMienGiamInfo.strIDTC_LoaiThuChi].ToString());
			pTC_DanhSachMienGiamInfo.SoTienMienGiam = double.Parse(dr[pTC_DanhSachMienGiamInfo.strSoTienMienGiam].ToString());
			pTC_DanhSachMienGiamInfo.GhiChu = dr[pTC_DanhSachMienGiamInfo.strGhiChu].ToString();
        }
    }
}
