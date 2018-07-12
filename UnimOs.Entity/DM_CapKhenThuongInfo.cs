using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_CapKhenThuongInfo
    {

        private int mDM_CapKhenThuongID;
        private string mTenCapKhenThuong;

        public string strDM_CapKhenThuongID = "DM_CapKhenThuongID";
        public string strTenCapKhenThuong = "TenCapKhenThuong";

        public DM_CapKhenThuongInfo()
        { }

        public int DM_CapKhenThuongID{
        	set{ mDM_CapKhenThuongID = value;}
        	get{ return mDM_CapKhenThuongID;}
        }
        public string TenCapKhenThuong{
        	set{ mTenCapKhenThuong = value;}
        	get{ return mTenCapKhenThuong;}
        }
    }
}
