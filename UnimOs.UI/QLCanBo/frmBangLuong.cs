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
using System.IO;
using System.Diagnostics;

namespace UnimOs.UI
{
    public partial class frmBangLuong : frmBase
    {
        cBNS_Luong oBNS_Luong;
        NS_LuongInfo pNS_LuongInfo;
        DataTable dtGiaoVien, dtLoaiPhuCap, dtTemp;
        private double LuongCoBan = 0;
        private int IDPhuCapGV_YT = 0;

        public frmBangLuong()
        {
            InitializeComponent();
            dtpTinhDenNgay.EditValue = DateTime.Now;
            oBNS_Luong = new cBNS_Luong();
            pNS_LuongInfo = new NS_LuongInfo();
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            if (dtpTinhDenNgay.EditValue == null) return;
            CreateWaitDialog("Đang tổng hợp dữ liệu. Xin vui lòng chờ.", "Tổng hợp dữ liệu");
            if (dtGiaoVien != null)
                dtGiaoVien.Clear();
            dtGiaoVien = CreateTable();
            AddBand();
            XuLyTable();
            grdBangLuong.DataSource = dtGiaoVien;
            dtGiaoVien.AcceptChanges();
        }

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NS_GiaoVienID", typeof(int));
            dt.Columns.Add("TenDonVi", typeof(string));
            dt.Columns.Add("HoTen", typeof(string));
            dt.Columns.Add("TenGioiTinh", typeof(string));
            dt.Columns.Add("NgaySinh", typeof(string));
            dt.Columns.Add("NgayTuyenDung", typeof(string));
            dt.Columns.Add("TenTrinhDoChuyenMon", typeof(string));
            dt.Columns.Add("TenChucDanh", typeof(string));
            dt.Columns.Add("MaNgachCongChuc", typeof(string));
            dt.Columns.Add("TuNgay", typeof(string));
            dt.Columns.Add("HeSoLuong", typeof(double));
            dt.Columns.Add("PhanTramHuong", typeof(double));
            dt.Columns.Add("ThanhTienLuong", typeof(double));
            dt.Columns.Add("TongHeSoPhuCap", typeof(double));
            dt.Columns.Add("ThanhTienPhuCap", typeof(double));
            dt.Columns.Add("TongTienLuongVaPhuCap", typeof(double));
            return dt;
        }

        private void AddBand()
        {
            BandedGridColumn bgc;
            NS_LoaiPhuCapInfo pNS_LoaiPhuCapInfo = new NS_LoaiPhuCapInfo();
            cBNS_LoaiPhuCap oBNS_LoaiPhuCap = new cBNS_LoaiPhuCap();
            dtLoaiPhuCap = oBNS_LoaiPhuCap.Get(pNS_LoaiPhuCapInfo);
            grbPhuCap.Columns.Clear();
            if ((dtLoaiPhuCap != null) && (dtLoaiPhuCap.Rows.Count > 0))
            {
                foreach (DataRow dr in dtLoaiPhuCap.Rows)
                {
                    if ("" + dr["KyHieu"] == "PCGV&YT")
                        IDPhuCapGV_YT = int.Parse(dr["NS_LoaiPhuCapID"].ToString());

                    dtGiaoVien.Columns.Add(dr["NS_LoaiPhuCapID"].ToString(), typeof(double));
                    bgc = new BandedGridColumn();
                    grbPhuCap.Columns.Add(bgc);

                    SetColumnBandCaption(bgc, dr["TenLoaiPhuCap"].ToString(), dr["NS_LoaiPhuCapID"].ToString(), 130, DevExpress.Utils.HorzAlignment.Default, false);
                    bgc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    bgc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    bgc.DisplayFormat.FormatString = "n2";
                    bgc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    bgc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    bgvBangLuong.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgc });
                }
                bgc = new BandedGridColumn();
                grbPhuCap.Columns.Add(bgc);

