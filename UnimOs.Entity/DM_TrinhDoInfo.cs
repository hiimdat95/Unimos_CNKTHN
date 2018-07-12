using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_TrinhDoInfo
    {

        private int mDM_TrinhDoID;
        private int mIDDM_He;
        private int mIDKQHT_QuyChe;
        private string mMaTrinhDo;
        private string mTenTrinhDo;
        private string mTenTrinhDo_E;

        public string strDM_TrinhDoID = "DM_TrinhDoID";
        public string strIDDM_He = "IDDM_He";
        public string strIDKQHT_QuyChe = "IDKQHT_QuyChe";
        public string strMaTrinhDo = "MaTrinhDo";
        public string strTenTrinhDo = "TenTrinhDo";
        public string strTenTrinhDo_E = "TenTrinhDo_E";

        public DM_TrinhDoInfo()
        { }

        public int DM_TrinhDoID{
        	set{ mDM_TrinhDoID = value;}
        	get{ return mDM_TrinhDoID;}
        }
        public int IDDM_He{
        	set{ mIDDM_He = value;}
        	get{ return mIDDM_He;}
        }
        public int IDKQHT_QuyChe{
        	set{ mIDKQHT_QuyChe = value;}
        	get{ return mIDKQHT_QuyChe;}
        }
        public string MaTrinhDo{
        	set{ mMaTrinhDo = value;}
        	get{ return mMaTrinhDo;}
        }
        public string TenTrinhDo{
        	set{ mTenTrinhDo = value;}
        	get{ return mTenTrinhDo;}
        }
        public string TenTrinhDo_E{
        	set{ mTenTrinhDo_E = value;}
        	get{ return mTenTrinhDo_E;}
        }
    }
}
