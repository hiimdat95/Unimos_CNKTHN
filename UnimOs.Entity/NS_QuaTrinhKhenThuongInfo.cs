using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class NS_QuaTrinhKhenThuongInfo
    {

        private int mNS_QuaTrinhKhenThuongID;
        private int mIDNS_GiaoVien;
        private string mSoQuyetDinh;
        private DateTime mNgayQuyetDinh;
        private DateTime mNgayCoHieuLuc;
        private int mIDDM_CapKhenThuong;
        private string mNoiDung;
        private int mGiamSoThangTangLuong;
        private double mSoTien;

        public string strNS_QuaTrinhKhenThuongID = "NS_QuaTrinhKhenThuongID";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strSoQuyetDinh = "SoQuyetDinh";
        public string strNgayQuyetDinh = "NgayQuyetDinh";
        public string strNgayCoHieuLuc = "NgayCoHieuLuc";
        public string strIDDM_CapKhenThuong = "IDDM_CapKhenThuong";
        public string strNoiDung = "NoiDung";
        public string strGiamSoThangTangLuong = "GiamSoThangTangLuong";
        public string strSoTien = "SoTien";

        public NS_QuaTrinhKhenThuongInfo()
        { }

        public int NS_QuaTrinhKhenThuongID{
        	set{ mNS_QuaTrinhKhenThuongID = value;}
        	get{ return mNS_QuaTrinhKhenThuongID;}
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
        public int IDDM_CapKhenThuong{
        	set{ mIDDM_CapKhenThuong = value;}
        	get{ return mIDDM_CapKhenThuong;}
        }
        public string NoiDung{
        	set{ mNoiDung = value;}
        	get{ return mNoiDung;}
        }
        public int GiamSoThangTangLuong{
        	set{ mGiamSoThangTangLuong = value;}
        	get{ return mGiamSoThangTangLuong;}
        }
        public double SoTien{
        	set{ mSoTien = value;}
        	get{ return mSoTien;}
        }
    }
}
