using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_XepLoaiMonHocInfo
    {

        private int mKQHT_XepLoaiMonHocID;
        private string mTenXepLoai;
        private double mTuDiem;
        private string mMaXepLoai;

        public string strKQHT_XepLoaiMonHocID = "KQHT_XepLoaiMonHocID";
        public string strTenXepLoai = "TenXepLoai";
        public string strTuDiem = "TuDiem";
        public string strMaXepLoai = "MaXepLoai";

        public KQHT_XepLoaiMonHocInfo()
        { }

        public int KQHT_XepLoaiMonHocID{
        	set{ mKQHT_XepLoaiMonHocID = value;}
        	get{ return mKQHT_XepLoaiMonHocID;}
        }
        public string TenXepLoai{
        	set{ mTenXepLoai = value;}
        	get{ return mTenXepLoai;}
        }
        public double TuDiem{
        	set{ mTuDiem = value;}
        	get{ return mTuDiem;}
        }
        public string MaXepLoai{
        	set{ mMaXepLoai = value;}
        	get{ return mMaXepLoai;}
        }
    }
}
