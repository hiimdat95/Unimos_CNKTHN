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
    public class cBwsNS_DonVi : cBwsBase
    {
        private cDNS_DonVi oDNS_DonVi;
        private NS_DonViInfo oNS_DonViInfo;
        private int currID;

        public cBwsNS_DonVi()
        {
            oDNS_DonVi = new cDNS_DonVi();
            oNS_DonViInfo = new NS_DonViInfo();
        }

        public DataTable Get(NS_DonViInfo pNS_DonViInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_NS_DonVi_GetResult>(client.cDNS_DonVi_Get(GlobalVar.MaXacThuc, pNS_DonViInfo));
            }
        }

        public DataTable GetByID(int IDNS_DonVi)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_NS_DonVi_GetByIDResult>(client.cDNS_DonVi_GetByID(GlobalVar.MaXacThuc, IDNS_DonVi));
            }
        }

        public int GetByIDDM_Khoa(int IDDM_Khoa)
        {
            var client = new UnimOsServiceClient();
            DataTable dt = ConvertList.ToDataTable<sp_NS_DonVi_GetByIDDM_KhoaResult>(client.cDNS_DonVi_GetByIDDM_Khoa(GlobalVar.MaXacThuc, IDDM_Khoa));
            client.Close();
            if (dt.Rows.Count > 0)
                return int.Parse(dt.Rows[0]["NS_DonViID"].ToString());
            return 0;
        }

        private DataTable CreateTableTree()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("ParentIDs", typeof(int));
            dt.Columns.Add("TenDonVi", typeof(string));
            dt.Columns.Add("MaDonVi", typeof(string));
            dt.Columns.Add("IDDM_Khoa", typeof(int));
            dt.Columns.Add("IDDM_BoMon", typeof(int));
            dt.Columns.Add("ParentID", typeof(int));
            dt.Columns.Add("Level", typeof(int));
            dt.Columns.Add("NS_DonViID", typeof(int));
            return dt;
        }

        public DataTable Get_Tree()
        {
            oNS_DonViInfo.NS_DonViID = 0;
            DataTable dt = Get(oNS_DonViInfo);
            DataTable dtTree = CreateTableTree();
            currID = 0;
            AddTree(dt, dtTree, "ParentID", 0, 0);
            return dtTree;
        }

        private void AddTree(DataTable dtSource, DataTable dtTree, string ParentField, int ParentValue, int ValueField)
        {
            string strFilter = "";
            if (dtSource.Rows.Count > 0)
            {
                if (ParentValue > 0)
                {
                    strFilter = ParentField + " = " + ValueField;
                }
                else
                {
                    strFilter = ParentField + " <= 0";
                }
                DataRow[] arrDr = dtSource.Select(strFilter);
                if (arrDr.Length > 0)
                {
                    foreach (DataRow dr in arrDr)
                    {
                        DataRow drNew = dtTree.NewRow();
                        currID++;
                        drNew["ID"] = currID;
                        drNew["ParentIDs"] = ParentValue;
                        drNew["TenDonVi"] = dr["TenDonVi"];
                        drNew["MaDonVi"] = dr["MaDonVi"];
                        drNew["IDDM_Khoa"] = dr["IDDM_Khoa"];
                        drNew["IDDM_BoMon"] = dr["IDDM_BoMon"];
                        drNew["ParentID"] = dr["ParentID"];
                        drNew["Level"] = dr["Level"];
                        drNew["NS_DonViID"] = dr["NS_DonViID"];
                        dtTree.Rows.Add(drNew);
                        AddTree(dtSource, dtTree, ParentField, currID, int.Parse(dr["NS_DonViID"].ToString()));
                    }
                }
            }
        }

        //public int Add(NS_DonViInfo pNS_DonViInfo)
        //{
        //    int ID = 0;
        //    var client = new UnimOsServiceClient();
        //    ID = client.cDNS_DonVi_Add(GlobalVar.MaXacThuc, pNS_DonViInfo);
        //    client.Close();
        //    mErrorMessage = oDNS_DonVi.ErrorMessages;
        //    mErrorNumber = oDNS_DonVi.ErrorNumber;
        //    return ID;
        //}

        //public void Update(NS_DonViInfo pNS_DonViInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDNS_DonVi_Update(GlobalVar.MaXacThuc, pNS_DonViInfo);
        //    client.Close();
        //    mErrorMessage = oDNS_DonVi.ErrorMessages;
        //    mErrorNumber = oDNS_DonVi.ErrorNumber;
        //}

        //public void Delete(NS_DonViInfo pNS_DonViInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDNS_DonVi_Delete(GlobalVar.MaXacThuc, pNS_DonViInfo);
        //    client.Close();
        //    mErrorMessage = oDNS_DonVi.ErrorMessages;
        //    mErrorNumber = oDNS_DonVi.ErrorNumber;
        //}

        //public List<NS_DonViInfoResult> GetList(NS_DonViInfo pNS_DonViInfo)
        //{
        //    List<NS_DonViInfoResult> oNS_DonViInfoList = new List<NS_DonViInfoResult>();
        //    DataTable dtb = Get(pNS_DonViInfo);
        //    if (dtb != null)
        //    {
        //        for (int i = 0; i < dtb.Rows.Count; i++)
        //        {
        //            oNS_DonViInfo = new NS_DonViInfo();

        //            oNS_DonViInfo.NS_DonViID = int.Parse(dtb.Rows[i]["NS_DonViID"].ToString());
        //            oNS_DonViInfo.MaDonVi = dtb.Rows[i]["MaDonVi"].ToString();
        //            oNS_DonViInfo.TenDonVi = dtb.Rows[i]["TenDonVi"].ToString();
        //            oNS_DonViInfo.IDDM_Khoa = int.Parse(dtb.Rows[i]["IDDM_Khoa"].ToString());
        //            oNS_DonViInfo.IDDM_BoMon = int.Parse(dtb.Rows[i]["IDDM_BoMon"].ToString());
        //            oNS_DonViInfo.ParentID = int.Parse(dtb.Rows[i]["ParentID"].ToString());
        //            oNS_DonViInfo.Level = int.Parse(dtb.Rows[i]["Level"].ToString());

        //            oNS_DonViInfoList.Add(oNS_DonViInfo);
        //        }
        //    }
        //    return oNS_DonViInfoList;
        //}

        public void ToDataRow(NS_DonViInfo pNS_DonViInfo, ref DataRow dr)
        {

            dr[pNS_DonViInfo.strNS_DonViID] = pNS_DonViInfo.NS_DonViID;
            dr[pNS_DonViInfo.strMaDonVi] = pNS_DonViInfo.MaDonVi;
            dr[pNS_DonViInfo.strTenDonVi] = pNS_DonViInfo.TenDonVi;
            dr[pNS_DonViInfo.strIDDM_Khoa] = pNS_DonViInfo.IDDM_Khoa;
            dr[pNS_DonViInfo.strIDDM_BoMon] = pNS_DonViInfo.IDDM_BoMon;
            dr[pNS_DonViInfo.strParentID] = pNS_DonViInfo.ParentID;
            dr[pNS_DonViInfo.strLevel] = pNS_DonViInfo.Level;
        }

        public void ToInfo(ref NS_DonViInfo pNS_DonViInfo, DataRow dr)
        {

            pNS_DonViInfo.NS_DonViID = int.Parse(dr[pNS_DonViInfo.strNS_DonViID].ToString());
            pNS_DonViInfo.MaDonVi = dr[pNS_DonViInfo.strMaDonVi].ToString();
            pNS_DonViInfo.TenDonVi = dr[pNS_DonViInfo.strTenDonVi].ToString();
            pNS_DonViInfo.IDDM_Khoa = int.Parse(dr[pNS_DonViInfo.strIDDM_Khoa].ToString());
            pNS_DonViInfo.IDDM_BoMon = int.Parse(dr[pNS_DonViInfo.strIDDM_BoMon].ToString());
            pNS_DonViInfo.ParentID = int.Parse(dr[pNS_DonViInfo.strParentID].ToString());
            pNS_DonViInfo.Level = int.Parse(dr[pNS_DonViInfo.strLevel].ToString());
        }
    }
}
