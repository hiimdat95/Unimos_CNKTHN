using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class XL_SuKienTKBInfo
    {
        private long mXL_SuKienTKBID;
        private int mIdx;
        private long mIDXL_Tuan;
        private int mIDDM_Lop;
        private int mIDXL_LopTachGop;
        private int mIdxLop;
        private string mTenLop;
        private long mIDXL_MonHocTrongKy;
        private int mIDDM_MonHoc;
        //private int mIndexThuocTinhMon;
        private SU_DUNG_PHONG mSuDungPhong;
        private string mTenMon;
        private string mKyHieu;
        private int mIDDM_PhongHoc;
        private int mIdxPhong;
        private string mTenPhong;
        private int mIDNS_GiaoVien;
        private int mIdxGiaoVien;
        private string mTenGiaoVien;
        private string mTenVietTat;
        private CA_HOC mCaHoc;
        private int mThu;
        private int mTietDau;
        private int mSoTiet;
        private LOAI_TIET mLoaiTiet;
        private bool mThieuDuLieu;
        private bool mChanged;
        private bool mDaXepLich;
        private bool mLocked;

        public string strXL_SuKienTKBID = "XL_SuKienTKBID";
        public string strIDXL_Tuan = "IDXL_Tuan";
        public string strIDDM_Lop = "IDDM_Lop";
        public string strIDXL_LopTachGop = "IDXL_LopTachGop";
        public string strIDXL_MonHocTrongKy = "IDXL_MonHocTrongKy";
        public string strIDDM_MonHoc = "IDDM_MonHoc";
        public string strIDDM_PhongHoc = "IDDM_PhongHoc";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strCaHoc = "CaHoc";
        public string strThu = "Thu";
        public string strTietDau = "TietDau";
        public string strSoTiet = "SoTiet";
        public string strLoaiTiet = "LoaiTiet";
        public string strDaXepLich = "DaXepLich";
        public string strLocked = "Locked";

        public XL_SuKienTKBInfo()
        { }

        public XL_SuKienTKBInfo(bool TKB)
        {
            mXL_SuKienTKBID = -1;
            mIdx = -1;
            mIDXL_Tuan = -1;
            mIDDM_Lop = -1;
            mIDXL_LopTachGop = -1;
            mIdxLop = -1;
            mTenLop = "";
            mIDXL_MonHocTrongKy = -1;
            mIDDM_MonHoc = -1;
            //mIndexThuocTinhMon = -1;
            mSuDungPhong = SU_DUNG_PHONG.BAT_KY;
            mTenMon = "";
            mKyHieu = "";
            mIDDM_PhongHoc = -1;
            mIdxPhong = -1;
            mTenPhong = "";
            mIDNS_GiaoVien = -1;
            mIdxGiaoVien = -1;
            mTenGiaoVien = "";
            mTenVietTat = "";
            mCaHoc = CA_HOC.KHONG_XAC_DINH;
            mThu = -1;
            mTietDau = -1;
            mSoTiet = 0;
            mLoaiTiet = LOAI_TIET.KHONG_XAC_DINH;
            mThieuDuLieu = false;
            mChanged = false;
            mDaXepLich = false;
            mLocked = false;
        }

        public XL_SuKienTKBInfo(int ID, int Idx, int IDTuan, int IDDM_Lop, int IDXL_LopTachGop, int IdxLop, string TenLop,
            int IDGiaoVien_MonHoc_Khoi_Lop, SU_DUNG_PHONG SuDungPhong, string TenMon, string KyHieu, int IDPhong, 
            int IdxPhong, string TenPhong, int IDGiaoVien, int IdxGiaoVien, string TenGiaoVien, string TenVietTat, 
            CA_HOC CaHoc, int Thu, int Tiet, int SoTiet, LOAI_TIET LoaiTiet, bool DaXepLich, bool Locked)
        {
            mXL_SuKienTKBID = ID;
            mIdx = Idx;
            mIDXL_Tuan = IDTuan;
            mIDDM_Lop = IDDM_Lop;
            mIDXL_LopTachGop = IDXL_LopTachGop;
            mIdxLop = IdxLop;
            mTenLop = TenLop;
            mIDDM_MonHoc = -1;
            //mIndexThuocTinhMon = IndexThuocTinhMon;
            mSuDungPhong = SuDungPhong;
            mTenMon = TenMon;
            mKyHieu = KyHieu;
            mIDDM_PhongHoc = IDPhong;
            mIdxPhong = IdxPhong;
            mTenPhong = TenPhong;
            mIDNS_GiaoVien = IDGiaoVien;
            mIdxGiaoVien = IdxGiaoVien;
            mTenGiaoVien = TenGiaoVien;
            mTenVietTat = TenVietTat;
            mCaHoc = CaHoc;
            mThu = Thu;
            mTietDau = Tiet;
            mSoTiet = SoTiet;
            mLoaiTiet = LoaiTiet;
            mThieuDuLieu = false;
            mChanged = false;
            mDaXepLich = DaXepLich;
            mLocked = Locked;
        }

        public long XL_SuKienTKBID{
        	set{ mXL_SuKienTKBID = value;}
        	get{ return mXL_SuKienTKBID;}
        }
        public int Idx
        {
            set { mIdx = value; }
            get { return mIdx; }
        }
        public long IDXL_Tuan{
        	set{ mIDXL_Tuan = value;}
        	get{ return mIDXL_Tuan;}
        }
        public int IDDM_Lop{
        	set{ mIDDM_Lop = value;}
        	get{ return mIDDM_Lop;}
        }
        public int IDXL_LopTachGop
        {
            set { mIDXL_LopTachGop = value; }
            get { return mIDXL_LopTachGop; }
        }
        public int IdxLop
        {
            set { mIdxLop = value; }
            get { return mIdxLop; }
        }
        public string TenLop
        {
            set { mTenLop = value; }
            get { return mTenLop; }
        }
        public long IDXL_MonHocTrongKy
        {
            set { mIDXL_MonHocTrongKy = value; }
            get { return mIDXL_MonHocTrongKy; }
        }
        public int IDDM_MonHoc{
        	set{ mIDDM_MonHoc = value;}
        	get{ return mIDDM_MonHoc;}
        }
        //public int IndexThuocTinhMon
        //{
        //    set { mIndexThuocTinhMon = value; }
        //    get { return mIndexThuocTinhMon; }
        //}
        public SU_DUNG_PHONG SuDungPhong
        {
            set { mSuDungPhong = value; }
            get { return mSuDungPhong; }
        }
        public string TenMon
        {
            set { mTenMon = value; }
            get { return mTenMon; }
        }
        public string KyHieu
        {
            set { mKyHieu = value; }
            get { return mKyHieu; }
        }
        public int IDDM_PhongHoc{
        	set{ mIDDM_PhongHoc = value;}
        	get{ return mIDDM_PhongHoc;}
        }
        public int IdxPhong
        {
            set { mIdxPhong = value; }
            get { return mIdxPhong; }
        }
        public string TenPhong
        {
            set { mTenPhong = value; }
            get { return mTenPhong; }
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
        }
        public int IdxGiaoVien
        {
            set { mIdxGiaoVien = value; }
            get { return mIdxGiaoVien; }
        }
        public string TenGiaoVien
        {
            set { mTenGiaoVien = value; }
            get { return mTenGiaoVien; }
        }
        public string TenVietTat
        {
            set { mTenVietTat = value; }
            get { return mTenVietTat; }
        }
        public CA_HOC CaHoc{
        	set{ mCaHoc = value;}
        	get{ return mCaHoc;}
        }
        public int Thu{
        	set{ mThu = value;}
        	get{ return mThu;}
        }
        public int TietDau{
        	set{ mTietDau = value;}
        	get{ return mTietDau;}
        }
        public int SoTiet{
        	set{ mSoTiet = value;}
        	get{ return mSoTiet;}
        }
        public LOAI_TIET LoaiTiet{
        	set{ mLoaiTiet = value;}
        	get{ return mLoaiTiet;}
        }
        public bool ThieuDuLieu
        {
            set { mThieuDuLieu = value; }
            get { return mThieuDuLieu; }
        }
        public bool Changed
        {
            set { mChanged = value; }
            get { return mChanged; }
        }
        public bool DaXepLich{
        	set{ mDaXepLich = value;}
        	get{ return mDaXepLich;}
        }
        public bool Locked{
        	set{ mLocked = value;}
        	get{ return mLocked;}
        }

        public XL_SuKienTKBInfo Clone()
        {
            XL_SuKienTKBInfo sk = new XL_SuKienTKBInfo(true);
            sk.XL_SuKienTKBID = mXL_SuKienTKBID;
            sk.Idx = mIdx;
            sk.IDXL_Tuan = mIDXL_Tuan;
            sk.IDDM_Lop = mIDDM_Lop;
            sk.IDXL_LopTachGop = mIDXL_LopTachGop;
            sk.IdxLop = mIdxLop;
            sk.TenLop = mTenLop;
            sk.IDXL_MonHocTrongKy = mIDXL_MonHocTrongKy;
            sk.IDDM_MonHoc = mIDDM_MonHoc;
            sk.SuDungPhong = mSuDungPhong;
            sk.TenMon = mTenMon;
            sk.KyHieu = mKyHieu;
            sk.IDDM_PhongHoc = mIDDM_PhongHoc;
            sk.mIdxPhong = mIdxPhong;
            sk.TenPhong = mTenPhong;
            sk.IDNS_GiaoVien = mIDNS_GiaoVien;
            sk.IdxGiaoVien = mIdxGiaoVien;
            sk.TenGiaoVien = mTenGiaoVien;
            sk.TenVietTat = mTenVietTat;
            sk.CaHoc = mCaHoc;
            sk.Thu = mThu;
            sk.TietDau = mTietDau;
            sk.SoTiet = mSoTiet;
            sk.LoaiTiet = mLoaiTiet;
            sk.ThieuDuLieu = mThieuDuLieu;
            sk.Changed = mChanged;
            sk.DaXepLich = mDaXepLich;
            sk.Locked = mLocked;
            return sk;
        }
    }
}
