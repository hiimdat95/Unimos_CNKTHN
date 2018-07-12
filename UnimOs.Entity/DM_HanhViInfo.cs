using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_HanhViInfo
    {

        private int mDM_HanhViID;
        private string mMaHanhVi;
        private string mTenHanhVi;

        public string strDM_HanhViID = "DM_HanhViID";
        public string strMaHanhVi = "MaHanhVi";
        public string strTenHanhVi = "TenHanhVi";

        public DM_HanhViInfo()
        { }

        public int DM_HanhViID{
        	set{ mDM_HanhViID = value;}
        	get{ return mDM_HanhViID;}
        }
        public string MaHanhVi{
        	set{ mMaHanhVi = value;}
        	get{ return mMaHanhVi;}
        }
        public string TenHanhVi{
        	set{ mTenHanhVi = value;}
        	get{ return mTenHanhVi;}
        }
    }
}
