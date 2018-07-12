using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class XL_GiaoVien_MonHocInfo
    {

        private int mXL_GiaoVien_MonHocID;
        private int mIDNS_GiaoVien;
        private int mIDDM_MonHoc;

        public string strXL_GiaoVien_MonHocID = "XL_GiaoVien_MonHocID";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strIDDM_MonHoc = "IDDM_MonHoc";

        public XL_GiaoVien_MonHocInfo()
        { }

        public int XL_GiaoVien_MonHocID{
        	set{ mXL_GiaoVien_MonHocID = value;}
        	get{ return mXL_GiaoVien_MonHocID;}
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
        }
        public int IDDM_MonHoc{
        	set{ mIDDM_MonHoc = value;}
        	get{ return mIDDM_MonHoc;}
        }
    }
}
