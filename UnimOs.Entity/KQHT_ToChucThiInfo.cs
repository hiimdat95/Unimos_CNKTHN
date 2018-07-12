using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_ToChucThiInfo
    {

        private int mKQHT_ToChucThiID;
        private int mIDDM_MonHoc;
        private int mIDDM_NamHoc;
        private int mHocKy;
        private int mLanThi;
        private int mDotThi;
        private DateTime mNgayThi;
        private int mCaThi;
        private int mNhomTiet;
        private int mIDHT_User;
        private DateTime mNgayTao;
        private bool mDongTui;
        private bool mTotNghiep;

        public string strKQHT_ToChucThiID = "KQHT_ToChucThiID";
        public string strIDDM_MonHoc = "IDDM_MonHoc";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strHocKy = "HocKy";
        public string strLanThi = "LanThi";
        public string strDotThi = "DotThi";
        public string strNgayThi = "NgayThi";
        public string strCaThi = "CaThi";
        public string strNhomTiet = "NhomTiet";
        public string strIDHT_User = "IDHT_User";
        public string strNgayTao = "NgayTao";
        public string strDongTui = "DongTui";
        public string strTotNghiep = "TotNghiep";

        public KQHT_ToChucThiInfo()
        { }

        public int KQHT_ToChucThiID{
        	set{ mKQHT_ToChucThiID = value;}
        	get{ return mKQHT_ToChucThiID;}
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
        public int DotThi{
        	set{ mDotThi = value;}
        	get{ return mDotThi;}
        }
        public DateTime NgayThi{
        	set{ mNgayThi = value;}
        	get{ return mNgayThi;}
        }
        public int CaThi{
        	set{ mCaThi = value;}
        	get{ return mCaThi;}
        }
        public int NhomTiet{
        	set{ mNhomTiet = value;}
        	get{ return mNhomTiet;}
        }
        public int IDHT_User{
        	set{ mIDHT_User = value;}
        	get{ return mIDHT_User;}
        }
        public DateTime NgayTao{
        	set{ mNgayTao = value;}
        	get{ return mNgayTao;}
        }
        public bool DongTui{
        	set{ mDongTui = value;}
        	get{ return mDongTui;}
        }
        public bool TotNghiep{
        	set{ mTotNghiep = value;}
        	get{ return mTotNghiep;}
        }
    }
}
