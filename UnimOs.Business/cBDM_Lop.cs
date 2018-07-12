using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;
using System.Collections;
using Lib;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_Lop : cBBase
    {
        #region "Khai báo biên"
        private cDDM_Lop oDDM_Lop;
        private DM_LopInfo oDM_LopInfo;
        private DataTable dt = new DataTable();
        private ArrayList arrLop;
        private clsDataTableHelper clsTable;
        private int currID;
        #endregion

        public cBDM_Lop()        
        {
            oDDM_Lop = new cDDM_Lop();
            clsTable = new clsDataTableHelper();
        }

        #region Tạo tree lớp
        public DataTable GetTreeTheoKhoa(string NamHoc)
        {
            DataTable dt = oDDM_Lop.GetTree(NamHoc);
            return CreateTree(dt);
        }

        public DataTable GetTreeTheoGiaoVien(string NamHoc, int IDNS_GiaoVien, int IDDM_NamHoc, int HocKy)
        {
            DataTable dt = oDDM_Lop.GetTreeByIDGiaoVien(NamHoc, IDNS_GiaoVien, IDDM_NamHoc, HocKy);
            return CreateTree(dt);
        }

        public DataTable GetTreeThiSinhTuDo(string NamHoc)
        {
            DataTable dt = oDDM_Lop.GetTree_ThiSinhTuDo(NamHoc);
            return CreateTree(dt);
        }

        public DataTable CreateTableTree()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("ParentID", typeof(int));
            dt.Columns.Add("TenLop", typeof(string));
            dt.Columns.Add("TenNganh", typeof(string));
            dt.Columns.Add("IDDM_He", typeof(int));
            dt.Columns.Add("IDDM_TrinhDo", typeof(int));
            dt.Columns.Add("IDDM_Khoa", typeof(int));
            dt.Columns.Add("IDDM_KhoaHoc", typeof(int));
            dt.Columns.Add("IDDM_Nganh", typeof(int));
            dt.Columns.Add("IDDM_ChuyenNganh", typeof(int));
            dt.Columns.Add("IDDM_Lop", typeof(int));
            dt.Columns.Add("IDKQHT_ChuongTrinhDaoTao", typeof(int));
            dt.Columns.Add("IDDM_DiaDiem", typeof(int));
            dt.Columns.Add("ImageIndex", typeof(int));
            return dt;
        }

        // Khoa
        // -- Hệ
        //    -- Trình độ
        //       -- Khoá
        //          -- Lớp
        public DataTable CreateTree(DataTable dt)
        {
            string[] UnDistinct = { "IDDM_He", "IDDM_TrinhDo", "IDDM_Khoa", "IDDM_KhoaHoc", "IDDM_Nganh", "IDDM_ChuyenNganh", "DM_LopID", "IDKQHT_ChuongTrinhDaoTao", "IDDM_DiaDiem" };
            DataTable dtTree = CreateTableTree();
            DataTable dtHe, dtTrinhDo, dtKhoaHoc, dtLop;
            // Add Khoa
            DataTable dtKhoa = clsTable.SelectDistinct(dt, new string[] { "TenKhoa" }, UnDistinct);
            int ParentKhoa = 0, pHe, pTrinhDo, pKhoaHoc, pLop;
            currID = 0;
            foreach (DataRow drKhoa in dtKhoa.Rows)
            {
                AddTreeNode(dtTree, drKhoa, "TenKhoa", "", "Khoa", ParentKhoa, new int[] { int.Parse(drKhoa["IDDM_Khoa"].ToString()), 0, 0, 0, 0, 0, 0, 0, 0 }, 0);
                // Add He
                dtHe = clsTable.SelectDistinct(dt, new string[] { "TenHe" }, UnDistinct, "TenKhoa = '" + drKhoa["TenKhoa"] + "'");
                pHe = currID;
                foreach (DataRow drHe in dtHe.Rows)
                {
                    AddTreeNode(dtTree, drHe, "TenHe", "", "Hệ", pHe, new int[] { int.Parse(drHe["IDDM_Khoa"].ToString()), 
                        int.Parse(drHe["IDDM_He"].ToString()), 0, 0, 0, 0, 0, 0, 0 }, 1);
                    // Add TrinhDo
                    dtTrinhDo = clsTable.SelectDistinct(dt, new string[] { "TenTrinhDo" }, UnDistinct,
                        "TenKhoa = '" + drKhoa["TenKhoa"] + "' And TenHe = '" + drHe["TenHe"] + "'");
                    pTrinhDo = currID;
                    foreach (DataRow drTrinhDo in dtTrinhDo.Rows)
                    {
                        AddTreeNode(dtTree, drTrinhDo, "TenTrinhDo", "", "Trình độ", pTrinhDo, new int[] { int.Parse(drTrinhDo["IDDM_Khoa"].ToString()), 
                            int.Parse(drTrinhDo["IDDM_He"].ToString()), int.Parse(drTrinhDo["IDDM_TrinhDo"].ToString()), 0, 0, 0, 0, 0, 0 }, 2);
                        // Add KhoaHoc
                        dtKhoaHoc = clsTable.SelectDistinct(dt, new string[] { "TenKhoaHoc" }, UnDistinct, "TenKhoa = '" + drKhoa["TenKhoa"]
                            + "' And TenHe = '" + drHe["TenHe"] + "' And TenTrinhDo = '" + drTrinhDo["TenTrinhDo"] + "'");
                        pKhoaHoc = currID;
                        foreach (DataRow drKhoaHoc in dtKhoaHoc.Rows)
                        {
                            AddTreeNode(dtTree, drKhoaHoc, "TenKhoaHoc", "", "Khoá", pKhoaHoc, new int[] { int.Parse(drKhoaHoc["IDDM_Khoa"].ToString()), 
                                int.Parse(drKhoaHoc["IDDM_He"].ToString()), int.Parse(drKhoaHoc["IDDM_TrinhDo"].ToString()), int.Parse(drKhoaHoc["IDDM_KhoaHoc"].ToString()), 0, 0, 0, 0, 0 }, 3);
                            // Add Lop
                            dtLop = clsTable.SelectDistinct(dt, new string[] { "TenLop", "TenNganh" }, UnDistinct, "TenKhoa = '" + drKhoa["TenKhoa"]
                                + "' And TenHe = '" + drHe["TenHe"] + "' And TenTrinhDo = '" + drTrinhDo["TenTrinhDo"] + "' And TenKhoaHoc = '" + drKhoaHoc["TenKhoaHoc"] + "'");
                            pLop = currID;
                            foreach (DataRow drLop in dtLop.Rows)
                            {
                                AddTreeNode(dtTree, drLop, "TenLop", "TenNganh", "Lớp", pLop, new int[] { int.Parse(drLop["IDDM_Khoa"].ToString()), 
                                    int.Parse(drLop["IDDM_He"].ToString()), int.Parse(drLop["IDDM_TrinhDo"].ToString()), int.Parse(drLop["IDDM_KhoaHoc"].ToString()), 0, 0, 
                                    int.Parse(drLop["DM_LopID"].ToString()), int.Parse("0" + drLop["IDKQHT_ChuongTrinhDaoTao"]), ""+drLop["IDDM_DiaDiem"] ==""? 0: int.Parse(drLop["IDDM_DiaDiem"].ToString())}, 4);
                            }
                        }
                    }
                }
            }
            return dtTree;
        }

        private void AddTreeNode(DataTable dtTree, DataRow drSource, string TenLop, string TenNganh, string Text, int ParentID, int[] Value, int imageIndex)
        {
            DataRow drNew = dtTree.NewRow();
            currID++;
            drNew["ID"] = currID;
            drNew["ParentID"] = ParentID;
            drNew["TenLop"] = Text + ": " + drSource[TenLop];
            if (TenNganh != "")
                drNew["TenNganh"] = "" + drSource[TenNganh];
            drNew["IDDM_Khoa"] = Value[0];
            drNew["IDDM_He"] = Value[1];
            drNew["IDDM_TrinhDo"] = Value[2];
            drNew["IDDM_KhoaHoc"] = Value[3];
            drNew["IDDM_Nganh"] = Value[4];
            drNew["IDDM_ChuyenNganh"] = Value[5];
            drNew["IDDM_Lop"] = Value[6];
            drNew["IDKQHT_ChuongTrinhDaoTao"] = Value[7];
            drNew["IDDM_DiaDiem"] = Value[8];
            drNew["ImageIndex"] = imageIndex;
            dtTree.Rows.Add(drNew);
        }

        private void AddTreeKhoa(DataTable dtSource, DataTable dtTree, string ParentField, int ParentValue, int ValueField)
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
                        drNew["Them"] = dr["Them"];
                        drNew["Sua"] = dr["Sua"];
                        drNew["Xoa"] = dr["Xoa"];
                        drNew["Chon"] = dr["Chon"];
                        drNew["barbtnName"] = dr["barbtnName"];
                        drNew["GanQuyenID"] = dr["GanQuyenID"];
                        drNew["HT_ChucNangID"] = dr["HT_ChucNangID"];
                        dtTree.Rows.Add(drNew);
                        AddTreeKhoa(dtSource, dtTree, ParentField, currID, int.Parse(dr["HT_ChucNangID"].ToString()));
                    }
                }
            }
        }
        #endregion

        public DataTable Get(DM_LopInfo pDM_LopInfo)        
        {
            return oDDM_Lop.Get(pDM_LopInfo);
        }

        public string GetTenLop(int DM_LopID)
        {
            oDM_LopInfo = new DM_LopInfo();
            oDM_LopInfo.DM_LopID = DM_LopID;
            DataTable dt = Get(oDM_LopInfo);
            if (dt.Rows.Count > 0)
                return dt.Rows[0]["TenLop"].ToString();

            return "";
        }

        public DataTable GetLopGop(DM_LopInfo pDM_LopInfo, int IDDM_MonHoc, string NamHoc)
        {
            return oDDM_Lop.GetLopGop(pDM_LopInfo, IDDM_MonHoc, NamHoc);
        }

        public DataTable GetDanhSachLop(DM_LopInfo pDM_LopInfo, string NamHoc)
        {
            return oDDM_Lop.GetDanhSachLop(pDM_LopInfo, NamHoc);
        }

        public DataTable GetDanhSachLop_ThiSinhTuDo(string NamHoc)
        {
            return oDDM_Lop.GetTree_ThiSinhTuDo(NamHoc);
        }

        public DataTable GetTongHopXepLoai(DM_LopInfo pDM_LopInfo, string NamHoc, int IDDM_NamHoc, int HocKy)
        {
            return oDDM_Lop.GetTongHopXepLoai(pDM_LopInfo, NamHoc, IDDM_NamHoc, HocKy);
        }

        public DataTable GetTree(string NamHoc)
        {
            return oDDM_Lop.GetTree(NamHoc);
        }

        public DataTable GetChon(int IDDM_TrinhDo, string NamHoc)
        {
            return oDDM_Lop.GetChon(IDDM_TrinhDo, NamHoc);
        }

        public DataTable GetKeHoachToanTruong(int IDNamHoc, string NamHoc, DM_LopInfo pDM_LopInfo)
        {
            return oDDM_Lop.GetKeHoachToanTruong(IDNamHoc, NamHoc, pDM_LopInfo);
        }

        public DataTable GetPhanBoPhongHoc(int IDNamHoc, string NamHoc, int HocKy, int CaHoc, int TuTuan, int DenTuan)
        {
            return oDDM_Lop.GetPhanBoPhongHoc(IDNamHoc, NamHoc, HocKy, CaHoc, TuTuan, DenTuan);
        }

        public DataTable GetChuongTrinhDaoTao(int DM_LopID)
        {
            return oDDM_Lop.GetChuongTrinhDaoTao(DM_LopID);
        }
        public DataTable GetTongDiemThanhPhan(int IDXL_MonHocTrongKy)
        {
            return oDDM_Lop.GetGetTongDiemThanhPhan(IDXL_MonHocTrongKy);
        }
        public DataTable GetByKhoa(int IDDM_Khoa, string @NamHoc)
        {
            return oDDM_Lop.GetByKhoa(IDDM_Khoa,@NamHoc);
        }

        public DataTable Get_TKB(long IDXL_Tuan)
        {
            return oDDM_Lop.Get_TKB(IDXL_Tuan);
        }

        public int Add(DM_LopInfo pDM_LopInfo)
        {
			int ID = 0;
            ID = oDDM_Lop.Add(pDM_LopInfo);
            mErrorMessage = oDDM_Lop.ErrorMessages;
            mErrorNumber = oDDM_Lop.ErrorNumber;
            return ID;
        }

        public void Update(DM_LopInfo pDM_LopInfo)
        {
            oDDM_Lop.Update(pDM_LopInfo);
            mErrorMessage = oDDM_Lop.ErrorMessages;
            mErrorNumber = oDDM_Lop.ErrorNumber;
        }
        
        public void Delete(DM_LopInfo pDM_LopInfo)
        {
            oDDM_Lop.Delete(pDM_LopInfo);
            mErrorMessage = oDDM_Lop.ErrorMessages;
            mErrorNumber = oDDM_Lop.ErrorNumber;
        }

        public List<DM_LopInfo> GetList(DM_LopInfo pDM_LopInfo)
        {
            List<DM_LopInfo> oDM_LopInfoList = new List<DM_LopInfo>();
            DataTable dtb = Get(pDM_LopInfo);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    oDM_LopInfo = new DM_LopInfo();

                    oDM_LopInfo.DM_LopID = int.Parse(dtb.Rows[i]["DM_LopID"].ToString());
                    oDM_LopInfo.TenLop = dtb.Rows[i]["TenLop"].ToString();
                    oDM_LopInfo.IDDM_He = int.Parse(dtb.Rows[i]["IDDM_He"].ToString());
                    oDM_LopInfo.IDDM_TrinhDo = int.Parse(dtb.Rows[i]["IDDM_TrinhDo"].ToString());
                    oDM_LopInfo.IDDM_Khoa = int.Parse(dtb.Rows[i]["IDDM_Khoa"].ToString());
                    oDM_LopInfo.IDDM_Nganh = int.Parse(dtb.Rows[i]["IDDM_Nganh"].ToString());
                    oDM_LopInfo.IDDM_ChuyenNganh = int.Parse(dtb.Rows[i]["IDDM_ChuyenNganh"].ToString());
                    oDM_LopInfo.NienKhoa = dtb.Rows[i]["NienKhoa"].ToString();
                    oDM_LopInfo.IDDM_KhoaHoc = int.Parse(dtb.Rows[i]["IDDM_KhoaHoc"].ToString());
                    oDM_LopInfo.SoSinhVien = int.Parse(dtb.Rows[i]["SoSinhVien"].ToString());
                    oDM_LopInfo.NgayVao = DateTime.Parse(dtb.Rows[i]["NgayVao"].ToString());
                    oDM_LopInfo.NgayRa = DateTime.Parse(dtb.Rows[i]["NgayRa"].ToString());
                    oDM_LopInfo.DaRaTruong = bool.Parse(dtb.Rows[i]["DaRaTruong"].ToString());
                    oDM_LopInfo.IDDM_TruongLienKet = int.Parse(dtb.Rows[i]["IDDM_TruongLienKet"].ToString());
                    oDM_LopInfo.XepThoiKhoaBieu = bool.Parse(dtb.Rows[i]["XepThoiKhoaBieu"].ToString());
                    oDM_LopInfo.KieuLopTachGop = int.Parse(dtb.Rows[i]["KieuLopTachGop"].ToString());

                    oDM_LopInfoList.Add(oDM_LopInfo);
                }
            }
            return oDM_LopInfoList;
        }

        public void ToDataRow(DM_LopInfo pDM_LopInfo, ref DataRow dr)
        {
            dr[pDM_LopInfo.strDM_LopID] = pDM_LopInfo.DM_LopID;
            dr[pDM_LopInfo.strTenLop] = pDM_LopInfo.TenLop;
            dr[pDM_LopInfo.strIDDM_He] = pDM_LopInfo.IDDM_He;
            dr[pDM_LopInfo.strIDDM_TrinhDo] = pDM_LopInfo.IDDM_TrinhDo;
            dr[pDM_LopInfo.strIDDM_Khoa] = pDM_LopInfo.IDDM_Khoa;
            dr[pDM_LopInfo.strIDDM_Nganh] = pDM_LopInfo.IDDM_Nganh;
            dr[pDM_LopInfo.strIDDM_ChuyenNganh] = pDM_LopInfo.IDDM_ChuyenNganh;
            dr[pDM_LopInfo.strNienKhoa] = pDM_LopInfo.NienKhoa;
            dr[pDM_LopInfo.strIDDM_KhoaHoc] = pDM_LopInfo.IDDM_KhoaHoc;
            dr[pDM_LopInfo.strIDDM_DiaDiem] = pDM_LopInfo.IDDM_DiaDiem;
            dr[pDM_LopInfo.strSoSinhVien] = pDM_LopInfo.SoSinhVien;
            dr[pDM_LopInfo.strNgayVao] = pDM_LopInfo.NgayVao;
            dr[pDM_LopInfo.strNgayRa] = pDM_LopInfo.NgayRa;
            dr[pDM_LopInfo.strDaRaTruong] = pDM_LopInfo.DaRaTruong;
            dr[pDM_LopInfo.strIDDM_TruongLienKet] = pDM_LopInfo.IDDM_TruongLienKet;
            dr[pDM_LopInfo.strXepThoiKhoaBieu] = pDM_LopInfo.XepThoiKhoaBieu;
            dr[pDM_LopInfo.strKieuLopTachGop] = pDM_LopInfo.KieuLopTachGop;
        }

        public void ToInfo(ref DM_LopInfo pDM_LopInfo, DataRow dr)
        {
            pDM_LopInfo.DM_LopID = int.Parse(dr[pDM_LopInfo.strDM_LopID].ToString());
            pDM_LopInfo.TenLop = dr[pDM_LopInfo.strTenLop].ToString();
            pDM_LopInfo.IDDM_He = int.Parse(dr[pDM_LopInfo.strIDDM_He].ToString());
            pDM_LopInfo.IDDM_TrinhDo = int.Parse(dr[pDM_LopInfo.strIDDM_TrinhDo].ToString());
            pDM_LopInfo.IDDM_Khoa = int.Parse(dr[pDM_LopInfo.strIDDM_Khoa].ToString());
            pDM_LopInfo.IDDM_Nganh = int.Parse(dr[pDM_LopInfo.strIDDM_Nganh].ToString());
            pDM_LopInfo.IDDM_ChuyenNganh = int.Parse(dr[pDM_LopInfo.strIDDM_ChuyenNganh].ToString());
            pDM_LopInfo.NienKhoa = dr[pDM_LopInfo.strNienKhoa].ToString();
            pDM_LopInfo.IDDM_KhoaHoc = int.Parse(dr[pDM_LopInfo.strIDDM_KhoaHoc].ToString());
            pDM_LopInfo.IDDM_DiaDiem = int.Parse(dr[pDM_LopInfo.strIDDM_DiaDiem].ToString());
            pDM_LopInfo.SoSinhVien = int.Parse(dr[pDM_LopInfo.strSoSinhVien].ToString());
            pDM_LopInfo.NgayVao = DateTime.Parse(dr[pDM_LopInfo.strNgayVao].ToString());
            pDM_LopInfo.NgayRa = DateTime.Parse(dr[pDM_LopInfo.strNgayRa].ToString());
            pDM_LopInfo.DaRaTruong = bool.Parse(dr[pDM_LopInfo.strDaRaTruong].ToString());
            pDM_LopInfo.IDDM_TruongLienKet = int.Parse(dr[pDM_LopInfo.strIDDM_TruongLienKet].ToString());
            pDM_LopInfo.XepThoiKhoaBieu = bool.Parse(dr[pDM_LopInfo.strXepThoiKhoaBieu].ToString());
            pDM_LopInfo.KieuLopTachGop = int.Parse(dr[pDM_LopInfo.strKieuLopTachGop].ToString());
        }

        #region "Dành cho xếp TKB"
        public cBDM_Lop(long IDXL_Tuan, HT_ThamSoXepLichInfo pThamSoTKB)
        {
            oDDM_Lop = new cDDM_Lop();
            arrLop = new ArrayList();
            Lop objLop;
            int intIDDM_Lop, intIDXL_LopTachGop, intIDDM_Khoa, intSoSinhVien, intIDDM_ToaNha, intIDDM_PhongHoc;
            string strTenLop;
            CA_HOC CaHoc;
            DataTable dtLop = Get_TKB(IDXL_Tuan);
            foreach (DataRow dr in dtLop.Rows)
            {
                intIDDM_Lop = int.Parse(dr["DM_LopID"].ToString());
                intIDXL_LopTachGop = int.Parse("0" + dr["IDXL_LopTachGop"]);
                intIDDM_Khoa = int.Parse(dr["IDDM_Khoa"].ToString());
                strTenLop = dr["TenLop"].ToString();
                intSoSinhVien = int.Parse(dr["SoSinhVien"].ToString());
                CaHoc = "" + dr["CaHoc"] == "" ? CA_HOC.KHONG_XAC_DINH : (CA_HOC)dr["CaHoc"];
                intIDDM_ToaNha = int.Parse("0" + dr["IDDM_ToaNha"]);
                intIDDM_PhongHoc = int.Parse("0" + dr["IDDM_PhongHoc"]);

                objLop = new Lop(intIDDM_Lop, intIDXL_LopTachGop,intIDDM_Khoa, strTenLop, intSoSinhVien, 
                    CaHoc, intIDDM_ToaNha, intIDDM_PhongHoc, pThamSoTKB);

                arrLop.Add(objLop);
            }
        }

        public string SearchTenLop(int IDDM_Lop)
        {
            Lop objLop;
            for (int i = 0; i < arrLop.Count; i++)
            {
                objLop = (Lop)arrLop[i];
                if (IDDM_Lop == objLop.IDDM_Lop)
                    return objLop.TenLop;
            }
            return "";
        }

        public int SearchIndexLop(int IDDM_Lop)
        {
            Lop objLop;
            for (int i = 0; i < arrLop.Count; i++)
            {
                objLop = (Lop)arrLop[i];
                if (IDDM_Lop == objLop.IDDM_Lop)
                    return i;
            }
            return -1;
        }

        public int Count
        {
            get { return arrLop.Count; }
        }

        public Lop this[int idx]
        {
            set { arrLop[idx] = value; }
            get { return (Lop)arrLop[idx]; }
        }
        #endregion
    }
}
