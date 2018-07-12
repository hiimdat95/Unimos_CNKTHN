using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBHT_ChucNang : cBBase
    {
        private cDHT_ChucNang oDHT_ChucNang;
        private int currID = 0;
        private HT_ChucNangInfo oHT_ChucNangInfo;

        public cBHT_ChucNang()        
        {
            oDHT_ChucNang = new cDHT_ChucNang();
        }

        public DataTable Get(HT_ChucNangInfo pHT_ChucNangInfo)        
        {
            return oDHT_ChucNang.Get(pHT_ChucNangInfo);
        }

        public DataTable GetIn(int IDHT_UserGroup, int IDHT_User)
        {
           // DataTable dt = oDHT_ChucNang.GetIn(IDHT_UserGroup, IDHT_User);
           // DataTable dtTree = CreateTableTree();
          //  currID = 0;
          //  AddTree(dt, dtTree, "ParentID", 0, 0);
            return oDHT_ChucNang.GetIn(IDHT_UserGroup, IDHT_User);
        }

        public DataTable GetIn_Tree(int IDHT_UserGroup, int IDHT_User)
        {
            DataTable dt = oDHT_ChucNang.GetIn(IDHT_UserGroup, IDHT_User);
            DataTable dtTree = CreateTableTree();
            currID = 0;
            AddTree(dt, dtTree, "ParentID", 0, 0);
            return dtTree;
        }

        public DataTable GetNotIn(int IDHT_UserGroup, int IDHT_User)
        {
            DataTable dt = oDHT_ChucNang.GetNotIn(IDHT_UserGroup, IDHT_User);
            DataTable dtTree = CreateTableTree();
            currID = 0;
            AddTree(dt, dtTree, "ParentID", 0, 0);
            return dtTree;
        }

        public DataTable CreateTableTree()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("ParentIDs", typeof(int));
            dt.Columns.Add("TenChucNang", typeof(string));
            dt.Columns.Add("Tag", typeof(string));
            dt.Columns.Add("GanQuyenID", typeof(string));
            dt.Columns.Add("barbtnName", typeof(string));
            dt.Columns.Add("ParentID", typeof(int));
            dt.Columns.Add("Level", typeof(int));
          //  dt.Columns.Add("TenPhanHe", typeof(string));
            dt.Columns.Add("IDHT_PhanHe", typeof(int));
            dt.Columns.Add("MoTa", typeof(string));
            dt.Columns.Add("KieuRibbon", typeof(string));
            dt.Columns.Add("btnThem", typeof(string));
            dt.Columns.Add("btnSua", typeof(string));
            dt.Columns.Add("btnXoa", typeof(string));
            dt.Columns.Add("Them", typeof(bool));
            dt.Columns.Add("Sua", typeof(bool));
            dt.Columns.Add("Xoa", typeof(bool));
            dt.Columns.Add("Chon", typeof(bool));
            dt.Columns.Add("HT_ChucNangID", typeof(int));
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
                        drNew["TenChucNang"] = dr["TenChucNang"];
                        drNew["Tag"] = dr["Tag"];
                        drNew["IDHT_PhanHe"] = dr["IDHT_PhanHe"];
                        drNew["ParentID"] = dr["ParentID"];
                        drNew["Level"] = dr["Level"];
                        drNew["MoTa"] = dr["MoTa"];
                        drNew["KieuRibbon"] = dr["KieuRibbon"];
                        drNew["btnThem"] = dr["btnThem"];
                        drNew["btnSua"] = dr["btnSua"];
                        drNew["btnXoa"] = dr["btnXoa"];
                        drNew["Them"] = dr["Them"];
                        drNew["Sua"] = dr["Sua"];
                        drNew["Xoa"] = dr["Xoa"];
                        drNew["Chon"] = dr["Chon"];
                        drNew["barbtnName"] = dr["barbtnName"];
                        drNew["GanQuyenID"] = dr["GanQuyenID"];
                        drNew["HT_ChucNangID"] = dr["HT_ChucNangID"];
                        dtTree.Rows.Add(drNew);
                        AddTree(dtSource, dtTree, ParentField, currID, int.Parse(dr["HT_ChucNangID"].ToString()));
                    }
                }
            }
        }

        public int Add(HT_ChucNangInfo pHT_ChucNangInfo)
        {
			int ID = 0;
            ID = oDHT_ChucNang.Add(pHT_ChucNangInfo);
            mErrorMessage = oDHT_ChucNang.ErrorMessages;
            mErrorNumber = oDHT_ChucNang.ErrorNumber;
            return ID;
        }

        public void Update(HT_ChucNangInfo pHT_ChucNangInfo)
        {
            oDHT_ChucNang.Update(pHT_ChucNangInfo);
            mErrorMessage = oDHT_ChucNang.ErrorMessages;
            mErrorNumber = oDHT_ChucNang.ErrorNumber;
        }
        
        public void Delete(HT_ChucNangInfo pHT_ChucNangInfo)
        {
            oDHT_ChucNang.Delete(pHT_ChucNangInfo);
            mErrorMessage = oDHT_ChucNang.ErrorMessages;
            mErrorNumber = oDHT_ChucNang.ErrorNumber;
        }

        public List<HT_ChucNangInfo> GetList(HT_ChucNangInfo pHT_ChucNangInfo)
        {
            List<HT_ChucNangInfo> oHT_ChucNangInfoList = new List<HT_ChucNangInfo>();
            DataTable dtb = Get(pHT_ChucNangInfo);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    oHT_ChucNangInfo = new HT_ChucNangInfo();

                    oHT_ChucNangInfo.HT_ChucNangID = int.Parse(dtb.Rows[i]["HT_ChucNangID"].ToString());
                    oHT_ChucNangInfo.IDHT_PhanHe = int.Parse(dtb.Rows[i]["IDHT_PhanHe"].ToString());
                    oHT_ChucNangInfo.TenChucNang = dtb.Rows[i]["TenChucNang"].ToString();
                    oHT_ChucNangInfo.Tag = dtb.Rows[i]["Tag"].ToString();
                    oHT_ChucNangInfo.ParentID = int.Parse(dtb.Rows[i]["ParentID"].ToString());
                    oHT_ChucNangInfo.Level = int.Parse(dtb.Rows[i]["Level"].ToString());
                    oHT_ChucNangInfo.MoTa = dtb.Rows[i]["MoTa"].ToString();
                    oHT_ChucNangInfo.barbtnName = dtb.Rows[i]["barbtnName"].ToString();
                    oHT_ChucNangInfo.btnThem = dtb.Rows[i]["btnThem"].ToString();
                    oHT_ChucNangInfo.btnSua = dtb.Rows[i]["btnSua"].ToString();
                    oHT_ChucNangInfo.btnXoa = dtb.Rows[i]["btnXoa"].ToString();

                    oHT_ChucNangInfoList.Add(oHT_ChucNangInfo);
                }
            }
            return oHT_ChucNangInfoList;
        }

        public void ToDataRow(HT_ChucNangInfo pHT_ChucNangInfo, ref DataRow dr)
        {

            dr[pHT_ChucNangInfo.strHT_ChucNangID] = pHT_ChucNangInfo.HT_ChucNangID;
            dr[pHT_ChucNangInfo.strIDHT_PhanHe] = pHT_ChucNangInfo.IDHT_PhanHe;
            dr[pHT_ChucNangInfo.strTenChucNang] = pHT_ChucNangInfo.TenChucNang;
            dr[pHT_ChucNangInfo.strTag] = pHT_ChucNangInfo.Tag;
            dr[pHT_ChucNangInfo.strParentID] = pHT_ChucNangInfo.ParentID;
            dr[pHT_ChucNangInfo.strLevel] = pHT_ChucNangInfo.Level;
            dr[pHT_ChucNangInfo.strMoTa] = pHT_ChucNangInfo.MoTa;
            dr[pHT_ChucNangInfo.strbarbtnName] = pHT_ChucNangInfo.barbtnName;
            dr[pHT_ChucNangInfo.strKieuRibbon] = pHT_ChucNangInfo.KieuRibbon;
            dr[pHT_ChucNangInfo.strbtnThem] = pHT_ChucNangInfo.btnThem;
            dr[pHT_ChucNangInfo.strbtnSua] = pHT_ChucNangInfo.btnSua;
            dr[pHT_ChucNangInfo.strbtnXoa] = pHT_ChucNangInfo.btnXoa;
        }

        public void ToInfo(ref HT_ChucNangInfo pHT_ChucNangInfo, DataRow dr)
        {

            pHT_ChucNangInfo.HT_ChucNangID = int.Parse(dr[pHT_ChucNangInfo.strHT_ChucNangID].ToString());
            pHT_ChucNangInfo.IDHT_PhanHe = int.Parse(dr[pHT_ChucNangInfo.strIDHT_PhanHe].ToString());
            pHT_ChucNangInfo.TenChucNang = dr[pHT_ChucNangInfo.strTenChucNang].ToString();
            pHT_ChucNangInfo.Tag = dr[pHT_ChucNangInfo.strTag].ToString();
            pHT_ChucNangInfo.ParentID = int.Parse(dr[pHT_ChucNangInfo.strParentID].ToString());
            pHT_ChucNangInfo.Level = int.Parse(dr[pHT_ChucNangInfo.strLevel].ToString());
            pHT_ChucNangInfo.MoTa = dr[pHT_ChucNangInfo.strMoTa].ToString();
            pHT_ChucNangInfo.barbtnName = dr[pHT_ChucNangInfo.strbarbtnName].ToString();
            pHT_ChucNangInfo.KieuRibbon = dr[pHT_ChucNangInfo.strKieuRibbon].ToString();
            pHT_ChucNangInfo.btnThem = dr[pHT_ChucNangInfo.strbtnThem].ToString();
            pHT_ChucNangInfo.btnSua = dr[pHT_ChucNangInfo.strbtnSua].ToString();
            pHT_ChucNangInfo.btnXoa = dr[pHT_ChucNangInfo.strbtnXoa].ToString();
        }
    }
}
