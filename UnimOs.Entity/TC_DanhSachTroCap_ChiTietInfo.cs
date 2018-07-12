using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class TC_DanhSachTroCap_ChiTietInfo
    {

        private int mTC_DanhSachTroCap_ChiTietID;
        private int mIDTC_DanhSachTroCap;
        private int mThang;
        private double mSoTien;

        public string strTC_DanhSachTroCap_ChiTietID = "TC_DanhSachTroCap_ChiTietID";
        public string strIDTC_DanhSachTroCap = "IDTC_DanhSachTroCap";
        public string strThang = "Thang";
        public string strSoTien = "SoTien";

        public TC_DanhSachTroCap_ChiTietInfo()
        { }

        public int TC_DanhSachTroCap_ChiTietID{
        	set{ mTC_DanhSachTroCap_ChiTietID = value;}
        	get{ return mTC_DanhSachTroCap_ChiTietID;}
        }
        public int IDTC_DanhSachTroCap{
        	set{ mIDTC_DanhSachTroCap = value;}
        	get{ return mIDTC_DanhSachTroCap;}
        }
        public int Thang{
        	set{ mThang = value;}
        	get{ return mThang;}
        }
        public double SoTien{
        	set{ mSoTien = value;}
        	get{ return mSoTien;}
        }
    }
}
