using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;
using System.Collections;
using DevExpress.XtraEditors;
using System.Reflection;

namespace UnimOs.UI
{
    public partial class frmKeHoachToanTruong : frmBase
    {
        #region "Khai báo các biến"
        // Định nghĩa kiểu cấu trúc của phần hiển thị trên grid
        protected struct CellData
        {
            public int KeHoachTruongID;
            public int IDPhongHoc;
            public string TenPhongHoc;
            public int BuoiHoc;
            public int IDKeHoachKhac;
            public string TenKeHoachKhac;
            public string TenVietTat;
            public string NgayNghi;
            //public DateTime dateDenNgay;
            public bool Changed;
        }

        private int RowHeight = 20, ColWidth = 45;
        private int RowBegin = 6, ColBegin = 5;
        //private bool HienThiNgay = true;
        DataTable dtKeHoach = new DataTable();
        DataTable dtTuan = new DataTable();
        cBDM_Lop oBLop = new cBDM_Lop();
        cBXL_KeHoachTruong oBKeHoachTruong;
        XL_KeHoachTruongInfo pKeHoachTruongInfo;
        // Khai báo biến xác định indexCol đang làm việc
        private int indexCol;
        //DataTable dtTemp;
        #endregion

        public frmKeHoachToanTruong()
        {
            InitializeComponent();
            oBKeHoachTruong = new cBXL_KeHoachTruong();
        }

        private void frmKeHoachToanTruong_Load(object sender, EventArgs e)
        {
            bar2.Visible = true;
            bar3.Visible = true;
            try
            {
                FlexColor(fg);
                fg.DataSource = null;
                cBXL_Tuan oBTuan = new cBXL_Tuan();
                XL_TuanInfo pTuanInfo = new XL_TuanInfo();
                pTuanInfo.IDDM_NamHoc = Program.IDNamHoc;
                dtTuan = oBTuan.GetByIDNamHoc(pTuanInfo);

                //barbtnOpen_ItemClick(null, null);
            }
            catch (Exception ex)
            {
                ThongBaoLoi(ex.Message);
            }
        }

        private void barbtnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgMoKeHoach dlg = new dlgMoKeHoach();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fg.DataSource = GetKeHoach(dlg.pDM_LopInfo);

                FormatGrid(fg);
                GanCotFix();

