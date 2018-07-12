using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_HeInfo
    {

        private int mDM_HeID;
        private string mMaHe;
        private string mTenHe;
        private string mTenHe_E;

        public string strDM_HeID = "DM_HeID";
        public string strMaHe = "MaHe";
        public string strTenHe = "TenHe";
        public string strTenHe_E = "TenHe_E";

        public DM_HeInfo()
        { }

        public int DM_HeID{
        	set{ mDM_HeID = value;}
        	get{ return mDM_HeID;}
        }
        public string MaHe{
        	set{ mMaHe = value;}
        	get{ return mMaHe;}
        }
        public string TenHe{
        	set{ mTenHe = value;}
        	get{ return mTenHe;}
        }
        public string TenHe_E{
        	set{ mTenHe_E = value;}
        	get{ return mTenHe_E;}
        }
    }
}
