using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_DiemDanhInfo
    {

        private int mKQHT_DiemDanhID;
        private int mIDSV_SinhVien;
        private int mIDXL_MonHocTrongKy;
        private int? mCoLyDo;
        private int? mKhongLyDo;
        private int mDiemLan;

        public string strKQHT_DiemDanhID = "KQHT_DiemDanhID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strIDXL_MonHocTrongKy = "IDXL_MonHocTrongKy";
        public string strCoLyDo = "CoLyDo";
        public string strKhongLyDo = "KhongLyDo";
        public string strDiemLan = "DiemLan";

        public KQHT_DiemDanhInfo()
        { }

        public int KQHT_DiemDanhID
        {
            set { mKQHT_DiemDanhID = value; }
            get { return mKQHT_DiemDanhID; }
        }
        public int IDSV_SinhVien
        {
            set { mIDSV_SinhVien = value; }
            get { return mIDSV_SinhVien; }
        }
        public int IDXL_MonHocTrongKy
        {
            set { mIDXL_MonHocTrongKy = value; }
            get { return mIDXL_MonHocTrongKy; }
        }
        public int? CoLyDo
        {
            set { mCoLyDo = value; }
            get { return mCoLyDo; }
        }
        public int? KhongLyDo
        {
            set { mKhongLyDo = value; }
            get { return mKhongLyDo; }
        }
        public int DiemLan
        {
            set { mDiemLan = value; }
            get { return mDiemLan; }
        }
    }
}
