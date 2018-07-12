using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_DiemThiInfo
    {

        private int mKQHT_DiemThiID;
        private int mIDSV_SinhVien;
        private int mIDDM_MonHoc;
        private int mIDDM_NamHoc;
        private int mHocKy;
        private int mLanThi;
        private double mDiem;
        private string mLyDo;
        private int mIDHT_User;
        private DateTime mNgayTao;
        private int mIDXL_MonHocTrongKy;

        public string strKQHT_DiemThiID = "KQHT_DiemThiID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strIDDM_MonHoc = "IDDM_MonHoc";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strHocKy = "HocKy";
        public string strLanThi = "LanThi";
        public string strDiem = "Diem";
        public string strLyDo = "LyDo";
        public string strIDHT_User = "IDHT_User";
        public string strNgayTao = "NgayTao";
        public string strIDXL_MonHocTrongKy = "IDXL_MonHocTrongKy";

        public KQHT_DiemThiInfo()
        { }

        public int KQHT_DiemThiID{
        	set{ mKQHT_DiemThiID = value;}
        	get{ return mKQHT_DiemThiID;}
        }
        public int IDXL_MonHocTrongKy
        {
            set { mIDXL_MonHocTrongKy = value; }
            get { return mIDXL_MonHocTrongKy; }
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
        public int LanThi{
        	set{ mLanThi = value;}
        	get{ return mLanThi;}
        }
        public double Diem{
        	set{ mDiem = value;}
        	get{ return mDiem;}
        }
        public string LyDo{
        	set{ mLyDo = value;}
        	get{ return mLyDo;}
        }
        public int IDHT_User{
        	set{ mIDHT_User = value;}
        	get{ return mIDHT_User;}
        }
        public DateTime NgayTao{
        	set{ mNgayTao = value;}
        	get{ return mNgayTao;}
        }
    }
}
