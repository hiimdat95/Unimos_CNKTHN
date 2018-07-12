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
    public class cBwsXL_KeHoachKhac : cBwsBase
    {
        private cDXL_KeHoachKhac oDXL_KeHoachKhac;
        private XL_KeHoachKhacInfo oXL_KeHoachKhacInfo;

        public cBwsXL_KeHoachKhac()
        {
            oDXL_KeHoachKhac = new cDXL_KeHoachKhac();
        }

        //public DataTable Get(XL_KeHoachKhacInfo pXL_KeHoachKhacInfo)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<XL_KeHoachKhacInfo>(client.cDXL_KeHoachKhac_Get(GlobalVar.MaXacThuc, pXL_KeHoachKhacInfo));
        //    }
        //}

        //public int Add(XL_KeHoachKhacInfo pXL_KeHoachKhacInfo)
        //{
        //    int ID = 0;
        //    var client = new UnimOsServiceClient();
        //    ID = client.cDXL_KeHoachKhac_Add(GlobalVar.MaXacThuc, pXL_KeHoachKhacInfo);
        //    client.Close();
        //    mErrorMessage = oDXL_KeHoachKhac.ErrorMessages;
        //    mErrorNumber = oDXL_KeHoachKhac.ErrorNumber;
        //    return ID;
        //}

        //public void Update(XL_KeHoachKhacInfo pXL_KeHoachKhacInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDXL_KeHoachKhac_Update(GlobalVar.MaXacThuc, pXL_KeHoachKhacInfo);
        //    client.Close();
        //    mErrorMessage = oDXL_KeHoachKhac.ErrorMessages;
        //    mErrorNumber = oDXL_KeHoachKhac.ErrorNumber;
        //}

        //public void Delete(XL_KeHoachKhacInfo pXL_KeHoachKhacInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDXL_KeHoachKhac_Delete(GlobalVar.MaXacThuc, pXL_KeHoachKhacInfo);
        //    client.Close();
        //    mErrorMessage = oDXL_KeHoachKhac.ErrorMessages;
        //    mErrorNumber = oDXL_KeHoachKhac.ErrorNumber;
        //}

        //public List<XL_KeHoachKhacInfo> GetList(XL_KeHoachKhacInfo pXL_KeHoachKhacInfo)
        //{
        //    List<XL_KeHoachKhacInfo> oXL_KeHoachKhacInfoList = new List<XL_KeHoachKhacInfo>();
        //    DataTable dtb = Get(pXL_KeHoachKhacInfo);
        //    if (dtb != null)
        //    {
        //        for (int i = 0; i < dtb.Rows.Count; i++)
        //        {
        //            oXL_KeHoachKhacInfo = new XL_KeHoachKhacInfo();

        //            oXL_KeHoachKhacInfo.XL_KeHoachKhacID = int.Parse(dtb.Rows[i]["XL_KeHoachKhacID"].ToString());
        //            oXL_KeHoachKhacInfo.TenKeHoachKhac = dtb.Rows[i]["TenKeHoachKhac"].ToString();
        //            oXL_KeHoachKhacInfo.TenVietTat = dtb.Rows[i]["TenVietTat"].ToString();
        //            oXL_KeHoachKhacInfo.MauNen = int.Parse(dtb.Rows[i]["MauNen"].ToString());
        //            oXL_KeHoachKhacInfo.MauChu = int.Parse(dtb.Rows[i]["MauChu"].ToString());
        //            oXL_KeHoachKhacInfo.DuLieuChuan = bool.Parse(dtb.Rows[i]["DuLieuChuan"].ToString());

        //            oXL_KeHoachKhacInfoList.Add(oXL_KeHoachKhacInfo);
        //        }
        //    }
        //    return oXL_KeHoachKhacInfoList;
        //}

        public void ToDataRow(XL_KeHoachKhacInfo pXL_KeHoachKhacInfo, ref DataRow dr)
        {

            dr[pXL_KeHoachKhacInfo.strXL_KeHoachKhacID] = pXL_KeHoachKhacInfo.XL_KeHoachKhacID;
            dr[pXL_KeHoachKhacInfo.strTenKeHoachKhac] = pXL_KeHoachKhacInfo.TenKeHoachKhac;
            dr[pXL_KeHoachKhacInfo.strTenVietTat] = pXL_KeHoachKhacInfo.TenVietTat;
            dr[pXL_KeHoachKhacInfo.strMauNen] = pXL_KeHoachKhacInfo.MauNen;
            dr[pXL_KeHoachKhacInfo.strMauChu] = pXL_KeHoachKhacInfo.MauChu;
            dr[pXL_KeHoachKhacInfo.strDuLieuChuan] = pXL_KeHoachKhacInfo.DuLieuChuan;
        }

        public void ToInfo(ref XL_KeHoachKhacInfo pXL_KeHoachKhacInfo, DataRow dr)
        {

            pXL_KeHoachKhacInfo.XL_KeHoachKhacID = int.Parse(dr[pXL_KeHoachKhacInfo.strXL_KeHoachKhacID].ToString());
            pXL_KeHoachKhacInfo.TenKeHoachKhac = dr[pXL_KeHoachKhacInfo.strTenKeHoachKhac].ToString();
            pXL_KeHoachKhacInfo.TenVietTat = dr[pXL_KeHoachKhacInfo.strTenVietTat].ToString();
            pXL_KeHoachKhacInfo.MauNen = int.Parse(dr[pXL_KeHoachKhacInfo.strMauNen].ToString());
            pXL_KeHoachKhacInfo.MauChu = int.Parse(dr[pXL_KeHoachKhacInfo.strMauChu].ToString());
            pXL_KeHoachKhacInfo.DuLieuChuan = bool.Parse(dr[pXL_KeHoachKhacInfo.strDuLieuChuan].ToString());
        }

        public DataTable GetCombo(XL_KeHoachKhacInfo pXL_KeHoachKhacInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_XL_KeHoachKhac_GetComboResult>(client.cDXL_KeHoachKhac_GetCombo(GlobalVar.MaXacThuc, pXL_KeHoachKhacInfo));
            }
        }
    }
}
