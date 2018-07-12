using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_QuyetDinhTotNghiepInfo
    {

        private int mKQHT_QuyetDinhTotNghiepID;
        private string mSoQuyetDinh;
        private DateTime mNgayQuyetDinh;
        private string mNoiDung;
        private int mIDDM_NamHoc;

        public string strKQHT_QuyetDinhTotNghiepID = "KQHT_QuyetDinhTotNghiepID";
        public string strSoQuyetDinh = "SoQuyetDinh";
        public string strNgayQuyetDinh = "NgayQuyetDinh";
        public string strNoiDung = "NoiDung";
        public string strIDDM_NamHoc = "IDDM_NamHoc";

        public KQHT_QuyetDinhTotNghiepInfo()
        { }

        public int KQHT_QuyetDinhTotNghiepID{
        	set{ mKQHT_QuyetDinhTotNghiepID = value;}
        	get{ return mKQHT_QuyetDinhTotNghiepID;}
        }
        public string SoQuyetDinh{
        	set{ mSoQuyetDinh = value;}
        	get{ return mSoQuyetDinh;}
        }
        public DateTime NgayQuyetDinh{
        	set{ mNgayQuyetDinh = value;}
        	get{ return mNgayQuyetDinh;}
        }
        public string NoiDung{
        	set{ mNoiDung = value;}
        	get{ return mNoiDung;}
        }
        public int IDDM_NamHoc{
        	set{ mIDDM_NamHoc = value;}
        	get{ return mIDDM_NamHoc;}
        }
    }
}
