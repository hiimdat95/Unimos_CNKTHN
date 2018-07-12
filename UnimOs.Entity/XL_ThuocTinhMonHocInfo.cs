using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class XL_ThuocTinhMonHocInfo
    {

        private int mXL_ThuocTinhMonHocID;
        private int mIDDM_MonHoc;
        private bool mXepCachNgay;
        private string mTietXepLichSang;
        private string mTietXepLichChieu;
        private string mTietXepLichToi;
        private bool mHocPhongChuyenMon;
        private bool mHocCachTietTrongBuoi;
        private int mSoTietToiDaTrongNhomTiet;

        private string[] mstrTietXepLichSang;
        private string[] mstrTietXepLichChieu;
        private string[] mstrTietXepLichToi;
        private int[] mArrPhongChuyenMon;

        public string strXL_ThuocTinhMonHocID = "XL_ThuocTinhMonHocID";
        public string strIDDM_MonHoc = "IDDM_MonHoc";
        public string strXepCachNgay = "XepCachNgay";
        public string strTietXepLichSang = "TietXepLichSang";
        public string strTietXepLichChieu = "TietXepLichChieu";
        public string strTietXepLichToi = "TietXepLichToi";
        public string strHocPhongChuyenMon = "HocPhongChuyenMon";
        public string strHocCachTietTrongBuoi = "HocCachTietTrongBuoi";
        public string strSoTietToiDaTrongNhomTiet = "SoTietToiDaTrongNhomTiet";

        public XL_ThuocTinhMonHocInfo()
        { }

        public XL_ThuocTinhMonHocInfo(bool TKB)
        {
            mXL_ThuocTinhMonHocID = -1;
            mIDDM_MonHoc = -1;
            mXepCachNgay = false;
            mTietXepLichSang = "";
            mTietXepLichChieu = "";
            mTietXepLichToi = "";
            mSoTietToiDaTrongNhomTiet = -1;
            mHocPhongChuyenMon = false;
            mHocCachTietTrongBuoi = false;
        }

        public XL_ThuocTinhMonHocInfo(int ThuocTinhMonKhoiID, int IDDMMonHoc, bool XepCachNgay,
            string[] arrTietXepLichSang, string[] arrTietXepLichChieu, string[] arrTietXepLichToi, int SoTietToiDaTrongNhomTiet,
            bool HocPhongChuyenMon, int[] arrPhongChuyenMon, bool HocCachTietTrongBuoi)
        {
            mXL_ThuocTinhMonHocID = ThuocTinhMonKhoiID;
            mIDDM_MonHoc = IDDMMonHoc;
            mXepCachNgay = XepCachNgay;
            mstrTietXepLichSang = arrTietXepLichSang;
            mstrTietXepLichChieu = arrTietXepLichChieu;
            mstrTietXepLichToi = arrTietXepLichToi;
            mSoTietToiDaTrongNhomTiet = SoTietToiDaTrongNhomTiet;
            mHocPhongChuyenMon = HocPhongChuyenMon;
            mArrPhongChuyenMon = arrPhongChuyenMon;
            mHocCachTietTrongBuoi = HocCachTietTrongBuoi;
        }

        public int XL_ThuocTinhMonHocID{
        	set{ mXL_ThuocTinhMonHocID = value;}
        	get{ return mXL_ThuocTinhMonHocID;}
        }
        public int IDDM_MonHoc{
        	set{ mIDDM_MonHoc = value;}
        	get{ return mIDDM_MonHoc;}
        }
        public bool XepCachNgay{
        	set{ mXepCachNgay = value;}
        	get{ return mXepCachNgay;}
        }
        public string TietXepLichSang{
        	set{ mTietXepLichSang = value;}
        	get{ return mTietXepLichSang;}
        }
        public string TietXepLichChieu{
        	set{ mTietXepLichChieu = value;}
        	get{ return mTietXepLichChieu;}
        }
        public string TietXepLichToi{
        	set{ mTietXepLichToi = value;}
        	get{ return mTietXepLichToi;}
        }
        public bool HocPhongChuyenMon{
        	set{ mHocPhongChuyenMon = value;}
        	get{ return mHocPhongChuyenMon;}
        }
        public bool HocCachTietTrongBuoi{
        	set{ mHocCachTietTrongBuoi = value;}
        	get{ return mHocCachTietTrongBuoi;}
        }
        public string[] arrTietXepLichSang
        {
            set { mstrTietXepLichSang = value; }
            get { return mstrTietXepLichSang; }
        }
        public string[] arrTietXepLichChieu
        {
            set { mstrTietXepLichChieu = value; }
            get { return mstrTietXepLichChieu; }
        }
        public string[] arrTietXepLichToi
        {
            set { mstrTietXepLichToi = value; }
            get { return mstrTietXepLichToi; }
        }
        public int[] arrPhongChuyenMon
        {
            set { mArrPhongChuyenMon = value; }
            get { return mArrPhongChuyenMon; }
        }
        public int SoTietToiDaTrongNhomTiet{
        	set{ mSoTietToiDaTrongNhomTiet = value;}
        	get{ return mSoTietToiDaTrongNhomTiet;}
        }
    }
}
