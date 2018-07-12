using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_ThanhPhanDiemBatBuocInfo
    {

        private int mKQHT_ThanhPhanDiemBatBuocID;
        private int mIDKQHT_ThanhPhanDiem;
        private int mSoHocTrinh;
        private int mSoTiet;
        private int mSoDiemBatBuoc;

        public string strKQHT_ThanhPhanDiemBatBuocID = "KQHT_ThanhPhanDiemBatBuocID";
        public string strIDKQHT_ThanhPhanDiem = "IDKQHT_ThanhPhanDiem";
        public string strSoHocTrinh = "SoHocTrinh";
        public string strSoTiet = "SoTiet";
        public string strSoDiemBatBuoc = "SoDiemBatBuoc";

        public KQHT_ThanhPhanDiemBatBuocInfo()
        { }

        public int KQHT_ThanhPhanDiemBatBuocID{
        	set{ mKQHT_ThanhPhanDiemBatBuocID = value;}
        	get{ return mKQHT_ThanhPhanDiemBatBuocID;}
        }
        public int IDKQHT_ThanhPhanDiem{
        	set{ mIDKQHT_ThanhPhanDiem = value;}
        	get{ return mIDKQHT_ThanhPhanDiem;}
        }
        public int SoHocTrinh{
        	set{ mSoHocTrinh = value;}
        	get{ return mSoHocTrinh;}
        }
        public int SoTiet{
        	set{ mSoTiet = value;}
        	get{ return mSoTiet;}
        }
        public int SoDiemBatBuoc{
        	set{ mSoDiemBatBuoc = value;}
        	get{ return mSoDiemBatBuoc;}
        }
    }
}
