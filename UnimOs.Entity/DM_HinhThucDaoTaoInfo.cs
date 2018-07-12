using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_HinhThucDaoTaoInfo
    {

        private int mDM_HinhThucDaoTaoID;
        private string mTenHinhThucDaoTao;

        public string strDM_HinhThucDaoTaoID = "DM_HinhThucDaoTaoID";
        public string strTenHinhThucDaoTao = "TenHinhThucDaoTao";

        public DM_HinhThucDaoTaoInfo()
        { }

        public int DM_HinhThucDaoTaoID{
        	set{ mDM_HinhThucDaoTaoID = value;}
        	get{ return mDM_HinhThucDaoTaoID;}
        }
        public string TenHinhThucDaoTao{
        	set{ mTenHinhThucDaoTao = value;}
        	get{ return mTenHinhThucDaoTao;}
        }
    }
}
