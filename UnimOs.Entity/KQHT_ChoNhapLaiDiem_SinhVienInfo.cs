using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_ChoNhapLaiDiem_SinhVienInfo
    {

        private int mKQHT_ChoNhapLaiDiem_SinhVienID;
        private int mIDKQHT_ChoNhapLaiDiem;
        private int mIDSV_SinhVien;

        public string strKQHT_ChoNhapLaiDiem_SinhVienID = "KQHT_ChoNhapLaiDiem_SinhVienID";
        public string strIDKQHT_ChoNhapLaiDiem = "IDKQHT_ChoNhapLaiDiem";
        public string strIDSV_SinhVien = "IDSV_SinhVien";

        public KQHT_ChoNhapLaiDiem_SinhVienInfo()
        { }

        public int KQHT_ChoNhapLaiDiem_SinhVienID{
        	set{ mKQHT_ChoNhapLaiDiem_SinhVienID = value;}
        	get{ return mKQHT_ChoNhapLaiDiem_SinhVienID;}
        }
        public int IDKQHT_ChoNhapLaiDiem{
        	set{ mIDKQHT_ChoNhapLaiDiem = value;}
        	get{ return mIDKQHT_ChoNhapLaiDiem;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
    }
}