                FormatColorCell();
            }
        }

        #region Load kế hoạch
        /// <summary>
        /// Lấy kế hoạch năm học của toàn trường
        /// </summary>
        /// <param name="IDNamHoc"></param> Mỗi lần mở chương trình chỉ thao tác với dữ liệu của một năm nào đó
        /// <param name="IDLops"></param> Danh sách các lớp mà người đó được phân quyền
        /// <returns></returns>
        public DataTable GetKeHoach(DM_LopInfo pDM_LopInfo)
        {
            DataTable dt = new DataTable();
            //string strNgay;
            //int SoNgay = 0, SoNgayTuan = 0;
            string IDLop = "";
            if (dt.Columns.Contains("C" + dtTuan.Rows[0]["XL_TuanID"].ToString()) == false)
            {
                dt.Columns.Add("IDDM_Lop");
                dt.Columns.Add("TenLop");
                dt.Columns.Add("SoSinhVien");
                for (int i = 0; i < dtTuan.Rows.Count; i++)
                {
                    dt.Columns.Add("C" + dtTuan.Rows[i]["XL_TuanID"].ToString());
                }
            }
            // Lấy ra danh sách các lớp đang hoạt động trong năm học đó để lập kế hoạch
            dtKeHoach = oBLop.GetKeHoachToanTruong(Program.IDNamHoc, Program.NamHoc, pDM_LopInfo);
            if (dtKeHoach.Rows.Count > 0)
            {
                DataRow drNew;
                int rowIndex = -1;
                foreach (DataRow dr in dtKeHoach.Rows)
                {
                    // Phần dữ liệu trong dtKeHoach đã được sắp xếp theo lớp
                    // Khi IDLop thay đổi thì phải tạo ra 1 row mới để gắn dữ liệu vào
                    if (dr["DM_LopID"].ToString() != IDLop)
                    {
                        drNew = dt.NewRow();
                        dt.Rows.Add(drNew);
                        IDLop = dr["DM_LopID"].ToString();
                        rowIndex += 1;
                        dt.Rows[rowIndex]["IDDM_Lop"] = IDLop;
                        dt.Rows[rowIndex]["TenLop"] = dr["TenLop"].ToString();
                        dt.Rows[rowIndex]["SoSinhVien"] = dr["SoSinhVien"].ToString();
                        if (dr["CaHoc"].ToString() != "")
                        {
                            if ("" + dr["IDXL_Tuan"] != "")
                                dt.Rows[rowIndex]["C" + dr["IDXL_Tuan"]] = dr["CaHoc"].ToString() == "0" ? "S" :
                                    dr["CaHoc"].ToString() == "1" ? "C" : dr["CaHoc"].ToString() == "2" ? "T" : "";
                        }
                    }

                    if (dr["NgayNghi"].ToString() != "")
                    {
                        if (dr["IDXL_KeHoachKhac"].ToString() != "")
                        {
                            dt.Rows[rowIndex]["C" + dr["IDXL_Tuan"]] = dr["TenVietTat"].ToString();
                        }
                    }
                    else
                    {
                        if (dr["CaHoc"].ToString() != "")
                        {
                            if ("" + dr["IDXL_Tuan"] != "")
                                dt.Rows[rowIndex]["C" + dr["IDXL_Tuan"]] = dr["CaHoc"].ToString() == "0" ? "S" :
                                    dr["CaHoc"].ToString() == "1" ? "C" : dr["CaHoc"].ToString() == "2" ? "T" : "";
                        }
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// Gán các cột được fix với các giá trị về tên lớp và số học sinh của lớp đó
        /// </summary>
        private void GanCotFix()
        {
            Lib.clsDataTableHelper cls = new Lib.clsDataTableHelper();
            DataTable dtLop = cls.SelectDistinct(dtKeHoach, new string[] { "DM_LopID", "TenLop", "SoSinhVien" });
            DataRow[] arrDr;
            fg.Cols[0].TextAlign = TextAlignEnum.LeftCenter;
            for (int i = RowBegin; i < fg.Rows.Count; i++)
            {
                arrDr = dtLop.Select("DM_LopID = " + fg[i, "IDDM_Lop"]);
                fg[i, 0] = arrDr[0]["TenLop"].ToString();
                fg[i, 1] = EncodeString(arrDr[0]["SoSinhVien"].ToString(), i);
            }
        }

        private void FormatColorCell()
        {
            int IDDM_Lop;
            for (int i = RowBegin; i <= fg.Rows.Count - 1; i++)
            {
                IDDM_Lop = int.Parse(fg[i, "IDDM_Lop"].ToString());
                indexCol = ColBegin;
                for (int j = 0; j <= dtTuan.Rows.Count - 1; j++)
                {
                    DataTable dtTemp = dtKeHoach.Copy();
                    dtTemp.DefaultView.RowFilter = "DM_LopID = " + IDDM_Lop.ToString() + " And IDXL_Tuan = " + dtTuan.Rows[j]["XL_TuanID"].ToString();
                    CellRange rg = fg.GetCellRange(i, indexCol);
                    CellData objCellData = new CellData();
                    if (!(fg[i, indexCol] == System.DBNull.Value))
                    {
                        mdtColor.DefaultView.RowFilter = "TenVietTat = '" + fg[i, indexCol].ToString() + "'";
                        if (dtTemp.DefaultView.Count > 0)
                        {
                            // Nếu ngày đang xét nằm trong khoảng có kế hoạch khác của tuần thì set IDKeHoachKhac cho ngày đó
                            for (int k = 0; k < dtTemp.DefaultView.Count; k++)
                            {
                                objCellData.NgayNghi = "" + dtTemp.DefaultView[k]["NgayNghi"];
                                //objCellData.dateDenNgay = (DateTime)dtTemp.DefaultView[k]["DenNgay"];
                                objCellData.KeHoachTruongID = int.Parse(dtTemp.DefaultView[k]["XL_KeHoachTruongID"].ToString());
                                objCellData.IDKeHoachKhac = int.Parse(dtTemp.DefaultView[k]["IDXL_KeHoachKhac"].ToString());
                                objCellData.TenKeHoachKhac = dtTemp.DefaultView[k]["TenKeHoachKhac"].ToString();
                                objCellData.TenVietTat = dtTemp.DefaultView[k]["TenVietTat"].ToString();
                                objCellData.BuoiHoc = dtTemp.DefaultView[0]["CaHoc"] == System.DBNull.Value ? -1 : int.Parse(dtTemp.DefaultView[0]["CaHoc"].ToString());
                                objCellData.IDPhongHoc = dtTemp.DefaultView[0]["IDDM_PhongHoc"] == System.DBNull.Value ? 0 : int.Parse(dtTemp.DefaultView[0]["IDDM_PhongHoc"].ToString());
                                objCellData.TenPhongHoc = dtTemp.DefaultView[0]["TenPhongHoc"].ToString();
                            }
                            //rg.Data = objCellData.TenVietTat;
                        }
                        // Nếu trên cell đã có dữ liệu kế hoạch khác thì gắn style cho cell đó
                        if (mdtColor.DefaultView.Count > 0)
                        {
                            //objCellData.BuoiHoc = dtKeHoach.DefaultView[0]["BuoiHoc"] == System.DBNull.Value ? -1 : int.Parse(dtKeHoach.DefaultView[0]["BuoiHoc"].ToString());
                            fg.SetCellStyle(i, indexCol, (CellStyle)htbCellStyle["MyCellStyle" + mdtColor.DefaultView[0]["XL_KeHoachKhacID"].ToString()]);
                        }
                        else
                        {
                            // Nếu Chưa có thì set style cho nó
                            if (dtTemp.DefaultView.Count > 0)
                            {
                                objCellData.BuoiHoc = dtTemp.DefaultView[0]["CaHoc"] == System.DBNull.Value ? -1 : int.Parse(dtTemp.DefaultView[0]["CaHoc"].ToString());
                                objCellData.IDPhongHoc = dtTemp.DefaultView[0]["IDDM_PhongHoc"] == System.DBNull.Value ? 0 : int.Parse(dtTemp.DefaultView[0]["IDDM_PhongHoc"].ToString());
                                objCellData.TenPhongHoc = dtTemp.DefaultView[0]["TenPhongHoc"].ToString();
                            }
                            else
                            {
                                DataTable dtTemp1 = dtKeHoach.Copy();
                                dtTemp1.DefaultView.RowFilter = "DM_LopID = " + IDDM_Lop.ToString();
                                objCellData.BuoiHoc = dtTemp1.DefaultView[0]["CaHoc"] == System.DBNull.Value ? -1 : int.Parse(dtTemp1.DefaultView[0]["CaHoc"].ToString());
                                objCellData.IDPhongHoc = dtTemp1.DefaultView[0]["IDDM_PhongHoc"] == System.DBNull.Value ? 0 : (int)dtTemp1.DefaultView[0]["IDDM_PhongHoc"];
                                objCellData.TenPhongHoc = dtTemp1.DefaultView[0]["TenPhongHoc"].ToString();
                                objCellData.NgayNghi = "" + dtTemp1.DefaultView[0]["NgayNghi"];
                            }
                            // SetCellStyle cho cell
                            fg.SetCellStyle(i, indexCol, (CellStyle)htbCellStyle["MyCellStyle" + (objCellData.BuoiHoc == 0 ? "Sang" : (objCellData.BuoiHoc == 1 ? "Chieu" : (objCellData.BuoiHoc == 2 ? "Toi" : "")))]);
                            if ("" + fg[i, indexCol] != "")
                                fg[i, indexCol] = EncodeCaHoc(fg[i, indexCol].ToString(), indexCol);
                        }
                    }
                    rg.UserData = objCellData;
                    indexCol++;
                }
            }
        }
        #endregion

        #region "Format Grid"
        private void FormatTieuDe(C1FlexGrid fg, int colBegin, int colWidth, bool ShowThang, bool ShowTuan, bool ShowNgay)
        {
            cBXL_Tuan oBTuan = new cBXL_Tuan();
            XL_TuanInfo pTuanInfo = new XL_TuanInfo();
            pTuanInfo.IDDM_NamHoc = Program.IDNamHoc;
            DataTable dtTuan = oBTuan.GetByIDNamHoc(pTuanInfo);
            int IDTuan, HocKy, TuanThu;
            DateTime NgayDau, NgayCuoi;
            try
            {
                string HocCaChuNhat = new cBHT_ThamSoHeThong().GetGiaTriByMaThamSo("HocCaChuNhat").Trim();
                int Temp = colBegin;

                for (int i = 0; i < dtTuan.Rows.Count; i++)
                {
                    NgayDau = (DateTime)dtTuan.Rows[i]["TuNgay"];
                    NgayCuoi = (DateTime)dtTuan.Rows[i]["DenNgay"];
                    IDTuan = int.Parse(dtTuan.Rows[i]["XL_TuanID"].ToString());
                    TuanThu = int.Parse(dtTuan.Rows[i]["TuanThu"].ToString());
                    HocKy = int.Parse(dtTuan.Rows[i]["HocKy"].ToString());
                    //SoNgayTuan = NgayCuoi.Subtract(NgayDau).Days;
                    //for (int j = 0; j <= SoNgayTuan; j++)
                    //{
                    //fg.Cols.Add(1);
                    //NgayHienTai = NgayDau.AddDays(j);
                    fg[0, Temp] = IDTuan;
                    fg[1, Temp] = "Học kỳ " + HocKy.ToString();
                    fg[2, Temp] = "Tháng " + NgayDau.Month.ToString();
                    fg[3, Temp] = TuanThu;
                    if (HocCaChuNhat == "0" && NgayCuoi.DayOfWeek == DayOfWeek.Sunday)
                        fg[4, Temp] = NgayDau.Day.ToString() + " - " + NgayCuoi.AddDays(-1).Day.ToString();
                    else
                        fg[4, Temp] = NgayDau.Day.ToString() + " - " + NgayCuoi.Day.ToString();
                    //fg[5, Temp] = NgayHienTai.Day.ToString();
                    fg[5, Temp] = "C" + dtTuan.Rows[i]["XL_TuanID"].ToString();
                    fg.Cols[Temp].Width = colWidth;
                    fg.Cols[Temp].TextAlign = TextAlignEnum.CenterCenter;
                    Temp += 1;
                    //}
                    //Temp += 1;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "THÔNG BÁO LỖI");
            }
        }

        private void FormatGrid(C1FlexGrid fg)
        {
            //fg.Cols.Add(5);
            fg.AllowSorting = AllowSortingEnum.None;
            fg.Cols.Fixed = 2;
            fg.Rows.Fixed = RowBegin;
            fg.Rows.DefaultSize = RowHeight;

            //Set rows width 
            // Hàng IDTuan
            fg.Rows[0].Visible = false;
            // Hàng Học kỳ
            fg.Rows[1].Height = 20;
            // Hàng Tháng
            fg.Rows[2].Height = 20;
            // Hàng Tuần thứ
            fg.Rows[3].Height = 20;
            // Hàng Từ ngày đến ngày
            fg.Rows[4].Height = 35;
            // Hàng oBBase.DateToInt
            fg.Rows[5].Visible = false;

            fg.Rows[1].AllowMerging = true;
            fg.Rows[2].AllowMerging = true;
            fg.Rows[3].AllowMerging = true;
            fg.Rows[4].AllowMerging = true;
            //fg.Rows[5].AllowMerging = true;
            //Set columns width 
            fg.Cols[0].Width = 100;
            fg.Cols[1].Width = 50;
            //fg.Cols[2].Width = 0;
            //fg.Cols[3].Width = 0;
            //fg.Cols[4].Width = 0;
            fg.Cols[2].Visible = false;
            fg.Cols[3].Visible = false;
            fg.Cols[4].Visible = false;

            //fg.Cols[1].TextAlign = TextAlignEnum.LeftCenter;
            fg.Cols[0].AllowMerging = true;
            fg.Cols[1].AllowMerging = true;
            fg.AllowMerging = AllowMergingEnum.FixedOnly;
            //fg.AllowMerging = AllowMergingEnum.RestrictCols;
            for (int i = fg.Rows.Fixed; i <= fg.Rows.Count - 1; i++)
            {
                fg.Rows[i].AllowMerging = true;
            }
            //Set Caption
            CellRange rg = fg.GetCellRange(1, 0, 5, 0);
            rg.Data = "Tên lớp";
            CellRange rg1 = fg.GetCellRange(1, 1, 5, 1);
            rg1.Data = "Số sinh viên";

            FormatTieuDe(fg, ColBegin, ColWidth, false, false, true);
        }

        private void DeleteKeHoachOnGrid()
        {
            int rowStart, rowEnd, colStart, colEnd;
            CellRange rg = fg.Selection;
            rowStart = rg.TopRow;
            rowEnd = rg.BottomRow;
            colStart = rg.LeftCol;
            colEnd = rg.RightCol;
            // Kiểm tra xem các dữ liệu fixed
            if (colStart < ColBegin)
                colStart = ColBegin;
            if (rowStart < RowBegin)
                rowStart = RowBegin;
            DeleteKeHoachOnGrid(rowStart, colStart, rowEnd, colEnd);
        }

        private void DisplayBuoiHocOnGrid(int BuoiHoc)
        {
            int rowStart, rowEnd, colStart, colEnd;
            //DateTime dateValue;
            CellRange rg = fg.Selection;
            rowStart = rg.TopRow;
            rowEnd = rg.BottomRow;
            colStart = rg.LeftCol;
            colEnd = rg.RightCol;
            // Kiểm tra xem các dữ liệu fixed
            if (colStart < ColBegin)
                colStart = ColBegin;
            if (rowStart < RowBegin)
                rowStart = RowBegin;
            for (int r = rowStart; r <= rowEnd; r++)
            {
                for (int c = colStart; c <= colEnd; c++)
                {
                    // Nếu chưa có kế hoạch nghỉ thì mới bố trí ca học
                    if (fg[r, c] == System.DBNull.Value || fg[r, c].ToString() == "")
                    {
                        ShowBuoiHoc(r, c, BuoiHoc);
                    }
                    else if (fg[r, c].ToString().Trim() == "S" || fg[r, c].ToString().Trim() == "C" ||
                        fg[r, c].ToString().Trim() == "T")
                    {
                        ShowBuoiHoc(r, c, BuoiHoc);
                    }
                    else
                    {
                        CellRange rg1 = fg.GetCellRange(r, c, r, c);
                        CellData objCellData = (CellData)rg.UserData;
                        objCellData.BuoiHoc = BuoiHoc;
                        objCellData.Changed = true;
                        rg1.UserData = objCellData;
                    }
                }
            }
        }

        private void ShowBuoiHoc(int r, int c, int BuoiHoc)
        {
            CellRange rg = fg.GetCellRange(r, c, r, c);
            CellData objCellData = (CellData)rg.UserData;
            objCellData.BuoiHoc = BuoiHoc;
            rg.Style = (CellStyle)htbCellStyle["MyCellStyle" + (BuoiHoc == 0 ? "Sang" : (BuoiHoc == 1 ? "Chieu" : "Toi"))];
            objCellData.Changed = true;
            rg.UserData = objCellData;
            rg.Data = EncodeCaHoc((BuoiHoc == 0 ? "S" : (BuoiHoc == 1 ? "C" : "T")), c);
        }

        private void DisplayKeHoachOnGrid(int KeHoachTruongID, int IDKeHoachKhac, string TenKeHoachKhac, string TenVietTat, string NgayNghi, int rowStart, int colStart, int rowEnd, int colEnd)
        {
            for (int r = rowStart; r <= rowEnd; r++)
            {
                for (int c = colStart; c <= colEnd; c++)
                {
                    ShowHoatDong(r, c, KeHoachTruongID, IDKeHoachKhac, TenKeHoachKhac, TenVietTat, NgayNghi);
                }
            }
        }

        private void DeleteKeHoachOnGrid(int rowStart, int colStart, int rowEnd, int colEnd)
        {
            // Thực hiện xóa kế hoạch
            CellRange rgDel;
            CellData oCellDelete;
            for (int r = rowStart; r <= rowEnd; r++)
            {
                for (int c = colStart; c <= colEnd; c++)
                {
                    rgDel = fg.GetCellRange(r, c);
                    oCellDelete = (CellData)rgDel.UserData;

                    oCellDelete.IDKeHoachKhac = -1;
                    oCellDelete.TenKeHoachKhac = "";
                    oCellDelete.TenVietTat = "";
                    oCellDelete.NgayNghi = "";

                    rgDel.Style = (CellStyle)htbCellStyle["MyCellStyle"];
                    rgDel.Data = "";
                    oCellDelete.Changed = true;
                    rgDel.UserData = oCellDelete;
                }
            }
        }

        //private void DeleteHoatDong(int r, int c)
        //{
        //    CellRange rgDel = fg.GetCellRange(r, c, r, c);
        //    CellData oCellDelete = (CellData)rgDel.UserData;
        //    // Nếu Từ ngày của sk mới trùng với từ ngày của sk cũ đang xét thì xem lại sk
        //    if (oCellDelete.KeHoachTruongID > 0 || oCellDelete.IDKeHoachKhac > 0)
        //    {
        //        DateTime currDate;
        //        int SubDate = 0;
        //        if (objTuNgay.Date <= oCellDelete.dateTuNgay.Date && objDenNgay.Date < oCellDelete.dateDenNgay.Date)
        //        {
        //            currDate = StringToDate(fg[6, c].ToString().Substring(1), fg[2, c].ToString());
        //            if (objDenNgay.Date == currDate)
        //            {
        //                ShowHoatDong(r, c + 1, -1, oCellDelete.IDKeHoachKhac, oCellDelete.TenKeHoachKhac, oCellDelete.TenVietTat, objDenNgay.AddDays(1), oCellDelete.dateDenNgay);
        //            }
        //        }
        //        else if (objTuNgay.Date > oCellDelete.dateTuNgay.Date && objDenNgay.Date < oCellDelete.dateDenNgay.Date)
        //        {
        //            currDate = StringToDate(fg[6, c].ToString().Substring(1), fg[2, c].ToString());
        //            if (objTuNgay.Date == currDate)
        //            {
        //                SubDate = objTuNgay.Date.Subtract(oCellDelete.dateTuNgay.Date).Days;
        //                ShowHoatDong(r, c - SubDate, -1, oCellDelete.IDKeHoachKhac, oCellDelete.TenKeHoachKhac, oCellDelete.TenVietTat, oCellDelete.dateTuNgay, objTuNgay.AddDays(-1));
        //            }
        //            else if (objDenNgay.Date == currDate)
        //            {
        //                ShowHoatDong(r, c + 1, -1, oCellDelete.IDKeHoachKhac, oCellDelete.TenKeHoachKhac, oCellDelete.TenVietTat, objDenNgay.AddDays(1), oCellDelete.dateDenNgay);
        //            }
        //        }
        //        else if (objTuNgay.Date > oCellDelete.dateTuNgay.Date && objTuNgay.Date < oCellDelete.dateDenNgay.Date && objDenNgay.Date >= oCellDelete.dateDenNgay.Date)
        //        {
        //            currDate = StringToDate(fg[6, c].ToString().Substring(1), fg[2, c].ToString());
        //            if (objTuNgay.Date == currDate)
        //            {
        //                SubDate = objTuNgay.Date.Subtract(oCellDelete.dateTuNgay.Date).Days;
        //                ShowHoatDong(r, c - SubDate, -1, oCellDelete.IDKeHoachKhac, oCellDelete.TenKeHoachKhac, oCellDelete.TenVietTat, oCellDelete.dateTuNgay, objTuNgay.AddDays(-1));
        //            }
        //        }
        //    }
        //    // Thực hiện xóa kế hoạch
        //    oCellDelete.IDKeHoachKhac = -1;
        //    oCellDelete.TenKeHoachKhac = "";
        //    oCellDelete.TenVietTat = "";
        //    oCellDelete.dateTuNgay = objTuNgay;
        //    oCellDelete.dateDenNgay = objDenNgay;
        //    if ((oCellDelete.BuoiHoc >= 0) && (StringToDate(fg[6, c].ToString().Substring(1), fg[2, c].ToString()).DayOfWeek != DayOfWeek.Sunday))
        //    {
        //        rgDel.Style = (CellStyle)htbCellStyle["MyCellStyle" + (oCellDelete.BuoiHoc == 0 ? "Sang" : (oCellDelete.BuoiHoc == 1 ? "Chieu" : "Toi"))];
        //        rgDel.Data = (oCellDelete.BuoiHoc == 0 ? "S" : (oCellDelete.BuoiHoc == 1 ? "C" : "T"));
        //    }
        //    else
        //    {
        //        rgDel.Style = (CellStyle)htbCellStyle["MyCellStyle"];
        //        rgDel.Data = "";
        //    }
        //    oCellDelete.Changed = true;
        //    rgDel.UserData = oCellDelete;
        //}

        private void ShowHoatDong(int r, int c, int KeHoachTruongID, int IDKeHoachKhac, string TenKeHoachKhac, string TenVietTat, string NgayNghi)
        {
            CellRange rg = fg.GetCellRange(r, c, r, c);
            CellData objCellData = (CellData)rg.UserData;

            if (KeHoachTruongID != 0)
                objCellData.KeHoachTruongID = KeHoachTruongID;
            objCellData.IDKeHoachKhac = IDKeHoachKhac;
            objCellData.TenKeHoachKhac = TenKeHoachKhac;
            objCellData.TenVietTat = TenVietTat;
            objCellData.NgayNghi = NgayNghi;
            if (IDKeHoachKhac > 0)
            {
                rg.Style = (CellStyle)htbCellStyle["MyCellStyle" + IDKeHoachKhac.ToString()];
                rg.Data = TenVietTat;
            }
            else if ((objCellData.BuoiHoc >= 0) && (StringToDate(fg[6, c].ToString().Substring(1), fg[2, c].ToString()).DayOfWeek != DayOfWeek.Sunday))
            {
                rg.Style = (CellStyle)htbCellStyle["MyCellStyle" + (objCellData.BuoiHoc == 0 ? "Sang" : (objCellData.BuoiHoc == 1 ? "Chieu" : "Toi"))];
                rg.Data = (objCellData.BuoiHoc == 0 ? "S" : (objCellData.BuoiHoc == 1 ? "C" : "T"));
            }
            else
            {
                rg.Style = (CellStyle)htbCellStyle["MyCellStyle"];
                rg.Data = "";
            }
            objCellData.Changed = true;
            rg.UserData = objCellData;
        }
        #endregion

        #region "Lưu kế hoạch"
        private void LuuKeHoach()
        {
            int IDTuan, currentIDTuan, c, IDDM_Lop;
            for (int r = RowBegin; r <= fg.Rows.Count - 1; r++)
            {
                IDDM_Lop = int.Parse(fg[r, "IDDM_Lop"].ToString());
                IDTuan = int.Parse(fg[0, ColBegin].ToString());
                dtTuan.DefaultView.RowFilter = "XL_TuanID = " + IDTuan.ToString();
                c = ColBegin;
                while (c <= fg.Cols.Count - 1)
                {
                    CellRange rg = fg.GetCellRange(r, c, r, c);
                    CellData objCellData = (CellData)rg.UserData;
                    currentIDTuan = int.Parse(fg[0, c].ToString());
                    // Nếu vẫn là tuần đang xét thì sẽ lấy dữ liệu
                    if (IDTuan != currentIDTuan)
                    {
                        IDTuan = currentIDTuan;
                        dtTuan.DefaultView.RowFilter = "XL_TuanID = " + IDTuan.ToString();
                    }
                    if (rg.UserData != null)
                    {
                        if (objCellData.IDKeHoachKhac == -1)
                        {
                            if (objCellData.KeHoachTruongID > 0)
                            {
                                DeleteKeHoachTruongTuan(objCellData.KeHoachTruongID);
                            }
                        }
                        else
                        {
                            if (objCellData.Changed)
                            {
                                // Nếu có sự thay đổi trong kế hoạch và từ ca học -> nghỉ hoặc từ nghỉ -> ca học hoặc nghỉ -> nghỉ khác
                                // Từ nghỉ -> nghỉ khác thì update vào
                                if (objCellData.KeHoachTruongID > 0)
                                {
                                    // Nếu được thay thế bởi Kế hoạch nghỉ khác thì update
                                    //if (objCellData.IDKeHoachKhac > 0)
                                    //{
                                    pKeHoachTruongInfo = new XL_KeHoachTruongInfo();
                                    pKeHoachTruongInfo.XL_KeHoachTruongID = objCellData.KeHoachTruongID;
                                    pKeHoachTruongInfo.IDXL_KeHoachKhac = objCellData.IDKeHoachKhac;
                                    pKeHoachTruongInfo.IDDM_Lop = IDDM_Lop;
                                    pKeHoachTruongInfo.IDXL_Tuan = IDTuan;
                                    pKeHoachTruongInfo.CaHoc = objCellData.BuoiHoc;
                                    pKeHoachTruongInfo.IDDM_PhongHoc = objCellData.IDPhongHoc;
                                    pKeHoachTruongInfo.NgayNghi = objCellData.NgayNghi;

                                    UpdateKeHoachTruongTuan(pKeHoachTruongInfo);
                                    //}
                                }
                                // Còn lại là Insert vào
                                else
                                {
                                    pKeHoachTruongInfo = new XL_KeHoachTruongInfo();
                                    pKeHoachTruongInfo.IDXL_KeHoachKhac = objCellData.IDKeHoachKhac;
                                    pKeHoachTruongInfo.IDDM_Lop = IDDM_Lop;
                                    pKeHoachTruongInfo.IDXL_Tuan = IDTuan;
                                    pKeHoachTruongInfo.CaHoc = objCellData.BuoiHoc;
                                    pKeHoachTruongInfo.IDDM_PhongHoc = objCellData.IDPhongHoc;
                                    pKeHoachTruongInfo.NgayNghi = "" + objCellData.NgayNghi;

                                    objCellData.KeHoachTruongID = InsertKeHoachTruongTuan(pKeHoachTruongInfo);
                                }
                                objCellData.Changed = false;
                                rg.UserData = objCellData;
                            }
                        }
                    }
                    c++;
                }
            }
        }

        private void DeleteKeHoachTruongTuan(int KeHoachTruongID)
        {
            pKeHoachTruongInfo = new XL_KeHoachTruongInfo();
            pKeHoachTruongInfo.XL_KeHoachTruongID = KeHoachTruongID;
            oBKeHoachTruong.Delete(pKeHoachTruongInfo);
        }

        private int InsertKeHoachTruongTuan(XL_KeHoachTruongInfo pKeHoachTruongInfo)
        {
            return oBKeHoachTruong.Add(pKeHoachTruongInfo);
        }

        private void UpdateKeHoachTruongTuan(XL_KeHoachTruongInfo pKeHoachTruongInfo)
        {
            oBKeHoachTruong.Update(pKeHoachTruongInfo);
        }
        #endregion

        private void btnThemHoatDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fg.Rows.Count > fg.Rows.Fixed)
            {
                int rowStart, rowEnd, colStart, colEnd;
                //DateTime dateTuNgay, dateDenNgay;
                CellRange rg = fg.Selection;
                if (rg.UserData == null)
                    return;
                // Không cần phải gắn dữ liệu CellData đoạn này. Sẽ sinh ra lỗi khi chọn vào vùng fixed
                CellData objCellData = (CellData)rg.UserData;
                rowStart = rg.TopRow;
                rowEnd = rg.BottomRow;
                colStart = rg.LeftCol;
                colEnd = rg.RightCol;
                // Kiểm tra xem các dữ liệu fixed
                if (colStart < ColBegin)
                    colStart = ColBegin;
                if (rowStart < RowBegin)
                    rowStart = RowBegin;

                dlgChonHoatDong dlg = new dlgChonHoatDong();
                dlg.mNgayNghi = "";
                dlg.mKeHoachKhacID = objCellData.IDKeHoachKhac;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    DisplayKeHoachOnGrid(0, dlg.mKeHoachKhacID, dlg.mTenKeHoachKhac, dlg.mTenVietTat, dlg.mNgayNghi, rowStart, colStart, rowEnd, colEnd);
                    // ghi log
                    GhiLog("Thêm kế hoạch khác '" + dlg.mTenKeHoachKhac + "' vào kế hoạch toàn trường", "Xóa", this.Tag.ToString());
                }
            }
        }

        private void fg_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                dlgChonHoatDong dlg = new dlgChonHoatDong();
                if (!(fg[fg.Row, fg.Col] == System.DBNull.Value))
                {
                    CellRange rg = fg.GetCellRange(fg.Row, fg.Col, fg.Row, fg.Col);
                    CellData objCellData = new CellData();
                    if (!(rg.UserData == null))
                    {
                        objCellData = (CellData)rg.UserData;
                        dlg.mKeHoachKhacID = objCellData.IDKeHoachKhac;
                        dlg.mNgayNghi = objCellData.NgayNghi;
                    }
                }
                // Nếu có chọn loại hoạt động thì sẽ thực hiện việc áp dụng đó lên grid
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // Nếu có sự thay đổi thì sẽ thực hiện việc hiển thị lên grid
                    DisplayKeHoachOnGrid(0, dlg.mKeHoachKhacID, dlg.mTenKeHoachKhac, dlg.mTenVietTat, dlg.mNgayNghi, fg.Row, fg.Col, fg.Row, fg.Col);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnKeHoachKhac_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmKeHoachKhac frm = new frmKeHoachKhac();
            frm.ShowDialog();
            mdtColor.Clear();
            htbCellStyle.Clear();
            FlexColor(fg);
        }

        private void barbtnCaHoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void fg_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.S:
                        DisplayBuoiHocOnGrid(0);
                        break;
                    case Keys.C:
                        DisplayBuoiHocOnGrid(1);
                        break;
                    case Keys.T:
                        DisplayBuoiHocOnGrid(2);
                        break;
                    case Keys.Delete:
                        DeleteKeHoachOnGrid();
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                LuuKeHoach();
                // ghi log
                GhiLog("Cập nhật sửa kế hoạch toàn trường", "Cập nhật", this.Tag.ToString());
                LuuThanhCong();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        #region ToolTip
        private void fg_MouseEnterCell(object sender, RowColEventArgs e)
        {
            if (e.Row < RowBegin || e.Col < ColBegin) return;
            CellRange rg = fg.GetCellRange(e.Row, e.Col);
            if (rg.Data.ToString() != "")
            {
                if (rg.UserData != null)
                {
                    CellData ud = (CellData)rg.UserData;
                    string strToolTip = "";
                    if (ud.BuoiHoc != (int)BUOIHOC.ChuaXacDinh)
                        strToolTip = "Ca học: <color=Blue>" + (ud.BuoiHoc == 0 ? "Sáng" : (ud.BuoiHoc == 1 ? "Chiều" : "Tối"));
                    if (ud.TenPhongHoc != "")
                        strToolTip += (strToolTip == "" ? "" : "<color=Black>, Phòng học: <color=Blue>") + ud.TenPhongHoc;
                    if (ud.TenKeHoachKhac != "" && "" + ud.NgayNghi != "")
                        strToolTip += (strToolTip == "" ? "" : "<br><color=Black>Kế hoạch khác: <color=Blue>" +
                            ud.TenKeHoachKhac + "<br><color=Black>Ngày thực hiện: <color=Blue>" + NgayNghiToString(ud.NgayNghi));
                    toolTipController.ShowHint(strToolTip, "Kế hoạch lớp");
                }
            }
        }

        private void fg_MouseLeaveCell(object sender, RowColEventArgs e)
        {
            toolTipController.HideHint();
        }
        #endregion

        private void barbtnpopThemHoatDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnThemHoatDong_ItemClick(null, null);
        }

        private void barbtnXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportFlexGridToXls(fg);
        }
    }
}
