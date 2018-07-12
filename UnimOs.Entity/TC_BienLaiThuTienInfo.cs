using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class TC_BienLaiThuTienInfo
    {

        private int mTC_BienLaiThuTienID;
        private int mIDSV_SinhVien;
        private int mIDDM_Lop;
        private int mIDSV_SinhVienNhapTruong;
        private int mIDDM_NamHoc;
        private int mHocKy;
        private bool mPhieuThu;
        private string mSoPhieu;
        private DateTime mNgayThu;
        private string mNoiDung;
        private double mSoTien;
        private string mSoTienBangChu;
        private string mGhiChu;
        private bool mPhieuHuy;
        private DateTime mNgayHuy;
        private int mIDHT_NguoiHuy;
        private int mIDHT_NguoiThu;
        private bool mPrinted;

        public string strTC_BienLaiThuTienID = "TC_BienLaiThuTienID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strIDDM_Lop = "IDDM_Lop";
        public string strIDSV_SinhVienNhapTruong = "IDSV_SinhVienNhapTruong";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strHocKy = "HocKy";
        public string strPhieuThu = "PhieuThu";
        public string strSoPhieu = "SoPhieu";
        public string strNgayThu = "NgayThu";
        public string strNoiDung = "NoiDung";
        public string strSoTien = "SoTien";
        public string strSoTienBangChu = "SoTienBangChu";
        public string strGhiChu = "GhiChu";
        public string strPhieuHuy = "PhieuHuy";
        public string strNgayHuy = "NgayHuy";
        public string strIDHT_NguoiHuy = "IDHT_NguoiHuy";
        public string strIDHT_NguoiThu = "IDHT_NguoiThu";
        public string strPrinted = "Printed";

        public TC_BienLaiThuTienInfo()
        { }

        public int TC_BienLaiThuTienID{
        	set{ mTC_BienLaiThuTienID = value;}
        	get{ return mTC_BienLaiThuTienID;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
        public int IDDM_Lop
        {
            set { mIDDM_Lop = value; }
            get { return mIDDM_Lop; }
        }
        public int IDSV_SinhVienNhapTruong
        {
            set { mIDSV_SinhVienNhapTruong = value; }
            get { return mIDSV_SinhVienNhapTruong; }
        }
        public int IDDM_NamHoc{
        	set{ mIDDM_NamHoc = value;}
        	get{ return mIDDM_NamHoc;}
        }
        public int HocKy{
        	set{ mHocKy = value;}
        	get{ return mHocKy;}
        }
        public bool PhieuThu{
        	set{ mPhieuThu = value;}
        	get{ return mPhieuThu;}
        }
        public string SoPhieu{
        	set{ mSoPhieu = value;}
        	get{ return mSoPhieu;}
        }
        public DateTime NgayThu{
        	set{ mNgayThu = value;}
        	get{ return mNgayThu;}
        }
        public string NoiDung{
        	set{ mNoiDung = value;}
        	get{ return mNoiDung;}
        }
        public double SoTien{
        	set{ mSoTien = value;}
        	get{ return mSoTien;}
        }
        public string SoTienBangChu{
        	set{ mSoTienBangChu = value;}
        	get{ return mSoTienBangChu;}
        }
        public string GhiChu{
        	set{ mGhiChu = value;}
        	get{ return mGhiChu;}
        }
        public bool PhieuHuy{
        	set{ mPhieuHuy = value;}
        	get{ return mPhieuHuy;}
        }
        public DateTime NgayHuy{
        	set{ mNgayHuy = value;}
        	get{ return mNgayHuy;}
        }
        public int IDHT_NguoiHuy{
        	set{ mIDHT_NguoiHuy = value;}
        	get{ return mIDHT_NguoiHuy;}
        }
        public int IDHT_NguoiThu{
        	set{ mIDHT_NguoiThu = value;}
        	get{ return mIDHT_NguoiThu;}
        }
        public bool Printed{
        	set{ mPrinted = value;}
        	get{ return mPrinted;}
        }
    }
}
