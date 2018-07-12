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
using C1.Win.C1FlexGrid;
using System.Collections;

namespace UnimOs.UI
{
    public partial class frmKeHoachThucHanh : frmBase
    {
        private cBXL_KeHoachThucHanh oBXL_KeHoachThucHanh;
        private cBXL_KeHoachThucHanhChiTiet oBXL_KeHoachThucHanhChiTiet;
        private XL_KeHoachThucHanhChiTietInfo pXL_KeHoachThucHanhChiTietInfo;
        private cBDM_PhongHoc oBDM_PhongHoc;
        private Lib.clsDataTableHelper clsdt;
        private DataTable dtTuan, dtLop, dtToanTruong;
        public DataTable dtKeHoach;
        private int RowHeight = 20, ColWidth = 20;
        public int RowBegin = 6, ColBegin = 7, SoTo = 2, indexCol;
        private CellRange crFocus;

        // Khai báo cấu trúc của kế hoạch
        public struct Cell_KeHoach
        {
            public long XL_KeHoachThucHanhChiTietID;
            public int IDXL_KeHoachThucHanh;
            public int IDXL_KeHoachThucHanhKyHieu;
            public int IDDM_MonHoc;
            public string KyHieu;
            public int IDNS_GiaoVien;
            public string TenGiaoVien;
            public string TenVietTat;
            public int IDDM_PhongHoc;
            public string TenPhongHoc;
            public CA_HOC CaHoc;
            public int To;
            public DateTime NgayHoc;
            public bool Changed;
        }

        protected struct CellData
        {
            public string TenPhongHoc;
            public string BuoiHoc;
            public string TenKeHoachKhac;
            public string TenVietTat;
            public string NgayNghi;
            public int SoNgayNghi;
        }

        public frmKeHoachThucHanh()
        {
            InitializeComponent();
            oBXL_KeHoachThucHanh = new cBXL_KeHoachThucHanh();
            oBXL_KeHoachThucHanhChiTiet = new cBXL_KeHoachThucHanhChiTiet();
            pXL_KeHoachThucHanhChiTietInfo = new XL_KeHoachThucHanhChiTietInfo();
            oBDM_PhongHoc = new cBDM_PhongHoc();
            clsdt = new Lib.clsDataTableHelper();
        }

        private void frmKeHoachThucHanh_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            bar2.Visible = true;
            cBXL_Tuan oBTuan = new cBXL_Tuan();
            dtTuan = oBTuan.GetByHocKy_NamHoc(Program.IDNamHoc, Program.HocKy);
            dtLop = (new cBDM_Lop()).GetTree(Program.NamHoc);
            fg.AllowMerging = AllowMergingEnum.Free;
            FlexColor(fg);
            FlexColor();
            FormatGrid();
            GetKeHoachThucHanhLop();
        }

        #region Load kế hoạch thực hành
        private void GetKeHoachThucHanhPhongHoc()
        {
            
        }

