using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBSV_Lop_GiaoVienChuNhiem : cBBase
    {
        private cDSV_Lop_GiaoVienChuNhiem oDSV_Lop_GiaoVienChuNhiem;
        private SV_Lop_GiaoVienChuNhiemInfo oSV_Lop_GiaoVienChuNhiemInfo;

        public cBSV_Lop_GiaoVienChuNhiem()        
        {
            oDSV_Lop_GiaoVienChuNhiem = new cDSV_Lop_GiaoVienChuNhiem();
        }

        public DataTable Get(SV_Lop_GiaoVienChuNhiemInfo pSV_Lop_GiaoVienChuNhiemInfo)        
        {
            return oDSV_Lop_GiaoVienChuNhiem.Get(pSV_Lop_GiaoVienChuNhiemInfo);
        }

        public int Add(SV_Lop_GiaoVienChuNhiemInfo pSV_Lop_GiaoVienChuNhiemInfo)
        {
			int ID = 0;
            ID = oDSV_Lop_GiaoVienChuNhiem.Add(pSV_Lop_GiaoVienChuNhiemInfo);
            mErrorMessage = oDSV_Lop_GiaoVienChuNhiem.ErrorMessages;
            mErrorNumber = oDSV_Lop_GiaoVienChuNhiem.ErrorNumber;
            return ID;
        }

        public void Update(SV_Lop_GiaoVienChuNhiemInfo pSV_Lop_GiaoVienChuNhiemInfo)
        {
            oDSV_Lop_GiaoVienChuNhiem.Update(pSV_Lop_GiaoVienChuNhiemInfo);
            mErrorMessage = oDSV_Lop_GiaoVienChuNhiem.ErrorMessages;
            mErrorNumber = oDSV_Lop_GiaoVienChuNhiem.ErrorNumber;
        }
        
        public void Delete(SV_Lop_GiaoVienChuNhiemInfo pSV_Lop_GiaoVienChuNhiemInfo)
        {
            oDSV_Lop_GiaoVienChuNhiem.Delete(pSV_Lop_GiaoVienChuNhiemInfo);
            mErrorMessage = oDSV_Lop_GiaoVienChuNhiem.ErrorMessages;
            mErrorNumber = oDSV_Lop_GiaoVienChuNhiem.ErrorNumber;
        }

        public List<SV_Lop_GiaoVienChuNhiemInfo> GetList(SV_Lop_GiaoVienChuNhiemInfo pSV_Lop_GiaoVienChuNhiemInfo)
        {
            List<SV_Lop_GiaoVienChuNhiemInfo> oSV_Lop_GiaoVienChuNhiemInfoList = new List<SV_Lop_GiaoVienChuNhiemInfo>();
            DataTable dtb = Get(pSV_Lop_GiaoVienChuNhiemInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oSV_Lop_GiaoVienChuNhiemInfo = new SV_Lop_GiaoVienChuNhiemInfo();
                    

                    oSV_Lop_GiaoVienChuNhiemInfo.SV_Lop_GiaoVienChuNhiemID = int.Parse(dtb.Rows[i]["SV_Lop_GiaoVienChuNhiemID"].ToString());
                    oSV_Lop_GiaoVienChuNhiemInfo.IDDM_Lop = int.Parse(dtb.Rows[i]["IDDM_Lop"].ToString());
                    oSV_Lop_GiaoVienChuNhiemInfo.IDDM_GiaoVien = int.Parse(dtb.Rows[i]["IDDM_GiaoVien"].ToString());
                    oSV_Lop_GiaoVienChuNhiemInfo.TuNgay = DateTime.Parse(dtb.Rows[i]["TuNgay"].ToString());
                    oSV_Lop_GiaoVienChuNhiemInfo.DenNgay = DateTime.Parse(dtb.Rows[i]["DenNgay"].ToString());
                    
                    oSV_Lop_GiaoVienChuNhiemInfoList.Add(oSV_Lop_GiaoVienChuNhiemInfo);
                }
            }
            return oSV_Lop_GiaoVienChuNhiemInfoList;
        }
    }
}
