using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_HoiDongMon_ChiTietInfo
    {

        private int mKQHT_HoiDongMon_ChiTietID;
        private int mIDKQHT_HoiDongMon;
        private int mIDNS_GiaoVien;
        private double mTyLe;
        private string mHoTen;
        private string mChucVu;
        private string mDonViCongTac;

        public string strKQHT_HoiDongMon_ChiTietID = "KQHT_HoiDongMon_ChiTietID";
        public string strIDKQHT_HoiDongMon = "IDKQHT_HoiDongMon";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strTyLe = "TyLe";
        public string strHoTen = "HoTen";
        public string strChucVu = "ChucVu";
        public string strDonViCongTac = "DonViCongTac";

        public KQHT_HoiDongMon_ChiTietInfo()
        { }

        public int KQHT_HoiDongMon_ChiTietID{
        	set{ mKQHT_HoiDongMon_ChiTietID = value;}
        	get{ return mKQHT_HoiDongMon_ChiTietID;}
        }
        public int IDKQHT_HoiDongMon{
        	set{ mIDKQHT_HoiDongMon = value;}
        	get{ return mIDKQHT_HoiDongMon;}
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
        }
        public double TyLe{
        	set{ mTyLe = value;}
        	get{ return mTyLe;}
        }
        public string HoTen{
        	set{ mHoTen = value;}
        	get{ return mHoTen;}
        }
        public string ChucVu{
        	set{ mChucVu = value;}
        	get{ return mChucVu;}
        }
        public string DonViCongTac{
        	set{ mDonViCongTac = value;}
        	get{ return mDonViCongTac;}
        }
    }
}
