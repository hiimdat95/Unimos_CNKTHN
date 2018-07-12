using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class TC_DanhSachMienGiam_ChiTietInfo
    {

        private int mTC_DanhSachMienGiam_ChiTietID;
        private int mIDTC_DanhSachMienGiam;
        private int mThang;
        private double mSoTien;

        public string strTC_DanhSachMienGiam_ChiTietID = "TC_DanhSachMienGiam_ChiTietID";
        public string strIDTC_DanhSachMienGiam = "IDTC_DanhSachMienGiam";
        public string strThang = "Thang";
        public string strSoTien = "SoTien";

        public TC_DanhSachMienGiam_ChiTietInfo()
        { }

        public int TC_DanhSachMienGiam_ChiTietID{
        	set{ mTC_DanhSachMienGiam_ChiTietID = value;}
        	get{ return mTC_DanhSachMienGiam_ChiTietID;}
        }
        public int IDTC_DanhSachMienGiam{
        	set{ mIDTC_DanhSachMienGiam = value;}
        	get{ return mIDTC_DanhSachMienGiam;}
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
