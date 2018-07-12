using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class SV_SinhVien_LopInfo
    {

        private int mSV_SinhVien_LopID;
        private int mIDSV_SinhVien;
        private int mIDDM_Lop;
        private int mTrangThaiSinhVien;

        public string strSV_SinhVien_LopID = "SV_SinhVien_LopID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strIDDM_Lop = "IDDM_Lop";
        public string strTrangThaiSinhVien = "TrangThaiSinhVien";

        public SV_SinhVien_LopInfo()
        { }

        public int SV_SinhVien_LopID{
        	set{ mSV_SinhVien_LopID = value;}
        	get{ return mSV_SinhVien_LopID;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
        public int IDDM_Lop{
        	set{ mIDDM_Lop = value;}
        	get{ return mIDDM_Lop;}
        }
        public int TrangThaiSinhVien
        {
            set { mTrangThaiSinhVien = value; }
            get { return mTrangThaiSinhVien; }
        }
    }
}
