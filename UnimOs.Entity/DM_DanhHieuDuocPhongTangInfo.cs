using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_DanhHieuDuocPhongTangInfo
    {

        private int mDM_DanhHieuDuocPhongTangID;
        private string mTenDanhHieuDuocPhongTang;

        public string strDM_DanhHieuDuocPhongTangID = "DM_DanhHieuDuocPhongTangID";
        public string strTenDanhHieuDuocPhongTang = "TenDanhHieuDuocPhongTang";

        public DM_DanhHieuDuocPhongTangInfo()
        { }

        public int DM_DanhHieuDuocPhongTangID{
        	set{ mDM_DanhHieuDuocPhongTangID = value;}
        	get{ return mDM_DanhHieuDuocPhongTangID;}
        }
        public string TenDanhHieuDuocPhongTang{
        	set{ mTenDanhHieuDuocPhongTang = value;}
        	get{ return mTenDanhHieuDuocPhongTang;}
        }
    }
}
