using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class HT_UserGroup_ChucNangInfo
    {

        private int mHT_UserGroup_ChucNangID;
        private int mIDHT_UserGroup;
        private int mIDHT_ChucNang;
        private bool mXem;
        private bool mSua;
        private bool mXoa;
        private bool mThem;

        public string strHT_UserGroup_ChucNangID = "HT_UserGroup_ChucNangID";
        public string strIDHT_UserGroup = "IDHT_UserGroup";
        public string strIDHT_ChucNang = "IDHT_ChucNang";
        public string strXem = "Xem";
        public string strSua = "Sua";
        public string strXoa = "Xoa";
        public string strThem = "Them";

        public HT_UserGroup_ChucNangInfo()
        { }

        public int HT_UserGroup_ChucNangID{
        	set{ mHT_UserGroup_ChucNangID = value;}
        	get{ return mHT_UserGroup_ChucNangID;}
        }
        public int IDHT_UserGroup{
        	set{ mIDHT_UserGroup = value;}
        	get{ return mIDHT_UserGroup;}
        }
        public int IDHT_ChucNang{
        	set{ mIDHT_ChucNang = value;}
        	get{ return mIDHT_ChucNang;}
        }
        public bool Xem{
        	set{ mXem = value;}
        	get{ return mXem;}
        }
        public bool Sua{
        	set{ mSua = value;}
        	get{ return mSua;}
        }
        public bool Xoa{
        	set{ mXoa = value;}
        	get{ return mXoa;}
        }
        public bool Them{
        	set{ mThem = value;}
        	get{ return mThem;}
        }
    }
}
