using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_MonThiTotNghiep_LopInfo
    {

        private int mKQHT_MonThiTotNghiep_LopID;
        private int mIDDM_Lop;
        private int mIDDM_MonHoc;
        private bool mTinhDiem;
        private double mSoHocTrinh;
        private int mIDDM_NamHoc;

        public string strKQHT_MonThiTotNghiep_LopID = "KQHT_MonThiTotNghiep_LopID";
        public string strIDDM_Lop = "IDDM_Lop";
        public string strIDDM_MonHoc = "IDDM_MonHoc";
        public string strTinhDiem = "TinhDiem";
        public string strSoHocTrinh = "SoHocTrinh";
        public string strIDDM_NamHoc = "IDDM_NamHoc";

        public KQHT_MonThiTotNghiep_LopInfo()
        { }

        public int KQHT_MonThiTotNghiep_LopID{
        	set{ mKQHT_MonThiTotNghiep_LopID = value;}
        	get{ return mKQHT_MonThiTotNghiep_LopID;}
        }
        public int IDDM_Lop{
        	set{ mIDDM_Lop = value;}
        	get{ return mIDDM_Lop;}
        }
        public int IDDM_MonHoc{
        	set{ mIDDM_MonHoc = value;}
        	get{ return mIDDM_MonHoc;}
        }
        public bool TinhDiem{
        	set{ mTinhDiem = value;}
        	get{ return mTinhDiem;}
        }
        public double SoHocTrinh
        {
        	set{ mSoHocTrinh = value;}
        	get{ return mSoHocTrinh;}
        }
        public int IDDM_NamHoc{
        	set{ mIDDM_NamHoc = value;}
        	get{ return mIDDM_NamHoc;}
        }
    }
}
