using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_DiemTongKetHocKyInfo
    {

        private int mKQHT_DiemTongKetHocKyID;
        private int mIDSV_SinhVien;
        private int mIDDM_NamHoc;
        private int mHocKy;
        private double mDiemL1;
        private int mIDDM_XepLoaiL1;
        private string mGhiChuL1;
        private double? mDiemL2;
        private int mIDDM_XepLoaiL2;
        private string mGhiChuL2;
        private int mTrangThai;

        public string strKQHT_DiemTongKetHocKyID = "KQHT_DiemTongKetHocKyID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strHocKy = "HocKy";
        public string strDiemL1 = "DiemL1";
        public string strIDDM_XepLoaiL1 = "IDDM_XepLoaiL1";
        public string strGhiChuL1 = "GhiChuL1";
        public string strDiemL2 = "DiemL2";
        public string strIDDM_XepLoaiL2 = "IDDM_XepLoaiL2";
        public string strGhiChuL2 = "GhiChuL2";
        public string strTrangThai = "TrangThai";

        public KQHT_DiemTongKetHocKyInfo()
        { }

        public int KQHT_DiemTongKetHocKyID
        {
            set { mKQHT_DiemTongKetHocKyID = value; }
            get { return mKQHT_DiemTongKetHocKyID; }
        }
        public int IDSV_SinhVien
        {
            set { mIDSV_SinhVien = value; }
            get { return mIDSV_SinhVien; }
        }
        public int IDDM_NamHoc
        {
            set { mIDDM_NamHoc = value; }
            get { return mIDDM_NamHoc; }
        }
        public int HocKy
        {
            set { mHocKy = value; }
            get { return mHocKy; }
        }
        public double DiemL1
        {
            set { mDiemL1 = value; }
            get { return mDiemL1; }
        }
        public int IDDM_XepLoaiL1
        {
            set { mIDDM_XepLoaiL1 = value; }
            get { return mIDDM_XepLoaiL1; }
        }
        public string GhiChuL1
        {
            set { mGhiChuL1 = value; }
            get { return mGhiChuL1; }
        }
        public double? DiemL2
        {
            set { mDiemL2 = value; }
            get { return mDiemL2; }
        }
        public int IDDM_XepLoaiL2
        {
            set { mIDDM_XepLoaiL2 = value; }
            get { return mIDDM_XepLoaiL2; }
        }
        public string GhiChuL2
        {
            set { mGhiChuL2 = value; }
            get { return mGhiChuL2; }
        }
        public int TrangThai
        {
            set { mTrangThai = value; }
            get { return mTrangThai; }
        }
    }
}