        private void GetKeHoachThucHanhLop()
        {
            dtToanTruong = new cBDM_Lop().GetKeHoachToanTruong(Program.IDNamHoc, Program.NamHoc, new DM_LopInfo());
            dtKeHoach = oBXL_KeHoachThucHanh.GetByNamHoc(Program.IDNamHoc, Program.HocKy);
            DataTable dtChiTiet = oBXL_KeHoachThucHanhChiTiet.GetByNamHocHocKy(Program.IDNamHoc, Program.HocKy);

            DataTable dtLop = clsdt.SelectDistinct(dtKeHoach, new string[] { "IDDM_He", "IDDM_TrinhDo", "TenKhoaHoc", "IDDM_Lop", "TenLop", "SoSinhVien" });
            string[] arrCaHoc = new string[] { "Sáng", "Chiều", "Tối" };

            if (fg.Rows.Count > RowBegin + 1)
            {
                fg.Select(RowBegin, 4);
                fg.Rows.RemoveRange(RowBegin + 1, fg.Rows.Count - RowBegin - 1);
            }
            
            int row = RowBegin, rowDangXet = RowBegin, colDangXet = ColBegin, CaHocDangXet, ToDangXet;

            foreach (DataRow dr in dtLop.Rows)
            {
                // Hiển thị kế hoạch lớp
                fg.Rows.Add(1);
                row++;
                // Gán các giá trị cho cell fix
                fg.Rows[row].Height = RowHeight;
                fg[row, 0] = "";
                fg[row, 1] = "Kế hoạch lớp";
                fg[row, 2] = "Kế hoạch lớp";
                fg[row, 3] = "Kế hoạch lớp";
                fg[row, 4] = int.Parse(dr["IDDM_Lop"].ToString());
                fg.Rows[row].AllowMerging = true;
                CellRange rg = fg.GetCellRange(row, 0, row, fg.Cols.Fixed - 1);
                rg.Style = fg.Styles["MyCellStyleLop"];
                FillKeHoachLop(row, int.Parse(dr["IDDM_Lop"].ToString()));

                foreach (string CaHoc in arrCaHoc)
                {
                    for (int i = 1; i <= 2; i++)
                    {
                        // Thêm 1 row vào grid và tăng giá trị của row hiện tại lên 1
                        fg.Rows.Add(1);
                        row++;
                        // Gán các giá trị cho cell fix
                        fg.Rows[row].Height = RowHeight;
                        fg[row, 0] = dr["TenLop"].ToString();
                        fg[row, 1] = int.Parse(dr["SoSinhVien"].ToString());
                        fg[row, 2] = CaHoc;
                        fg[row, 3] = EncodeString(i.ToString(), row);
                        fg[row, 4] = int.Parse(dr["IDDM_Lop"].ToString());
                        fg.Rows[row].AllowMerging = true;
                    }
                }
                // Thực hiện tìm các kế hoạch chi tiết thực hành của lớp đang xét để fill lên grid
                DataView dv = new DataView(dtChiTiet);
                dv.RowFilter = "IDDM_Lop = " + dr["IDDM_Lop"];
                if (dv.Count > 0)
                {
                    CaHocDangXet = -1;
                    ToDangXet = -1;
                    foreach (DataRowView drv in dv)
                    {
                        if (int.Parse(drv["CaHoc"].ToString()) != CaHocDangXet || int.Parse(drv["ToThucHanh"].ToString()) != ToDangXet)
                        {
                            CaHocDangXet = int.Parse(drv["CaHoc"].ToString());
                            ToDangXet = int.Parse(drv["ToThucHanh"].ToString());
                            colDangXet = ColBegin;
                            if (CaHocDangXet == 0)
                            {
                                if (ToDangXet != 2)
                                    rowDangXet = row - 5;
                                else
                                    rowDangXet = row - 4;
                            }
                            else if (CaHocDangXet == 1)
                            {
                                if (ToDangXet != 2)
                                    rowDangXet = row - 3;
                                else
                                    rowDangXet = row - 2;
                            }
                            else
                            {
                                if (ToDangXet != 2)
                                    rowDangXet = row - 1;
                                else
                                    rowDangXet = row;
                            }
                        }
                        while (colDangXet < fg.Cols.Count)
                        {
                            if (StringToDate(fg[6, colDangXet].ToString().Substring(2)).Date == ((DateTime)drv["NgayThucHanh"]).Date)
                                break;
                            colDangXet++;
                        }

                        if (ToDangXet == 0)
                        {
                            SetCellKeHoach(rowDangXet, colDangXet, int.Parse(drv["XL_KeHoachThucHanhChiTietID"].ToString()),
                                int.Parse(drv["IDXL_KeHoachThucHanh"].ToString()), int.Parse(drv["IDDM_MonHoc"].ToString()),
                                int.Parse(drv["IDXL_KeHoachThucHanhKyHieu"].ToString()), drv["KyHieu"].ToString(),
                                int.Parse("0" + drv["IDNS_GiaoVien"]), "" + drv["TenGiaoVien"], "" + drv["TenVietTat"],
                                int.Parse("0" + drv["IDDM_PhongHoc"]), "" + drv["TenPhongHoc"], (CA_HOC)drv["CaHoc"],
                                ToDangXet, (DateTime)drv["NgayThucHanh"]);

                            SetCellKeHoach(rowDangXet + 1, colDangXet, int.Parse(drv["XL_KeHoachThucHanhChiTietID"].ToString()),
                                int.Parse(drv["IDXL_KeHoachThucHanh"].ToString()), int.Parse(drv["IDDM_MonHoc"].ToString()),
                                int.Parse(drv["IDXL_KeHoachThucHanhKyHieu"].ToString()), drv["KyHieu"].ToString(),
                                int.Parse("0" + drv["IDNS_GiaoVien"]), "" + drv["TenGiaoVien"], "" + drv["TenVietTat"],
                                int.Parse("0" + drv["IDDM_PhongHoc"]), "" + drv["TenPhongHoc"], (CA_HOC)drv["CaHoc"],
                                ToDangXet, (DateTime)drv["NgayThucHanh"]);
                        }
                        else
                        {
                            SetCellKeHoach(rowDangXet, colDangXet, int.Parse(drv["XL_KeHoachThucHanhChiTietID"].ToString()),
                                int.Parse(drv["IDXL_KeHoachThucHanh"].ToString()), int.Parse(drv["IDDM_MonHoc"].ToString()),
                                int.Parse(drv["IDXL_KeHoachThucHanhKyHieu"].ToString()), drv["KyHieu"].ToString(),
                                int.Parse("0" + drv["IDNS_GiaoVien"]), "" + drv["TenGiaoVien"], "" + drv["TenVietTat"],
                                int.Parse("0" + drv["IDDM_PhongHoc"]), "" + drv["TenPhongHoc"], (CA_HOC)drv["CaHoc"],
                                ToDangXet, (DateTime)drv["NgayThucHanh"]);
                        }
                    }
                }
            }
            for (int i = ColBegin; i < fg.Cols.Count; i++)
                fg.Cols[i].AllowMerging = true;

            SetGridCaption("LOP");
        }

