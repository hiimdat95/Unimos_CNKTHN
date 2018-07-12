using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class GG_HeSoLopDongTheoKhoaInfo
    {

        private int mGG_HeSoLopDongTheoKhoaID;
        private string mLoaiGiangDay;
        private int mIDDM_TrinhDo;
        private int mIDDM_Khoa;
        private int mSoSVToiDa;
        private double mHeSoQuyChuan;
        private int mSoCongThem1Tiet;
        private double mSoTietDinhMuc1Tuan;

        public string strGG_HeSoLopDongTheoKhoaID = "GG_HeSoLopDongTheoKhoaID";
        public string strLoaiGiangDay = "LoaiGiangDay";
        public string strIDDM_TrinhDo = "IDDM_TrinhDo";
        public string strIDDM_Khoa = "IDDM_Khoa";
        public string strSoSVToiDa = "SoSVToiDa";
        public string strHeSoQuyChuan = "HeSoQuyChuan";
        public string strSoCongThem1Tiet = "SoCongThem1Tiet";
        public string strSoTietDinhMuc1Tuan = "SoTietDinhMuc1Tuan";

        public GG_HeSoLopDongTheoKhoaInfo()
        { }

        public int GG_HeSoLopDongTheoKhoaID{
        	set{ mGG_HeSoLopDongTheoKhoaID = value;}
        	get{ return mGG_HeSoLopDongTheoKhoaID;}
        }
        public string LoaiGiangDay{
        	set{ mLoaiGiangDay = value;}
        	get{ return mLoaiGiangDay;}
        }
        public int IDDM_TrinhDo{
        	set{ mIDDM_TrinhDo = value;}
        	get{ return mIDDM_TrinhDo;}
        }
        public int IDDM_Khoa{
        	set{ mIDDM_Khoa = value;}
        	get{ return mIDDM_Khoa;}
        }
        public int SoSVToiDa{
        	set{ mSoSVToiDa = value;}
        	get{ return mSoSVToiDa;}
        }
        public double HeSoQuyChuan{
        	set{ mHeSoQuyChuan = value;}
        	get{ return mHeSoQuyChuan;}
        }
        public int SoCongThem1Tiet{
        	set{ mSoCongThem1Tiet = value;}
        	get{ return mSoCongThem1Tiet;}
        }
        public double SoTietDinhMuc1Tuan{
        	set{ mSoTietDinhMuc1Tuan = value;}
        	get{ return mSoTietDinhMuc1Tuan;}
        }
    }
}
