using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class NS_QuaTrinhLuanChuyenInfo
    {

        private int mNS_QuaTrinhLuanChuyenID;
        private int mIDNS_GiaoVien;
        private string mSoQuyetDinh;
        private DateTime mNgayQuyetDinh;
        private DateTime mNgayCoHieuLuc;
        private int mIDNS_LoaiLuanChuyen;
        private int mIDNS_DonViCu;
        private int mIDNS_DonViMoi;
        private string mNoiDung;

        public string strNS_QuaTrinhLuanChuyenID = "NS_QuaTrinhLuanChuyenID";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strSoQuyetDinh = "SoQuyetDinh";
        public string strNgayQuyetDinh = "NgayQuyetDinh";
        public string strNgayCoHieuLuc = "NgayCoHieuLuc";
        public string strIDNS_LoaiLuanChuyen = "IDNS_LoaiLuanChuyen";
        public string strIDNS_DonViCu = "IDNS_DonViCu";
        public string strIDNS_DonViMoi = "IDNS_DonViMoi";
        public string strNoiDung = "NoiDung";

        public NS_QuaTrinhLuanChuyenInfo()
        { }

        public int NS_QuaTrinhLuanChuyenID{
        	set{ mNS_QuaTrinhLuanChuyenID = value;}
        	get{ return mNS_QuaTrinhLuanChuyenID;}
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
        }
        public string SoQuyetDinh{
        	set{ mSoQuyetDinh = value;}
        	get{ return mSoQuyetDinh;}
        }
        public DateTime NgayQuyetDinh{
        	set{ mNgayQuyetDinh = value;}
        	get{ return mNgayQuyetDinh;}
        }
        public DateTime NgayCoHieuLuc{
        	set{ mNgayCoHieuLuc = value;}
        	get{ return mNgayCoHieuLuc;}
        }
        public int IDNS_LoaiLuanChuyen{
        	set{ mIDNS_LoaiLuanChuyen = value;}
        	get{ return mIDNS_LoaiLuanChuyen;}
        }
        public int IDNS_DonViCu{
        	set{ mIDNS_DonViCu = value;}
        	get{ return mIDNS_DonViCu;}
        }
        public int IDNS_DonViMoi{
        	set{ mIDNS_DonViMoi = value;}
        	get{ return mIDNS_DonViMoi;}
        }
        public string NoiDung{
        	set{ mNoiDung = value;}
        	get{ return mNoiDung;}
        }
    }
}
