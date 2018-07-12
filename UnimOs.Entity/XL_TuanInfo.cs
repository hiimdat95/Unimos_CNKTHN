using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class XL_TuanInfo
    {

        private long mXL_TuanID;
        private int mIDDM_NamHoc;
        private int mTuanThu;
        private DateTime mTuNgay;
        private DateTime mDenNgay;
        private bool mChoPhepXemLich;
        private int mHocKy;

        public string strXL_TuanID = "XL_TuanID";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strTuanThu = "TuanThu";
        public string strTuNgay = "TuNgay";
        public string strDenNgay = "DenNgay";
        public string strChoPhepXemLich = "ChoPhepXemLich";
        public string strHocKy = "HocKy";

        public XL_TuanInfo()
        { }

        public long XL_TuanID{
        	set{ mXL_TuanID = value;}
        	get{ return mXL_TuanID;}
        }
        public int IDDM_NamHoc{
        	set{ mIDDM_NamHoc = value;}
        	get{ return mIDDM_NamHoc;}
        }
        public int TuanThu{
        	set{ mTuanThu = value;}
        	get{ return mTuanThu;}
        }
        public DateTime TuNgay{
        	set{ mTuNgay = value;}
        	get{ return mTuNgay;}
        }
        public DateTime DenNgay{
        	set{ mDenNgay = value;}
        	get{ return mDenNgay;}
        }
        public bool ChoPhepXemLich{
        	set{ mChoPhepXemLich = value;}
        	get{ return mChoPhepXemLich;}
        }
        public int HocKy{
        	set{ mHocKy = value;}
        	get{ return mHocKy;}
        }
    }
}
