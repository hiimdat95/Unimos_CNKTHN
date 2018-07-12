using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class NS_LinhVucCongTacInfo
    {

        private int mNS_LinhVucCongTacID;
        private int mSTT;
        private string mTenLinhVuc;

        public string strNS_LinhVucCongTacID = "NS_LinhVucCongTacID";
        public string strSTT = "STT";
        public string strTenLinhVuc = "TenLinhVuc";

        public NS_LinhVucCongTacInfo()
        { }

        public int NS_LinhVucCongTacID{
        	set{ mNS_LinhVucCongTacID = value;}
        	get{ return mNS_LinhVucCongTacID;}
        }
        public int STT{
        	set{ mSTT = value;}
        	get{ return mSTT;}
        }
        public string TenLinhVuc{
        	set{ mTenLinhVuc = value;}
        	get{ return mTenLinhVuc;}
        }
    }
}
