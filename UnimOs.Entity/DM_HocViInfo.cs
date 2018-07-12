using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_HocViInfo
    {

        private int mDM_HocViID;
        private string mTenHocVi;
        private int mIDDM_LoaiChuyenMon;

        public string strDM_HocViID = "DM_HocViID";
        public string strTenHocVi = "TenHocVi";
        public string strIDDM_LoaiChuyenMon = "IDDM_LoaiChuyenMon";

        public DM_HocViInfo()
        { }

        public int DM_HocViID{
        	set{ mDM_HocViID = value;}
        	get{ return mDM_HocViID;}
        }
        public string TenHocVi{
        	set{ mTenHocVi = value;}
        	get{ return mTenHocVi;}
        }
        public int IDDM_LoaiChuyenMon
        {
            set { mIDDM_LoaiChuyenMon = value; }
            get { return mIDDM_LoaiChuyenMon; }
        }
    }
}
