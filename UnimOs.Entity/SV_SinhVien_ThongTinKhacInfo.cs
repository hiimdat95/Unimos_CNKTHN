using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class SV_SinhVien_ThongTinKhacInfo
    {

        private int mSV_SinhVien_ThongTinKhacID;
        private int mIDSV_SinhVien;
        private string mKhenThuongKyLuat;
        private string mQuaTrinhHocTapCongTac;

        public string strSV_SinhVien_ThongTinKhacID = "SV_SinhVien_ThongTinKhacID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strKhenThuongKyLuat = "KhenThuongKyLuat";
        public string strQuaTrinhHocTapCongTac = "QuaTrinhHocTapCongTac";

        public SV_SinhVien_ThongTinKhacInfo()
        { }

        public int SV_SinhVien_ThongTinKhacID{
        	set{ mSV_SinhVien_ThongTinKhacID = value;}
        	get{ return mSV_SinhVien_ThongTinKhacID;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
        public string KhenThuongKyLuat{
        	set{ mKhenThuongKyLuat = value;}
        	get{ return mKhenThuongKyLuat;}
        }
        public string QuaTrinhHocTapCongTac{
        	set{ mQuaTrinhHocTapCongTac = value;}
        	get{ return mQuaTrinhHocTapCongTac;}
        }
    }
}
