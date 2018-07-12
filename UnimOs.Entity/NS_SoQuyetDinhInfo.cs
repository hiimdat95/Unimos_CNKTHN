using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class NS_SoQuyetDinhInfo
    {

        private int mNS_SoQuyetDinhID;
        private string mSoQuyetDinh;
        private DateTime mNgayQuyetDinh;

        public string strNS_SoQuyetDinhID = "NS_SoQuyetDinhID";
        public string strSoQuyetDinh = "SoQuyetDinh";
        public string strNgayQuyetDinh = "NgayQuyetDinh";

        public NS_SoQuyetDinhInfo()
        { }

        public int NS_SoQuyetDinhID{
        	set{ mNS_SoQuyetDinhID = value;}
        	get{ return mNS_SoQuyetDinhID;}
        }
        public string SoQuyetDinh{
        	set{ mSoQuyetDinh = value;}
        	get{ return mSoQuyetDinh;}
        }
        public DateTime NgayQuyetDinh{
        	set{ mNgayQuyetDinh = value;}
        	get{ return mNgayQuyetDinh;}
        }
    }
}
