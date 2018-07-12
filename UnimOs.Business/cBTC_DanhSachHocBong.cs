using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBTC_DanhSachHocBong : cBBase
    {
        private cDTC_DanhSachHocBong oDTC_DanhSachHocBong;
        private TC_DanhSachHocBongInfo oTC_DanhSachHocBongInfo;

        public cBTC_DanhSachHocBong()        
        {
            oDTC_DanhSachHocBong = new cDTC_DanhSachHocBong();
        }

        public DataTable Get(TC_DanhSachHocBongInfo pTC_DanhSachHocBongInfo)        
        {
            return oDTC_DanhSachHocBong.Get(pTC_DanhSachHocBongInfo);
        }

        public DataTable GetDanhSachSinhVien(int IDDM_Lop, int IDDM_NamHoc, int HocKy, int Thang)
        {
            return oDTC_DanhSachHocBong.GetDanhSachSinhVien(IDDM_Lop, IDDM_NamHoc, HocKy, Thang);
        }

        public DataTable GetInSinhVien(DM_LopInfo pDM_LopInfo, int IDDM_NamHoc, int HocKy)
        {
            return oDTC_DanhSachHocBong.GetInSinhVien(pDM_LopInfo, IDDM_NamHoc, HocKy);
        }

        public DataTable GetNotInSinhVien(DM_LopInfo pDM_LopInfo, int IDDM_NamHoc, int HocKy, string NamHoc, string RenLuyenIDs, double DiemTBC)
        {
            return oDTC_DanhSachHocBong.GetNotInSinhVien(pDM_LopInfo, IDDM_NamHoc, HocKy, NamHoc, RenLuyenIDs, DiemTBC);
        }

        public DataTable GetThangInSinhVien(DM_LopInfo pDM_LopInfo, int IDDM_NamHoc, int HocKy, string NamHoc)
        {
            return oDTC_DanhSachHocBong.GetThangInSinhVien(pDM_LopInfo, IDDM_NamHoc, HocKy, NamHoc);
        }

        public DataTable GetInSinhVienByKyTruoc(DM_LopInfo pDM_LopInfo, int IDDM_NamHoc, int HocKy, string NamHoc, int Thang)
        {
            return oDTC_DanhSachHocBong.GetInSinhVienByKyTruoc(pDM_LopInfo, IDDM_NamHoc, HocKy, NamHoc, Thang);
        }

        public DataTable GetDanhSachLop(DM_LopInfo pDM_LopInfo, int IDDM_NamHoc, int HocKy, int Thang, string NamHoc)
        {
            return oDTC_DanhSachHocBong.GetDanhSachLop(pDM_LopInfo, IDDM_NamHoc, HocKy, Thang, NamHoc);
        }

        public int Add(TC_DanhSachHocBongInfo pTC_DanhSachHocBongInfo)
        {
			int ID = 0;
            ID = oDTC_DanhSachHocBong.Add(pTC_DanhSachHocBongInfo);
            mErrorMessage = oDTC_DanhSachHocBong.ErrorMessages;
            mErrorNumber = oDTC_DanhSachHocBong.ErrorNumber;
            return ID;
        }

        public void Update(TC_DanhSachHocBongInfo pTC_DanhSachHocBongInfo)
        {
            oDTC_DanhSachHocBong.Update(pTC_DanhSachHocBongInfo);
            mErrorMessage = oDTC_DanhSachHocBong.ErrorMessages;
            mErrorNumber = oDTC_DanhSachHocBong.ErrorNumber;
        }
        
        public void Delete(TC_DanhSachHocBongInfo pTC_DanhSachHocBongInfo)
        {
            oDTC_DanhSachHocBong.Delete(pTC_DanhSachHocBongInfo);
            mErrorMessage = oDTC_DanhSachHocBong.ErrorMessages;
            mErrorNumber = oDTC_DanhSachHocBong.ErrorNumber;
        }

        public void DeleteInIDs(string TC_DanhSachHocBongIDs)
        {
            oDTC_DanhSachHocBong.DeleteInIDs(TC_DanhSachHocBongIDs);
            mErrorMessage = oDTC_DanhSachHocBong.ErrorMessages;
            mErrorNumber = oDTC_DanhSachHocBong.ErrorNumber;
        }

        public List<TC_DanhSachHocBongInfo> GetList(TC_DanhSachHocBongInfo pTC_DanhSachHocBongInfo)
        {
            List<TC_DanhSachHocBongInfo> oTC_DanhSachHocBongInfoList = new List<TC_DanhSachHocBongInfo>();
            DataTable dtb = Get(pTC_DanhSachHocBongInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oTC_DanhSachHocBongInfo = new TC_DanhSachHocBongInfo();

                    oTC_DanhSachHocBongInfo.TC_DanhSachHocBongID = int.Parse(dtb.Rows[i]["TC_DanhSachHocBongID"].ToString());
                    oTC_DanhSachHocBongInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oTC_DanhSachHocBongInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oTC_DanhSachHocBongInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    oTC_DanhSachHocBongInfo.IDTC_PhanBoQuyHocBong = int.Parse(dtb.Rows[i]["IDTC_PhanBoQuyHocBong"].ToString());
                    oTC_DanhSachHocBongInfo.SoTienThang = double.Parse(dtb.Rows[i]["SoTienThang"].ToString());
                    oTC_DanhSachHocBongInfo.SoTienKy = double.Parse(dtb.Rows[i]["SoTienKy"].ToString());
                    
                    oTC_DanhSachHocBongInfoList.Add(oTC_DanhSachHocBongInfo);
                }
            }
            return oTC_DanhSachHocBongInfoList;
        }
        
        public void ToDataRow(TC_DanhSachHocBongInfo pTC_DanhSachHocBongInfo, ref DataRow dr)
        {

			dr[pTC_DanhSachHocBongInfo.strTC_DanhSachHocBongID] = pTC_DanhSachHocBongInfo.TC_DanhSachHocBongID;
			dr[pTC_DanhSachHocBongInfo.strIDSV_SinhVien] = pTC_DanhSachHocBongInfo.IDSV_SinhVien;
			dr[pTC_DanhSachHocBongInfo.strIDDM_NamHoc] = pTC_DanhSachHocBongInfo.IDDM_NamHoc;
			dr[pTC_DanhSachHocBongInfo.strHocKy] = pTC_DanhSachHocBongInfo.HocKy;
			dr[pTC_DanhSachHocBongInfo.strIDTC_PhanBoQuyHocBong] = pTC_DanhSachHocBongInfo.IDTC_PhanBoQuyHocBong;
			dr[pTC_DanhSachHocBongInfo.strSoTienThang] = pTC_DanhSachHocBongInfo.SoTienThang;
			dr[pTC_DanhSachHocBongInfo.strSoTienKy] = pTC_DanhSachHocBongInfo.SoTienKy;
        }
        
        public void ToInfo(ref TC_DanhSachHocBongInfo pTC_DanhSachHocBongInfo, DataRow dr)
        {

			pTC_DanhSachHocBongInfo.TC_DanhSachHocBongID = int.Parse(dr[pTC_DanhSachHocBongInfo.strTC_DanhSachHocBongID].ToString());
			pTC_DanhSachHocBongInfo.IDSV_SinhVien = int.Parse(dr[pTC_DanhSachHocBongInfo.strIDSV_SinhVien].ToString());
			pTC_DanhSachHocBongInfo.IDDM_NamHoc = int.Parse(dr[pTC_DanhSachHocBongInfo.strIDDM_NamHoc].ToString());
			pTC_DanhSachHocBongInfo.HocKy = int.Parse(dr[pTC_DanhSachHocBongInfo.strHocKy].ToString());
			pTC_DanhSachHocBongInfo.IDTC_PhanBoQuyHocBong = int.Parse(dr[pTC_DanhSachHocBongInfo.strIDTC_PhanBoQuyHocBong].ToString());
			pTC_DanhSachHocBongInfo.SoTienThang = double.Parse(dr[pTC_DanhSachHocBongInfo.strSoTienThang].ToString());
			pTC_DanhSachHocBongInfo.SoTienKy = double.Parse(dr[pTC_DanhSachHocBongInfo.strSoTienKy].ToString());
        }
    }
}
