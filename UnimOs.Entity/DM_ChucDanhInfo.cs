using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_ChucDanhInfo
    {

        private int mDM_ChucDanhID;
        private string mTenChucDanh;

        public string strDM_ChucDanhID = "DM_ChucDanhID";
        public string strTenChucDanh = "TenChucDanh";

        public DM_ChucDanhInfo()
        { }

        public int DM_ChucDanhID{
        	set{ mDM_ChucDanhID = value;}
        	get{ return mDM_ChucDanhID;}
        }
        public string TenChucDanh{
        	set{ mTenChucDanh = value;}
        	get{ return mTenChucDanh;}
        }
    }
}
