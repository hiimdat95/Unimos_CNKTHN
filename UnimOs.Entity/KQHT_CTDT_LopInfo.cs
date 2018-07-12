using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_CTDT_LopInfo
    {

        private int mKQHT_CTDT_LopID;
        private int mIDDM_Lop;
        private int mIDKQHT_ChuongTrinhDaoTao;

        public string strKQHT_CTDT_LopID = "KQHT_CTDT_LopID";
        public string strIDDM_Lop = "IDDM_Lop";
        public string strIDKQHT_ChuongTrinhDaoTao = "IDKQHT_ChuongTrinhDaoTao";

        public KQHT_CTDT_LopInfo()
        { }

        public int KQHT_CTDT_LopID{
        	set{ mKQHT_CTDT_LopID = value;}
        	get{ return mKQHT_CTDT_LopID;}
        }
        public int IDDM_Lop{
        	set{ mIDDM_Lop = value;}
        	get{ return mIDDM_Lop;}
        }
        public int IDKQHT_ChuongTrinhDaoTao{
        	set{ mIDKQHT_ChuongTrinhDaoTao = value;}
        	get{ return mIDKQHT_ChuongTrinhDaoTao;}
        }
    }
}
