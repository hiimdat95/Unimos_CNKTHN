using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_NganhInfo
    {

        private int mDM_NganhID;
        private int mIDDM_Khoa;
        private string mMaNganh;
        private string mTenNganh;
        private string mTenNganh_E;

        public string strDM_NganhID = "DM_NganhID";
        public string strIDDM_Khoa = "IDDM_Khoa";
        public string strMaNganh = "MaNganh";
        public string strTenNganh = "TenNganh";
        public string strTenNganh_E = "TenNganh_E";

        public DM_NganhInfo()
        { }

        public int DM_NganhID{
        	set{ mDM_NganhID = value;}
        	get{ return mDM_NganhID;}
        }
        public int IDDM_Khoa{
        	set{ mIDDM_Khoa = value;}
        	get{ return mIDDM_Khoa;}
        }
        public string MaNganh{
        	set{ mMaNganh = value;}
        	get{ return mMaNganh;}
        }
        public string TenNganh{
        	set{ mTenNganh = value;}
        	get{ return mTenNganh;}
        }
        public string TenNganh_E{
        	set{ mTenNganh_E = value;}
        	get{ return mTenNganh_E;}
        }
    }
}
