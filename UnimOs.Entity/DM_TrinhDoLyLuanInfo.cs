using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_TrinhDoLyLuanInfo
    {

        private int mDM_TrinhDoLyLuanID;
        private string mTenTrinhDoLyLuan;

        public string strDM_TrinhDoLyLuanID = "DM_TrinhDoLyLuanID";
        public string strTenTrinhDoLyLuan = "TenTrinhDoLyLuan";

        public DM_TrinhDoLyLuanInfo()
        { }

        public int DM_TrinhDoLyLuanID{
        	set{ mDM_TrinhDoLyLuanID = value;}
        	get{ return mDM_TrinhDoLyLuanID;}
        }
        public string TenTrinhDoLyLuan{
        	set{ mTenTrinhDoLyLuan = value;}
        	get{ return mTenTrinhDoLyLuan;}
        }
    }
}
