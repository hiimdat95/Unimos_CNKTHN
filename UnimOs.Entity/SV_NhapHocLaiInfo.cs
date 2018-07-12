using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class SV_NhapHocLaiInfo
    {

        private int mSV_NhapHocLaiID;
        private int mIDSV_SinhVien;
        private int mIDDM_LopCu;
        private int mIDDM_LopMoi;
        private int mIDDM_NamHoc;
        private int mHocKy;

        public string strSV_NhapHocLaiID = "SV_NhapHocLaiID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strIDDM_LopCu = "IDDM_LopCu";
        public string strIDDM_LopMoi = "IDDM_LopMoi";
        public string strIDDM_NamHoc = "IDDM_NamHoc";
        public string strHocKy = "HocKy";

        public SV_NhapHocLaiInfo()
        { }

        public int SV_NhapHocLaiID{
        	set{ mSV_NhapHocLaiID = value;}
        	get{ return mSV_NhapHocLaiID;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
        public int IDDM_LopCu{
        	set{ mIDDM_LopCu = value;}
        	get{ return mIDDM_LopCu;}
        }
        public int IDDM_LopMoi{
        	set{ mIDDM_LopMoi = value;}
        	get{ return mIDDM_LopMoi;}
        }
        public int IDDM_NamHoc{
        	set{ mIDDM_NamHoc = value;}
        	get{ return mIDDM_NamHoc;}
        }
        public int HocKy{
        	set{ mHocKy = value;}
        	get{ return mHocKy;}
        }
    }
}
