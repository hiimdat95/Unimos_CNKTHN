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
    public class cBwsDM_He : cBwsBase
    {
        private cDDM_He oDDM_He;
        private DM_HeInfo oDM_HeInfo;

        public cBwsDM_He()
        {
            oDDM_He = new cDDM_He();
        }

        //public DataTable Get(DM_HeInfo pDM_HeInfo)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<DM_HeInfo>(client.cDDM_He_Get(GlobalVar.MaXacThuc, pDM_HeInfo));
        //    }
        //}

        //public int Add(DM_HeInfo pDM_HeInfo)
        //{
        //    int ID = 0;
        //    var client = new UnimOsServiceClient();
        //    ID = client.cDDM_He_Add(GlobalVar.MaXacThuc, pDM_HeInfo);
        //    client.Close();
        //    mErrorMessage = oDDM_He.ErrorMessages;
        //    mErrorNumber = oDDM_He.ErrorNumber;
        //    return ID;
        //}

        //public void Update(DM_HeInfo pDM_HeInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDDM_He_Update(GlobalVar.MaXacThuc, pDM_HeInfo);
        //    client.Close();
        //    mErrorMessage = oDDM_He.ErrorMessages;
        //    mErrorNumber = oDDM_He.ErrorNumber;
        //}

        //public void Delete(DM_HeInfo pDM_HeInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDDM_He_Delete(GlobalVar.MaXacThuc, pDM_HeInfo);
        //    client.Close();
        //    mErrorMessage = oDDM_He.ErrorMessages;
        //    mErrorNumber = oDDM_He.ErrorNumber;
        //}

        //public List<DM_HeInfo> GetList(DM_HeInfo pDM_HeInfo)
        //{
        //    List<DM_HeInfo> oDM_HeInfoList = new List<DM_HeInfo>();
        //    DataTable dtb = Get(pDM_HeInfo);
        //    if (dtb != null)
        //    {
        //        for (int i = 0; i < dtb.Rows.Count; i++)
        //        {
        //            oDM_HeInfo = new DM_HeInfo();


        //            oDM_HeInfo.DM_HeID = int.Parse(dtb.Rows[i]["DM_HeID"].ToString());
        //            oDM_HeInfo.MaHe = dtb.Rows[i]["MaHe"].ToString();
        //            oDM_HeInfo.TenHe = dtb.Rows[i]["TenHe"].ToString();
        //            oDM_HeInfo.TenHe_E = dtb.Rows[i]["TenHe_E"].ToString();

        //            oDM_HeInfoList.Add(oDM_HeInfo);
        //        }
        //    }
        //    return oDM_HeInfoList;
        //}
    }
}
