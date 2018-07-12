using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class HT_DongBoInfo
    {

        private long mHT_DongBoID;
        private string mTenBang;
        private long mIDThayDoi;
        private string mThaoTac;
        private bool mDaDongBo;
        private DateTime mCreatedTime;

        public string strHT_DongBoID = "HT_DongBoID";
        public string strTenBang = "TenBang";
        public string strIDThayDoi = "IDThayDoi";
        public string strThaoTac = "ThaoTac";
        public string strDaDongBo = "DaDongBo";
        public string strCreatedTime = "CreatedTime";

        public HT_DongBoInfo()
        { }

        public long HT_DongBoID{
        	set{ mHT_DongBoID = value;}
        	get{ return mHT_DongBoID;}
        }
        public string TenBang{
        	set{ mTenBang = value;}
        	get{ return mTenBang;}
        }
        public long IDThayDoi{
        	set{ mIDThayDoi = value;}
        	get{ return mIDThayDoi;}
        }
        public string ThaoTac{
        	set{ mThaoTac = value;}
        	get{ return mThaoTac;}
        }
        public bool DaDongBo{
        	set{ mDaDongBo = value;}
        	get{ return mDaDongBo;}
        }
        public DateTime CreatedTime{
        	set{ mCreatedTime = value;}
        	get{ return mCreatedTime;}
        }
    }
}
