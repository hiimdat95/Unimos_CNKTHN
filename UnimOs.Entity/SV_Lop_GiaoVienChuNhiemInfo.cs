using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class SV_Lop_GiaoVienChuNhiemInfo
    {

        private int mSV_Lop_GiaoVienChuNhiemID;
        private int mIDDM_Lop;
        private int mIDDM_GiaoVien;
        private DateTime mTuNgay;
        private DateTime mDenNgay;

        public string strSV_Lop_GiaoVienChuNhiemID = "SV_Lop_GiaoVienChuNhiemID";
        public string strIDDM_Lop = "IDDM_Lop";
        public string strIDDM_GiaoVien = "IDDM_GiaoVien";
        public string strTuNgay = "TuNgay";
        public string strDenNgay = "DenNgay";

        public SV_Lop_GiaoVienChuNhiemInfo()
        { }

        public int SV_Lop_GiaoVienChuNhiemID{
        	set{ mSV_Lop_GiaoVienChuNhiemID = value;}
        	get{ return mSV_Lop_GiaoVienChuNhiemID;}
        }
        public int IDDM_Lop{
        	set{ mIDDM_Lop = value;}
        	get{ return mIDDM_Lop;}
        }
        public int IDDM_GiaoVien{
        	set{ mIDDM_GiaoVien = value;}
        	get{ return mIDDM_GiaoVien;}
        }
        public DateTime TuNgay{
        	set{ mTuNgay = value;}
        	get{ return mTuNgay;}
        }
        public DateTime DenNgay{
        	set{ mDenNgay = value;}
        	get{ return mDenNgay;}
        }
    }
}
