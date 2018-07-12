using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class XL_TietNghiCoDinhLopInfo
    {

        private int mXL_TietNghiCoDinhLopID;
        private int mIDDM_Lop;
        private int mThu;
        private int mTiet;
        private bool mNghi;
        private string mMoTa;
        private int mCaHoc;

        public string strXL_TietNghiCoDinhLopID = "XL_TietNghiCoDinhLopID";
        public string strIDDM_Lop = "IDDM_Lop";
        public string strThu = "Thu";
        public string strTiet = "Tiet";
        public string strNghi = "Nghi";
        public string strMoTa = "MoTa";
        public string strCaHoc = "CaHoc";

        public XL_TietNghiCoDinhLopInfo()
        { }

        public int XL_TietNghiCoDinhLopID{
        	set{ mXL_TietNghiCoDinhLopID = value;}
        	get{ return mXL_TietNghiCoDinhLopID;}
        }
        public int IDDM_Lop{
        	set{ mIDDM_Lop = value;}
        	get{ return mIDDM_Lop;}
        }
        public int Thu{
        	set{ mThu = value;}
        	get{ return mThu;}
        }
        public int Tiet{
        	set{ mTiet = value;}
        	get{ return mTiet;}
        }
        public bool Nghi{
        	set{ mNghi = value;}
        	get{ return mNghi;}
        }
        public string MoTa{
        	set{ mMoTa = value;}
        	get{ return mMoTa;}
        }
        public int CaHoc{
        	set{ mCaHoc = value;}
        	get{ return mCaHoc;}
        }
    }
}
