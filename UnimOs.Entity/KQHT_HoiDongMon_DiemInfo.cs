using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_HoiDongMon_DiemInfo
    {

        private long mKQHT_HoiDongMon_DiemID;
        private int mIDKQHT_HoiDongMon_ChiTiet;
        private int mIDSV_SinhVien;
        private double mDiem;

        public string strKQHT_HoiDongMon_DiemID = "KQHT_HoiDongMon_DiemID";
        public string strIDKQHT_HoiDongMon_ChiTiet = "IDKQHT_HoiDongMon_ChiTiet";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strDiem = "Diem";

        public KQHT_HoiDongMon_DiemInfo()
        { }

        public long KQHT_HoiDongMon_DiemID{
        	set{ mKQHT_HoiDongMon_DiemID = value;}
        	get{ return mKQHT_HoiDongMon_DiemID;}
        }
        public int IDKQHT_HoiDongMon_ChiTiet{
        	set{ mIDKQHT_HoiDongMon_ChiTiet = value;}
        	get{ return mIDKQHT_HoiDongMon_ChiTiet;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
        public double Diem{
        	set{ mDiem = value;}
        	get{ return mDiem;}
        }
    }
}
