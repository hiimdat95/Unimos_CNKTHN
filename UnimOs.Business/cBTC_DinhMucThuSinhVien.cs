using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBTC_DinhMucThuSinhVien : cBBase
    {
        private cDTC_DinhMucThuSinhVien oDTC_DinhMucThuSinhVien;
        private TC_DinhMucThuSinhVienInfo oTC_DinhMucThuSinhVienInfo;

        public cBTC_DinhMucThuSinhVien()        
        {
            oDTC_DinhMucThuSinhVien = new cDTC_DinhMucThuSinhVien();
        }

        public DataTable GetBy_SinhVien(int IDSV_SinhVien,int IDDM_NamHoc, int HocKy,int PhieuThu,int Type, int IDSV_SinhVienNhapTruong)
        {
            return oDTC_DinhMucThuSinhVien.GetBy_SinhVien(IDSV_SinhVien, IDDM_NamHoc, HocKy, PhieuThu, Type, IDSV_SinhVienNhapTruong);
        }

        public DataTable GetBySinhVien(int IDSV_SinhVien, int IDDM_NamHoc, int HocKy, int IDTC_LoaiThuChi)
        {
            return oDTC_DinhMucThuSinhVien.GetBySinhVien(IDSV_SinhVien, IDDM_NamHoc, HocKy, IDTC_LoaiThuChi);
        }

        public DataTable GetChuaNopBy_SinhVien(int IDSV_SinhVien, int IDDM_NamHoc, int HocKy, int IDTC_LoaiThuChi)
        {
            return oDTC_DinhMucThuSinhVien.GetChuaNopBy_SinhVien(IDSV_SinhVien, IDDM_NamHoc, HocKy, IDTC_LoaiThuChi);
        }

        public DataTable GetInSinhVien(DM_LopInfo pDM_LopInfo, int IDDM_NamHoc, int HocKy, int IDTC_LoaiThuChi)
        {
            return oDTC_DinhMucThuSinhVien.GetInSinhVien(pDM_LopInfo, IDDM_NamHoc, HocKy, IDTC_LoaiThuChi);
        }

        public DataTable GetNotInSinhVien(DM_LopInfo pDM_LopInfo, int IDDM_NamHoc, int HocKy, string NamHoc, int IDTC_LoaiThuChi)
        {
            return oDTC_DinhMucThuSinhVien.GetNotInSinhVien(pDM_LopInfo, IDDM_NamHoc, HocKy, NamHoc, IDTC_LoaiThuChi);
        }

        public DataTable GetByKyTruoc(DM_LopInfo pDM_LopInfo, int IDDM_NamHoc, int HocKy, string NamHoc, int IDTC_LoaiThuChi)
        {
            return oDTC_DinhMucThuSinhVien.GetByKyTruoc(pDM_LopInfo, IDDM_NamHoc, HocKy, NamHoc, IDTC_LoaiThuChi);
        }

        public DataTable Get(TC_DinhMucThuSinhVienInfo pTC_DinhMucThuSinhVienInfo)        
        {
            return oDTC_DinhMucThuSinhVien.Get(pTC_DinhMucThuSinhVienInfo);
        }

        public int Add(TC_DinhMucThuSinhVienInfo pTC_DinhMucThuSinhVienInfo)
        {
			int ID = 0;
            ID = oDTC_DinhMucThuSinhVien.Add(pTC_DinhMucThuSinhVienInfo);
            mErrorMessage = oDTC_DinhMucThuSinhVien.ErrorMessages;
            mErrorNumber = oDTC_DinhMucThuSinhVien.ErrorNumber;
            return ID;
        }

        public void Update(TC_DinhMucThuSinhVienInfo pTC_DinhMucThuSinhVienInfo)
        {
            oDTC_DinhMucThuSinhVien.Update(pTC_DinhMucThuSinhVienInfo);
            mErrorMessage = oDTC_DinhMucThuSinhVien.ErrorMessages;
            mErrorNumber = oDTC_DinhMucThuSinhVien.ErrorNumber;
        }
        
        public void Delete(TC_DinhMucThuSinhVienInfo pTC_DinhMucThuSinhVienInfo)
        {
            oDTC_DinhMucThuSinhVien.Delete(pTC_DinhMucThuSinhVienInfo);
            mErrorMessage = oDTC_DinhMucThuSinhVien.ErrorMessages;
            mErrorNumber = oDTC_DinhMucThuSinhVien.ErrorNumber;
        }

        public List<TC_DinhMucThuSinhVienInfo> GetList(TC_DinhMucThuSinhVienInfo pTC_DinhMucThuSinhVienInfo)
        {
            List<TC_DinhMucThuSinhVienInfo> oTC_DinhMucThuSinhVienInfoList = new List<TC_DinhMucThuSinhVienInfo>();
            DataTable dtb = Get(pTC_DinhMucThuSinhVienInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oTC_DinhMucThuSinhVienInfo = new TC_DinhMucThuSinhVienInfo();

                    oTC_DinhMucThuSinhVienInfo.TC_DinhMucThuSinhVienID = int.Parse(dtb.Rows[i]["TC_DinhMucThuSinhVienID"].ToString());
                    oTC_DinhMucThuSinhVienInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oTC_DinhMucThuSinhVienInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oTC_DinhMucThuSinhVienInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    oTC_DinhMucThuSinhVienInfo.IDTC_LoaiThuChi = int.Parse(dtb.Rows[i]["IDTC_LoaiThuChi"].ToString());
                    oTC_DinhMucThuSinhVienInfo.SoTienPhaiNop = double.Parse(dtb.Rows[i]["SoTienPhaiNop"].ToString());
                    oTC_DinhMucThuSinhVienInfo.SoTienGiam = double.Parse(dtb.Rows[i]["SoTienGiam"].ToString());
                    oTC_DinhMucThuSinhVienInfo.GhiChu = dtb.Rows[i]["GhiChu"].ToString();
                    
                    oTC_DinhMucThuSinhVienInfoList.Add(oTC_DinhMucThuSinhVienInfo);
                }
            }
            return oTC_DinhMucThuSinhVienInfoList;
        }
        
        public void ToDataRow(TC_DinhMucThuSinhVienInfo pTC_DinhMucThuSinhVienInfo, ref DataRow dr)
        {
			dr[pTC_DinhMucThuSinhVienInfo.strTC_DinhMucThuSinhVienID] = pTC_DinhMucThuSinhVienInfo.TC_DinhMucThuSinhVienID;
			dr[pTC_DinhMucThuSinhVienInfo.strIDSV_SinhVien] = pTC_DinhMucThuSinhVienInfo.IDSV_SinhVien;
			dr[pTC_DinhMucThuSinhVienInfo.strIDDM_NamHoc] = pTC_DinhMucThuSinhVienInfo.IDDM_NamHoc;
			dr[pTC_DinhMucThuSinhVienInfo.strHocKy] = pTC_DinhMucThuSinhVienInfo.HocKy;
			dr[pTC_DinhMucThuSinhVienInfo.strIDTC_LoaiThuChi] = pTC_DinhMucThuSinhVienInfo.IDTC_LoaiThuChi;
			dr[pTC_DinhMucThuSinhVienInfo.strSoTienPhaiNop] = pTC_DinhMucThuSinhVienInfo.SoTienPhaiNop;
			dr[pTC_DinhMucThuSinhVienInfo.strSoTienGiam] = pTC_DinhMucThuSinhVienInfo.SoTienGiam;
			dr[pTC_DinhMucThuSinhVienInfo.strGhiChu] = pTC_DinhMucThuSinhVienInfo.GhiChu;
        }
        
        public void ToInfo(ref TC_DinhMucThuSinhVienInfo pTC_DinhMucThuSinhVienInfo, DataRow dr)
        {
			pTC_DinhMucThuSinhVienInfo.TC_DinhMucThuSinhVienID = int.Parse(dr[pTC_DinhMucThuSinhVienInfo.strTC_DinhMucThuSinhVienID].ToString());
			pTC_DinhMucThuSinhVienInfo.IDSV_SinhVien = int.Parse(dr[pTC_DinhMucThuSinhVienInfo.strIDSV_SinhVien].ToString());
			pTC_DinhMucThuSinhVienInfo.IDDM_NamHoc = int.Parse(dr[pTC_DinhMucThuSinhVienInfo.strIDDM_NamHoc].ToString());
			pTC_DinhMucThuSinhVienInfo.HocKy = int.Parse(dr[pTC_DinhMucThuSinhVienInfo.strHocKy].ToString());
			pTC_DinhMucThuSinhVienInfo.IDTC_LoaiThuChi = int.Parse(dr[pTC_DinhMucThuSinhVienInfo.strIDTC_LoaiThuChi].ToString());
			pTC_DinhMucThuSinhVienInfo.SoTienPhaiNop = double.Parse(dr[pTC_DinhMucThuSinhVienInfo.strSoTienPhaiNop].ToString());
			pTC_DinhMucThuSinhVienInfo.SoTienGiam = double.Parse(dr[pTC_DinhMucThuSinhVienInfo.strSoTienGiam].ToString());
			pTC_DinhMucThuSinhVienInfo.GhiChu = dr[pTC_DinhMucThuSinhVienInfo.strGhiChu].ToString();
        }
    }
}
