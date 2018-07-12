using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class NS_QuaTrinhMienNhiemTuChucInfo
    {

        private int mNS_QuaTrinhMienNhiemTuChucID;
        private int mIDNS_GiaoVien;
        private string mSoQuyetDinh;
        private DateTime mNgayRaQuyetDinh;
        private DateTime mNgayCoHieuLuc;
        private int mIDDM_CapQuyetDinh;

        public string strNS_QuaTrinhMienNhiemTuChucID = "NS_QuaTrinhMienNhiemTuChucID";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strSoQuyetDinh = "SoQuyetDinh";
        public string strNgayRaQuyetDinh = "NgayRaQuyetDinh";
        public string strNgayCoHieuLuc = "NgayCoHieuLuc";
        public string strIDDM_CapQuyetDinh = "IDDM_CapQuyetDinh";

        public NS_QuaTrinhMienNhiemTuChucInfo()
        { }

        public int NS_QuaTrinhMienNhiemTuChucID{
        	set{ mNS_QuaTrinhMienNhiemTuChucID = value;}
        	get{ return mNS_QuaTrinhMienNhiemTuChucID;}
        }
        public int IDNS_GiaoVien{
            set { mIDNS_GiaoVien = value; }
            get { return mIDNS_GiaoVien; }
        }
        public string SoQuyetDinh{
        	set{ mSoQuyetDinh = value;}
        	get{ return mSoQuyetDinh;}
        }
        public DateTime NgayRaQuyetDinh{
        	set{ mNgayRaQuyetDinh = value;}
        	get{ return mNgayRaQuyetDinh;}
        }
        public DateTime NgayCoHieuLuc{
        	set{ mNgayCoHieuLuc = value;}
        	get{ return mNgayCoHieuLuc;}
        }
        public int IDDM_CapQuyetDinh{
        	set{ mIDDM_CapQuyetDinh = value;}
        	get{ return mIDDM_CapQuyetDinh;}
        }
    }
}
