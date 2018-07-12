using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class TC_QuyenHoaDon_TrinhDoInfo
    {

        private int mTC_QuyenHoaDon_TrinhDoID;
        private int mIDTC_QuyenHoaDon;
        private int mIDDM_TrinhDo;

        public string strTC_QuyenHoaDon_TrinhDoID = "TC_QuyenHoaDon_TrinhDoID";
        public string strIDTC_QuyenHoaDon = "IDTC_QuyenHoaDon";
        public string strIDDM_TrinhDo = "IDDM_TrinhDo";

        public TC_QuyenHoaDon_TrinhDoInfo()
        { }

        public int TC_QuyenHoaDon_TrinhDoID{
        	set{ mTC_QuyenHoaDon_TrinhDoID = value;}
        	get{ return mTC_QuyenHoaDon_TrinhDoID;}
        }
        public int IDTC_QuyenHoaDon{
        	set{ mIDTC_QuyenHoaDon = value;}
        	get{ return mIDTC_QuyenHoaDon;}
        }
        public int IDDM_TrinhDo{
        	set{ mIDDM_TrinhDo = value;}
        	get{ return mIDDM_TrinhDo;}
        }
    }
}
