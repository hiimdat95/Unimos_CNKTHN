using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_DangKyThiLaiInfo
    {

        private int mKQHT_DangKyThiLaiID;
        private int mIDSV_SinhVien;
        private int mIDDM_MonHoc;
        private int mIDDM_NamHoc;
        private int mHocKy;
        private int mLanThi;
        private int mIDKQHT_ToChucThi;
        private string mGhiChu;
        private double mTienLePhi;
        private int mIDHT_User;
        private DateTime mNgayDangKy;

        public string strKQHT_DangKyThiLaiID = "KQHT_DangKyThiLaiID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strIDDM_MonHoc = "IDDM_MonHoc";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strHocKy = "HocKy";
        public string strIDKQHT_ToChucThi = "IDKQHT_ToChucThi";
        public string strGhiChu = "GhiChu";
        public string strTienLePhi = "TienLePhi";
        public string strIDHT_User = "IDHT_User";
        public string strNgayDangKy = "NgayDangKy";
        public string strLanThi = "LanThi";

        public KQHT_DangKyThiLaiInfo()
        { }

        public int KQHT_DangKyThiLaiID{
        	set{ mKQHT_DangKyThiLaiID = value;}
        	get{ return mKQHT_DangKyThiLaiID;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
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
        public int LanThi
        {
            set { mLanThi = value; }
            get { return mLanThi; }
        }
        public int IDKQHT_ToChucThi{
        	set{ mIDKQHT_ToChucThi = value;}
        	get{ return mIDKQHT_ToChucThi;}
        }
        public string GhiChu{
        	set{ mGhiChu = value;}
        	get{ return mGhiChu;}
        }
        public double TienLePhi{
        	set{ mTienLePhi = value;}
        	get{ return mTienLePhi;}
        }
        public int IDHT_User{
        	set{ mIDHT_User = value;}
        	get{ return mIDHT_User;}
        }
        public DateTime NgayDangKy{
        	set{ mNgayDangKy = value;}
        	get{ return mNgayDangKy;}
        }
    }
}
