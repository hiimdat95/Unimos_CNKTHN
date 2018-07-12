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
    public class cBwsTC_LoaiThuChi : cBwsBase
    {
        private cDTC_LoaiThuChi oDTC_LoaiThuChi;
        private TC_LoaiThuChiInfo oTC_LoaiThuChiInfo;
        private int currID = 0;

        public cBwsTC_LoaiThuChi()
        {
            oDTC_LoaiThuChi = new cDTC_LoaiThuChi();
            oTC_LoaiThuChiInfo = new TC_LoaiThuChiInfo();
        }

        //public DataTable Get(TC_LoaiThuChiInfo pTC_LoaiThuChiInfo)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<TC_LoaiThuChiInfo>(client.cDTC_LoaiThuChi_Get(GlobalVar.MaXacThuc, pTC_LoaiThuChiInfo));
        //    }
        //}

        public DataTable GetBy_IDNamHoc_HocKy(int IDNamHoc, int HocKy, bool HasParent)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_TC_LoaiThuChi_GetBy_IDNamHoc_HocKyResult>(client.cDTC_LoaiThuChi_GetBy_IDNamHoc_HocKy(GlobalVar.MaXacThuc, IDNamHoc, HocKy, HasParent));
            }
        }

        public DataTable GetTongHop()
        {
            return oDTC_LoaiThuChi.GetTongHop();
        }

        //public int Add(TC_LoaiThuChiInfo pTC_LoaiThuChiInfo)
        //{
        //    int ID = 0;
        //    var client = new UnimOsServiceClient();
        //    ID = client.cDTC_LoaiThuChi_Add(GlobalVar.MaXacThuc, pTC_LoaiThuChiInfo);
        //    client.Close();
        //    mErrorMessage = oDTC_LoaiThuChi.ErrorMessages;
        //    mErrorNumber = oDTC_LoaiThuChi.ErrorNumber;
        //    return ID;
        //}

        //public void Update(TC_LoaiThuChiInfo pTC_LoaiThuChiInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDTC_LoaiThuChi_Update(GlobalVar.MaXacThuc, pTC_LoaiThuChiInfo);
        //    client.Close();
        //    mErrorMessage = oDTC_LoaiThuChi.ErrorMessages;
        //    mErrorNumber = oDTC_LoaiThuChi.ErrorNumber;
        //}

        //public void Delete(TC_LoaiThuChiInfo pTC_LoaiThuChiInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDTC_LoaiThuChi_Delete(GlobalVar.MaXacThuc, pTC_LoaiThuChiInfo);
        //    client.Close();
        //    mErrorMessage = oDTC_LoaiThuChi.ErrorMessages;
        //    mErrorNumber = oDTC_LoaiThuChi.ErrorNumber;
        //}

        //public List<TC_LoaiThuChiInfo> GetList(TC_LoaiThuChiInfo pTC_LoaiThuChiInfo)
        //{
        //    List<TC_LoaiThuChiInfo> oTC_LoaiThuChiInfoList = new List<TC_LoaiThuChiInfo>();
        //    DataTable dtb = Get(pTC_LoaiThuChiInfo);
        //    if (dtb != null)
        //    {
        //        for (int i = 0; i < dtb.Rows.Count; i++)
        //        {
        //            oTC_LoaiThuChiInfo = new TC_LoaiThuChiInfo();

        //            oTC_LoaiThuChiInfo.TC_LoaiThuChiID = int.Parse(dtb.Rows[i]["TC_LoaiThuChiID"].ToString());
        //            oTC_LoaiThuChiInfo.TenLoaiThuChi = dtb.Rows[i]["TenLoaiThuChi"].ToString();
        //            oTC_LoaiThuChiInfo.SoTien = double.Parse(dtb.Rows[i]["SoTien"].ToString());
        //            oTC_LoaiThuChiInfo.KhoanThu = bool.Parse(dtb.Rows[i]["KhoanThu"].ToString());
        //            oTC_LoaiThuChiInfo.BatBuoc = bool.Parse(dtb.Rows[i]["BatBuoc"].ToString());
        //            oTC_LoaiThuChiInfo.TheoNienKhoa = bool.Parse(dtb.Rows[i]["TheoNienKhoa"].ToString());
        //            oTC_LoaiThuChiInfo.HocPhi = bool.Parse(dtb.Rows[i]["HocPhi"].ToString());
        //            oTC_LoaiThuChiInfo.NhapHoc = bool.Parse(dtb.Rows[i]["NhapHoc"].ToString());
        //            oTC_LoaiThuChiInfo.ParentID = int.Parse(dtb.Rows[i]["ParentID"].ToString());
        //            oTC_LoaiThuChiInfo.IDNamHoc = int.Parse(dtb.Rows[i]["IDNamHoc"].ToString());
        //            oTC_LoaiThuChiInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());

        //            oTC_LoaiThuChiInfoList.Add(oTC_LoaiThuChiInfo);
        //        }
        //    }
        //    return oTC_LoaiThuChiInfoList;
        //}

        public void ToDataRow(TC_LoaiThuChiInfo pTC_LoaiThuChiInfo, ref DataRow dr)
        {

            dr[pTC_LoaiThuChiInfo.strTC_LoaiThuChiID] = pTC_LoaiThuChiInfo.TC_LoaiThuChiID;
            dr[pTC_LoaiThuChiInfo.strTenLoaiThuChi] = pTC_LoaiThuChiInfo.TenLoaiThuChi;
            dr[pTC_LoaiThuChiInfo.strSoTien] = pTC_LoaiThuChiInfo.SoTien;
            dr[pTC_LoaiThuChiInfo.strKhoanThu] = pTC_LoaiThuChiInfo.KhoanThu;
            dr[pTC_LoaiThuChiInfo.strBatBuoc] = pTC_LoaiThuChiInfo.BatBuoc;
            dr[pTC_LoaiThuChiInfo.strTheoNienKhoa] = pTC_LoaiThuChiInfo.TheoNienKhoa;
            dr[pTC_LoaiThuChiInfo.strHocPhi] = pTC_LoaiThuChiInfo.HocPhi;
            dr[pTC_LoaiThuChiInfo.strNhapHoc] = pTC_LoaiThuChiInfo.NhapHoc;
            dr[pTC_LoaiThuChiInfo.strParentID] = pTC_LoaiThuChiInfo.ParentID;
            dr[pTC_LoaiThuChiInfo.strIDNamHoc] = pTC_LoaiThuChiInfo.IDNamHoc;
            dr[pTC_LoaiThuChiInfo.strHocKy] = pTC_LoaiThuChiInfo.HocKy;
        }

        public void ToInfo(ref TC_LoaiThuChiInfo pTC_LoaiThuChiInfo, DataRow dr)
        {

            pTC_LoaiThuChiInfo.TC_LoaiThuChiID = int.Parse(dr[pTC_LoaiThuChiInfo.strTC_LoaiThuChiID].ToString());
            pTC_LoaiThuChiInfo.TenLoaiThuChi = dr[pTC_LoaiThuChiInfo.strTenLoaiThuChi].ToString();
            pTC_LoaiThuChiInfo.SoTien = double.Parse(dr[pTC_LoaiThuChiInfo.strSoTien].ToString());
            pTC_LoaiThuChiInfo.KhoanThu = bool.Parse(dr[pTC_LoaiThuChiInfo.strKhoanThu].ToString());
            pTC_LoaiThuChiInfo.BatBuoc = bool.Parse(dr[pTC_LoaiThuChiInfo.strBatBuoc].ToString());
            pTC_LoaiThuChiInfo.TheoNienKhoa = bool.Parse(dr[pTC_LoaiThuChiInfo.strTheoNienKhoa].ToString());
            pTC_LoaiThuChiInfo.HocPhi = bool.Parse(dr[pTC_LoaiThuChiInfo.strHocPhi].ToString());
            pTC_LoaiThuChiInfo.NhapHoc = bool.Parse(dr[pTC_LoaiThuChiInfo.strNhapHoc].ToString());
            pTC_LoaiThuChiInfo.ParentID = int.Parse(dr[pTC_LoaiThuChiInfo.strParentID].ToString());
            pTC_LoaiThuChiInfo.IDNamHoc = int.Parse(dr[pTC_LoaiThuChiInfo.strIDNamHoc].ToString());
            pTC_LoaiThuChiInfo.HocKy = int.Parse(dr[pTC_LoaiThuChiInfo.strHocKy].ToString());
        }

        private DataTable CreateTableTree()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("ParentIDs", typeof(int));
            dt.Columns.Add("TenLoaiThuChi", typeof(string));
            dt.Columns.Add("SoTien", typeof(double));
            dt.Columns.Add("KhoanThu", typeof(bool));
            dt.Columns.Add("BatBuoc", typeof(bool));
            dt.Columns.Add("TheoNienKhoa", typeof(bool));
            dt.Columns.Add("HocPhi", typeof(bool));
            dt.Columns.Add("NhapHoc", typeof(bool));
            dt.Columns.Add("ParentID", typeof(int));
            dt.Columns.Add("IDNamHoc", typeof(int));
            dt.Columns.Add("HocKy", typeof(int));
            dt.Columns.Add("TC_LoaiThuChiID", typeof(int));
            return dt;
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
                        drNew["TenLoaiThuChi"] = dr["TenLoaiThuChi"];
                        drNew["SoTien"] = dr["SoTien"];
                        drNew["KhoanThu"] = dr["KhoanThu"];
                        drNew["BatBuoc"] = dr["BatBuoc"];
                        drNew["TheoNienKhoa"] = dr["TheoNienKhoa"];
                        drNew["HocPhi"] = dr["HocPhi"];
                        drNew["NhapHoc"] = dr["NhapHoc"];
                        drNew["ParentID"] = dr["ParentID"];
                        drNew["IDNamHoc"] = dr["IDNamHoc"];
                        drNew["HocKy"] = dr["HocKy"];
                        drNew["TC_LoaiThuChiID"] = dr["TC_LoaiThuChiID"];
                        dtTree.Rows.Add(drNew);
                        AddTree(dtSource, dtTree, ParentField, currID, int.Parse(dr["TC_LoaiThuChiID"].ToString()));
                    }
                }
            }
        }

        public DataTable Get_Tree(int IDNamHoc, int HocKy)
        {
            DataTable dt = GetBy_IDNamHoc_HocKy(IDNamHoc, HocKy, true);
            //oTC_LoaiThuChiInfo.TC_LoaiThuChiID = 0;
            //DataTable dt = oDTC_LoaiThuChi.GetBy_IDNamHoc_HocKy(IDNamHoc, HocKy);
            DataTable dtTree = CreateTableTree();
            currID = 0;
            AddTree(dt, dtTree, "ParentID", 0, 0);
            return dtTree;
        }
    }
}
