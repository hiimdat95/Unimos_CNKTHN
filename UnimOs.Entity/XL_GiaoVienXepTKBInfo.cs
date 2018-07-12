using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class XL_GiaoVienXepTKBInfo
    {

        private int mXL_GiaoVienXepTKB;
        private int mIDHT_User;
        private int mIDDM_GiaoVien;

        public string strXL_GiaoVienXepTKB = "XL_GiaoVienXepTKB";
        public string strIDHT_User = "IDHT_User";
        public string strIDDM_GiaoVien = "IDDM_GiaoVien";

        public XL_GiaoVienXepTKBInfo()
        { }

        public int XL_GiaoVienXepTKB{
        	set{ mXL_GiaoVienXepTKB = value;}
        	get{ return mXL_GiaoVienXepTKB;}
        }
        public int IDHT_User{
        	set{ mIDHT_User = value;}
        	get{ return mIDHT_User;}
        }
        public int IDDM_GiaoVien{
        	set{ mIDDM_GiaoVien = value;}
        	get{ return mIDDM_GiaoVien;}
        }
    }
}
