using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_HinhThucThiInfo
    {

        private int mDM_HinhThucThiID;
        private string mMaHinhThucThi;
        private string mTenHinhThucThi;
        private bool mXepLichThi;

        public string strDM_HinhThucThiID = "DM_HinhThucThiID";
        public string strMaHinhThucThi = "MaHinhThucThi";
        public string strTenHinhThucThi = "TenHinhThucThi";
        public string strXepLichThi = "XepLichThi";

        public DM_HinhThucThiInfo()
        { }

        public int DM_HinhThucThiID{
        	set{ mDM_HinhThucThiID = value;}
        	get{ return mDM_HinhThucThiID;}
        }
        public string MaHinhThucThi{
        	set{ mMaHinhThucThi = value;}
        	get{ return mMaHinhThucThi;}
        }
        public string TenHinhThucThi{
        	set{ mTenHinhThucThi = value;}
        	get{ return mTenHinhThucThi;}
        }
        public bool XepLichThi{
        	set{ mXepLichThi = value;}
        	get{ return mXepLichThi;}
        }
    }
}
