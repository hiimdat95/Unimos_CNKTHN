using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class GG_DinhMucTheoChucDanhInfo
    {

        private int mGG_DinhMucTheoChucDanhID;
        private int mIDDM_ChucDanh;
        private double mHeSo;
        private double mHeSoGioChuan;
        private double mGioLamViec;
        private double mGioChuanGiang;

        public string strGG_DinhMucTheoChucDanhID = "GG_DinhMucTheoChucDanhID";
        public string strIDDM_ChucDanh = "IDDM_ChucDanh";
        public string strHeSo = "HeSo";
        public string strHeSoGioChuan = "HeSoGioChuan";
        public string strGioLamViec = "GioLamViec";
        public string strGioChuanGiang = "GioChuanGiang";

        public GG_DinhMucTheoChucDanhInfo()
        { }

        public int GG_DinhMucTheoChucDanhID{
        	set{ mGG_DinhMucTheoChucDanhID = value;}
        	get{ return mGG_DinhMucTheoChucDanhID;}
        }
        public int IDDM_ChucDanh{
        	set{ mIDDM_ChucDanh = value;}
        	get{ return mIDDM_ChucDanh;}
        }
        public double HeSo
        {
        	set{ mHeSo = value;}
        	get{ return mHeSo;}
        }
        public double HeSoGioChuan
        {
        	set{ mHeSoGioChuan = value;}
        	get{ return mHeSoGioChuan;}
        }
        public double GioLamViec
        {
        	set{ mGioLamViec = value;}
        	get{ return mGioLamViec;}
        }
        public double GioChuanGiang
        {
        	set{ mGioChuanGiang = value;}
        	get{ return mGioChuanGiang;}
        }
    }
}
