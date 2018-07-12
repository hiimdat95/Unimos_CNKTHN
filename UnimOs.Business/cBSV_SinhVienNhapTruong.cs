using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBSV_SinhVienNhapTruong : cBBase
    {
        private cDSV_SinhVienNhapTruong oDSV_SinhVienNhapTruong;
        private SV_SinhVienNhapTruongInfo oSV_SinhVienNhapTruongInfo;

        public cBSV_SinhVienNhapTruong()        
        {
            oDSV_SinhVienNhapTruong = new cDSV_SinhVienNhapTruong();
        }

        public DataTable Get(SV_SinhVienNhapTruongInfo pSV_SinhVienNhapTruongInfo)        
        {
            return oDSV_SinhVienNhapTruong.Get(pSV_SinhVienNhapTruongInfo);
        }

        public DataTable GetByNamHoc(int IDDM_NamHoc)
        {
            return oDSV_SinhVienNhapTruong.GetByNamHoc(IDDM_NamHoc);
        }

        public void XuLyGiayBao(ref DataTable dtTrungTuyen, string NamHoc, string TenHe)
        {
            dtTrungTuyen.Columns.Add("NamHoc", typeof(string));
            dtTrungTuyen.Columns.Add("TenHe", typeof(string));
            dtTrungTuyen.Columns.Add("TenLop", typeof(string));
            dtTrungTuyen.Columns.Add("SOGB", typeof(string));

            foreach (DataRow dr in dtTrungTuyen.Rows)
            {
                dr["NamHoc"] = NamHoc;
                dr["TenHe"] = TenHe;
                dr["TenLop"] = "";
                dr["SOGB"] = "";
            }
        }

        public int Add(SV_SinhVienNhapTruongInfo pSV_SinhVienNhapTruongInfo)
        {
			int ID = 0;
            ID = oDSV_SinhVienNhapTruong.Add(pSV_SinhVienNhapTruongInfo);
            mErrorMessage = oDSV_SinhVienNhapTruong.ErrorMessages;
            mErrorNumber = oDSV_SinhVienNhapTruong.ErrorNumber;
            return ID;
        }

        public void Update(SV_SinhVienNhapTruongInfo pSV_SinhVienNhapTruongInfo)
        {
            oDSV_SinhVienNhapTruong.Update(pSV_SinhVienNhapTruongInfo);
            mErrorMessage = oDSV_SinhVienNhapTruong.ErrorMessages;
            mErrorNumber = oDSV_SinhVienNhapTruong.ErrorNumber;
        }

        public void UpdateNhapTruong(SV_SinhVienNhapTruongInfo pSV_SinhVienNhapTruongInfo)
        {
            oDSV_SinhVienNhapTruong.UpdateNhapTruong(pSV_SinhVienNhapTruongInfo);
            mErrorMessage = oDSV_SinhVienNhapTruong.ErrorMessages;
            mErrorNumber = oDSV_SinhVienNhapTruong.ErrorNumber;
        }

        public void UpdateHoSo(SV_SinhVienNhapTruongInfo pSV_SinhVienNhapTruongInfo)
        {
            oDSV_SinhVienNhapTruong.UpdateHoSo(pSV_SinhVienNhapTruongInfo);
            mErrorMessage = oDSV_SinhVienNhapTruong.ErrorMessages;
            mErrorNumber = oDSV_SinhVienNhapTruong.ErrorNumber;
        }
        
        public void Delete(SV_SinhVienNhapTruongInfo pSV_SinhVienNhapTruongInfo)
        {
            oDSV_SinhVienNhapTruong.Delete(pSV_SinhVienNhapTruongInfo);
            mErrorMessage = oDSV_SinhVienNhapTruong.ErrorMessages;
            mErrorNumber = oDSV_SinhVienNhapTruong.ErrorNumber;
        }

        public List<SV_SinhVienNhapTruongInfo> GetList(SV_SinhVienNhapTruongInfo pSV_SinhVienNhapTruongInfo)
        {
            List<SV_SinhVienNhapTruongInfo> oSV_SinhVienNhapTruongInfoList = new List<SV_SinhVienNhapTruongInfo>();
            DataTable dtb = Get(pSV_SinhVienNhapTruongInfo);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    oSV_SinhVienNhapTruongInfo = new SV_SinhVienNhapTruongInfo();

                    oSV_SinhVienNhapTruongInfo.SV_SinhVienNhapTruongID = int.Parse(dtb.Rows[i]["SV_SinhVienNhapTruongID"].ToString());
                    oSV_SinhVienNhapTruongInfo.HoVaTenTS = dtb.Rows[i]["HoVaTenTS"].ToString();
                    oSV_SinhVienNhapTruongInfo.TenTS = dtb.Rows[i]["TenTS"].ToString();
                    oSV_SinhVienNhapTruongInfo.NgaySinhTS = DateTime.Parse(dtb.Rows[i]["NgaySinhTS"].ToString());
                    oSV_SinhVienNhapTruongInfo.SoBaoDanhTS = dtb.Rows[i]["SoBaoDanhTS"].ToString();
                    oSV_SinhVienNhapTruongInfo.NoiSinhTS = dtb.Rows[i]["NoiSinhTS"].ToString();
                    oSV_SinhVienNhapTruongInfo.ThuongTruTS = dtb.Rows[i]["ThuongTruTS"].ToString();
                    oSV_SinhVienNhapTruongInfo.GioiTinhTS = int.Parse(dtb.Rows[i]["GioiTinhTS"].ToString());
                    oSV_SinhVienNhapTruongInfo.KhoiThi = dtb.Rows[i]["KhoiThi"].ToString();
                    oSV_SinhVienNhapTruongInfo.NganhThi = dtb.Rows[i]["NganhThi"].ToString();
                    oSV_SinhVienNhapTruongInfo.KyHieuTruong = dtb.Rows[i]["KyHieuTruong"].ToString();
                    oSV_SinhVienNhapTruongInfo.DanToc = dtb.Rows[i]["DanToc"].ToString();
                    oSV_SinhVienNhapTruongInfo.DoiTuongTuyenSinh = dtb.Rows[i]["DoiTuongTuyenSinh"].ToString();
                    oSV_SinhVienNhapTruongInfo.XLHocLuc = dtb.Rows[i]["XLHocLuc"].ToString();
                    oSV_SinhVienNhapTruongInfo.XLHanhKiem = dtb.Rows[i]["XLHanhKiem"].ToString();
                    oSV_SinhVienNhapTruongInfo.XLTotNghiep = dtb.Rows[i]["XLTotNghiep"].ToString();
                    oSV_SinhVienNhapTruongInfo.NamTotNghiep = dtb.Rows[i]["NamTotNghiep"].ToString();
                    oSV_SinhVienNhapTruongInfo.KhuVucTuyenSinh = dtb.Rows[i]["KhuVucTuyenSinh"].ToString();
                    oSV_SinhVienNhapTruongInfo.DiemMon1 = double.Parse(dtb.Rows[i]["DiemMon1"].ToString());
                    oSV_SinhVienNhapTruongInfo.DiemMon2 = double.Parse(dtb.Rows[i]["DiemMon2"].ToString());
                    oSV_SinhVienNhapTruongInfo.DiemMon3 = double.Parse(dtb.Rows[i]["DiemMon3"].ToString());
                    oSV_SinhVienNhapTruongInfo.DiemMon4 = double.Parse(dtb.Rows[i]["DiemMon4"].ToString());
                    oSV_SinhVienNhapTruongInfo.DiemThuong = double.Parse(dtb.Rows[i]["DiemThuong"].ToString());
                    oSV_SinhVienNhapTruongInfo.TongDiemLamTron = double.Parse(dtb.Rows[i]["TongDiemLamTron"].ToString());
                    oSV_SinhVienNhapTruongInfo.TuyenThang = bool.Parse(dtb.Rows[i]["TuyenThang"].ToString());
                    oSV_SinhVienNhapTruongInfo.LyDo = dtb.Rows[i]["LyDo"].ToString();
                    oSV_SinhVienNhapTruongInfo.NgayNhapTruong = DateTime.Parse(dtb.Rows[i]["NgayNhapTruong"].ToString());
                    oSV_SinhVienNhapTruongInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oSV_SinhVienNhapTruongInfo.IDNguoiTiepNhan = int.Parse(dtb.Rows[i]["IDNguoiTiepNhan"].ToString());
                    oSV_SinhVienNhapTruongInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());

                    oSV_SinhVienNhapTruongInfoList.Add(oSV_SinhVienNhapTruongInfo);
                }
            }
            return oSV_SinhVienNhapTruongInfoList;
        }

        public void ToDataRow(SV_SinhVienNhapTruongInfo pSV_SinhVienNhapTruongInfo, ref DataRow dr)
        {

            dr[pSV_SinhVienNhapTruongInfo.strSV_SinhVienNhapTruongID] = pSV_SinhVienNhapTruongInfo.SV_SinhVienNhapTruongID;
            dr[pSV_SinhVienNhapTruongInfo.strHoVaTenTS] = pSV_SinhVienNhapTruongInfo.HoVaTenTS;
            dr[pSV_SinhVienNhapTruongInfo.strTenTS] = pSV_SinhVienNhapTruongInfo.TenTS;
            dr[pSV_SinhVienNhapTruongInfo.strNgaySinhTS] = pSV_SinhVienNhapTruongInfo.NgaySinhTS;
            dr[pSV_SinhVienNhapTruongInfo.strSoBaoDanhTS] = pSV_SinhVienNhapTruongInfo.SoBaoDanhTS;
            dr[pSV_SinhVienNhapTruongInfo.strNoiSinhTS] = pSV_SinhVienNhapTruongInfo.NoiSinhTS;
            dr[pSV_SinhVienNhapTruongInfo.strThuongTruTS] = pSV_SinhVienNhapTruongInfo.ThuongTruTS;
            dr[pSV_SinhVienNhapTruongInfo.strGioiTinhTS] = pSV_SinhVienNhapTruongInfo.GioiTinhTS;
            dr[pSV_SinhVienNhapTruongInfo.strKhoiThi] = pSV_SinhVienNhapTruongInfo.KhoiThi;
            dr[pSV_SinhVienNhapTruongInfo.strNganhThi] = pSV_SinhVienNhapTruongInfo.NganhThi;
            dr[pSV_SinhVienNhapTruongInfo.strKyHieuTruong] = pSV_SinhVienNhapTruongInfo.KyHieuTruong;
            dr[pSV_SinhVienNhapTruongInfo.strDanToc] = pSV_SinhVienNhapTruongInfo.DanToc;
            dr[pSV_SinhVienNhapTruongInfo.strDoiTuongTuyenSinh] = pSV_SinhVienNhapTruongInfo.DoiTuongTuyenSinh;
            dr[pSV_SinhVienNhapTruongInfo.strXLHocLuc] = pSV_SinhVienNhapTruongInfo.XLHocLuc;
            dr[pSV_SinhVienNhapTruongInfo.strXLHanhKiem] = pSV_SinhVienNhapTruongInfo.XLHanhKiem;
            dr[pSV_SinhVienNhapTruongInfo.strXLTotNghiep] = pSV_SinhVienNhapTruongInfo.XLTotNghiep;
            dr[pSV_SinhVienNhapTruongInfo.strNamTotNghiep] = pSV_SinhVienNhapTruongInfo.NamTotNghiep;
            dr[pSV_SinhVienNhapTruongInfo.strKhuVucTuyenSinh] = pSV_SinhVienNhapTruongInfo.KhuVucTuyenSinh;
            dr[pSV_SinhVienNhapTruongInfo.strDiemMon1] = pSV_SinhVienNhapTruongInfo.DiemMon1;
            dr[pSV_SinhVienNhapTruongInfo.strDiemMon2] = pSV_SinhVienNhapTruongInfo.DiemMon2;
            dr[pSV_SinhVienNhapTruongInfo.strDiemMon3] = pSV_SinhVienNhapTruongInfo.DiemMon3;
            dr[pSV_SinhVienNhapTruongInfo.strDiemMon4] = pSV_SinhVienNhapTruongInfo.DiemMon4;
            dr[pSV_SinhVienNhapTruongInfo.strDiemThuong] = pSV_SinhVienNhapTruongInfo.DiemThuong;
            dr[pSV_SinhVienNhapTruongInfo.strTongDiemLamTron] = pSV_SinhVienNhapTruongInfo.TongDiemLamTron;
            dr[pSV_SinhVienNhapTruongInfo.strTuyenThang] = pSV_SinhVienNhapTruongInfo.TuyenThang;
            dr[pSV_SinhVienNhapTruongInfo.strLyDo] = pSV_SinhVienNhapTruongInfo.LyDo;
            dr[pSV_SinhVienNhapTruongInfo.strNgayNhapTruong] = pSV_SinhVienNhapTruongInfo.NgayNhapTruong;
            dr[pSV_SinhVienNhapTruongInfo.strIDDM_NamHoc] = pSV_SinhVienNhapTruongInfo.IDDM_NamHoc;
            dr[pSV_SinhVienNhapTruongInfo.strIDNguoiTiepNhan] = pSV_SinhVienNhapTruongInfo.IDNguoiTiepNhan;
            dr[pSV_SinhVienNhapTruongInfo.strIDSV_SinhVien] = pSV_SinhVienNhapTruongInfo.IDSV_SinhVien;
        }

        public void ToInfo(ref SV_SinhVienNhapTruongInfo pSV_SinhVienNhapTruongInfo, DataRow dr)
        {

            pSV_SinhVienNhapTruongInfo.SV_SinhVienNhapTruongID = int.Parse(dr[pSV_SinhVienNhapTruongInfo.strSV_SinhVienNhapTruongID].ToString());
            pSV_SinhVienNhapTruongInfo.HoVaTenTS = dr[pSV_SinhVienNhapTruongInfo.strHoVaTenTS].ToString();
            pSV_SinhVienNhapTruongInfo.TenTS = dr[pSV_SinhVienNhapTruongInfo.strTenTS].ToString();
            pSV_SinhVienNhapTruongInfo.NgaySinhTS = DateTime.Parse(dr[pSV_SinhVienNhapTruongInfo.strNgaySinhTS].ToString());
            pSV_SinhVienNhapTruongInfo.SoBaoDanhTS = dr[pSV_SinhVienNhapTruongInfo.strSoBaoDanhTS].ToString();
            pSV_SinhVienNhapTruongInfo.NoiSinhTS = dr[pSV_SinhVienNhapTruongInfo.strNoiSinhTS].ToString();
            pSV_SinhVienNhapTruongInfo.ThuongTruTS = dr[pSV_SinhVienNhapTruongInfo.strThuongTruTS].ToString();
            pSV_SinhVienNhapTruongInfo.GioiTinhTS = int.Parse(dr[pSV_SinhVienNhapTruongInfo.strGioiTinhTS].ToString());
            pSV_SinhVienNhapTruongInfo.KhoiThi = dr[pSV_SinhVienNhapTruongInfo.strKhoiThi].ToString();
            pSV_SinhVienNhapTruongInfo.NganhThi = dr[pSV_SinhVienNhapTruongInfo.strNganhThi].ToString();
            pSV_SinhVienNhapTruongInfo.KyHieuTruong = dr[pSV_SinhVienNhapTruongInfo.strKyHieuTruong].ToString();
            pSV_SinhVienNhapTruongInfo.DanToc = dr[pSV_SinhVienNhapTruongInfo.strDanToc].ToString();
            pSV_SinhVienNhapTruongInfo.DoiTuongTuyenSinh = dr[pSV_SinhVienNhapTruongInfo.strDoiTuongTuyenSinh].ToString();
            pSV_SinhVienNhapTruongInfo.XLHocLuc = dr[pSV_SinhVienNhapTruongInfo.strXLHocLuc].ToString();
            pSV_SinhVienNhapTruongInfo.XLHanhKiem = dr[pSV_SinhVienNhapTruongInfo.strXLHanhKiem].ToString();
            pSV_SinhVienNhapTruongInfo.XLTotNghiep = dr[pSV_SinhVienNhapTruongInfo.strXLTotNghiep].ToString();
            pSV_SinhVienNhapTruongInfo.NamTotNghiep = dr[pSV_SinhVienNhapTruongInfo.strNamTotNghiep].ToString();
            pSV_SinhVienNhapTruongInfo.KhuVucTuyenSinh = dr[pSV_SinhVienNhapTruongInfo.strKhuVucTuyenSinh].ToString();
            pSV_SinhVienNhapTruongInfo.DiemMon1 = double.Parse(dr[pSV_SinhVienNhapTruongInfo.strDiemMon1].ToString());
            pSV_SinhVienNhapTruongInfo.DiemMon2 = double.Parse(dr[pSV_SinhVienNhapTruongInfo.strDiemMon2].ToString());
            pSV_SinhVienNhapTruongInfo.DiemMon3 = double.Parse(dr[pSV_SinhVienNhapTruongInfo.strDiemMon3].ToString());
            pSV_SinhVienNhapTruongInfo.DiemMon4 = double.Parse(dr[pSV_SinhVienNhapTruongInfo.strDiemMon4].ToString());
            pSV_SinhVienNhapTruongInfo.DiemThuong = double.Parse(dr[pSV_SinhVienNhapTruongInfo.strDiemThuong].ToString());
            pSV_SinhVienNhapTruongInfo.TongDiemLamTron = double.Parse(dr[pSV_SinhVienNhapTruongInfo.strTongDiemLamTron].ToString());
            pSV_SinhVienNhapTruongInfo.TuyenThang = bool.Parse(dr[pSV_SinhVienNhapTruongInfo.strTuyenThang].ToString());
            pSV_SinhVienNhapTruongInfo.LyDo = dr[pSV_SinhVienNhapTruongInfo.strLyDo].ToString();
            pSV_SinhVienNhapTruongInfo.NgayNhapTruong = DateTime.Parse(dr[pSV_SinhVienNhapTruongInfo.strNgayNhapTruong].ToString());
            pSV_SinhVienNhapTruongInfo.IDDM_NamHoc = int.Parse(dr[pSV_SinhVienNhapTruongInfo.strIDDM_NamHoc].ToString());
            pSV_SinhVienNhapTruongInfo.IDNguoiTiepNhan = int.Parse(dr[pSV_SinhVienNhapTruongInfo.strIDNguoiTiepNhan].ToString());
            pSV_SinhVienNhapTruongInfo.IDSV_SinhVien = int.Parse(dr[pSV_SinhVienNhapTruongInfo.strIDSV_SinhVien].ToString());
        }

        public void ToInfo(ref SV_SinhVienNhapTruongInfo pSV_SinhVienNhapTruongInfo, DataRow dr, DataTable dt)
        {
            pSV_SinhVienNhapTruongInfo.HoVaTenTS = dr["HoVaTen"].ToString();
            pSV_SinhVienNhapTruongInfo.TenTS = GetTen(dr["HoVaTen"].ToString());
            if (dt.Columns.Contains("NgaySinh") && "" + dr["NgaySinh"] != "")
                pSV_SinhVienNhapTruongInfo.NgaySinhTS = DateTime.Parse(dr["NgaySinh"].ToString());
            else
                pSV_SinhVienNhapTruongInfo.NgaySinhTS = DateTime.Parse("1/1/1900");

            if (dt.Columns.Contains("SoBaoDanh"))
                pSV_SinhVienNhapTruongInfo.SoBaoDanhTS = "" + dr["SoBaoDanh"].ToString();
            if (dt.Columns.Contains("NoiSinh"))
                pSV_SinhVienNhapTruongInfo.NoiSinhTS = "" + dr["NoiSinh"].ToString();
            if (dt.Columns.Contains("ThuongTru"))
                pSV_SinhVienNhapTruongInfo.ThuongTruTS = "" + dr["ThuongTru"].ToString();
            if (dt.Columns.Contains("GioiTinh"))
                pSV_SinhVienNhapTruongInfo.GioiTinhTS = int.Parse("0" + dr["GioiTinh"].ToString());
            if (dt.Columns.Contains(pSV_SinhVienNhapTruongInfo.strKhoiThi))
                pSV_SinhVienNhapTruongInfo.KhoiThi = "" + dr[pSV_SinhVienNhapTruongInfo.strKhoiThi].ToString();
            if (dt.Columns.Contains(pSV_SinhVienNhapTruongInfo.strNganhThi))
                pSV_SinhVienNhapTruongInfo.NganhThi = "" + dr[pSV_SinhVienNhapTruongInfo.strNganhThi].ToString();
            if (dt.Columns.Contains(pSV_SinhVienNhapTruongInfo.strDanToc))
                pSV_SinhVienNhapTruongInfo.DanToc = "" + dr[pSV_SinhVienNhapTruongInfo.strDanToc].ToString();
            if (dt.Columns.Contains(pSV_SinhVienNhapTruongInfo.strDoiTuongTuyenSinh))
                pSV_SinhVienNhapTruongInfo.DoiTuongTuyenSinh = "" + dr[pSV_SinhVienNhapTruongInfo.strDoiTuongTuyenSinh].ToString();
            if (dt.Columns.Contains(pSV_SinhVienNhapTruongInfo.strNamTotNghiep))
                pSV_SinhVienNhapTruongInfo.NamTotNghiep = "" + dr[pSV_SinhVienNhapTruongInfo.strNamTotNghiep].ToString();
            if (dt.Columns.Contains(pSV_SinhVienNhapTruongInfo.strKhuVucTuyenSinh))
                pSV_SinhVienNhapTruongInfo.KhuVucTuyenSinh = "" + dr[pSV_SinhVienNhapTruongInfo.strKhuVucTuyenSinh].ToString();
            if (dt.Columns.Contains(pSV_SinhVienNhapTruongInfo.strDiemMon1) && "" + dr[pSV_SinhVienNhapTruongInfo.strDiemMon1] != "")
                pSV_SinhVienNhapTruongInfo.DiemMon1 = double.Parse(dr[pSV_SinhVienNhapTruongInfo.strDiemMon1].ToString());
            if (dt.Columns.Contains(pSV_SinhVienNhapTruongInfo.strDiemMon2) && "" + dr[pSV_SinhVienNhapTruongInfo.strDiemMon2] != "")
                pSV_SinhVienNhapTruongInfo.DiemMon2 = double.Parse(dr[pSV_SinhVienNhapTruongInfo.strDiemMon2].ToString());
            if (dt.Columns.Contains(pSV_SinhVienNhapTruongInfo.strDiemMon3) && "" + dr[pSV_SinhVienNhapTruongInfo.strDiemMon3] != "")
                pSV_SinhVienNhapTruongInfo.DiemMon3 = double.Parse(dr[pSV_SinhVienNhapTruongInfo.strDiemMon3].ToString());
            if (dt.Columns.Contains(pSV_SinhVienNhapTruongInfo.strDiemMon4) && "" + dr[pSV_SinhVienNhapTruongInfo.strDiemMon4] != "")
                pSV_SinhVienNhapTruongInfo.DiemMon4 = double.Parse(dr[pSV_SinhVienNhapTruongInfo.strDiemMon4].ToString());
            if (dt.Columns.Contains(pSV_SinhVienNhapTruongInfo.strTongDiemLamTron) && "" + dr[pSV_SinhVienNhapTruongInfo.strTongDiemLamTron] != "")
                pSV_SinhVienNhapTruongInfo.TongDiemLamTron = double.Parse(dr[pSV_SinhVienNhapTruongInfo.strTongDiemLamTron].ToString());

            pSV_SinhVienNhapTruongInfo.NgayNhapTruong = DateTime.Parse("1/1/1900");
        }
    }
}
