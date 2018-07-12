using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class NS_LoaiLuanChuyenInfo
    {

        private int mNS_LoaiLuanChuyenID;
        private string mTenLoaiLuanChuyen;
        private int mTrangThaiGiaoVien;

        public string strNS_LoaiLuanChuyenID = "NS_LoaiLuanChuyenID";
        public string strTenLoaiLuanChuyen = "TenLoaiLuanChuyen";
        public string strTrangThaiGiaoVien = "TrangThaiGiaoVien";

        public NS_LoaiLuanChuyenInfo()
        { }

        public int NS_LoaiLuanChuyenID{
        	set{ mNS_LoaiLuanChuyenID = value;}
        	get{ return mNS_LoaiLuanChuyenID;}
        }
        public string TenLoaiLuanChuyen{
        	set{ mTenLoaiLuanChuyen = value;}
        	get{ return mTenLoaiLuanChuyen;}
        }
        public int TrangThaiGiaoVien{
        	set{ mTrangThaiGiaoVien = value;}
        	get{ return mTrangThaiGiaoVien;}
        }
    }
}
