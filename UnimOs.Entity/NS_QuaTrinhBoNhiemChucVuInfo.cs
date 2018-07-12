using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class NS_QuaTrinhBoNhiemChucVuInfo
    {

        private int mNS_QuaTrinhBoNhiemChucVuID;
        private int mIDNS_GiaoVien;
        private string mSoQuyetDinh;
        private DateTime mNgayRaQuyetDinh;
        private int mIDDM_CapQuyetDinh;
        private int mIDDM_ChucVuBoNhiem;
        private DateTime mNgayCoHieuLuc;
        private DateTime mNgayHetHieuLuc;
        private bool mLaChucVuKiemNhiem;
        private int mIDNS_MienNhiemTuChuc;

        public string strNS_QuaTrinhBoNhiemChucVuID = "NS_QuaTrinhBoNhiemChucVuID";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strSoQuyetDinh = "SoQuyetDinh";
        public string strNgayRaQuyetDinh = "NgayRaQuyetDinh";
        public string strIDDM_CapQuyetDinh = "IDDM_CapQuyetDinh";
        public string strIDDM_ChucVuBoNhiem = "IDDM_ChucVuBoNhiem";
        public string strNgayCoHieuLuc = "NgayCoHieuLuc";
        public string strNgayHetHieuLuc = "NgayHetHieuLuc";
        public string strLaChucVuKiemNhiem = "LaChucVuKiemNhiem";
        public string strIDNS_MienNhiemTuChuc = "IDNS_MienNhiemTuChuc";

        public NS_QuaTrinhBoNhiemChucVuInfo()
        { }

        public int NS_QuaTrinhBoNhiemChucVuID{
        	set{ mNS_QuaTrinhBoNhiemChucVuID = value;}
        	get{ return mNS_QuaTrinhBoNhiemChucVuID;}
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
        }
        public string SoQuyetDinh{
        	set{ mSoQuyetDinh = value;}
        	get{ return mSoQuyetDinh;}
        }
        public DateTime NgayRaQuyetDinh{
        	set{ mNgayRaQuyetDinh = value;}
        	get{ return mNgayRaQuyetDinh;}
        }
        public int IDDM_CapQuyetDinh{
        	set{ mIDDM_CapQuyetDinh = value;}
        	get{ return mIDDM_CapQuyetDinh;}
        }
        public int IDDM_ChucVuBoNhiem{
        	set{ mIDDM_ChucVuBoNhiem = value;}
        	get{ return mIDDM_ChucVuBoNhiem;}
        }
        public DateTime NgayCoHieuLuc{
        	set{ mNgayCoHieuLuc = value;}
        	get{ return mNgayCoHieuLuc;}
        }
        public DateTime NgayHetHieuLuc{
        	set{ mNgayHetHieuLuc = value;}
        	get{ return mNgayHetHieuLuc;}
        }
        public bool LaChucVuKiemNhiem{
        	set{ mLaChucVuKiemNhiem = value;}
        	get{ return mLaChucVuKiemNhiem;}
        }
        public int IDNS_MienNhiemTuChuc{
        	set{ mIDNS_MienNhiemTuChuc = value;}
        	get{ return mIDNS_MienNhiemTuChuc;}
        }
    }
}
