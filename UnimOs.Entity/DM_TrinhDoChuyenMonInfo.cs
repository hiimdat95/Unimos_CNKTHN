using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_TrinhDoChuyenMonInfo
    {

        private int mDM_TrinhDoChuyenMonID;
        private string mTenTrinhDoChuyenMon;
        private int mParentID;

        public string strDM_TrinhDoChuyenMonID = "DM_TrinhDoChuyenMonID";
        public string strTenTrinhDoChuyenMon = "TenTrinhDoChuyenMon";
        public string strParentID = "ParentID";

        public DM_TrinhDoChuyenMonInfo()
        { }

        public int DM_TrinhDoChuyenMonID
        {
            set { mDM_TrinhDoChuyenMonID = value; }
            get { return mDM_TrinhDoChuyenMonID; }
        }
        public string TenTrinhDoChuyenMon
        {
            set { mTenTrinhDoChuyenMon = value; }
            get { return mTenTrinhDoChuyenMon; }
        }
        public int ParentID { set { mParentID = value; } get { return mParentID; } }
    }
}
