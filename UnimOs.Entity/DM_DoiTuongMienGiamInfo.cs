using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_DoiTuongMienGiamInfo
    {

        private int mDM_DoiTuongMienGiamID;
        private string mMaDoiTuongMienGiam;
        private string mTenDoiTuongMienGiam;
        private string mMienGiam;
        private double mSoTienMienGiam;

        public string strDM_DoiTuongMienGiamID = "DM_DoiTuongMienGiamID";
        public string strMaDoiTuongMienGiam = "MaDoiTuongMienGiam";
        public string strTenDoiTuongMienGiam = "TenDoiTuongMienGiam";
        public string strMienGiam = "MienGiam";
        public string strSoTienMienGiam = "SoTienMienGiam";

        public DM_DoiTuongMienGiamInfo()
        { }

        public int DM_DoiTuongMienGiamID{
        	set{ mDM_DoiTuongMienGiamID = value;}
        	get{ return mDM_DoiTuongMienGiamID;}
        }
        public string MaDoiTuongMienGiam{
        	set{ mMaDoiTuongMienGiam = value;}
        	get{ return mMaDoiTuongMienGiam;}
        }
        public string TenDoiTuongMienGiam{
        	set{ mTenDoiTuongMienGiam = value;}
        	get{ return mTenDoiTuongMienGiam;}
        }
        public string MienGiam{
        	set{ mMienGiam = value;}
        	get{ return mMienGiam;}
        }
        public double SoTienMienGiam{
        	set{ mSoTienMienGiam = value;}
        	get{ return mSoTienMienGiam;}
        }
    }
}
