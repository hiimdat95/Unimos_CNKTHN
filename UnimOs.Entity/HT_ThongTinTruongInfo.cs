using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class HT_ThongTinTruongInfo
    {

        private int mHT_ThongTinTruongID;
        private string mMaThongTin;
        private string mTenThongTin;
        private string mGiaTri;
        private int mSapXep;

        public string strHT_ThongTinTruongID = "HT_ThongTinTruongID";
        public string strMaThongTin = "MaThongTin";
        public string strTenThongTin = "TenThongTin";
        public string strGiaTri = "GiaTri";
        public string strSapXep = "SapXep";

        public HT_ThongTinTruongInfo()
        { }

        public int HT_ThongTinTruongID{
        	set{ mHT_ThongTinTruongID = value;}
        	get{ return mHT_ThongTinTruongID;}
        }
        public string MaThongTin{
        	set{ mMaThongTin = value;}
        	get{ return mMaThongTin;}
        }
        public string TenThongTin{
        	set{ mTenThongTin = value;}
        	get{ return mTenThongTin;}
        }
        public string GiaTri{
        	set{ mGiaTri = value;}
        	get{ return mGiaTri;}
        }
        public int SapXep{
        	set{ mSapXep = value;}
        	get{ return mSapXep;}
        }
    }
}
