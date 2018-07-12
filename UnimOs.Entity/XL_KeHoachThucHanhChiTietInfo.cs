using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class XL_KeHoachThucHanhChiTietInfo
    {

        private long mXL_KeHoachThucHanhChiTietID;
        private int mIDXL_KeHoachThucHanh;
        private long mIDXL_Tuan;
        private int mCaHoc;
        private int mToThucHanh;
        private DateTime mNgayThucHanh;

        public string strXL_KeHoachThucHanhChiTietID = "XL_KeHoachThucHanhChiTietID";
        public string strIDXL_KeHoachThucHanh = "IDXL_KeHoachThucHanh";
        public string strIDXL_Tuan = "IDXL_Tuan";
        public string strCaHoc = "CaHoc";
        public string strToThucHanh = "ToThucHanh";
        public string strNgayThucHanh = "NgayThucHanh";

        public XL_KeHoachThucHanhChiTietInfo()
        { }

        public long XL_KeHoachThucHanhChiTietID{
        	set{ mXL_KeHoachThucHanhChiTietID = value;}
        	get{ return mXL_KeHoachThucHanhChiTietID;}
        }
        public int IDXL_KeHoachThucHanh{
        	set{ mIDXL_KeHoachThucHanh = value;}
        	get{ return mIDXL_KeHoachThucHanh;}
        }
        public long IDXL_Tuan{
        	set{ mIDXL_Tuan = value;}
        	get{ return mIDXL_Tuan;}
        }
        public int CaHoc{
        	set{ mCaHoc = value;}
        	get{ return mCaHoc;}
        }
        public int ToThucHanh{
        	set{ mToThucHanh = value;}
        	get{ return mToThucHanh;}
        }
        public DateTime NgayThucHanh{
        	set{ mNgayThucHanh = value;}
        	get{ return mNgayThucHanh;}
        }
    }
}
