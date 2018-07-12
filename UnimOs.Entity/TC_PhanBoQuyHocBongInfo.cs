using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class TC_PhanBoQuyHocBongInfo
    {

        private int mTC_PhanBoQuyHocBongID;
        private int mIDDM_NamHoc;
        private int mHocKy;
        private int mIDTC_QuyHocBong;
        private int mIDDM_Khoa;
        private int mIDDM_KhoaHoc;
        private int mIDDM_Nganh;
        private int mIDDM_Lop;
        private int mSoSinhVien;
        private double mSoTien;
        private bool mPhanDacBiet;

        public string strTC_PhanBoQuyHocBongID = "TC_PhanBoQuyHocBongID";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strHocKy = "HocKy";
        public string strIDTC_QuyHocBong = "IDTC_QuyHocBong";
        public string strIDDM_Khoa = "IDDM_Khoa";
        public string strIDDM_KhoaHoc = "IDDM_KhoaHoc";
        public string strIDDM_Nganh = "IDDM_Nganh";
        public string strIDDM_Lop = "IDDM_Lop";
        public string strSoSinhVien = "SoSinhVien";
        public string strSoTien = "SoTien";
        public string strPhanDacBiet = "PhanDacBiet";

        public TC_PhanBoQuyHocBongInfo()
        { }

        public int TC_PhanBoQuyHocBongID{
        	set{ mTC_PhanBoQuyHocBongID = value;}
        	get{ return mTC_PhanBoQuyHocBongID;}
        }
        public int IDDM_NamHoc{
        	set{ mIDDM_NamHoc = value;}
        	get{ return mIDDM_NamHoc;}
        }
        public int HocKy{
        	set{ mHocKy = value;}
        	get{ return mHocKy;}
        }
        public int IDTC_QuyHocBong{
        	set{ mIDTC_QuyHocBong = value;}
        	get{ return mIDTC_QuyHocBong;}
        }
        public int IDDM_Khoa{
        	set{ mIDDM_Khoa = value;}
        	get{ return mIDDM_Khoa;}
        }
        public int IDDM_KhoaHoc{
        	set{ mIDDM_KhoaHoc = value;}
        	get{ return mIDDM_KhoaHoc;}
        }
        public int IDDM_Nganh{
        	set{ mIDDM_Nganh = value;}
        	get{ return mIDDM_Nganh;}
        }
        public int IDDM_Lop{
        	set{ mIDDM_Lop = value;}
        	get{ return mIDDM_Lop;}
        }
        public int SoSinhVien{
        	set{ mSoSinhVien = value;}
        	get{ return mSoSinhVien;}
        }
        public double SoTien{
        	set{ mSoTien = value;}
        	get{ return mSoTien;}
        }
        public bool PhanDacBiet{
        	set{ mPhanDacBiet = value;}
        	get{ return mPhanDacBiet;}
        }
    }
}
