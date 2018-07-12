using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBTC_BienLaiThuTien : cBBase
    {
        private cDTC_BienLaiThuTien oDTC_BienLaiThuTien;
        private TC_BienLaiThuTienInfo oTC_BienLaiThuTienInfo;

        public cBTC_BienLaiThuTien()        
        {
            oDTC_BienLaiThuTien = new cDTC_BienLaiThuTien();
        }

        public DataTable Get(TC_BienLaiThuTienInfo pTC_BienLaiThuTienInfo)        
        {
            return oDTC_BienLaiThuTien.Get(pTC_BienLaiThuTienInfo);
        }

        public DataTable GetNamHoc(int IDDM_NamHoc, int HocKy)
        {
            return oDTC_BienLaiThuTien.GetNamHoc(IDDM_NamHoc, HocKy);
        }

        public DataTable GetChiTiet(int TC_BienLaiThuTienID)
        {
            return oDTC_BienLaiThuTien.GetChiTiet(TC_BienLaiThuTienID);
        }

        public DataRow GetInfoByID(int TC_BienLaiThuTienID)
        {
            return oDTC_BienLaiThuTien.GetInfoByID(TC_BienLaiThuTienID);
        }

        public DataTable GetBySinhVien(int IDSV_SinhVien, int IDDM_NamHoc, int HocKy)
        {
            return oDTC_BienLaiThuTien.GetBySinhVien(IDSV_SinhVien, IDDM_NamHoc, HocKy);
        }

        public DataTable GetTongHop(DM_LopInfo pDM_LopInfo, int IDDM_NamHoc, int IDTC_LoaiThuChi, int HocKy, int IDTC_QuyenHoaDon, bool TongHopTuDau)
        {
            return oDTC_BienLaiThuTien.GetTongHop(pDM_LopInfo, IDDM_NamHoc, IDTC_LoaiThuChi, HocKy, IDTC_QuyenHoaDon, TongHopTuDau);
        }

        public DataTable GetThuChi(int IDTC_LoaiThuChi, string TuNgay, string DenNgay, int IDDM_NamHoc, int HocKy, string IDDM_Lops)
        {
            return oDTC_BienLaiThuTien.GetThuChi(IDTC_LoaiThuChi, TuNgay, DenNgay, IDDM_NamHoc, HocKy, IDDM_Lops);
        }

        public DataTable TimKiem(string SoPhieu, int PhieuThu, int PhieuHuy, string MaSinhVien, int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            return oDTC_BienLaiThuTien.TimKiem(SoPhieu,PhieuThu,PhieuHuy,MaSinhVien,IDDM_Lop,IDDM_NamHoc,HocKy);
        }

        public DataTable GetSoPhieu(int HocKy, int IDDM_NamHoc, int SV_SinhVienID, int IDDM_DiaDiem)
        {
            return oDTC_BienLaiThuTien.GetSoPhieu(HocKy, IDDM_NamHoc, SV_SinhVienID, IDDM_DiaDiem);
        }

        public int Add(TC_BienLaiThuTienInfo pTC_BienLaiThuTienInfo)
        {
			int ID = 0;
            ID = oDTC_BienLaiThuTien.Add(pTC_BienLaiThuTienInfo);
            mErrorMessage = oDTC_BienLaiThuTien.ErrorMessages;
            mErrorNumber = oDTC_BienLaiThuTien.ErrorNumber;
            return ID;
        }

        public void Update(TC_BienLaiThuTienInfo pTC_BienLaiThuTienInfo)
        {
            oDTC_BienLaiThuTien.Update(pTC_BienLaiThuTienInfo);
            mErrorMessage = oDTC_BienLaiThuTien.ErrorMessages;
            mErrorNumber = oDTC_BienLaiThuTien.ErrorNumber;
        }

        public void UpdatePhieuHuy(int TC_BienLaiThuTienID, DateTime dtNgayHuy, int IDNguoiHuy, int PhieuHuy)
        {
            oDTC_BienLaiThuTien.UpdatePhieuHuy(TC_BienLaiThuTienID, dtNgayHuy, IDNguoiHuy, PhieuHuy);
            mErrorMessage = oDTC_BienLaiThuTien.ErrorMessages;
            mErrorNumber = oDTC_BienLaiThuTien.ErrorNumber;
        }

        public void Delete(TC_BienLaiThuTienInfo pTC_BienLaiThuTienInfo)
        {
            oDTC_BienLaiThuTien.Delete(pTC_BienLaiThuTienInfo);
            mErrorMessage = oDTC_BienLaiThuTien.ErrorMessages;
            mErrorNumber = oDTC_BienLaiThuTien.ErrorNumber;
        }

        public List<TC_BienLaiThuTienInfo> GetList(TC_BienLaiThuTienInfo pTC_BienLaiThuTienInfo)
        {
            List<TC_BienLaiThuTienInfo> oTC_BienLaiThuTienInfoList = new List<TC_BienLaiThuTienInfo>();
            DataTable dtb = Get(pTC_BienLaiThuTienInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oTC_BienLaiThuTienInfo = new TC_BienLaiThuTienInfo();

                    oTC_BienLaiThuTienInfo.TC_BienLaiThuTienID = int.Parse(dtb.Rows[i]["TC_BienLaiThuTienID"].ToString());
                    oTC_BienLaiThuTienInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oTC_BienLaiThuTienInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oTC_BienLaiThuTienInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    oTC_BienLaiThuTienInfo.PhieuThu = bool.Parse(dtb.Rows[i]["PhieuThu"].ToString());
                    oTC_BienLaiThuTienInfo.SoPhieu = dtb.Rows[i]["SoPhieu"].ToString();
                    oTC_BienLaiThuTienInfo.NgayThu = DateTime.Parse(dtb.Rows[i]["NgayThu"].ToString());
                    oTC_BienLaiThuTienInfo.NoiDung = dtb.Rows[i]["NoiDung"].ToString();
                    oTC_BienLaiThuTienInfo.SoTien = double.Parse(dtb.Rows[i]["SoTien"].ToString());
                    oTC_BienLaiThuTienInfo.SoTienBangChu = dtb.Rows[i]["SoTienBangChu"].ToString();
                    oTC_BienLaiThuTienInfo.GhiChu = dtb.Rows[i]["GhiChu"].ToString();
                    oTC_BienLaiThuTienInfo.PhieuHuy = bool.Parse(dtb.Rows[i]["PhieuHuy"].ToString());
                    oTC_BienLaiThuTienInfo.NgayHuy = DateTime.Parse(dtb.Rows[i]["NgayHuy"].ToString());
                    oTC_BienLaiThuTienInfo.IDHT_NguoiHuy = int.Parse(dtb.Rows[i]["IDHT_NguoiHuy"].ToString());
                    oTC_BienLaiThuTienInfo.IDHT_NguoiThu = int.Parse(dtb.Rows[i]["IDHT_NguoiThu"].ToString());
                    oTC_BienLaiThuTienInfo.Printed = bool.Parse(dtb.Rows[i]["Printed"].ToString());
                    
                    oTC_BienLaiThuTienInfoList.Add(oTC_BienLaiThuTienInfo);
                }
            }
            return oTC_BienLaiThuTienInfoList;
        }
        
        public void ToDataRow(TC_BienLaiThuTienInfo pTC_BienLaiThuTienInfo, ref DataRow dr)
        {
			dr[pTC_BienLaiThuTienInfo.strTC_BienLaiThuTienID] = pTC_BienLaiThuTienInfo.TC_BienLaiThuTienID;
			dr[pTC_BienLaiThuTienInfo.strIDSV_SinhVien] = pTC_BienLaiThuTienInfo.IDSV_SinhVien;
			dr[pTC_BienLaiThuTienInfo.strIDDM_NamHoc] = pTC_BienLaiThuTienInfo.IDDM_NamHoc;
			dr[pTC_BienLaiThuTienInfo.strHocKy] = pTC_BienLaiThuTienInfo.HocKy;
			dr[pTC_BienLaiThuTienInfo.strPhieuThu] = pTC_BienLaiThuTienInfo.PhieuThu;
			dr[pTC_BienLaiThuTienInfo.strSoPhieu] = pTC_BienLaiThuTienInfo.SoPhieu;
			dr[pTC_BienLaiThuTienInfo.strNgayThu] = pTC_BienLaiThuTienInfo.NgayThu;
			dr[pTC_BienLaiThuTienInfo.strNoiDung] = pTC_BienLaiThuTienInfo.NoiDung;
			dr[pTC_BienLaiThuTienInfo.strSoTien] = pTC_BienLaiThuTienInfo.SoTien;
			dr[pTC_BienLaiThuTienInfo.strSoTienBangChu] = pTC_BienLaiThuTienInfo.SoTienBangChu;
			dr[pTC_BienLaiThuTienInfo.strGhiChu] = pTC_BienLaiThuTienInfo.GhiChu;
			dr[pTC_BienLaiThuTienInfo.strPhieuHuy] = pTC_BienLaiThuTienInfo.PhieuHuy;
			dr[pTC_BienLaiThuTienInfo.strNgayHuy] = pTC_BienLaiThuTienInfo.NgayHuy;
			dr[pTC_BienLaiThuTienInfo.strIDHT_NguoiHuy] = pTC_BienLaiThuTienInfo.IDHT_NguoiHuy;
			dr[pTC_BienLaiThuTienInfo.strIDHT_NguoiThu] = pTC_BienLaiThuTienInfo.IDHT_NguoiThu;
			dr[pTC_BienLaiThuTienInfo.strPrinted] = pTC_BienLaiThuTienInfo.Printed;
        }
        
        public void ToInfo(ref TC_BienLaiThuTienInfo pTC_BienLaiThuTienInfo, DataRow dr)
        {
			pTC_BienLaiThuTienInfo.TC_BienLaiThuTienID = int.Parse(dr[pTC_BienLaiThuTienInfo.strTC_BienLaiThuTienID].ToString());
			pTC_BienLaiThuTienInfo.IDSV_SinhVien = int.Parse(dr[pTC_BienLaiThuTienInfo.strIDSV_SinhVien].ToString());
			pTC_BienLaiThuTienInfo.IDDM_NamHoc = int.Parse(dr[pTC_BienLaiThuTienInfo.strIDDM_NamHoc].ToString());
			pTC_BienLaiThuTienInfo.HocKy = int.Parse(dr[pTC_BienLaiThuTienInfo.strHocKy].ToString());
			pTC_BienLaiThuTienInfo.PhieuThu = bool.Parse(dr[pTC_BienLaiThuTienInfo.strPhieuThu].ToString());
			pTC_BienLaiThuTienInfo.SoPhieu = dr[pTC_BienLaiThuTienInfo.strSoPhieu].ToString();
			pTC_BienLaiThuTienInfo.NgayThu = DateTime.Parse(dr[pTC_BienLaiThuTienInfo.strNgayThu].ToString());
			pTC_BienLaiThuTienInfo.NoiDung = dr[pTC_BienLaiThuTienInfo.strNoiDung].ToString();
			pTC_BienLaiThuTienInfo.SoTien = double.Parse(dr[pTC_BienLaiThuTienInfo.strSoTien].ToString());
			pTC_BienLaiThuTienInfo.SoTienBangChu = dr[pTC_BienLaiThuTienInfo.strSoTienBangChu].ToString();
			pTC_BienLaiThuTienInfo.GhiChu = dr[pTC_BienLaiThuTienInfo.strGhiChu].ToString();
			pTC_BienLaiThuTienInfo.PhieuHuy = bool.Parse(dr[pTC_BienLaiThuTienInfo.strPhieuHuy].ToString());
			pTC_BienLaiThuTienInfo.NgayHuy = DateTime.Parse(dr[pTC_BienLaiThuTienInfo.strNgayHuy].ToString());
			pTC_BienLaiThuTienInfo.IDHT_NguoiHuy = int.Parse(dr[pTC_BienLaiThuTienInfo.strIDHT_NguoiHuy].ToString());
			pTC_BienLaiThuTienInfo.IDHT_NguoiThu = int.Parse(dr[pTC_BienLaiThuTienInfo.strIDHT_NguoiThu].ToString());
			pTC_BienLaiThuTienInfo.Printed = bool.Parse(dr[pTC_BienLaiThuTienInfo.strPrinted].ToString());
        }

        public DataTable CreateTableMain()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TenLop", typeof(string));
            dt.Columns.Add("HoVaTen", typeof(string));
            dt.Columns.Add("MaSinhVien", typeof(string));
            dt.Columns.Add("SoPhieu", typeof(string));
            dt.Columns.Add("PhieuThu", typeof(string));
            dt.Columns.Add("TongTien", typeof(double));
            dt.Columns.Add("SoTienBangChu", typeof(string));
            dt.Columns.Add("NoiDungPhieu", typeof(string));
            dt.Columns.Add("NgayThu", typeof(DateTime));
            dt.Columns.Add("FullName", typeof(string));
            return dt;
        }
    }
}
