using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class SV_SinhVienNhapTruongInfo
    {

        private int mSV_SinhVienNhapTruongID;
        private string mHoVaTenTS;
        private string mTenTS;
        private DateTime mNgaySinhTS;
        private string mSoBaoDanhTS;
        private string mNoiSinhTS;
        private string mThuongTruTS;
        private int mGioiTinhTS;
        private string mKhoiThi;
        private string mNganhThi;
        private string mKyHieuTruong;
        private string mDanToc;
        private string mDoiTuongTuyenSinh;
        private string mXLHocLuc;
        private string mXLHanhKiem;
        private string mXLTotNghiep;
        private string mNamTotNghiep;
        private string mKhuVucTuyenSinh;
        private double mDiemMon1;
        private double mDiemMon2;
        private double mDiemMon3;
        private double mDiemMon4;
        private double mDiemThuong;
        private double mTongDiemLamTron;
        private bool mTuyenThang;
        private string mLyDo;
        private DateTime mNgayNhapTruong;
        private int mIDDM_NamHoc;
        private int mIDNguoiTiepNhan;
        private int mIDSV_SinhVien;
        private bool mDaXetDuyet;

        public string strSV_SinhVienNhapTruongID = "SV_SinhVienNhapTruongID";
        public string strHoVaTenTS = "HoVaTenTS";
        public string strTenTS = "TenTS";
        public string strNgaySinhTS = "NgaySinhTS";
        public string strSoBaoDanhTS = "SoBaoDanhTS";
        public string strNoiSinhTS = "NoiSinhTS";
        public string strThuongTruTS = "ThuongTruTS";
        public string strGioiTinhTS = "GioiTinhTS";
        public string strKhoiThi = "KhoiThi";
        public string strNganhThi = "NganhThi";
        public string strKyHieuTruong = "KyHieuTruong";
        public string strDanToc = "DanToc";
        public string strDoiTuongTuyenSinh = "DoiTuongTuyenSinh";
        public string strXLHocLuc = "XLHocLuc";
        public string strXLHanhKiem = "XLHanhKiem";
        public string strXLTotNghiep = "XLTotNghiep";
        public string strNamTotNghiep = "NamTotNghiep";
        public string strKhuVucTuyenSinh = "KhuVucTuyenSinh";
        public string strDiemMon1 = "DiemMon1";
        public string strDiemMon2 = "DiemMon2";
        public string strDiemMon3 = "DiemMon3";
        public string strDiemMon4 = "DiemMon4";
        public string strDiemThuong = "DiemThuong";
        public string strTongDiemLamTron = "TongDiemLamTron";
        public string strTuyenThang = "TuyenThang";
        public string strLyDo = "LyDo";
        public string strNgayNhapTruong = "NgayNhapTruong";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strIDNguoiTiepNhan = "IDNguoiTiepNhan";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strDaXetDuyet = "DaXetDuyet";

        public SV_SinhVienNhapTruongInfo()
        { }

        public bool DaXetDuyet
        {
            set { mDaXetDuyet = value; }
            get { return mDaXetDuyet; }
        }
        public int SV_SinhVienNhapTruongID{
        	set{ mSV_SinhVienNhapTruongID = value;}
        	get{ return mSV_SinhVienNhapTruongID;}
        }
        public string HoVaTenTS{
        	set{ mHoVaTenTS = value;}
        	get{ return mHoVaTenTS;}
        }
        public string TenTS{
        	set{ mTenTS = value;}
        	get{ return mTenTS;}
        }
        public DateTime NgaySinhTS{
        	set{ mNgaySinhTS = value;}
        	get{ return mNgaySinhTS;}
        }
        public string SoBaoDanhTS{
        	set{ mSoBaoDanhTS = value;}
        	get{ return mSoBaoDanhTS;}
        }
        public string NoiSinhTS{
        	set{ mNoiSinhTS = value;}
        	get{ return mNoiSinhTS;}
        }
        public string ThuongTruTS{
        	set{ mThuongTruTS = value;}
        	get{ return mThuongTruTS;}
        }
        public int GioiTinhTS{
        	set{ mGioiTinhTS = value;}
        	get{ return mGioiTinhTS;}
        }
        public string KhoiThi{
        	set{ mKhoiThi = value;}
        	get{ return mKhoiThi;}
        }
        public string NganhThi{
        	set{ mNganhThi = value;}
        	get{ return mNganhThi;}
        }
        public string KyHieuTruong{
        	set{ mKyHieuTruong = value;}
        	get{ return mKyHieuTruong;}
        }
        public string DanToc{
        	set{ mDanToc = value;}
        	get{ return mDanToc;}
        }
        public string DoiTuongTuyenSinh{
        	set{ mDoiTuongTuyenSinh = value;}
        	get{ return mDoiTuongTuyenSinh;}
        }
        public string XLHocLuc{
        	set{ mXLHocLuc = value;}
        	get{ return mXLHocLuc;}
        }
        public string XLHanhKiem{
        	set{ mXLHanhKiem = value;}
        	get{ return mXLHanhKiem;}
        }
        public string XLTotNghiep{
        	set{ mXLTotNghiep = value;}
        	get{ return mXLTotNghiep;}
        }
        public string NamTotNghiep{
        	set{ mNamTotNghiep = value;}
        	get{ return mNamTotNghiep;}
        }
        public string KhuVucTuyenSinh{
        	set{ mKhuVucTuyenSinh = value;}
        	get{ return mKhuVucTuyenSinh;}
        }
        public double DiemMon1{
        	set{ mDiemMon1 = value;}
        	get{ return mDiemMon1;}
        }
        public double DiemMon2{
        	set{ mDiemMon2 = value;}
        	get{ return mDiemMon2;}
        }
        public double DiemMon3{
        	set{ mDiemMon3 = value;}
        	get{ return mDiemMon3;}
        }
        public double DiemMon4{
        	set{ mDiemMon4 = value;}
        	get{ return mDiemMon4;}
        }
        public double DiemThuong{
        	set{ mDiemThuong = value;}
        	get{ return mDiemThuong;}
        }
        public double TongDiemLamTron{
        	set{ mTongDiemLamTron = value;}
        	get{ return mTongDiemLamTron;}
        }
        public bool TuyenThang{
        	set{ mTuyenThang = value;}
        	get{ return mTuyenThang;}
        }
        public string LyDo{
        	set{ mLyDo = value;}
        	get{ return mLyDo;}
        }
        public DateTime NgayNhapTruong{
        	set{ mNgayNhapTruong = value;}
        	get{ return mNgayNhapTruong;}
        }
        public int IDDM_NamHoc{
        	set{ mIDDM_NamHoc = value;}
        	get{ return mIDDM_NamHoc;}
        }
        public int IDNguoiTiepNhan{
        	set{ mIDNguoiTiepNhan = value;}
        	get{ return mIDNguoiTiepNhan;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
    }
}
