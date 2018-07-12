using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class NS_LuongCoBanInfo
    {

        private int mNS_LuongCoBanID;
        private double mLuongCoBan;
        private DateTime mTuNgay;
        private DateTime mDenNgay;

        public string strNS_LuongCoBanID = "NS_LuongCoBanID";
        public string strLuongCoBan = "LuongCoBan";
        public string strTuNgay = "TuNgay";
        public string strDenNgay = "DenNgay";

        public NS_LuongCoBanInfo()
        { }

        public int NS_LuongCoBanID{
        	set{ mNS_LuongCoBanID = value;}
        	get{ return mNS_LuongCoBanID;}
        }
        public double LuongCoBan{
        	set{ mLuongCoBan = value;}
        	get{ return mLuongCoBan;}
        }
        public DateTime TuNgay{
        	set{ mTuNgay = value;}
        	get{ return mTuNgay;}
        }
        public DateTime DenNgay{
        	set{ mDenNgay = value;}
        	get{ return mDenNgay;}
        }
    }
}
