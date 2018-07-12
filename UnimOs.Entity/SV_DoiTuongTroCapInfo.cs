using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class SV_DoiTuongTroCapInfo
    {

        private int mSV_DoiTuongTroCapID;
        private int mIDSV_SinhVien;
        private int mIDDM_DoiTuongTroCap;
        private int mHocKy;
        private int mIDDM_NamHoc;
        private string mGhiChu;

        public string strSV_DoiTuongTroCapID = "SV_DoiTuongTroCapID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strIDDM_DoiTuongTroCap = "IDDM_DoiTuongTroCap";
        public string strHocKy = "HocKy";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strGhiChu = "GhiChu";

        public SV_DoiTuongTroCapInfo()
        { }

        public int SV_DoiTuongTroCapID{
        	set{ mSV_DoiTuongTroCapID = value;}
        	get{ return mSV_DoiTuongTroCapID;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
        public int IDDM_DoiTuongTroCap{
        	set{ mIDDM_DoiTuongTroCap = value;}
        	get{ return mIDDM_DoiTuongTroCap;}
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
