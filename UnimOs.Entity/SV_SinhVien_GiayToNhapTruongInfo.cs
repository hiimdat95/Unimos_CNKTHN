using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class SV_SinhVien_GiayToNhapTruongInfo
    {

        private int mSV_SinhVien_GiayToNhapTruongID;
        private int mIDSV_SinhVien;
        private int mIDSV_SinhVienNhapTruong;
        private int mIDDM_GiayToNhapTruong;
        private string mGhiChu;
        private bool mDaTra;

        public string strSV_SinhVien_GiayToNhapTruongID = "SV_SinhVien_GiayToNhapTruongID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strIDSV_SinhVienNhapTruong = "IDSV_SinhVienNhapTruong";
        public string strIDDM_GiayToNhapTruong = "IDDM_GiayToNhapTruong";
        public string strGhiChu = "GhiChu";
        public string strDaTra = "DaTra";

        public SV_SinhVien_GiayToNhapTruongInfo()
        { }

        public int SV_SinhVien_GiayToNhapTruongID{
        	set{ mSV_SinhVien_GiayToNhapTruongID = value;}
        	get{ return mSV_SinhVien_GiayToNhapTruongID;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
        public int IDSV_SinhVienNhapTruong{
        	set{ mIDSV_SinhVienNhapTruong = value;}
        	get{ return mIDSV_SinhVienNhapTruong;}
        }
        public int IDDM_GiayToNhapTruong{
        	set{ mIDDM_GiayToNhapTruong = value;}
        	get{ return mIDDM_GiayToNhapTruong;}
        }
        public string GhiChu{
        	set{ mGhiChu = value;}
        	get{ return mGhiChu;}
        }
        public bool DaTra{
        	set{ mDaTra = value;}
        	get{ return mDaTra;}
        }
    }
}
