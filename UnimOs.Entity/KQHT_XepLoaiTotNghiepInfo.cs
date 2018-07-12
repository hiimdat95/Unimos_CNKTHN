using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_XepLoaiTotNghiepInfo
    {

        private int mKQHT_XepLoaiTotNghiepID;
        private string mTenXepLoai;
        private double mTuDiem;
        private string mMaXepLoai;
        private bool mHaXepLoaiThiLaiQuaMucPhanTram;

        public string strKQHT_XepLoaiTotNghiepID = "KQHT_XepLoaiTotNghiepID";
        public string strTenXepLoai = "TenXepLoai";
        public string strTuDiem = "TuDiem";
        public string strMaXepLoai = "MaXepLoai";
        public string strHaXepLoaiThiLaiQuaMucPhanTram = "HaXepLoaiThiLaiQuaMucPhanTram";

        public KQHT_XepLoaiTotNghiepInfo()
        { }

        public int KQHT_XepLoaiTotNghiepID{
        	set{ mKQHT_XepLoaiTotNghiepID = value;}
        	get{ return mKQHT_XepLoaiTotNghiepID;}
        }
        public string TenXepLoai{
        	set{ mTenXepLoai = value;}
        	get{ return mTenXepLoai;}
        }
        public double TuDiem{
        	set{ mTuDiem = value;}
        	get{ return mTuDiem;}
        }
        public string MaXepLoai{
        	set{ mMaXepLoai = value;}
        	get{ return mMaXepLoai;}
        }
        public bool HaXepLoaiThiLaiQuaMucPhanTram
        {
            set { mHaXepLoaiThiLaiQuaMucPhanTram = value; }
            get { return mHaXepLoaiThiLaiQuaMucPhanTram; }
        }
    }
}
