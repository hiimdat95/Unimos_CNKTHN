using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class NS_QuaTrinhThamGiaToChucCTXHInfo
    {

        private int mNS_QuaTrinhThamGiaToChucCTXHID;
        private int mIDNS_GiaoVien;
        private DateTime mNgayThamGia;
        private string mTenToChuc;
        private string mCongViec;

        public string strNS_QuaTrinhThamGiaToChucCTXHID = "NS_QuaTrinhThamGiaToChucCTXHID";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strNgayThamGia = "NgayThamGia";
        public string strTenToChuc = "TenToChuc";
        public string strCongViec = "CongViec";

        public NS_QuaTrinhThamGiaToChucCTXHInfo()
        { }

        public int NS_QuaTrinhThamGiaToChucCTXHID{
        	set{ mNS_QuaTrinhThamGiaToChucCTXHID = value;}
        	get{ return mNS_QuaTrinhThamGiaToChucCTXHID;}
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
        }
        public DateTime NgayThamGia{
        	set{ mNgayThamGia = value;}
        	get{ return mNgayThamGia;}
        }
        public string TenToChuc{
        	set{ mTenToChuc = value;}
        	get{ return mTenToChuc;}
        }
        public string CongViec{
        	set{ mCongViec = value;}
        	get{ return mCongViec;}
        }
    }
}
