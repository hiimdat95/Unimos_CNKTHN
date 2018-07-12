using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;
using DevExpress.XtraGrid.Views.BandedGrid;
using C1.Win.C1FlexGrid;
using Lib;

namespace UnimOs.UI
{
    public partial class frmKeHoachChiTiet : frmBase
    {
        #region Khởi tạo biến
        private clsDataTableHelper clsdt;
        private cBXL_KeHoachTruong oBXL_KeHoachTruong;
        private XL_KeHoachTruongInfo pXL_KeHoachTruongInfo;
        private cBXL_KeHoachChiTiet oBXL_KeHoachChiTiet;
        private XL_KeHoachChiTietInfo pXL_KeHoachChiTietInfo;
        private cBXL_PhanCongGiaoVien oBXL_PhanCongGiaoVien;
        private DM_LopInfo pDM_LopInfo;
        private DataTable dtTuan, dtToanTruong, dtPhanCongGiangDay;
        public int RowBegin = 5, ColBegin = 9, rowHeight = 25, colWidth = 40;

        private int SoTietTuan, IDNS_GiaoVienChon = 0, SoNgayTuan;
        // Khai báo biến xác định indexCol đang làm việc
        private int indexCol, SoTietFocus = 0;

        protected struct CellData
        {
            public string TenPhongHoc;
            public string BuoiHoc;
            public string TenKeHoachKhac;
            public string TenVietTat;
            public string NgayNghi;
            public int SoNgayNghi;
        }

        // Khai báo cấu trúc của kế hoạch
        public struct Cell_KeHoach
        {
            public long XL_KeHoachChiTietID;
            public int IDNS_GiaoVien;
            public string TenGiaoVien;
            public int LoaiTiet;
            public int SoTiet;
            public string GhiChu;
            public bool Changed;
        }

        #endregion

        public frmKeHoachChiTiet()
        {
            InitializeComponent();
            SoNgayTuan = Program.pgrThamSo.THU_KET_THUC - Program.pgrThamSo.THU_BAT_DAU;
            oBXL_KeHoachTruong = new cBXL_KeHoachTruong();
            pXL_KeHoachTruongInfo = new XL_KeHoachTruongInfo();
            oBXL_KeHoachChiTiet = new cBXL_KeHoachChiTiet();
            pXL_KeHoachChiTietInfo = new XL_KeHoachChiTietInfo();
            oBXL_PhanCongGiaoVien = new cBXL_PhanCongGiaoVien();
            pDM_LopInfo = new DM_LopInfo();
            dtTuan = LoadTuan();
            AddBands();
            FlexColor(fg);
        }

