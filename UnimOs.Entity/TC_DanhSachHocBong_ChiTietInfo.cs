using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class TC_DanhSachHocBong_ChiTietInfo
    {

        private int mTC_DanhSachHocBong_ChiTietID;
        private int mIDTC_DanhSachHocBong;
        private int mThang;
        private int mSoNgayThieuCong;
        private double mSoTienThieuCong;
        private double mSoTien;
        private string mGhiChu;

        public string strTC_DanhSachHocBong_ChiTietID = "TC_DanhSachHocBong_ChiTietID";
        public string strIDTC_DanhSachHocBong = "IDTC_DanhSachHocBong";
        public string strThang = "Thang";
        public string strSoNgayThieuCong = "SoNgayThieuCong";
        public string strSoTienThieuCong = "SoTienThieuCong";
        public string strSoTien = "SoTien";
        public string strGhiChu = "GhiChu";

        public TC_DanhSachHocBong_ChiTietInfo()
        { }

        public int TC_DanhSachHocBong_ChiTietID{
        	set{ mTC_DanhSachHocBong_ChiTietID = value;}
        	get{ return mTC_DanhSachHocBong_ChiTietID;}
        }
        public int IDTC_DanhSachHocBong{
        	set{ mIDTC_DanhSachHocBong = value;}
        	get{ return mIDTC_DanhSachHocBong;}
        }
        public int Thang{
        	set{ mThang = value;}
        	get{ return mThang;}
        }
        public int SoNgayThieuCong
        {
            set { mSoNgayThieuCong = value; }
            get { return mSoNgayThieuCong; }
        }
        public double SoTienThieuCong
        {
            set { mSoTienThieuCong = value; }
            get { return mSoTienThieuCong; }
        }
        public double SoTien{
        	set{ mSoTien = value;}
        	get{ return mSoTien;}
        }
        public string GhiChu
        {
            set { mGhiChu = value; }
            get { return mGhiChu; }
        }
    }
}
