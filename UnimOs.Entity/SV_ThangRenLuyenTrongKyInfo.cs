using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class SV_ThangRenLuyenTrongKyInfo
    {

        private int mSV_ThangRenLuyenTrongKyID;
        private int mIDDM_NamHoc;
        private int mHocKy;
        private int mThang;

        public string strSV_ThangRenLuyenTrongKyID = "SV_ThangRenLuyenTrongKyID";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strHocKy = "HocKy";
        public string strThang = "Thang";

        public SV_ThangRenLuyenTrongKyInfo()
        { }

        public int SV_ThangRenLuyenTrongKyID{
        	set{ mSV_ThangRenLuyenTrongKyID = value;}
        	get{ return mSV_ThangRenLuyenTrongKyID;}
        }
        public int IDDM_NamHoc{
        	set{ mIDDM_NamHoc = value;}
        	get{ return mIDDM_NamHoc;}
        }
        public int HocKy{
        	set{ mHocKy = value;}
        	get{ return mHocKy;}
        }
        public int Thang{
        	set{ mThang = value;}
        	get{ return mThang;}
        }
    }
}
