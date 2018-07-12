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
    public class cBwsGG_DinhMucGioDay : cBwsBase
    {
        private cDGG_DinhMucGioDay oDGG_DinhMucGioDay;

        public cBwsGG_DinhMucGioDay()
        {
            oDGG_DinhMucGioDay = new cDGG_DinhMucGioDay();
        }

        public DataTable Get(GG_DinhMucGioDayInfo pGG_DinhMucGioDayInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_GG_DinhMucGioDay_GetResult>(client.cDGG_DinhMucGioDay_Get(GlobalVar.MaXacThuc, pGG_DinhMucGioDayInfo));
            }
        }

        public DataTable GetByIDNS_DonVi(int IDNS_DonVi, int IDDM_NamHoc, int HocKy)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_GG_DinhMucGioDay_GetByIDNS_DonViResult>(client.cDGG_DinhMucGioDay_GetByIDNS_DonVi(GlobalVar.MaXacThuc, IDNS_DonVi, IDDM_NamHoc, HocKy));
            }
        }

        public int Add(GG_DinhMucGioDayInfo pGG_DinhMucGioDayInfo)
        {
            int ID = 0;
            var client = new UnimOsServiceClient();
            ID = client.cDGG_DinhMucGioDay_Add(GlobalVar.MaXacThuc, pGG_DinhMucGioDayInfo);
            client.Close();
            mErrorMessage = oDGG_DinhMucGioDay.ErrorMessages;
            mErrorNumber = oDGG_DinhMucGioDay.ErrorNumber;
            return ID;
        }

        public void Update(GG_DinhMucGioDayInfo pGG_DinhMucGioDayInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDGG_DinhMucGioDay_Update(GlobalVar.MaXacThuc, pGG_DinhMucGioDayInfo);
            client.Close();
            mErrorMessage = oDGG_DinhMucGioDay.ErrorMessages;
            mErrorNumber = oDGG_DinhMucGioDay.ErrorNumber;
        }

        public void Delete(GG_DinhMucGioDayInfo pGG_DinhMucGioDayInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDGG_DinhMucGioDay_Delete(GlobalVar.MaXacThuc, pGG_DinhMucGioDayInfo);
            client.Close();
            mErrorMessage = oDGG_DinhMucGioDay.ErrorMessages;
            mErrorNumber = oDGG_DinhMucGioDay.ErrorNumber;
        }

        public List<GG_DinhMucGioDayInfo> GetList(GG_DinhMucGioDayInfo pGG_DinhMucGioDayInfo)
        {
            List<GG_DinhMucGioDayInfo> oGG_DinhMucGioDayInfoList = new List<GG_DinhMucGioDayInfo>();
            DataTable dtb = Get(pGG_DinhMucGioDayInfo);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    pGG_DinhMucGioDayInfo = new GG_DinhMucGioDayInfo();

                    pGG_DinhMucGioDayInfo.GG_DinhMucGioDayID = int.Parse(dtb.Rows[i][pGG_DinhMucGioDayInfo.strGG_DinhMucGioDayID].ToString());
                    pGG_DinhMucGioDayInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i][pGG_DinhMucGioDayInfo.strIDNS_GiaoVien].ToString());
                    if ("" + dtb.Rows[i][pGG_DinhMucGioDayInfo.strSoGioGiam] != "")
                        pGG_DinhMucGioDayInfo.SoGioGiam = double.Parse(dtb.Rows[i][pGG_DinhMucGioDayInfo.strSoGioGiam].ToString());
                    if ("" + dtb.Rows[i][pGG_DinhMucGioDayInfo.strSoGioDinhMuc] != "")
                        pGG_DinhMucGioDayInfo.SoGioDinhMuc = double.Parse(dtb.Rows[i][pGG_DinhMucGioDayInfo.strSoGioDinhMuc].ToString());
                    pGG_DinhMucGioDayInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i][pGG_DinhMucGioDayInfo.strIDDM_NamHoc].ToString());
                    if ("" + dtb.Rows[i][pGG_DinhMucGioDayInfo.strHocKy] != "")
                        pGG_DinhMucGioDayInfo.HocKy = int.Parse(dtb.Rows[i][pGG_DinhMucGioDayInfo.strHocKy].ToString());

                    oGG_DinhMucGioDayInfoList.Add(pGG_DinhMucGioDayInfo);
                }
            }
            return oGG_DinhMucGioDayInfoList;
        }

        public void ToDataRow(GG_DinhMucGioDayInfo pGG_DinhMucGioDayInfo, ref DataRow dr)
        {

            dr[pGG_DinhMucGioDayInfo.strGG_DinhMucGioDayID] = pGG_DinhMucGioDayInfo.GG_DinhMucGioDayID;
            dr[pGG_DinhMucGioDayInfo.strIDNS_GiaoVien] = pGG_DinhMucGioDayInfo.IDNS_GiaoVien;
            dr[pGG_DinhMucGioDayInfo.strSoGioGiam] = pGG_DinhMucGioDayInfo.SoGioGiam;
            dr[pGG_DinhMucGioDayInfo.strSoGioDinhMuc] = pGG_DinhMucGioDayInfo.SoGioDinhMuc;
            dr[pGG_DinhMucGioDayInfo.strIDDM_NamHoc] = pGG_DinhMucGioDayInfo.IDDM_NamHoc;
            dr[pGG_DinhMucGioDayInfo.strHocKy] = pGG_DinhMucGioDayInfo.HocKy;
        }

        public void ToInfo(ref GG_DinhMucGioDayInfo pGG_DinhMucGioDayInfo, DataRow dr)
        {

            pGG_DinhMucGioDayInfo.GG_DinhMucGioDayID = int.Parse(dr[pGG_DinhMucGioDayInfo.strGG_DinhMucGioDayID].ToString());
            pGG_DinhMucGioDayInfo.IDNS_GiaoVien = int.Parse(dr[pGG_DinhMucGioDayInfo.strIDNS_GiaoVien].ToString());
            if ("" + dr[pGG_DinhMucGioDayInfo.strSoGioGiam] != "")
                pGG_DinhMucGioDayInfo.SoGioGiam = double.Parse(dr[pGG_DinhMucGioDayInfo.strSoGioGiam].ToString());
            if ("" + dr[pGG_DinhMucGioDayInfo.strSoGioDinhMuc] != "")
                pGG_DinhMucGioDayInfo.SoGioDinhMuc = double.Parse(dr[pGG_DinhMucGioDayInfo.strSoGioDinhMuc].ToString());
            pGG_DinhMucGioDayInfo.IDDM_NamHoc = int.Parse(dr[pGG_DinhMucGioDayInfo.strIDDM_NamHoc].ToString());
            if ("" + dr[pGG_DinhMucGioDayInfo.strHocKy] != "")
                pGG_DinhMucGioDayInfo.HocKy = int.Parse(dr[pGG_DinhMucGioDayInfo.strHocKy].ToString());
        }
    }
}
