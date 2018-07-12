using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_ChucVuInfo
    {

        private int mDM_ChucVuID;
        private string mTenChucVu;
        private int? mSoGioGiam;
        private double? mPhanTramGioGiam;
        private string mIDLoaiVienChuc;

        public string strDM_ChucVuID = "DM_ChucVuID";
        public string strTenChucVu = "TenChucVu";
        public string strSoGioGiam = "SoGioGiam";
        public string strPhanTramGioGiam = "PhanTramGioGiam";
        public string strIDLoaiVienChuc = "IDLoaiVienChuc";

        public DM_ChucVuInfo()
        { }

        public int DM_ChucVuID{
        	set{ mDM_ChucVuID = value;}
        	get{ return mDM_ChucVuID;}
        }
        public string TenChucVu{
        	set{ mTenChucVu = value;}
        	get{ return mTenChucVu;}
        }
        public int? SoGioGiam{
        	set{ mSoGioGiam = value;}
        	get{ return mSoGioGiam;}
        }
        public double? PhanTramGioGiam{
        	set{ mPhanTramGioGiam = value;}
        	get{ return mPhanTramGioGiam;}
        }
        public string IDLoaiVienChuc
        {
            set { mIDLoaiVienChuc = value; }
            get { return mIDLoaiVienChuc; }
        }
    }
}
