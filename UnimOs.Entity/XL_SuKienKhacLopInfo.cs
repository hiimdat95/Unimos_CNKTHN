using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class XL_SuKienKhacLopInfo
    {
        int mID;
        int mIDLop;
        string mTenLop;
        int mThu;
        int mTiet;
        int mSoTiet;
        string mMoTa;

        public XL_SuKienKhacLopInfo()
        {
            mID = -1;
            mIDLop = -1;
            mTenLop = "";
            mThu = -1;
            mTiet = -1;
            mSoTiet = 0;
            mMoTa = "";
        }

        public XL_SuKienKhacLopInfo(int ID, int IDLop, string TenLop, int Thu, int Tiet, int SoTiet, string MoTa)
        {
            mID = ID;
            mIDLop = IDLop;
            mTenLop = TenLop;
            mThu = Thu;
            mTiet = Tiet;
            mSoTiet = SoTiet;
            mMoTa = MoTa;
        }

        public int ID
        {
            set { mID = value; }
            get { return mID; }
        }
        public int IDLop
        {
            set { mIDLop = value; }
            get { return mIDLop; }
        }
        public string TenLop
        {
            set { mTenLop = value; }
            get { return mTenLop; }
        }
        public int Thu
        {
            set { mThu = value; }
            get { return mThu; }
        }
        public int Tiet
        {
            set { mTiet = value; }
            get { return mTiet; }
        }
        public int SoTiet
        {
            set { mSoTiet = value; }
            get { return mSoTiet; }
        }
        public string MoTa
        {
            set { mMoTa = value; }
            get { return mMoTa; }
        }
    }
}
