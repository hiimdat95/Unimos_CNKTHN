using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class XL_PhongHoc_MonHocInfo
    {

        private int mXL_PhongHoc_MonHocID;
        private int mIDDM_MonHoc;
        private int mIDDM_PhongHoc;

        public string strXL_PhongHoc_MonHocID = "XL_PhongHoc_MonHocID";
        public string strIDDM_MonHoc = "IDDM_MonHoc";
        public string strIDDM_PhongHoc = "IDDM_PhongHoc";

        public XL_PhongHoc_MonHocInfo()
        { }

        public int XL_PhongHoc_MonHocID{
        	set{ mXL_PhongHoc_MonHocID = value;}
        	get{ return mXL_PhongHoc_MonHocID;}
        }
        public int IDDM_MonHoc{
        	set{ mIDDM_MonHoc = value;}
        	get{ return mIDDM_MonHoc;}
        }
        public int IDDM_PhongHoc{
        	set{ mIDDM_PhongHoc = value;}
        	get{ return mIDDM_PhongHoc;}
        }
    }
}
