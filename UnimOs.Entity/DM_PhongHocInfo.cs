using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class DM_PhongHocInfo
    {
        private int mDM_PhongHocID;
        private string mTenPhongHoc;
        private int mIDDM_ToaNha;
        private int mIDDM_Tang;
        private int mSucChua;
        private int mIDDM_LoaiPhong;
        private TKBInfo mTKB;

        public string strDM_PhongHocID = "DM_PhongHocID";
        public string strTenPhongHoc = "TenPhongHoc";
        public string strIDDM_ToaNha = "IDDM_ToaNha";
        public string strIDDM_Tang = "IDDM_Tang";
        public string strSucChua = "SucChua";
        public string strIDDM_LoaiPhong = "IDDM_LoaiPhong";

        public DM_PhongHocInfo()
        { }

        public DM_PhongHocInfo(int PhongHocID, string TenPhongHoc, int IDToaNha, int IDDM_Tang, int SucChua, HT_ThamSoXepLichInfo pThamSoTKB)
        {
            mTKB = new TKBInfo(pThamSoTKB);
            mDM_PhongHocID = PhongHocID;
            mTenPhongHoc = TenPhongHoc;
            mIDDM_ToaNha = IDToaNha;
            mIDDM_Tang = IDDM_Tang;
            mSucChua = SucChua;
        }

        public int DM_PhongHocID{
        	set{ mDM_PhongHocID = value;}
        	get{ return mDM_PhongHocID;}
        }
        public string TenPhongHoc{
        	set{ mTenPhongHoc = value;}
        	get{ return mTenPhongHoc;}
        }
        public int IDDM_ToaNha{
        	set{ mIDDM_ToaNha = value;}
        	get{ return mIDDM_ToaNha;}
        }
        public int IDDM_Tang{
        	set{ mIDDM_Tang = value;}
        	get{ return mIDDM_Tang;}
        }
        public int SucChua{
        	set{ mSucChua = value;}
        	get{ return mSucChua;}
        }
        public int IDDM_LoaiPhong{
        	set{ mIDDM_LoaiPhong = value;}
        	get{ return mIDDM_LoaiPhong;}
        }
        public TKBInfo TKB
        {
            get { return mTKB; }
            set { mTKB = value; }
        }
    }
}
