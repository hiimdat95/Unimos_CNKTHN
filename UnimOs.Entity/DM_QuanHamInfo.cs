using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_QuanHamInfo
    {

        private int mDM_QuanHamID;
        private string mTenQuanHam;

        public string strDM_QuanHamID = "DM_QuanHamID";
        public string strTenQuanHam = "TenQuanHam";

        public DM_QuanHamInfo()
        { }

        public int DM_QuanHamID{
        	set{ mDM_QuanHamID = value;}
        	get{ return mDM_QuanHamID;}
        }
        public string TenQuanHam{
        	set{ mTenQuanHam = value;}
        	get{ return mTenQuanHam;}
        }
    }
}
