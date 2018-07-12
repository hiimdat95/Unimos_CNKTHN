using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_MonHocInfo
    {

        private int mDM_MonHocID;
        private string mMaMonHoc;
        private string mTenMonHoc;
        private string mTenMonHoc_E;
        private string mTenVietTat;
        private int mSoTiet;
        private int mLyThuyet;
        private int mThucHanh;
        private int mLoaiTietKhac1;
        private int mLoaiTietKhac2;
        private double mSoHocTrinh;
        private bool mChoPhepXepLich;
        private int mSuDungPhong;
        private int mIDDM_TrinhDo;
        private int mIDDM_Nganh;
        private int mIDDM_ChuyenNganh;
        private int mIDDM_BoMon;
        private int mIDDM_KhoiKienThuc;
        private int mIDDM_HinhThucThi;
        private bool mTinhDiemToanKhoa;
        private string mMoTa;

        public string strDM_MonHocID = "DM_MonHocID";
        public string strMaMonHoc = "MaMonHoc";
        public string strTenMonHoc = "TenMonHoc";
        public string strTenMonHoc_E = "TenMonHoc_E";
        public string strTenVietTat = "TenVietTat";
        public string strSoTiet = "SoTiet";
        public string strLyThuyet = "LyThuyet";
        public string strThucHanh = "ThucHanh";
        public string strLoaiTietKhac1 = "LoaiTietKhac1";
        public string strLoaiTietKhac2 = "LoaiTietKhac2";
        public string strSoHocTrinh = "SoHocTrinh";
        public string strChoPhepXepLich = "ChoPhepXepLich";
        public string strSuDungPhong = "SuDungPhong";
        public string strIDDM_TrinhDo = "IDDM_TrinhDo";
        public string strIDDM_Nganh = "IDDM_Nganh";
        public string strIDDM_ChuyenNganh = "IDDM_ChuyenNganh";
        public string strIDDM_BoMon = "IDDM_BoMon";
        public string strIDDM_KhoiKienThuc = "IDDM_KhoiKienThuc";
        public string strIDDM_HinhThucThi = "IDDM_HinhThucThi";
        public string strMoTa = "MoTa";
        public string strTinhDiemToanKhoa = "TinhDiemToanKhoa";

        public DM_MonHocInfo()
        { }

        public int DM_MonHocID{
        	set{ mDM_MonHocID = value;}
        	get{ return mDM_MonHocID;}
        }
        public string MaMonHoc{
        	set{ mMaMonHoc = value;}
        	get{ return mMaMonHoc;}
        }
        public string TenMonHoc{
        	set{ mTenMonHoc = value;}
        	get{ return mTenMonHoc;}
        }
        public string TenMonHoc_E{
        	set{ mTenMonHoc_E = value;}
        	get{ return mTenMonHoc_E;}
        }
        public string TenVietTat
        {
            set { mTenVietTat = value; }
            get { return mTenVietTat; }
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
        public int SuDungPhong{
        	set{ mSuDungPhong = value;}
        	get{ return mSuDungPhong;}
        }
        public int IDDM_TrinhDo{
        	set{ mIDDM_TrinhDo = value;}
        	get{ return mIDDM_TrinhDo;}
        }
        public int IDDM_Nganh{
        	set{ mIDDM_Nganh = value;}
        	get{ return mIDDM_Nganh;}
        }
        public int IDDM_ChuyenNganh{
        	set{ mIDDM_ChuyenNganh = value;}
        	get{ return mIDDM_ChuyenNganh;}
        }
        public int IDDM_BoMon{
        	set{ mIDDM_BoMon = value;}
        	get{ return mIDDM_BoMon;}
        }
        public int IDDM_KhoiKienThuc{
        	set{ mIDDM_KhoiKienThuc = value;}
        	get{ return mIDDM_KhoiKienThuc;}
        }
        public int IDDM_HinhThucThi{
        	set{ mIDDM_HinhThucThi = value;}
        	get{ return mIDDM_HinhThucThi;}
        }
        public string MoTa{
        	set{ mMoTa = value;}
        	get{ return mMoTa;}
        }
        public bool TinhDiemToanKhoa 
        {
            set { mTinhDiemToanKhoa = value; }
            get { return mTinhDiemToanKhoa; }
        }
    }
}
