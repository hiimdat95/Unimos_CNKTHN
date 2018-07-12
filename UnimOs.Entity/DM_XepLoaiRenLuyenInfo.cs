using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_XepLoaiRenLuyenInfo
    {

        private int mDM_XepLoaiRenLuyenID;
        private string mKyHieu;
        private string mTenXepLoaiRenLuyen;
        private int mTuDiem;
        private double mDiemCongXetHocBong;

        public string strDM_XepLoaiRenLuyenID = "DM_XepLoaiRenLuyenID";
        public string strKyHieu = "KyHieu";
        public string strTenXepLoaiRenLuyen = "TenXepLoaiRenLuyen";
        public string strTuDiem = "TuDiem";
        public string strDiemCongXetHocBong = "DiemCongXetHocBong";

        public DM_XepLoaiRenLuyenInfo()
        { }

        public int DM_XepLoaiRenLuyenID{
        	set{ mDM_XepLoaiRenLuyenID = value;}
        	get{ return mDM_XepLoaiRenLuyenID;}
        }
        public string KyHieu{
        	set{ mKyHieu = value;}
        	get{ return mKyHieu;}
        }
        public string TenXepLoaiRenLuyen{
        	set{ mTenXepLoaiRenLuyen = value;}
        	get{ return mTenXepLoaiRenLuyen;}
        }
        public int TuDiem{
        	set{ mTuDiem = value;}
        	get{ return mTuDiem;}
        }
        public double DiemCongXetHocBong{
        	set{ mDiemCongXetHocBong = value;}
        	get{ return mDiemCongXetHocBong;}
        }
    }
}
