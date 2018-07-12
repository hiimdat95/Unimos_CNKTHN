using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_TrinhDoQuanLyHanhChinhNhaNuocInfo
    {

        private int mDM_TrinhDoQuanLyHanhChinhNhaNuocID;
        private string mTenTrinhDoQuanLyHanhChinhNhaNuoc;

        public string strDM_TrinhDoQuanLyHanhChinhNhaNuocID = "DM_TrinhDoQuanLyHanhChinhNhaNuocID";
        public string strTenTrinhDoQuanLyHanhChinhNhaNuoc = "TenTrinhDoQuanLyHanhChinhNhaNuoc";

        public DM_TrinhDoQuanLyHanhChinhNhaNuocInfo()
        { }

        public int DM_TrinhDoQuanLyHanhChinhNhaNuocID{
        	set{ mDM_TrinhDoQuanLyHanhChinhNhaNuocID = value;}
        	get{ return mDM_TrinhDoQuanLyHanhChinhNhaNuocID;}
        }
        public string TenTrinhDoQuanLyHanhChinhNhaNuoc{
        	set{ mTenTrinhDoQuanLyHanhChinhNhaNuoc = value;}
        	get{ return mTenTrinhDoQuanLyHanhChinhNhaNuoc;}
        }
    }
}
