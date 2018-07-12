using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class SV_QuyetDinhKyLuatInfo
    {

        private int mSV_QuyetDinhKyLuatID;
        private int mIDDM_NamHoc;
        private int mHocKy;
        private string mSoQuyetDinh;
        private DateTime mNgayQuyetDinh;
        private int mIDDM_CapKhenThuong;
        private int mIDDM_HanhVi;
        private string mNoiDung;

        public string strSV_QuyetDinhKyLuatID = "SV_QuyetDinhKyLuatID";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strHocKy = "HocKy";
        public string strSoQuyetDinh = "SoQuyetDinh";
        public string strNgayQuyetDinh = "NgayQuyetDinh";
        public string strIDDM_CapKhenThuong = "IDDM_CapKhenThuong";
        public string strIDDM_HanhVi = "IDDM_HanhVi";
        public string strNoiDung = "NoiDung";

        public SV_QuyetDinhKyLuatInfo()
        { }

        public int SV_QuyetDinhKyLuatID{
        	set{ mSV_QuyetDinhKyLuatID = value;}
        	get{ return mSV_QuyetDinhKyLuatID;}
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
        public int IDDM_HanhVi{
        	set{ mIDDM_HanhVi = value;}
        	get{ return mIDDM_HanhVi;}
        }
        public string NoiDung{
        	set{ mNoiDung = value;}
        	get{ return mNoiDung;}
        }
    }
}
