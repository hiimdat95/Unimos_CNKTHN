using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class NS_QuaTrinhCongTacInfo
    {

        private int mNS_QuaTrinhCongTacID;
        private int mIDNS_GiaoVien;
        private string mNoiCongTac;
        private string mNoiDungCongTac;
        private string mChucVuDamNhiem;
        private DateTime mTuNgay;
        private DateTime mDenNgay;
        private bool mDiNuocNgoai;
        private int mIDDM_QuocTich;

        public string strNS_QuaTrinhCongTacID = "NS_QuaTrinhCongTacID";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strNoiCongTac = "NoiCongTac";
        public string strNoiDungCongTac = "NoiDungCongTac";
        public string strChucVuDamNhiem = "ChucVuDamNhiem";
        public string strTuNgay = "TuNgay";
        public string strDenNgay = "DenNgay";
        public string strDiNuocNgoai = "DiNuocNgoai";
        public string strIDDM_QuocTich = "IDDM_QuocTich";

        public NS_QuaTrinhCongTacInfo()
        { }

        public int NS_QuaTrinhCongTacID{
        	set{ mNS_QuaTrinhCongTacID = value;}
        	get{ return mNS_QuaTrinhCongTacID;}
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
        }
        public string NoiCongTac{
        	set{ mNoiCongTac = value;}
        	get{ return mNoiCongTac;}
        }
        public string NoiDungCongTac{
        	set{ mNoiDungCongTac = value;}
        	get{ return mNoiDungCongTac;}
        }
        public string ChucVuDamNhiem{
        	set{ mChucVuDamNhiem = value;}
        	get{ return mChucVuDamNhiem;}
        }
        public DateTime TuNgay{
        	set{ mTuNgay = value;}
        	get{ return mTuNgay;}
        }
        public DateTime DenNgay{
        	set{ mDenNgay = value;}
        	get{ return mDenNgay;}
        }
        public bool DiNuocNgoai{
        	set{ mDiNuocNgoai = value;}
        	get{ return mDiNuocNgoai;}
        }
        public int IDDM_QuocTich{
        	set{ mIDDM_QuocTich = value;}
        	get{ return mIDDM_QuocTich;}
        }
    }
}
