using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class NS_GiaoVienInfo
    {

        private int mNS_GiaoVienID;
        private string mMaGiaoVien;
        private string mHoTen;
        private string mTen;
        private string mTenVietTat;
        private DateTime mNgaySinh;
        private int mIDNS_DonVi;
        private byte[] mAnh;
        private string mDienThoai;
        private int mIDDM_TinhHuyenXaQueQuan;
        private int mIDDM_TinhHuyenXaNoiSinh;
        private string mDiaChiThuongTru;
        private int mIDDM_TinhHuyenXaThuongTru;
        private string mDiaChiNoiO;
        private int mIDDM_TinhHuyenXaNoiO;
        private int mIDDM_DanToc;
        private int mIDDM_TonGiao;
        private bool mGioiTinh;
        private string mSoCMND;
        private DateTime mNgayCap;
        private string mEmail;
        private bool mGiangDay;
        private int mTrangThaiGiaoVien;
        private string mUsername;
        private string mPassword;
        private bool mIsDuocTruyCap;
        private int mIDDM_Khoa_GiaoVu;

        public string strNS_GiaoVienID = "NS_GiaoVienID";
        public string strMaGiaoVien = "MaGiaoVien";
        public string strHoTen = "HoTen";
        public string strTen = "Ten";
        public string strTenVietTat = "TenVietTat";
        public string strNgaySinh = "NgaySinh";
        public string strIDNS_DonVi = "IDNS_DonVi";
        public string strAnh = "Anh";
        public string strDienThoai = "DienThoai";
        public string strIDDM_TinhHuyenXaQueQuan = "IDDM_TinhHuyenXaQueQuan";
        public string strIDDM_TinhHuyenXaNoiSinh = "IDDM_TinhHuyenXaNoiSinh";
        public string strDiaChiThuongTru = "DiaChiThuongTru";
        public string strIDDM_TinhHuyenXaThuongTru = "IDDM_TinhHuyenXaThuongTru";
        public string strDiaChiNoiO = "DiaChiNoiO";
        public string strIDDM_TinhHuyenXaNoiO = "IDDM_TinhHuyenXaNoiO";
        public string strIDDM_DanToc = "IDDM_DanToc";
        public string strIDDM_TonGiao = "IDDM_TonGiao";
        public string strGioiTinh = "GioiTinh";
        public string strSoCMND = "SoCMND";
        public string strNgayCap = "NgayCap";
        public string strEmail = "Email";
        public string strGiangDay = "GiangDay";
        public string strTrangThaiGiaoVien = "TrangThaiGiaoVien";
        public string strUsername = "Username";
        public string strPassword = "Password";
        public string strIsDuocTruyCap = "IsDuocTruyCap";
        public string strIDDM_Khoa_GiaoVu = "IDDM_Khoa_GiaoVu";

        public NS_GiaoVienInfo()
        { }

        public int NS_GiaoVienID
        {
            set { mNS_GiaoVienID = value; }
            get { return mNS_GiaoVienID; }
        }
        public string MaGiaoVien
        {
            set { mMaGiaoVien = value; }
            get { return mMaGiaoVien; }
        }
        public string HoTen
        {
            set { mHoTen = value; }
            get { return mHoTen; }
        }
        public string Ten
        {
            set { mTen = value; }
            get { return mTen; }
        }
        public string TenVietTat
        {
            set { mTenVietTat = value; }
            get { return mTenVietTat; }
        }
        public DateTime NgaySinh
        {
            set { mNgaySinh = value; }
            get { return mNgaySinh; }
        }
        public int IDNS_DonVi
        {
            set { mIDNS_DonVi = value; }
            get { return mIDNS_DonVi; }
        }
        public byte[] Anh
        {
            set { mAnh = value; }
            get { return mAnh; }
        }
        public string DienThoai
        {
            set { mDienThoai = value; }
            get { return mDienThoai; }
        }
        public int IDDM_TinhHuyenXaQueQuan
        {
            set { mIDDM_TinhHuyenXaQueQuan = value; }
            get { return mIDDM_TinhHuyenXaQueQuan; }
        }
        public int IDDM_TinhHuyenXaNoiSinh
        {
            set { mIDDM_TinhHuyenXaNoiSinh = value; }
            get { return mIDDM_TinhHuyenXaNoiSinh; }
        }
        public string DiaChiThuongTru
        {
            set { mDiaChiThuongTru = value; }
            get { return mDiaChiThuongTru; }
        }
        public int IDDM_TinhHuyenXaThuongTru
        {
            set { mIDDM_TinhHuyenXaThuongTru = value; }
            get { return mIDDM_TinhHuyenXaThuongTru; }
        }
        public string DiaChiNoiO
        {
            set { mDiaChiNoiO = value; }
            get { return mDiaChiNoiO; }
        }
        public int IDDM_TinhHuyenXaNoiO
        {
            set { mIDDM_TinhHuyenXaNoiO = value; }
            get { return mIDDM_TinhHuyenXaNoiO; }
        }
        public int IDDM_DanToc
        {
            set { mIDDM_DanToc = value; }
            get { return mIDDM_DanToc; }
        }
        public int IDDM_TonGiao
        {
            set { mIDDM_TonGiao = value; }
            get { return mIDDM_TonGiao; }
        }
        public bool GioiTinh
        {
            set { mGioiTinh = value; }
            get { return mGioiTinh; }
        }
        public string SoCMND
        {
            set { mSoCMND = value; }
            get { return mSoCMND; }
        }
        public DateTime NgayCap
        {
            set { mNgayCap = value; }
            get { return mNgayCap; }
        }
        public string Email
        {
            set { mEmail = value; }
            get { return mEmail; }
        }
        public bool GiangDay
        {
            set { mGiangDay = value; }
            get { return mGiangDay; }
        }
        public int TrangThaiGiaoVien
        {
            set { mTrangThaiGiaoVien = value; }
            get { return mTrangThaiGiaoVien; }
        }
        public string Username
        {
            set { mUsername = value; }
            get { return mUsername; }
        }
        public string Password
        {
            set { mPassword = value; }
            get { return mPassword; }
        }
        public bool IsDuocTruyCap
        {
            set { mIsDuocTruyCap = value; }
            get { return mIsDuocTruyCap; }
        }
        public int IDDM_Khoa_GiaoVu
        {
            set { mIDDM_Khoa_GiaoVu = value; }
            get { return mIDDM_Khoa_GiaoVu; }
        }
    }

    public class GiaoVien
    {
        private int mNS_GiaoVienID;
        private string mMaGiaoVien;
        private string mHoTen;
        private string mTenVietTat;
        private TKBInfo mTKB;

        public GiaoVien(int NS_GiaoVienID, string MaGiaoVien, string HoTen, string TenVietTat, HT_ThamSoXepLichInfo pThamSoTKB)
        {
            mTKB = new TKBInfo(pThamSoTKB);
            mNS_GiaoVienID = NS_GiaoVienID;
            mMaGiaoVien = MaGiaoVien;
            mHoTen = HoTen;
            mTenVietTat = TenVietTat;
        }

        public int NS_GiaoVienID
        {
            set { mNS_GiaoVienID = value; }
            get { return mNS_GiaoVienID; }
        }
        public string MaGiaoVien
        {
            set { mMaGiaoVien = value; }
            get { return mMaGiaoVien; }
        }
        public string HoTen
        {
            set { mHoTen = value; }
            get { return mHoTen; }
        }
        public string TenVietTat
        {
            set { mTenVietTat = value; }
            get { return mTenVietTat; }
        }
        public TKBInfo TKB
        {
            get { return mTKB; }
            set { mTKB = value; }
        }
    }
}
