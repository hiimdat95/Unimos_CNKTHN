using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class NS_GiaoVien_NgoaiNguInfo
    {

        private int mNS_GiaoVien_NgoaiNguID;
        private int mIDNS_GiaoVien;
        private int mIDDM_NgoaiNgu;
        private string mIDTrinhDo;
        private string mTrinhDo;
        private string mSoChungChi;
        private DateTime mNgayCap;
        private string mNoiCap;
        private int mIDDM_TinhHuyenXaNoiCap;

        public string strNS_GiaoVien_NgoaiNguID = "NS_GiaoVien_NgoaiNguID";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strIDDM_NgoaiNgu = "IDDM_NgoaiNgu";
        public string strIDTrinhDo = "IDTrinhDo";
        public string strTrinhDo = "TrinhDo";
        public string strSoChungChi = "SoChungChi";
        public string strNgayCap = "NgayCap";
        public string strNoiCap = "NoiCap";
        public string strIDDM_TinhHuyenXaNoiCap = "IDDM_TinhHuyenXaNoiCap";

        public NS_GiaoVien_NgoaiNguInfo()
        { }

        public int NS_GiaoVien_NgoaiNguID{
        	set{ mNS_GiaoVien_NgoaiNguID = value;}
        	get{ return mNS_GiaoVien_NgoaiNguID;}
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
        }
        public int IDDM_NgoaiNgu{
        	set{ mIDDM_NgoaiNgu = value;}
        	get{ return mIDDM_NgoaiNgu;}
        }
        public string IDTrinhDo
        {
            set { mIDTrinhDo = value; }
            get { return mIDTrinhDo; }
        }
        public string TrinhDo{
        	set{ mTrinhDo = value;}
        	get{ return mTrinhDo;}
        }
        public string SoChungChi{
        	set{ mSoChungChi = value;}
        	get{ return mSoChungChi;}
        }
        public DateTime NgayCap{
        	set{ mNgayCap = value;}
        	get{ return mNgayCap;}
        }
        public string NoiCap{
        	set{ mNoiCap = value;}
        	get{ return mNoiCap;}
        }
        public int IDDM_TinhHuyenXaNoiCap{
        	set{ mIDDM_TinhHuyenXaNoiCap = value;}
        	get{ return mIDDM_TinhHuyenXaNoiCap;}
        }
    }
}
