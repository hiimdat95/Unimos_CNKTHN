using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_DiemTongKetToanKhoaInfo
    {

        private long mKQHT_DiemTongKetToanKhoaID;
        private int mIDSV_SinhVien;
        private double mDiem;
        private double mDiemTHXL;
        private int mIDDM_XepLoai;
        private string mGhiChu;
        private double mDiemTBMH;
        private bool mLanCuoi;
        private int mLanThi;
        private int mIDDM_NamHoc;
        private string mSoBang;
        private int mIDDM_NamTruong;

        public string strKQHT_DiemTongKetToanKhoaID = "KQHT_DiemTongKetToanKhoaID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strDiem = "Diem";
        public string strDiemTHXL = "DiemTHXL";
        public string strIDDM_XepLoai = "IDDM_XepLoai";
        public string strGhiChu = "GhiChu";
        public string strDiemTBMH = "DiemTBMH";
        public string strLanCuoi = "LanCuoi";
        public string strLanThi = "LanThi";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strSoBang = "SoBang";
        public string strIDDM_NamTruong = "IDDM_NamTruong";

        public KQHT_DiemTongKetToanKhoaInfo()
        { }

        public long KQHT_DiemTongKetToanKhoaID{
        	set{ mKQHT_DiemTongKetToanKhoaID = value;}
        	get{ return mKQHT_DiemTongKetToanKhoaID;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
        public double Diem{
        	set{ mDiem = value;}
        	get{ return mDiem;}
        }
        public double DiemTHXL
        {
            set { mDiemTHXL = value; }
            get { return mDiemTHXL; }
        }
        public int IDDM_XepLoai{
        	set{ mIDDM_XepLoai = value;}
        	get{ return mIDDM_XepLoai;}
        }
        public string GhiChu{
        	set{ mGhiChu = value;}
        	get{ return mGhiChu;}
        }
        public double DiemTBMH{
        	set{ mDiemTBMH = value;}
        	get{ return mDiemTBMH;}
        }
        public bool LanCuoi{
        	set{ mLanCuoi = value;}
        	get{ return mLanCuoi;}
        }
        public int LanThi{
        	set{ mLanThi = value;}
        	get{ return mLanThi;}
        }
        public int IDDM_NamHoc{
        	set{ mIDDM_NamHoc = value;}
        	get{ return mIDDM_NamHoc;}
        }
        public string SoBang{
        	set{ mSoBang = value;}
        	get{ return mSoBang;}
        }
        public int IDDM_NamTruong{
        	set{ mIDDM_NamTruong = value;}
        	get{ return mIDDM_NamTruong;}
        }
    }
}
