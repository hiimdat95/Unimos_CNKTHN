using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class XL_LopTachGop_MonHocInfo
    {

        private int mXL_LopTachGop_MonHocID;
        private int mIDXL_LopTachGop;
        private int mIDXL_MonHocTrongKy;
        private int mIDNS_GiaoVien;
        private int mIDDM_PhongHoc;
        private int mCaHoc;

        public string strXL_LopTachGop_MonHocID = "XL_LopTachGop_MonHocID";
        public string strIDXL_LopTachGop = "IDXL_LopTachGop";
        public string strIDXL_MonHocTrongKy = "IDXL_MonHocTrongKy";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strIDDM_PhongHoc = "IDDM_PhongHoc";
        public string strCaHoc = "CaHoc";

        public XL_LopTachGop_MonHocInfo()
        { }

        public int XL_LopTachGop_MonHocID{
        	set{ mXL_LopTachGop_MonHocID = value;}
        	get{ return mXL_LopTachGop_MonHocID;}
        }
        public int IDXL_LopTachGop{
        	set{ mIDXL_LopTachGop = value;}
        	get{ return mIDXL_LopTachGop;}
        }
        public int IDXL_MonHocTrongKy{
        	set{ mIDXL_MonHocTrongKy = value;}
        	get{ return mIDXL_MonHocTrongKy;}
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
        }
        public int IDDM_PhongHoc{
        	set{ mIDDM_PhongHoc = value;}
        	get{ return mIDDM_PhongHoc;}
        }
        public int CaHoc{
        	set{ mCaHoc = value;}
        	get{ return mCaHoc;}
        }
    }
}
