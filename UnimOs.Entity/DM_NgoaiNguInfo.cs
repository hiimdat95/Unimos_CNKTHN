using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_NgoaiNguInfo
    {

        private int mDM_NgoaiNguID;
        private string mTenNgoaiNgu;

        public string strDM_NgoaiNguID = "DM_NgoaiNguID";
        public string strTenNgoaiNgu = "TenNgoaiNgu";

        public DM_NgoaiNguInfo()
        { }

        public int DM_NgoaiNguID{
        	set{ mDM_NgoaiNguID = value;}
        	get{ return mDM_NgoaiNguID;}
        }
        public string TenNgoaiNgu{
        	set{ mTenNgoaiNgu = value;}
        	get{ return mTenNgoaiNgu;}
        }
    }
}
