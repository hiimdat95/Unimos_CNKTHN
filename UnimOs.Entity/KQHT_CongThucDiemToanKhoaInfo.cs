using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_CongThucDiemToanKhoaInfo
    {

        private int mKQHT_CongThucDiemToanKhoaID;
        private string mTenCongThucDiem;
        private string mCongThuc;
        private string mGhChu;

        public string strKQHT_CongThucDiemToanKhoaID = "KQHT_CongThucDiemToanKhoaID";
        public string strTenCongThucDiem = "TenCongThucDiem";
        public string strCongThuc = "CongThuc";
        public string strGhChu = "GhChu";

        public KQHT_CongThucDiemToanKhoaInfo()
        { }

        public int KQHT_CongThucDiemToanKhoaID{
        	set{ mKQHT_CongThucDiemToanKhoaID = value;}
        	get{ return mKQHT_CongThucDiemToanKhoaID;}
        }
        public string TenCongThucDiem{
        	set{ mTenCongThucDiem = value;}
        	get{ return mTenCongThucDiem;}
        }
        public string CongThuc{
        	set{ mCongThuc = value;}
        	get{ return mCongThuc;}
        }
        public string GhChu{
        	set{ mGhChu = value;}
        	get{ return mGhChu;}
        }
    }
}
