using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class XL_BaoBanPhongHocInfo
    {

        private int mXL_BaoBanPhongHocID;
        private long mIDTuan;
        private int mIDXL_PhongHoc;
        private int mThu;
        private int mTiet;
        private int mSoTiet;
        private string mMoTa;

        public string strXL_BaoBanPhongHocID = "XL_BaoBanPhongHocID";
        public string strIDTuan = "IDTuan";
        public string strIDXL_PhongHoc = "IDXL_PhongHoc";
        public string strThu = "Thu";
        public string strTiet = "Tiet";
        public string strSoTiet = "SoTiet";
        public string strMoTa = "MoTa";

        public XL_BaoBanPhongHocInfo()
        { }

        public int XL_BaoBanPhongHocID{
        	set{ mXL_BaoBanPhongHocID = value;}
        	get{ return mXL_BaoBanPhongHocID;}
        }
        public long IDTuan{
        	set{ mIDTuan = value;}
        	get{ return mIDTuan;}
        }
        public int IDXL_PhongHoc{
        	set{ mIDXL_PhongHoc = value;}
        	get{ return mIDXL_PhongHoc;}
        }
        public int Thu{
        	set{ mThu = value;}
        	get{ return mThu;}
        }
        public int Tiet{
        	set{ mTiet = value;}
        	get{ return mTiet;}
        }
        public int SoTiet{
        	set{ mSoTiet = value;}
        	get{ return mSoTiet;}
        }
        public string MoTa{
        	set{ mMoTa = value;}
        	get{ return mMoTa;}
        }
    }
}
