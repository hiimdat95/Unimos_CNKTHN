using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class NS_GiaoVien_HDLDInfo
    {

        private int mNS_GiaoVien_HDLDID;
        private int mIDNS_GiaoVien;
        private string mIDHinhThucHDLD;
        private string mSoHopDong;
        private int? mSoThangHopDong;
        private string mGhiChu;
        private DateTime mThoiGianBatDau;
        private DateTime? mThoiGianKetThuc;

        public string strNS_GiaoVien_HDLDID = "NS_GiaoVien_HDLDID";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strIDHinhThucHDLD = "IDHinhThucHDLD";
        public string strSoHopDong = "SoHopDong";
        public string strSoThangHopDong = "SoThangHopDong";
        public string strGhiChu = "GhiChu";
        public string strThoiGianBatDau = "ThoiGianBatDau";
        public string strThoiGianKetThuc = "ThoiGianKetThuc";

        public NS_GiaoVien_HDLDInfo()
        { }

        public int NS_GiaoVien_HDLDID{
        	set{ mNS_GiaoVien_HDLDID = value;}
        	get{ return mNS_GiaoVien_HDLDID;}
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
        }
        public string IDHinhThucHDLD{
        	set{ mIDHinhThucHDLD = value;}
        	get{ return mIDHinhThucHDLD;}
        }
        public string SoHopDong{
        	set{ mSoHopDong = value;}
        	get{ return mSoHopDong;}
        }
        public int? SoThangHopDong{
        	set{ mSoThangHopDong = value;}
        	get{ return mSoThangHopDong;}
        }
        public string GhiChu{
        	set{ mGhiChu = value;}
        	get{ return mGhiChu;}
        }
        public DateTime ThoiGianBatDau{
        	set{ mThoiGianBatDau = value;}
        	get{ return mThoiGianBatDau;}
        }
        public DateTime? ThoiGianKetThuc{
        	set{ mThoiGianKetThuc = value;}
        	get{ return mThoiGianKetThuc;}
        }
    }
}
