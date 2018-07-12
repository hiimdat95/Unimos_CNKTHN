using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class GG_GiangDayGiaoVienInfo
    {

        private long mGG_GiangDayGiaoVienID;
        private int mIDNS_GiaoVien;
        private int mIDDM_NamHoc;
        private int mHocKy;
        private long mIDXL_MonHocTrongKy;
        private int mSoNhom;
        private int mSoSinhVien;
        private int? mLyThuyet;
        private double? mLyThuyetQuyChuan;
        private int? mThucHanh;
        private double? mThucHanhQuyChuan;
        private double? mHeSoLopDong;
        private double mSoGioChuan;
        private string mGhiChu;

        public string strGG_GiangDayGiaoVienID = "GG_GiangDayGiaoVienID";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strHocKy = "HocKy";
        public string strIDXL_MonHocTrongKy = "IDXL_MonHocTrongKy";
        public string strSoNhom = "SoNhom";
        public string strSoSinhVien = "SoSinhVien";
        public string strLyThuyet = "LyThuyet";
        public string strLyThuyetQuyChuan = "LyThuyetQuyChuan";
        public string strThucHanh = "ThucHanh";
        public string strThucHanhQuyChuan = "ThucHanhQuyChuan";
        public string strHeSoLopDong = "HeSoLopDong";
        public string strSoGioChuan = "SoGioChuan";
        public string strGhiChu = "GhiChu";

        public GG_GiangDayGiaoVienInfo()
        { }

        public long GG_GiangDayGiaoVienID{
        	set{ mGG_GiangDayGiaoVienID = value;}
        	get{ return mGG_GiangDayGiaoVienID;}
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
        }
        public int IDDM_NamHoc{
        	set{ mIDDM_NamHoc = value;}
        	get{ return mIDDM_NamHoc;}
        }
        public int HocKy{
        	set{ mHocKy = value;}
        	get{ return mHocKy;}
        }
        public long IDXL_MonHocTrongKy{
        	set{ mIDXL_MonHocTrongKy = value;}
        	get{ return mIDXL_MonHocTrongKy;}
        }
        public int SoNhom
        {
            set { mSoNhom = value; }
            get { return mSoNhom; }
        }
        public int SoSinhVien{
        	set{ mSoSinhVien = value;}
        	get{ return mSoSinhVien;}
        }
        public int? LyThuyet{
        	set{ mLyThuyet = value;}
        	get{ return mLyThuyet;}
        }
        public double? LyThuyetQuyChuan{
        	set{ mLyThuyetQuyChuan = value;}
        	get{ return mLyThuyetQuyChuan;}
        }
        public int? ThucHanh{
        	set{ mThucHanh = value;}
        	get{ return mThucHanh;}
        }
        public double? ThucHanhQuyChuan{
        	set{ mThucHanhQuyChuan = value;}
        	get{ return mThucHanhQuyChuan;}
        }
        public double? HeSoLopDong
        {
            set { mHeSoLopDong = value; }
            get { return mHeSoLopDong; }
        }
        public double SoGioChuan{
        	set{ mSoGioChuan = value;}
        	get{ return mSoGioChuan;}
        }
        public string GhiChu{
        	set{ mGhiChu = value;}
        	get{ return mGhiChu;}
        }
    }
}