        private void FillKeHoachLop(int r, int DM_LopID)
        {
            indexCol = ColBegin;
            for (int i = 0; i < dtTuan.Rows.Count; i++)
            {
                FormatColorCell(r, i, DM_LopID);
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

        //private void GetKeHoachThucHanhGiangVien()
        //{

        //}
        #endregion

        #region Format Grid
        private void FormatTieuDe(int colBegin, int colWidth, bool ShowThang, bool ShowTuan, bool ShowNgay)
        {
            cBXL_Tuan oBTuan = new cBXL_Tuan();
            XL_TuanInfo pTuanInfo = new XL_TuanInfo();
            int IDTuan, HocKy, TuanThu, SoNgayTuan;
            DateTime NgayDau, NgayCuoi, NgayHienTai;
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
                    SoNgayTuan = NgayCuoi.Subtract(NgayDau).Days;
                    for (int j = 0; j <= SoNgayTuan; j++)
                    {
                        NgayHienTai = NgayDau.AddDays(j);
                        if (Program.pgrThamSo.THUCHANH_TU_THU <= (int)NgayHienTai.DayOfWeek && (int)NgayHienTai.DayOfWeek <= Program.pgrThamSo.THUCHANH_DEN_THU)
                        {
                            if (NgayHienTai.DayOfWeek != DayOfWeek.Sunday)
                            {
                                fg.Cols.Add(1);
                                fg[0, Temp] = IDTuan;
                                fg[1, Temp] = "Học kỳ " + HocKy.ToString();
                                fg[2, Temp] = "Tháng " + NgayHienTai.Month.ToString();
                                fg[3, Temp] = TuanThu;
                                fg[4, Temp] = NgayDau.Day.ToString() + " - " + NgayCuoi.Day.ToString();
                                fg[5, Temp] = NgayHienTai.Day;
                                fg[6, Temp] = "C_" + DateToInt(NgayHienTai);
                                fg.Cols[Temp].Width = colWidth;
                                fg.Cols[Temp].TextAlign = TextAlignEnum.CenterCenter;
                                Temp += 1;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ThongBaoLoi(ex.Message);
            }
        }

        private void FormatGrid()
        {
            fg.Cols.Add(ColBegin);
            fg.AllowSorting = AllowSortingEnum.None;
            fg.Cols.Fixed = 4;
            fg.Rows.Fixed = 6;
            fg.Rows.DefaultSize = RowHeight;

            //Set rows width 
            // Hàng IDTuan
            fg.Rows[0].Height = 0;
            // Hàng Học kỳ
            fg.Rows[1].Height = 20;
            // Hàng Tháng
            fg.Rows[2].Height = 20;
            // Hàng Tuần thứ
            fg.Rows[3].Height = 20;
            // Hàng Từ ngày đến ngày
            fg.Rows[4].Height = 20;
            // Hàng ngày
            fg.Rows[5].Height = 20;
            // Hàng oBBase.DateToInt
            fg.Rows[6].Visible = false;

            fg.Rows[1].AllowMerging = true;
            fg.Rows[2].AllowMerging = true;
            fg.Rows[3].AllowMerging = true;
            fg.Rows[4].AllowMerging = true;
            //fg.Rows[5].AllowMerging = true;

            //Set columns width 
            // Tên lớp hoặc phòng
            fg.Cols[0].Width = 130;
            // Số sinh viên hoặc sức chứa
            fg.Cols[1].Width = 35;
            // Ca học
            fg.Cols[2].Width = 40;
            // Tổ
            fg.Cols[3].Width = 23;
            // IDDM_Lop hoặc IDDM_PhongHoc
            fg.Cols[4].Visible = false;

            fg.Cols[5].Visible = false;
            fg.Cols[6].Visible = false;

            //fg.Cols[1].TextAlign = TextAlignEnum.CenterCenter;
            fg.Cols[0].AllowMerging = true;
            fg.Cols[1].AllowMerging = true;
            fg.Cols[2].AllowMerging = true;
            fg.Cols[3].AllowMerging = true;
            //Set Caption
            CellRange rg2 = fg.GetCellRange(1, 2, 5, 2);
            rg2.Data = "Ca";
            CellRange rg3 = fg.GetCellRange(1, 3, 5, 3);
            rg3.Data = "Tổ";

            FormatTieuDe(ColBegin, ColWidth, false, false, true);
        }

        private void SetGridCaption(string ViewWith)
        {
            if (ViewWith == "LOP")
            {
                CellRange rg = fg.GetCellRange(1, 0, 5, 0);
                rg.Data = "Tên lớp";
                CellRange rg1 = fg.GetCellRange(1, 1, 5, 1);
                rg1.Data = "Số sinh viên";
            }
            else if (ViewWith == "PHONG")
            {
                CellRange rg = fg.GetCellRange(1, 0, 5, 0);
                rg.Data = "Tên phòng";
                CellRange rg1 = fg.GetCellRange(1, 1, 5, 1);
                rg1.Data = "Sức chưa";
            }
            else
            {
                CellRange rg = fg.GetCellRange(1, 0, 5, 1);
                rg.Data = "Giảng viên";
                //CellRange rg1 = fg.GetCellRange(1, 1, 5, 1);
                //rg1.Data = "Sức chưa";
            }
        }
        #endregion

        #region FlexColor
        // Khai báo cho phần format color
        //protected DataTable mdtColor = new DataTable();
        protected Hashtable htbThucHanhStyle = new Hashtable();
        protected void FlexColor()
        {
            cBXL_KeHoachThucHanhKyHieu oBXL_KeHoachThucHanhKyHieu = new cBXL_KeHoachThucHanhKyHieu();
            XL_KeHoachThucHanhKyHieuInfo pXL_KeHoachThucHanhKyHieuInfo = new XL_KeHoachThucHanhKyHieuInfo();
            DataTable mdtThucHanh = oBXL_KeHoachThucHanhKyHieu.Get(pXL_KeHoachThucHanhKyHieuInfo);
            CellStyle objCellStyle;
            // Định nghĩa các Style theo kế hoạch người dùng chọn
            foreach (DataRow dr in mdtThucHanh.Rows)
            {
                objCellStyle = fg.Styles.Add("Style_" + dr["XL_KeHoachThucHanhKyHieuID"].ToString());
                objCellStyle.Font = new Font("Arial", 7);
                objCellStyle.BackColor = Color.FromArgb(int.Parse(dr["MauNen"].ToString()));
                objCellStyle.ForeColor = Color.FromArgb(int.Parse(dr["MauChu"].ToString()));
                htbThucHanhStyle.Add("Style_" + dr["XL_KeHoachThucHanhKyHieuID"].ToString(), objCellStyle);
            }
            // Style lớp
            objCellStyle = fg.Styles.Add("MyCellStyleLop");
            //objCellStyle.Font = new Font("Arial", 10);
            objCellStyle.BackColor = Color.Tan;
            objCellStyle.ForeColor = Color.Black;
            htbThucHanhStyle.Add("MyCellStyleLop", objCellStyle);
            // Style chuẩn
            objCellStyle = fg.Styles.Add("MyCellStyle");
            objCellStyle.Font = new Font("Arial", 8);
            objCellStyle.BackColor = Color.White;
            objCellStyle.ForeColor = Color.Black;
            htbThucHanhStyle.Add("MyCellStyle", objCellStyle);
            // Ca học sáng
            objCellStyle = fg.Styles.Add("MyCellStyleSang");
            objCellStyle.Font = new Font("Arial", 8);
            objCellStyle.BackColor = Color.SkyBlue;
            objCellStyle.ForeColor = Color.Maroon;
            htbThucHanhStyle.Add("MyCellStyleSang", objCellStyle);
            // Ca học chiều
            objCellStyle = fg.Styles.Add("MyCellStyleChieu");
            objCellStyle.Font = new Font("Arial", 8);
            objCellStyle.BackColor = Color.Gainsboro;
            objCellStyle.ForeColor = Color.DodgerBlue;
            htbThucHanhStyle.Add("MyCellStyleChieu", objCellStyle);
            // Ca học tối
            objCellStyle = fg.Styles.Add("MyCellStyleToi");
            objCellStyle.Font = new Font("Arial", 8);
            objCellStyle.BackColor = Color.DarkSeaGreen;
            objCellStyle.ForeColor = Color.Gold;
            htbThucHanhStyle.Add("MyCellStyleToi", objCellStyle);
            // Giáo viên
            objCellStyle = fg.Styles.Add("MyCellStyleGiaoVien");
            objCellStyle.Font = new Font("Arial", 8);
            objCellStyle.BackColor = Color.LemonChiffon;
            objCellStyle.ForeColor = Color.Blue;
            htbThucHanhStyle.Add("MyCellStyleGiaoVien", objCellStyle);
            // Row TongHop
            objCellStyle = fg.Styles.Add("MyCellStyleTongHop");
            objCellStyle.Font = new Font("Arial", 8);
            objCellStyle.BackColor = Color.Silver;
            objCellStyle.ForeColor = Color.Blue;
            htbThucHanhStyle.Add("MyCellStyleTongHop", objCellStyle);
        }
        #endregion

        #region ItemClick
        private void barbtnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetKeHoachThucHanhLop();
        }

        private void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int IDTuan, c, IDDM_Lop;
                for (int r = RowBegin + 1; r <= fg.Rows.Count - 1; r++)
                {
                    if ("" + fg[r, 0] != "")
                    {
                        IDDM_Lop = int.Parse(fg[r, 4].ToString());
                        c = ColBegin;
                        while (c <= fg.Cols.Count - 1)
                        {
                            CellRange rg = fg.GetCellRange(r, c);
                            if (rg.UserData != null)
                            {
                                IDTuan = int.Parse(fg[0, c].ToString());
                                Cell_KeHoach objCellData = (Cell_KeHoach)rg.UserData;
                                if (rg.UserData != null)
                                {
                                    if (objCellData.IDXL_KeHoachThucHanhKyHieu == -1)
                                    {
                                        if (objCellData.XL_KeHoachThucHanhChiTietID > 0)
                                        {
                                            DeleteKeHoachThucHanhChiTiet(objCellData.XL_KeHoachThucHanhChiTietID);
                                        }
                                    }
                                    else
                                    {
                                        if (objCellData.Changed)
                                        {
                                            // Nếu có sự thay đổi trong kế hoạch và từ ca học -> nghỉ hoặc từ nghỉ -> ca học hoặc nghỉ -> nghỉ khác
                                            // Từ nghỉ -> nghỉ khác thì update vào
                                            if (objCellData.XL_KeHoachThucHanhChiTietID > 0)
                                            {
                                                // Nếu được thay thế bởi Kế hoạch nghỉ khác thì update
                                                //if (objCellData.IDKeHoachKhac > 0)
                                                //{
                                                pXL_KeHoachThucHanhChiTietInfo = new XL_KeHoachThucHanhChiTietInfo();
                                                pXL_KeHoachThucHanhChiTietInfo.XL_KeHoachThucHanhChiTietID = objCellData.XL_KeHoachThucHanhChiTietID;
                                                pXL_KeHoachThucHanhChiTietInfo.IDXL_KeHoachThucHanh = objCellData.IDXL_KeHoachThucHanh;
                                                pXL_KeHoachThucHanhChiTietInfo.IDXL_Tuan = IDTuan;
                                                pXL_KeHoachThucHanhChiTietInfo.CaHoc = (int)objCellData.CaHoc;
                                                pXL_KeHoachThucHanhChiTietInfo.NgayThucHanh = objCellData.NgayHoc;
                                                pXL_KeHoachThucHanhChiTietInfo.ToThucHanh = objCellData.To;

                                                UpdateKeHoachThucHanhChiTiet(pXL_KeHoachThucHanhChiTietInfo);
                                                //}
                                            }
                                            // Còn lại là Insert vào
                                            else
                                            {
                                                pXL_KeHoachThucHanhChiTietInfo = new XL_KeHoachThucHanhChiTietInfo();
                                                pXL_KeHoachThucHanhChiTietInfo.IDXL_KeHoachThucHanh = objCellData.IDXL_KeHoachThucHanh;
                                                pXL_KeHoachThucHanhChiTietInfo.IDXL_Tuan = IDTuan;
                                                pXL_KeHoachThucHanhChiTietInfo.CaHoc = (int)objCellData.CaHoc;
                                                pXL_KeHoachThucHanhChiTietInfo.NgayThucHanh = objCellData.NgayHoc;
                                                pXL_KeHoachThucHanhChiTietInfo.ToThucHanh = objCellData.To;

                                                InsertKeHoachThucHanhChiTiet(pXL_KeHoachThucHanhChiTietInfo);
                                            }
                                            objCellData.Changed = false;
                                            rg.UserData = objCellData;
                                            // Nếu lớp chỉ có 1 tổ thực hành thì cập nhật trạng thái cho cả ô dưới nó
                                            if (pXL_KeHoachThucHanhChiTietInfo.ToThucHanh == 0)
                                            {
                                                rg = fg.GetCellRange(r + 1, c);
                                                if (rg.UserData != null)
                                                {
                                                    objCellData = (Cell_KeHoach)rg.UserData;
                                                    objCellData.Changed = false;
                                                    rg.UserData = objCellData;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            c++;
                        }
                    }
                }
                LuuThanhCong();
            }
            catch (Exception ex)
            {
                ThongBaoLoi(ex.Message);
            }
        }

        private void barbtnLop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barbtnPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        // Gọi hành thêm sửa xóa
        private void DeleteKeHoachThucHanhChiTiet(long XL_KeHoachThucHanhChiTietID)
        {
            pXL_KeHoachThucHanhChiTietInfo.XL_KeHoachThucHanhChiTietID = XL_KeHoachThucHanhChiTietID;
            oBXL_KeHoachThucHanhChiTiet.Delete(pXL_KeHoachThucHanhChiTietInfo);
        }

        private void InsertKeHoachThucHanhChiTiet(XL_KeHoachThucHanhChiTietInfo pXL_KeHoachThucHanhChiTietInfo)
        {
            oBXL_KeHoachThucHanhChiTiet.Add(pXL_KeHoachThucHanhChiTietInfo);
        }

        private void UpdateKeHoachThucHanhChiTiet(XL_KeHoachThucHanhChiTietInfo pXL_KeHoachThucHanhChiTietInfo)
        {
            oBXL_KeHoachThucHanhChiTiet.Update(pXL_KeHoachThucHanhChiTietInfo);
        }
        #endregion

        #region Set Cell KeHoach
        public void SetCellKeHoach(int r, int c, int XL_KeHoachThucHanhChiTietID, int IDXL_KeHoachThucHanh, int IDDM_MonHoc, int IDXL_KeHoachThucHanhKyHieu,
            string KyHieu, int IDNS_GiaoVien, string TenGiaoVien, string TenVietTat, int IDDM_PhongHoc, string TenPhongHoc,
            CA_HOC CaHoc, int To, DateTime NgayHoc)
        {
            CellRange rg = fg.GetCellRange(r, c);
            Cell_KeHoach objCellData;

            if (rg.UserData != null)
                objCellData = (Cell_KeHoach)rg.UserData;
            else
                objCellData = new Cell_KeHoach();

            if (XL_KeHoachThucHanhChiTietID != 0)
                objCellData.XL_KeHoachThucHanhChiTietID = XL_KeHoachThucHanhChiTietID;
            objCellData.IDXL_KeHoachThucHanh = IDXL_KeHoachThucHanh;
            objCellData.IDDM_MonHoc = IDDM_MonHoc;
            objCellData.IDXL_KeHoachThucHanhKyHieu = IDXL_KeHoachThucHanhKyHieu;
            objCellData.KyHieu = KyHieu;
            objCellData.IDNS_GiaoVien = IDNS_GiaoVien;
            objCellData.TenGiaoVien = TenGiaoVien;
            objCellData.TenVietTat = TenVietTat;
            objCellData.IDDM_PhongHoc = IDDM_PhongHoc;
            objCellData.TenPhongHoc = TenPhongHoc;
            objCellData.CaHoc = CaHoc;
            objCellData.To = To;
            objCellData.NgayHoc = NgayHoc;

            if (IDXL_KeHoachThucHanhKyHieu > 0)
            {
                rg.Style = (CellStyle)htbThucHanhStyle["Style_" + IDXL_KeHoachThucHanhKyHieu.ToString()];
                rg.Data = KyHieu;
            }
            objCellData.Changed = true;
            rg.UserData = objCellData;
        }
        #endregion

        #region Xu ly keo tha
        private void fg_DragOver(object sender, DragEventArgs e)
        {
            if (fg.HitTest().Column >= ColBegin & fg.HitTest().Row > RowBegin)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void fg_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void fg_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (fg.HitTest().Column >= ColBegin & fg.HitTest().Row > RowBegin)
                {
                    //if (rptType == REPORT_TYPE.THEO_SUKIEN) return;
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        if (crFocus.Data != null && !string.IsNullOrEmpty(crFocus.Data.ToString()))
                        {
                            fg.DoDragDrop(sender, DragDropEffects.Copy);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ThongBaoLoi(ex.ToString());
            }
        }

        private void fg_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (fg.HitTest().Column >= ColBegin & fg.HitTest().Row > RowBegin)
                {
                    crFocus = fg.GetCellRange(fg.MouseRow, fg.MouseCol);
                }
            }
            catch (Exception ex)
            {
                ThongBaoLoi(ex.Message);
            }
        }
        #endregion

        #region PopupMenu
        private void barbtnLapLichChoMon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CellRange rg = fg.Selection;
            if (rg.TopRow > RowBegin)
            {
                if ("" + fg[rg.TopRow, 0] == "")
                {
                    ThongBao("Bạn cần chọn đúng vào ca học cần xếp lịch thực hành.");
                    return;
                }
                dlgLapLichThucHanhChoMon dlg = new dlgLapLichThucHanhChoMon(this);
                dlg.ShowDialog();
            }
            else
                ThongBao("Bạn chưa chọn lớp nào.");
        }

        private void barbtnSuaCaThucHanh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        #endregion

        #region ToolTip
        private void fg_MouseEnterCell(object sender, RowColEventArgs e)
        {
            if (e.Row < RowBegin || e.Col < ColBegin) return;
            if ("" + fg[e.Row, 0] == "")
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
        #endregion

        private void barbtnXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportFlexGridToXls(fg);
        }

        private void fg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                CellRange rg = fg.Selection;
                if (rg.TopRow > RowBegin)
                {

                }
            }
        }
    }

    public class FlexThucHanh : C1.Win.C1FlexGrid.C1FlexGrid
    {
        override public CellRange GetMergedRange(int row, int col, bool clip)
        {
            // create basic cell range
            CellRange rg = GetCellRange(row, col);
            // expand left/right
            int i;
            int cnt = Cols.Count;
            int ifx = Cols.Fixed;
            for (i = rg.c1; i < cnt - 1; i++)
            {
                if (GetDataDisplay(rg.r1, i) == "" || GetDataDisplay(rg.r1, i) != GetDataDisplay(rg.r1, i + 1)) break;
                rg.c2 = i + 1;
            }
            for (i = rg.c1; i > ifx; i--)
            {
                if (GetDataDisplay(rg.r1, i) == "" || GetDataDisplay(rg.r1, i) != GetDataDisplay(rg.r1, i - 1)) break;
                rg.c1 = i - 1;
            }

            // expand up/down
            cnt = Rows.Count;
            ifx = Rows.Fixed;
            for (i = rg.r1; i < cnt - 1; i++)
            {
                if (GetDataDisplay(i, rg.c1) == "" || GetDataDisplay(i, rg.c1) != GetDataDisplay(i + 1, rg.c1)) break;
                rg.r2 = i + 1;
            }
            for (i = rg.r1; i > ifx; i--)
            {
                if (GetDataDisplay(i, rg.c1) == "" || GetDataDisplay(i, rg.c1) != GetDataDisplay(i - 1, rg.c1)) break;
                rg.r1 = i - 1;
            }

            // done
            return rg;
        }
    }
}