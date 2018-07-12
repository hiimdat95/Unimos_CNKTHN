using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_LoaiPhongInfo
    {

        private int mDM_LoaiPhongID;
        private string mMaLoaiPhong;
        private string mTenLoaiPhong;
        private bool mLyThuyet;

        public string strDM_LoaiPhongID = "DM_LoaiPhongID";
        public string strMaLoaiPhong = "MaLoaiPhong";
        public string strTenLoaiPhong = "TenLoaiPhong";
        public string strLyThuyet = "LyThuyet";

        public DM_LoaiPhongInfo()
        { }

        public int DM_LoaiPhongID{
        	set{ mDM_LoaiPhongID = value;}
        	get{ return mDM_LoaiPhongID;}
        }
        public string MaLoaiPhong{
        	set{ mMaLoaiPhong = value;}
        	get{ return mMaLoaiPhong;}
        }
        public string TenLoaiPhong{
        	set{ mTenLoaiPhong = value;}
        	get{ return mTenLoaiPhong;}
        }
        public bool LyThuyet{
        	set{ mLyThuyet = value;}
        	get{ return mLyThuyet;}
        }
    }
}
