using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class SV_DoiTuongMienGiamInfo
    {

        private int mSV_DoiTuongMienGiamID;
        private int mIDSV_SinhVien;
        private int mIDDM_DoiTuongMienGiam;
        private int mHocKy;
        private int mIDDM_NamHoc;
        private string mGhiChu;

        public string strSV_DoiTuongMienGiamID = "SV_DoiTuongMienGiamID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strIDDM_DoiTuongMienGiam = "IDDM_DoiTuongMienGiam";
        public string strHocKy = "HocKy";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strGhiChu = "GhiChu";

        public SV_DoiTuongMienGiamInfo()
        { }

        public int SV_DoiTuongMienGiamID{
        	set{ mSV_DoiTuongMienGiamID = value;}
        	get{ return mSV_DoiTuongMienGiamID;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
        public int IDDM_DoiTuongMienGiam{
        	set{ mIDDM_DoiTuongMienGiam = value;}
        	get{ return mIDDM_DoiTuongMienGiam;}
        }
        public int HocKy{
        	set{ mHocKy = value;}
        	get{ return mHocKy;}
        }
        public int IDDM_NamHoc{
        	set{ mIDDM_NamHoc = value;}
        	get{ return mIDDM_NamHoc;}
        }
        public string GhiChu{
        	set{ mGhiChu = value;}
        	get{ return mGhiChu;}
        }
    }
}
