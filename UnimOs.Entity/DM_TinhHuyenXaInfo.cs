using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_TinhHuyenXaInfo
    {

        private int mDM_TinhHuyenXaID;
        private string mMa;
        private string mTen;
        private int mParentID;
        private int mLevel;

        public string strDM_TinhHuyenXaID = "DM_TinhHuyenXaID";
        public string strMa = "Ma";
        public string strTen = "Ten";
        public string strParentID = "ParentID";
        public string strLevel = "Level";

        public DM_TinhHuyenXaInfo()
        { }

        public int DM_TinhHuyenXaID{
        	set{ mDM_TinhHuyenXaID = value;}
        	get{ return mDM_TinhHuyenXaID;}
        }
        public string Ma{
        	set{ mMa = value;}
        	get{ return mMa;}
        }
        public string Ten{
        	set{ mTen = value;}
        	get{ return mTen;}
        }
        public int ParentID{
        	set{ mParentID = value;}
        	get{ return mParentID;}
        }
        public int Level{
        	set{ mLevel = value;}
        	get{ return mLevel;}
        }
    }
}
