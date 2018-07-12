using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class HT_PhanHeInfo
    {

        private int mHT_PhanHeID;
        private string mMaPhanHe;
        private string mTenPhanHe;
        private string mMoTa;
        private int mSapXep;

        public string strHT_PhanHeID = "HT_PhanHeID";
        public string strMaPhanHe = "MaPhanHe";
        public string strTenPhanHe = "TenPhanHe";
        public string strMoTa = "MoTa";
        public string strSapXep = "SapXep";

        public HT_PhanHeInfo()
        { }

        public int HT_PhanHeID{
        	set{ mHT_PhanHeID = value;}
        	get{ return mHT_PhanHeID;}
        }
        public string MaPhanHe{
        	set{ mMaPhanHe = value;}
        	get{ return mMaPhanHe;}
        }
        public string TenPhanHe{
        	set{ mTenPhanHe = value;}
        	get{ return mTenPhanHe;}
        }
        public string MoTa{
        	set{ mMoTa = value;}
        	get{ return mMoTa;}
        }
        public int SapXep{
        	set{ mSapXep = value;}
        	get{ return mSapXep;}
        }
    }
}
