using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_DoiTuongTroCapInfo
    {

        private int mDM_DoiTuongTroCapID;
        private string mMaDoiTuongTroCap;
        private string mTenDoiTuongTroCap;
        private double mSoTienTroCap;

        public string strDM_DoiTuongTroCapID = "DM_DoiTuongTroCapID";
        public string strMaDoiTuongTroCap = "MaDoiTuongTroCap";
        public string strTenDoiTuongTroCap = "TenDoiTuongTroCap";
        public string strSoTienTroCap = "SoTienTroCap";

        public DM_DoiTuongTroCapInfo()
        { }

        public int DM_DoiTuongTroCapID{
        	set{ mDM_DoiTuongTroCapID = value;}
        	get{ return mDM_DoiTuongTroCapID;}
        }
        public string MaDoiTuongTroCap{
        	set{ mMaDoiTuongTroCap = value;}
        	get{ return mMaDoiTuongTroCap;}
        }
        public string TenDoiTuongTroCap{
        	set{ mTenDoiTuongTroCap = value;}
        	get{ return mTenDoiTuongTroCap;}
        }
        public double SoTienTroCap{
        	set{ mSoTienTroCap = value;}
        	get{ return mSoTienTroCap;}
        }
    }
}
