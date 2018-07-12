using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_HocHamInfo
    {

        private int mDM_HocHamID;
        private string mTenHocHam;

        public string strDM_HocHamID = "DM_HocHamID";
        public string strTenHocHam = "TenHocHam";

        public DM_HocHamInfo()
        { }

        public int DM_HocHamID{
        	set{ mDM_HocHamID = value;}
        	get{ return mDM_HocHamID;}
        }
        public string TenHocHam{
        	set{ mTenHocHam = value;}
        	get{ return mTenHocHam;}
        }
    }
}
