using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class XL_KeHoachChiTietInfo
    {

        private long mXL_KeHoachChiTietID;
        private long mIDXL_Tuan;
        private int mIDDM_Lop;
        private int mIDXL_LopTachGop;
        private int mIDXL_MonHocTrongKy;
        private int mIDDM_MonHoc;
        private int mIDNS_GiaoVien;
        private int mSoTiet;
        private int mLoaiTiet;
        private string mGhiChu;

        public string strXL_KeHoachChiTietID = "XL_KeHoachChiTietID";
        public string strIDXL_Tuan = "IDXL_Tuan";
        public string strIDDM_Lop = "IDDM_Lop";
        public string strIDXL_LopTachGop = "IDXL_LopTachGop";
        public string strIDXL_MonHocTrongKy = "IDXL_MonHocTrongKy";
        public string strIDDM_MonHoc = "IDDM_MonHoc";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strSoTiet = "SoTiet";
        public string strLoaiTiet = "LoaiTiet";
        public string strGhiChu = "GhiChu";

        public XL_KeHoachChiTietInfo()
        { }

        public long XL_KeHoachChiTietID{
        	set{ mXL_KeHoachChiTietID = value;}
        	get{ return mXL_KeHoachChiTietID;}
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
        public int IDXL_MonHocTrongKy{
        	set{ mIDXL_MonHocTrongKy = value;}
        	get{ return mIDXL_MonHocTrongKy;}
        }
        public int IDDM_MonHoc{
        	set{ mIDDM_MonHoc = value;}
        	get{ return mIDDM_MonHoc;}
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
        }
        public int SoTiet{
        	set{ mSoTiet = value;}
        	get{ return mSoTiet;}
        }
        public int LoaiTiet{
        	set{ mLoaiTiet = value;}
        	get{ return mLoaiTiet;}
        }
        public string GhiChu{
        	set{ mGhiChu = value;}
        	get{ return mGhiChu;}
        }
    }
}
