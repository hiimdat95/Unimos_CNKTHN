using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class SV_DiemRenLuyenInfo
    {

        private int mSV_DiemRenLuyenID;
        private int mIDSV_SinhVien;
        private int mIDDM_NamHoc;
        private double mSoDiemKy1;
        private int mIDDM_XepLoaiRenLuyenKy1;
        private string mNhanXetKy1;
        private double mSoDiemKy2;
        private int mIDDM_XepLoaiRenLuyenKy2;
        private string mNhanXetKy2;
        private double mSoDiemCaNam;
        private int mIDDM_XepLoaiRenLuyenCaNam;
        private string mNhanXetCaNam;

        public string strSV_DiemRenLuyenID = "SV_DiemRenLuyenID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strSoDiemKy1 = "SoDiemKy1";
        public string strIDDM_XepLoaiRenLuyenKy1 = "IDDM_XepLoaiRenLuyenKy1";
        public string strNhanXetKy1 = "NhanXetKy1";
        public string strSoDiemKy2 = "SoDiemKy2";
        public string strIDDM_XepLoaiRenLuyenKy2 = "IDDM_XepLoaiRenLuyenKy2";
        public string strNhanXetKy2 = "NhanXetKy2";
        public string strSoDiemCaNam = "SoDiemCaNam";
        public string strIDDM_XepLoaiRenLuyenCaNam = "IDDM_XepLoaiRenLuyenCaNam";
        public string strNhanXetCaNam = "NhanXetCaNam";

        public SV_DiemRenLuyenInfo()
        { }

        public int SV_DiemRenLuyenID{
        	set{ mSV_DiemRenLuyenID = value;}
        	get{ return mSV_DiemRenLuyenID;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
        public int IDDM_NamHoc{
        	set{ mIDDM_NamHoc = value;}
        	get{ return mIDDM_NamHoc;}
        }
        public double SoDiemKy1{
        	set{ mSoDiemKy1 = value;}
        	get{ return mSoDiemKy1;}
        }
        public int IDDM_XepLoaiRenLuyenKy1{
        	set{ mIDDM_XepLoaiRenLuyenKy1 = value;}
        	get{ return mIDDM_XepLoaiRenLuyenKy1;}
        }
        public string NhanXetKy1{
        	set{ mNhanXetKy1 = value;}
        	get{ return mNhanXetKy1;}
        }
        public double SoDiemKy2{
        	set{ mSoDiemKy2 = value;}
        	get{ return mSoDiemKy2;}
        }
        public int IDDM_XepLoaiRenLuyenKy2{
        	set{ mIDDM_XepLoaiRenLuyenKy2 = value;}
        	get{ return mIDDM_XepLoaiRenLuyenKy2;}
        }
        public string NhanXetKy2{
        	set{ mNhanXetKy2 = value;}
        	get{ return mNhanXetKy2;}
        }
        public double SoDiemCaNam{
        	set{ mSoDiemCaNam = value;}
        	get{ return mSoDiemCaNam;}
        }
        public int IDDM_XepLoaiRenLuyenCaNam{
        	set{ mIDDM_XepLoaiRenLuyenCaNam = value;}
        	get{ return mIDDM_XepLoaiRenLuyenCaNam;}
        }
        public string NhanXetCaNam{
        	set{ mNhanXetCaNam = value;}
        	get{ return mNhanXetCaNam;}
        }
    }
}
