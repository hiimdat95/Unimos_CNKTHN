using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class SV_DiemRenLuyenTheoThangInfo
    {

        private int mSV_DiemRenLuyenTheoThangID;
        private int mIDSV_SinhVien;
        private int mIDSV_ThangRenLuyenTrongKy;
        private double mSoDiem;
        private int mIDDM_XepLoaiRenLuyen;
        private string mNhanXet;

        public string strSV_DiemRenLuyenTheoThangID = "SV_DiemRenLuyenTheoThangID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strIDSV_ThangRenLuyenTrongKy = "IDSV_ThangRenLuyenTrongKy";
        public string strSoDiem = "SoDiem";
        public string strIDDM_XepLoaiRenLuyen = "IDDM_XepLoaiRenLuyen";
        public string strNhanXet = "NhanXet";

        public SV_DiemRenLuyenTheoThangInfo()
        { }

        public int SV_DiemRenLuyenTheoThangID{
        	set{ mSV_DiemRenLuyenTheoThangID = value;}
        	get{ return mSV_DiemRenLuyenTheoThangID;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
        public int IDSV_ThangRenLuyenTrongKy{
        	set{ mIDSV_ThangRenLuyenTrongKy = value;}
        	get{ return mIDSV_ThangRenLuyenTrongKy;}
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
