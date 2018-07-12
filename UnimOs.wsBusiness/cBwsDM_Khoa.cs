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
    public class cBwsDM_Khoa : cBwsBase
    {
        private cDDM_Khoa oDDM_Khoa;
        private DM_KhoaInfo oDM_KhoaInfo;

        public cBwsDM_Khoa()
        {
            oDDM_Khoa = new cDDM_Khoa();
        }

        public DataTable Get(DM_KhoaInfo pDM_KhoaInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_DM_Khoa_GetResult>(client.cDDM_Khoa_Get(GlobalVar.MaXacThuc, pDM_KhoaInfo));
            }
        }

        public DataTable GetByIDBoMon(int IDDM_BoMon)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_DM_Khoa_GetByIDBoMonResult>(client.cDDM_Khoa_GetByIDBoMon(GlobalVar.MaXacThuc, IDDM_BoMon));
            }
        }

        //public int Add(DM_KhoaInfo pDM_KhoaInfo)
        //{
        //    int ID = 0;
        //    var client = new UnimOsServiceClient();
        //    ID = client.cDDM_Khoa_Add(GlobalVar.MaXacThuc, pDM_KhoaInfo);
        //    client.Close();
        //    mErrorMessage = oDDM_Khoa.ErrorMessages;
        //    mErrorNumber = oDDM_Khoa.ErrorNumber;
        //    return ID;
        //}

        //public void Update(DM_KhoaInfo pDM_KhoaInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDDM_Khoa_Update(GlobalVar.MaXacThuc, pDM_KhoaInfo);
        //    client.Close();
        //    mErrorMessage = oDDM_Khoa.ErrorMessages;
        //    mErrorNumber = oDDM_Khoa.ErrorNumber;
        //}

        //public void Delete(DM_KhoaInfo pDM_KhoaInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDDM_Khoa_Delete(GlobalVar.MaXacThuc, pDM_KhoaInfo);
        //    client.Close();
        //    mErrorMessage = oDDM_Khoa.ErrorMessages;
        //    mErrorNumber = oDDM_Khoa.ErrorNumber;
        //}

        public List<DM_KhoaInfo> GetList(DM_KhoaInfo pDM_KhoaInfo)
        {
            List<DM_KhoaInfo> oDM_KhoaInfoList = new List<DM_KhoaInfo>();
            DataTable dtb = Get(pDM_KhoaInfo);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    oDM_KhoaInfo = new DM_KhoaInfo();


                    oDM_KhoaInfo.DM_KhoaID = int.Parse(dtb.Rows[i]["DM_KhoaID"].ToString());
                    oDM_KhoaInfo.MaKhoa = dtb.Rows[i]["MaKhoa"].ToString();
                    oDM_KhoaInfo.TenKhoa = dtb.Rows[i]["TenKhoa"].ToString();
                    oDM_KhoaInfo.TenKhoa_E = dtb.Rows[i]["TenKhoa_E"].ToString();

                    oDM_KhoaInfoList.Add(oDM_KhoaInfo);
                }
            }
            return oDM_KhoaInfoList;
        }

        public void ToDataRow(DM_KhoaInfo pDM_KhoaInfo, ref DataRow dr)
        {
            dr[pDM_KhoaInfo.strDM_KhoaID] = pDM_KhoaInfo.DM_KhoaID;
            dr[pDM_KhoaInfo.strMaKhoa] = pDM_KhoaInfo.MaKhoa;
            dr[pDM_KhoaInfo.strTenKhoa] = pDM_KhoaInfo.TenKhoa;
            dr[pDM_KhoaInfo.strTenKhoa_E] = pDM_KhoaInfo.TenKhoa_E;
        }
    }
}
