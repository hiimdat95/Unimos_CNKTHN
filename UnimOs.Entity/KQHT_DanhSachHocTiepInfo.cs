using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_DanhSachHocTiepInfo
    {

        private int mKQHT_DanhSachHocTiepID;
        private int mIDKQHT_DanhSachNgungHoc;
        private int mIDSV_SinhVien;
        private int mHocky;
        private int mIDDM_Namhoc;
        private string mSoQuyetDinh;
        private DateTime mNgayQuyetDinh;
        private string mLydo;
        private int mIDDM_Lop;

        public string strKQHT_DanhSachHocTiepID = "KQHT_DanhSachHocTiepID";
        public string strIDKQHT_DanhSachNgungHoc = "IDKQHT_DanhSachNgungHoc";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strHocky = "Hocky";
        public string strIDDM_Namhoc = "IDDM_Namhoc";
        public string strSoQuyetDinh = "SoQuyetDinh";
        public string strNgayQuyetDinh = "NgayQuyetDinh";
        public string strLydo = "Lydo";
        public string strIDDM_Lop = "IDDM_Lop";

        public KQHT_DanhSachHocTiepInfo()
        { }

        public int KQHT_DanhSachHocTiepID{
        	set{ mKQHT_DanhSachHocTiepID = value;}
        	get{ return mKQHT_DanhSachHocTiepID;}
        }
        public int IDKQHT_DanhSachNgungHoc{
        	set{ mIDKQHT_DanhSachNgungHoc = value;}
        	get{ return mIDKQHT_DanhSachNgungHoc;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
        public int Hocky{
        	set{ mHocky = value;}
        	get{ return mHocky;}
        }
        public int IDDM_Namhoc{
        	set{ mIDDM_Namhoc = value;}
        	get{ return mIDDM_Namhoc;}
        }
        public string SoQuyetDinh{
        	set{ mSoQuyetDinh = value;}
        	get{ return mSoQuyetDinh;}
        }
        public DateTime NgayQuyetDinh{
        	set{ mNgayQuyetDinh = value;}
        	get{ return mNgayQuyetDinh;}
        }
        public string Lydo{
        	set{ mLydo = value;}
        	get{ return mLydo;}
        }
        public int IDDM_Lop{
        	set{ mIDDM_Lop = value;}
        	get{ return mIDDM_Lop;}
        }
    }
}
