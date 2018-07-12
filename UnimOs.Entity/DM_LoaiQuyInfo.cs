using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_LoaiQuyInfo
    {

        private int mDM_LoaiQuyID;
        private string mTenLoaiQuy;
        private string mGhiChu;

        public string strDM_LoaiQuyID = "DM_LoaiQuyID";
        public string strTenLoaiQuy = "TenLoaiQuy";
        public string strGhiChu = "GhiChu";

        public DM_LoaiQuyInfo()
        { }

        public int DM_LoaiQuyID{
        	set{ mDM_LoaiQuyID = value;}
        	get{ return mDM_LoaiQuyID;}
        }
        public string TenLoaiQuy{
        	set{ mTenLoaiQuy = value;}
        	get{ return mTenLoaiQuy;}
        }
        public string GhiChu{
        	set{ mGhiChu = value;}
        	get{ return mGhiChu;}
        }
    }
}
