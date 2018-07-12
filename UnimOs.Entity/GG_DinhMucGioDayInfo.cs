using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class GG_DinhMucGioDayInfo
    {

        private int mGG_DinhMucGioDayID;
        private int mIDNS_GiaoVien;
        private double? mSoGioGiam;
        private double? mSoGioDinhMuc;
        private int mIDDM_NamHoc;
        private int? mHocKy;

        public string strGG_DinhMucGioDayID = "GG_DinhMucGioDayID";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strSoGioGiam = "SoGioGiam";
        public string strSoGioDinhMuc = "SoGioDinhMuc";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strHocKy = "HocKy";

        public GG_DinhMucGioDayInfo()
        { }

        public int GG_DinhMucGioDayID{
        	set{ mGG_DinhMucGioDayID = value;}
        	get{ return mGG_DinhMucGioDayID;}
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
        }
        public double? SoGioGiam{
        	set{ mSoGioGiam = value;}
        	get{ return mSoGioGiam;}
        }
        public double? SoGioDinhMuc{
        	set{ mSoGioDinhMuc = value;}
        	get{ return mSoGioDinhMuc;}
        }
        public int IDDM_NamHoc{
        	set{ mIDDM_NamHoc = value;}
        	get{ return mIDDM_NamHoc;}
        }
        public int? HocKy{
        	set{ mHocKy = value;}
        	get{ return mHocKy;}
        }
    }
}
