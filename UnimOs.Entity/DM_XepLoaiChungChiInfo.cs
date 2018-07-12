using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_XepLoaiChungChiInfo
    {

        private int mDM_XepLoaiChungChiID;
        private string mTenXepLoaiChungChi;

        public string strDM_XepLoaiChungChiID = "DM_XepLoaiChungChiID";
        public string strTenXepLoaiChungChi = "TenXepLoaiChungChi";

        public DM_XepLoaiChungChiInfo()
        { }

        public int DM_XepLoaiChungChiID{
        	set{ mDM_XepLoaiChungChiID = value;}
        	get{ return mDM_XepLoaiChungChiID;}
        }
        public string TenXepLoaiChungChi{
        	set{ mTenXepLoaiChungChi = value;}
        	get{ return mTenXepLoaiChungChi;}
        }
    }
}
