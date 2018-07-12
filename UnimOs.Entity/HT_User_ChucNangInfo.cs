using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class HT_User_ChucNangInfo
    {

        private int mHT_User_ChucNangID;
        private int mIDHT_User;
        private int mIDHT_ChucNang;
        private bool mThem;
        private bool mSua;
        private bool mXoa;

        public string strHT_User_ChucNangID = "HT_User_ChucNangID";
        public string strIDHT_User = "IDHT_User";
        public string strIDHT_ChucNang = "IDHT_ChucNang";
        public string strThem = "Them";
        public string strSua = "Sua";
        public string strXoa = "Xoa";

        public HT_User_ChucNangInfo()
        { }

        public int HT_User_ChucNangID{
        	set{ mHT_User_ChucNangID = value;}
        	get{ return mHT_User_ChucNangID;}
        }
        public int IDHT_User{
        	set{ mIDHT_User = value;}
        	get{ return mIDHT_User;}
        }
        public int IDHT_ChucNang{
        	set{ mIDHT_ChucNang = value;}
        	get{ return mIDHT_ChucNang;}
        }
        public bool Them{
        	set{ mThem = value;}
        	get{ return mThem;}
        }
        public bool Sua{
        	set{ mSua = value;}
        	get{ return mSua;}
        }
        public bool Xoa{
        	set{ mXoa = value;}
        	get{ return mXoa;}
        }
    }
}
