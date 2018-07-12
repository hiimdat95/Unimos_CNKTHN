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
    public class cBwsDM_TrinhDo : cBwsBase
    {
        private cDDM_TrinhDo oDDM_TrinhDo;
        private DM_TrinhDoInfo oDM_TrinhDoInfo;

        public cBwsDM_TrinhDo()
        {
            oDDM_TrinhDo = new cDDM_TrinhDo();
        }

        public DataTable Get(DM_TrinhDoInfo pDM_TrinhDoInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_DM_TrinhDo_GetResult>(client.cDDM_TrinhDo_Get(GlobalVar.MaXacThuc, pDM_TrinhDoInfo));
            }
        }

        //public int Add(DM_TrinhDoInfo pDM_TrinhDoInfo)
        //{
        //    int ID = 0;
        //    var client = new UnimOsServiceClient();
        //    ID = client.cDDM_TrinhDo_Add(GlobalVar.MaXacThuc, pDM_TrinhDoInfo);
        //    client.Close();
        //    mErrorMessage = oDDM_TrinhDo.ErrorMessages;
        //    mErrorNumber = oDDM_TrinhDo.ErrorNumber;
        //    return ID;
        //}

        //public void Update(DM_TrinhDoInfo pDM_TrinhDoInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDDM_TrinhDo_Update(GlobalVar.MaXacThuc, pDM_TrinhDoInfo);
        //    client.Close();
        //    mErrorMessage = oDDM_TrinhDo.ErrorMessages;
        //    mErrorNumber = oDDM_TrinhDo.ErrorNumber;
        //}

        //public void Delete(DM_TrinhDoInfo pDM_TrinhDoInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDDM_TrinhDo_Delete(GlobalVar.MaXacThuc, pDM_TrinhDoInfo);
        //    client.Close();
        //    mErrorMessage = oDDM_TrinhDo.ErrorMessages;
        //    mErrorNumber = oDDM_TrinhDo.ErrorNumber;
        //}

        //public List<DM_TrinhDoInfo> GetList(DM_TrinhDoInfo pDM_TrinhDoInfo)
        //{
        //    List<DM_TrinhDoInfo> oDM_TrinhDoInfoList = new List<DM_TrinhDoInfo>();
        //    DataTable dtb = Get(pDM_TrinhDoInfo);
        //    if (dtb != null)
        //    {
        //        for (int i = 0; i < dtb.Rows.Count; i++)
        //        {
        //            oDM_TrinhDoInfo = new DM_TrinhDoInfo();


        //            oDM_TrinhDoInfo.DM_TrinhDoID = int.Parse(dtb.Rows[i]["DM_TrinhDoID"].ToString());
        //            oDM_TrinhDoInfo.IDDM_He = int.Parse(dtb.Rows[i]["IDDM_He"].ToString());
        //            oDM_TrinhDoInfo.IDKQHT_QuyChe = int.Parse(dtb.Rows[i]["IDKQHT_QuyChe"].ToString());
        //            oDM_TrinhDoInfo.MaTrinhDo = dtb.Rows[i]["MaTrinhDo"].ToString();
        //            oDM_TrinhDoInfo.TenTrinhDo = dtb.Rows[i]["TenTrinhDo"].ToString();
        //            oDM_TrinhDoInfo.TenTrinhDo_E = dtb.Rows[i]["TenTrinhDo_E"].ToString();

        //            oDM_TrinhDoInfoList.Add(oDM_TrinhDoInfo);
        //        }
        //    }
        //    return oDM_TrinhDoInfoList;
        //}

        public DataTable GetByIDHe(int IDDM_He)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_DM_TrinhDo_GetByIDHeResult>(client.cDDM_TrinhDo_GetByIDHe(GlobalVar.MaXacThuc, IDDM_He));
            }
        }
    }
}
