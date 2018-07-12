using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_BoMonInfo
    {

        private int mDM_BoMonID;
        private int mIDDM_Khoa;
        private string mMaBoMon;
        private string mTenBoMon;

        public string strDM_BoMonID = "DM_BoMonID";
        public string strIDDM_Khoa = "IDDM_Khoa";
        public string strMaBoMon = "MaBoMon";
        public string strTenBoMon = "TenBoMon";

        public DM_BoMonInfo()
        { }

        public int DM_BoMonID{
        	set{ mDM_BoMonID = value;}
        	get{ return mDM_BoMonID;}
        }
        public int IDDM_Khoa{
        	set{ mIDDM_Khoa = value;}
        	get{ return mIDDM_Khoa;}
        }
        public string MaBoMon{
        	set{ mMaBoMon = value;}
        	get{ return mMaBoMon;}
        }
        public string TenBoMon{
        	set{ mTenBoMon = value;}
        	get{ return mTenBoMon;}
        }
    }
}
