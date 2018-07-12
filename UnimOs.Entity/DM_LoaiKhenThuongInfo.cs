using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_LoaiKhenThuongInfo
    {

        private int mDM_LoaiKhenThuongID;
        private string mMaLoaiKhenThuong;
        private string mTenLoaiKhenThuong;

        public string strDM_LoaiKhenThuongID = "DM_LoaiKhenThuongID";
        public string strMaLoaiKhenThuong = "MaLoaiKhenThuong";
        public string strTenLoaiKhenThuong = "TenLoaiKhenThuong";

        public DM_LoaiKhenThuongInfo()
        { }

        public int DM_LoaiKhenThuongID{
        	set{ mDM_LoaiKhenThuongID = value;}
        	get{ return mDM_LoaiKhenThuongID;}
        }
        public string MaLoaiKhenThuong{
        	set{ mMaLoaiKhenThuong = value;}
        	get{ return mMaLoaiKhenThuong;}
        }
        public string TenLoaiKhenThuong{
        	set{ mTenLoaiKhenThuong = value;}
        	get{ return mTenLoaiKhenThuong;}
        }
    }
}
