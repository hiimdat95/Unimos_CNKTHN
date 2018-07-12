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
    public class cBwsDM_TinhHuyenXa : cBwsBase
    {
        private cDDM_TinhHuyenXa oDDM_TinhHuyenXa;
        private DM_TinhHuyenXaInfo oDM_TinhHuyenXaInfo;

        public cBwsDM_TinhHuyenXa()
        {
            oDDM_TinhHuyenXa = new cDDM_TinhHuyenXa();
        }

        //public DataTable Get(DM_TinhHuyenXaInfo pDM_TinhHuyenXaInfo)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<DM_TinhHuyenXaInfo>(client.cDDM_TinhHuyenXa_Get(GlobalVar.MaXacThuc, pDM_TinhHuyenXaInfo));
        //    }
        //}

        public DataTable GetByCap(int Level, int ParentID)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_DM_TinhHuyenXa_GetByCapResult>(client.cDDM_TinhHuyenXa_GetByCap(GlobalVar.MaXacThuc, Level, ParentID));
            }
        }

        public DataTable GetTinh(int DM_TinhHuyenXaID)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_DM_TinhHuyenXa_GetTinhResult>(client.cDDM_TinhHuyenXa_GetTinh(GlobalVar.MaXacThuc, DM_TinhHuyenXaID));
            }
        }

        /// <summary>
        /// Hàm trả về tree
        /// </summary>
        /// <returns></returns>
        public DataTable GetTree()
        {
            return oDDM_TinhHuyenXa.GetTree();
        }

        public string CheckExistByMa(string Mas)
        {
            using (var client = new UnimOsServiceClient())
            {
                return client.cDDM_TinhHuyenXa_CheckExistByMa(GlobalVar.MaXacThuc, Mas);
            }
        }

        //public int Add(DM_TinhHuyenXaInfo pDM_TinhHuyenXaInfo)
        //{
        //    int ID = 0;
        //    var client = new UnimOsServiceClient();
        //    ID = client.cDDM_TinhHuyenXa_Add(GlobalVar.MaXacThuc, pDM_TinhHuyenXaInfo);
        //    client.Close();
        //    mErrorMessage = oDDM_TinhHuyenXa.ErrorMessages;
        //    mErrorNumber = oDDM_TinhHuyenXa.ErrorNumber;
        //    return ID;
        //}

        public int AddByImport(DM_TinhHuyenXaInfo pDM_TinhHuyenXaInfo, string MaCha)
        {
            int ID = 0;
            var client = new UnimOsServiceClient();
            ID = client.cDDM_TinhHuyenXa_AddByImport(GlobalVar.MaXacThuc, pDM_TinhHuyenXaInfo, MaCha);
            client.Close();
            mErrorMessage = oDDM_TinhHuyenXa.ErrorMessages;
            mErrorNumber = oDDM_TinhHuyenXa.ErrorNumber;
            return ID;
        }

        //public void Update(DM_TinhHuyenXaInfo pDM_TinhHuyenXaInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDDM_TinhHuyenXa_Update(GlobalVar.MaXacThuc, pDM_TinhHuyenXaInfo);
        //    client.Close();
        //    mErrorMessage = oDDM_TinhHuyenXa.ErrorMessages;
        //    mErrorNumber = oDDM_TinhHuyenXa.ErrorNumber;
        //}

        //public void Delete(DM_TinhHuyenXaInfo pDM_TinhHuyenXaInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDDM_TinhHuyenXa_Delete(GlobalVar.MaXacThuc, pDM_TinhHuyenXaInfo);
        //    client.Close();
        //    mErrorMessage = oDDM_TinhHuyenXa.ErrorMessages;
        //    mErrorNumber = oDDM_TinhHuyenXa.ErrorNumber;
        //}

        //public List<DM_TinhHuyenXaInfo> GetList(DM_TinhHuyenXaInfo pDM_TinhHuyenXaInfo)
        //{
        //    List<DM_TinhHuyenXaInfo> oDM_TinhHuyenXaInfoList = new List<DM_TinhHuyenXaInfo>();
        //    DataTable dtb = Get(pDM_TinhHuyenXaInfo);
        //    if (dtb != null)
        //    {
        //        for (int i = 0; i < dtb.Rows.Count; i++)
        //        {
        //            oDM_TinhHuyenXaInfo = new DM_TinhHuyenXaInfo();


        //            oDM_TinhHuyenXaInfo.DM_TinhHuyenXaID = int.Parse(dtb.Rows[i]["DM_TinhHuyenXaID"].ToString());
        //            oDM_TinhHuyenXaInfo.Ma = dtb.Rows[i]["Ma"].ToString();
        //            oDM_TinhHuyenXaInfo.Ten = dtb.Rows[i]["Ten"].ToString();
        //            oDM_TinhHuyenXaInfo.ParentID = int.Parse(dtb.Rows[i]["ParentID"].ToString());
        //            oDM_TinhHuyenXaInfo.Level = int.Parse(dtb.Rows[i]["Level"].ToString());

        //            oDM_TinhHuyenXaInfoList.Add(oDM_TinhHuyenXaInfo);
        //        }
        //    }
        //    return oDM_TinhHuyenXaInfoList;
        //}
    }
}
