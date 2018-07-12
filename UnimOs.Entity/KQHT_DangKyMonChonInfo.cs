using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_DangKyMonChonInfo
    {

        private int mKQHT_DangKyMonChonID;
        private int mIDSV_SinhVien;
        private int mIDXL_MonHocTrongKy;
        private int mIDHT_User;

        public string strKQHT_DangKyMonChonID = "KQHT_DangKyMonChonID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strIDXL_MonHocTrongKy = "IDXL_MonHocTrongKy";
        public string strIDHT_User = "IDHT_User";

        public KQHT_DangKyMonChonInfo()
        { }

        public int KQHT_DangKyMonChonID{
        	set{ mKQHT_DangKyMonChonID = value;}
        	get{ return mKQHT_DangKyMonChonID;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
        public int IDXL_MonHocTrongKy{
        	set{ mIDXL_MonHocTrongKy = value;}
        	get{ return mIDXL_MonHocTrongKy;}
        }
        public int IDHT_User{
        	set{ mIDHT_User = value;}
        	get{ return mIDHT_User;}
        }
    }
}
