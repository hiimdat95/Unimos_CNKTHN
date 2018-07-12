using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_MonHoc_CT_KhoiKienThucInfo
    {

        private int mKQHT_MonHoc_CT_KhoiKienThucID;
        private int mIDKQHT_CT_KhoiKienThuc;
        private int mIDDM_MonHoc;
        private double mSoHocTrinh;
        private int mSoTiet;
        private int mLyThuyet;
        private int mThucHanh;
        private int mLoaiTietKhac1;
        private int mLoaiTietKhac2;
        private bool mChoPhepXepLich;
        private int mIDDM_HinhThucThi;
        private bool mTuChon;
        private int mSapXep;
        private bool mTinhDiemToanKhoa;

        public string strKQHT_MonHoc_CT_KhoiKienThucID = "KQHT_MonHoc_CT_KhoiKienThucID";
        public string strIDKQHT_CT_KhoiKienThuc = "IDKQHT_CT_KhoiKienThuc";
        public string strIDDM_MonHoc = "IDDM_MonHoc";
        public string strSoHocTrinh = "SoHocTrinh";
        public string strSoTiet = "SoTiet";
        public string strLyThuyet = "LyThuyet";
        public string strThucHanh = "ThucHanh";
        public string strLoaiTietKhac1 = "LoaiTietKhac1";
        public string strLoaiTietKhac2 = "LoaiTietKhac2";
        public string strChoPhepXepLich = "ChoPhepXepLich";
        public string strIDDM_HinhThucThi = "IDDM_HinhThucThi";
        public string strTuChon = "TuChon";
        public string strSapXep = "SapXep";
        public string strTinhDiemToanKhoa = "TinhDiemToanKhoa";

        public KQHT_MonHoc_CT_KhoiKienThucInfo()
        { }

        public int KQHT_MonHoc_CT_KhoiKienThucID{
        	set{ mKQHT_MonHoc_CT_KhoiKienThucID = value;}
        	get{ return mKQHT_MonHoc_CT_KhoiKienThucID;}
        }
        public int IDKQHT_CT_KhoiKienThuc{
        	set{ mIDKQHT_CT_KhoiKienThuc = value;}
        	get{ return mIDKQHT_CT_KhoiKienThuc;}
        }
        public int IDDM_MonHoc{
        	set{ mIDDM_MonHoc = value;}
        	get{ return mIDDM_MonHoc;}
        }
        public double SoHocTrinh{
        	set{ mSoHocTrinh = value;}
        	get{ return mSoHocTrinh;}
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
        public bool ChoPhepXepLich{
        	set{ mChoPhepXepLich = value;}
        	get{ return mChoPhepXepLich;}
        }
        public int IDDM_HinhThucThi{
        	set{ mIDDM_HinhThucThi = value;}
        	get{ return mIDDM_HinhThucThi;}
        }
        public bool TuChon{
        	set{ mTuChon = value;}
        	get{ return mTuChon;}
        }
        public int SapXep{
        	set{ mSapXep = value;}
        	get{ return mSapXep;}
        }
        public bool TinhDiemToanKhoa
        {
            set { mTinhDiemToanKhoa = value; }
            get { return mTinhDiemToanKhoa; }
        }
    }
}
