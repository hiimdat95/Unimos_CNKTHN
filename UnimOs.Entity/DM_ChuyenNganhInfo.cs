using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_ChuyenNganhInfo
    {

        private int mDM_ChuyenNganhID;
        private int mIDDM_Nganh;
        private string mMaChuyenNganh;
        private string mTenChuyenNganh;
        private string mTenChuyenNganh_E;

        public string strDM_ChuyenNganhID = "DM_ChuyenNganhID";
        public string strIDDM_Nganh = "IDDM_Nganh";
        public string strMaChuyenNganh = "MaChuyenNganh";
        public string strTenChuyenNganh = "TenChuyenNganh";
        public string strTenChuyenNganh_E = "TenChuyenNganh_E";

        public DM_ChuyenNganhInfo()
        { }

        public int DM_ChuyenNganhID{
        	set{ mDM_ChuyenNganhID = value;}
        	get{ return mDM_ChuyenNganhID;}
        }
        public int IDDM_Nganh{
        	set{ mIDDM_Nganh = value;}
        	get{ return mIDDM_Nganh;}
        }
        public string MaChuyenNganh{
        	set{ mMaChuyenNganh = value;}
        	get{ return mMaChuyenNganh;}
        }
        public string TenChuyenNganh{
        	set{ mTenChuyenNganh = value;}
        	get{ return mTenChuyenNganh;}
        }
        public string TenChuyenNganh_E{
        	set{ mTenChuyenNganh_E = value;}
        	get{ return mTenChuyenNganh_E;}
        }
    }
}
