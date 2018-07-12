using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class XL_PhongHocXepTKBInfo
    {

        private int mXL_PhongHocXepTKBID;
        private int mIDHT_User;
        private int mIDDM_PhongHoc;

        public string strXL_PhongHocXepTKBID = "XL_PhongHocXepTKBID";
        public string strIDHT_User = "IDHT_User";
        public string strIDDM_PhongHoc = "IDDM_PhongHoc";

        public XL_PhongHocXepTKBInfo()
        { }

        public int XL_PhongHocXepTKBID{
        	set{ mXL_PhongHocXepTKBID = value;}
        	get{ return mXL_PhongHocXepTKBID;}
        }
        public int IDHT_User{
        	set{ mIDHT_User = value;}
        	get{ return mIDHT_User;}
        }
        public int IDDM_PhongHoc{
        	set{ mIDDM_PhongHoc = value;}
        	get{ return mIDDM_PhongHoc;}
        }
    }
}
