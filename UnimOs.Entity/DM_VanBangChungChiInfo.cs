using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_VanBangChungChiInfo
    {

        private int mDM_VanBangChungChiID;
        private string mTen;
        private bool mVanBang;
        private bool mChungChi;

        public string strDM_VanBangChungChiID = "DM_VanBangChungChiID";
        public string strTen = "Ten";
        public string strVanBang = "VanBang";
        public string strChungChi = "ChungChi";

        public DM_VanBangChungChiInfo()
        { }

        public int DM_VanBangChungChiID{
        	set{ mDM_VanBangChungChiID = value;}
        	get{ return mDM_VanBangChungChiID;}
        }
        public string Ten{
        	set{ mTen = value;}
        	get{ return mTen;}
        }
        public bool VanBang{
        	set{ mVanBang = value;}
        	get{ return mVanBang;}
        }
        public bool ChungChi{
        	set{ mChungChi = value;}
        	get{ return mChungChi;}
        }
    }
}
