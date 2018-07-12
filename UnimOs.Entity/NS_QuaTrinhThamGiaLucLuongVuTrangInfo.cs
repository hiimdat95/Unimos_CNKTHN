using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class NS_QuaTrinhThamGiaLucLuongVuTrangInfo
    {

        private int mNS_QuaTrinhThamGiaLucLuongVuTrangID;
        private int mIDNS_GiaoVien;
        private DateTime mNgayNhapNgu;
        private DateTime mNgayXuatNgu;
        private int mIDDM_QuanHam;
        private string mDonVi;
        private string mChucVu;

        public string strNS_QuaTrinhThamGiaLucLuongVuTrangID = "NS_QuaTrinhThamGiaLucLuongVuTrangID";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strNgayNhapNgu = "NgayNhapNgu";
        public string strNgayXuatNgu = "NgayXuatNgu";
        public string strIDDM_QuanHam = "IDDM_QuanHam";
        public string strDonVi = "DonVi";
        public string strChucVu = "ChucVu";

        public NS_QuaTrinhThamGiaLucLuongVuTrangInfo()
        { }

        public int NS_QuaTrinhThamGiaLucLuongVuTrangID{
        	set{ mNS_QuaTrinhThamGiaLucLuongVuTrangID = value;}
        	get{ return mNS_QuaTrinhThamGiaLucLuongVuTrangID;}
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
        }
        public DateTime NgayNhapNgu{
        	set{ mNgayNhapNgu = value;}
        	get{ return mNgayNhapNgu;}
        }
        public DateTime NgayXuatNgu{
        	set{ mNgayXuatNgu = value;}
        	get{ return mNgayXuatNgu;}
        }
        public int IDDM_QuanHam{
        	set{ mIDDM_QuanHam = value;}
        	get{ return mIDDM_QuanHam;}
        }
        public string DonVi{
        	set{ mDonVi = value;}
        	get{ return mDonVi;}
        }
        public string ChucVu{
        	set{ mChucVu = value;}
        	get{ return mChucVu;}
        }
    }
}
