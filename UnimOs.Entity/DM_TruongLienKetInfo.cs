using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_TruongLienKetInfo
    {

        private int mDM_TruongLienKetID;
        private string mMaTruong;
        private string mTenTruong;
        private string mDiaChi;
        private int mIDDM_TinhHuyenXa;

        public string strDM_TruongLienKetID = "DM_TruongLienKetID";
        public string strMaTruong = "MaTruong";
        public string strTenTruong = "TenTruong";
        public string strDiaChi = "DiaChi";
        public string strIDDM_TinhHuyenXa = "IDDM_TinhHuyenXa";

        public DM_TruongLienKetInfo()
        { }

        public int DM_TruongLienKetID{
        	set{ mDM_TruongLienKetID = value;}
        	get{ return mDM_TruongLienKetID;}
        }
        public string MaTruong{
        	set{ mMaTruong = value;}
        	get{ return mMaTruong;}
        }
        public string TenTruong{
        	set{ mTenTruong = value;}
        	get{ return mTenTruong;}
        }
        public string DiaChi{
        	set{ mDiaChi = value;}
        	get{ return mDiaChi;}
        }
        public int IDDM_TinhHuyenXa{
        	set{ mIDDM_TinhHuyenXa = value;}
        	get{ return mIDDM_TinhHuyenXa;}
        }
    }
}
