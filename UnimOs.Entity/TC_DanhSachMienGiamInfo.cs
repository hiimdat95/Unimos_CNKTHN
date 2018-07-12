using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class TC_DanhSachMienGiamInfo
    {

        private int mTC_DanhSachMienGiamID;
        private int mIDSV_SinhVien;
        private int mIDDM_NamHoc;
        private int mHocKy;
        private int mIDTC_LoaiThuChi;
        private double mSoTienMienGiam;
        private string mGhiChu;

        public string strTC_DanhSachMienGiamID = "TC_DanhSachMienGiamID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strHocKy = "HocKy";
        public string strIDTC_LoaiThuChi = "IDTC_LoaiThuChi";
        public string strSoTienMienGiam = "SoTienMienGiam";
        public string strGhiChu = "GhiChu";

        public TC_DanhSachMienGiamInfo()
        { }

        public int TC_DanhSachMienGiamID{
        	set{ mTC_DanhSachMienGiamID = value;}
        	get{ return mTC_DanhSachMienGiamID;}
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
        public double SoTienMienGiam{
        	set{ mSoTienMienGiam = value;}
        	get{ return mSoTienMienGiam;}
        }
        public string GhiChu{
        	set{ mGhiChu = value;}
        	get{ return mGhiChu;}
        }
    }
}
