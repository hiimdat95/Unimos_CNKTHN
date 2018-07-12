using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_DanTocInfo
    {

        private int mDM_DanTocID;
        private string mMaDanToc;
        private string mTenDanToc;

        public string strDM_DanTocID = "DM_DanTocID";
        public string strMaDanToc = "MaDanToc";
        public string strTenDanToc = "TenDanToc";

        public DM_DanTocInfo()
        { }

        public int DM_DanTocID{
        	set{ mDM_DanTocID = value;}
        	get{ return mDM_DanTocID;}
        }
        public string MaDanToc{
        	set{ mMaDanToc = value;}
        	get{ return mMaDanToc;}
        }
        public string TenDanToc{
        	set{ mTenDanToc = value;}
        	get{ return mTenDanToc;}
        }
    }
}
