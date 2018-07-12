using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class TC_DinhMucThuSinhVienInfo
    {

        private int mTC_DinhMucThuSinhVienID;
        private int mIDSV_SinhVien;
        private int mIDDM_NamHoc;
        private int mHocKy;
        private int mIDTC_LoaiThuChi;
        private double mSoTienPhaiNop;
        private double mSoTienGiam;
        private string mGhiChu;

        public string strTC_DinhMucThuSinhVienID = "TC_DinhMucThuSinhVienID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strHocKy = "HocKy";
        public string strIDTC_LoaiThuChi = "IDTC_LoaiThuChi";
        public string strSoTienPhaiNop = "SoTienPhaiNop";
        public string strSoTienGiam = "SoTienGiam";
        public string strGhiChu = "GhiChu";

        public TC_DinhMucThuSinhVienInfo()
        { }

        public int TC_DinhMucThuSinhVienID{
        	set{ mTC_DinhMucThuSinhVienID = value;}
        	get{ return mTC_DinhMucThuSinhVienID;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
        public int IDDM_NamHoc{
        	set{ mIDDM_NamHoc = value;}
        	get{ return mIDDM_NamHoc;}
        }
        public int HocKy{
        	set{ mHocKy = value;}
        	get{ return mHocKy;}
        }
        public int IDTC_LoaiThuChi{
        	set{ mIDTC_LoaiThuChi = value;}
        	get{ return mIDTC_LoaiThuChi;}
        }
        public double SoTienPhaiNop{
        	set{ mSoTienPhaiNop = value;}
        	get{ return mSoTienPhaiNop;}
        }
        public double SoTienGiam{
        	set{ mSoTienGiam = value;}
        	get{ return mSoTienGiam;}
        }
        public string GhiChu{
        	set{ mGhiChu = value;}
        	get{ return mGhiChu;}
        }
    }
}
