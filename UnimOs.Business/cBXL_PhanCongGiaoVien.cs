using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBXL_PhanCongGiaoVien : cBBase
    {
        private cDXL_PhanCongGiaoVien oDXL_PhanCongGiaoVien;
        private XL_PhanCongGiaoVienInfo oXL_PhanCongGiaoVienInfo;

        public cBXL_PhanCongGiaoVien()        
        {
            oDXL_PhanCongGiaoVien = new cDXL_PhanCongGiaoVien();
        }

        public DataTable Get(XL_PhanCongGiaoVienInfo pXL_PhanCongGiaoVienInfo)        
        {
            return oDXL_PhanCongGiaoVien.Get(pXL_PhanCongGiaoVienInfo);
        }

        public DataTable GetByMonHocTrongKy(int IDXL_MonHocTrongKy)
        {
            return oDXL_PhanCongGiaoVien.GetByMonHocTrongKy(IDXL_MonHocTrongKy);
        }

        public DataTable GetGiaoVien(int IDXL_MonHocTrongKy, int IDNS_GiaoVien)
        {
            return oDXL_PhanCongGiaoVien.GetGiaoVien(IDXL_MonHocTrongKy, IDNS_GiaoVien);
        }

        public DataTable GetGiaoVienByMonHocTrongKy(int IDXL_MonHocTrongKy)
        {
            return oDXL_PhanCongGiaoVien.GetGiaoVienByMonHocTrongKy(IDXL_MonHocTrongKy);
        }

        public int Add(XL_PhanCongGiaoVienInfo pXL_PhanCongGiaoVienInfo)
        {
			int ID = 0;
            ID = oDXL_PhanCongGiaoVien.Add(pXL_PhanCongGiaoVienInfo);
            mErrorMessage = oDXL_PhanCongGiaoVien.ErrorMessages;
            mErrorNumber = oDXL_PhanCongGiaoVien.ErrorNumber;
            return ID;
        }

        public void Update(XL_PhanCongGiaoVienInfo pXL_PhanCongGiaoVienInfo)
        {
            oDXL_PhanCongGiaoVien.Update(pXL_PhanCongGiaoVienInfo);
            mErrorMessage = oDXL_PhanCongGiaoVien.ErrorMessages;
            mErrorNumber = oDXL_PhanCongGiaoVien.ErrorNumber;
        }
        
        public void Delete(XL_PhanCongGiaoVienInfo pXL_PhanCongGiaoVienInfo)
        {
            oDXL_PhanCongGiaoVien.Delete(pXL_PhanCongGiaoVienInfo);
            mErrorMessage = oDXL_PhanCongGiaoVien.ErrorMessages;
            mErrorNumber = oDXL_PhanCongGiaoVien.ErrorNumber;
        }

        public void DeleteByMonHoc(int IDXL_MonHocTrongKy, string IDNS_GiaoViens)
        {
            oDXL_PhanCongGiaoVien.DeleteByMonHoc(IDXL_MonHocTrongKy, IDNS_GiaoViens);
            mErrorMessage = oDXL_PhanCongGiaoVien.ErrorMessages;
            mErrorNumber = oDXL_PhanCongGiaoVien.ErrorNumber;
        }

        public List<XL_PhanCongGiaoVienInfo> GetList(XL_PhanCongGiaoVienInfo pXL_PhanCongGiaoVienInfo)
        {
            List<XL_PhanCongGiaoVienInfo> oXL_PhanCongGiaoVienInfoList = new List<XL_PhanCongGiaoVienInfo>();
            DataTable dtb = Get(pXL_PhanCongGiaoVienInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oXL_PhanCongGiaoVienInfo = new XL_PhanCongGiaoVienInfo();

                    oXL_PhanCongGiaoVienInfo.XL_PhanCongGiaoVienID = int.Parse(dtb.Rows[i]["XL_PhanCongGiaoVienID"].ToString());
                    oXL_PhanCongGiaoVienInfo.IDXL_MonHocTrongKy = int.Parse(dtb.Rows[i]["IDXL_MonHocTrongKy"].ToString());
                    oXL_PhanCongGiaoVienInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i]["IDNS_GiaoVien"].ToString());
                    
                    oXL_PhanCongGiaoVienInfoList.Add(oXL_PhanCongGiaoVienInfo);
                }
            }
            return oXL_PhanCongGiaoVienInfoList;
        }
        
        public void ToDataRow(XL_PhanCongGiaoVienInfo pXL_PhanCongGiaoVienInfo, ref DataRow dr)
        {
			dr[pXL_PhanCongGiaoVienInfo.strXL_PhanCongGiaoVienID] = pXL_PhanCongGiaoVienInfo.XL_PhanCongGiaoVienID;
			dr[pXL_PhanCongGiaoVienInfo.strIDXL_MonHocTrongKy] = pXL_PhanCongGiaoVienInfo.IDXL_MonHocTrongKy;
			dr[pXL_PhanCongGiaoVienInfo.strIDNS_GiaoVien] = pXL_PhanCongGiaoVienInfo.IDNS_GiaoVien;
            dr[pXL_PhanCongGiaoVienInfo.strSoTiet] = pXL_PhanCongGiaoVienInfo.SoTiet;
        }
        
        public void ToInfo(ref XL_PhanCongGiaoVienInfo pXL_PhanCongGiaoVienInfo, DataRow dr)
        {
			pXL_PhanCongGiaoVienInfo.XL_PhanCongGiaoVienID = int.Parse(dr[pXL_PhanCongGiaoVienInfo.strXL_PhanCongGiaoVienID].ToString());
			pXL_PhanCongGiaoVienInfo.IDXL_MonHocTrongKy = int.Parse(dr[pXL_PhanCongGiaoVienInfo.strIDXL_MonHocTrongKy].ToString());
			pXL_PhanCongGiaoVienInfo.IDNS_GiaoVien = int.Parse(dr[pXL_PhanCongGiaoVienInfo.strIDNS_GiaoVien].ToString());
            pXL_PhanCongGiaoVienInfo.SoTiet = int.Parse("0" + dr[pXL_PhanCongGiaoVienInfo.strSoTiet]);
        }
    }
}
