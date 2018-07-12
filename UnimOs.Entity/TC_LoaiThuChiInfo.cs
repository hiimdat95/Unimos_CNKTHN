using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class TC_LoaiThuChiInfo
    {

        private int mTC_LoaiThuChiID;
        private string mTenLoaiThuChi;
        private double mSoTien;
        private bool mKhoanThu;
        private bool mBatBuoc;
        private bool mTheoNienKhoa;
        private bool mHocPhi;
        private bool mNhapHoc;
        private int mParentID;
        private int mIDNamHoc;
        private int mHocKy;

        public string strTC_LoaiThuChiID = "TC_LoaiThuChiID";
        public string strTenLoaiThuChi = "TenLoaiThuChi";
        public string strSoTien = "SoTien";
        public string strKhoanThu = "KhoanThu";
        public string strBatBuoc = "BatBuoc";
        public string strTheoNienKhoa = "TheoNienKhoa";
        public string strHocPhi = "HocPhi";
        public string strNhapHoc = "NhapHoc";
        public string strParentID = "ParentID";
        public string strIDNamHoc = "IDNamHoc";
        public string strHocKy = "HocKy";

        public TC_LoaiThuChiInfo()
        { }

        public int TC_LoaiThuChiID{
        	set{ mTC_LoaiThuChiID = value;}
        	get{ return mTC_LoaiThuChiID;}
        }
        public string TenLoaiThuChi{
        	set{ mTenLoaiThuChi = value;}
        	get{ return mTenLoaiThuChi;}
        }
        public double SoTien{
        	set{ mSoTien = value;}
        	get{ return mSoTien;}
        }
        public bool KhoanThu{
        	set{ mKhoanThu = value;}
        	get{ return mKhoanThu;}
        }
        public bool BatBuoc{
        	set{ mBatBuoc = value;}
        	get{ return mBatBuoc;}
        }
        public bool TheoNienKhoa{
        	set{ mTheoNienKhoa = value;}
        	get{ return mTheoNienKhoa;}
        }
        public bool HocPhi{
        	set{ mHocPhi = value;}
        	get{ return mHocPhi;}
        }
        public bool NhapHoc{
        	set{ mNhapHoc = value;}
        	get{ return mNhapHoc;}
        }
        public int ParentID{
            set { mParentID = value; }
            get { return mParentID; }
        }
        public int IDNamHoc{
            set { mIDNamHoc = value; }
            get { return mIDNamHoc; }
        }
        public int HocKy{
            set { mHocKy = value; }
            get { return mHocKy; }
        }
    }
}
