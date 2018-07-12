using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBXL_NgayNghiToanTruong : cBBase
    {
        private cDXL_NgayNghiToanTruong oDXL_NgayNghiToanTruong;
        private XL_NgayNghiToanTruongInfo oXL_NgayNghiToanTruongInfo;

        public cBXL_NgayNghiToanTruong()        
        {
            oDXL_NgayNghiToanTruong = new cDXL_NgayNghiToanTruong();
        }

        public DataTable Get(XL_NgayNghiToanTruongInfo pXL_NgayNghiToanTruongInfo)        
        {
            return oDXL_NgayNghiToanTruong.Get(pXL_NgayNghiToanTruongInfo);
        }

        public int Add(XL_NgayNghiToanTruongInfo pXL_NgayNghiToanTruongInfo)
        {
			int ID = 0;
            ID = oDXL_NgayNghiToanTruong.Add(pXL_NgayNghiToanTruongInfo);
            mErrorMessage = oDXL_NgayNghiToanTruong.ErrorMessages;
            mErrorNumber = oDXL_NgayNghiToanTruong.ErrorNumber;
            return ID;
        }

        public void Update(XL_NgayNghiToanTruongInfo pXL_NgayNghiToanTruongInfo)
        {
            oDXL_NgayNghiToanTruong.Update(pXL_NgayNghiToanTruongInfo);
            mErrorMessage = oDXL_NgayNghiToanTruong.ErrorMessages;
            mErrorNumber = oDXL_NgayNghiToanTruong.ErrorNumber;
        }
        
        public void Delete(XL_NgayNghiToanTruongInfo pXL_NgayNghiToanTruongInfo)
        {
            oDXL_NgayNghiToanTruong.Delete(pXL_NgayNghiToanTruongInfo);
            mErrorMessage = oDXL_NgayNghiToanTruong.ErrorMessages;
            mErrorNumber = oDXL_NgayNghiToanTruong.ErrorNumber;
        }

        public List<XL_NgayNghiToanTruongInfo> GetList(XL_NgayNghiToanTruongInfo pXL_NgayNghiToanTruongInfo)
        {
            List<XL_NgayNghiToanTruongInfo> oXL_NgayNghiToanTruongInfoList = new List<XL_NgayNghiToanTruongInfo>();
            DataTable dtb = Get(pXL_NgayNghiToanTruongInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oXL_NgayNghiToanTruongInfo = new XL_NgayNghiToanTruongInfo();
                    

                    oXL_NgayNghiToanTruongInfo.XL_NgayNghiToanTruongID = int.Parse(dtb.Rows[i]["XL_NgayNghiToanTruongID"].ToString());
                    oXL_NgayNghiToanTruongInfo.IDXL_KeHaochKhac = int.Parse(dtb.Rows[i]["IDXL_KeHaochKhac"].ToString());
                    oXL_NgayNghiToanTruongInfo.IDXL_Tuan = long.Parse(dtb.Rows[i]["IDXL_Tuan"].ToString());
                    oXL_NgayNghiToanTruongInfo.NgayNghi = dtb.Rows[i]["NgayNghi"].ToString();
                    oXL_NgayNghiToanTruongInfo.GhiChu = dtb.Rows[i]["GhiChu"].ToString();
                    
                    oXL_NgayNghiToanTruongInfoList.Add(oXL_NgayNghiToanTruongInfo);
                }
            }
            return oXL_NgayNghiToanTruongInfoList;
        }
    }
}
