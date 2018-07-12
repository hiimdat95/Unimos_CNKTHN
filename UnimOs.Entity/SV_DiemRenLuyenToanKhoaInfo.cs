using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class SV_DiemRenLuyenToanKhoaInfo
    {

        private int mSV_DiemRenLuyenToanKhoaID;
        private int mIDSV_SinhVien;
        private double mSoDiem;
        private int mIDDM_XepLoaiRenLuyen;
        private string mNhanXet;

        public string strSV_DiemRenLuyenToanKhoaID = "SV_DiemRenLuyenToanKhoaID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strSoDiem = "SoDiem";
        public string strIDDM_XepLoaiRenLuyen = "IDDM_XepLoaiRenLuyen";
        public string strNhanXet = "NhanXet";

        public SV_DiemRenLuyenToanKhoaInfo()
        { }

        public int SV_DiemRenLuyenToanKhoaID{
        	set{ mSV_DiemRenLuyenToanKhoaID = value;}
        	get{ return mSV_DiemRenLuyenToanKhoaID;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
        public double SoDiem{
        	set{ mSoDiem = value;}
        	get{ return mSoDiem;}
        }
        public int IDDM_XepLoaiRenLuyen{
        	set{ mIDDM_XepLoaiRenLuyen = value;}
        	get{ return mIDDM_XepLoaiRenLuyen;}
        }
        public string NhanXet{
        	set{ mNhanXet = value;}
        	get{ return mNhanXet;}
        }
    }
}
