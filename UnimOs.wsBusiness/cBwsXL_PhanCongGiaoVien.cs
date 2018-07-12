using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.wsBusiness;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;
using UnimOs.wsBusiness.wsUnimOs;
using TruongViet.UnimOs.Entity.Model;

namespace TruongViet.UnimOs.wsBusiness
{
    public class cBwsXL_PhanCongGiaoVien : cBwsBase
    {
        private cDXL_PhanCongGiaoVien oDXL_PhanCongGiaoVien;
        private XL_PhanCongGiaoVienInfo oXL_PhanCongGiaoVienInfo;

        public cBwsXL_PhanCongGiaoVien()
        {
            oDXL_PhanCongGiaoVien = new cDXL_PhanCongGiaoVien();
        }

        public DataTable Get(XL_PhanCongGiaoVienInfo pXL_PhanCongGiaoVienInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_XL_PhanCongGiaoVien_GetResult>(client.cDXL_PhanCongGiaoVien_Get(GlobalVar.MaXacThuc, pXL_PhanCongGiaoVienInfo));
            }
        }

        public DataTable GetByMonHocTrongKy(int IDXL_MonHocTrongKy)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_XL_PhanCongGiaoVien_GetByMonHocTrongKyResult>(client.cDXL_PhanCongGiaoVien_GetByMonHocTrongKy(GlobalVar.MaXacThuc, IDXL_MonHocTrongKy));
            }
        }

        public DataTable GetGiaoVien(int IDXL_MonHocTrongKy, int IDNS_GiaoVien)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_XL_PhanCongGiaoVien_GetGiaoVienResult>(client.cDXL_PhanCongGiaoVien_GetGiaoVien(GlobalVar.MaXacThuc, IDXL_MonHocTrongKy, IDNS_GiaoVien));
            }
        }

        public DataTable GetGiaoVienByMonHocTrongKy(int IDXL_MonHocTrongKy)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_XL_PhanCongGiaoVien_GetGiaoVienByMonHocTrongKyResult>(client.cDXL_PhanCongGiaoVien_GetGiaoVienByMonHocTrongKy(GlobalVar.MaXacThuc, IDXL_MonHocTrongKy));
            }
        }

        public int Add(XL_PhanCongGiaoVienInfo pXL_PhanCongGiaoVienInfo)
        {
            int ID = 0;
            var client = new UnimOsServiceClient();
            ID = client.cDXL_PhanCongGiaoVien_Add(GlobalVar.MaXacThuc, pXL_PhanCongGiaoVienInfo);
            client.Close();
            mErrorMessage = oDXL_PhanCongGiaoVien.ErrorMessages;
            mErrorNumber = oDXL_PhanCongGiaoVien.ErrorNumber;
            return ID;
        }

        public void Update(XL_PhanCongGiaoVienInfo pXL_PhanCongGiaoVienInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDXL_PhanCongGiaoVien_Update(GlobalVar.MaXacThuc, pXL_PhanCongGiaoVienInfo);
            client.Close();
            mErrorMessage = oDXL_PhanCongGiaoVien.ErrorMessages;
            mErrorNumber = oDXL_PhanCongGiaoVien.ErrorNumber;
        }

        public void Delete(XL_PhanCongGiaoVienInfo pXL_PhanCongGiaoVienInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDXL_PhanCongGiaoVien_Delete(GlobalVar.MaXacThuc, pXL_PhanCongGiaoVienInfo);
            client.Close();
            mErrorMessage = oDXL_PhanCongGiaoVien.ErrorMessages;
            mErrorNumber = oDXL_PhanCongGiaoVien.ErrorNumber;
        }

        public void DeleteByMonHoc(int IDXL_MonHocTrongKy, string IDNS_GiaoViens)
        {
            var client = new UnimOsServiceClient();
            client.cDXL_PhanCongGiaoVien_DeleteByMonHoc(GlobalVar.MaXacThuc, IDXL_MonHocTrongKy, IDNS_GiaoViens);
            client.Close();
            mErrorMessage = oDXL_PhanCongGiaoVien.ErrorMessages;
            mErrorNumber = oDXL_PhanCongGiaoVien.ErrorNumber;
        }

        public List<XL_PhanCongGiaoVienInfo> GetList(XL_PhanCongGiaoVienInfo pXL_PhanCongGiaoVienInfo)
        {
            List<XL_PhanCongGiaoVienInfo> oXL_PhanCongGiaoVienInfoList = new List<XL_PhanCongGiaoVienInfo>();
            DataTable dtb = Get(pXL_PhanCongGiaoVienInfo);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
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
