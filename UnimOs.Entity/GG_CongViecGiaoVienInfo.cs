using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class GG_CongViecGiaoVienInfo
    {

        private long mGG_CongViecGiaoVienID;
        private int mIDDM_LoaiCongViec;
        private int mIDNS_GiaoVien;
        private double mSoGio;
        private double mHeSo;
        private double mGioQuyChuan;
        private int mIDDM_NamHoc;
        private int mHocKy;
        private string mGhiChu;

        public string strGG_CongViecGiaoVienID = "GG_CongViecGiaoVienID";
        public string strIDDM_LoaiCongViec = "IDDM_LoaiCongViec";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strSoGio = "SoGio";
        public string strHeSo = "HeSo";
        public string strGioQuyChuan = "GioQuyChuan";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strHocKy = "HocKy";
        public string strGhiChu = "GhiChu";

        public GG_CongViecGiaoVienInfo()
        { }

        public long GG_CongViecGiaoVienID{
        	set{ mGG_CongViecGiaoVienID = value;}
        	get{ return mGG_CongViecGiaoVienID;}
        }
        public int IDDM_LoaiCongViec{
        	set{ mIDDM_LoaiCongViec = value;}
        	get{ return mIDDM_LoaiCongViec;}
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
        }
        public double SoGio{
        	set{ mSoGio = value;}
        	get{ return mSoGio;}
        }
        public double HeSo{
        	set{ mHeSo = value;}
        	get{ return mHeSo;}
        }
        public double GioQuyChuan{
        	set{ mGioQuyChuan = value;}
        	get{ return mGioQuyChuan;}
        }
        public int IDDM_NamHoc{
        	set{ mIDDM_NamHoc = value;}
        	get{ return mIDDM_NamHoc;}
        }
        public int HocKy{
        	set{ mHocKy = value;}
        	get{ return mHocKy;}
        }
        public string GhiChu{
        	set{ mGhiChu = value;}
        	get{ return mGhiChu;}
        }
    }
}
