using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_CongThucDiem_ThanhPhanDiemInfo
    {

        private int mKQHT_CongThucDiem_ThanhPhanDiemID;
        private int mIDKQHT_CongThucDiem;
        private int mIDKQHT_ThanhPhanDiem;

        public string strKQHT_CongThucDiem_ThanhPhanDiemID = "KQHT_CongThucDiem_ThanhPhanDiemID";
        public string strIDKQHT_CongThucDiem = "IDKQHT_CongThucDiem";
        public string strIDKQHT_ThanhPhanDiem = "IDKQHT_ThanhPhanDiem";

        public KQHT_CongThucDiem_ThanhPhanDiemInfo()
        { }

        public int KQHT_CongThucDiem_ThanhPhanDiemID{
        	set{ mKQHT_CongThucDiem_ThanhPhanDiemID = value;}
        	get{ return mKQHT_CongThucDiem_ThanhPhanDiemID;}
        }
        public int IDKQHT_CongThucDiem{
        	set{ mIDKQHT_CongThucDiem = value;}
        	get{ return mIDKQHT_CongThucDiem;}
        }
        public int IDKQHT_ThanhPhanDiem{
        	set{ mIDKQHT_ThanhPhanDiem = value;}
        	get{ return mIDKQHT_ThanhPhanDiem;}
        }
    }
}
