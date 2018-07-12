using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_DanhSachKhongThiInfo
    {

        private int mKQHT_DanhSachKhongThiID;
        private int mIDSV_SinhVien;
        private int mIDDM_MonHoc;
        private int mIDDM_NamHoc;
        private int mHocKy;
        private int mLanThi;
        private int? mSoTietHocLai;
        private string mLyDo;

        public string strKQHT_DanhSachKhongThiID = "KQHT_DanhSachKhongThiID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strIDDM_MonHoc = "IDDM_MonHoc";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strHocKy = "HocKy";
        public string strLanThi = "LanThi";
        public string strSoTietHocLai = "SoTietHocLai";
        public string strLyDo = "LyDo";

        public KQHT_DanhSachKhongThiInfo()
        { }

        public int KQHT_DanhSachKhongThiID{
        	set{ mKQHT_DanhSachKhongThiID = value;}
        	get{ return mKQHT_DanhSachKhongThiID;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
        public int IDDM_MonHoc{
        	set{ mIDDM_MonHoc = value;}
        	get{ return mIDDM_MonHoc;}
        }
        public int IDDM_NamHoc{
        	set{ mIDDM_NamHoc = value;}
        	get{ return mIDDM_NamHoc;}
        }
        public int HocKy{
        	set{ mHocKy = value;}
        	get{ return mHocKy;}
        }
        public int LanThi
        {
            set { mLanThi = value; }
            get { return mLanThi; }
        }
        public int? SoTietHocLai
        {
            set { mSoTietHocLai = value; }
            get { return mSoTietHocLai; }
        }
        public string LyDo{
        	set{ mLyDo = value;}
        	get{ return mLyDo;}
        }
    }
}
