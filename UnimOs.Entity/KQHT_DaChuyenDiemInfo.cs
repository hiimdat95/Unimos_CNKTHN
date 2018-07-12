using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_DaChuyenDiemInfo
    {
        private long mKQHT_DaChuyenDiemID;
        private int mIDXL_MonHocTrongKy;
        private bool mDaNhapDiemThanhPhan;
        private DateTime mNgayChuyenDiemThanhPhan;
        private int mIDNS_GiaoVienChuyenDiemTP;
        private bool mDaNhapDiemThiL1;
        private DateTime mNgayChuyenDiemThiL1;
        private int mIDNS_GiaoVienChuyenDiemThiL1;
        private bool mDaNhapDiemThiL2;
        private DateTime mNgayChuyenDiemThiL2;
        private int mIDNS_GiaoVienChuyenDiemThiL2;
        private bool mDaNhapDiemThanhPhanL2;
        private DateTime mNgayChuyenDiemThanhPhanL2;
        private int mIDNS_GiaoVienChuyenDiemTPL2;

        public string strKQHT_DaChuyenDiemID = "KQHT_DaChuyenDiemID";
        public string strIDXL_MonHocTrongKy = "IDXL_MonHocTrongKy";
        public string strDaNhapDiemThanhPhan = "DaNhapDiemThanhPhan";
        public string strNgayChuyenDiemThanhPhan = "NgayChuyenDiemThanhPhan";
        public string strIDNS_GiaoVienChuyenDiemTP = "IDNS_GiaoVienChuyenDiemTP";
        public string strDaNhapDiemThiL1 = "DaNhapDiemThiL1";
        public string strNgayChuyenDiemThiL1 = "NgayChuyenDiemThiL1";
        public string strIDNS_GiaoVienChuyenDiemThiL1 = "IDNS_GiaoVienChuyenDiemThiL1";
        public string strDaNhapDiemThiL2 = "DaNhapDiemThiL2";
        public string strNgayChuyenDiemThiL2 = "NgayChuyenDiemThiL2";
        public string strIDNS_GiaoVienChuyenDiemThiL2 = "IDNS_GiaoVienChuyenDiemThiL2";
        public string strDaNhapDiemThanhPhanL2 = "DaNhapDiemThanhPhanL2";
        public string strNgayChuyenDiemThanhPhanL2 = "NgayChuyenDiemThanhPhanL2";
        public string strIDNS_GiaoVienChuyenDiemTPL2 = "IDNS_GiaoVienChuyenDiemTPL2";

        public KQHT_DaChuyenDiemInfo()
        { }

        public long KQHT_DaChuyenDiemID
        {
            set { mKQHT_DaChuyenDiemID = value; }
            get { return mKQHT_DaChuyenDiemID; }
        }
        public int IDXL_MonHocTrongKy
        {
            set { mIDXL_MonHocTrongKy = value; }
            get { return mIDXL_MonHocTrongKy; }
        }
        public bool DaNhapDiemThanhPhan
        {
            set { mDaNhapDiemThanhPhan = value; }
            get { return mDaNhapDiemThanhPhan; }
        }
        public DateTime NgayChuyenDiemThanhPhan
        {
            set { mNgayChuyenDiemThanhPhan = value; }
            get { return mNgayChuyenDiemThanhPhan; }
        }
        public int IDNS_GiaoVienChuyenDiemTP
        {
            set { mIDNS_GiaoVienChuyenDiemTP = value; }
            get { return mIDNS_GiaoVienChuyenDiemTP; }
        }
        public bool DaNhapDiemThiL1
        {
            set { mDaNhapDiemThiL1 = value; }
            get { return mDaNhapDiemThiL1; }
        }
        public DateTime NgayChuyenDiemThiL1
        {
            set { mNgayChuyenDiemThiL1 = value; }
            get { return mNgayChuyenDiemThiL1; }
        }
        public int IDNS_GiaoVienChuyenDiemThiL1
        {
            set { mIDNS_GiaoVienChuyenDiemThiL1 = value; }
            get { return mIDNS_GiaoVienChuyenDiemThiL1; }
        }
        public bool DaNhapDiemThiL2
        {
            set { mDaNhapDiemThiL2 = value; }
            get { return mDaNhapDiemThiL2; }
        }
        public DateTime NgayChuyenDiemThiL2
        {
            set { mNgayChuyenDiemThiL2 = value; }
            get { return mNgayChuyenDiemThiL2; }
        }
        public int IDNS_GiaoVienChuyenDiemThiL2
        {
            set { mIDNS_GiaoVienChuyenDiemThiL2 = value; }
            get { return mIDNS_GiaoVienChuyenDiemThiL2; }
        }
        public bool DaNhapDiemThanhPhanL2
        {
            set { mDaNhapDiemThanhPhanL2 = value; }
            get { return mDaNhapDiemThanhPhanL2; }
        }
        public DateTime NgayChuyenDiemThanhPhanL2
        {
            set { mNgayChuyenDiemThanhPhanL2 = value; }
            get { return mNgayChuyenDiemThanhPhanL2; }
        }
        public int IDNS_GiaoVienChuyenDiemTPL2
        {
            set { mIDNS_GiaoVienChuyenDiemTPL2 = value; }
            get { return mIDNS_GiaoVienChuyenDiemTPL2; }
        }
    }
}
