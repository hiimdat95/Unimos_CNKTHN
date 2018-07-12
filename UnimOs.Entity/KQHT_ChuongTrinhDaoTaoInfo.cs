using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_ChuongTrinhDaoTaoInfo
    {

        private int mKQHT_ChuongTrinhDaoTaoID;
        private string mMaChuongTrinhDaoTao;
        private string mTenChuongTrinhDaoTao;
        private int mIDDM_TrinhDo;
        private int mIDDM_Nganh;
        private int mIDDM_ChuyenNganh;
        private int mIDDM_KhoaHoc;
        private int mChuongTrinhDaoTaoSo;
        private int mSoHocKy;
        private string mMoTa;

        public string strKQHT_ChuongTrinhDaoTaoID = "KQHT_ChuongTrinhDaoTaoID";
        public string strMaChuongTrinhDaoTao = "MaChuongTrinhDaoTao";
        public string strTenChuongTrinhDaoTao = "TenChuongTrinhDaoTao";
        public string strIDDM_TrinhDo = "IDDM_TrinhDo";
        public string strIDDM_Nganh = "IDDM_Nganh";
        public string strIDDM_ChuyenNganh = "IDDM_ChuyenNganh";
        public string strIDDM_KhoaHoc = "IDDM_KhoaHoc";
        public string strChuongTrinhDaoTaoSo = "ChuongTrinhDaoTaoSo";
        public string strSoHocKy = "SoHocKy";
        public string strMoTa = "MoTa";

        public KQHT_ChuongTrinhDaoTaoInfo()
        { }

        public int KQHT_ChuongTrinhDaoTaoID{
        	set{ mKQHT_ChuongTrinhDaoTaoID = value;}
        	get{ return mKQHT_ChuongTrinhDaoTaoID;}
        }
        public string MaChuongTrinhDaoTao{
        	set{ mMaChuongTrinhDaoTao = value;}
        	get{ return mMaChuongTrinhDaoTao;}
        }
        public string TenChuongTrinhDaoTao{
        	set{ mTenChuongTrinhDaoTao = value;}
        	get{ return mTenChuongTrinhDaoTao;}
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
        public int IDDM_KhoaHoc{
        	set{ mIDDM_KhoaHoc = value;}
        	get{ return mIDDM_KhoaHoc;}
        }
        public int ChuongTrinhDaoTaoSo{
        	set{ mChuongTrinhDaoTaoSo = value;}
        	get{ return mChuongTrinhDaoTaoSo;}
        }
        public int SoHocKy{
        	set{ mSoHocKy = value;}
        	get{ return mSoHocKy;}
        }
        public string MoTa{
        	set{ mMoTa = value;}
        	get{ return mMoTa;}
        }
    }
}