        private void frmKeHoachChiTiet_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            bar2.Visible = true;
            //try
            //{
            //LoadKeHoach();
            SoTietTuan = int.Parse("0" + bartxtSoTietTuan.EditValue);
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message);
            //}
        }

        private void barbtnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgMoKeHoach dlg = new dlgMoKeHoach();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pDM_LopInfo = dlg.pDM_LopInfo;
                LoadKeHoach();
            }
        }

        private void LoadKeHoach()
        {
            fg.Rows.Count = 0;
            fg.Cols.Count = 0;
            DataTable dtLop;
            int row = RowBegin;
            dtToanTruong = new cBDM_Lop().GetKeHoachToanTruong(Program.IDNamHoc, Program.NamHoc, pDM_LopInfo);
            dtPhanCongGiangDay = new cBXL_MonHocTrongKy().GetByHocKyNamHoc(0, Program.HocKy, Program.IDNamHoc, 0, 0);
            clsdt = new clsDataTableHelper();
            dtLop = clsdt.SelectDistinct(dtToanTruong, new string[] { "IDDM_He", "IDDM_TrinhDo", "TenKhoaHoc", "DM_LopID", "TenLop", "SoSinhVien" });
            if (dtLop.Rows.Count > 0)
            {
                fg.Rows.Count = row + dtLop.Rows.Count;
                fg.Cols.Count = ColBegin + LoadTuan().Rows.Count;
                FormatGrid();
                for (int i = 0; i < dtLop.Rows.Count; i++)
                {
                    // Gán giá trị lớp
                    fg.Rows[row].Height = rowHeight;
                    fg[row, 0] = 0;
                    fg[row, 1] = int.Parse(dtLop.Rows[i]["DM_LopID"].ToString());
                    fg[row, 3] = dtLop.Rows[i]["TenLop"].ToString();
                    fg[row, 4] = int.Parse(dtLop.Rows[i]["SoSinhVien"].ToString());
                    CellRange rg = fg.GetCellRange(row, 0, row, fg.Cols.Fixed - 1);
                    rg.Style = fg.Styles["MyCellStyleLop"];
                    FillKeHoachLop(row, int.Parse(dtLop.Rows[i]["DM_LopID"].ToString()));
                    row++;
                    FillChiTietLop(ref row, int.Parse(dtLop.Rows[i]["DM_LopID"].ToString()));
                }
                TinhSoTietCon(RowBegin, fg.Rows.Count - 1);
            }
        }

        private void FillKeHoachLop(int r, int DM_LopID)
        {
            indexCol = ColBegin;
            for (int i = 0; i < dtTuan.Rows.Count; i++)
            {
                FormatColorCell(r, i, DM_LopID);
            }
        }

        private void FillChiTietLop(ref int row, int DM_LopID)
        {
            DataRow[] drChiTiet;
            DataTable dtChiTiet = oBXL_KeHoachChiTiet.GetKeHoachByLop(Program.IDNamHoc, Program.HocKy, DM_LopID);
            DataTable dtTemp = clsdt.SelectDistinct(dtChiTiet, new string[] { "HocKy", "TenMonHoc", "XL_MonHocTrongKyID", "DM_MonHocID", "SoHocTrinh", "TongSoTiet" });
            fg.Rows.Count = fg.Rows.Count + dtTemp.Rows.Count + 1;
            int i = 0;
            foreach (DataRow dr in dtTemp.Rows)
            {
                // Gán giá trị lớp
                fg.Rows[row + i].Height = rowHeight;
                fg[row + i, 0] = row - 1;
                fg[row + i, 1] = dr["DM_MonHocID"].ToString();
                fg[row + i, 2] = dr["HocKy"].ToString();
                fg[row + i, 3] = dr["TenMonHoc"].ToString();
                fg[row + i, 4] = Encode(dr["SoHocTrinh"].ToString(), row + i);
                fg[row + i, 5] = Encode(dr["TongSoTiet"].ToString(), row + i);
                fg[row + i, 7] = dr["XL_MonHocTrongKyID"].ToString();
                fg[row + i, 8] = GetGiaoVienGiangDay(int.Parse(dr["XL_MonHocTrongKyID"].ToString()));
                // Gán kế hoạch chi tiết môn cho hàng thứ row
                drChiTiet = dtChiTiet.Select("DM_MonHocID = " + dr["DM_MonHocID"].ToString());
                FillChiTietMon(row + i, drChiTiet);
                //CellRange rg = fg.GetCellRange(row, 0, row, fg.Cols.Fixed - 1);
                i++;
            }

            fg.Rows[row + i].Height = rowHeight;
            fg[row + i, 0] = (row - 1).ToString() + ",Tong";
            fg[row + i, 1] = 0;
            fg[row + i, 2] = "Tổng hợp kỳ";
            fg[row + i, 3] = "Tổng hợp kỳ";
            fg.Rows[row + i].AllowMerging = true;
            fg.Rows[row + i].Style = fg.Styles["MyCellStyleTongHop"];
            CellRange rg = fg.GetCellRange(row + i, 0, row + i, fg.Cols.Fixed - 1);
            rg.Style = fg.Styles["MyCellStyleTongHop"];

            row += i + 1;
        }

        private string GetGiaoVienGiangDay(int IDXL_MonHocTrongKy)
        {
            DataRow[] arrDr = dtPhanCongGiangDay.Select("XL_MonHocTrongKyID = " + IDXL_MonHocTrongKy.ToString());
            if (arrDr.Length > 0)
            {
                string IDNS_GiaoVien = "";
                foreach (DataRow dr in arrDr)
                {
                    if ("" + dr["IDNS_GiaoVien"] != "")
                        IDNS_GiaoVien += IDNS_GiaoVien != "" ? "," + dr["IDNS_GiaoVien"] : dr["IDNS_GiaoVien"].ToString();
                }
                return IDNS_GiaoVien;
            }
            else
                return "";
        }

        private void FillChiTietMon(int row, DataRow[] drChiTiet)
        {
            Cell_KeHoach ud;
            CellRange rg;
            foreach (DataRow dr in drChiTiet)
            {
                if ("" + dr["TuanThu"] != "")
                {
                    ud = new Cell_KeHoach();
                    if ("" + dr["SoTiet"] != "")
                    {
                        fg[row, ColBegin - 1 + int.Parse(dr["TuanThu"].ToString())] = dr["SoTiet"];
                    }
                    ud.XL_KeHoachChiTietID = long.Parse(dr["XL_KeHoachChiTietID"].ToString());
                    ud.SoTiet = int.Parse(dr["SoTiet"].ToString());
                    ud.LoaiTiet = int.Parse(dr["LoaiTiet"].ToString());
                    if ("" + dr["IDNS_GiaoVien"] != "")
                        ud.IDNS_GiaoVien = int.Parse(dr["IDNS_GiaoVien"].ToString());
                    ud.TenGiaoVien = "" + dr["HoTen"];
                    if (ud.IDNS_GiaoVien > 0)
                        fg.SetCellStyle(row, ColBegin - 1 + int.Parse(dr["TuanThu"].ToString()), (CellStyle)htbCellStyle["MyCellStyleGiaoVien"]);
                    rg = fg.GetCellRange(row, ColBegin - 1 + int.Parse(dr["TuanThu"].ToString()), row, ColBegin - 1 + int.Parse(dr["TuanThu"].ToString()));
                    rg.UserData = ud;
                }
            }
        }

        private void FormatColorCell(int idxRow, int idxTuan, int DM_LopID)
        {
            DataView dvTemp = new DataView(dtToanTruong);
            dvTemp.RowFilter = "DM_LopID = " + DM_LopID.ToString() + " And IDXL_Tuan = " + dtTuan.Rows[idxTuan]["XL_TuanID"].ToString();
            CellRange rg = fg.GetCellRange(idxRow, indexCol);
            if (dvTemp.Count > 0)
            {
                CellData ud = new CellData();
                ud.BuoiHoc = "" + dvTemp[0]["CaHoc"] == "0" ? "Sáng" : ("" + dvTemp[0]["CaHoc"] == "1" ? "Chiều" : ("" + dvTemp[0]["CaHoc"] == "2" ? "Tối" : ""));
                ud.TenKeHoachKhac = "" + dvTemp[0]["TenKeHoachKhac"];
                ud.TenVietTat = "" + dvTemp[0]["TenVietTat"];
                ud.TenPhongHoc = "" + dvTemp[0]["TenPhongHoc"];

                rg.Data = dvTemp[0]["TenVietTat"].ToString();
                if ("" + dvTemp[0]["NgayNghi"] != "")
                {
                    if (dvTemp[0]["NgayNghi"].ToString() == "CaTuan")
                    {
                        ud.NgayNghi = "Cả tuần";
                        ud.SoNgayNghi = 7;
                    }
                    else
                    {
                        ud.NgayNghi = NgayNghiToString(dvTemp[0]["NgayNghi"].ToString());
                        ud.SoNgayNghi = dvTemp[0]["NgayNghi"].ToString().Split(',').Length;
                    }
                }
                rg.UserData = ud;

                mdtColor.DefaultView.RowFilter = "TenVietTat = '" + fg[idxRow, indexCol] + "'";
                // Nếu trên cell đã có dữ liệu kế hoạch khác thì gắn style cho cell đó
                if (mdtColor.DefaultView.Count > 0)
                {
                    fg.SetCellStyle(idxRow, indexCol, (CellStyle)htbCellStyle["MyCellStyle" + mdtColor.DefaultView[0]["XL_KeHoachKhacID"].ToString()]);
                }
                // Nếu Chưa có thì set style cho nó theo ca học
                else
                {
                    string CaHoc = dvTemp[0]["CaHoc"].ToString();
                    // SetCellStyle cho cell
                    if (CaHoc != "-1")
                        rg.Data = CaHoc == "0" ? "S" : (CaHoc == "1" ? "C" : (CaHoc == "2" ? "T" : ""));

                    fg.SetCellStyle(idxRow, indexCol, (CellStyle)htbCellStyle["MyCellStyle" + (CaHoc == "0" ? "Sang" :
                        (CaHoc == "1" ? "Chieu" : (CaHoc == "2" ? "Toi" : "")))]);
                }
            }
            indexCol++;
        }

        #region Tạo các cột trên grid
        private DataTable CreateTableChiTietGV()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TenLop", typeof(string));
            dt.Columns.Add("TenMonHoc", typeof(string));
            dt.Columns.Add("TongSoTiet", typeof(int));
            dt.Columns.Add("CaHoc", typeof(string));
            for (int i = 0; i < dtTuan.Rows.Count; i++)
            {
                dt.Columns.Add("T" + dtTuan.Rows[i]["XL_TuanID"].ToString(), typeof(int));
            }
            return dt;
        }

        private DataTable XuLydtChiTietGV(DataTable dtSource)
        {
            string IDXL_MonHocTrongKy, IDDM_Lop;
            int TongSoTiet = 0;
            DataTable dt = CreateTableChiTietGV();
            DataRow drNew;
            IDXL_MonHocTrongKy = dtSource.Rows[0]["IDXL_MonHocTrongKy"].ToString();
            IDDM_Lop = dtSource.Rows[0]["IDDM_Lop"].ToString();

            drNew = dt.NewRow();
            drNew["TenLop"] = dtSource.Rows[0]["TenLop"].ToString();
            drNew["TenMonHoc"] = dtSource.Rows[0]["TenMonHoc"].ToString();

            foreach (DataRow dr in dtSource.Rows)
            {
                if (IDXL_MonHocTrongKy != dr["IDXL_MonHocTrongKy"].ToString() || IDDM_Lop != dr["IDDM_Lop"].ToString())
                {
                    drNew["TongSoTiet"] = TongSoTiet;
                    dt.Rows.Add(drNew);
                    IDXL_MonHocTrongKy = dr["IDXL_MonHocTrongKy"].ToString();
                    IDDM_Lop = dr["IDDM_Lop"].ToString();
                    TongSoTiet = 0;

                    drNew = dt.NewRow();
                    drNew["TenLop"] = dr["TenLop"].ToString();
                    drNew["TenMonHoc"] = dr["TenMonHoc"].ToString();
                    drNew["T" + dr["IDXL_Tuan"]] = int.Parse(dr["SoTiet"].ToString());
                    TongSoTiet += int.Parse(dr["SoTiet"].ToString());
                }
                else
                {
                    drNew["T" + dr["IDXL_Tuan"]] = int.Parse(dr["SoTiet"].ToString());
                    TongSoTiet += int.Parse(dr["SoTiet"].ToString());
                }
            }
            drNew["TongSoTiet"] = TongSoTiet;
            dt.Rows.Add(drNew);
            dt.AcceptChanges();
            return dt;
        }

        BandedGridColumn bgc;
        private void AddBands()
        {
            int IDTuan, HocKy, TuanThu, widthKy1 = 0, widthKy2 = 0;
            try
            {
                for (int i = 0; i < dtTuan.Rows.Count; i++)
                {
                    IDTuan = int.Parse(dtTuan.Rows[i]["XL_TuanID"].ToString());
                    TuanThu = int.Parse(dtTuan.Rows[i]["TuanThu"].ToString());
                    HocKy = int.Parse(dtTuan.Rows[i]["HocKy"].ToString());

                    if (HocKy == 1)
                    {
                        bgc = new BandedGridColumn();
                        bgc.Name = "T" + IDTuan.ToString();
                        bgc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                        grbKy1.Columns.Add(bgc);
                        SetColumnBandCaption(bgc, "T" + TuanThu.ToString(), "T" + IDTuan.ToString(), colWidth, DevExpress.Utils.HorzAlignment.Center, true);
                        bgrvGiaoVien.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgc });

                        widthKy1 += colWidth;
                    }
                    else
                    {
                        bgc = new BandedGridColumn();
                        bgc.Name = "T" + IDTuan.ToString();
                        bgc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                        grbKy2.Columns.Add(bgc);
                        SetColumnBandCaption(bgc, "T" + TuanThu.ToString(), "T" + IDTuan.ToString(), colWidth, DevExpress.Utils.HorzAlignment.Center, true);
                        bgrvGiaoVien.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgc });

                        widthKy2 += colWidth;
                    }
                }

                SetBandCaption(grbKy1, "Học kỳ 1", widthKy1);
                SetBandCaption(grbKy2, "Học kỳ 2", widthKy2);
            }
            catch (Exception ex)
            {
                ThongBao(ex.Message);
            }
        }

        //private void AddTuan(long XL_TuanID, int Thang, int TuanThu, DateTime NgayDau, DateTime NgayCuoi)
        //{
        //    grbTuan = new GridBand();
        //    grbTuan.Name = "Tuan" + XL_TuanID.ToString();
        //    grbThang.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { grbTuan });
        //    SetBandCaption(grbTuan, "T " + TuanThu.ToString(), widthTuan);

        //    bgc = new BandedGridColumn();
        //    bgc.Name = "T" + XL_TuanID.ToString();
        //    bgc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
        //    grbKy1.Columns.Add(bgc);
        //    SetColumnBandCaption(bgc, NgayDau.Day.ToString() + "-" + NgayCuoi.Day.ToString(), "T" + XL_TuanID.ToString(), widthTuan, DevExpress.Utils.HorzAlignment.Center);
        //    bgrvGiaoVien.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgc });
        //}
        #endregion

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IDDM_Lop", typeof(int));
            dt.Columns.Add("TenLop", typeof(string));
            dt.Columns.Add("SoSinhVien", typeof(int));
            dt.Columns.Add("TenMonHoc", typeof(string));

            for (int i = 0; i < dtTuan.Rows.Count; i++)
            {
                dt.Columns.Add("T" + dtTuan.Rows[i]["XL_TuanID"].ToString(), typeof(string));
            }
            return dt;
        }

        #region FormatGrid
        private void FormatGrid()
        {
            //Setting Flexgrid
            fg.AllowSorting = AllowSortingEnum.None;
            fg.Cols.Fixed = ColBegin;
            fg.Rows.Fixed = 5;
            fg.Rows.DefaultSize = rowHeight;

            fg.Rows[2].Caption = "Kỳ";

            //Set rows width 
            fg.Rows[0].Height = 0;
            fg.Rows[1].Height = 20;
            fg.Rows[2].Height = 20;
            fg.Rows[3].Height = 20;
            fg.Rows[4].Height = 25;
            //Set columns width
            fg.Cols[0].Width = 0;
            //Dia chi row cua lop
            fg.Cols[1].Width = 0;
            //ID_mon
            fg.Cols[2].Width = 25;
            //hoc ky
            fg.Cols[3].Width = 200;
            //Ten mon
            fg.Cols[4].Width = 25;
            //So don vi hoc trinh
            //fg.Cols[5].Width = 25;
            ////Thuc_hanh
            fg.Cols[5].Width = 25;
            //So tiết
            fg.Cols[6].Width = 25;
            //So tiet con
            fg.Cols[7].Visible = false;
            fg.Cols[8].Visible = false;

            fg.Cols[2].AllowMerging = true;
            fg.Cols[3].AllowMerging = true;
            fg.Cols[4].AllowMerging = true;
            fg.Cols[5].AllowMerging = true;
            fg.Cols[6].AllowMerging = true;

            fg.Rows[1].AllowMerging = true;
            fg.Rows[2].AllowMerging = true;
            fg.Rows[3].AllowMerging = true;
            fg.Rows[4].AllowMerging = true;

            fg.AllowMerging = AllowMergingEnum.FixedOnly;

            fg.Cols[3].TextAlign = TextAlignEnum.LeftCenter;

            //Set Caption
            CellRange rg0 = fg.GetCellRange(1, 2, 4, 2);
            rg0.Data = "Kỳ";
            CellRange rg1 = fg.GetCellRange(1, 3, 4, 3);
            rg1.Data = "Tên lớp/Tên môn";
            CellRange rg5 = fg.GetCellRange(1, 4, 1, 6);
            rg5.Data = "Trong đó";
            CellRange rg2 = fg.GetCellRange(2, 4, 4, 4);
            rg2.Data = "SHT";
            CellRange rg4 = fg.GetCellRange(2, 5, 4, 5);
            rg4.Data = "ST";
            CellRange rg3 = fg.GetCellRange(2, 6, 4, 6);
            rg3.Data = "STC";
            //Load du lieu tieu de ke hoach
            FormatTieuDe(ColBegin, colWidth);
        }

        private void FormatTieuDe(int colBegin, int colWidth)
        {
            int IDTuan, HocKy, TuanThu;
            DateTime NgayDau, NgayCuoi;
            try
            {
                int Temp = colBegin;
                for (int i = 0; i < dtTuan.Rows.Count; i++)
                {
                    NgayDau = (DateTime)dtTuan.Rows[i]["TuNgay"];
                    NgayCuoi = (DateTime)dtTuan.Rows[i]["DenNgay"];
                    IDTuan = int.Parse(dtTuan.Rows[i]["XL_TuanID"].ToString());
                    TuanThu = int.Parse(dtTuan.Rows[i]["TuanThu"].ToString());
                    HocKy = int.Parse(dtTuan.Rows[i]["HocKy"].ToString());
                    fg[0, Temp] = IDTuan;
                    fg[1, Temp] = "Học kỳ " + HocKy.ToString();
                    fg[2, Temp] = "Tháng " + NgayDau.Month.ToString();
                    fg[3, Temp] = TuanThu;
                    fg[4, Temp] = NgayDau.Day.ToString() + " - " + NgayCuoi.Day.ToString();
                    fg.Cols[Temp].Width = colWidth;
                    fg.Cols[Temp].TextAlign = TextAlignEnum.CenterCenter;
                    Temp += 1;
                }
            }
            catch (Exception ex)
            {
                ThongBaoLoi(ex.Message);
            }
        }
        #endregion

        private void fg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                FillRange(int.Parse(e.KeyChar.ToString()));
            }
        }

        private void FillRange(int SoTiet)
        {
            CellRange rg = fg.Selection;
            int RowStart, ColStart;
            RowStart = rg.TopRow;
            ColStart = rg.LeftCol;
            if (RowStart < RowBegin)
                RowStart = RowBegin;
            if (ColStart < ColBegin)
                ColStart = ColBegin;
            for (int r = RowStart; r <= rg.BottomRow; r++)
            {
                for (int c = ColStart; c <= rg.RightCol; c++)
                {
                    SetCellKeHoach(r, c, SoTiet);
                }
            }
            TinhSoTietCon(RowStart, rg.BottomRow);
        }

        private void SetCellKeHoach(int row, int col, int SoTiet)
        {
            int TongSoTiet, SoTietNghi, SoTietLopDaChia, SoTietMonDaChia, SoTietCoTheThem = 0;
            string DiaChiLop = "" + fg[row, 0];
            if (DiaChiLop == "0" || DiaChiLop.IndexOf(",") >= 0)
                return;
            Cell_KeHoach ud;
            CellRange rg;
            SoTietNghi = SoTietNghiCell(int.Parse(DiaChiLop), col);
            if (SoTietNghi == -1)
                return;
            else
            {
                if ("" + fg[row, 2] != "")
                {
                    if (SoTiet > 0)
                    {
                        TongSoTiet = int.Parse("0" + fg[row, 5]);
                        SoTietLopDaChia = GetSoTietLopDaChia(int.Parse(DiaChiLop), col);
                        SoTietMonDaChia = GetSoTietMonDaChia(row, col);
                        if (SoTiet > TongSoTiet - SoTietMonDaChia && TongSoTiet - SoTietMonDaChia >= 0)
                            SoTiet = TongSoTiet - SoTietMonDaChia;

                        SoTietCoTheThem = int.Parse("0" + fg[row, 6]);

                        if (TongSoTiet <= SoTietMonDaChia)
                            SoTiet = 0;
                        else
                        {
                            if (SoTiet > (SoTietTuan - SoTietLopDaChia - SoTietNghi) && SoTietTuan - SoTietLopDaChia - SoTietNghi > 0)
                                SoTietCoTheThem = SoTietTuan - SoTietLopDaChia - SoTietNghi;
                            if (SoTietTuan - SoTietLopDaChia - SoTietNghi <= 0)
                                SoTietCoTheThem = 0;
                        }
                        if (SoTiet > 0)
                        {
                            rg = fg.GetCellRange(row, col, row, col);
                            ud = rg.UserData == null ? new Cell_KeHoach() : (Cell_KeHoach)rg.UserData;
                            if (SoTiet - ud.SoTiet <= SoTietCoTheThem)
                                ud.SoTiet = SoTiet;
                            else
                                ud.SoTiet += SoTietCoTheThem;

                            ud.LoaiTiet = 0;
                            if (ud.IDNS_GiaoVien <= 0)
                            {
                                string IDNS_GiaoVien = GetIDGiaoVienPhanCong(int.Parse(fg[row, 7].ToString()));
                                ud.IDNS_GiaoVien = IDNS_GiaoVien == "" ? 0 : 
                                    (IDNS_GiaoVien.IndexOf(",") > 0 ? int.Parse(IDNS_GiaoVien.Split(',')[0]) : int.Parse(IDNS_GiaoVien));
                                rg.Style = fg.Styles["MyCellStyleGiaoVien"];
                            }
                            ud.Changed = true;
                            rg.UserData = ud;
                            rg.Data = ud.SoTiet;
                        }
                    }
                }
            }
        }

        private string GetIDGiaoVienPhanCong(int IDXL_MonHocTrongKy)
        {
            DataTable dt = oBXL_PhanCongGiaoVien.GetByMonHocTrongKy(IDXL_MonHocTrongKy);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["IDNS_GiaoVien"].ToString();
            }
            return "";
        }

        private int GetSoTietLopDaChia(int DiaChiLop, int col)
        {
            int r = DiaChiLop + 1, SoTiet = 0;
            while (r < fg.Rows.Count && fg[r, 0].ToString().IndexOf("Tong") < 0)
            {
                SoTiet += int.Parse("0" + fg[r, col]);
                r++;
            } 
            return SoTiet;
        }

        private int GetSoTietMonDaChia(int row, int col)
        {
            CellRange rg;
            Cell_KeHoach ud;
            int SoTiet = 0;
            for (int i = ColBegin; i < fg.Cols.Count; i++)
            {
                rg = fg.GetCellRange(row, i);
                if (rg.UserData != null && i != col)
                {
                    ud = (Cell_KeHoach)rg.UserData;
                    SoTiet += ud.SoTiet;
                }
            }
            return SoTiet;
        }

        /// <summary>
        /// Hàm trả lại số tiết nghỉ trong tuần của lớp
        /// </summary>
        /// <param name="DiaChiLop"></param>
        /// <param name="col"></param>
        /// <returns>0: chia tiết thoải mái; -1: Không được chia tiết; khác: số tiết nghỉ trong tuần</returns>
        private int SoTietNghiCell(int DiaChiLop, int col)
        {
            CellRange rg = fg.GetCellRange(DiaChiLop, col);
            if (rg.UserData != null)
            {
                string str = "" + rg.Data;
                str = str.ToUpper();
                if (str == "" || str == "S" || str == "C" || str == "T")
                    return 0;
                else if (rg.UserData != null)
                {
                    CellData ud = (CellData)rg.UserData;
                    if (ud.SoNgayNghi == 7)
                        return -1;
                    else
                        return SoTietTuan / SoNgayTuan * ud.SoNgayNghi;
                }
            }
            return 0;
        }

        private void TinhSoTietCon(int TopRow, int BottomRow)
        {
            Cell_KeHoach ud;
            CellRange rg;
            int TongSoTiet, SoTietDaChia;
            // Tính số tiết còn của môn học.
            for (int r = TopRow; r <= BottomRow; r++)
            {
                if ("" + fg[r, 2] != "" && "0" + fg[r, 5] != "0" && ("" + fg[r, 0]).IndexOf("Tong") < 0)
                {
                    TongSoTiet = int.Parse("0" + fg[r, 5]);
                    SoTietDaChia = 0;
                    for (int c = ColBegin; c < fg.Cols.Count; c++)
                    {
                        rg = fg.GetCellRange(r, c);
                        if (rg.UserData != null)
                        {
                            ud = (Cell_KeHoach)rg.UserData;
                            SoTietDaChia += ud.SoTiet;
                        }
                    }
                    fg[r, 6] = Encode((TongSoTiet - SoTietDaChia).ToString(), r);
                }
            }
            // Tổng hợp theo tuần xem có bao nhiêu tiết mỗi tuần.
            int row = TopRow, RowLop, RowTongHop;
            while (row <= BottomRow)
            {
                if ("" + fg[row, 0] != "0" && ("" + fg[row, 0]).IndexOf("Tong") < 0)
                {
                    // Xác định row lớp
                    RowLop = int.Parse("" + fg[row, 0]);
                    // Tìm row tổng hợp
                    RowTongHop = RowLop;
                    while (RowTongHop < fg.Rows.Count)
                    {
                        RowTongHop++;
                        if (("" + fg[RowTongHop, 0]).IndexOf("Tong") >= 0)
                        {
                            row = RowTongHop + 2;
                            break;
                        }
                    }
                    for (int c = ColBegin; c < fg.Cols.Count; c++)
                    {
                        SoTietDaChia = 0;
                        for (int r = RowLop + 1; r < RowTongHop; r++)
                        {
                            rg = fg.GetCellRange(r, c);
                            if (rg.UserData != null)
                            {
                                ud = (Cell_KeHoach)rg.UserData;
                                SoTietDaChia += ud.SoTiet;
                            }
                        }
                        if (SoTietDaChia > 0)
                            fg[RowTongHop, c] = SoTietDaChia;
                        else
                            fg[RowTongHop, c] = "";
                    }
                }
                else
                    row++;
            }
        }

        private void XoaKeHoach()
        {
            Cell_KeHoach ud;
            CellRange rg, rg1 = fg.Selection;
            for (int r = rg1.TopRow; r <= rg1.BottomRow; r++)
            {
                for (int c = rg1.LeftCol; c <= rg1.RightCol; c++)
                {
                    if ("" + fg[r, 0] != "")
                    {
                        rg = fg.GetCellRange(r, c);
                        if (rg.UserData != null)
                        {
                            ud = (Cell_KeHoach)rg.UserData;
                            ud.SoTiet = 0;
                            ud.LoaiTiet = -1;
                            ud.IDNS_GiaoVien = 0;
                            ud.GhiChu = "";
                            ud.Changed = true;
                            rg.UserData = ud;
                            fg[r, c] = "";
                            fg.SetCellStyle(r, c, (CellStyle)htbCellStyle["MyCellStyle"]);
                        }
                    }
                }
            }
            TinhSoTietCon(rg1.TopRow, rg1.BottomRow);
        }

        private void fg_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                XoaKeHoach();
            }
        }

        private void fg_DoubleClick(object sender, EventArgs e)
        {
            barbtnSoTiet_ItemClick(null, null);
        }

        private void bartxtSoTietTuan_EditValueChanged(object sender, EventArgs e)
        {
            SoTietTuan = int.Parse("0" + bartxtSoTietTuan.EditValue);
        }

        private void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fg.Rows.Count > fg.Rows.Fixed)
            {
                int IDDM_Lop, DiaChiLop, IDXL_Tuan, IDXL_MonHocTrongKy;
                string IDDM_MonHoc;
                Cell_KeHoach ud;
                CellRange rg;
                for (int r = RowBegin; r < fg.Rows.Count; r++)
                {
                    if ("" + fg[r, 0] != "0" && ("" + fg[r, 0]).IndexOf("Tong") < 0)
                    {
                        DiaChiLop = int.Parse(fg[r, 0].ToString());
                        IDDM_Lop = int.Parse(fg[DiaChiLop, 1].ToString());
                        IDDM_MonHoc = fg[r, 1].ToString();
                        IDXL_MonHocTrongKy = int.Parse(fg[r, 7].ToString());
                        for (int c = ColBegin; c < fg.Cols.Count; c++)
                        {
                            pXL_KeHoachChiTietInfo = new XL_KeHoachChiTietInfo();
                            rg = fg.GetCellRange(r, c, r, c);
                            IDXL_Tuan = int.Parse(fg[0, c].ToString());
                            if (rg.UserData != null)
                            {
                                ud = (Cell_KeHoach)rg.UserData;
                                if (ud.Changed == true)
                                {
                                    // Nếu thay đổi trên kế hoạch chi tiết đã có thì xóa hoặc sửa
                                    if (ud.XL_KeHoachChiTietID > 0)
                                    {
                                        pXL_KeHoachChiTietInfo.XL_KeHoachChiTietID = ud.XL_KeHoachChiTietID;
                                        // Nếu số tiết <= 0 tức là cần phải xóa, ngược lại thì cập nhật
                                        if (ud.SoTiet <= 0)
                                        {
                                            oBXL_KeHoachChiTiet.Delete(pXL_KeHoachChiTietInfo);
                                            ud.XL_KeHoachChiTietID = -1;
                                        }
                                        else
                                        {
                                            pXL_KeHoachChiTietInfo.SoTiet = ud.SoTiet;
                                            pXL_KeHoachChiTietInfo.LoaiTiet = ud.LoaiTiet;
                                            pXL_KeHoachChiTietInfo.IDXL_MonHocTrongKy = IDXL_MonHocTrongKy;
                                            pXL_KeHoachChiTietInfo.IDDM_MonHoc = int.Parse(IDDM_MonHoc);
                                            pXL_KeHoachChiTietInfo.IDDM_Lop = IDDM_Lop;
                                            pXL_KeHoachChiTietInfo.IDNS_GiaoVien = ud.IDNS_GiaoVien;
                                            pXL_KeHoachChiTietInfo.IDXL_Tuan = IDXL_Tuan;
                                            pXL_KeHoachChiTietInfo.GhiChu = "" + ud.GhiChu;
                                            oBXL_KeHoachChiTiet.Update(pXL_KeHoachChiTietInfo);
                                        }
                                    }
                                    else
                                    {
                                        pXL_KeHoachChiTietInfo.SoTiet = ud.SoTiet;
                                        pXL_KeHoachChiTietInfo.LoaiTiet = ud.LoaiTiet;
                                        pXL_KeHoachChiTietInfo.IDXL_MonHocTrongKy = IDXL_MonHocTrongKy;
                                        pXL_KeHoachChiTietInfo.IDDM_MonHoc = int.Parse(IDDM_MonHoc);
                                        pXL_KeHoachChiTietInfo.IDDM_Lop = IDDM_Lop;
                                        pXL_KeHoachChiTietInfo.IDNS_GiaoVien = ud.IDNS_GiaoVien;
                                        pXL_KeHoachChiTietInfo.IDXL_Tuan = IDXL_Tuan;
                                        pXL_KeHoachChiTietInfo.GhiChu = "" + ud.GhiChu;

                                        ud.XL_KeHoachChiTietID = oBXL_KeHoachChiTiet.Add(pXL_KeHoachChiTietInfo);
                                    }
                                    // Sau khi cập nhật thì set lại giá trị của các Cell_KeHoach
                                    ud.Changed = false;
                                    rg.UserData = ud;
                                }
                            }
                        }
                    }
                }
                LuuThanhCong();
            }
            else
                ThongBao("Không có dữ liệu để lưu !");
        }

        private void fg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && fg.ClientRectangle.Contains(e.X, e.Y))
            {
                CellRange rg = fg.Selection;
                int row;
                if (rg.TopRow == rg.BottomRow)
                {
                    row = rg.TopRow;
                    if ("" + fg[row, 0] != "0" && ("" + fg[row, 0]).IndexOf("Tong") < 0)
                    {
                        popupMenu.ShowPopup(MousePosition);
                    }
                }
            }
        }

        private void barbtnNghi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barbtnGiaoVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CellRange rg=fg.Selection;
            int row = rg.TopRow;

            int DiaChiLop = int.Parse(fg[row, 0].ToString());
            pXL_KeHoachChiTietInfo.IDDM_Lop = int.Parse(fg[DiaChiLop, 1].ToString());
            pXL_KeHoachChiTietInfo.IDDM_MonHoc = int.Parse(fg[row, 1].ToString());
            pXL_KeHoachChiTietInfo.IDXL_MonHocTrongKy = int.Parse(fg[row, 7].ToString());
            dlgChonGiaoVien dlg = new dlgChonGiaoVien(this, pXL_KeHoachChiTietInfo, fg[DiaChiLop, 3].ToString(), fg[row, 3].ToString(), fg[row, 8].ToString());
            dlg.ShowDialog();
        }

        private void barbtnSoTiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgSoTietTuan dlg = new dlgSoTietTuan(SoTietFocus);
            if (dlg.ShowDialog() == DialogResult.OK)
                FillRange(int.Parse(dlg.txtSoTiet.Text));
        }

        private void fg_EnterCell(object sender, EventArgs e)
        {
            CellRange rg = fg.Selection;
            Cell_KeHoach ud;
            int row = fg.Row;
            if (fg.Row < RowBegin) return;
            if ("" + fg[row, 0] != "0" && ("" + fg[row, 0]).IndexOf("Tong") < 0)
            {
                rg = fg.GetCellRange(row, fg.Col, row, fg.Col);
                if (rg.UserData != null)
                {
                    ud = (Cell_KeHoach)rg.UserData;
                    SoTietFocus = ud.SoTiet;
                    if (ud.IDNS_GiaoVien > 0)
                    {
                        if (IDNS_GiaoVienChon != ud.IDNS_GiaoVien)
                        {
                            IDNS_GiaoVienChon = ud.IDNS_GiaoVien;
                            dockGiaoVien.Text = "Chi tiết giảng viên: " + ud.TenGiaoVien;
                            DataTable dt = oBXL_KeHoachChiTiet.GetChiTietGV(IDNS_GiaoVienChon, Program.IDNamHoc, Program.HocKy);
                            if (dt.Rows.Count > 0)
                                grdGiaoVien.DataSource = XuLydtChiTietGV(dt);
                        }
                    }
                    else
                    {
                        IDNS_GiaoVienChon = 0;
                        dockGiaoVien.Text = "Chi tiết giảng viên";
                        grdGiaoVien.DataSource = null;
                    }
                }
                else
                {
                    IDNS_GiaoVienChon = 0;
                    dockGiaoVien.Text = "Chi tiết giảng viên";
                    grdGiaoVien.DataSource = null;
                    SoTietFocus = 0;
                }
            }
        }

        private void fg_MouseEnterCell(object sender, RowColEventArgs e)
        {
            if (e.Row < RowBegin || e.Col < ColBegin) return;
            if ("" + fg[e.Row, 0] == "0")
            {
                CellRange rg = fg.GetCellRange(e.Row, e.Col);
                if (rg.UserData != null)
                {
                    CellData ud = (CellData)rg.UserData;
                    string strToolTip = "";
                    if (ud.BuoiHoc != "")
                        strToolTip = "Ca học: <color=Blue>" + ud.BuoiHoc;
                    if (ud.TenPhongHoc != "")
                        strToolTip += (strToolTip == "" ? "" : "<color=Black>, Phòng học: <color=Blue>") + ud.TenPhongHoc;
                    if (ud.TenKeHoachKhac != "")
                        strToolTip += (strToolTip == "" ? "" : "<br><color=Black>Kế hoạch khác: <color=Blue>" + 
                            ud.TenKeHoachKhac + "<br><color=Black>Ngày thực hiện: <color=Blue>" + ud.NgayNghi);
                    toolTipController.ShowHint(strToolTip, "Kế hoạch lớp");
                }
            }
        }

        private void fg_MouseLeaveCell(object sender, RowColEventArgs e)
        {
            toolTipController.HideHint();
        }

        private void barbtnXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportFlexGridToXls(fg);
        }
    }
}