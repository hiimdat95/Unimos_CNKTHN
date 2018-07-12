using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class SV_SinhVien_KyLuatInfo
    {

        private int mSV_SinhVien_KyLuatID;
        private int mIDSV_SinhVien;
        private int mIDSV_QuyetDinhKyLuat;
        private bool mXoaKyLuat;
        private DateTime mNgayXoaKyLuat;
        private string mLyDoXoaKyLuat;

        public string strSV_SinhVien_KyLuatID = "SV_SinhVien_KyLuatID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strIDSV_QuyetDinhKyLuat = "IDSV_QuyetDinhKyLuat";
        public string strXoaKyLuat = "XoaKyLuat";
        public string strNgayXoaKyLuat = "NgayXoaKyLuat";
        public string strLyDoXoaKyLuat = "LyDoXoaKyLuat";

        public SV_SinhVien_KyLuatInfo()
        { }

        public int SV_SinhVien_KyLuatID{
        	set{ mSV_SinhVien_KyLuatID = value;}
        	get{ return mSV_SinhVien_KyLuatID;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
        public int IDSV_QuyetDinhKyLuat{
        	set{ mIDSV_QuyetDinhKyLuat = value;}
        	get{ return mIDSV_QuyetDinhKyLuat;}
        }
        public bool XoaKyLuat{
        	set{ mXoaKyLuat = value;}
        	get{ return mXoaKyLuat;}
        }
        public DateTime NgayXoaKyLuat{
        	set{ mNgayXoaKyLuat = value;}
        	get{ return mNgayXoaKyLuat;}
        }
        public string LyDoXoaKyLuat{
        	set{ mLyDoXoaKyLuat = value;}
        	get{ return mLyDoXoaKyLuat;}
        }
    }
}
