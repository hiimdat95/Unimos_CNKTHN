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
using Lib;
using C1.Win.C1FlexGrid;

namespace UnimOs.UI
{
    public partial class frmBaoBanGiaoVien : frmBase
    {
        int ColBegin = 6, ColWidth = 45;
        DataTable dtTuan, dtBaoBan, dtChiTiet, dtGiaoVien;
        cBXL_BaoBanGiaoVien oBBaoBanGV;
        XL_BaoBanGiaoVienInfo pBaoBanGVInfo;
        bool BaoBan = true, Selected = false;

        public frmBaoBanGiaoVien()
        {
            InitializeComponent();
            oBBaoBanGV = new cBXL_BaoBanGiaoVien();
            pBaoBanGVInfo = new XL_BaoBanGiaoVienInfo();
        }

        private void frmBaoBanGiaoVien_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            if (Program.IDNamHoc > 0)
            {
                FlexColorSetup(fg);
                FlexColorSetup(fgChiTiet);
                cBXL_Tuan oBTuan = new cBXL_Tuan();
                dtTuan = oBTuan.GetByHocKy_NamHoc(Program.IDNamHoc, Program.HocKy);
                FillBaoBan();
            }
        }

        private void FillBaoBan()
        {
            fg.DataSource = null;
            DataTable dtSource = LoadBaoBanGiaoVien();

            fg.DataSource = dtSource.DefaultView;
            LoadTieuDe();

            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                fg[fg.Rows.Fixed + i, 0] = dtSource.DefaultView[i]["MaGiaoVien"].ToString();
                fg[fg.Rows.Fixed + i, 1] = dtSource.DefaultView[i]["HoTen"].ToString();
            }

            CellRange cr = fg.GetCellRange(0, 0, fg.Rows.Fixed - 1, 0);
            cr.Data = "Mã GV";
            cr = fg.GetCellRange(0, 1, fg.Rows.Fixed - 1, 1);
            cr.Data = "Họ và tên";
            fg.Cols[0].AllowMerging = true;
            fg.Cols[1].AllowMerging = true;

            for (int r = fg.Rows.Fixed; r < fg.Rows.Count; r++)
            {
                for (int c = ColBegin; c < fg.Cols.Count; c++)
                {
                    FormatCellStyle(r, c);
                }
            }
            fg.Cols[0].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter;
            fg.Cols[0].Width = 90;
            fg.Cols[1].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter;
            fg.Cols[1].Width = 160;
            fg.Cols["IDNS_GiaoVien"].Visible = false;
            fg.Cols["HoTen"].Visible = false;
            fg.Cols["MaGiaoVien"].Visible = false;
            fg.Cols["TenVietTat"].Visible = false;
            fg.Rows[0].Visible = false;

