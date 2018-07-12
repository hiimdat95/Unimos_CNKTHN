using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_QuanHeGiaDinhInfo
    {

        private int mDM_QuanHeGiaDinhID;
        private string mTenMoiQuanHe;
        private bool mBo;
        private bool mMe;

        public string strDM_QuanHeGiaDinhID = "DM_QuanHeGiaDinhID";
        public string strTenMoiQuanHe = "TenMoiQuanHe";
        public string strBo = "Bo";
        public string strMe = "Me";

        public DM_QuanHeGiaDinhInfo()
        { }

        public int DM_QuanHeGiaDinhID{
        	set{ mDM_QuanHeGiaDinhID = value;}
        	get{ return mDM_QuanHeGiaDinhID;}
        }
        public string TenMoiQuanHe{
        	set{ mTenMoiQuanHe = value;}
        	get{ return mTenMoiQuanHe;}
        }
        public bool Bo{
        	set{ mBo = value;}
        	get{ return mBo;}
        }
        public bool Me{
        	set{ mMe = value;}
        	get{ return mMe;}
        }
    }
}
