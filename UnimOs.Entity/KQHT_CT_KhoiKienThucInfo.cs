using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_CT_KhoiKienThucInfo
    {

        private int mKQHT_CT_KhoiKienThucID;
        private string mTenCT_KhoiKienThuc;
        private int mIDDM_TrinhDo;
        private int mIDDM_Nganh;
        private int mIDDM_ChuyenNganh;
        private int mIDDM_KhoaHoc;
        private int mIDDM_KhoiKienThuc;
        private int mCT_KhoiKienThucSo;
        private int mTongSoHocTrinh;
        private int mTongSoMon;
        private string mMoTa;

        public string strKQHT_CT_KhoiKienThucID = "KQHT_CT_KhoiKienThucID";
        public string strTenCT_KhoiKienThuc = "TenCT_KhoiKienThuc";
        public string strIDDM_TrinhDo = "IDDM_TrinhDo";
        public string strIDDM_Nganh = "IDDM_Nganh";
        public string strIDDM_ChuyenNganh = "IDDM_ChuyenNganh";
        public string strIDDM_KhoaHoc = "IDDM_KhoaHoc";
        public string strIDDM_KhoiKienThuc = "IDDM_KhoiKienThuc";
        public string strCT_KhoiKienThucSo = "CT_KhoiKienThucSo";
        public string strTongSoHocTrinh = "TongSoHocTrinh";
        public string strTongSoMon = "TongSoMon";
        public string strMoTa = "MoTa";

        public KQHT_CT_KhoiKienThucInfo()
        { }

        public int KQHT_CT_KhoiKienThucID{
        	set{ mKQHT_CT_KhoiKienThucID = value;}
        	get{ return mKQHT_CT_KhoiKienThucID;}
        }
        public string TenCT_KhoiKienThuc{
        	set{ mTenCT_KhoiKienThuc = value;}
        	get{ return mTenCT_KhoiKienThuc;}
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
        public int IDDM_KhoiKienThuc{
        	set{ mIDDM_KhoiKienThuc = value;}
        	get{ return mIDDM_KhoiKienThuc;}
        }
        public int CT_KhoiKienThucSo{
        	set{ mCT_KhoiKienThucSo = value;}
        	get{ return mCT_KhoiKienThucSo;}
        }
        public int TongSoHocTrinh{
        	set{ mTongSoHocTrinh = value;}
        	get{ return mTongSoHocTrinh;}
        }
        public int TongSoMon{
        	set{ mTongSoMon = value;}
        	get{ return mTongSoMon;}
        }
        public string MoTa{
        	set{ mMoTa = value;}
        	get{ return mMoTa;}
        }
    }
}
