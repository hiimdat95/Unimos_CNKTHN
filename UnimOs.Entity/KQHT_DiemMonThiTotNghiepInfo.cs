using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_DiemMonThiTotNghiepInfo
    {

        private long mKQHT_DiemMonThiTotNghiepID;
        private int mIDSV_SinhVien;
        private int mIDKQHT_MonThiTotNghiep_Lop;
        private int mLanThi;
        private double mDiem;
        private int? mIDKQHT_XepLoai;

        public string strKQHT_DiemMonThiTotNghiepID = "KQHT_DiemMonThiTotNghiepID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strIDKQHT_MonThiTotNghiep_Lop = "IDKQHT_MonThiTotNghiep_Lop";
        public string strLanThi = "LanThi";
        public string strDiem = "Diem";
        public string strIDKQHT_XepLoai = "IDKQHT_XepLoai";

        public KQHT_DiemMonThiTotNghiepInfo()
        { }

        public long KQHT_DiemMonThiTotNghiepID{
        	set{ mKQHT_DiemMonThiTotNghiepID = value;}
        	get{ return mKQHT_DiemMonThiTotNghiepID;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
        public int IDKQHT_MonThiTotNghiep_Lop{
        	set{ mIDKQHT_MonThiTotNghiep_Lop = value;}
        	get{ return mIDKQHT_MonThiTotNghiep_Lop;}
        }
        public int LanThi{
        	set{ mLanThi = value;}
        	get{ return mLanThi;}
        }
        public double Diem{
        	set{ mDiem = value;}
        	get{ return mDiem;}
        }
        public int? IDKQHT_XepLoai{
        	set{ mIDKQHT_XepLoai = value;}
        	get{ return mIDKQHT_XepLoai;}
        }
    }
}
