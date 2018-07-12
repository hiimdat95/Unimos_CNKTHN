using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_QuyCheInfo
    {

        private int mKQHT_QuyCheID;
        private string mMaQuyChe;
        private string mTenQuyChe;

        public string strKQHT_QuyCheID = "KQHT_QuyCheID";
        public string strMaQuyChe = "MaQuyChe";
        public string strTenQuyChe = "TenQuyChe";

        public KQHT_QuyCheInfo()
        { }

        public int KQHT_QuyCheID{
        	set{ mKQHT_QuyCheID = value;}
        	get{ return mKQHT_QuyCheID;}
        }
        public string MaQuyChe{
        	set{ mMaQuyChe = value;}
        	get{ return mMaQuyChe;}
        }
        public string TenQuyChe{
        	set{ mTenQuyChe = value;}
        	get{ return mTenQuyChe;}
        }
    }
}
