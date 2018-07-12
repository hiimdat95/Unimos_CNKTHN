using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class NS_NgachCongChucInfo
    {

        private int mNS_NgachCongChucID;
        private string mMaNgachCongChuc;
        private string mTenNgachCongChuc;
        private int mIDNS_NhomNgach;

        public string strNS_NgachCongChucID = "NS_NgachCongChucID";
        public string strMaNgachCongChuc = "MaNgachCongChuc";
        public string strTenNgachCongChuc = "TenNgachCongChuc";
        public string strIDNS_NhomNgach = "IDNS_NhomNgach";

        public NS_NgachCongChucInfo()
        { }

        public int NS_NgachCongChucID{
        	set{ mNS_NgachCongChucID = value;}
        	get{ return mNS_NgachCongChucID;}
        }
        public string MaNgachCongChuc{
        	set{ mMaNgachCongChuc = value;}
        	get{ return mMaNgachCongChuc;}
        }
        public string TenNgachCongChuc{
        	set{ mTenNgachCongChuc = value;}
        	get{ return mTenNgachCongChuc;}
        }
        public int IDNS_NhomNgach{
        	set{ mIDNS_NhomNgach = value;}
        	get{ return mIDNS_NhomNgach;}
        }
    }
}
