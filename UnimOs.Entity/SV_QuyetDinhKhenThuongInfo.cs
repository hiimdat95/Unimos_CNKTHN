using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class SV_QuyetDinhKhenThuongInfo
    {

        private int mSV_QuyetDinhKhenThuongID;
        private int mIDDM_NamHoc;
        private int mHocKy;
        private string mSoQuyetDinh;
        private DateTime mNgayQuyetDinh;
        private int mIDDM_CapKhenThuong;
        private int mIDDM_LoaiKhenThuong;
        private string mNoiDung;

        public string strSV_QuyetDinhKhenThuongID = "SV_QuyetDinhKhenThuongID";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strHocKy = "HocKy";
        public string strSoQuyetDinh = "SoQuyetDinh";
        public string strNgayQuyetDinh = "NgayQuyetDinh";
        public string strIDDM_CapKhenThuong = "IDDM_CapKhenThuong";
        public string strIDDM_LoaiKhenThuong = "IDDM_LoaiKhenThuong";
        public string strNoiDung = "NoiDung";

        public SV_QuyetDinhKhenThuongInfo()
        { }

        public int SV_QuyetDinhKhenThuongID{
        	set{ mSV_QuyetDinhKhenThuongID = value;}
        	get{ return mSV_QuyetDinhKhenThuongID;}
        }
        public int IDDM_NamHoc{
        	set{ mIDDM_NamHoc = value;}
        	get{ return mIDDM_NamHoc;}
        }
        public int HocKy{
        	set{ mHocKy = value;}
        	get{ return mHocKy;}
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
        public int IDDM_LoaiKhenThuong{
        	set{ mIDDM_LoaiKhenThuong = value;}
        	get{ return mIDDM_LoaiKhenThuong;}
        }
        public string NoiDung{
        	set{ mNoiDung = value;}
        	get{ return mNoiDung;}
        }
    }
}
