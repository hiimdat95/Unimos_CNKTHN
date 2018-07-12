using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_LopInfo
    {

        private int mDM_LopID;
        private string mTenLop;
        private int mIDDM_He;
        private int mIDDM_TrinhDo;
        private int mIDDM_Khoa;
        private int mIDDM_Nganh;
        private int mIDDM_ChuyenNganh;
        private string mNienKhoa;
        private int mIDDM_KhoaHoc;
        private int mIDDM_DiaDiem;
        private int mSoSinhVien;
        private DateTime mNgayVao;
        private DateTime mNgayRa;
        private bool mDaRaTruong;
        private int mIDDM_TruongLienKet;
        private bool mXepThoiKhoaBieu;
        private int mKieuLopTachGop;

        public string strDM_LopID = "DM_LopID";
        public string strTenLop = "TenLop";
        public string strIDDM_He = "IDDM_He";
        public string strIDDM_TrinhDo = "IDDM_TrinhDo";
        public string strIDDM_Khoa = "IDDM_Khoa";
        public string strIDDM_Nganh = "IDDM_Nganh";
        public string strIDDM_ChuyenNganh = "IDDM_ChuyenNganh";
        public string strNienKhoa = "NienKhoa";
        public string strIDDM_KhoaHoc = "IDDM_KhoaHoc";
        public string strIDDM_DiaDiem = "IDDM_DiaDiem";
        public string strSoSinhVien = "SoSinhVien";
        public string strNgayVao = "NgayVao";
        public string strNgayRa = "NgayRa";
        public string strDaRaTruong = "DaRaTruong";
        public string strIDDM_TruongLienKet = "IDDM_TruongLienKet";
        public string strXepThoiKhoaBieu = "XepThoiKhoaBieu";
        public string strKieuLopTachGop = "KieuLopTachGop";

        public DM_LopInfo()
        { }

        public int DM_LopID{
        	set{ mDM_LopID = value;}
        	get{ return mDM_LopID;}
        }
        public string TenLop{
        	set{ mTenLop = value;}
        	get{ return mTenLop;}
        }
        public int IDDM_He{
        	set{ mIDDM_He = value;}
        	get{ return mIDDM_He;}
        }
        public int IDDM_TrinhDo{
        	set{ mIDDM_TrinhDo = value;}
        	get{ return mIDDM_TrinhDo;}
        }
        public int IDDM_Khoa{
        	set{ mIDDM_Khoa = value;}
        	get{ return mIDDM_Khoa;}
        }
        public int IDDM_Nganh{
        	set{ mIDDM_Nganh = value;}
        	get{ return mIDDM_Nganh;}
        }
        public int IDDM_ChuyenNganh{
        	set{ mIDDM_ChuyenNganh = value;}
        	get{ return mIDDM_ChuyenNganh;}
        }
        public string NienKhoa{
        	set{ mNienKhoa = value;}
        	get{ return mNienKhoa;}
        }
        public int IDDM_KhoaHoc{
        	set{ mIDDM_KhoaHoc = value;}
        	get{ return mIDDM_KhoaHoc;}
        }
        public int IDDM_DiaDiem 
        { 
            get{return mIDDM_DiaDiem;} 
            set{mIDDM_DiaDiem = value;} 
        }
        public int SoSinhVien{
        	set{ mSoSinhVien = value;}
        	get{ return mSoSinhVien;}
        }
        public DateTime NgayVao{
        	set{ mNgayVao = value;}
        	get{ return mNgayVao;}
        }
        public DateTime NgayRa{
        	set{ mNgayRa = value;}
        	get{ return mNgayRa;}
        }
        public bool DaRaTruong{
        	set{ mDaRaTruong = value;}
        	get{ return mDaRaTruong;}
        }
        public int IDDM_TruongLienKet{
        	set{ mIDDM_TruongLienKet = value;}
        	get{ return mIDDM_TruongLienKet;}
        }
        public bool XepThoiKhoaBieu{
        	set{ mXepThoiKhoaBieu = value;}
        	get{ return mXepThoiKhoaBieu;}
        }
        public int KieuLopTachGop{
        	set{ mKieuLopTachGop = value;}
        	get{ return mKieuLopTachGop;}
        }
    }

    public class Lop
    {
        private int mIDDM_Lop;
        private int mIDXL_LopTachGop;
        private int mIDDM_Khoa;
        private string mTenLop;
        private int mSoSinhVien;
        private CA_HOC mCaHoc;
        private int mIDDM_ToaNha;
        private int mIDDM_PhongHoc;

        private TKBInfo mTKB;

        public Lop(int IDDM_Lop, int IDXL_LopTachGop, int IDDM_Khoa, string TenLop, int SoSinhVien, CA_HOC CaHoc, int IDDM_ToaNha, int IDDM_PhongHoc, HT_ThamSoXepLichInfo pThamSoTKB)
        {
            mTKB = new TKBInfo(pThamSoTKB);
            mIDDM_Lop = IDDM_Lop;
            mIDXL_LopTachGop = IDXL_LopTachGop;
            mIDDM_Khoa = IDDM_Khoa;
            mTenLop = TenLop;
            mSoSinhVien = SoSinhVien;
            mCaHoc = CaHoc;
            mIDDM_ToaNha = IDDM_ToaNha;
            mIDDM_PhongHoc = IDDM_PhongHoc;
        }

        public int IDDM_Lop
        {
            set { mIDDM_Lop = value; }
            get { return mIDDM_Lop; }
        }
        public int IDXL_LopTachGop
        {
            set { mIDXL_LopTachGop = value; }
            get { return mIDXL_LopTachGop; }
        }
        public int IDDM_Khoa
        {
            set { mIDDM_Khoa = value; }
            get { return mIDDM_Khoa; }
        }
        public string TenLop
        {
            set { mTenLop = value; }
            get { return mTenLop; }
        }
        public int SoSinhVien
        {
            set { mSoSinhVien = value; }
            get { return mSoSinhVien; }
        }
        public CA_HOC CaHoc
        {
            set { mCaHoc = value; }
            get { return mCaHoc; }
        }
        public int IDDM_ToaNha
        {
            set { mIDDM_ToaNha = value; }
            get { return mIDDM_ToaNha; }
        }
        public int IDDM_PhongHoc
        {
            set { mIDDM_PhongHoc = value; }
            get { return mIDDM_PhongHoc; }
        }

        public TKBInfo TKB
        {
            set { mTKB = value; }
            get { return mTKB; }
        }
    }
}
