using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_CTDT_ChiTietInfo
    {

        private long mKQHT_CTDT_ChiTietID;
        private int mIDKQHT_MonHoc_CT_KhoiKienThuc;
        private int mHocKy;
        private int mSoTiet;
        private int mLyThuyet;
        private int mThucHanh;
        private int mLoaiTietKhac1;
        private int mLoaiTietKhac2;
        private double mSoHocTrinh;

        public string strKQHT_CTDT_ChiTietID = "KQHT_CTDT_ChiTietID";
        public string strIDKQHT_MonHoc_CT_KhoiKienThuc = "IDKQHT_MonHoc_CT_KhoiKienThuc";
        public string strHocKy = "HocKy";
        public string strSoTiet = "SoTiet";
        public string strLyThuyet = "LyThuyet";
        public string strThucHanh = "ThucHanh";
        public string strLoaiTietKhac1 = "LoaiTietKhac1";
        public string strLoaiTietKhac2 = "LoaiTietKhac2";
        public string strSoHocTrinh = "SoHocTrinh";

        public KQHT_CTDT_ChiTietInfo()
        { }

        public long KQHT_CTDT_ChiTietID{
        	set{ mKQHT_CTDT_ChiTietID = value;}
        	get{ return mKQHT_CTDT_ChiTietID;}
        }
        public int IDKQHT_MonHoc_CT_KhoiKienThuc{
        	set{ mIDKQHT_MonHoc_CT_KhoiKienThuc = value;}
        	get{ return mIDKQHT_MonHoc_CT_KhoiKienThuc;}
        }
        public int HocKy{
        	set{ mHocKy = value;}
        	get{ return mHocKy;}
        }
        public int SoTiet{
        	set{ mSoTiet = value;}
        	get{ return mSoTiet;}
        }
        public int LyThuyet{
        	set{ mLyThuyet = value;}
        	get{ return mLyThuyet;}
        }
        public int ThucHanh{
        	set{ mThucHanh = value;}
        	get{ return mThucHanh;}
        }
        public int LoaiTietKhac1{
        	set{ mLoaiTietKhac1 = value;}
        	get{ return mLoaiTietKhac1;}
        }
        public int LoaiTietKhac2{
        	set{ mLoaiTietKhac2 = value;}
        	get{ return mLoaiTietKhac2;}
        }
        public double SoHocTrinh{
        	set{ mSoHocTrinh = value;}
        	get{ return mSoHocTrinh;}
        }
    }
}
