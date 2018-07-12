using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class GG_HeSoTheoTrinhDoInfo
    {

        private int mGG_HeSoTheoTrinhDoID;
        private string mLoaiGiangDay;
        private int mIDDM_TrinhDo;
        private int mTuSo;
        private int mDenSo;
        private double mHeSo;

        public string strGG_HeSoTheoTrinhDoID = "GG_HeSoTheoTrinhDoID";
        public string strLoaiGiangDay = "LoaiGiangDay";
        public string strIDDM_TrinhDo = "IDDM_TrinhDo";
        public string strTuSo = "TuSo";
        public string strDenSo = "DenSo";
        public string strHeSo = "HeSo";

        public GG_HeSoTheoTrinhDoInfo()
        { }

        public int GG_HeSoTheoTrinhDoID{
        	set{ mGG_HeSoTheoTrinhDoID = value;}
        	get{ return mGG_HeSoTheoTrinhDoID;}
        }
        public string LoaiGiangDay{
        	set{ mLoaiGiangDay = value;}
        	get{ return mLoaiGiangDay;}
        }
        public int IDDM_TrinhDo{
        	set{ mIDDM_TrinhDo = value;}
        	get{ return mIDDM_TrinhDo;}
        }
        public int TuSo{
        	set{ mTuSo = value;}
        	get{ return mTuSo;}
        }
        public int DenSo{
        	set{ mDenSo = value;}
        	get{ return mDenSo;}
        }
        public double HeSo{
        	set{ mHeSo = value;}
        	get{ return mHeSo;}
        }
    }
}
