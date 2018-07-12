using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class TC_DanhSachTroCapInfo
    {

        private int mTC_DanhSachTroCapID;
        private int mIDSV_SinhVien;
        private int mIDDM_NamHoc;
        private int mHocKy;
        private double mSoTien;
        private string mGhiChu;

        public string strTC_DanhSachTroCapID = "TC_DanhSachTroCapID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strHocKy = "HocKy";
        public string strSoTien = "SoTien";
        public string strGhiChu = "GhiChu";

        public TC_DanhSachTroCapInfo()
        { }

        public int TC_DanhSachTroCapID{
        	set{ mTC_DanhSachTroCapID = value;}
        	get{ return mTC_DanhSachTroCapID;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
        public int IDDM_NamHoc{
        	set{ mIDDM_NamHoc = value;}
        	get{ return mIDDM_NamHoc;}
        }
        public int HocKy{
        	set{ mHocKy = value;}
        	get{ return mHocKy;}
        }
        public double SoTien{
        	set{ mSoTien = value;}
        	get{ return mSoTien;}
        }
        public string GhiChu{
        	set{ mGhiChu = value;}
        	get{ return mGhiChu;}
        }
    }
}
