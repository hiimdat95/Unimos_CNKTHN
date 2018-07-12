using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class XL_KeHoachThucHanhKyHieuInfo
    {

        private int mXL_KeHoachThucHanhKyHieuID;
        private int mIDDM_MonHoc;
        private string mKyHieu;
        private int mMauChu;
        private int mMauNen;

        public string strXL_KeHoachThucHanhKyHieuID = "XL_KeHoachThucHanhKyHieuID";
        public string strIDDM_MonHoc = "IDDM_MonHoc";
        public string strKyHieu = "KyHieu";
        public string strMauChu = "MauChu";
        public string strMauNen = "MauNen";

        public XL_KeHoachThucHanhKyHieuInfo()
        { }

        public int XL_KeHoachThucHanhKyHieuID{
        	set{ mXL_KeHoachThucHanhKyHieuID = value;}
        	get{ return mXL_KeHoachThucHanhKyHieuID;}
        }
        public int IDDM_MonHoc{
        	set{ mIDDM_MonHoc = value;}
        	get{ return mIDDM_MonHoc;}
        }
        public string KyHieu{
        	set{ mKyHieu = value;}
        	get{ return mKyHieu;}
        }
        public int MauChu{
        	set{ mMauChu = value;}
        	get{ return mMauChu;}
        }
        public int MauNen{
        	set{ mMauNen = value;}
        	get{ return mMauNen;}
        }
    }
}
