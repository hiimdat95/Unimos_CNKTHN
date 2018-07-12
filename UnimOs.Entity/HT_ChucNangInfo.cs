using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class HT_ChucNangInfo
    {

        private int mHT_ChucNangID;
        private int mIDHT_PhanHe;
        private string mTenChucNang;
        private string mTag;
        private int mParentID;
        private int mLevel;
        private string mMoTa;
        private string mbarbtnName;
        private string mKieuRibbon;
        private string mbtnThem;
        private string mbtnSua;
        private string mbtnXoa;

        public string strHT_ChucNangID = "HT_ChucNangID";
        public string strIDHT_PhanHe = "IDHT_PhanHe";
        public string strTenChucNang = "TenChucNang";
        public string strTag = "Tag";
        public string strParentID = "ParentID";
        public string strLevel = "Level";
        public string strMoTa = "MoTa";
        public string strbarbtnName = "barbtnName";
        public string strKieuRibbon = "KieuRibbon";
        public string strbtnThem = "btnThem";
        public string strbtnSua = "btnSua";
        public string strbtnXoa = "btnXoa";

        public HT_ChucNangInfo()
        { }

        public int HT_ChucNangID{
        	set{ mHT_ChucNangID = value;}
        	get{ return mHT_ChucNangID;}
        }
        public int IDHT_PhanHe{
        	set{ mIDHT_PhanHe = value;}
        	get{ return mIDHT_PhanHe;}
        }
        public string TenChucNang{
        	set{ mTenChucNang = value;}
        	get{ return mTenChucNang;}
        }
        public string Tag{
        	set{ mTag = value;}
        	get{ return mTag;}
        }
        public int ParentID{
        	set{ mParentID = value;}
        	get{ return mParentID;}
        }
        public int Level{
        	set{ mLevel = value;}
        	get{ return mLevel;}
        }
        public string MoTa{
        	set{ mMoTa = value;}
        	get{ return mMoTa;}
        }
        public string barbtnName{
        	set{ mbarbtnName = value;}
        	get{ return mbarbtnName;}
        }
        public string KieuRibbon
        {
            set { mKieuRibbon = value; }
            get { return mKieuRibbon; }
        }
        public string btnThem{
        	set{ mbtnThem = value;}
        	get{ return mbtnThem;}
        }
        public string btnSua{
        	set{ mbtnSua = value;}
        	get{ return mbtnSua;}
        }
        public string btnXoa{
        	set{ mbtnXoa = value;}
        	get{ return mbtnXoa;}
        }
    }
}
