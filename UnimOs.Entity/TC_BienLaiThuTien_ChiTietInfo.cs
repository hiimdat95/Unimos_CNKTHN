using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class TC_BienLaiThuTien_ChiTietInfo
    {

        private int mTC_BienLaiThuTien_ChiTietID;
        private int mIDTC_BienLaiThuTien;
        private int mIDTC_LoaiThuChi;
        private int mIDTC_DinhMucThuSinhVien;
        private int mLanThu;
        private string mNoiDung;
        private double mSoTien;

        public string strTC_BienLaiThuTien_ChiTietID = "TC_BienLaiThuTien_ChiTietID";
        public string strIDTC_BienLaiThuTien = "IDTC_BienLaiThuTien";
        public string strIDTC_LoaiThuChi = "IDTC_LoaiThuChi";
        public string strIDTC_DinhMucThuSinhVien = "IDTC_DinhMucThuSinhVien";
        public string strLanThu = "LanThu";
        public string strNoiDung = "NoiDung";
        public string strSoTien = "SoTien";

        public TC_BienLaiThuTien_ChiTietInfo()
        { }

        public int TC_BienLaiThuTien_ChiTietID{
        	set{ mTC_BienLaiThuTien_ChiTietID = value;}
        	get{ return mTC_BienLaiThuTien_ChiTietID;}
        }
        public int IDTC_BienLaiThuTien{
        	set{ mIDTC_BienLaiThuTien = value;}
        	get{ return mIDTC_BienLaiThuTien;}
        }
        public int IDTC_LoaiThuChi{
        	set{ mIDTC_LoaiThuChi = value;}
        	get{ return mIDTC_LoaiThuChi;}
        }
        public int IDTC_DinhMucThuSinhVien{
        	set{ mIDTC_DinhMucThuSinhVien = value;}
        	get{ return mIDTC_DinhMucThuSinhVien;}
        }
        public int LanThu{
        	set{ mLanThu = value;}
        	get{ return mLanThu;}
        }
        public string NoiDung{
        	set{ mNoiDung = value;}
        	get{ return mNoiDung;}
        }
        public double SoTien{
        	set{ mSoTien = value;}
        	get{ return mSoTien;}
        }
    }
}
