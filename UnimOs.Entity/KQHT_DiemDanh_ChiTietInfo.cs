using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_DiemDanh_ChiTietInfo
    {

        private int mKQHT_DiemDanh_ChiTietID;
        private int mIDKQHT_DiemDanh;
        private long mIDXL_Tuan;
        private int mSoTiet;
        private string mLyDo;

        public string strKQHT_DiemDanh_ChiTietID = "KQHT_DiemDanh_ChiTietID";
        public string strIDKQHT_DiemDanh = "IDKQHT_DiemDanh";
        public string strIDXL_Tuan = "IDXL_Tuan";
        public string strSoTiet = "SoTiet";
        public string strLyDo = "LyDo";

        public KQHT_DiemDanh_ChiTietInfo()
        { }

        public int KQHT_DiemDanh_ChiTietID{
        	set{ mKQHT_DiemDanh_ChiTietID = value;}
        	get{ return mKQHT_DiemDanh_ChiTietID;}
        }
        public int IDKQHT_DiemDanh{
        	set{ mIDKQHT_DiemDanh = value;}
        	get{ return mIDKQHT_DiemDanh;}
        }
        public long IDXL_Tuan{
        	set{ mIDXL_Tuan = value;}
        	get{ return mIDXL_Tuan;}
        }
        public int SoTiet
        {
        	set{ mSoTiet = value;}
        	get{ return mSoTiet;}
        }
        public string LyDo{
        	set{ mLyDo = value;}
        	get{ return mLyDo;}
        }
    }
}
