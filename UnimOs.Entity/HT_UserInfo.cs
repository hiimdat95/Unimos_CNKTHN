using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class HT_UserInfo
    {

        private int mHT_UserID;
        private string mUserName;
        private string mPassword;
        private string mFullName;
        private int mIDNS_GiaoVien;
        private int mIDHT_UserGroup;
        private bool mActive;
        private string mIpAddress;
        private string mMacAddress;

        public string strHT_UserID = "HT_UserID";
        public string strUserName = "UserName";
        public string strPassword = "Password";
        public string strFullName = "FullName";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strIDHT_UserGroup = "IDHT_UserGroup";
        public string strActive = "Active";
        public string strIpAddress = "IpAddress";
        public string strMacAddress = "MacAddress";

        public HT_UserInfo()
        { }

        public int HT_UserID{
        	set{ mHT_UserID = value;}
        	get{ return mHT_UserID;}
        }
        public string UserName{
        	set{ mUserName = value;}
        	get{ return mUserName;}
        }
        public string Password{
        	set{ mPassword = value;}
        	get{ return mPassword;}
        }
        public string FullName{
        	set{ mFullName = value;}
        	get{ return mFullName;}
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
        }
        public int IDHT_UserGroup{
        	set{ mIDHT_UserGroup = value;}
        	get{ return mIDHT_UserGroup;}
        }
        public bool Active{
        	set{ mActive = value;}
        	get{ return mActive;}
        }
        public string IpAddress{
        	set{ mIpAddress = value;}
        	get{ return mIpAddress;}
        }
        public string MacAddress{
        	set{ mMacAddress = value;}
        	get{ return mMacAddress;}
        }
    }
}
