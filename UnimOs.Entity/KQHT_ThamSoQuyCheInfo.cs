using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_ThamSoQuyCheInfo
    {

        private int mKQHT_ThamSoQuyCheID;
        private string mMaThamSo;
        private string mTenThamSo;
        private string mGiaTriMacDinh;
        private string mKieuTruong;

        public string strKQHT_ThamSoQuyCheID = "KQHT_ThamSoQuyCheID";
        public string strMaThamSo = "MaThamSo";
        public string strTenThamSo = "TenThamSo";
        public string strGiaTriMacDinh = "GiaTriMacDinh";
        public string strKieuTruong = "KieuTruong";

        public KQHT_ThamSoQuyCheInfo()
        { }

        public int KQHT_ThamSoQuyCheID{
        	set{ mKQHT_ThamSoQuyCheID = value;}
        	get{ return mKQHT_ThamSoQuyCheID;}
        }
        public string MaThamSo{
        	set{ mMaThamSo = value;}
        	get{ return mMaThamSo;}
        }
        public string TenThamSo{
        	set{ mTenThamSo = value;}
        	get{ return mTenThamSo;}
        }
        public string GiaTriMacDinh{
        	set{ mGiaTriMacDinh = value;}
        	get{ return mGiaTriMacDinh;}
        }
        public string KieuTruong{
        	set{ mKieuTruong = value;}
        	get{ return mKieuTruong;}
        }
    }
}
