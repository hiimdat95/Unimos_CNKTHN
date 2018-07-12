using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_LoaiCongViecInfo
    {

        private int mDM_LoaiCongViecID;
        private string mTenLoaiCongViec;
        private double mSoLuong;
        private string mDonVi;
        private double mQuyChuan;

        public string strDM_LoaiCongViecID = "DM_LoaiCongViecID";
        public string strTenLoaiCongViec = "TenLoaiCongViec";
        public string strSoLuong = "SoLuong";
        public string strDonVi = "DonVi";
        public string strQuyChuan = "QuyChuan";

        public DM_LoaiCongViecInfo()
        { }

        public int DM_LoaiCongViecID{
        	set{ mDM_LoaiCongViecID = value;}
        	get{ return mDM_LoaiCongViecID;}
        }
        public string TenLoaiCongViec{
        	set{ mTenLoaiCongViec = value;}
        	get{ return mTenLoaiCongViec;}
        }
        public double SoLuong
        {
        	set{ mSoLuong = value;}
        	get{ return mSoLuong;}
        }
        public string DonVi{
        	set{ mDonVi = value;}
        	get{ return mDonVi;}
        }
        public double QuyChuan
        {
        	set{ mQuyChuan = value;}
        	get{ return mQuyChuan;}
        }
    }
}
