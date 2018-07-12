using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_MonThiTotNghiepInfo
    {

        private int mKQHT_MonThiTotNghiepID;
        private string mMaMon;
        private string mTenMon;
        private bool mTinhDiem;
        private double mDiemDieuKien;
        private double mSoHocTrinh;

        public string strKQHT_MonThiTotNghiepID = "KQHT_MonThiTotNghiepID";
        public string strMaMon = "MaMon";
        public string strTenMon = "TenMon";
        public string strTinhDiem = "TinhDiem";
        public string strDiemDieuKien = "DiemDieuKien";
        public string strSoHocTrinh = "SoHocTrinh";

        public KQHT_MonThiTotNghiepInfo()
        { }

        public int KQHT_MonThiTotNghiepID{
        	set{ mKQHT_MonThiTotNghiepID = value;}
        	get{ return mKQHT_MonThiTotNghiepID;}
        }
        public string MaMon{
        	set{ mMaMon = value;}
        	get{ return mMaMon;}
        }
        public string TenMon{
        	set{ mTenMon = value;}
        	get{ return mTenMon;}
        }
        public bool TinhDiem{
        	set{ mTinhDiem = value;}
        	get{ return mTinhDiem;}
        }
        public double DiemDieuKien{
        	set{ mDiemDieuKien = value;}
        	get{ return mDiemDieuKien;}
        }
        public double SoHocTrinh{
        	set{ mSoHocTrinh = value;}
        	get{ return mSoHocTrinh;}
        }
    }
}
