using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class SV_SinhVien_KhenThuongInfo
    {

        private int mSV_SinhVien_KhenThuongID;
        private int mIDSV_SinhVien;
        private int mIDSV_QuyetDinhKhenThuong;

        public string strSV_SinhVien_KhenThuongID = "SV_SinhVien_KhenThuongID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strIDSV_QuyetDinhKhenThuong = "IDSV_QuyetDinhKhenThuong";

        public SV_SinhVien_KhenThuongInfo()
        { }

        public int SV_SinhVien_KhenThuongID{
        	set{ mSV_SinhVien_KhenThuongID = value;}
        	get{ return mSV_SinhVien_KhenThuongID;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
        public int IDSV_QuyetDinhKhenThuong{
        	set{ mIDSV_QuyetDinhKhenThuong = value;}
        	get{ return mIDSV_QuyetDinhKhenThuong;}
        }
    }
}
