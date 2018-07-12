using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class TC_DinhMucThuSinhVien_ChiTietInfo
    {

        private int mTC_DinhMucThuSinhVien_ChiTietID;
        private int mIDTC_DinhMucThuSinhVien;
        private int mThang;
        private double mSoTien;

        public string strTC_DinhMucThuSinhVien_ChiTietID = "TC_DinhMucThuSinhVien_ChiTietID";
        public string strIDTC_DinhMucThuSinhVien = "IDTC_DinhMucThuSinhVien";
        public string strThang = "Thang";
        public string strSoTien = "SoTien";

        public TC_DinhMucThuSinhVien_ChiTietInfo()
        { }

        public int TC_DinhMucThuSinhVien_ChiTietID{
        	set{ mTC_DinhMucThuSinhVien_ChiTietID = value;}
        	get{ return mTC_DinhMucThuSinhVien_ChiTietID;}
        }
        public int IDTC_DinhMucThuSinhVien{
        	set{ mIDTC_DinhMucThuSinhVien = value;}
        	get{ return mIDTC_DinhMucThuSinhVien;}
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
