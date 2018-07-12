using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class XL_PhanCongGiaoVienInfo
    {

        private int mXL_PhanCongGiaoVienID;
        private int mIDXL_MonHocTrongKy;
        private int mIDNS_GiaoVien;
        private int mSoTiet;

        public string strXL_PhanCongGiaoVienID = "XL_PhanCongGiaoVienID";
        public string strIDXL_MonHocTrongKy = "IDXL_MonHocTrongKy";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strSoTiet = "SoTiet";

        public XL_PhanCongGiaoVienInfo()
        { }

        public int XL_PhanCongGiaoVienID{
        	set{ mXL_PhanCongGiaoVienID = value;}
        	get{ return mXL_PhanCongGiaoVienID;}
        }
        public int IDXL_MonHocTrongKy{
        	set{ mIDXL_MonHocTrongKy = value;}
        	get{ return mIDXL_MonHocTrongKy;}
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
        }
        public int SoTiet{
        	set{ mSoTiet = value;}
        	get{ return mSoTiet;}
        }
    }
}
