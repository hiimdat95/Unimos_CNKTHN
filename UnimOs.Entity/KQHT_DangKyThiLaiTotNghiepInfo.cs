using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_DangKyThiLaiTotNghiepInfo
    {

        private int mKQHT_DangKyThiLaiTotNghiepID;
        private int mIDDM_MonHoc;
        private int mIDSV_SinhVien;
        private int mIDDM_NamHoc;
        private int mHocKy;
        private int mIDDM_Lop;

        public string strKQHT_DangKyThiLaiTotNghiepID = "KQHT_DangKyThiLaiTotNghiepID";
        public string strIDDM_MonHoc = "IDDM_MonHoc";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strHocKy = "HocKy";
        public string strIDDM_Lop = "IDDM_Lop";

        public KQHT_DangKyThiLaiTotNghiepInfo()
        { }

        public int KQHT_DangKyThiLaiTotNghiepID{
        	set{ mKQHT_DangKyThiLaiTotNghiepID = value;}
        	get{ return mKQHT_DangKyThiLaiTotNghiepID;}
        }
        public int IDDM_MonHoc{
        	set{ mIDDM_MonHoc = value;}
        	get{ return mIDDM_MonHoc;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
        public int IDDM_NamHoc{
        	set{ mIDDM_NamHoc = value;}
        	get{ return mIDDM_NamHoc;}
        }
        public int HocKy{
        	set{ mHocKy = value;}
        	get{ return mHocKy;}
        }
        public int IDDM_Lop{
        	set{ mIDDM_Lop = value;}
        	get{ return mIDDM_Lop;}
        }
    }
}
