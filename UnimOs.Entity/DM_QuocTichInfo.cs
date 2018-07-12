using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_QuocTichInfo
    {

        private int mDM_QuocTichID;
        private string mMaNuoc;
        private string mTenNuoc;

        public string strDM_QuocTichID = "DM_QuocTichID";
        public string strMaNuoc = "MaNuoc";
        public string strTenNuoc = "TenNuoc";

        public DM_QuocTichInfo()
        { }

        public int DM_QuocTichID{
        	set{ mDM_QuocTichID = value;}
        	get{ return mDM_QuocTichID;}
        }
        public string MaNuoc{
        	set{ mMaNuoc = value;}
        	get{ return mMaNuoc;}
        }
        public string TenNuoc{
        	set{ mTenNuoc = value;}
        	get{ return mTenNuoc;}
        }
    }
}
