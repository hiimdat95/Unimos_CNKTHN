using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_HoiDongMonInfo
    {

        private int mKQHT_HoiDongMonID;
        private string mTenHoiDong;
        private int mIDDM_MonHoc;
        private int mIDDM_NamHoc;
        private int mHocKy;

        public string strKQHT_HoiDongMonID = "KQHT_HoiDongMonID";
        public string strTenHoiDong = "TenHoiDong";
        public string strIDDM_MonHoc = "IDDM_MonHoc";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strHocKy = "HocKy";

        public KQHT_HoiDongMonInfo()
        { }

        public int KQHT_HoiDongMonID{
        	set{ mKQHT_HoiDongMonID = value;}
        	get{ return mKQHT_HoiDongMonID;}
        }
        public string TenHoiDong{
        	set{ mTenHoiDong = value;}
        	get{ return mTenHoiDong;}
        }
        public int IDDM_MonHoc{
        	set{ mIDDM_MonHoc = value;}
        	get{ return mIDDM_MonHoc;}
        }
        public int IDDM_NamHoc{
        	set{ mIDDM_NamHoc = value;}
        	get{ return mIDDM_NamHoc;}
        }
        public int HocKy{
        	set{ mHocKy = value;}
        	get{ return mHocKy;}
        }
    }
}
