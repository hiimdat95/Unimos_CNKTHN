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
    public class cBwsDM_BoMon : cBwsBase
    {
        private cDDM_BoMon oDDM_BoMon;
        private DM_BoMonInfo oDM_BoMonInfo;

        public cBwsDM_BoMon()
        {
            oDDM_BoMon = new cDDM_BoMon();
        }

        public DataTable Get(DM_BoMonInfo pDM_BoMonInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_DM_BoMon_GetResult>(client.cDDM_BoMon_Get(GlobalVar.MaXacThuc, pDM_BoMonInfo));
            }
        }

        //public int Add(DM_BoMonInfo pDM_BoMonInfo)
        //{
        //    int ID = 0;
        //    var client = new UnimOsServiceClient();
        //    ID = client.cDDM_BoMon_Add(GlobalVar.MaXacThuc, pDM_BoMonInfo);
        //    client.Close();
        //    mErrorMessage = oDDM_BoMon.ErrorMessages;
        //    mErrorNumber = oDDM_BoMon.ErrorNumber;
        //    return ID;
        //}

        //public void Update(DM_BoMonInfo pDM_BoMonInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDDM_BoMon_Update(GlobalVar.MaXacThuc, pDM_BoMonInfo);
        //    client.Close();
        //    mErrorMessage = oDDM_BoMon.ErrorMessages;
        //    mErrorNumber = oDDM_BoMon.ErrorNumber;
        //}

        //public void Delete(DM_BoMonInfo pDM_BoMonInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDDM_BoMon_Delete(GlobalVar.MaXacThuc, pDM_BoMonInfo);
        //    client.Close();
        //    mErrorMessage = oDDM_BoMon.ErrorMessages;
        //    mErrorNumber = oDDM_BoMon.ErrorNumber;
        //}

        public List<DM_BoMonInfo> GetList(DM_BoMonInfo pDM_BoMonInfo)
        {
            List<DM_BoMonInfo> oDM_BoMonInfoList = new List<DM_BoMonInfo>();
            DataTable dtb = Get(pDM_BoMonInfo);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    oDM_BoMonInfo = new DM_BoMonInfo();


                    oDM_BoMonInfo.DM_BoMonID = int.Parse(dtb.Rows[i]["DM_BoMonID"].ToString());
                    oDM_BoMonInfo.IDDM_Khoa = int.Parse(dtb.Rows[i]["IDDM_Khoa"].ToString());
                    oDM_BoMonInfo.MaBoMon = dtb.Rows[i]["MaBoMon"].ToString();
                    oDM_BoMonInfo.TenBoMon = dtb.Rows[i]["TenBoMon"].ToString();

                    oDM_BoMonInfoList.Add(oDM_BoMonInfo);
                }
            }
            return oDM_BoMonInfoList;
        }

        public void ToDataRow(DM_BoMonInfo pDM_BoMonInfo, ref DataRow dr)
        {
            dr[pDM_BoMonInfo.strDM_BoMonID] = pDM_BoMonInfo.DM_BoMonID;
            dr[pDM_BoMonInfo.strIDDM_Khoa] = pDM_BoMonInfo.IDDM_Khoa;
            dr[pDM_BoMonInfo.strMaBoMon] = pDM_BoMonInfo.MaBoMon;
            dr[pDM_BoMonInfo.strTenBoMon] = pDM_BoMonInfo.TenBoMon;
        }

        public void ToInfo(ref DM_BoMonInfo pDM_BoMonInfo, DataRow dr)
        {
            pDM_BoMonInfo.DM_BoMonID = int.Parse(dr[pDM_BoMonInfo.strDM_BoMonID].ToString());
            pDM_BoMonInfo.IDDM_Khoa = int.Parse(dr[pDM_BoMonInfo.strIDDM_Khoa].ToString());
            pDM_BoMonInfo.MaBoMon = dr[pDM_BoMonInfo.strMaBoMon].ToString();
            pDM_BoMonInfo.TenBoMon = dr[pDM_BoMonInfo.strTenBoMon].ToString();
        }

        public DataTable GetByIDKhoa(int IDDM_Khoa)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_DM_BoMon_GetByIDKhoaResult>(client.cDDM_BoMon_GetByIDKhoa(GlobalVar.MaXacThuc, IDDM_Khoa));
            }
        }
    }
}
