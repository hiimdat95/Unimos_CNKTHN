using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class XL_NgayNghiToanTruongInfo
    {

        private int mXL_NgayNghiToanTruongID;
        private int mIDXL_KeHaochKhac;
        private long mIDXL_Tuan;
        private string mNgayNghi;
        private string mGhiChu;

        public string strXL_NgayNghiToanTruongID = "XL_NgayNghiToanTruongID";
        public string strIDXL_KeHaochKhac = "IDXL_KeHaochKhac";
        public string strIDXL_Tuan = "IDXL_Tuan";
        public string strNgayNghi = "NgayNghi";
        public string strGhiChu = "GhiChu";

        public XL_NgayNghiToanTruongInfo()
        { }

        public int XL_NgayNghiToanTruongID{
        	set{ mXL_NgayNghiToanTruongID = value;}
        	get{ return mXL_NgayNghiToanTruongID;}
        }
        public int IDXL_KeHaochKhac{
        	set{ mIDXL_KeHaochKhac = value;}
        	get{ return mIDXL_KeHaochKhac;}
        }
        public long IDXL_Tuan{
        	set{ mIDXL_Tuan = value;}
        	get{ return mIDXL_Tuan;}
        }
        public string NgayNghi{
        	set{ mNgayNghi = value;}
        	get{ return mNgayNghi;}
        }
        public string GhiChu{
        	set{ mGhiChu = value;}
        	get{ return mGhiChu;}
        }
    }
}
