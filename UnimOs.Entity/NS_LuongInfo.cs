using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class NS_LuongInfo
    {

        private int mNS_LuongID;
        private int mIDNS_SoQuyetDinh;
        private int mIDNS_GiaoVien;
        private string mCongViecDamNhiem;
        private int mIDNS_NgachCongChuc;
        private int mBacLuong;
        private double mHeSoLuong;
        private double mPhanTramHuong;
        private DateTime mTuNgay;
        private DateTime mDenNgay;

        public string strNS_LuongID = "NS_LuongID";
        public string strIDNS_SoQuyetDinh = "IDNS_SoQuyetDinh";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strCongViecDamNhiem = "CongViecDamNhiem";
        public string strIDNS_NgachCongChuc = "IDNS_NgachCongChuc";
        public string strBacLuong = "BacLuong";
        public string strHeSoLuong = "HeSoLuong";
        public string strPhanTramHuong = "PhanTramHuong";
        public string strTuNgay = "TuNgay";
        public string strDenNgay = "DenNgay";

        public NS_LuongInfo()
        { }

        public int NS_LuongID{
        	set{ mNS_LuongID = value;}
        	get{ return mNS_LuongID;}
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
        }
        public int IDNS_SoQuyetDinh{
            set { mIDNS_SoQuyetDinh = value; }
            get { return mIDNS_SoQuyetDinh; }
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
