using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class TC_QuyHocBongInfo
    {

        private int mTC_QuyHocBongID;
        private int mIDDM_He;
        private int mIDDM_TrinhDo;
        private int mIDDM_LoaiQuy;
        private double mPhanTramHocPhi;
        private double mSoTien;
        private string mGhiChu;
        private bool mHetHan;

        public string strTC_QuyHocBongID = "TC_QuyHocBongID";
        public string strIDDM_He = "IDDM_He";
        public string strIDDM_TrinhDo = "IDDM_TrinhDo";
        public string strIDDM_LoaiQuy = "IDDM_LoaiQuy";
        public string strPhanTramHocPhi = "PhanTramHocPhi";
        public string strSoTien = "SoTien";
        public string strGhiChu = "GhiChu";
        public string strHetHan = "HetHan";

        public TC_QuyHocBongInfo()
        { }

        public int TC_QuyHocBongID{
        	set{ mTC_QuyHocBongID = value;}
        	get{ return mTC_QuyHocBongID;}
        }
        public int IDDM_He{
        	set{ mIDDM_He = value;}
        	get{ return mIDDM_He;}
        }
        public int IDDM_TrinhDo{
        	set{ mIDDM_TrinhDo = value;}
        	get{ return mIDDM_TrinhDo;}
        }
        public int IDDM_LoaiQuy{
        	set{ mIDDM_LoaiQuy = value;}
        	get{ return mIDDM_LoaiQuy;}
        }
        public double PhanTramHocPhi{
        	set{ mPhanTramHocPhi = value;}
        	get{ return mPhanTramHocPhi;}
        }
        public double SoTien{
        	set{ mSoTien = value;}
        	get{ return mSoTien;}
        }
        public string GhiChu{
        	set{ mGhiChu = value;}
        	get{ return mGhiChu;}
        }
        public bool HetHan{
        	set{ mHetHan = value;}
        	get{ return mHetHan;}
        }
    }
}
