using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class NS_LoaiPhuCapInfo
    {

        private int mNS_LoaiPhuCapID;
        private string mKyHieu;
        private string mTenLoaiPhuCap;
        private bool mLaPhuCapChucVu;
        private bool mBHXH;

        public string strNS_LoaiPhuCapID = "NS_LoaiPhuCapID";
        public string strKyHieu = "KyHieu";
        public string strTenLoaiPhuCap = "TenLoaiPhuCap";
        public string strLaPhuCapChucVu = "LaPhuCapChucVu";
        public string strBHXH = "BHXH";

        public NS_LoaiPhuCapInfo()
        { }

        public int NS_LoaiPhuCapID{
        	set{ mNS_LoaiPhuCapID = value;}
        	get{ return mNS_LoaiPhuCapID;}
        }
        public string KyHieu{
        	set{ mKyHieu = value;}
        	get{ return mKyHieu;}
        }
        public string TenLoaiPhuCap{
        	set{ mTenLoaiPhuCap = value;}
        	get{ return mTenLoaiPhuCap;}
        }
        public bool LaPhuCapChucVu{
            set { mLaPhuCapChucVu = value; }
            get { return mLaPhuCapChucVu; }
        }
        public bool BHXH{
        	set{ mBHXH = value;}
        	get{ return mBHXH;}
        }
    }
}
