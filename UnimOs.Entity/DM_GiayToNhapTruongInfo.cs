using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_GiayToNhapTruongInfo
    {

        private int mDM_GiayToNhapTruongID;
        private string mTenGiayTo;

        public string strDM_GiayToNhapTruongID = "DM_GiayToNhapTruongID";
        public string strTenGiayTo = "TenGiayTo";

        public DM_GiayToNhapTruongInfo()
        { }

        public int DM_GiayToNhapTruongID{
        	set{ mDM_GiayToNhapTruongID = value;}
        	get{ return mDM_GiayToNhapTruongID;}
        }
        public string TenGiayTo{
        	set{ mTenGiayTo = value;}
        	get{ return mTenGiayTo;}
        }
    }
}
