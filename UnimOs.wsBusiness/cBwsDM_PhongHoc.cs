using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.wsBusiness;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Entity.Model;
using TruongViet.UnimOs.Data;
using UnimOs.wsBusiness.wsUnimOs;
using System.Collections;

namespace TruongViet.UnimOs.wsBusiness
{
    public class cBwsDM_PhongHoc : cBwsBase
    {
        private cDDM_PhongHoc oDDM_PhongHoc;
        private DM_PhongHocInfo oDM_PhongHocInfo;
        private ArrayList arrPhongHoc;

        public cBwsDM_PhongHoc()
        {
            oDDM_PhongHoc = new cDDM_PhongHoc();
        }

        //public DataTable Get(DM_PhongHocInfo pDM_PhongHocInfo)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<DM_PhongHocInfo>(client.cDDM_PhongHoc_Get(GlobalVar.MaXacThuc, pDM_PhongHocInfo));
        //    }
        //}

        public DataTable GetAll()
        {
            return oDDM_PhongHoc.GetAll();
        }

        public DataTable GetByIDToaNha(int IDDM_ToaNha)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_DM_PhongHoc_GetByIDToaNhaResult>(client.cDDM_PhongHoc_GetByIDToaNha(GlobalVar.MaXacThuc, IDDM_ToaNha));
            }
        }

        public DataTable GetChon(int IDToaNha, string mPhongHoc)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_DM_PhongHoc_GetChonResult>(client.cDDM_PhongHoc_GetChon(GlobalVar.MaXacThuc, IDToaNha, mPhongHoc));
            }
        }

        public DataTable Get_TKB()
        {
            return oDDM_PhongHoc.Get_TKB();
        }

        public DataTable GetKeHoachThucHanh(int IDDM_NamHoc, string NamHoc)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_DM_PhongHoc_GetKeHoachThucHanhResult>(client.cDDM_PhongHoc_GetKeHoachThucHanh(GlobalVar.MaXacThuc, IDDM_NamHoc, NamHoc));
            }
        }

        //public int Add(DM_PhongHocInfo pDM_PhongHocInfo)
        //{
        //    int ID = 0;
        //    var client = new UnimOsServiceClient();
        //    ID = client.cDDM_PhongHoc_Add(GlobalVar.MaXacThuc, pDM_PhongHocInfo);
        //    client.Close();
        //    mErrorMessage = oDDM_PhongHoc.ErrorMessages;
        //    mErrorNumber = oDDM_PhongHoc.ErrorNumber;
        //    return ID;
        //}

        //public void Update(DM_PhongHocInfo pDM_PhongHocInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDDM_PhongHoc_Update(GlobalVar.MaXacThuc, pDM_PhongHocInfo);
        //    client.Close();
        //    mErrorMessage = oDDM_PhongHoc.ErrorMessages;
        //    mErrorNumber = oDDM_PhongHoc.ErrorNumber;
        //}

        //public void Delete(DM_PhongHocInfo pDM_PhongHocInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDDM_PhongHoc_Delete(GlobalVar.MaXacThuc, pDM_PhongHocInfo);
        //    client.Close();
        //    mErrorMessage = oDDM_PhongHoc.ErrorMessages;
        //    mErrorNumber = oDDM_PhongHoc.ErrorNumber;
        //}

        //#region Hiển thị tree giáo viên đơn vị
        //private DataTable CreateTableTree()
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("ID", typeof(int));
        //    dt.Columns.Add("ParentID", typeof(int));
        //    dt.Columns.Add("TenToaNha", typeof(string));
        //    dt.Columns.Add("MaToaNha", typeof(string));
        //    dt.Columns.Add("TenPhongHoc", typeof(string));
        //    dt.Columns.Add("SoSinhVien", typeof(string));
        //    dt.Columns.Add("DM_ToaNhaID", typeof(int));
        //    dt.Columns.Add("IDDM_PhongHoc", typeof(int));
        //    return dt;
        //}

        //public DataTable Get_Tree()
        //{
        //    cBDM_ToaNha oBToaNha = new cBDM_ToaNha();
        //    DM_ToaNhaInfo oToaNhaInfo = new DM_ToaNhaInfo();
        //    oToaNhaInfo.DM_ToaNhaID = 0;
        //    DataTable dt = oBToaNha.Get(oToaNhaInfo);
        //    DataTable dtTree = CreateTableTree();
        //    oDM_PhongHocInfo = new DM_PhongHocInfo();
        //    oDM_PhongHocInfo.DM_PhongHocID = 0;
        //    DataTable dtPH = Get_TKB();
        //    currID = 0;
        //    AddTree(dt, dtTree, dtPH, "ParentID", 0, 0);
        //    return dtTree;
        //}

        //private void AddTree(DataTable dtSource, DataTable dtTree, DataTable dtPH, string ParentField, int ParentValue, int ValueField)
        //{
        //    //string strFilter = "";
        //    Lib.clsDataTableHelper cls = new Lib.clsDataTableHelper();
        //    if (dtSource.Rows.Count > 0)
        //    {
        //    //    if (ParentValue > 0)
        //    //    {
        //    //        strFilter = ParentField + " = " + ValueField;
        //    //    }
        //    //    else
        //    //    {
        //    //        strFilter = ParentField + " <= 0";
        //    //    }

        //        //DataRow[] arrDr = dtSource.Select(strFilter);
        //        //if (arrDr.Length > 0)
        //        //{
        //            foreach (DataRow dr in dtSource.Rows)
        //            {
        //                DataRow drNew = dtTree.NewRow();
        //                currID++;
        //                drNew["ID"] = currID;
        //                drNew["ParentID"] = ParentValue;
        //                drNew["TenToaNha"] = dr["TenToaNha"];
        //                drNew["MaToaNha"] = dr["MaToaNha"];
        //                drNew["TenPhongHoc"] = "";
        //                drNew["SoSinhVien"] = "";
        //                drNew["DM_ToaNhaID"] = dr["DM_ToaNhaID"];
        //                drNew["IDDM_PhongHoc"] = -1;
        //                dtTree.Rows.Add(drNew);
        //                // Add phòng học vào tree phòng học
        //                DataRow[] drGV = dtPH.Select("IDDM_ToaNha = " + dr["DM_ToaNhaID"].ToString());
        //                foreach (DataRow dr1 in drGV)
        //                {
        //                    drNew = dtTree.NewRow();
        //                    drNew["ID"] = 100 + int.Parse(dr1["DM_PhongHocID"].ToString());
        //                    drNew["ParentID"] = currID;
        //                    drNew["TenToaNha"] = "";
        //                    drNew["MaToaNha"] = "";
        //                    drNew["TenPhongHoc"] = dr1["TenPhongHoc"].ToString();
        //                    drNew["SoSinhVien"] = "";
        //                    drNew["DM_ToaNhaID"] = dr["DM_ToaNhaID"];
        //                    drNew["IDDM_PhongHoc"] = dr1["DM_PhongHocID"].ToString();
        //                    dtTree.Rows.Add(drNew);
        //                }
        //                AddTree(dtSource, dtTree, dtPH, "ParentID", currID, int.Parse(dr["DM_ToaNhaID"].ToString()));
        //            }
        //        //}
        //    }
        //}
        //#endregion
        //public List<DM_PhongHocInfo> GetList(DM_PhongHocInfo pDM_PhongHocInfo)
        //{
        //    List<DM_PhongHocInfo> oDM_PhongHocInfoList = new List<DM_PhongHocInfo>();
        //    DataTable dtb = Get(pDM_PhongHocInfo);
        //    if (dtb != null)
        //    {
        //        for (int i = 0; i < dtb.Rows.Count; i++)
        //        {
        //            oDM_PhongHocInfo = new DM_PhongHocInfo();

        //            oDM_PhongHocInfo.DM_PhongHocID = int.Parse(dtb.Rows[i]["DM_PhongHocID"].ToString());
        //            oDM_PhongHocInfo.TenPhongHoc = dtb.Rows[i]["TenPhongHoc"].ToString();
        //            oDM_PhongHocInfo.IDDM_ToaNha = int.Parse(dtb.Rows[i]["IDDM_ToaNha"].ToString());
        //            oDM_PhongHocInfo.IDDM_Tang = int.Parse(dtb.Rows[i]["IDDM_Tang"].ToString());
        //            oDM_PhongHocInfo.SucChua = int.Parse(dtb.Rows[i]["SucChua"].ToString());
        //            oDM_PhongHocInfo.IDDM_LoaiPhong = int.Parse(dtb.Rows[i]["IDDM_LoaiPhong"].ToString());

        //            oDM_PhongHocInfoList.Add(oDM_PhongHocInfo);
        //        }
        //    }
        //    return oDM_PhongHocInfoList;
        //}

        public void ToDataRow(DM_PhongHocInfo pDM_PhongHocInfo, ref DataRow dr)
        {

            dr[pDM_PhongHocInfo.strDM_PhongHocID] = pDM_PhongHocInfo.DM_PhongHocID;
            dr[pDM_PhongHocInfo.strTenPhongHoc] = pDM_PhongHocInfo.TenPhongHoc;
            dr[pDM_PhongHocInfo.strIDDM_ToaNha] = pDM_PhongHocInfo.IDDM_ToaNha;
            dr[pDM_PhongHocInfo.strIDDM_Tang] = pDM_PhongHocInfo.IDDM_Tang;
            dr[pDM_PhongHocInfo.strSucChua] = pDM_PhongHocInfo.SucChua;
            dr[pDM_PhongHocInfo.strIDDM_LoaiPhong] = pDM_PhongHocInfo.IDDM_LoaiPhong;
        }

        #region "Dành cho xếp TKB"
        public cBwsDM_PhongHoc(HT_ThamSoXepLichInfo pThamSoTKB)
        {
            oDDM_PhongHoc = new cDDM_PhongHoc();
            arrPhongHoc = new ArrayList();
            DM_PhongHocInfo objPhong;
            int intPhongHocID, intIDToaNha, intIDDM_Tang, intSucChua;
            string strTenPhong;
            DataTable dtPhong = Get_TKB();
            foreach (DataRow dr in dtPhong.Rows)
            {
                intPhongHocID = int.Parse(dr["DM_PhongHocID"].ToString());
                strTenPhong = dr["TenPhongHoc"].ToString();
                intIDToaNha = (int)dr["IDDM_ToaNha"];
                intIDDM_Tang = int.Parse(dr["IDDM_Tang"].ToString());
                intSucChua = (int)dr["SucChua"];
                objPhong = new DM_PhongHocInfo(intPhongHocID, strTenPhong, intIDToaNha, intIDDM_Tang, intSucChua, pThamSoTKB);
                arrPhongHoc.Add(objPhong);
            }
        }

        public string SearchTenPhong(int IDPhongHoc)
        {
            DM_PhongHocInfo objPhong;
            for (int i = 0; i < arrPhongHoc.Count; i++)
            {
                objPhong = (DM_PhongHocInfo)arrPhongHoc[i];
                if (IDPhongHoc == objPhong.DM_PhongHocID)
                    return objPhong.TenPhongHoc;
            }
            return "";
        }

        public int SearchIndexPhong(int IDPhongHoc)
        {
            DM_PhongHocInfo objPhong;
            for (int i = 0; i < arrPhongHoc.Count; i++)
            {
                objPhong = (DM_PhongHocInfo)arrPhongHoc[i];
                if (IDPhongHoc == objPhong.DM_PhongHocID)
                    return i;
            }
            return -1;
        }

        public int Count
        {
            get { return arrPhongHoc.Count; }
        }

        public DM_PhongHocInfo this[int idx]
        {
            set { arrPhongHoc[idx] = value; }
            get { return (DM_PhongHocInfo)arrPhongHoc[idx]; }
        }
        #endregion
    }
}
