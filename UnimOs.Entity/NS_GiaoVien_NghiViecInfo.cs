using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class NS_GiaoVien_NghiViecInfo
    {

        private int mNS_GiaoVien_NghiViecID;
        private int mIDNS_GiaoVien;
        private string mSoQuyetDinh;
        private string mIDNS_HinhThucNghiViec;
        private DateTime mNgayCoHieuLuc;

        public string strNS_GiaoVien_NghiViecID = "NS_GiaoVien_NghiViecID";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strSoQuyetDinh = "SoQuyetDinh";
        public string strIDNS_HinhThucNghiViec = "IDNS_HinhThucNghiViec";
        public string strNgayCoHieuLuc = "NgayCoHieuLuc";

        public NS_GiaoVien_NghiViecInfo()
        { }

        public int NS_GiaoVien_NghiViecID{
        	set{ mNS_GiaoVien_NghiViecID = value;}
        	get{ return mNS_GiaoVien_NghiViecID;}
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
        }
        public string SoQuyetDinh{
        	set{ mSoQuyetDinh = value;}
        	get{ return mSoQuyetDinh;}
        }
        public string IDNS_HinhThucNghiViec{
        	set{ mIDNS_HinhThucNghiViec = value;}
        	get{ return mIDNS_HinhThucNghiViec;}
        }
        public DateTime NgayCoHieuLuc{
        	set{ mNgayCoHieuLuc = value;}
        	get{ return mNgayCoHieuLuc;}
        }
    }
}
