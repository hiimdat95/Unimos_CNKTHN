using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class SV_AnhXaMonInfo
    {

        private long mSV_AnhXaMonID;
        private int mIDSV_SinhVien;
        private int mIDXL_MonHocTrongKyCu;
        private int mIDXL_MonHocTrongKyMoi;
        private int mIDDM_Lop;

        public string strSV_AnhXaMonID = "SV_AnhXaMonID";
        public string strIDSV_SinhVien = "IDSV_SinhVien";
        public string strIDXL_MonHocTrongKyCu = "IDXL_MonHocTrongKyCu";
        public string strIDXL_MonHocTrongKyMoi = "IDXL_MonHocTrongKyMoi";
        public string strIDDM_Lop = "IDDM_Lop";

        public SV_AnhXaMonInfo()
        { }

        public long SV_AnhXaMonID{
        	set{ mSV_AnhXaMonID = value;}
        	get{ return mSV_AnhXaMonID;}
        }
        public int IDSV_SinhVien{
        	set{ mIDSV_SinhVien = value;}
        	get{ return mIDSV_SinhVien;}
        }
        public int IDXL_MonHocTrongKyCu{
        	set{ mIDXL_MonHocTrongKyCu = value;}
        	get{ return mIDXL_MonHocTrongKyCu;}
        }
        public int IDXL_MonHocTrongKyMoi{
        	set{ mIDXL_MonHocTrongKyMoi = value;}
        	get{ return mIDXL_MonHocTrongKyMoi;}
        }
        public int IDDM_Lop{
        	set{ mIDDM_Lop = value;}
        	get{ return mIDDM_Lop;}
        }
    }
}
