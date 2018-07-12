using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_TangInfo
    {

        private int mDM_TangID;
        private string mTenTang;

        public string strDM_TangID = "DM_TangID";
        public string strTenTang = "TenTang";

        public DM_TangInfo()
        { }

        public int DM_TangID{
        	set{ mDM_TangID = value;}
        	get{ return mDM_TangID;}
        }
        public string TenTang{
        	set{ mTenTang = value;}
        	get{ return mTenTang;}
        }
    }
}
