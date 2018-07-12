using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_ToaNhaInfo
    {

        private int mDM_ToaNhaID;
        private int mIDDM_DiaDiem;
        private string mMaToaNha;
        private string mTenToaNha;

        public string strDM_ToaNhaID = "DM_ToaNhaID";
        public string strIDDM_DiaDiem = "IDDM_DiaDiem";
        public string strMaToaNha = "MaToaNha";
        public string strTenToaNha = "TenToaNha";

        public DM_ToaNhaInfo()
        { }

        public int DM_ToaNhaID{
        	set{ mDM_ToaNhaID = value;}
        	get{ return mDM_ToaNhaID;}
        }
        public int IDDM_DiaDiem{
        	set{ mIDDM_DiaDiem = value;}
        	get{ return mIDDM_DiaDiem;}
        }
        public string MaToaNha{
        	set{ mMaToaNha = value;}
        	get{ return mMaToaNha;}
        }
        public string TenToaNha{
        	set{ mTenToaNha = value;}
        	get{ return mTenToaNha;}
        }
    }
}
