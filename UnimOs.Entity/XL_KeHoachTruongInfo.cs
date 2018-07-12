using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class XL_KeHoachTruongInfo
    {

        private int mXL_KeHoachTruongID;
        private long mIDXL_Tuan;
        private int mIDDM_Lop;
        private int mIDXL_LopTachGop;
        private int mCaHoc;
        private int mIDDM_PhongHoc;
        private int mIDXL_KeHoachKhac;
        private string mNgayNghi;

        public string strXL_KeHoachTruongID = "XL_KeHoachTruongID";
        public string strIDXL_Tuan = "IDXL_Tuan";
        public string strIDDM_Lop = "IDDM_Lop";
        public string strIDXL_LopTachGop = "IDXL_LopTachGop";
        public string strCaHoc = "CaHoc";
        public string strIDDM_PhongHoc = "IDDM_PhongHoc";
        public string strIDXL_KeHoachKhac = "IDXL_KeHoachKhac";
        public string strNgayNghi = "NgayNghi";

        public XL_KeHoachTruongInfo()
        { }

        public int XL_KeHoachTruongID{
        	set{ mXL_KeHoachTruongID = value;}
        	get{ return mXL_KeHoachTruongID;}
        }
        public long IDXL_Tuan{
        	set{ mIDXL_Tuan = value;}
        	get{ return mIDXL_Tuan;}
        }
        public int IDDM_Lop{
        	set{ mIDDM_Lop = value;}
        	get{ return mIDDM_Lop;}
        }
        public int IDXL_LopTachGop{
        	set{ mIDXL_LopTachGop = value;}
        	get{ return mIDXL_LopTachGop;}
        }
        public int CaHoc{
        	set{ mCaHoc = value;}
        	get{ return mCaHoc;}
        }
        public int IDDM_PhongHoc{
        	set{ mIDDM_PhongHoc = value;}
        	get{ return mIDDM_PhongHoc;}
        }
        public int IDXL_KeHoachKhac{
        	set{ mIDXL_KeHoachKhac = value;}
        	get{ return mIDXL_KeHoachKhac;}
        }
        public string NgayNghi{
        	set{ mNgayNghi = value;}
        	get{ return mNgayNghi;}
        }
    }
}
