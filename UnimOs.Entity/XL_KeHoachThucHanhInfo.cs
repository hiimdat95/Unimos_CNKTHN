using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class XL_KeHoachThucHanhInfo
    {

        private int mXL_KeHoachThucHanhID;
        private int mIDDM_Lop;
        private int mIDXL_MonHocTrongKy;
        private int mIDDM_MonHoc;
        private int mIDDM_PhongHoc;
        private int mIDNS_GiaoVien;
        private int mSoBuoi;
        private int mSoTiet;
        private int mSoTo;
        private int mIDXL_KeHoachThucHanhKyHieu;

        public string strXL_KeHoachThucHanhID = "XL_KeHoachThucHanhID";
        public string strIDDM_Lop = "IDDM_Lop";
        public string strIDXL_MonHocTrongKy = "IDXL_MonHocTrongKy";
        public string strIDDM_MonHoc = "IDDM_MonHoc";
        public string strIDDM_PhongHoc = "IDDM_PhongHoc";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strSoBuoi = "SoBuoi";
        public string strSoTiet = "SoTiet";
        public string strSoTo = "SoTo";
        public string strIDXL_KeHoachThucHanhKyHieu = "IDXL_KeHoachThucHanhKyHieu";

        public XL_KeHoachThucHanhInfo()
        { }

        public int XL_KeHoachThucHanhID{
        	set{ mXL_KeHoachThucHanhID = value;}
        	get{ return mXL_KeHoachThucHanhID;}
        }
        public int IDDM_Lop{
        	set{ mIDDM_Lop = value;}
        	get{ return mIDDM_Lop;}
        }
        public int IDXL_MonHocTrongKy{
        	set{ mIDXL_MonHocTrongKy = value;}
        	get{ return mIDXL_MonHocTrongKy;}
        }
        public int IDDM_MonHoc{
        	set{ mIDDM_MonHoc = value;}
        	get{ return mIDDM_MonHoc;}
        }
        public int IDDM_PhongHoc{
        	set{ mIDDM_PhongHoc = value;}
        	get{ return mIDDM_PhongHoc;}
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
        }
        public int SoBuoi{
        	set{ mSoBuoi = value;}
        	get{ return mSoBuoi;}
        }
        public int SoTiet{
        	set{ mSoTiet = value;}
        	get{ return mSoTiet;}
        }
        public int SoTo{
        	set{ mSoTo = value;}
        	get{ return mSoTo;}
        }
        public int IDXL_KeHoachThucHanhKyHieu{
        	set{ mIDXL_KeHoachThucHanhKyHieu = value;}
        	get{ return mIDXL_KeHoachThucHanhKyHieu;}
        }
    }
}
