using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class NS_DonViInfo
    {

        private int mNS_DonViID;
        private string mMaDonVi;
        private string mTenDonVi;
        private int mIDDM_Khoa;
        private int mIDDM_BoMon;
        private int mParentID;
        private int mLevel;

        public string strNS_DonViID = "NS_DonViID";
        public string strMaDonVi = "MaDonVi";
        public string strTenDonVi = "TenDonVi";
        public string strIDDM_Khoa = "IDDM_Khoa";
        public string strIDDM_BoMon = "IDDM_BoMon";
        public string strParentID = "ParentID";
        public string strLevel = "Level";

        public NS_DonViInfo()
        { }

        public int NS_DonViID{
        	set{ mNS_DonViID = value;}
        	get{ return mNS_DonViID;}
        }
        public string MaDonVi{
        	set{ mMaDonVi = value;}
        	get{ return mMaDonVi;}
        }
        public string TenDonVi{
        	set{ mTenDonVi = value;}
        	get{ return mTenDonVi;}
        }
        public int IDDM_Khoa{
        	set{ mIDDM_Khoa = value;}
        	get{ return mIDDM_Khoa;}
        }
        public int IDDM_BoMon{
        	set{ mIDDM_BoMon = value;}
        	get{ return mIDDM_BoMon;}
        }
        public int ParentID{
        	set{ mParentID = value;}
        	get{ return mParentID;}
        }
        public int Level{
        	set{ mLevel = value;}
        	get{ return mLevel;}
        }
    }
}
