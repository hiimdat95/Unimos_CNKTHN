using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_TonGiaoInfo
    {

        private int mDM_TonGiaoID;
        private string mMaTonGiao;
        private string mTenTonGiao;

        public string strDM_TonGiaoID = "DM_TonGiaoID";
        public string strMaTonGiao = "MaTonGiao";
        public string strTenTonGiao = "TenTonGiao";

        public DM_TonGiaoInfo()
        { }

        public int DM_TonGiaoID{
        	set{ mDM_TonGiaoID = value;}
        	get{ return mDM_TonGiaoID;}
        }
        public string MaTonGiao{
        	set{ mMaTonGiao = value;}
        	get{ return mMaTonGiao;}
        }
        public string TenTonGiao{
        	set{ mTenTonGiao = value;}
        	get{ return mTenTonGiao;}
        }
    }
}
