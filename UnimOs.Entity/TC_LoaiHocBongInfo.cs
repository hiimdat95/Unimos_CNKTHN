using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class TC_LoaiHocBongInfo
    {

        private int mTC_LoaiHocBongID;
        private string mTenLoaiHocBong;
        private string mKyHieu;
        private double mSoTien;
        private int mIDDM_TrinhDo;

        public string strTC_LoaiHocBongID = "TC_LoaiHocBongID";
        public string strTenLoaiHocBong = "TenLoaiHocBong";
        public string strKyHieu = "KyHieu";
        public string strSoTien = "SoTien";
        public string strIDDM_TrinhDo = "IDDM_TrinhDo";

        public TC_LoaiHocBongInfo()
        { }

        public int TC_LoaiHocBongID{
        	set{ mTC_LoaiHocBongID = value;}
        	get{ return mTC_LoaiHocBongID;}
        }
        public string TenLoaiHocBong{
        	set{ mTenLoaiHocBong = value;}
        	get{ return mTenLoaiHocBong;}
        }
        public string KyHieu{
        	set{ mKyHieu = value;}
        	get{ return mKyHieu;}
        }
        public double SoTien{
        	set{ mSoTien = value;}
        	get{ return mSoTien;}
        }
        public int IDDM_TrinhDo{
        	set{ mIDDM_TrinhDo = value;}
        	get{ return mIDDM_TrinhDo;}
        }
    }
}
