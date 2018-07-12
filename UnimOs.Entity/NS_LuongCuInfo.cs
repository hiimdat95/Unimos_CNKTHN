using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class NS_LuongCuInfo
    {

        private int mNS_LuongCuID;
        private int mIDNS_GiaoVien;
        private string mCongViecDamNhiem;
        private int mIDNS_NgachCongChuc;
        private int mBacLuong;
        private double mHeSoLuong;
        private double mPhanTramHuong;
        private DateTime mTuNgay;
        private DateTime mDenNgay;

        public string strNS_LuongCuID = "NS_LuongCuID";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strCongViecDamNhiem = "CongViecDamNhiem";
        public string strIDNS_NgachCongChuc = "IDNS_NgachCongChuc";
        public string strBacLuong = "BacLuong";
        public string strHeSoLuong = "HeSoLuong";
        public string strPhanTramHuong = "PhanTramHuong";
        public string strTuNgay = "TuNgay";
        public string strDenNgay = "DenNgay";

        public NS_LuongCuInfo()
        { }

        public int NS_LuongCuID{
        	set{ mNS_LuongCuID = value;}
        	get{ return mNS_LuongCuID;}
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
        }
        public string CongViecDamNhiem{
        	set{ mCongViecDamNhiem = value;}
        	get{ return mCongViecDamNhiem;}
        }
        public int IDNS_NgachCongChuc{
        	set{ mIDNS_NgachCongChuc = value;}
        	get{ return mIDNS_NgachCongChuc;}
        }
        public int BacLuong{
        	set{ mBacLuong = value;}
        	get{ return mBacLuong;}
        }
        public double HeSoLuong{
        	set{ mHeSoLuong = value;}
        	get{ return mHeSoLuong;}
        }
        public double PhanTramHuong{
        	set{ mPhanTramHuong = value;}
        	get{ return mPhanTramHuong;}
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
