using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class XL_LopTachGopInfo
    {

        private int mXL_LopTachGopID;
        private string mTenLopTachGop;
        private int mSoSinhVien;
        private int mIDDM_LopGoc;
        private int mIDDM_NamHoc;
        private int mHocKy;
        private bool mLopTach;
        private int mParentID;

        public string strXL_LopTachGopID = "XL_LopTachGopID";
        public string strTenLopTachGop = "TenLopTachGop";
        public string strSoSinhVien = "SoSinhVien";
        public string strIDDM_LopGoc = "IDDM_LopGoc";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strHocKy = "HocKy";
        public string strLopTach = "LopTach";
        public string strParentID = "ParentID";

        public XL_LopTachGopInfo()
        { }

        public int XL_LopTachGopID{
        	set{ mXL_LopTachGopID = value;}
        	get{ return mXL_LopTachGopID;}
        }
        public string TenLopTachGop{
        	set{ mTenLopTachGop = value;}
        	get{ return mTenLopTachGop;}
        }
        public int SoSinhVien{
        	set{ mSoSinhVien = value;}
        	get{ return mSoSinhVien;}
        }
        public int IDDM_LopGoc{
        	set{ mIDDM_LopGoc = value;}
        	get{ return mIDDM_LopGoc;}
        }
        public int IDDM_NamHoc{
        	set{ mIDDM_NamHoc = value;}
        	get{ return mIDDM_NamHoc;}
        }
        public int HocKy{
        	set{ mHocKy = value;}
        	get{ return mHocKy;}
        }
        public bool LopTach{
        	set{ mLopTach = value;}
        	get{ return mLopTach;}
        }
        public int ParentID{
        	set{ mParentID = value;}
        	get{ return mParentID;}
        }
    }
}
