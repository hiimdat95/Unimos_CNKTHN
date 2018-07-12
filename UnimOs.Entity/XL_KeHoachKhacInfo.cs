using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class XL_KeHoachKhacInfo
    {

        private int mXL_KeHoachKhacID;
        private string mTenKeHoachKhac;
        private string mTenVietTat;
        private int mMauNen;
        private int mMauChu;
        private bool mDuLieuChuan;

        public string strXL_KeHoachKhacID = "XL_KeHoachKhacID";
        public string strTenKeHoachKhac = "TenKeHoachKhac";
        public string strTenVietTat = "TenVietTat";
        public string strMauNen = "MauNen";
        public string strMauChu = "MauChu";
        public string strDuLieuChuan = "DuLieuChuan";

        public XL_KeHoachKhacInfo()
        { }

        public int XL_KeHoachKhacID{
        	set{ mXL_KeHoachKhacID = value;}
        	get{ return mXL_KeHoachKhacID;}
        }
        public string TenKeHoachKhac{
        	set{ mTenKeHoachKhac = value;}
        	get{ return mTenKeHoachKhac;}
        }
        public string TenVietTat{
        	set{ mTenVietTat = value;}
        	get{ return mTenVietTat;}
        }
        public int MauNen{
        	set{ mMauNen = value;}
        	get{ return mMauNen;}
        }
        public int MauChu{
        	set{ mMauChu = value;}
        	get{ return mMauChu;}
        }
        public bool DuLieuChuan{
        	set{ mDuLieuChuan = value;}
        	get{ return mDuLieuChuan;}
        }
    }
}
