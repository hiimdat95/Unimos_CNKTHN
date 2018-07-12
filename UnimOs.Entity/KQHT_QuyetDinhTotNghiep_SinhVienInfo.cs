using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_QuyetDinhTotNghiep_SinhVienInfo
    {

        private long mKQHT_QuyetDinhTotNghiep_SinhVienID;
        private int mIDKQHT_QuyetDinhTotNghiep;
        private int mIDSV_SinhVien;
        private string mSoBang;
        private double? mDiemMonTotNghiep1;
        private double? mDiemMonTotNghiep2;
        private double? mDiemMonTotNghiep3;
        private double? mDiemMonTotNghiep4;
        private double? mDiemTrungBinhChungToanKhoa;
        private double? mDiemTrungBinhChungTotNghiep;
        private double? mDiemXepLoaiTotNghiep;
        private int? mIDKQHT_XepLoaiTotNghiep;

        public string strKQHT_QuyetDinhTotNghiep_SinhVienID = "KQHT_QuyetDinhTotNghiep_SinhVienID";
        public string strIDKQHT_QuyetDinhTotNghiep = "IDKQHT_QuyetDinhTotNghiep";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strSoBang = "SoBang";
        public string strDiemMonTotNghiep1 = "DiemMonTotNghiep1";
        public string strDiemMonTotNghiep2 = "DiemMonTotNghiep2";
        public string strDiemMonTotNghiep3 = "DiemMonTotNghiep3";
        public string strDiemMonTotNghiep4 = "DiemMonTotNghiep4";
        public string strDiemTrungBinhChungToanKhoa = "DiemTrungBinhChungToanKhoa";
        public string strDiemTrungBinhChungTotNghiep = "DiemTrungBinhChungTotNghiep";
        public string strDiemXepLoaiTotNghiep = "DiemXepLoaiTotNghiep";
        public string strIDKQHT_XepLoaiTotNghiep = "IDKQHT_XepLoaiTotNghiep";

        public KQHT_QuyetDinhTotNghiep_SinhVienInfo()
        { }

        public long KQHT_QuyetDinhTotNghiep_SinhVienID{
        	set{ mKQHT_QuyetDinhTotNghiep_SinhVienID = value;}
        	get{ return mKQHT_QuyetDinhTotNghiep_SinhVienID;}
        }
        public int IDKQHT_QuyetDinhTotNghiep{
        	set{ mIDKQHT_QuyetDinhTotNghiep = value;}
        	get{ return mIDKQHT_QuyetDinhTotNghiep;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
        public string SoBang
        {
            set { mSoBang = value; }
            get { return mSoBang; }
        }
        public double? DiemMonTotNghiep1{
        	set{ mDiemMonTotNghiep1 = value;}
        	get{ return mDiemMonTotNghiep1;}
        }
        public double? DiemMonTotNghiep2{
        	set{ mDiemMonTotNghiep2 = value;}
        	get{ return mDiemMonTotNghiep2;}
        }
        public double? DiemMonTotNghiep3{
        	set{ mDiemMonTotNghiep3 = value;}
        	get{ return mDiemMonTotNghiep3;}
        }
        public double? DiemMonTotNghiep4{
        	set{ mDiemMonTotNghiep4 = value;}
        	get{ return mDiemMonTotNghiep4;}
        }
        public double? DiemTrungBinhChungToanKhoa{
        	set{ mDiemTrungBinhChungToanKhoa = value;}
        	get{ return mDiemTrungBinhChungToanKhoa;}
        }
        public double? DiemTrungBinhChungTotNghiep{
        	set{ mDiemTrungBinhChungTotNghiep = value;}
        	get{ return mDiemTrungBinhChungTotNghiep;}
        }
        public double? DiemXepLoaiTotNghiep
        {
            set { mDiemXepLoaiTotNghiep = value; }
            get { return mDiemXepLoaiTotNghiep; }
        }
        public int? IDKQHT_XepLoaiTotNghiep{
        	set{ mIDKQHT_XepLoaiTotNghiep = value;}
        	get{ return mIDKQHT_XepLoaiTotNghiep;}
        }
    }
}
