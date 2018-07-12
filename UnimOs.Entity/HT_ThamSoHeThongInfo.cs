using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class HT_ThamSoHeThongInfo
    {

        private int mHT_ThamSoHeThongID;
        private string mMaThamSoHeThong;
        private string mTenThamSoHeThong;
        private int mIDDM_He;
        private int mPhanHe;
        private string mGiaTri;
        private string mGhiChu;
        private bool mTrangThai;
        private int mSapXep;

        public string strHT_ThamSoHeThongID = "HT_ThamSoHeThongID";
        public string strMaThamSoHeThong = "MaThamSoHeThong";
        public string strTenThamSoHeThong = "TenThamSoHeThong";
        public string strIDDM_He = "IDDM_He";
        public string strPhanHe = "PhanHe";
        public string strGiaTri = "GiaTri";
        public string strGhiChu = "GhiChu";
        public string strTrangThai = "TrangThai";
        public string strSapXep = "SapXep";

        public HT_ThamSoHeThongInfo()
        { }

        public int HT_ThamSoHeThongID{
        	set{ mHT_ThamSoHeThongID = value;}
        	get{ return mHT_ThamSoHeThongID;}
        }
        public string MaThamSoHeThong{
        	set{ mMaThamSoHeThong = value;}
        	get{ return mMaThamSoHeThong;}
        }
        public string TenThamSoHeThong{
        	set{ mTenThamSoHeThong = value;}
        	get{ return mTenThamSoHeThong;}
        }
        public int IDDM_He{
        	set{ mIDDM_He = value;}
        	get{ return mIDDM_He;}
        }
        public int PhanHe{
        	set{ mPhanHe = value;}
        	get{ return mPhanHe;}
        }
        public string GiaTri{
        	set{ mGiaTri = value;}
        	get{ return mGiaTri;}
        }
        public string GhiChu{
        	set{ mGhiChu = value;}
        	get{ return mGhiChu;}
        }
        public bool TrangThai{
        	set{ mTrangThai = value;}
        	get{ return mTrangThai;}
        }
        public int SapXep{
        	set{ mSapXep = value;}
        	get{ return mSapXep;}
        }
    }

    public struct HT_ThamSoXepLichInfo
    {
        private int _SO_TIET_CASANG;
        private int _SO_TIET_CACHIEU;
        private int _SO_TIET_CATOI;
        private int _THU_BAT_DAU;
        private int _THU_KET_THUC;
        private int _SO_BUOI_HOC;
        private int _SO_NHOMTIET_TRONG_BUOI;
        private int _SO_NHOMTIET_TRONG_NGAY;
        private int _SUDUNG_BAOBAN_TRONG_XEPLICH;
        private string _SO_TIET_CAC_NHOM;
        private int _THUCHANH_TU_THU;
        private int _THUCHANH_DEN_THU;
        private int _SO_TIET_THUCHANH_TRONGTUAN;

        public int SO_TIET_CASANG
        {
            set { _SO_TIET_CASANG = value; }
            get { return _SO_TIET_CASANG; }
        }
        public int SO_TIET_NGAY
        {
            get { return _SO_TIET_CASANG + _SO_TIET_CACHIEU + _SO_TIET_CATOI; }
        }
        public int SO_TIET_CACHIEU
        {
            set { _SO_TIET_CACHIEU = value; }
            get { return _SO_TIET_CACHIEU; }
        }
        public int SO_TIET_CATOI
        {
            set { _SO_TIET_CATOI = value; }
            get { return _SO_TIET_CATOI; }
        }
        public int THU_BAT_DAU
        {
            set { _THU_BAT_DAU = value; }
            get { return _THU_BAT_DAU; }
        }
        public int THU_KET_THUC
        {
            set { _THU_KET_THUC = value; }
            get { return _THU_KET_THUC; }
        }
        public int SO_BUOI_HOC
        {
            set { _SO_BUOI_HOC = value; }
            get { return _SO_BUOI_HOC; }
        }
        public int SO_NHOMTIET_TRONG_BUOI
        {
            set { _SO_NHOMTIET_TRONG_BUOI = value; }
            get { return _SO_NHOMTIET_TRONG_BUOI; }
        }
        public int SO_NHOMTIET_TRONG_NGAY
        {
            set { _SO_NHOMTIET_TRONG_NGAY = value; }
            get { return _SO_NHOMTIET_TRONG_NGAY; }
        }
        public int SUDUNG_BAOBAN_TRONG_XEPLICH
        {
            set { _SUDUNG_BAOBAN_TRONG_XEPLICH = value; }
            get { return _SUDUNG_BAOBAN_TRONG_XEPLICH; }
        }
        public string SO_TIET_CAC_NHOM
        {
            set { _SO_TIET_CAC_NHOM = value; }
            get { return _SO_TIET_CAC_NHOM; }
        }
        public int SO_NHOMTIET_CA
        {
            get { return _SO_NHOMTIET_TRONG_BUOI * Math.Abs(THU_KET_THUC - THU_BAT_DAU); }
        }
        public int THUCHANH_TU_THU
        {
            set { _THUCHANH_TU_THU = value; }
            get { return _THUCHANH_TU_THU; }
        }
        public int THUCHANH_DEN_THU
        {
            set { _THUCHANH_DEN_THU = value; }
            get { return _THUCHANH_DEN_THU; }
        }
        public int SO_TIET_THUCHANH_TRONGTUAN
        {
            set { _SO_TIET_THUCHANH_TRONGTUAN = value; }
            get { return _SO_TIET_THUCHANH_TRONGTUAN; }
        }
    }
}
