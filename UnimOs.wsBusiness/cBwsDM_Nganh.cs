using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.wsBusiness;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Entity.Model;
using TruongViet.UnimOs.Data;
using UnimOs.wsBusiness.wsUnimOs;

namespace TruongViet.UnimOs.wsBusiness
{
    public class cBwsDM_Nganh : cBwsBase
    {
        private cDDM_Nganh oDDM_Nganh;
        private DM_NganhInfo oDM_NganhInfo;

        public cBwsDM_Nganh()
        {
            oDDM_Nganh = new cDDM_Nganh();
        }

        public DataTable Get(DM_NganhInfo pDM_NganhInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_DM_Nganh_GetResult>(client.cDDM_Nganh_Get(GlobalVar.MaXacThuc, pDM_NganhInfo));
            }
        }

        public DataTable GetByIDKhoa(int IDDM_Khoa)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_DM_Nganh_GetByIDKhoaResult>(client.cDDM_Nganh_GetByIDKhoa(GlobalVar.MaXacThuc, IDDM_Khoa));
            }
        }

        //public int Add(DM_NganhInfo pDM_NganhInfo)
        //{
        //    int ID = 0;
        //    var client = new UnimOsServiceClient();
        //    ID = client.cDDM_Nganh_Add(GlobalVar.MaXacThuc, pDM_NganhInfo);
        //    client.Close();
        //    mErrorMessage = oDDM_Nganh.ErrorMessages;
        //    mErrorNumber = oDDM_Nganh.ErrorNumber;
        //    return ID;
        //}

        //public void Update(DM_NganhInfo pDM_NganhInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDDM_Nganh_Update(GlobalVar.MaXacThuc, pDM_NganhInfo);
        //    client.Close();
        //    mErrorMessage = oDDM_Nganh.ErrorMessages;
        //    mErrorNumber = oDDM_Nganh.ErrorNumber;
        //}

        //public void Delete(DM_NganhInfo pDM_NganhInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDDM_Nganh_Delete(GlobalVar.MaXacThuc, pDM_NganhInfo);
        //    client.Close();
        //    mErrorMessage = oDDM_Nganh.ErrorMessages;
        //    mErrorNumber = oDDM_Nganh.ErrorNumber;
        //}

        public List<DM_NganhInfo> GetList(DM_NganhInfo pDM_NganhInfo)
        {
            List<DM_NganhInfo> oDM_NganhInfoList = new List<DM_NganhInfo>();
            DataTable dtb = Get(pDM_NganhInfo);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    oDM_NganhInfo = new DM_NganhInfo();


                    oDM_NganhInfo.DM_NganhID = int.Parse(dtb.Rows[i]["DM_NganhID"].ToString());
                    oDM_NganhInfo.IDDM_Khoa = int.Parse(dtb.Rows[i]["IDDM_Khoa"].ToString());
                    oDM_NganhInfo.MaNganh = dtb.Rows[i]["MaNganh"].ToString();
                    oDM_NganhInfo.TenNganh = dtb.Rows[i]["TenNganh"].ToString();
                    oDM_NganhInfo.TenNganh_E = dtb.Rows[i]["TenNganh_E"].ToString();

                    oDM_NganhInfoList.Add(oDM_NganhInfo);
                }
            }
            return oDM_NganhInfoList;
        }

        public void ToDataRow(DM_NganhInfo pDM_NganhInfo, ref DataRow dr)
        {
            dr[pDM_NganhInfo.strDM_NganhID] = pDM_NganhInfo.DM_NganhID;
            dr[pDM_NganhInfo.strIDDM_Khoa] = pDM_NganhInfo.IDDM_Khoa;
            dr[pDM_NganhInfo.strMaNganh] = pDM_NganhInfo.MaNganh;
            dr[pDM_NganhInfo.strTenNganh] = pDM_NganhInfo.TenNganh;
            dr[pDM_NganhInfo.strTenNganh_E] = pDM_NganhInfo.TenNganh_E;
        }
    }
}
