using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_DanhSachKhongThiTotNghiepInfo
    {

        private long mKQHT_DanhSachKhongThiTotNghiepID;
        private int mIDSV_SinhVien;
        private string mLyDo;
        private int mIDDM_NamHoc;
        private bool mXetVot;

        public string strKQHT_DanhSachKhongThiTotNghiepID = "KQHT_DanhSachKhongThiTotNghiepID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strLyDo = "LyDo";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strXetVot = "XetVot";

        public KQHT_DanhSachKhongThiTotNghiepInfo()
        { }

        public long KQHT_DanhSachKhongThiTotNghiepID{
        	set{ mKQHT_DanhSachKhongThiTotNghiepID = value;}
        	get{ return mKQHT_DanhSachKhongThiTotNghiepID;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
        public string LyDo{
        	set{ mLyDo = value;}
        	get{ return mLyDo;}
        }
        public int IDDM_NamHoc{
        	set{ mIDDM_NamHoc = value;}
        	get{ return mIDDM_NamHoc;}
        }
        public bool XetVot{
        	set{ mXetVot = value;}
        	get{ return mXetVot;}
        }
    }
}