                SetColumnBandCaption(bgc, "Tổng hệ số phụ cấp", "TongHeSoPhuCap", 120, DevExpress.Utils.HorzAlignment.Default, false);
                bgc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                bgc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                bgc.DisplayFormat.FormatString = "n2";
                bgc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                bgvBangLuong.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgc });

                bgc = new BandedGridColumn();
                grbPhuCap.Columns.Add(bgc);

                SetColumnBandCaption(bgc, "Thành tiền", "ThanhTienPhuCap", 120, DevExpress.Utils.HorzAlignment.Default, false);
                bgc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                bgc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                bgc.DisplayFormat.FormatString = "n2";
                bgc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                bgvBangLuong.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgc });
            }
        }

        private void XuLyTable()
        {
            dtTemp = oBNS_Luong.Get_BangLuong(DateTime.Parse(dtpTinhDenNgay.EditValue.ToString()));
            DataRow drNew;
            DataRow[] drLuong;
            try
            {
                CloseWaitDialog();
                if (dtTemp.Rows.Count > 0)
                {
                    string NS_GiaoVienID = dtTemp.Rows[0]["NS_GiaoVienID"].ToString();
                    drNew = dtGiaoVien.NewRow();
                    drNew["NS_GiaoVienID"] = int.Parse(NS_GiaoVienID);
                    drNew["TenDonVi"] = dtTemp.Rows[0]["TenDonVi"].ToString();
                    drNew["HoTen"] = dtTemp.Rows[0]["HoTen"].ToString();
                    drNew["TenGioiTinh"] = dtTemp.Rows[0]["TenGioiTinh"].ToString();
                    if (("" + dtTemp.Rows[0]["NgaySinh"]) != "")
                        drNew["NgaySinh"] = dtTemp.Rows[0]["NgaySinh"];
                    if (("" + dtTemp.Rows[0]["NgayTuyenDung"]) != "")
                        if (dtTemp.Rows[0]["NgayTuyenDung"].ToString() != "01/01/1900")
                            drNew["NgayTuyenDung"] = dtTemp.Rows[0]["NgayTuyenDung"];
                    drNew["TenTrinhDoChuyenMon"] = dtTemp.Rows[0]["TenTrinhDoChuyenMon"].ToString();
                    drNew["TenChucDanh"] = dtTemp.Rows[0]["TenChucDanh"].ToString();
                    drNew["MaNgachCongChuc"] = dtTemp.Rows[0]["MaNgachCongChuc"].ToString();
                    if (("" + dtTemp.Rows[0]["TuNgay"]) != "")
                        drNew["TuNgay"] = dtTemp.Rows[0]["TuNgay"];
                    if (("" + dtTemp.Rows[0]["HeSoLuong"]) != "")
                        drNew["HeSoLuong"] = dtTemp.Rows[0]["HeSoLuong"];
                    if (("" + dtTemp.Rows[0]["PhanTramHuong"]) != "")
                        drNew["PhanTramHuong"] = dtTemp.Rows[0]["PhanTramHuong"];
                    if (("" + dtTemp.Rows[0]["ThanhTienLuong"]) != "")
                        drNew["ThanhTienLuong"] = dtTemp.Rows[0]["ThanhTienLuong"];

                    drLuong = dtTemp.Select("NS_GiaoVienID =" + NS_GiaoVienID);
                    LuongCoBan = double.Parse("0" + dtTemp.Rows[0]["LuongCoBan"].ToString());


                    double TongPhuCap = 0, PhuCapGV_YT = 0;
                    foreach (DataRow dr in dtTemp.Rows)
                    {
                        if (dr["NS_GiaoVienID"].ToString() != NS_GiaoVienID)
                        {
                            if (("" + dr["IsGiaoVienChinhTri"] == "" ? false : bool.Parse(dr["IsGiaoVienChinhTri"].ToString())))
                                PhuCapGV_YT = Math.Round((TongPhuCap + double.Parse("0" + drNew["HeSoLuong"])) * 0.4, 2, MidpointRounding.AwayFromZero);
                            else
                                PhuCapGV_YT = Math.Round((TongPhuCap + double.Parse("0" + drNew["HeSoLuong"])) * 0.3, 2, MidpointRounding.AwayFromZero);

                            TongPhuCap = TongPhuCap + PhuCapGV_YT;
                            drNew[IDPhuCapGV_YT.ToString()] = PhuCapGV_YT;
                            drNew["TongHeSoPhuCap"] = TongPhuCap;
                            drNew["ThanhTienPhuCap"] = (TongPhuCap * LuongCoBan * double.Parse("0" + drNew["PhanTramHuong"])) / 100;
                            drNew["TongTienLuongVaPhuCap"] = double.Parse("0" + drNew["ThanhTienLuong"]) + double.Parse("0" + drNew["ThanhTienPhuCap"]);
                            dtGiaoVien.Rows.Add(drNew);
                            TongPhuCap = 0;
                            NS_GiaoVienID = dr["NS_GiaoVienID"].ToString();
                            drNew = dtGiaoVien.NewRow();

                            drNew["NS_GiaoVienID"] = int.Parse(NS_GiaoVienID);
                            drNew["TenDonVi"] = dr["TenDonVi"].ToString();
                            drNew["HoTen"] = dr["HoTen"].ToString();
                            drNew["TenGioiTinh"] = dr["TenGioiTinh"].ToString();
                            if (("" + dr["NgaySinh"]) != "")
                                drNew["NgaySinh"] = dr["NgaySinh"];
                            if (("" + dr["NgayTuyenDung"]) != "")
                                drNew["NgayTuyenDung"] = dr["NgayTuyenDung"];
                            drNew["TenTrinhDoChuyenMon"] = dr["TenTrinhDoChuyenMon"].ToString();
                            drNew["TenChucDanh"] = dr["TenChucDanh"].ToString();
                            drNew["MaNgachCongChuc"] = dr["MaNgachCongChuc"].ToString();
                            if (("" + dr["TuNgay"]) != "")
                                drNew["TuNgay"] = dr["TuNgay"];
                            if (("" + dr["HeSoLuong"]) != "")
                                drNew["HeSoLuong"] = dr["HeSoLuong"];
                            if (("" + dr["PhanTramHuong"]) != "")
                                drNew["PhanTramHuong"] = dr["PhanTramHuong"];
                            if (("" + dr["ThanhTienLuong"]) != "")
                                drNew["ThanhTienLuong"] = dr["ThanhTienLuong"];
                            drLuong = dtTemp.Select("NS_GiaoVienID =" + NS_GiaoVienID);
                            if (("" + dr["HeSoPhuCap"]) != "" && "" + dr["KyHieu"] != "PCGV&YT")
                            {
                                drNew[dr["NS_LoaiPhuCapID"].ToString()] = dr["HeSoPhuCap"];
                                TongPhuCap += double.Parse(dr["HeSoPhuCap"].ToString());
                            }
                        }
                        else
                        {
                            if (("" + dr["HeSoPhuCap"]) != "" && "" + dr["KyHieu"] != "PCGV&YT")
                            {
                                drNew[dr["NS_LoaiPhuCapID"].ToString()] = dr["HeSoPhuCap"];
                                TongPhuCap += double.Parse(dr["HeSoPhuCap"].ToString());
                            }
                        }
                    }

                    if (("" + dtTemp.Rows[dtTemp.Rows.Count - 1]["IsGiaoVienChinhTri"] == "" ? false : bool.Parse(dtTemp.Rows[dtTemp.Rows.Count - 1]["IsGiaoVienChinhTri"].ToString())))
                        PhuCapGV_YT = Math.Round((TongPhuCap + double.Parse("0" + drNew["HeSoLuong"])) * 0.4, 2, MidpointRounding.AwayFromZero);
                    else
                        PhuCapGV_YT = Math.Round((TongPhuCap + double.Parse("0" + drNew["HeSoLuong"])) * 0.3, 2, MidpointRounding.AwayFromZero);

                    TongPhuCap = TongPhuCap + PhuCapGV_YT;
                    drNew[IDPhuCapGV_YT.ToString()] = PhuCapGV_YT;
                    drNew["TongHeSoPhuCap"] = TongPhuCap;
                    drNew["ThanhTienPhuCap"] = (TongPhuCap * LuongCoBan * double.Parse("0" + drNew["PhanTramHuong"])) / 100;
                    drNew["TongTienLuongVaPhuCap"] = double.Parse("0" + drNew["ThanhTienLuong"]) + double.Parse("0" + drNew["ThanhTienPhuCap"]);
                    dtGiaoVien.Rows.Add(drNew);
                }
            }
            catch (Exception ex)
            {
                ThongBaoLoi(ex.Message);
            }
        }

        private void bgvBangLuong_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            XuatTheoTemplate();
        }

        private void XuatTheoTemplate()
        {
            if (dtGiaoVien.Rows.Count == 0)
            {
                ThongBao("Không có dữ liệu để xuất ra excel.");
                return;
            }
            string DuongDan = Application.StartupPath;
            string strFileExcel = DuongDan + "\\Template\\BangLuong.xls";
            if (!File.Exists(strFileExcel))
            {
                ThongBao("Không tìm thấy file " + strFileExcel + ". Đề nghị kiểm tra lại đường dẫn thư mục hiện tại!");
                return;
            }
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Excel file (*.xls)|*.xls";
            sv.Title = "Xuất dữ liệu";
            if (sv.ShowDialog() == DialogResult.OK)
            {
                string strTenFileExcelMoi = sv.FileName;
                try
                {
                    File.Copy(strFileExcel, strTenFileExcelMoi, true);
                }
                catch (Exception ex)
                {
                    ThongBaoLoi("File excel đang được mở. Đề nghị đóng file này trước khi xuất dữ liệu! Thông báo lỗi: " + ex.Message);
                    return;
                }
                finally { }
                XuatDuLieuRaExcel(dtGiaoVien, strTenFileExcelMoi);
                ThongBao("Xuất dữ liệu thành công!");
            }
        }

        private void XuatDuLieuRaExcel(DataTable dtChiTiet, string FileExcel)
        {
            CreateWaitDialog("Đang xuất dữ liệu ra file Excel, xin vui lòng chờ!", "Xuất dữ liệu");
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            int i = 0;
            int DongBatDau = 9;
            Excel.Range cel;

            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            try
            {
                excel.Application.Workbooks.Open(FileExcel, true, false, true, "", "", true, true, true, true, true, true, true, true, false);
                // Phần này là thêm Header.
                excel.Cells[5, 1] = "BÁO CÁO DANH SÁCH CÁN BỘ CÔNG CHỨC VÀ QUỸ TIỀN LƯƠNG TÍNH ĐẾN NGÀY " + DateTime.Parse(dtpTinhDenNgay.EditValue.ToString()).ToString("dd/MM/yyyy");
                cel = (Excel.Range)excel.Cells[5, 1];

                excel.Cells[7, 1] = "HSL: " + LuongCoBan.ToString("#,###") + "đ";
                cel = (Excel.Range)excel.Cells[7, 1];

                // Phần này thêm các tiêu đề Loại phụ cấp.
                for (int j = 0; j < dtLoaiPhuCap.Rows.Count; j++)
                {
                    excel.Cells[DongBatDau, 12 + j] = dtLoaiPhuCap.Rows[j]["TenLoaiPhuCap"];
                    cel = (Excel.Range)(excel.Cells[DongBatDau, 12 + j]);
                }

                // Phần này là thêm Detail.
                DongBatDau = 11;
                string TenDonVi = dtChiTiet.Rows[0]["TenDonVi"].ToString();
                int STT = 0;
                double SumHeSoLuong = 0, SumThanhTienLuong = 0, SumTongHeSoPhuCap = 0, SumTongTienLuongVaPhuCap = 0, SumThanhTienPhuCap = 0,
                SumPhuCap1 = 0, SumPhuCap2 = 0, SumPhuCap3 = 0, SumPhuCap4 = 0, SumPhuCap5 = 0, SumPhuCap6 = 0;
                for (i = 0; i < dtChiTiet.Rows.Count; i++)
                {
                    if (TenDonVi != dtChiTiet.Rows[i]["TenDonVi"].ToString() || i == 0)
                    {
                        STT = 0;
                        excel.Cells[i + DongBatDau, 2] = dtChiTiet.Rows[i]["TenDonVi"].ToString();
                        cel = (Excel.Range)(excel.Cells[i + DongBatDau, 2]);
                        cel.Font.Bold = true;
                        cel.Borders.Value = 1;
                        DongBatDau += 1;
                    }
                    excel.Cells[i + DongBatDau, 1] = STT + 1;
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 1]);
                    cel.Borders.Value = 1;

                    excel.Cells[i + DongBatDau, 2] = dtChiTiet.Rows[i]["HoTen"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 2]);
                    cel.Borders.Value = 1;

                    if ((dtChiTiet.Rows[i]["TenGioiTinh"] + "").ToUpper() == "NAM")
                        excel.Cells[i + DongBatDau, 3] = dtChiTiet.Rows[i]["NgaySinh"] + "";
                    else
                        excel.Cells[i + DongBatDau, 4] = dtChiTiet.Rows[i]["NgaySinh"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 3]);
                    cel.Borders.Value = 1;
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 4]);
                    cel.Borders.Value = 1;

                    excel.Cells[i + DongBatDau, 5] = dtChiTiet.Rows[i]["NgayTuyenDung"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 5]);
                    cel.Borders.Value = 1;

                    excel.Cells[i + DongBatDau, 6] = dtChiTiet.Rows[i]["TenTrinhDoChuyenMon"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 6]);
                    cel.Borders.Value = 1;

                    excel.Cells[i + DongBatDau, 7] = dtChiTiet.Rows[i]["TenChucDanh"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 7]);
                    cel.Borders.Value = 1;

                    excel.Cells[i + DongBatDau, 8] = dtChiTiet.Rows[i]["MaNgachCongChuc"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 8]);
                    cel.Borders.Value = 1;

                    excel.Cells[i + DongBatDau, 9] = dtChiTiet.Rows[i]["TuNgay"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 9]);
                    cel.Borders.Value = 1;

                    excel.Cells[i + DongBatDau, 10] = dtChiTiet.Rows[i]["HeSoLuong"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 10]);
                    cel.Borders.Value = 1;
                    SumHeSoLuong += double.Parse("0" + dtChiTiet.Rows[i]["HeSoLuong"] + "");

                    excel.Cells[i + DongBatDau, 11] = dtChiTiet.Rows[i]["ThanhTienLuong"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 11]);
                    cel.Borders.Value = 1;
                    SumThanhTienLuong += double.Parse("0" + dtChiTiet.Rows[i]["ThanhTienLuong"] + "");

                    excel.Cells[i + DongBatDau, 18] = dtChiTiet.Rows[i]["TongHeSoPhuCap"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 18]);
                    cel.Borders.Value = 1;
                    SumTongHeSoPhuCap += double.Parse("0" + dtChiTiet.Rows[i]["TongHeSoPhuCap"] + "");

                    excel.Cells[i + DongBatDau, 19] = dtChiTiet.Rows[i]["ThanhTienPhuCap"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 19]);
                    cel.Borders.Value = 1;
                    SumThanhTienPhuCap += double.Parse("0" + dtChiTiet.Rows[i]["ThanhTienPhuCap"] + "");

                    excel.Cells[i + DongBatDau, 20] = dtChiTiet.Rows[i]["TongTienLuongVaPhuCap"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 20]);
                    cel.Borders.Value = 1;
                    SumTongTienLuongVaPhuCap += double.Parse("0" + dtChiTiet.Rows[i]["TongTienLuongVaPhuCap"] + "");

                    STT += 1;
                    // loai phu cap
                    // Phần này thêm các tiêu đề Loại phụ cấp.
                    for (int j = 0; j < dtLoaiPhuCap.Rows.Count; j++)
                    {
                        excel.Cells[i + DongBatDau, 12 + j] = dtChiTiet.Rows[i][dtLoaiPhuCap.Rows[j]["NS_LoaiPhuCapID"].ToString()] + "";
                        cel = (Excel.Range)(excel.Cells[i + DongBatDau, 12 + j]);
                        cel.Borders.Value = 1;
                        if (j == 0)
                            SumPhuCap1 += double.Parse("0" + dtChiTiet.Rows[i][dtLoaiPhuCap.Rows[j]["NS_LoaiPhuCapID"].ToString()] + "");
                        if (j == 1)
                            SumPhuCap2 += double.Parse("0" + dtChiTiet.Rows[i][dtLoaiPhuCap.Rows[j]["NS_LoaiPhuCapID"].ToString()] + "");
                        if (j == 2)
                            SumPhuCap3 += double.Parse("0" + dtChiTiet.Rows[i][dtLoaiPhuCap.Rows[j]["NS_LoaiPhuCapID"].ToString()] + "");
                        if (j == 3)
                            SumPhuCap4 += double.Parse("0" + dtChiTiet.Rows[i][dtLoaiPhuCap.Rows[j]["NS_LoaiPhuCapID"].ToString()] + "");
                        if (j == 4)
                            SumPhuCap5 += double.Parse("0" + dtChiTiet.Rows[i][dtLoaiPhuCap.Rows[j]["NS_LoaiPhuCapID"].ToString()] + "");
                        if (j == 5)
                            SumPhuCap6 += double.Parse("0" + dtChiTiet.Rows[i][dtLoaiPhuCap.Rows[j]["NS_LoaiPhuCapID"].ToString()] + "");
                    }
                    TenDonVi = dtChiTiet.Rows[i]["TenDonVi"].ToString();
                }
                // =SUM(M11:M218)
                // phan tong cong
                for (int j = 1; j < 10; j++)
                {
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, j]);
                    cel.Borders.Value = 1;
                }
                excel.Cells[dtChiTiet.Rows.Count + DongBatDau, 10] = SumHeSoLuong;
                cel = (Excel.Range)(excel.Cells[i + DongBatDau, 10]);
                cel.Borders.Value = 1;

                excel.Cells[dtChiTiet.Rows.Count + DongBatDau, 11] = SumThanhTienLuong;
                cel = (Excel.Range)(excel.Cells[i + DongBatDau, 11]);
                cel.Borders.Value = 1;

                excel.Cells[dtChiTiet.Rows.Count + DongBatDau, 12] = SumPhuCap1;
                cel = (Excel.Range)(excel.Cells[i + DongBatDau, 12]);
                cel.Borders.Value = 1;
                excel.Cells[dtChiTiet.Rows.Count + DongBatDau, 13] = SumPhuCap2;
                cel = (Excel.Range)(excel.Cells[i + DongBatDau, 13]);
                cel.Borders.Value = 1;
                excel.Cells[dtChiTiet.Rows.Count + DongBatDau, 14] = SumPhuCap3;
                cel = (Excel.Range)(excel.Cells[i + DongBatDau, 14]);
                cel.Borders.Value = 1;
                excel.Cells[dtChiTiet.Rows.Count + DongBatDau, 15] = SumPhuCap4;
                cel = (Excel.Range)(excel.Cells[i + DongBatDau, 15]);
                cel.Borders.Value = 1;
                excel.Cells[dtChiTiet.Rows.Count + DongBatDau, 16] = SumPhuCap5;
                cel = (Excel.Range)(excel.Cells[i + DongBatDau, 16]);
                cel.Borders.Value = 1;
                excel.Cells[dtChiTiet.Rows.Count + DongBatDau, 17] = SumPhuCap6;
                cel = (Excel.Range)(excel.Cells[i + DongBatDau, 17]);
                cel.Borders.Value = 1;

                excel.Cells[dtChiTiet.Rows.Count + DongBatDau, 18] = SumTongHeSoPhuCap;
                cel = (Excel.Range)(excel.Cells[i + DongBatDau, 18]);
                cel.Borders.Value = 1;

                excel.Cells[dtChiTiet.Rows.Count + DongBatDau, 19] = SumThanhTienPhuCap;
                cel = (Excel.Range)(excel.Cells[i + DongBatDau, 19]);
                cel.Borders.Value = 1;

                excel.Cells[dtChiTiet.Rows.Count + DongBatDau, 20] = SumTongTienLuongVaPhuCap;
                cel = (Excel.Range)(excel.Cells[i + DongBatDau, 20]);
                cel.Borders.Value = 1;

                // Phần này là thêm Folter.
                int Folter = dtChiTiet.Rows.Count;
                excel.Cells[DongBatDau + Folter + 2, 2] = "Xác nhận của cơ quan xét duyệt biên chế quỹ tiền lương";
                ((Excel.Range)excel.Cells[DongBatDau + Folter + 2, 2]).Font.Bold = true;
                excel.Cells[DongBatDau + Folter + 2, 19] = "Hà nội, ngày " + DateTime.Parse(dtpTinhDenNgay.EditValue.ToString()).Day.ToString() + " tháng " + DateTime.Parse(dtpTinhDenNgay.EditValue.ToString()).Month.ToString() + " năm " + DateTime.Parse(dtpTinhDenNgay.EditValue.ToString()).Year.ToString();
                ((Excel.Range)excel.Cells[DongBatDau + Folter + 2, 19]).Font.Italic = true;
                excel.Cells[DongBatDau + Folter + 3, 2] = "* Chỉ tiêu biên chế giao năm " + DateTime.Parse(dtpTinhDenNgay.EditValue.ToString()).Year + " ngành sự nghiệp giáo dục là" + "       " + " người";
                excel.Cells[DongBatDau + Folter + 3, 18] = "HIỆU TRƯỞNG";
                ((Excel.Range)excel.Cells[DongBatDau + Folter + 3, 18]).Font.Bold = true;
                excel.Cells[DongBatDau + Folter + 4, 2] = "* Số người hiện có(kể cả thử việc, HĐ làm việc 68) đến ngày " + DateTime.Parse(dtpTinhDenNgay.EditValue.ToString()).ToString("dd/MM/yyyy") + " là " + dtChiTiet.Rows.Count + " người";
                excel.Cells[DongBatDau + Folter + 5, 2] = "* Quỹ tiền lương 1 tháng     " + " năm       là              triệu đồng, từ 1 tháng      năm         ";
                excel.Cells[DongBatDau + Folter + 7, 2] = "Hà nội, ngày " + DateTime.Parse(dtpTinhDenNgay.EditValue.ToString()).Day.ToString() + " tháng " + DateTime.Parse(dtpTinhDenNgay.EditValue.ToString()).Month.ToString() + " năm " + DateTime.Parse(dtpTinhDenNgay.EditValue.ToString()).Year.ToString();
                ((Excel.Range)excel.Cells[DongBatDau + Folter + 7, 2]).Font.Italic = true;
                excel.Cells[DongBatDau + Folter + 7, 18] = "Tạ Văn Hương";
                ((Excel.Range)excel.Cells[DongBatDau + Folter + 7, 18]).Font.Bold = true;
                excel.Cells[DongBatDau + Folter + 8, 2] = "T/L Bộ trưởng Bộ Nông nghiệp & PTNN";
                ((Excel.Range)excel.Cells[DongBatDau + Folter + 8, 4]).Font.Bold = true;
            }
            catch (Exception e)
            {
                CloseWaitDialog();
                this.Cursor = System.Windows.Forms.Cursors.Default;
                ThongBaoLoi("Xuất dữ liệu không thành công! Hãy đóng file Excel Phiếu báo điểm trước khi xuất dữ liệu. Thông báo lỗi: " + e.Message);
                return;
            }
            finally
            {
                excel.Application.Workbooks[1].Save();
                excel.Application.Workbooks.Close();
                excel.Application.Quit();
                excel.Quit();
                Process.Start(FileExcel);
                CloseWaitDialog();
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }
    }
}