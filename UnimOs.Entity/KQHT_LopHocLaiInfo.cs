using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_LopHocLaiInfo
    {

        private int mKQHT_LopHocLaiID;
        private string mTenLop;
        private int mIDDM_MonHoc;
        private int mIDDM_NamHoc;
        private int mHocKy;
        private int mIDNS_GiaoVien;

        public string strKQHT_LopHocLaiID = "KQHT_LopHocLaiID";
        public string strTenLop = "TenLop";
        public string strIDDM_MonHoc = "IDDM_MonHoc";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strHocKy = "HocKy";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";

        public KQHT_LopHocLaiInfo()
        { }

        public int KQHT_LopHocLaiID
        {
            set { mKQHT_LopHocLaiID = value; }
            get { return mKQHT_LopHocLaiID; }
        }
        public string TenLop{
        	set{ mTenLop = value;}
        	get{ return mTenLop;}
        }
        public int IDDM_MonHoc{
        	set{ mIDDM_MonHoc = value;}
        	get{ return mIDDM_MonHoc;}
        }
        public int IDDM_NamHoc{
        	set{ mIDDM_NamHoc = value;}
        	get{ return mIDDM_NamHoc;}
        }
        public int HocKy{
        	set{ mHocKy = value;}
        	get{ return mHocKy;}
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
        }
    }
}
