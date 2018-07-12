using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_KhoaHocInfo
    {

        private int mDM_KhoaHocID;
        private string mTenKhoaHoc;
        private int mIDDM_TrinhDo;
        private int mIDDM_Nganh;
        private int mIDDM_ChuyenNganh;
        private int mNamVaoTruong;
        private int mNamRaTruong;

        public string strDM_KhoaHocID = "DM_KhoaHocID";
        public string strTenKhoaHoc = "TenKhoaHoc";
        public string strIDDM_TrinhDo = "IDDM_TrinhDo";
        public string strIDDM_Nganh = "IDDM_Nganh";
        public string strIDDM_ChuyenNganh = "IDDM_ChuyenNganh";
        public string strNamVaoTruong = "NamVaoTruong";
        public string strNamRaTruong = "NamRaTruong";

        public DM_KhoaHocInfo()
        { }

        public int DM_KhoaHocID{
        	set{ mDM_KhoaHocID = value;}
        	get{ return mDM_KhoaHocID;}
        }
        public string TenKhoaHoc{
        	set{ mTenKhoaHoc = value;}
        	get{ return mTenKhoaHoc;}
        }
        public int IDDM_TrinhDo{
        	set{ mIDDM_TrinhDo = value;}
        	get{ return mIDDM_TrinhDo;}
        }
        public int IDDM_Nganh{
        	set{ mIDDM_Nganh = value;}
        	get{ return mIDDM_Nganh;}
        }
        public int IDDM_ChuyenNganh{
        	set{ mIDDM_ChuyenNganh = value;}
        	get{ return mIDDM_ChuyenNganh;}
        }
        public int NamVaoTruong{
        	set{ mNamVaoTruong = value;}
        	get{ return mNamVaoTruong;}
        }
        public int NamRaTruong{
        	set{ mNamRaTruong = value;}
        	get{ return mNamRaTruong;}
        }
    }
}
