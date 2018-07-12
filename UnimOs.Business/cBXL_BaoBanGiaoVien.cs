using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBXL_BaoBanGiaoVien : cBBase
    {
        private cDXL_BaoBanGiaoVien oDXL_BaoBanGiaoVien;
        private XL_BaoBanGiaoVienInfo oXL_BaoBanGiaoVienInfo;

        public cBXL_BaoBanGiaoVien()        
        {
            oDXL_BaoBanGiaoVien = new cDXL_BaoBanGiaoVien();
        }

        public DataTable Get(XL_BaoBanGiaoVienInfo pXL_BaoBanGiaoVienInfo)        
        {
            return oDXL_BaoBanGiaoVien.Get(pXL_BaoBanGiaoVienInfo);
        }

        public DataTable GetByIDTuan(long IDXL_Tuan)
        {
            return oDXL_BaoBanGiaoVien.GetByIDTuan(IDXL_Tuan);
        }

        public int Add(XL_BaoBanGiaoVienInfo pXL_BaoBanGiaoVienInfo)
        {
			int ID = 0;
            ID = oDXL_BaoBanGiaoVien.Add(pXL_BaoBanGiaoVienInfo);
            mErrorMessage = oDXL_BaoBanGiaoVien.ErrorMessages;
            mErrorNumber = oDXL_BaoBanGiaoVien.ErrorNumber;
            return ID;
        }

        public void Update(XL_BaoBanGiaoVienInfo pXL_BaoBanGiaoVienInfo)
        {
            oDXL_BaoBanGiaoVien.Update(pXL_BaoBanGiaoVienInfo);
            mErrorMessage = oDXL_BaoBanGiaoVien.ErrorMessages;
            mErrorNumber = oDXL_BaoBanGiaoVien.ErrorNumber;
        }
        
        public void Delete(XL_BaoBanGiaoVienInfo pXL_BaoBanGiaoVienInfo)
        {
            oDXL_BaoBanGiaoVien.Delete(pXL_BaoBanGiaoVienInfo);
            mErrorMessage = oDXL_BaoBanGiaoVien.ErrorMessages;
            mErrorNumber = oDXL_BaoBanGiaoVien.ErrorNumber;
        }

        public List<XL_BaoBanGiaoVienInfo> GetList(XL_BaoBanGiaoVienInfo pXL_BaoBanGiaoVienInfo)
        {
            List<XL_BaoBanGiaoVienInfo> oXL_BaoBanGiaoVienInfoList = new List<XL_BaoBanGiaoVienInfo>();
            DataTable dtb = Get(pXL_BaoBanGiaoVienInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oXL_BaoBanGiaoVienInfo = new XL_BaoBanGiaoVienInfo();
                    

                    oXL_BaoBanGiaoVienInfo.XL_BaoBanGiaoVienID = int.Parse(dtb.Rows[i]["XL_BaoBanGiaoVienID"].ToString());
                    oXL_BaoBanGiaoVienInfo.IDTuan = long.Parse(dtb.Rows[i]["IDTuan"].ToString());
                    oXL_BaoBanGiaoVienInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i]["IDNS_GiaoVien"].ToString());
                    oXL_BaoBanGiaoVienInfo.Thu = int.Parse(dtb.Rows[i]["Thu"].ToString());
                    oXL_BaoBanGiaoVienInfo.Tiet = int.Parse(dtb.Rows[i]["Tiet"].ToString());
                    oXL_BaoBanGiaoVienInfo.CaHoc = int.Parse(dtb.Rows[i]["CaHoc"].ToString());
                    oXL_BaoBanGiaoVienInfo.MoTa = dtb.Rows[i]["MoTa"].ToString();
                    
                    oXL_BaoBanGiaoVienInfoList.Add(oXL_BaoBanGiaoVienInfo);
                }
            }
            return oXL_BaoBanGiaoVienInfoList;
        }

        public DataTable GetByHocKy(int IDDM_NamHoc, int HocKy)
        {
            return oDXL_BaoBanGiaoVien.GetByHocKy(IDDM_NamHoc, HocKy);
        }
    }
}
