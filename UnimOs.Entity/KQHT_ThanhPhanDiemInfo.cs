using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_ThanhPhanDiemInfo
    {

        private int mKQHT_ThanhPhanDiemID;
        private int mIDDM_TrinhDo;
        private string mKyHieu;
        private string mTenThanhPhan;
        private int mSoDiem;
        private bool mThi;
        private int? mSoLanThi;
        private int? mSTT;

        public string strKQHT_ThanhPhanDiemID = "KQHT_ThanhPhanDiemID";
        public string strIDDM_TrinhDo = "IDDM_TrinhDo";
        public string strKyHieu = "KyHieu";
        public string strTenThanhPhan = "TenThanhPhan";
        public string strSoDiem = "SoDiem";
        public string strThi = "Thi";
        public string strSoLanThi = "SoLanThi";
        public string strSTT = "STT";

        public KQHT_ThanhPhanDiemInfo()
        { }

        public int KQHT_ThanhPhanDiemID
        {
            set { mKQHT_ThanhPhanDiemID = value; }
            get { return mKQHT_ThanhPhanDiemID; }
        }
        public int IDDM_TrinhDo
        {
            set { mIDDM_TrinhDo = value; }
            get { return mIDDM_TrinhDo; }
        }
        public string KyHieu
        {
            set { mKyHieu = value; }
            get { return mKyHieu; }
        }
        public string TenThanhPhan
        {
            set { mTenThanhPhan = value; }
            get { return mTenThanhPhan; }
        }
        public int SoDiem
        {
            set { mSoDiem = value; }
            get { return mSoDiem; }
        }
        public bool Thi
        {
            set { mThi = value; }
            get { return mThi; }
        }
        public int? SoLanThi
        {
            set { mSoLanThi = value; }
            get { return mSoLanThi; }
        }
        public int? STT
        {
            set { mSTT = value; }
            get { return mSTT; }
        }
    }
}
