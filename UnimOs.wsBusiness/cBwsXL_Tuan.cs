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
    public class cBwsXL_Tuan : cBwsBase
    {
        private cDXL_Tuan oDXL_Tuan;
        private XL_TuanInfo oXL_TuanInfo;

        public cBwsXL_Tuan()
        {
            oDXL_Tuan = new cDXL_Tuan();
        }

        //public DataTable Get(XL_TuanInfo pXL_TuanInfo)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<XL_TuanInfo>(client.cDXL_Tuan_Get(GlobalVar.MaXacThuc, pXL_TuanInfo));
        //    }
        //}

        public DataTable GetByIDNamHoc(XL_TuanInfo pTuanInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_XL_Tuan_GetByIDNamHocResult>(client.cDXL_Tuan_GetByIDNamHoc(GlobalVar.MaXacThuc, pTuanInfo));
            }
        }

        public DataTable GetByTuanThu(XL_TuanInfo pTuanInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_XL_Tuan_GetByTuanThuResult>(client.cDXL_Tuan_GetByTuanThu(GlobalVar.MaXacThuc, pTuanInfo));
            }
        }

        public DataTable GetByHocKy_NamHoc(int IDNamHoc, int HocKy)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_XL_Tuan_GetByNamHoc_HocKyResult>(client.cDXL_Tuan_GetBy_NamHoc_HocKy(GlobalVar.MaXacThuc, IDNamHoc, HocKy));
            }
        }

        public DataTable GetByTuTuan(int IDNamHoc, int HocKy, int TuTuan)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_XL_Tuan_GetByTuanThuResult>(client.cDXL_Tuan_GetByTuanThu_2(GlobalVar.MaXacThuc, IDNamHoc, HocKy, TuTuan));
            }
        }

        //public int Add(XL_TuanInfo pXL_TuanInfo)
        //{
        //    int ID = 0;
        //    var client = new UnimOsServiceClient();
        //    ID = client.cDXL_Tuan_Add(GlobalVar.MaXacThuc, pXL_TuanInfo);
        //    client.Close();
        //    mErrorMessage = oDXL_Tuan.ErrorMessages;
        //    mErrorNumber = oDXL_Tuan.ErrorNumber;
        //    return ID;
        //}

        //public void Update(XL_TuanInfo pXL_TuanInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDXL_Tuan_Update(GlobalVar.MaXacThuc, pXL_TuanInfo);
        //    client.Close();
        //    mErrorMessage = oDXL_Tuan.ErrorMessages;
        //    mErrorNumber = oDXL_Tuan.ErrorNumber;
        //}

        //public void Delete(XL_TuanInfo pXL_TuanInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDXL_Tuan_Delete(GlobalVar.MaXacThuc, pXL_TuanInfo);
        //    client.Close();
        //    mErrorMessage = oDXL_Tuan.ErrorMessages;
        //    mErrorNumber = oDXL_Tuan.ErrorNumber;
        //}

        //public void DeleteTuanThua(XL_TuanInfo pTuanInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDXL_Tuan_DeleteTuanThua(GlobalVar.MaXacThuc, pTuanInfo);
        //    client.Close();
        //    mErrorMessage = oDXL_Tuan.ErrorMessages;
        //    mErrorNumber = oDXL_Tuan.ErrorNumber;
        //}

        //public List<XL_TuanInfo> GetList(XL_TuanInfo pXL_TuanInfo)
        //{
        //    List<XL_TuanInfo> oXL_TuanInfoList = new List<XL_TuanInfo>();
        //    DataTable dtb = Get(pXL_TuanInfo);
        //    if (dtb != null)
        //    {
        //        for (int i = 0; i < dtb.Rows.Count; i++)
        //        {
        //            oXL_TuanInfo = new XL_TuanInfo();


        //            oXL_TuanInfo.XL_TuanID = long.Parse(dtb.Rows[i]["XL_TuanID"].ToString());
        //            oXL_TuanInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
        //            oXL_TuanInfo.TuanThu = int.Parse(dtb.Rows[i]["TuanThu"].ToString());
        //            oXL_TuanInfo.TuNgay = DateTime.Parse(dtb.Rows[i]["TuNgay"].ToString());
        //            oXL_TuanInfo.DenNgay = DateTime.Parse(dtb.Rows[i]["DenNgay"].ToString());
        //            oXL_TuanInfo.ChoPhepXemLich = bool.Parse(dtb.Rows[i]["ChoPhepXemLich"].ToString());

        //            oXL_TuanInfoList.Add(oXL_TuanInfo);
        //        }
        //    }
        //    return oXL_TuanInfoList;
        //}
    }
}
