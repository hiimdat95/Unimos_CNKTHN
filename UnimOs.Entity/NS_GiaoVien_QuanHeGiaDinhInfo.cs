using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class NS_GiaoVien_QuanHeGiaDinhInfo
    {

        private int mNS_GiaoVien_QuanHeGiaDinhID;
        private int mIDNS_GiaoVien;
        private int mIDDM_QuanHeGiaDinh;
        private string mHoVaTen;
        private string mNamSinh;
        private string mDiaChiQueQuan;
        private int mIDDM_TinhHuyenXaQueQuan;
        private string mNgheNghiep;
        private string mThongTinKhac;

        public string strNS_GiaoVien_QuanHeGiaDinhID = "NS_GiaoVien_QuanHeGiaDinhID";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strIDDM_QuanHeGiaDinh = "IDDM_QuanHeGiaDinh";
        public string strHoVaTen = "HoVaTen";
        public string strNamSinh = "NamSinh";
        public string strDiaChiQueQuan = "DiaChiQueQuan";
        public string strIDDM_TinhHuyenXaQueQuan = "IDDM_TinhHuyenXaQueQuan";
        public string strNgheNghiep = "NgheNghiep";
        public string strThongTinKhac = "ThongTinKhac";

        public NS_GiaoVien_QuanHeGiaDinhInfo()
        { }

        public int NS_GiaoVien_QuanHeGiaDinhID{
        	set{ mNS_GiaoVien_QuanHeGiaDinhID = value;}
        	get{ return mNS_GiaoVien_QuanHeGiaDinhID;}
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
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
        public string DiaChiQueQuan{
        	set{ mDiaChiQueQuan = value;}
        	get{ return mDiaChiQueQuan;}
        }
        public int IDDM_TinhHuyenXaQueQuan{
        	set{ mIDDM_TinhHuyenXaQueQuan = value;}
        	get{ return mIDDM_TinhHuyenXaQueQuan;}
        }
        public string NgheNghiep{
            set { mNgheNghiep = value; }
            get { return mNgheNghiep; }
        }
        public string ThongTinKhac{
        	set{ mThongTinKhac = value;}
        	get{ return mThongTinKhac;}
        }
    }
}
