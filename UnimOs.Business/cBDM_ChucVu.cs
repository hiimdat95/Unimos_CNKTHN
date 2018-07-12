using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_ChucVu : cBBase
    {
        private cDDM_ChucVu oDDM_ChucVu;
        private DM_ChucVuInfo oDM_ChucVuInfo;

        public cBDM_ChucVu()        
        {
            oDDM_ChucVu = new cDDM_ChucVu();
        }

        public DataTable Get(DM_ChucVuInfo pDM_ChucVuInfo)        
        {
            return oDDM_ChucVu.Get(pDM_ChucVuInfo);
        }

        public DataTable ChucVu_QuaTrinhBoNhiem_GetBy_IDNS_GiaoVien(int IDNS_GiaoVien)
        {
            return oDDM_ChucVu.ChucVu_QuaTrinhBoNhiem_GetBy_IDNS_GiaoVien(IDNS_GiaoVien);
        }

        public int Add(DM_ChucVuInfo pDM_ChucVuInfo)
        {
			int ID = 0;
            ID = oDDM_ChucVu.Add(pDM_ChucVuInfo);
            mErrorMessage = oDDM_ChucVu.ErrorMessages;
            mErrorNumber = oDDM_ChucVu.ErrorNumber;
            return ID;
        }

        public void Update(DM_ChucVuInfo pDM_ChucVuInfo)
        {
            oDDM_ChucVu.Update(pDM_ChucVuInfo);
            mErrorMessage = oDDM_ChucVu.ErrorMessages;
            mErrorNumber = oDDM_ChucVu.ErrorNumber;
        }
        
        public void Delete(DM_ChucVuInfo pDM_ChucVuInfo)
        {
            oDDM_ChucVu.Delete(pDM_ChucVuInfo);
            mErrorMessage = oDDM_ChucVu.ErrorMessages;
            mErrorNumber = oDDM_ChucVu.ErrorNumber;
        }

        public List<DM_ChucVuInfo> GetList(DM_ChucVuInfo pDM_ChucVuInfo)
        {
            List<DM_ChucVuInfo> oDM_ChucVuInfoList = new List<DM_ChucVuInfo>();
            DataTable dtb = Get(pDM_ChucVuInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_ChucVuInfo = new DM_ChucVuInfo();

                    oDM_ChucVuInfo.DM_ChucVuID = int.Parse(dtb.Rows[i]["DM_ChucVuID"].ToString());
                    oDM_ChucVuInfo.TenChucVu = dtb.Rows[i]["TenChucVu"].ToString();
                    oDM_ChucVuInfo.SoGioGiam = int.Parse(dtb.Rows[i]["SoGioGiam"].ToString());
                    oDM_ChucVuInfo.PhanTramGioGiam = float.Parse(dtb.Rows[i]["PhanTramGioGiam"].ToString());
                    oDM_ChucVuInfo.IDLoaiVienChuc = dtb.Rows[i]["IDLoaiVienChuc"].ToString();
                    
                    oDM_ChucVuInfoList.Add(oDM_ChucVuInfo);
                }
            }
            return oDM_ChucVuInfoList;
        }
        
        public void ToDataRow(DM_ChucVuInfo pDM_ChucVuInfo, ref DataRow dr)
        {

			dr[pDM_ChucVuInfo.strDM_ChucVuID] = pDM_ChucVuInfo.DM_ChucVuID;
			dr[pDM_ChucVuInfo.strTenChucVu] = pDM_ChucVuInfo.TenChucVu;
            dr[pDM_ChucVuInfo.strSoGioGiam] = pDM_ChucVuInfo.SoGioGiam;
            dr[pDM_ChucVuInfo.strPhanTramGioGiam] = pDM_ChucVuInfo.PhanTramGioGiam;
            dr[pDM_ChucVuInfo.strIDLoaiVienChuc] = pDM_ChucVuInfo.IDLoaiVienChuc;
        }
        
        public void ToInfo(ref DM_ChucVuInfo pDM_ChucVuInfo, DataRow dr)
        {

			pDM_ChucVuInfo.DM_ChucVuID = int.Parse(dr[pDM_ChucVuInfo.strDM_ChucVuID].ToString());
			pDM_ChucVuInfo.TenChucVu = dr[pDM_ChucVuInfo.strTenChucVu].ToString();
            pDM_ChucVuInfo.SoGioGiam = int.Parse("0" + dr[pDM_ChucVuInfo.strSoGioGiam]);
            pDM_ChucVuInfo.PhanTramGioGiam = float.Parse("0" + dr[pDM_ChucVuInfo.strPhanTramGioGiam]);
            pDM_ChucVuInfo.IDLoaiVienChuc = dr[pDM_ChucVuInfo.strIDLoaiVienChuc].ToString();
        }
    }
}
