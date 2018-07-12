using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_HoiDongMon_SinhVienInfo
    {

        private int mKQHT_HoiDongMon_SinhVienID;
        private int mIDKQHT_HoiDongMon;
        private int mIDSV_SinhVien;

        public string strKQHT_HoiDongMon_SinhVienID = "KQHT_HoiDongMon_SinhVienID";
        public string strIDKQHT_HoiDongMon = "IDKQHT_HoiDongMon";
        public string strIDSV_SinhVien = "IDSV_SinhVien";

        public KQHT_HoiDongMon_SinhVienInfo()
        { }

        public int KQHT_HoiDongMon_SinhVienID{
        	set{ mKQHT_HoiDongMon_SinhVienID = value;}
        	get{ return mKQHT_HoiDongMon_SinhVienID;}
        }
        public int IDKQHT_HoiDongMon{
        	set{ mIDKQHT_HoiDongMon = value;}
        	get{ return mIDKQHT_HoiDongMon;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
    }
}
