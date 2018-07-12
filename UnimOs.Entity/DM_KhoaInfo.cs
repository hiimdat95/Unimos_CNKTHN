using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_KhoaInfo
    {

        private int mDM_KhoaID;
        private string mMaKhoa;
        private string mTenKhoa;
        private string mTenKhoa_E;

        public string strDM_KhoaID = "DM_KhoaID";
        public string strMaKhoa = "MaKhoa";
        public string strTenKhoa = "TenKhoa";
        public string strTenKhoa_E = "TenKhoa_E";

        public DM_KhoaInfo()
        { }

        public int DM_KhoaID{
        	set{ mDM_KhoaID = value;}
        	get{ return mDM_KhoaID;}
        }
        public string MaKhoa{
        	set{ mMaKhoa = value;}
        	get{ return mMaKhoa;}
        }
        public string TenKhoa{
        	set{ mTenKhoa = value;}
        	get{ return mTenKhoa;}
        }
        public string TenKhoa_E{
        	set{ mTenKhoa_E = value;}
        	get{ return mTenKhoa_E;}
        }
    }
}
