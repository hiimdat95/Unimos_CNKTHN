using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_ChoNhapLaiDiemInfo
    {

        private int mKQHT_ChoNhapLaiDiemID;
        private int mIDKQHT_DaChuyenDiem;
        private int mIDHT_User;
        private int mLanChoNhapLai;
        private DateTime mNgayChoNhapLai;
        private bool mDiemThanhPhan_L1;
        private bool mDiemThi_L1;
        private bool mDiemThanhPhan_L2;
        private bool mDiemThi_L2;

        public string strKQHT_ChoNhapLaiDiemID = "KQHT_ChoNhapLaiDiemID";
        public string strIDKQHT_DaChuyenDiem = "IDKQHT_DaChuyenDiem";
        public string strIDHT_User = "IDHT_User";
        public string strLanChoNhapLai = "LanChoNhapLai";
        public string strNgayChoNhapLai = "NgayChoNhapLai";
        public string strDiemThanhPhan_L1 = "DiemThanhPhan_L1";
        public string strDiemThi_L1 = "DiemThi_L1";
        public string strDiemThanhPhan_L2 = "DiemThanhPhan_L2";
        public string strDiemThi_L2 = "DiemThi_L2";

        public KQHT_ChoNhapLaiDiemInfo()
        { }

        public int KQHT_ChoNhapLaiDiemID{
        	set{ mKQHT_ChoNhapLaiDiemID = value;}
        	get{ return mKQHT_ChoNhapLaiDiemID;}
        }
        public int IDKQHT_DaChuyenDiem{
        	set{ mIDKQHT_DaChuyenDiem = value;}
        	get{ return mIDKQHT_DaChuyenDiem;}
        }
        public int IDHT_User{
        	set{ mIDHT_User = value;}
        	get{ return mIDHT_User;}
        }
        public int LanChoNhapLai{
        	set{ mLanChoNhapLai = value;}
        	get{ return mLanChoNhapLai;}
        }
        public DateTime NgayChoNhapLai{
        	set{ mNgayChoNhapLai = value;}
        	get{ return mNgayChoNhapLai;}
        }
        public bool DiemThanhPhan_L1{
        	set{ mDiemThanhPhan_L1 = value;}
        	get{ return mDiemThanhPhan_L1;}
        }
        public bool DiemThi_L1{
        	set{ mDiemThi_L1 = value;}
        	get{ return mDiemThi_L1;}
        }
        public bool DiemThanhPhan_L2{
        	set{ mDiemThanhPhan_L2 = value;}
        	get{ return mDiemThanhPhan_L2;}
        }
        public bool DiemThi_L2{
        	set{ mDiemThi_L2 = value;}
        	get{ return mDiemThi_L2;}
        }
    }
}
