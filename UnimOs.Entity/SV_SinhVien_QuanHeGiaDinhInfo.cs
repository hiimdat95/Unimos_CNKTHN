using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class SV_SinhVien_QuanHeGiaDinhInfo
    {

        private int mSV_SinhVien_QuanHeGiaDinhID;
        private int mIDSV_SinhVien;
        private int mIDDM_QuanHeGiaDinh;
        private string mHoVaTen;
        private string mNamSinh;
        private string mNgheNghiep;
        private string mDiaChi;
        private string mThongTinKhac;

        public string strSV_SinhVien_QuanHeGiaDinhID = "SV_SinhVien_QuanHeGiaDinhID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strIDDM_QuanHeGiaDinh = "IDDM_QuanHeGiaDinh";
        public string strHoVaTen = "HoVaTen";
        public string strNamSinh = "NamSinh";
        public string strNgheNghiep = "NgheNghiep";
        public string strDiaChi = "DiaChi";
        public string strThongTinKhac = "ThongTinKhac";

        public SV_SinhVien_QuanHeGiaDinhInfo()
        { }

        public int SV_SinhVien_QuanHeGiaDinhID{
        	set{ mSV_SinhVien_QuanHeGiaDinhID = value;}
        	get{ return mSV_SinhVien_QuanHeGiaDinhID;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
        public int IDDM_QuanHeGiaDinh{
        	set{ mIDDM_QuanHeGiaDinh = value;}
        	get{ return mIDDM_QuanHeGiaDinh;}
        }
        public string HoVaTen{
        	set{ mHoVaTen = value;}
        	get{ return mHoVaTen;}
        }
        public string NamSinh{
        	set{ mNamSinh = value;}
        	get{ return mNamSinh;}
        }
        public string NgheNghiep{
        	set{ mNgheNghiep = value;}
        	get{ return mNgheNghiep;}
        }
        public string DiaChi{
        	set{ mDiaChi = value;}
        	get{ return mDiaChi;}
        }
        public string ThongTinKhac{
        	set{ mThongTinKhac = value;}
        	get{ return mThongTinKhac;}
        }
    }
}
