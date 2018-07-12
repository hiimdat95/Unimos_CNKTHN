using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_CongThucDiemInfo
    {

        private int mKQHT_CongThucDiemID;
        private int mIDDM_Lop;
        private int mIDDM_MonHoc;
        private int mIDDM_NamHoc;
        private int mHocKy;
        private string mCongThuc;

        public string strKQHT_CongThucDiemID = "KQHT_CongThucDiemID";
        public string strIDDM_Lop = "IDDM_Lop";
        public string strIDDM_MonHoc = "IDDM_MonHoc";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strHocKy = "HocKy";
        public string strCongThuc = "CongThuc";

        public KQHT_CongThucDiemInfo()
        { }

        public int KQHT_CongThucDiemID{
        	set{ mKQHT_CongThucDiemID = value;}
        	get{ return mKQHT_CongThucDiemID;}
        }
        public int IDDM_Lop{
        	set{ mIDDM_Lop = value;}
        	get{ return mIDDM_Lop;}
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
        public string CongThuc{
        	set{ mCongThuc = value;}
        	get{ return mCongThuc;}
        }
    }
}
