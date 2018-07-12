using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_DangKyHocLaiInfo
    {

        private int mKQHT_DangKyHocLaiID;
        private int mIDSV_SinhVien;
        private int mIDDM_MonHoc;
        private int mIDDM_NamHoc;
        private int mHocKy;
        private int mIDDM_LopDangKy;
        private string mGhiChu;
        private double mTienLePhi;
        private int mIDHT_User;
        private int mIDKQHT_LopHocLai;
        private DateTime mNgayDangKy;
        private int mIDXL_MonHocTrongKy;
        private int mSoTietHocLai;

        public string strKQHT_DangKyHocLaiID = "KQHT_DangKyHocLaiID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strIDDM_MonHoc = "IDDM_MonHoc";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strHocKy = "HocKy";
        public string strIDDM_LopDangKy = "IDDM_LopDangKy";
        public string strGhiChu = "GhiChu";
        public string strTienLePhi = "TienLePhi";
        public string strIDHT_User = "IDHT_User";
        public string strNgayDangKy = "NgayDangKy";
        public string strIDKQHT_LopHocLai = "IDKQHT_LopHocLai";
        public string strIDXL_MonHocTrongKy = "IDXL_MonHocTrongKy";
        public string strSoTietHocLai = "SoTietHocLai";

        public KQHT_DangKyHocLaiInfo()
        { }

        public int KQHT_DangKyHocLaiID{
        	set{ mKQHT_DangKyHocLaiID = value;}
        	get{ return mKQHT_DangKyHocLaiID;}
        }
        public int IDXL_MonHocTrongKy
        {
            set { mIDXL_MonHocTrongKy = value; }
            get { return mIDXL_MonHocTrongKy; }
        }
        public int SoTietHocLai
        {
            set { mSoTietHocLai = value; }
            get { return mSoTietHocLai; }
        }
        public int IDKQHT_LopHocLai
        {
            set { mIDKQHT_LopHocLai = value; }
            get { return mIDKQHT_LopHocLai; }
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
        public int IDDM_LopDangKy{
        	set{ mIDDM_LopDangKy = value;}
        	get{ return mIDDM_LopDangKy;}
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
