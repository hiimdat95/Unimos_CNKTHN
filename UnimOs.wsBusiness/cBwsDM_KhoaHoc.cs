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
    public class cBwsDM_KhoaHoc : cBwsBase
    {
        private cDDM_KhoaHoc oDDM_KhoaHoc;
        private DM_KhoaHocInfo oDM_KhoaHocInfo;

        public cBwsDM_KhoaHoc()
        {
            oDDM_KhoaHoc = new cDDM_KhoaHoc();
        }

        //public DataTable Get(DM_KhoaHocInfo pDM_KhoaHocInfo)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<DM_KhoaHocInfo>(client.cDDM_KhoaHoc_Get(GlobalVar.MaXacThuc, pDM_KhoaHocInfo));
        //    }
        //}

        public DataTable GetAll()
        {
            return oDDM_KhoaHoc.GetAll();
        }

        //public int Add(DM_KhoaHocInfo pDM_KhoaHocInfo)
        //{
        //    int ID = 0;
        //    var client = new UnimOsServiceClient();
        //    ID = client.cDDM_KhoaHoc_Add(GlobalVar.MaXacThuc, pDM_KhoaHocInfo);
        //    client.Close();
        //    mErrorMessage = oDDM_KhoaHoc.ErrorMessages;
        //    mErrorNumber = oDDM_KhoaHoc.ErrorNumber;
        //    return ID;
        //}

        //public void Update(DM_KhoaHocInfo pDM_KhoaHocInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDDM_KhoaHoc_Update(GlobalVar.MaXacThuc, pDM_KhoaHocInfo);
        //    client.Close();
        //    mErrorMessage = oDDM_KhoaHoc.ErrorMessages;
        //    mErrorNumber = oDDM_KhoaHoc.ErrorNumber;
        //}

        //public void Delete(DM_KhoaHocInfo pDM_KhoaHocInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDDM_KhoaHoc_Delete(GlobalVar.MaXacThuc, pDM_KhoaHocInfo);
        //    client.Close();
        //    mErrorMessage = oDDM_KhoaHoc.ErrorMessages;
        //    mErrorNumber = oDDM_KhoaHoc.ErrorNumber;
        //}

        //public List<DM_KhoaHocInfo> GetList(DM_KhoaHocInfo pDM_KhoaHocInfo)
        //{
        //    List<DM_KhoaHocInfo> oDM_KhoaHocInfoList = new List<DM_KhoaHocInfo>();
        //    DataTable dtb = Get(pDM_KhoaHocInfo);
        //    if (dtb != null)
        //    {
        //        for (int i = 0; i < dtb.Rows.Count; i++)
        //        {
        //            oDM_KhoaHocInfo = new DM_KhoaHocInfo();

        //            oDM_KhoaHocInfo.DM_KhoaHocID = int.Parse(dtb.Rows[i]["DM_KhoaHocID"].ToString());
        //            oDM_KhoaHocInfo.TenKhoaHoc = dtb.Rows[i]["TenKhoaHoc"].ToString();
        //            oDM_KhoaHocInfo.IDDM_TrinhDo = int.Parse(dtb.Rows[i]["IDDM_TrinhDo"].ToString());
        //            oDM_KhoaHocInfo.IDDM_Nganh = int.Parse(dtb.Rows[i]["IDDM_Nganh"].ToString());
        //            oDM_KhoaHocInfo.IDDM_ChuyenNganh = int.Parse(dtb.Rows[i]["IDDM_ChuyenNganh"].ToString());
        //            oDM_KhoaHocInfo.NamVaoTruong = int.Parse(dtb.Rows[i]["NamVaoTruong"].ToString());
        //            oDM_KhoaHocInfo.NamRaTruong = int.Parse(dtb.Rows[i]["NamRaTruong"].ToString());

        //            oDM_KhoaHocInfoList.Add(oDM_KhoaHocInfo);
        //        }
        //    }
        //    return oDM_KhoaHocInfoList;
        //}

        public void ToDataRow(DM_KhoaHocInfo pDM_KhoaHocInfo, ref DataRow dr)
        {

            dr[pDM_KhoaHocInfo.strDM_KhoaHocID] = pDM_KhoaHocInfo.DM_KhoaHocID;
            dr[pDM_KhoaHocInfo.strTenKhoaHoc] = pDM_KhoaHocInfo.TenKhoaHoc;
            dr[pDM_KhoaHocInfo.strIDDM_TrinhDo] = pDM_KhoaHocInfo.IDDM_TrinhDo;
            dr[pDM_KhoaHocInfo.strIDDM_Nganh] = pDM_KhoaHocInfo.IDDM_Nganh;
            dr[pDM_KhoaHocInfo.strIDDM_ChuyenNganh] = pDM_KhoaHocInfo.IDDM_ChuyenNganh;
            dr[pDM_KhoaHocInfo.strNamVaoTruong] = pDM_KhoaHocInfo.NamVaoTruong;
            dr[pDM_KhoaHocInfo.strNamRaTruong] = pDM_KhoaHocInfo.NamRaTruong;
        }
    }
}
