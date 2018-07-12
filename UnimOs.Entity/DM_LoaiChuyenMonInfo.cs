using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_LoaiChuyenMonInfo
    {

        private int mDM_LoaiChuyenMonID;
        private string mMaLoaiChuyenMon;
        private string mTenLoaiChuyenMon;

        public string strDM_LoaiChuyenMonID = "DM_LoaiChuyenMonID";
        public string strMaLoaiChuyenMon = "MaLoaiChuyenMon";
        public string strTenLoaiChuyenMon = "TenLoaiChuyenMon";

        public DM_LoaiChuyenMonInfo()
        { }

        public int DM_LoaiChuyenMonID{
        	set{ mDM_LoaiChuyenMonID = value;}
        	get{ return mDM_LoaiChuyenMonID;}
        }
        public string MaLoaiChuyenMon{
        	set{ mMaLoaiChuyenMon = value;}
        	get{ return mMaLoaiChuyenMon;}
        }
        public string TenLoaiChuyenMon{
        	set{ mTenLoaiChuyenMon = value;}
        	get{ return mTenLoaiChuyenMon;}
        }
    }
}
