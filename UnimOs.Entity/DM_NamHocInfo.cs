using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_NamHocInfo
    {

        private int mDM_NamHocID;
        private string mTenNamHoc;
        private DateTime mTuNgay;
        private DateTime mDenNgay;

        public string strDM_NamHocID = "DM_NamHocID";
        public string strTenNamHoc = "TenNamHoc";
        public string strTuNgay = "TuNgay";
        public string strDenNgay = "DenNgay";

        public DM_NamHocInfo()
        { }

        public int DM_NamHocID{
        	set{ mDM_NamHocID = value;}
        	get{ return mDM_NamHocID;}
        }
        public string TenNamHoc{
        	set{ mTenNamHoc = value;}
        	get{ return mTenNamHoc;}
        }
        public DateTime TuNgay{
        	set{ mTuNgay = value;}
        	get{ return mTuNgay;}
        }
        public DateTime DenNgay{
        	set{ mDenNgay = value;}
        	get{ return mDenNgay;}
        }
    }
}
