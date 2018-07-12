using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class NS_QuaTrinhKyLuatInfo
    {

        private int mNS_QuaTrinhKyLuatID;
        private int mIDNS_GiaoVien;
        private string mSoQuyetDinh;
        private DateTime mNgayQuyetDinh;
        private int mIDDM_CapKhenThuong;
        private string mNoiDung;
        private int mTangSoThangTangLuong;
        private DateTime mNgayCoHieuLuc;
        private DateTime mNgayHetHieuLuc;
        private bool mXoaKyLuat;
        private DateTime mNgayXoa;
        private string mLyDoXoa;
        private bool mXoaTangSoThangTangLuong;

        public string strNS_QuaTrinhKyLuatID = "NS_QuaTrinhKyLuatID";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strSoQuyetDinh = "SoQuyetDinh";
        public string strNgayQuyetDinh = "NgayQuyetDinh";
        public string strIDDM_CapKhenThuong = "IDDM_CapKhenThuong";
        public string strNoiDung = "NoiDung";
        public string strTangSoThangTangLuong = "TangSoThangTangLuong";
        public string strNgayCoHieuLuc = "NgayCoHieuLuc";
        public string strNgayHetHieuLuc = "NgayHetHieuLuc";
        public string strXoaKyLuat = "XoaKyLuat";
        public string strNgayXoa = "NgayXoa";
        public string strLyDoXoa = "LyDoXoa";
        public string strXoaTangSoThangTangLuong = "XoaTangSoThangTangLuong";

        public NS_QuaTrinhKyLuatInfo()
        { }

        public int NS_QuaTrinhKyLuatID{
        	set{ mNS_QuaTrinhKyLuatID = value;}
        	get{ return mNS_QuaTrinhKyLuatID;}
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
        }
        public string SoQuyetDinh{
        	set{ mSoQuyetDinh = value;}
        	get{ return mSoQuyetDinh;}
        }
        public DateTime NgayQuyetDinh{
        	set{ mNgayQuyetDinh = value;}
        	get{ return mNgayQuyetDinh;}
        }
        public int IDDM_CapKhenThuong{
        	set{ mIDDM_CapKhenThuong = value;}
        	get{ return mIDDM_CapKhenThuong;}
        }
        public string NoiDung{
        	set{ mNoiDung = value;}
        	get{ return mNoiDung;}
        }
        public int TangSoThangTangLuong{
        	set{ mTangSoThangTangLuong = value;}
        	get{ return mTangSoThangTangLuong;}
        }
        public DateTime NgayCoHieuLuc{
        	set{ mNgayCoHieuLuc = value;}
        	get{ return mNgayCoHieuLuc;}
        }
        public DateTime NgayHetHieuLuc{
        	set{ mNgayHetHieuLuc = value;}
        	get{ return mNgayHetHieuLuc;}
        }
        public bool XoaKyLuat{
            set { mXoaKyLuat = value; }
            get { return mXoaKyLuat; }
        }
        public DateTime NgayXoa{
            set { mNgayXoa = value; }
            get { return mNgayXoa; }
        }
        public string LyDoXoa{
            set { mLyDoXoa = value; }
            get { return mLyDoXoa; }
        }
        public bool XoaTangSoThangTangLuong{
            set { mXoaTangSoThangTangLuong = value; }
            get { return mXoaTangSoThangTangLuong; }
        }
    }
}
