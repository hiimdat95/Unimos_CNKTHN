using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class HT_UserGroupInfo
    {

        private int mHT_UserGroupID;
        private string mTenNhom;

        public string strHT_UserGroupID = "HT_UserGroupID";
        public string strTenNhom = "TenNhom";

        public HT_UserGroupInfo()
        { }

        public int HT_UserGroupID{
        	set{ mHT_UserGroupID = value;}
        	get{ return mHT_UserGroupID;}
        }
        public string TenNhom{
        	set{ mTenNhom = value;}
        	get{ return mTenNhom;}
        }
    }
}
