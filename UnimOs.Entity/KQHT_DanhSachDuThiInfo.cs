using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_DanhSachDuThiInfo
    {

        private long mKQHT_DanhSachDuThiID;
        private int mIDKQHT_ToChucThi;
        private long mIDXL_MonHocTrongKy;
        private int mLanThi;
        private int mIDSV_SinhVien;
        private int mIDDM_PhongHoc;
        private int mSoBaoDanh;
        private string mSoPhach;
        private int mTuiThiSo;
        private string mGhiChu;

        public string strKQHT_DanhSachDuThiID = "KQHT_DanhSachDuThiID";
        public string strIDKQHT_ToChucThi = "IDKQHT_ToChucThi";
        public string strIDXL_MonHocTrongKy = "IDXL_MonHocTrongKy";
        public string strLanThi = "LanThi";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strIDDM_PhongHoc = "IDDM_PhongHoc";
        public string strSoBaoDanh = "SoBaoDanh";
        public string strSoPhach = "SoPhach";
        public string strTuiThiSo = "TuiThiSo";
        public string strGhiChu = "GhiChu";

        public KQHT_DanhSachDuThiInfo()
        { }

        public long KQHT_DanhSachDuThiID{
        	set{ mKQHT_DanhSachDuThiID = value;}
        	get{ return mKQHT_DanhSachDuThiID;}
        }
        public int IDKQHT_ToChucThi{
        	set{ mIDKQHT_ToChucThi = value;}
        	get{ return mIDKQHT_ToChucThi;}
        }
        public long IDXL_MonHocTrongKy
        {
            set { mIDXL_MonHocTrongKy = value; }
            get { return mIDXL_MonHocTrongKy; }
        }
        public int LanThi
        {
            set { mLanThi = value; }
            get { return mLanThi; }
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
        public int IDDM_PhongHoc{
        	set{ mIDDM_PhongHoc = value;}
        	get{ return mIDDM_PhongHoc;}
        }
        public int SoBaoDanh{
        	set{ mSoBaoDanh = value;}
        	get{ return mSoBaoDanh;}
        }
        public string SoPhach{
        	set{ mSoPhach = value;}
        	get{ return mSoPhach;}
        }
        public int TuiThiSo{
        	set{ mTuiThiSo = value;}
        	get{ return mTuiThiSo;}
        }
        public string GhiChu{
        	set{ mGhiChu = value;}
        	get{ return mGhiChu;}
        }
    }
}
