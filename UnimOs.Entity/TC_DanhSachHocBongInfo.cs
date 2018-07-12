using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class TC_DanhSachHocBongInfo
    {

        private int mTC_DanhSachHocBongID;
        private int mIDSV_SinhVien;
        private int mIDDM_NamHoc;
        private int mHocKy;
        private int mIDTC_PhanBoQuyHocBong;
        private double mSoTienThang;
        private double mSoTienKy;

        public string strTC_DanhSachHocBongID = "TC_DanhSachHocBongID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strHocKy = "HocKy";
        public string strIDTC_PhanBoQuyHocBong = "IDTC_PhanBoQuyHocBong";
        public string strSoTienThang = "SoTienThang";
        public string strSoTienKy = "SoTienKy";

        public TC_DanhSachHocBongInfo()
        { }

        public int TC_DanhSachHocBongID{
        	set{ mTC_DanhSachHocBongID = value;}
        	get{ return mTC_DanhSachHocBongID;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
        public int IDDM_NamHoc{
        	set{ mIDDM_NamHoc = value;}
        	get{ return mIDDM_NamHoc;}
        }
        public int HocKy{
        	set{ mHocKy = value;}
        	get{ return mHocKy;}
        }
        public int IDTC_PhanBoQuyHocBong{
        	set{ mIDTC_PhanBoQuyHocBong = value;}
        	get{ return mIDTC_PhanBoQuyHocBong;}
        }
        public double SoTienThang{
        	set{ mSoTienThang = value;}
        	get{ return mSoTienThang;}
        }
        public double SoTienKy{
        	set{ mSoTienKy = value;}
        	get{ return mSoTienKy;}
        }
    }
}
