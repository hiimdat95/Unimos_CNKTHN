using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_CTDT_CT_KhoiKienThucInfo
    {

        private int mKQHT_CTDT_CT_KhoiKienThucID;
        private int mIDKQHT_ChuongTrinhDaoTao;
        private int mIDKQHT_CT_KhoiKienThuc;

        public string strKQHT_CTDT_CT_KhoiKienThucID = "KQHT_CTDT_CT_KhoiKienThucID";
        public string strIDKQHT_ChuongTrinhDaoTao = "IDKQHT_ChuongTrinhDaoTao";
        public string strIDKQHT_CT_KhoiKienThuc = "IDKQHT_CT_KhoiKienThuc";

        public KQHT_CTDT_CT_KhoiKienThucInfo()
        { }

        public int KQHT_CTDT_CT_KhoiKienThucID{
        	set{ mKQHT_CTDT_CT_KhoiKienThucID = value;}
        	get{ return mKQHT_CTDT_CT_KhoiKienThucID;}
        }
        public int IDKQHT_ChuongTrinhDaoTao{
        	set{ mIDKQHT_ChuongTrinhDaoTao = value;}
        	get{ return mIDKQHT_ChuongTrinhDaoTao;}
        }
        public int IDKQHT_CT_KhoiKienThuc{
        	set{ mIDKQHT_CT_KhoiKienThuc = value;}
        	get{ return mIDKQHT_CT_KhoiKienThuc;}
        }
    }
}
