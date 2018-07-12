using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_KhoiKienThucInfo
    {

        private int mDM_KhoiKienThucID;
        private string mMaKhoiKienThuc;
        private string mTenKhoiKienThuc;
        private int mParentID;
        private int mSoHocPhanPhaiChon;
        private bool mKhoaLuanTotNghiep;
        private int mSapXep;

        public string strDM_KhoiKienThucID = "DM_KhoiKienThucID";
        public string strMaKhoiKienThuc = "MaKhoiKienThuc";
        public string strTenKhoiKienThuc = "TenKhoiKienThuc";
        public string strParentID = "ParentID";
        public string strSoHocPhanPhaiChon = "SoHocPhanPhaiChon";
        public string strKhoaLuanTotNghiep = "KhoaLuanTotNghiep";
        public string strSapXep = "SapXep";

        public DM_KhoiKienThucInfo()
        { }

        public int DM_KhoiKienThucID{
        	set{ mDM_KhoiKienThucID = value;}
        	get{ return mDM_KhoiKienThucID;}
        }
        public string MaKhoiKienThuc{
        	set{ mMaKhoiKienThuc = value;}
        	get{ return mMaKhoiKienThuc;}
        }
        public string TenKhoiKienThuc{
        	set{ mTenKhoiKienThuc = value;}
        	get{ return mTenKhoiKienThuc;}
        }
        public int ParentID{
        	set{ mParentID = value;}
        	get{ return mParentID;}
        }
        public int SoHocPhanPhaiChon{
        	set{ mSoHocPhanPhaiChon = value;}
        	get{ return mSoHocPhanPhaiChon;}
        }
        public bool KhoaLuanTotNghiep{
        	set{ mKhoaLuanTotNghiep = value;}
        	get{ return mKhoaLuanTotNghiep;}
        }
        public int SapXep{
        	set{ mSapXep = value;}
        	get{ return mSapXep;}
        }
    }
}
