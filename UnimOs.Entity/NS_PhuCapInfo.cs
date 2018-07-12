using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class NS_PhuCapInfo
    {
        private int mNS_PhuCapID;
        private int mIDNS_GiaoVien;
        private int mIDNS_LoaiPhuCap;
        private double mHeSoPhuCap;
        private double mPhanTramHuong;
        private DateTime mPhuCapTuNgay;
        private DateTime mPhuCapDenNgay;
        private bool mTinhBHXH;

        public string strNS_PhuCapID = "NS_PhuCapID";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strIDNS_LoaiPhuCap = "IDNS_LoaiPhuCap";
        public string strHeSoPhuCap = "HeSoPhuCap";
        public string strPhanTramHuong = "PhanTramHuong";
        public string strPhuCapTuNgay = "PhuCapTuNgay";
        public string strPhuCapDenNgay = "PhuCapDenNgay";
        public string strTinhBHXH = "TinhBHXH";

        public NS_PhuCapInfo()
        { }

        public int NS_PhuCapID{
        	set{ mNS_PhuCapID = value;}
        	get{ return mNS_PhuCapID;}
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
        }
        public int IDNS_LoaiPhuCap{
        	set{ mIDNS_LoaiPhuCap = value;}
        	get{ return mIDNS_LoaiPhuCap;}
        }
        public double HeSoPhuCap{
        	set{ mHeSoPhuCap = value;}
        	get{ return mHeSoPhuCap;}
        }
        public double PhanTramHuong{
        	set{ mPhanTramHuong = value;}
        	get{ return mPhanTramHuong;}
        }
        public DateTime PhuCapTuNgay{
        	set{ mPhuCapTuNgay = value;}
        	get{ return mPhuCapTuNgay;}
        }
        public DateTime PhuCapDenNgay{
        	set{ mPhuCapDenNgay = value;}
        	get{ return mPhuCapDenNgay;}
        }
        public bool TinhBHXH{
        	set{ mTinhBHXH = value;}
        	get{ return mTinhBHXH;}
        }
    }
}
