using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class XL_MonHocTrongKyInfo
    {

        private int mXL_MonHocTrongKyID;
        private long mIDKQHT_CTDT_ChiTiet;
        private int mIDDM_Lop;
        private int mHocKy;
        private int mIDDM_NamHoc;
        private int mSoTiet;
        private int mLyThuyet;
        private int mThucHanh;
        private int mLoaiTietKhac1;
        private int mLoaiTietKhac2;
        private double mSoHocTrinh;
        private bool mChoPhepXepLich;
        private int mIDDM_HinhThucThi;
        private bool mHocOLopTachGop;
        private int mSapXep;
        private bool mTinhDiemToanKhoa;

        public string strXL_MonHocTrongKyID = "XL_MonHocTrongKyID";
        public string strIDKQHT_CTDT_ChiTiet = "IDKQHT_CTDT_ChiTiet";
        public string strIDDM_Lop = "IDDM_Lop";
        public string strHocKy = "HocKy";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strSoTiet = "SoTiet";
        public string strLyThuyet = "LyThuyet";
        public string strThucHanh = "ThucHanh";
        public string strLoaiTietKhac1 = "LoaiTietKhac1";
        public string strLoaiTietKhac2 = "LoaiTietKhac2";
        public string strSoHocTrinh = "SoHocTrinh";
        public string strChoPhepXepLich = "ChoPhepXepLich";
        public string strIDDM_HinhThucThi = "IDDM_HinhThucThi";
        public string strHocOLopTachGop = "HocOLopTachGop";
        public string strSapXep = "SapXep";
        public string strTinhDiemToanKhoa = "TinhDiemToanKhoa";

        public XL_MonHocTrongKyInfo()
        { }

        public int XL_MonHocTrongKyID{
        	set{ mXL_MonHocTrongKyID = value;}
        	get{ return mXL_MonHocTrongKyID;}
        }
        public long IDKQHT_CTDT_ChiTiet{
        	set{ mIDKQHT_CTDT_ChiTiet = value;}
        	get{ return mIDKQHT_CTDT_ChiTiet;}
        }
        public int IDDM_Lop{
        	set{ mIDDM_Lop = value;}
        	get{ return mIDDM_Lop;}
        }
        public int HocKy{
        	set{ mHocKy = value;}
        	get{ return mHocKy;}
        }
        public int IDDM_NamHoc{
        	set{ mIDDM_NamHoc = value;}
        	get{ return mIDDM_NamHoc;}
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
        public bool ChoPhepXepLich{
        	set{ mChoPhepXepLich = value;}
        	get{ return mChoPhepXepLich;}
        }
        public int IDDM_HinhThucThi{
        	set{ mIDDM_HinhThucThi = value;}
        	get{ return mIDDM_HinhThucThi;}
        }
        public bool HocOLopTachGop{
        	set{ mHocOLopTachGop = value;}
        	get{ return mHocOLopTachGop;}
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