            dtGiaoVien = dtSource.Copy();
            for (int i = dtGiaoVien.Columns.Count - 1; i > 3; i--)
            {
                dtGiaoVien.Columns.Remove(dtGiaoVien.Columns[i].ColumnName);
            }
            dtGiaoVien.DefaultView.Sort = "TenVietTat, IDNS_GiaoVien";
        }

        private DataTable LoadBaoBanGiaoVien()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IDNS_GiaoVien", typeof(int));
            dt.Columns.Add("HoTen", typeof(string));
            dt.Columns.Add("MaGiaoVien", typeof(string));
            dt.Columns.Add("TenVietTat", typeof(string));
            foreach (DataRow dr in dtTuan.Rows)
            {
                dt.Columns.Add("T" + dr["XL_TuanID"].ToString(), typeof(string));
            }
            dtBaoBan = oBBaoBanGV.GetByHocKy(Program.IDNamHoc, Program.HocKy);
            if (dtBaoBan.Rows.Count > 0)
            {
                int count = 0;
                DataRow drNew;
                Lib.clsDataTableHelper cls = new Lib.clsDataTableHelper();
                DataTable dtTemp = cls.SelectDistinct(dtBaoBan, new string[] { "NS_GiaoVienID", "HoTen", "MaGiaoVien", "IDTuan" }, new string[] { "TenVietTat" });
                string IDGiaoVien = dtTemp.Rows[0]["NS_GiaoVienID"].ToString();
                drNew = dt.NewRow();
                drNew["IDNS_GiaoVien"] = int.Parse(IDGiaoVien);
                drNew["HoTen"] = EncodeString(dtTemp.Rows[0]["HoTen"].ToString(), 0);
                drNew["MaGiaoVien"] = dtTemp.Rows[0]["MaGiaoVien"].ToString();
                drNew["TenVietTat"] = dtTemp.Rows[0]["TenVietTat"].ToString();

                foreach (DataRow dr in dtTemp.Rows)
                {
                    if (dr["NS_GiaoVienID"].ToString() != IDGiaoVien)
                    {
                        count++;
                        IDGiaoVien = dr["NS_GiaoVienID"].ToString();
                        // Add row đã có dữ liệu trước khi khởi tạo row mới.
                        dt.Rows.Add(drNew);
                        // Khởi tạo row mới để gán dữ liệu.
                        drNew = dt.NewRow();
                        drNew["IDNS_GiaoVien"] = int.Parse(IDGiaoVien);
                        drNew["HoTen"] = EncodeString(dr["HoTen"].ToString(), count);
                        drNew["MaGiaoVien"] = dr["MaGiaoVien"].ToString();
                        drNew["TenVietTat"] = dr["TenVietTat"].ToString();
                        if (dr["IDTuan"] + "" != "")
                            drNew["T" + dr["IDTuan"].ToString()] = " ";
                    }
                    else
                    {
                        if (dr["IDTuan"] + "" != "")
                            drNew["T" + dr["IDTuan"].ToString()] = " ";
                    }
                }
                dt.Rows.Add(drNew);
            }
            dt.DefaultView.Sort = "TenVietTat, IDNS_GiaoVien";
            return dt;
        }

        private void FormatCellStyle(int r, int c)
        {
            if (fg[r, c] + "" != "")
            {
                fg.SetCellStyle(r, c, fg.Styles["MyCellStyleBaoBan"]);
            }
        }

        private void LoadTieuDe()
        {
            if (dtTuan.Rows.Count > 0)
            {
                int i = 0, IDTuan;
                DateTime NgayDauTuan, NgayCuoiTuan;
                try
                {
                    fg.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.FixedOnly;
                    fg.Rows[1].AllowMerging = true;
                    fg.Rows[2].AllowMerging = true;
                    fg.Rows[3].AllowMerging = true;
                    foreach (DataRow dr in dtTuan.Rows)
                    {
                        NgayDauTuan = (DateTime.Parse(dr["TuNgay"].ToString())).Date;
                        NgayCuoiTuan = (DateTime.Parse(dr["DenNgay"].ToString())).Date;
                        IDTuan = int.Parse(dr["XL_TuanID"].ToString());
                        fg[0, ColBegin + i] = IDTuan;
                        fg[1, ColBegin + i] = "Học kỳ " + Program.HocKy.ToString();
                        fg[2, ColBegin + i] = "Tháng " + NgayDauTuan.Month.ToString();
                        fg[3, ColBegin + i] = dr["TuanThu"].ToString();
                        fg[4, ColBegin + i] = NgayDauTuan.Day.ToString() + " - " + NgayCuoiTuan.Day.ToString();
                        fg.Cols[ColBegin + i].Width = ColWidth;
                        fg.Cols[ColBegin + i].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                        i++;
                    }
                }
                catch (Exception ex)
                {
                    ThongBao(ex.Message);
                }
            }
        }

        private void fg_DoubleClick(object sender, EventArgs e)
        {
            if (Selected == true)
            {
                int IDTuTuan, IDDenTuan;
                CellRange rg = fg.Selection;
                IDTuTuan = int.Parse(fg.Rows[0][rg.LeftCol].ToString());
                IDDenTuan = int.Parse(fg.Rows[0][rg.RightCol].ToString());
                dlgBaoBanGiaoVien dlg = new dlgBaoBanGiaoVien(dtGiaoVien.DefaultView, dtChiTiet, ref dtBaoBan, dtTuan, int.Parse(fg[fg.Row, "IDNS_GiaoVien"].ToString()), IDTuTuan, IDDenTuan);
                dlg.ShowDialog();
                if (dlg.Changed)
                {
                    FillBaoBan();
                    fg_RowColChange(null, null);
                }
            }
        }

        private void fg_RowColChange(object sender, EventArgs e)
        {
            if (fg.Col >= ColBegin && fg.Row >= 5)
            {
                long IDXL_Tuan = int.Parse(fg[0, fg.Col].ToString());
                DataRow[] arrDr = dtTuan.Select("XL_TuanID = " + IDXL_Tuan.ToString());
                if (fg[fg.Row, fg.Col].ToString() == "")
                {
                    if (BaoBan == true)
                    {
                        dtChiTiet = CreateTableChiTiet((DateTime)arrDr[0]["TuNgay"], (DateTime)arrDr[0]["DenNgay"]);
                        ShowBaoBanChiTiet(fgChiTiet, dtChiTiet, ColBegin);
                        //BaoBan = false;
                    }
                }
                else
                {
                    dtChiTiet = CreateTableChiTiet((DateTime)arrDr[0]["TuNgay"], (DateTime)arrDr[0]["DenNgay"]);
                    DataTable dtTemp = dtBaoBan.Copy();
                    string IDTuan = fg[0, fg.Col].ToString();
                    string IDGiaoVien = fg[fg.Row, "IDNS_GiaoVien"].ToString();
                    dtTemp.DefaultView.RowFilter = "IDTuan = " + IDTuan + " And IDNS_GiaoVien = " + IDGiaoVien;
                    try
                    {
                        foreach (DataRowView dr in dtTemp.DefaultView)
                        {
                            if ((CA_HOC)dr["CaHoc"] == CA_HOC.CA_SANG)
                            {
                                dtChiTiet.Rows[int.Parse(dr["Tiet"].ToString()) + 1]["T" + dr["Thu"].ToString()] = dr["MoTa"].ToString();
                            }
                            else if ((CA_HOC)dr["CaHoc"] == CA_HOC.CA_CHIEU)
                            {
                                dtChiTiet.Rows[int.Parse(dr["Tiet"].ToString()) + 1 + Program.pgrThamSo.SO_TIET_CASANG]["T" + dr["Thu"].ToString()] = dr["MoTa"].ToString();
                            }
                            else if ((CA_HOC)dr["CaHoc"] == CA_HOC.CA_TOI)
                            {
                                dtChiTiet.Rows[int.Parse(dr["Tiet"].ToString()) + 1 + Program.pgrThamSo.SO_TIET_CASANG + Program.pgrThamSo.SO_TIET_CACHIEU]["T" + dr["Thu"].ToString()] = dr["MoTa"].ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message);
                    }
                    ShowBaoBanChiTiet(fgChiTiet, dtChiTiet, 4);
                    BaoBan = true;
                }
                Selected = true;
            }
            else
                Selected = false;
        }

        private void fg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && fg.ClientRectangle.Contains(e.X, e.Y))
            {
                if (fg.Col >= ColBegin && fg.Row >= 5)
                {
                    popupBaoBan.ShowPopup(MousePosition);
                }
            }
        }

        private void barbtnBaoBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fg_DoubleClick(null, null);
        }

        private void barbtnXoaBanBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barbtnXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportFlexGridToXls(fg);
        }
    }
}