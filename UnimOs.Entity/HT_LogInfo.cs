using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class HT_LogInfo
    {

        private long mHT_LogID;
        private string mTag;
        private string mSuKien;
        private string mNoiDung;
        private DateTime mThoiDiem;
        private string mUserName;
        private string mIPMayTram;
        private string mMacMayTram;

        public string strHT_LogID = "HT_LogID";
        public string strTag = "Tag";
        public string strSuKien = "SuKien";
        public string strNoiDung = "NoiDung";
        public string strThoiDiem = "ThoiDiem";
        public string strUserName = "UserName";
        public string strIPMayTram = "IPMayTram";
        public string strMacMayTram = "MacMayTram";

        public HT_LogInfo()
        { }

        public long HT_LogID{
        	set{ mHT_LogID = value;}
        	get{ return mHT_LogID;}
        }
        public string Tag{
        	set{ mTag = value;}
        	get{ return mTag;}
        }
        public string SuKien{
        	set{ mSuKien = value;}
        	get{ return mSuKien;}
        }
        public string NoiDung{
        	set{ mNoiDung = value;}
        	get{ return mNoiDung;}
        }
        public DateTime ThoiDiem{
        	set{ mThoiDiem = value;}
        	get{ return mThoiDiem;}
        }
        public string UserName{
        	set{ mUserName = value;}
        	get{ return mUserName;}
        }
        public string IPMayTram{
        	set{ mIPMayTram = value;}
        	get{ return mIPMayTram;}
        }
        public string MacMayTram{
        	set{ mMacMayTram = value;}
        	get{ return mMacMayTram;}
        }
    }
}
