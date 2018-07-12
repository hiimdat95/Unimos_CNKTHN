using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class NS_QuaTrinhBoiDuongInfo
    {

        private int mNS_QuaTrinhBoiDuongID;
        private int mIDNS_GiaoVien;
        private string mNoiBoiDuong;
        private string mNoiDungBoiDuong;
        private DateTime mTuNgay;
        private DateTime mDenNgay;
        private int mIDDM_VanBangChungChi;
        private int mIDDM_XepLoaiChungChi;
        private int mIDDM_HinhThucDaoTao;
        private bool mCoThoiHan;
        private DateTime mThoiHanTuNgay;
        private DateTime mThoiHanDenNgay;

        public string strNS_QuaTrinhBoiDuongID = "NS_QuaTrinhBoiDuongID";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strNoiBoiDuong = "NoiBoiDuong";
        public string strNoiDungBoiDuong = "NoiDungBoiDuong";
        public string strTuNgay = "TuNgay";
        public string strDenNgay = "DenNgay";
        public string strIDDM_VanBangChungChi = "IDDM_VanBangChungChi";
        public string strIDDM_XepLoaiChungChi = "IDDM_XepLoaiChungChi";
        public string strIDDM_HinhThucDaoTao = "IDDM_HinhThucDaoTao";
        public string strCoThoiHan = "CoThoiHan";
        public string strThoiHanTuNgay = "ThoiHanTuNgay";
        public string strThoiHanDenNgay = "ThoiHanDenNgay";

        public NS_QuaTrinhBoiDuongInfo()
        { }

        public int NS_QuaTrinhBoiDuongID{
        	set{ mNS_QuaTrinhBoiDuongID = value;}
        	get{ return mNS_QuaTrinhBoiDuongID;}
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
        }
        public string NoiBoiDuong{
        	set{ mNoiBoiDuong = value;}
        	get{ return mNoiBoiDuong;}
        }
        public string NoiDungBoiDuong{
        	set{ mNoiDungBoiDuong = value;}
        	get{ return mNoiDungBoiDuong;}
        }
        public DateTime TuNgay{
        	set{ mTuNgay = value;}
        	get{ return mTuNgay;}
        }
        public DateTime DenNgay{
        	set{ mDenNgay = value;}
        	get{ return mDenNgay;}
        }
        public int IDDM_VanBangChungChi{
        	set{ mIDDM_VanBangChungChi = value;}
        	get{ return mIDDM_VanBangChungChi;}
        }
        public int IDDM_XepLoaiChungChi{
        	set{ mIDDM_XepLoaiChungChi = value;}
        	get{ return mIDDM_XepLoaiChungChi;}
        }
        public int IDDM_HinhThucDaoTao{
        	set{ mIDDM_HinhThucDaoTao = value;}
        	get{ return mIDDM_HinhThucDaoTao;}
        }
        public bool CoThoiHan{
        	set{ mCoThoiHan = value;}
        	get{ return mCoThoiHan;}
        }
        public DateTime ThoiHanTuNgay{
        	set{ mThoiHanTuNgay = value;}
        	get{ return mThoiHanTuNgay;}
        }
        public DateTime ThoiHanDenNgay{
        	set{ mThoiHanDenNgay = value;}
        	get{ return mThoiHanDenNgay;}
        }
    }
}
