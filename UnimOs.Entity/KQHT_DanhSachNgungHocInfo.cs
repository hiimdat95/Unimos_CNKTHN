using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_DanhSachNgungHocInfo
    {

        private int mKQHT_DanhSachNgungHocID;
        private int mIDSV_SinhVien;
        private int mIDDM_NamHoc;
        private int mHocKy;
        private string mSoQuyetDinh;
        private DateTime mNgayQuyetDinh;
        private string mNoiDung;
        private int mIDDM_LopCu;
        private int mTrangThai;

        public string strKQHT_DanhSachNgungHocID = "KQHT_DanhSachNgungHocID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strHocKy = "HocKy";
        public string strSoQuyetDinh = "SoQuyetDinh";
        public string strNgayQuyetDinh = "NgayQuyetDinh";
        public string strNoiDung = "NoiDung";
        public string strIDDM_LopCu = "IDDM_LopCu";
        public string strTrangThai = "TrangThai";

        public KQHT_DanhSachNgungHocInfo()
        { }

        public int KQHT_DanhSachNgungHocID{
        	set{ mKQHT_DanhSachNgungHocID = value;}
        	get{ return mKQHT_DanhSachNgungHocID;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
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
        public string NoiDung{
        	set{ mNoiDung = value;}
        	get{ return mNoiDung;}
        }
        public int IDDM_LopCu{
        	set{ mIDDM_LopCu = value;}
        	get{ return mIDDM_LopCu;}
        }
        public int  TrangThai
        {
        	set{ mTrangThai = value;}
        	get{ return mTrangThai;}
        }
    }
}
