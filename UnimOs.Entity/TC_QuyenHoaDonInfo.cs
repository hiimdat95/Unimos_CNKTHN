using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class TC_QuyenHoaDonInfo
    {

        private int mTC_QuyenHoaDonID;
        private int mIDDM_DiaDiem;
        private string mTenQuyenHoaDon;
        private string mTuSo;
        private string mSoHienTai;
        private int mHocKy;
        private int mIDDM_NamHoc;

        public string strTC_QuyenHoaDonID = "TC_QuyenHoaDonID";
        public string strIDDM_DiaDiem = "IDDM_DiaDiem";
        public string strTenQuyenHoaDon = "TenQuyenHoaDon";
        public string strTuSo = "TuSo";
        public string strSoHienTai = "SoHienTai";
        public string strHocKy = "HocKy";
        public string strIDDM_NamHoc = "IDDM_NamHoc";

        public TC_QuyenHoaDonInfo()
        { }

        public int TC_QuyenHoaDonID{
        	set{ mTC_QuyenHoaDonID = value;}
        	get{ return mTC_QuyenHoaDonID;}
        }
        public int IDDM_DiaDiem
        {
            set { mIDDM_DiaDiem = value; }
            get { return mIDDM_DiaDiem; }
        }
        public string TenQuyenHoaDon{
        	set{ mTenQuyenHoaDon = value;}
        	get{ return mTenQuyenHoaDon;}
        }
        public string TuSo{
        	set{ mTuSo = value;}
        	get{ return mTuSo;}
        }
        public string SoHienTai{
        	set{ mSoHienTai = value;}
        	get{ return mSoHienTai;}
        }
        public int HocKy{
        	set{ mHocKy = value;}
        	get{ return mHocKy;}
        }
        public int IDDM_NamHoc{
        	set{ mIDDM_NamHoc = value;}
        	get{ return mIDDM_NamHoc;}
        }
    }
}
