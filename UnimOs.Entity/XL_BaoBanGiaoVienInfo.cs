using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class XL_BaoBanGiaoVienInfo
    {

        private int mXL_BaoBanGiaoVienID;
        private long mIDTuan;
        private int mIDNS_GiaoVien;
        private int mThu;
        private int mTiet;
        private int mCaHoc;
        private string mMoTa;

        public string strXL_BaoBanGiaoVienID = "XL_BaoBanGiaoVienID";
        public string strIDTuan = "IDTuan";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strThu = "Thu";
        public string strTiet = "Tiet";
        public string strCaHoc = "CaHoc";
        public string strMoTa = "MoTa";

        public XL_BaoBanGiaoVienInfo()
        { }

        public int XL_BaoBanGiaoVienID{
        	set{ mXL_BaoBanGiaoVienID = value;}
        	get{ return mXL_BaoBanGiaoVienID;}
        }
        public long IDTuan{
        	set{ mIDTuan = value;}
        	get{ return mIDTuan;}
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
        }
        public int Thu{
        	set{ mThu = value;}
        	get{ return mThu;}
        }
        public int Tiet{
        	set{ mTiet = value;}
        	get{ return mTiet;}
        }
        public int CaHoc{
        	set{ mCaHoc = value;}
        	get{ return mCaHoc;}
        }
        public string MoTa{
        	set{ mMoTa = value;}
        	get{ return mMoTa;}
        }
    }
}
