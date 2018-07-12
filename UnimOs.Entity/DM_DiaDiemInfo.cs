using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_DiaDiemInfo
    {

        private int mDM_DiaDiemID;
        private string mMaDiaDiem;
        private string mTenDiaDiem;
        private string mMoTa;

        public string strDM_DiaDiemID = "DM_DiaDiemID";
        public string strMaDiaDiem = "MaDiaDiem";
        public string strTenDiaDiem = "TenDiaDiem";
        public string strMoTa = "MoTa";

        public DM_DiaDiemInfo()
        { }

        public int DM_DiaDiemID{
        	set{ mDM_DiaDiemID = value;}
        	get{ return mDM_DiaDiemID;}
        }
        public string MaDiaDiem{
        	set{ mMaDiaDiem = value;}
        	get{ return mMaDiaDiem;}
        }
        public string TenDiaDiem{
        	set{ mTenDiaDiem = value;}
        	get{ return mTenDiaDiem;}
        }
        public string MoTa
        {
            set { mMoTa = value; }
            get { return mMoTa; }
        }
    }
}
